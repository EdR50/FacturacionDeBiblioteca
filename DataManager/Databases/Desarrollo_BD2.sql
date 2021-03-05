DROP DATABASE IF EXISTS biblioteca;
CREATE DATABASE biblioteca;
USE biblioteca;

create table autores
(
    IdAutor int auto_increment primary key,
    NombreAutor   varchar(200) not null,
    ApellidoAutor varchar(200) not null,
    Nacionalidad  varchar(100) not null
);

create table editoriales
(
    IdEditorial     int auto_increment primary key,
    NombreEditorial varchar(200) not null,
    Direccion       varchar(200) not null,
    Telefono        int          not null
);

-- Drop table if exists libros;
create table libros
(
    Idlibro          int auto_increment primary key,
    Isbn             varchar(100)  not null,
    Titulo           varchar(100)  not null,
    Descripcion      varchar(500)  not null,
    Precio           decimal(5, 2) not null,
    Idioma           varchar(100)  not null,
    FechaLanzamiento date          not null,
    NumeroPag        int           not null,
    Cover            mediumblob    null,
    stock            int           null
    );

create table permisos(
	idpermiso int primary key auto_increment,
    idrol int 
);

create table usuarios
(
    IdUsuario int auto_increment primary key,
    NombreUsuario varchar(100) not null,
    Contrasena    varchar(100) not null,
    Nombre        varchar(100) not null,
    Apellido      varchar(100) not null,
    FechaNac      date         not null,
    Direccion     varchar(200) not null,
    Email         varchar(150) not null,
    idrol         int not null,
    fotoperfil mediumblob   null
);

create table Facturas
(
    Idfacturas int auto_increment primary key,
    MetodoPago    varchar(100) not null,
    FechaCompra   date         not null,
    IdUsuario     int          null,
    Idlibro       int          null
);

/*create table paises
(
	idpais int auto_increment primary key,
    nombrepais varchar(100) not null
);*/

create table categorias(
	idcategorias int auto_increment primary key,
    nombrecategoria varchar(200) not null
);

create table libros_categorias(
	Idlibros int,
    idcategorias int,
    primary key(IdLibros, idcategorias),
    foreign key (Idlibros) references libros(IdLibro),
    foreign key (idcategorias) references categorias(idcategorias)
); 

create table libros_autores(
	IdLibro int,
    IdAutor int,
    primary key(IdLibro, IdAutor),
    foreign key(idLibro) references libros(IdLibro),
    foreign key(idAutor) references autores(IdAutor)
);

create table libros_editoriales(
	IdLibro int,
    IdEditorial int,
	primary key(IdLibro, IdEditorial),
    foreign key(idLibro) references libros(IdLibro),
    foreign key(idEditorial) references editoriales(IdEditorial)
);

create table roles(
	idrol int primary key auto_increment,
    rol varchar(100) not null,
    IdUsuario int
);

alter table facturas add foreign key (IdUsuario) references usuarios(IdUsuario);
alter table facturas add foreign key (Idlibro) references libros(IdLibro);      
alter table permisos add foreign key (idrol) references roles(idrol);
alter table roles add foreign key (IdUsuario) references Usuarios(IdUsuario);



