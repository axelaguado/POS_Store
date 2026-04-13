CREATE DATABASE db_tstore; 
--------------------------------------------------------------------
USE db_tstore; 
--------------------------------------------------------------------  
CREATE TABLE Persona (
	id_persona INT IDENTITY (1, 1),  
	CONSTRAINT PK_persona PRIMARY KEY (id_persona),  
); 
 
 EXEC sp_help 'Persona'
-------------------------------------------------------------------- 

CREATE TABLE Persona_fisica (
  id_persona INT NOT NULL,
  dni_persona INT NOT NULL,
  nombre_persona VARCHAR(100) NOT NULL,
  apellido_persona VARCHAR(100) NOT NULL,
  fecha_nacimiento DATE NOT NULL,
  sexo VARCHAR(10) NOT NULL,
  CONSTRAINT FK_persona_fisica FOREIGN KEY (id_persona) REFERENCES Persona (id_persona),
  CONSTRAINT PK_personafisica PRIMARY KEY (id_persona)
);
--------------------------------------------------------------------

 CREATE TABLE Persona_juridica ( 
	id_persona INT NOT NULL,
	razon_social VARCHAR(100) NOT NULL,
	nombre_comercial VARCHAR(100) NOT NULL,
	CUIT BIGINT NOT NULL,
	CONSTRAINT FK_persona_juridica FOREIGN KEY (id_persona) REFERENCES Persona (id_persona),
    CONSTRAINT PK_personajuridica PRIMARY KEY (id_persona)
 ); 
 -------------------------------------------------------------------

CREATE TABLE Direccion (
	id_direccion INT IDENTITY (1, 1), 
	id_persona INT NOT NULL,
	cod_postal INT,
	calle VARCHAR (100) NOT NULL,
	altura INT NOT NULL,
	piso VARCHAR(10),
	depto INT,
	CONSTRAINT PK_direccion PRIMARY KEY (id_direccion),  
	CONSTRAINT FK_persona FOREIGN KEY (id_persona) REFERENCES Persona (id_persona) 
);  
-------------------------------------------------------------------

CREATE TABLE Contacto (
	id_contacto INT IDENTITY (1, 1),
	id_persona INT NOT NULL,
	telefono BIGINT NOT NULL, 
	email VARCHAR(50), 
	sitio_web VARCHAR(150),
	CONSTRAINT PK_Contacto PRIMARY KEY (id_contacto),
	CONSTRAINT FK_contacto_persona FOREIGN KEY (id_persona) REFERENCES Persona (id_persona) 
);
-------------------------------------------------------------------- 

CREATE TABLE Cliente (
	id_cliente INT IDENTITY (1, 1),
	id_persona INT NOT NULL,
	CONSTRAINT PK_cliente PRIMARY KEY (id_cliente),
	CONSTRAINT FK_cliente_persona FOREIGN KEY (id_persona) REFERENCES Persona(id_persona) 
);

-- Rstricciones de integridad ..
ALTER TABLE Cliente ADD CONSTRAINT UNQ_cliente_persona UNIQUE (id_persona);
-------------------------------------------------------------------- 

CREATE TABLE Proveedor (  
	id_proveedor INT IDENTITY (1, 1),
	id_persona INT NOT NULL,
	CONSTRAINT PK_proveedor PRIMARY KEY (id_proveedor),
	CONSTRAINT FK_proveedor_persona FOREIGN KEY (id_persona) REFERENCES Persona(id_persona) 
);

-- Rstricciones de integridad ..
ALTER TABLE Proveedor ADD CONSTRAINT UNQ_proveedor_persona UNIQUE (id_persona);
--------------------------------------------------------------------

CREATE TABLE Empleado (
	id_empleado INT IDENTITY (1, 1),
	id_persona INT NOT NULL, 
	CONSTRAINT PK_empleado PRIMARY KEY (id_empleado),
	CONSTRAINT FK_empleado_persona FOREIGN KEY (id_persona) REFERENCES Persona(id_persona) 
);

