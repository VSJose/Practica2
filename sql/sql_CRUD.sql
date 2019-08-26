create database CRUD;

use CRUD;

create table usuario(
	id int not null,
	nombre varchar(50),
	apellido varchar(50),
	correo varchar(50),
	fecha_nac datetime
	constraint pk_usuario primary key(id)
)


INSERT INTO usuario(id,nombre,apellido,correo,fecha_nac) values (1010,'MARCO','SANCHEZ','POW@gmail.com','24/08/1998');
INSERT INTO usuario(id,nombre,apellido,correo,fecha_nac) values (1111,'PEDRO','SANCHEZ','WWW@gmail.com','24/08/1998');
/*drop database CRUD;

update usuario set nombre='noambre', apellido='apesllido', correo='corfreo',fecha_nac='24/08/1999' where id=1010;

delete from usuario where id=1111;

select *
from usuario*/