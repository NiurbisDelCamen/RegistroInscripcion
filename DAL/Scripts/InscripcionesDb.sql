create database InscripcionesDb
use InscripcionesDb

create TABLE Personas
(
	PersonaID int primary key identity,
	Nombre varchar(max),
	Cedula varchar(max),
	Telefono varchar(30),
	Direccion varchar(max),
	FechaNacimiento datetime,
	balance decimal
);

select * from Personas

create  table Inscripciones
(
	IncripcionId int primary key identity, 
	Fecha datetime, 
	PersonaId int, 
	Comentarios varchar(max), 
	Monto decimal, 
	Balance decimal,
	deposito decimal
); 
--Se crea la llave foranea
alter table Inscripciones add constraint FK_PersonaID Foreign key(PersonaId) references Personas(PersonaID)
on delete cascade on update cascade

select * from Inscripciones