-- Rstricciones de integridad ..
ALTER TABLE Empleado ADD CONSTRAINT UNQ_empleado_persona UNIQUE (id_persona); 
--------------------------------------------------------------------
 
CREATE TABLE Usuario (  
	id_usuario INT IDENTITY (1, 1),
	id_empleado INT NOT NULL,
	username VARCHAR(100) NOT NULL,
	contraseña VARCHAR(100) NOT NULL, 
	tipo_perfil INT NOT NULL,
	estado BIT NOT NULL, 
	CONSTRAINT PK_usuario PRIMARY KEY (id_usuario),
	CONSTRAINT FK_usuario_tipo FOREIGN KEY (tipo_perfil) REFERENCES Tipo_usuario(id_tipo),
	CONSTRAINT FK_usuario_empleado FOREIGN KEY (id_empleado) REFERENCES Empleado (id_empleado)   
);

-- Restricciones de integridad --
ALTER TABLE Usuario ADD CONSTRAINT UNQ_usuario_empleado UNIQUE (id_empleado); 
ALTER TABLE Usuario ADD CONSTRAINT UNQ_usuario_username UNIQUE (username); 
ALTER TABLE Usuario ADD CONSTRAINT CHK_usuario_contraseña CHECK (LEN(contraseña) > 8); 
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
------------------------------------------------------------------- 

 CREATE TABLE Pedido ( 
	 id_pedido INT IDENTITY(1, 1), 
	 id_proveedor INT NOT NULL,
	 fecha_emision DATETIME NOT NULL,
	 monto_total DECIMAL(10, 2) NOT NULL,
	 estado INT NOT NULL,
	 CONSTRAINT PK_pedido PRIMARY KEY (id_pedido),
	 CONSTRAINT FK_pedido_proveedor FOREIGN KEY (id_proveedor) REFERENCES Proveedor(id_proveedor), 
	 CONSTRAINT FK_pedido_estado FOREIGN KEY (estado) REFERENCES Estado_pedido (id_estado)
 );   

 -------------------------------------------------------------------

 CREATE TABLE Estado_pedido (
	id_estado INT IDENTITY (1, 1),
	descripcion_estado VARCHAR(30) NOT NULL,
	CONSTRAINT PK_estado PRIMARY KEY (id_estado)
 );

 -- Insercion de los tipos de usuario --
INSERT Estado_pedido (descripcion_estado) VALUES ('Cancelado');
INSERT Estado_pedido (descripcion_estado) VALUES ('Pendiente');
INSERT Estado_pedido (descripcion_estado) VALUES ('Recibido'); 
 -------------------------------------------------------------------

 CREATE TABLE Detalle_pedido ( 
	  id_detalle INT IDENTITY(1, 1),
	  id_pedido INT NOT NULL,
	  id_articulo INT NOT NULL,
	  cantidad INT NOT NULL,   
	  CONSTRAINT PK_detalle PRIMARY KEY (id_detalle),
	  CONSTRAINT FK_detalle_pedido FOREIGN KEY (id_pedido) REFERENCES Pedido(id_pedido), 
	  CONSTRAINT FK_detalle_articulo FOREIGN KEY (id_articulo) REFERENCES Articulo(id_articulo)
 );  
 -------------------------------------------------------------------
 
  CREATE TABLE Articulo(
	id_articulo INT IDENTITY(1, 1),
	marca_articulo VARCHAR(50) NOT NULL,
	nombre_articulo VARCHAR(50) NOT NULL,
	descripcion_articulo VARCHAR(100),
	contenido_articulo VARCHAR(50) NOT NULL,
	precio_unitario DECIMAL(10, 2) NOT NULL,
	CONSTRAINT PK_articulo PRIMARY KEY (id_articulo)
 );
 -------------------------------------------------------------------    