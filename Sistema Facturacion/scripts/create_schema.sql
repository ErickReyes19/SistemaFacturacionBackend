-- Crear el esquema llamado SistemaFacturacion con la contraseña Root.123
CREATE USER SistemaFacturacion IDENTIFIED BY "Root.123";

-- Otorgar permisos necesarios
GRANT CONNECT, RESOURCE, DBA TO SistemaFacturacion;

-- Otorgar privilegios adicionales
GRANT CREATE SESSION, CREATE TABLE, CREATE VIEW, CREATE PROCEDURE, CREATE SEQUENCE, CREATE TRIGGER, CREATE SYNONYM, CREATE ANY DIRECTORY TO SistemaFacturacion;
