---------------
-- AppEscuela--
---------------
-- CREACION DE TABLAS
-- TABLA FACULTAD
CREATE TABLE Facultad (
    ID int IDENTITY(1, 1) PRIMARY KEY,
    Codigo varchar(10),
    Nombre varchar(250)
);

-- TABLA ESTUDIANTE
CREATE TABLE Estudiante (
    Matricula int IDENTITY(1000, 1) PRIMARY KEY,
    Nombre varchar(250),
    FechaNacimiento date,
    Semestre int,
    Facultad int,
    FOREIGN KEY (Facultad) REFERENCES Facultad(ID)
);

-- DATOS DE PRUEBA
INSERT INTO
    Facultad
VALUES
    ('ING01', 'Facultad de Ingeniería');

INSERT INTO
    Facultad
VALUES
    ('ARQ01', 'Facultad de Arquitectura');

INSERT INTO
    Estudiante
VALUES
    ('Andrés Sánchez', '1992-09-23', 8, 1);

INSERT INTO
    Estudiante
VALUES
    ('José Pérez', '1995-01-01', 7, 2);

-- PROCEDIMIENTOS ALMACENADOS
-- SP CARGAR ESTUDIANTES
CREATE PROCEDURE CargarEstudiantes AS BEGIN
SELECT
    Estudiante.*,
    Facultad.Nombre AS nombreFacultad
FROM
    Estudiante
    JOIN Facultad ON Estudiante.Facultad = Facultad.ID;

END 

-- SP AGREGAR ESTUDIANTES
CREATE PROCEDURE AgregarEstudiantes (
    @Nombre varchar(250),
    @FechaNacimiento date,
    @Semestre int,
    @Facultad int
) AS BEGIN
INSERT INTO
    Estudiante
VALUES
    (
        @Nombre,
        @FechaNacimiento,
        @Semestre,
        @Facultad
    );

END 

-- SP CARGAR FACULTADES
CREATE PROCEDURE CargarFacultades AS BEGIN
SELECT
    *
FROM
    Facultad;

END 

-- SP CARGAR ESTUDIANTE
CREATE PROCEDURE CargarEstudiante (@Matricula int) AS BEGIN
SELECT
    *
FROM
    Estudiante
WHERE
    Matricula = @Matricula;

END 

-- SP MODIFICAR ESTUDIANTE
CREATE PROCEDURE ModificarEstudiante (
    @Matricula int,
    @Nombre varchar(250),
    @FechaNacimiento date,
    @Semestre int,
    @Facultad int
) AS BEGIN
UPDATE
    Estudiante
SET
    Nombre = @Nombre,
    FechaNacimiento = @FechaNacimiento,
    Semestre = @Semestre,
    Facultad = @Facultad
WHERE
    Matricula = @Matricula;

END 

-- SP ELIMINAR ESTUDIANTE
CREATE PROCEDURE EliminarEstudiante (@Matricula int) AS BEGIN
DELETE FROM
    Estudiante
WHERE
    Matricula = @Matricula;

END