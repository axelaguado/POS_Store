using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_BackUp
    {
        
        public CN_BackUp() 
        { 
        }

        public string ObtenerBDActiva() 
        {
            using (var context = new MiDbContext()) 
            { 
                BackUpDAO backup = new BackUpDAO(context);
                return backup.GetBDActive();
            } 
        }

        public string ObtenerCarpetaRestore()
        {
            using (var context = new MiDbContext())
            {
                BackUpDAO backup = new BackUpDAO(context);
                return backup.GetFoldRestore();
            }
        }

        public string BackUp() 
        {
            using (var context = new MiDbContext())
            {
                BackUpDAO backupDAO = new BackUpDAO(context);
                return backupDAO.Backup();
            }
        }

        public void Restore(string ruta, int posicion = 1)
        {
            using (var context = new MiDbContext())
            {
                BackUpDAO backupDAO = new BackUpDAO(context);
                backupDAO.Restore(ruta, posicion);
            }
        }
    }
}
