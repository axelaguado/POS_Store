CREATE DATABASE Pos_store;

USE Pos_store;

CREATE TABLE Persona ( 
  id_persona INT IDENTITY (1,1), 
  dni_persona INT NOT NULL,
  nombre_persona VARCHAR(100) NOT NULL,
  apellido_persona VARCHAR(100) NOT NULL,
  fecha_nacimiento DATE NOT NULL,
  email VARCHAR(100) NOT NULL, 
  telefono BIGINT NOT NULL,
  sexo VARCHAR(10) NOT NULL, 
  CONSTRAINT PK_persona PRIMARY KEY (id_persona) 
);

-- RESTRICCIONES -- 
ALTER TABLE Persona ADD CONSTRAINT UNQ_persona_dni UNIQUE (dni_persona); 
ALTER TABLE Persona ADD CONSTRAINT UNQ_persona_telefono UNIQUE (telefono);
ALTER TABLE Persona ADD CONSTRAINT UNQ_persona_email UNIQUE (email);

ALTER TABLE Persona ADD CONSTRAINT CHK_persona_nacimiento CHECK (DATEDIFF(YEAR, fecha_nacimiento, GETDATE()) < 100);
ALTER TABLE Persona ADD CONSTRAINT CHK_persona_email CHECK (email LIKE '%_@__%.__%')
ALTER TABLE Persona ADD CONSTRAINT CHK_persona_sexo CHECK ((sexo LIKE 'Mujer') OR (sexo LIKE 'Hombre'));
 
-- Nos permite conocer la informacion de nuestra tablas y definicion de las columnas --
-- EXEC sp_help 'Persona' -- 
-------------------------------------------------------------------

CREATE TABLE Direccion (
	id_direccion INT IDENTITY (1, 1),
	id_persona INT NOT NULL,
	calle VARCHAR (100) NOT NULL,
	altura INT NOT NULL,
	piso VARCHAR(10),
	depto INT
);

-- RESTRICCIONES --
ALTER TABLE Direccion ADD CONSTRAINT PK_direccion PRIMARY KEY (id_direccion); 
ALTER TABLE Direccion ADD CONSTRAINT FK_direccion_persona FOREIGN KEY (id_persona) REFERENCES Persona(id_persona);
 
 -------------------------------------------------------------------

 CREATE TABLE Tipo_usuario (
  id_tipo INT IDENTITY (1,1),
  descripcion_tipo VARCHAR(50) NOT NULL,
  CONSTRAINT PK_tipo_usuario PRIMARY KEY (id_tipo)
);

-- Insercion de los tipos de usuario --
INSERT Tipo_usuario (descripcion_tipo) VALUES ('Administrador');
INSERT Tipo_usuario (descripcion_tipo) VALUES ('Gerente');
INSERT Tipo_usuario (descripcion_tipo) VALUES ('Empleado');

--------------------------------------------------------------------
 
CREATE TABLE Usuario (
  -- id_user INT IDENTITY(1,1),--
  id_persona INT NOT NULL,
  username VARCHAR(100) NOT NULL,
  contraseña VARCHAR(100) NOT NULL, 
  tipo_perfil INT NOT NULL,
  estado BIT NOT NULL,
  -- CONSTRAINT PK_usuario PRIMARY KEY (id_user), --
  CONSTRAINT FK_usuario_persona FOREIGN KEY (id_persona) REFERENCES Persona (id_persona), 
  CONSTRAINT FK_usuario_tipo FOREIGN KEY (tipo_perfil) REFERENCES tipo_usuario(id_tipo)
);

