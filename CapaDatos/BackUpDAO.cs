using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class BackUpDAO
    {
        public MiDbContext context;

        public BackUpDAO (MiDbContext context)
        {
            this.context = context;
        }

        public string Backup()
        {
            string connection_string = this.context.Database.Connection.ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connection_string))
            {
                    // @: Le dice a C# que tome todo el texto literalmente tal cual está escrito
                    string unidad = Directory.Exists(@"D:\") ? @"D:\" : @"C:\";
                    string carpeta_destino = Path.Combine(unidad, "BackUp_POS");

                    if (!Directory.Exists(carpeta_destino))
                    {
                        Directory.CreateDirectory(carpeta_destino);
                    }

                    string fecha = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    string file_name = "BackUp" + fecha + ".bak";

                    // Sirve para incrustar variables en una cadena, usando las llaves alrededor de la variable
                    string ruta_final = Path.Combine(carpeta_destino, $"{file_name}");

                    StringBuilder query = new StringBuilder();

                    /*
                        La N delante de las comillas simples indica que esa cadena de texto es Unicode (específicamente de tipo NVARCHAR / NCHAR en SQL Server).
                        ¿Por qué es importante usarla en rutas y nombres?
                        _ Soporte de caracteres especiales y tildes: 
                        Permite guardar rutas de carpetas o nombres de backup que contengan tildes (á, é, í, ó, ú), eñes (ñ), símbolos o caracteres de cualquier idioma 
                        sin que SQL Server los convierta en signos de interrogación (?) o letras corruptas.
                        _ Buenas prácticas en C#: 
                        Cuando pasás parámetros de texto (string) desde C# a SQL Server, .NET maneja todos sus strings en Unicode (UTF-16) de forma nativa. 
                        Usar N'...' asegura que no haya conversión ni pérdida de caracteres entre tu aplicación y el motor de base de datos.
                    */

                    query.AppendLine("BACKUP DATABASE [db_distribucion] TO DISK = @Ruta" + // N'D:\\Backup_POS\\" + file_name + "' " +
                                         " WITH " + // Parametros de la sentencia WITH ..
                                         "NOFORMAT, " + // Conserva el media header y los conjuntos de copias de seguridad existentes en el archivo - Lo opuesto a FORMAT que borra todo el archivo y crea una estructura nueva.
                                         "NOINIT, " + // Agrega este nuevo backup al final del archivo especificado, manteniendo intactos los backups anteriores guardados dentro de ese mismo archivo - INIT: si quisieras sobrescribir el contenido previo.
                                         "NAME = 'DB_distribucion - Full Database Backup´" + fecha + "', " + // Asigna una etiqueta interna al conjunto de respaldo. Sirve para identificarlo luego al listar el historial del archivo con RESTORE HEADERONLY.
                                         "SKIP, " + // Omite la verificación de fecha de expiración de los backups existentes en el archivo antes de escribir encima o agregar uno nuevo.
                                         "NOREWIND, " + // Mantiene la cinta abierta al finalizar. Es un parámetro heredado de las unidades de cinta magnética; SQL Server lo ignora cuando el destino es DISK.
                                         "NOUNLOAD, " + // Indica que no se expulse automáticamente la cinta al terminar.Al igual que NOREWIND, no tiene efecto en respaldos a disco y suele aparecer porque es la plantilla que genera por defecto el asistente de SSMS.
                                         "STATS = 10"); // Envía un mensaje informativo de progreso cada vez que se completa un 10% del proceso. Es el parámetro clave para alimentar barras de progreso.

                    // SqlCommand representa un procedimiento almacenado o una instruccion Transac-SQL que se ejecuta en una BD de SQL Server
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);

                    conexion.Open();
                    cmd.Parameters.Add("@Ruta", SqlDbType.NVarChar, 500).Value = ruta_final;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;
                    cmd.ExecuteNonQuery();
                    conexion.Close();

                    return ruta_final;
            }
        }

        // RESTORE con reubicacion
        public void Restore(string rutaBak, int posicionFile = 1)
        {
            string nombreBaseDestino = "db_distribucion";

            // 1. Cambiamos la conexión a 'master' para no bloquear la base que vamos a restaurar
            var builder = new SqlConnectionStringBuilder(this.context.Database.Connection.ConnectionString)
            {
                InitialCatalog = "master"
            };

            using (SqlConnection conexion = new SqlConnection(builder.ConnectionString))
            {
                conexion.Open();

                // 2. Leemos los nombres lógicos internos del archivo .bak (Data y Log)
                string logicalData = "";
                string logicalLog = "";

                // RESOTRE FILELISTONLY - devuelve una lista con los archivos de datos, de registro y contenedores incluidos en un conjunto de copia de seguridad
                // Esto srive siempre y cuando el archivo no tengas mas de un BackUp en el historial. O debemos indicar la posicion.
                using (SqlCommand cmdFileList = new SqlCommand("RESTORE FILELISTONLY FROM DISK = @RutaBak;", conexion))
                {
                    cmdFileList.Parameters.Add("@RutaBak", SqlDbType.NVarChar, 500).Value = rutaBak;

                    using (SqlDataReader reader = cmdFileList.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tipo = reader["Type"].ToString(); // 'D' = Data (.mdf), 'L' = Log (.ldf)
                            string nombreLogico = reader["LogicalName"].ToString();

                            if (tipo == "D") logicalData = nombreLogico;
                            else if (tipo == "L") logicalLog = nombreLogico;
                        }
                    }
                }

                // 3. Verificamos si la base de datos ya existe en este servidor y obtenemos sus rutas físicas
                string rutaMdfDestino = "";
                string rutaLdfDestino = "";
                bool baseExiste = false;

                string queryRutasActuales = @"
                    SELECT type_desc, physical_name 
                    FROM sys.master_files 
                    WHERE database_id = DB_ID(@NombreBD);";

                using (SqlCommand cmdRutas = new SqlCommand(queryRutasActuales, conexion))
                {
                    cmdRutas.Parameters.Add("@NombreBD", SqlDbType.NVarChar, 128).Value = nombreBaseDestino;

                    using (SqlDataReader reader = cmdRutas.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            baseExiste = true;
                            string tipo = reader["type_desc"].ToString(); // 'ROWS' (.mdf) o 'LOG' (.ldf)
                            string rutaFisica = reader["physical_name"].ToString();

                            if (tipo == "ROWS") rutaMdfDestino = rutaFisica;
                            else if (tipo == "LOG") rutaLdfDestino = rutaFisica;
                        }
                    }
                }

                // 4. Si la base NO existe (instalación nueva), usamos las carpetas por defecto del servidor
                if (!baseExiste)
                {
                    string queryDefaultPaths = @"
                        SELECT 
                            SERVERPROPERTY('InstanceDefaultDataPath'), 
                            SERVERPROPERTY('InstanceDefaultLogPath');";

                    using (SqlCommand cmdDefaults = new SqlCommand(queryDefaultPaths, conexion))
                    using (SqlDataReader reader = cmdDefaults.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string dirData = reader[0].ToString();
                            string dirLog = reader[1].ToString();

                            rutaMdfDestino = Path.Combine(dirData, $"{nombreBaseDestino}.mdf");
                            rutaLdfDestino = Path.Combine(dirLog, $"{nombreBaseDestino}_log.ldf");
                        }
                    }
                }

                // 5. Construimos y ejecutamos el Restore con cierre de conexiones activas
                StringBuilder queryRestore = new StringBuilder();

                if (baseExiste)
                {
                    // El WITH ROLLBACK INMEDIATE basicamente hace que todos los usuarios y conexiones que se estan dando en el momento
                    // se cierren, en caso de no estar SQL estaria esperando que se cierren por su cuente lo cual generaria mayor demora.
                    queryRestore.AppendLine($@"
                        BEGIN TRY
                            ALTER DATABASE [{nombreBaseDestino}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

                            RESTORE DATABASE [{nombreBaseDestino}]
                            FROM DISK = @RutaBak
                            WITH FILE = @Posicion,
                                 MOVE @LogicalData TO @RutaMdf,
                                 MOVE @LogicalLog  TO @RutaLdf,
                                 REPLACE,
                                 RECOVERY,
                                 STATS = 10;

                            ALTER DATABASE [{nombreBaseDestino}] SET MULTI_USER;
                        END TRY
                        BEGIN CATCH
                            IF EXISTS (SELECT 1 FROM sys.databases WHERE name = '{nombreBaseDestino}' AND user_access_desc = 'SINGLE_USER')
                                ALTER DATABASE [{nombreBaseDestino}] SET MULTI_USER;
                            THROW;
                        END CATCH;");
                }
                else
                {
                    queryRestore.AppendLine($@"
                        RESTORE DATABASE [{nombreBaseDestino}]
                        FROM DISK = @RutaBak
                        WITH FILE = @Posicion,
                             MOVE @LogicalData TO @RutaMdf,
                             MOVE @LogicalLog  TO @RutaLdf,
                             REPLACE,
                             RECOVERY,
                             STATS = 10;");
                }

                using (SqlCommand cmdRestore = new SqlCommand(queryRestore.ToString(), conexion))
                {
                    cmdRestore.CommandType = CommandType.Text;
                    cmdRestore.CommandTimeout = 0;

                    cmdRestore.Parameters.Add("@RutaBak", SqlDbType.NVarChar, 500).Value = rutaBak;
                    cmdRestore.Parameters.Add("@Posicion", SqlDbType.Int).Value = posicionFile;
                    cmdRestore.Parameters.Add("@LogicalData", SqlDbType.NVarChar, 128).Value = logicalData;
                    cmdRestore.Parameters.Add("@RutaMdf", SqlDbType.NVarChar, 500).Value = rutaMdfDestino;
                    cmdRestore.Parameters.Add("@LogicalLog", SqlDbType.NVarChar, 128).Value = logicalLog;
                    cmdRestore.Parameters.Add("@RutaLdf", SqlDbType.NVarChar, 500).Value = rutaLdfDestino;

                    cmdRestore.ExecuteNonQuery();

                    // Aca hay un tema que se dispara del WITH ROLLBACK INMEDIATE, que mata las conexiones dormidas que veniamos manejando
                    // lo que puede generar un error futuro, ya que el framework desconoce lo ocurrido.
                    SqlConnection.ClearAllPools();
                }
            }
        }

        public string GetBDActive() 
        { 
            return this.context.Database.Connection.Database;
        }

        public string GetFoldRestore()
        {
            // @: Le dice a C# que tome todo el texto literalmente tal cual está escrito
            string unidad = Directory.Exists(@"D:\")? @"D:\" : @"C:\";
            string carpeta_backup = Path.Combine(unidad, "BackUp_POS");

            if (!Directory.Exists(carpeta_backup))
            {
                Directory.CreateDirectory(carpeta_backup);
            }

            return carpeta_backup;
        }

        // RESTORE basico, sirve siempre y cuando la PC en la que se hace el RESTORE ya cuenta con lo archivos (.mdf y .ldf).
        public int Restore(string ruta)
        {
            string connection_string = this.context.Database.Connection.ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connection_string))
            {
                StringBuilder query = new StringBuilder();

                // Nos colocamos en la BD master 
                query.AppendLine("USE master;");

                // Seteamos la opcion de usuario unico.
                query.AppendLine("ALTER DATABASE [db_distribucion] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;");

                // Restauramos la BD
                query.AppendLine($"RESTORE DATABASE [db_distribucion] FROM DISK = N'{ruta}' WITH REPLACE;");

                // Volvemos a permitir los multiples usr+uarios.
                query.AppendLine("ALTER DATABASE [db_distribucion] SET MULTI_USER;");

                SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                conexion.Open();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conexion.Close();

                return 1;
            }
        }
        
        /*
        public List<BackupItem> ObtenerHistorialArchivo(string rutaBak)
        {
            var lista = new List<BackupItem>();

            // Conectamos a master para evitar bloqueos innecesarios
            var builder = new SqlConnectionStringBuilder(this.context.Database.Connection.ConnectionString)
            {
                InitialCatalog = "master"
            };

            using (SqlConnection conexion = new SqlConnection(builder.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("RESTORE HEADERONLY FROM DISK = @RutaBak;", conexion))
            {
                cmd.Parameters.Add("@RutaBak", SqlDbType.NVarChar, 500).Value = rutaBak;
                conexion.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Si tiene compresión usa CompressedBackupSize, sino BackupSize
                        long bytes = reader["CompressedBackupSize"] != DBNull.Value
                            ? Convert.ToInt64(reader["CompressedBackupSize"])
                            : Convert.ToInt64(reader["BackupSize"]);

                        lista.Add(new BackupItem
                        {
                            Posicion = Convert.ToInt32(reader["Position"]),
                            Nombre = reader["BackupName"]?.ToString() ?? "Sin nombre",
                            Fecha = Convert.ToDateTime(reader["BackupFinishDate"]),
                            TamanoMB = Math.Round((decimal)bytes / (1024 * 1024), 2)
                        });
                    }
                }
            }

            // Ordenamos del más reciente al más antiguo para que el último aparezca primero
            return lista.OrderByDescending(x => x.Posicion).ToList();
        }
        */

        /*
         public void RestoreConReubicacion(string rutaBak, string nombreBaseDestino, int posicionFile = 1)
         {
            
            // 1. Apuntamos la conexión a 'master' para no bloquear la base a restaurar
            var builder = new SqlConnectionStringBuilder(this.context.Database.Connection.ConnectionString)
            {
                InitialCatalog = "master"
            };

            using (SqlConnection conexion = new SqlConnection(builder.ConnectionString))
            {
                conexion.Open();

                // 2. Averiguamos las carpetas por defecto del servidor destino
                string rutaDatosServidor = "";
                string rutaLogsServidor = "";
                string queryRutas = "SELECT SERVERPROPERTY('InstanceDefaultDataPath'), SERVERPROPERTY('InstanceDefaultLogPath');";

                using (SqlCommand cmdRutas = new SqlCommand(queryRutas, conexion))
                using (SqlDataReader reader = cmdRutas.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        rutaDatosServidor = reader[0].ToString();
                        rutaLogsServidor = reader[1].ToString();
                    }
                }

                // 3. Leemos los nombres lógicos internos del archivo .bak
                string logicalData = "";
                string logicalLog = "";
                string queryFileList = "RESTORE FILELISTONLY FROM DISK = @RutaBak;";

                using (SqlCommand cmdFiles = new SqlCommand(queryFileList, conexion))
                {
                    cmdFiles.Parameters.Add("@RutaBak", SqlDbType.NVarChar, 500).Value = rutaBak;
                    using (SqlDataReader reader = cmdFiles.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tipo = reader["Type"].ToString(); // 'D' = Data (.mdf), 'L' = Log (.ldf)
                            string nombreLogico = reader["LogicalName"].ToString();

                            if (tipo == "D") logicalData = nombreLogico;
                            else if (tipo == "L") logicalLog = nombreLogico;
                        }
                    }
                }

                // 4. Armamos las nuevas rutas físicas combinando la carpeta del servidor + nombre de la BD
                string nuevoMdf = Path.Combine(rutaDatosServidor, $"{nombreBaseDestino}.mdf");
                string nuevoLdf = Path.Combine(rutaLogsServidor, $"{nombreBaseDestino}_log.ldf");
                string dbSegura = $"[{nombreBaseDestino.Replace("]", "]]")}]";

                // 5. Ejecutamos el Restore cerrando conexiones activas si la base ya existe
                string queryRestore = $@"
                    IF EXISTS (SELECT name FROM sys.databases WHERE name = @NombreBD)
                    BEGIN
                        ALTER DATABASE {dbSegura} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                    END

                    RESTORE DATABASE {dbSegura}
                    FROM DISK = @RutaBak
                    WITH FILE = @Posicion,
                         MOVE @LogicalData TO @NuevoMdf,
                         MOVE @LogicalLog  TO @NuevoLdf,
                         REPLACE,
                         RECOVERY,
                         STATS = 10;

                    ALTER DATABASE {dbSegura} SET MULTI_USER;";

                using (SqlCommand cmdRestore = new SqlCommand(queryRestore, conexion))
                {
                    cmdRestore.CommandTimeout = 0;
                    cmdRestore.Parameters.Add("@NombreBD", SqlDbType.NVarChar, 128).Value = nombreBaseDestino;
                    cmdRestore.Parameters.Add("@RutaBak", SqlDbType.NVarChar, 500).Value = rutaBak;
                    cmdRestore.Parameters.Add("@Posicion", SqlDbType.Int).Value = posicionFile;
                    cmdRestore.Parameters.Add("@LogicalData", SqlDbType.NVarChar, 128).Value = logicalData;
                    cmdRestore.Parameters.Add("@NuevoMdf", SqlDbType.NVarChar, 500).Value = nuevoMdf;
                    cmdRestore.Parameters.Add("@LogicalLog", SqlDbType.NVarChar, 128).Value = logicalLog;
                    cmdRestore.Parameters.Add("@NuevoLdf", SqlDbType.NVarChar, 500).Value = nuevoLdf;

                    cmdRestore.ExecuteNonQuery();
                }
            }
        }
        */
    }
}
