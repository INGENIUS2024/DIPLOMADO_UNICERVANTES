USE PalabrerIA;
GO

-- Crear tabla de usuarios si no existe
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'usuarios')
BEGIN
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
    PRINT 'Tabla usuarios creada correctamente.';
END
ELSE
BEGIN
    PRINT 'La tabla usuarios ya existe.';
END
GO