-- RESTRICCIONES --
ALTER TABLE Usuario ADD CONSTRAINT CHK_usuario_contraseña CHECK (LEN(contraseña) > 8);
ALTER TABLE Usuario ADD CONSTRAINT UNQ_usuario_usuario UNIQUE (username);
 
 /* Esto es lo que realmente terminamos haciendo en la tabla
-- Si quisiera establecer uno a uno, es necesario que la FK tambien sea PK, veremos que ocurriria para el caso de la relacion Usuario/ Persona: -- 
-- Debemos eliminar la PK(id_user)
ALTER TABLE Usuario DROP CONSTRAINT PK_usuario;
ALTER TABLE Usuario DROP COLUMN id_user
-- Definimos nuestra FK id_persona tambien como PK
ALTER TABLE Usuario ADD CONSTRAINT PK_Usuario PRIMARY KEY (id_persona);
-- Con esto el id de nuestro usuario sera el mismo que el de persona, estableciendo asi un relacion 1 a 1. 
*/
DROP PROCEDURE IF EXISTS [InsertarPersona];

GO
-- Esta garcha no sirve para poner el identity en donde estaba --
-- La idea es implementar la restriccion sobre las inserciones relacionas de Persona, Direccion y Usuario --
-- De tal modo que si ya ocurrio el insert en persona y en direccion pero hubo un error en usuario, la persona no sea insertada de igual manera y asi los datos pueden seguir siendo
-- utilizados 
CREATE OR ALTER PROCEDURE InsertarPersona 
	@dni_persona INT,
	@nombre_persona VARCHAR (100),
	@apellido_persona VARCHAR (100),
	@fecha_nacimiento DATE,
	@email VARCHAR(100), 
	@telefono BIGINT,
	@sexo VARCHAR(10), 
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
AS
BEGIN
    SET @Resultado = 0;
    SET @Mensaje = '';

	-- Mis condiciones para que no se ejecute la insercion de persona --
    IF EXISTS (SELECT 1 FROM Persona WHERE dni_persona = @dni_persona)
    BEGIN
        SET @Mensaje = 'Ya existe una persona con ese DNI.';
        RETURN;
    END

	IF EXISTS (SELECT 1 FROM Persona WHERE emaiL = @email)
    BEGIN
        SET @Mensaje = 'Ya existe una persona con ese EMAIL.';
        RETURN;
    END

	IF EXISTS (SELECT 1 FROM Persona WHERE telefono = @telefono)
    BEGIN
        SET @Mensaje = 'Ya existe una persona con ese numero de TELEFONO.';
        RETURN;
    END  

     BEGIN TRANSACTION;
	 BEGIN TRY
			INSERT INTO Persona(dni_persona, nombre_persona, apellido_persona, fecha_nacimiento, email, telefono, sexo) 
			VALUES (@dni_persona, @nombre_persona, @apellido_persona, @fecha_nacimiento, @email, @telefono, @sexo);
			COMMIT;
			SET @Resultado = 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH;
END;
GO

-- Probamos el funcionamiento del procedimiento con manejo de transaccion. --
DECLARE @SalidaResultado BIT, @SalidaMensaje VARCHAR(500);
 
EXEC InsertarPersona 
	@dni_persona = 42424753, 
	@nombre_persona = 'Lex', 
	@apellido_persona = 'Odauga',
	@fecha_nacimiento = '1981-11-10',
	@email = 'axelaguado10@gmail.com', 
	@telefono  = 3704346241, 
	@sexo = 'Hombre', 
	@Resultado = @SalidaResultado OUTPUT, 
	@Mensaje = @SalidaMensaje OUTPUT; 

SELECT @SalidaResultado AS Resutaldo, @SalidaMensaje AS Mensaje; 

INSERT INTO Persona(dni_persona, nombre_persona, apellido_persona, fecha_nacimiento, email, telefono, sexo) 
VALUES (42424755, 'Lex', 'Odauga', '1981-11-10', 'axelaguado@gmail.com', 3704346242,  'Hombre');

/* BLOQUE STANDAR DE UNA TRANSACTION;
CREATE OR ALTER PROCEDURE InsertarUsuario
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
AS
BEGIN
    SET @Resultado = 0;
    SET @Mensaje = '';

    IF EXISTS ( -- CONDICION QUE NO EJECUTA EL PROCEDIMIENTO --)
    BEGIN
        SET @Mensaje = ' ';
        RETURN;
    END
	 
    BEGIN TRY
		BEGIN TRANSACTION;
        -- OPERACION -- 
        COMMIT;
        SET @Resultado = 1;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH;
END;
*/