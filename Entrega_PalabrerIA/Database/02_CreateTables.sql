USE PalabrerIA;
GO

CREATE TABLE usuarios (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    apellido NVARCHAR(100) NOT NULL,
    correo NVARCHAR(150) NOT NULL UNIQUE,
    contacto NVARCHAR(50) NULL,
    usuario NVARCHAR(50) NOT NULL UNIQUE,
    password_hash NVARCHAR(256) NOT NULL,
    fecha_registro DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE tipos_documento (
    id_tipo INT PRIMARY KEY,
    nombre_tipo NVARCHAR(150) NOT NULL,
    descripcion NVARCHAR(500) NULL
);
GO

CREATE TABLE temas (
    id_tema INT PRIMARY KEY,
    nombre_tema NVARCHAR(150) NOT NULL,
    descripcion NVARCHAR(500) NULL
);
GO

CREATE TABLE formato_texto (
    id_formato INT PRIMARY KEY,
    nombre_formato NVARCHAR(150) NOT NULL,
    descripcion NVARCHAR(500) NULL
);
GO

CREATE TABLE documentos (
    id_documento INT IDENTITY(1,1) PRIMARY KEY,
    titulo NVARCHAR(300) NOT NULL,
    texto_original NVARCHAR(MAX) NOT NULL,
    idioma_original NVARCHAR(50) NOT NULL,
    fecha_publicacion DATE NULL,
    fuente NVARCHAR(200) NULL,
    id_tipo INT NOT NULL,
    id_tema INT NOT NULL,
    nivel_tecnico NVARCHAR(50) NOT NULL,
    publico_objetivo NVARCHAR(150) NOT NULL,
    url_fuente NVARCHAR(500) NULL,
    CONSTRAINT FK_documentos_tipos FOREIGN KEY (id_tipo) REFERENCES tipos_documento(id_tipo),
    CONSTRAINT FK_documentos_temas FOREIGN KEY (id_tema) REFERENCES temas(id_tema)
);
GO

CREATE TABLE versiones_texto (
    id_version INT IDENTITY(1,1) PRIMARY KEY,
    id_documento INT NOT NULL,
    id_formato INT NOT NULL,
    tipo_version NVARCHAR(100) NOT NULL,
    texto_version NVARCHAR(MAX) NOT NULL,
    idioma_version NVARCHAR(50) NOT NULL,
    fecha_creacion DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_versiones_documentos FOREIGN KEY (id_documento) REFERENCES documentos(id_documento),
    CONSTRAINT FK_versiones_formato FOREIGN KEY (id_formato) REFERENCES formato_texto(id_formato)
);
GO
