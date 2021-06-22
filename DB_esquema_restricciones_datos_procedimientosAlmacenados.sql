CREATE DATABASE Grupo6_TPIntegrador 
GO

USE Grupo6_TPIntegrador 
GO

CREATE TABLE Articulos(
 art_codigo INT IDENTITY(1, 1) NOT NULL,
 art_marca_codigo INT NOT NULL,
 art_categoria_codigo INT NOT NULL,
 art_nombre VARCHAR(255) NOT NULL,
 art_descripcion VARCHAR(255) NOT NULL,
 art_punto_pedido INT DEFAULT 0 NOT NULL,
 art_precio_lista DECIMAL(18, 2) DEFAULT '0,00' NULL,
 art_ruta_imagen VARCHAR(255) NULL,
 art_codigo_estado INT NULL,
 CONSTRAINT PK_Articulos PRIMARY KEY (art_codigo))
GO

CREATE TABLE Articulos_por_Proveedor(
 axp_codigo INT IDENTITY(1, 1) NOT NULL,
 axp_proveedor_dni CHAR(8) NOT NULL,
 axp_articulo_codigo INT NOT NULL,
 axp_stock_actual INT DEFAULT 0 NOT NULL,
 axp_stock_anterior INT DEFAULT 0 NOT NULL,
 axp_entrada INT DEFAULT 0 NOT NULL,
 axp_salida INT DEFAULT 0 NOT NULL,
 axp_precio_unitario DECIMAL(18, 2) DEFAULT '0,00' NULL,
 CONSTRAINT PK_Articulos_por_Proveedor PRIMARY KEY (axp_codigo))
GO

CREATE TABLE Categorias(
 cat_codigo INT IDENTITY(1, 1) NOT NULL,
 cat_nombre VARCHAR(255) NOT NULL,
 cat_descripcion VARCHAR(255) NULL,
 cat_ruta_imagen VARCHAR(255) NULL,
 cat_codigo_estado INT NULL,
 CONSTRAINT PK_Categorias PRIMARY KEY (cat_codigo))
GO

CREATE TABLE DetalleFactura(
 dt_venta_codigo INT NOT NULL,
 dt_numero_linea INT NOT NULL,
 dt_articulo_codigo INT NOT NULL,
 dt_cantidad_unidades INT DEFAULT 0 NULL,
 dt_precio_unitario DECIMAL(18, 2) DEFAULT '0,00' NULL,
 CONSTRAINT PK_DetalleFactura PRIMARY KEY (dt_venta_codigo, dt_numero_linea, dt_articulo_codigo))
GO

CREATE TABLE Estados(
 est_codigo INT IDENTITY(1, 1) NOT NULL,
 est_nombre VARCHAR(255) NOT NULL,
 CONSTRAINT PK_estado PRIMARY KEY (est_codigo))
GO

CREATE TABLE Marcas(
 mar_codigo INT IDENTITY(1, 1) NOT NULL,
 mar_nombre VARCHAR(255) NOT NULL,
 mar_descripcion VARCHAR(255) NULL,
 mar_ruta_imagen VARCHAR(255) NULL,
 mar_codigo_estado INT NULL,
 CONSTRAINT PK_Marcas PRIMARY KEY (mar_codigo))
GO

CREATE TABLE Medios_de_pago(
 mp_codigo INT IDENTITY(1, 1) NOT NULL,
 mp_nombre VARCHAR(255) NOT NULL,
 mp_otros_detalles VARCHAR(255) NULL,
 CONSTRAINT PK_Medios_de_pago PRIMARY KEY (mp_codigo))
GO

CREATE TABLE Perfiles(
 per_codigo INT IDENTITY(1, 1) NOT NULL,
 per_nombre VARCHAR(255) NOT NULL,
 CONSTRAINT PK_Perfiles PRIMARY KEY (per_codigo))
GO

CREATE TABLE Proveedores(
 pro_dni CHAR(8) NOT NULL,
 pro_razon_social VARCHAR(255) NOT NULL,
 pro_direccion VARCHAR(255) NOT NULL,
 pro_email VARCHAR(255) NULL,
 pro_telefono VARCHAR(255) NULL,
 pro_nombre_contacto VARCHAR(255) NULL,
 pro_ruta_imagen VARCHAR(255) NULL,
 pro_codigo_estado INT NULL, CONSTRAINT PK_Proveedores PRIMARY KEY (pro_dni))
GO

CREATE TABLE Usuarios(
 usu_dni CHAR(8) NOT NULL,
 usu_username VARCHAR(20) NOT NULL,
 usu_pass VARCHAR(20) NOT NULL,
 usu_nombre VARCHAR(255) NOT NULL,
 usu_apellido VARCHAR(255) NULL,
 usu_telefono VARCHAR(255) NULL,
 usu_email VARCHAR(255) NULL,
 usu_direccion VARCHAR(255) NULL,
 usu_ciudad VARCHAR(255) NULL,
 usu_provincia VARCHAR(255) NULL,
 usu_codigo_postal VARCHAR(255) NULL,
 usu_ruta_imagen VARCHAR(255) NULL,
 usu_codigo_estado INT NOT NULL,
 usu_perfil_codigo INT NOT NULL,
 CONSTRAINT PK_usuarios PRIMARY KEY (usu_dni))
GO

CREATE TABLE Ventas(
 ven_codigo INT IDENTITY(1, 1) NOT NULL,
 ven_usuarios_dni CHAR(8) NOT NULL,
 ven_medio_pago_codigo INT NOT NULL,
 ven_fecha SMALLDATETIME NOT NULL,
 ven_fecha_requerida SMALLDATETIME NULL,
 ven_fecha_envio SMALLDATETIME NULL,
 ven_total_facturado DECIMAL(18, 2) DEFAULT '0,00' NULL,
 ven_codigo_estado INT NULL,
 CONSTRAINT PK_Ventas PRIMARY KEY (ven_codigo))
GO

ALTER TABLE Articulos ADD CONSTRAINT FK_Articulos_Estados FOREIGN KEY (art_codigo_estado)
REFERENCES Estados (est_codigo)
GO

ALTER TABLE Articulos ADD CONSTRAINT FK_Articulos_Marcas FOREIGN KEY (art_marca_codigo)
REFERENCES Marcas (mar_codigo)
GO

ALTER TABLE Articulos_por_Proveedor ADD CONSTRAINT FK_Articulos_por_Proveedor_Articulos FOREIGN KEY (axp_articulo_codigo)
REFERENCES Articulos (art_codigo)
GO

ALTER TABLE Articulos_por_Proveedor ADD CONSTRAINT FK_Articulos_por_Proveedor_Proveedores FOREIGN KEY (axp_proveedor_dni)
REFERENCES Proveedores (pro_dni)
GO

ALTER TABLE Categorias ADD CONSTRAINT FK_Categorias_Estados FOREIGN KEY (cat_codigo_estado)
REFERENCES Estados (est_codigo)
GO

ALTER TABLE DetalleFactura ADD CONSTRAINT FK_DetalleFactura_Articulos FOREIGN KEY (dt_articulo_codigo)
REFERENCES Articulos (art_codigo)
GO

ALTER TABLE DetalleFactura ADD CONSTRAINT FK_DetalleFactura_Ventas FOREIGN KEY (dt_venta_codigo)
REFERENCES Ventas (ven_codigo)
GO

ALTER TABLE Marcas ADD CONSTRAINT FK_Marcas_Estados FOREIGN KEY (mar_codigo_estado)
REFERENCES Estados (est_codigo)
GO

ALTER TABLE Proveedores ADD CONSTRAINT FK_Proveedores_Estados FOREIGN KEY (pro_codigo_estado)
REFERENCES Estados (est_codigo)
GO

ALTER TABLE Usuarios ADD CONSTRAINT FK_Usuarios_Estados FOREIGN KEY (usu_codigo_estado)
REFERENCES Estados (est_codigo)
GO

ALTER TABLE Usuarios ADD CONSTRAINT FK_Usuarios_Perfiles FOREIGN KEY (usu_perfil_codigo)
REFERENCES Perfiles (per_codigo)
GO

ALTER TABLE Ventas ADD CONSTRAINT FK_Ventas_Estados FOREIGN KEY (ven_codigo_estado)
REFERENCES Estados (est_codigo)
GO

ALTER TABLE Ventas ADD CONSTRAINT FK_Ventas_Medios_de_pago FOREIGN KEY (ven_medio_pago_codigo)
REFERENCES Medios_de_pago (mp_codigo)
GO

ALTER TABLE Ventas ADD CONSTRAINT FK_Ventas_Usuarios FOREIGN KEY (ven_usuarios_dni)
REFERENCES Usuarios (usu_dni)
GO

ALTER TABLE Articulos ADD CONSTRAINT FK_Articulos_Categorias FOREIGN KEY (art_categoria_codigo)
REFERENCES Categorias (cat_codigo)
GO

INSERT INTO Estados (est_nombre)
SELECT 'No Activo' UNION
SELECT 'Activo'
GO

INSERT INTO Perfiles (per_nombre)
SELECT 'Administrador' UNION
SELECT 'Cliente'
GO

INSERT INTO Categorias (cat_nombre,cat_descripcion,cat_ruta_imagen,cat_codigo_estado)
SELECT 'Cámaras y Accesorios','Descubrí miles de productos','Imagenes/categorias/camaras-y-accesorios.png',2 UNION
SELECT 'Celulares y Teléfonos','Encontrá lo mejor en smartphones','Imagenes/categorias/celulares-y-telefonos.png',2 UNION
SELECT 'Computación','Todo para armar tu Home Office','Imagenes/categorias/computacion.png',2 UNION
SELECT 'Consolas y Videojuegos','Lo mejor del mundo gamer','Imagenes/categorias/consolas-y-videojuegos.png',2 UNION
SELECT 'Electrónica Audio y Video','Encontrá lo mejor en electrónica','Imagenes/categorias/electronica-audio-y-video.png',2 UNION
SELECT 'Herramientas','Hacé realidad tus proyectos','Imagenes/categorias/herramientas.png',2 UNION
SELECT 'Televisores','Viví tu entretenimiento con los mejores TV','Imagenes/categorias/televisores.png',2
GO

INSERT INTO Marcas (mar_nombre,mar_descripcion,mar_ruta_imagen,mar_codigo_estado)
SELECT 'ActiVision','','Imagenes/marcas/ActiVision.png',2 UNION
SELECT 'Admiral','One Touch','Imagenes/marcas/Admiral.png',2 UNION
SELECT 'Alcatel','','Imagenes/marcas/Alcatel.png',2 UNION
SELECT 'AMD','','Imagenes/marcas/AMD.png',2 UNION
SELECT 'Apple','Piensa diferente','Imagenes/marcas/Apple.png',2 UNION
SELECT 'Atma','','Imagenes/marcas/Atma.png',2 UNION
SELECT 'Benro','','Imagenes/marcas/Benro.png',2 UNION
SELECT 'BGH','','Imagenes/marcas/BGH.png',2 UNION
SELECT 'Black & Decker','','Imagenes/marcas/Black & Decker.png',2 UNION
SELECT 'BlackBerry','','Imagenes/marcas/BlackBerry.png',2 UNION
SELECT 'Bosch','','Imagenes/marcas/Bosch.png',2 UNION
SELECT 'Canon','','Imagenes/marcas/Canon.png',2 UNION
SELECT 'Celestron','','Imagenes/marcas/Celestron.png',2 UNION
SELECT 'Corsair','','Imagenes/marcas/Corsair.png',2 UNION
SELECT 'Dell','','Imagenes/marcas/Dell.png',2 UNION
SELECT 'DeWalt','','Imagenes/marcas/DeWalt.png',2 UNION
SELECT 'EA','','Imagenes/marcas/EA.png',2 UNION
SELECT 'Einhell','','Imagenes/marcas/Einhell.png',2 UNION
SELECT 'Electrolux','','Imagenes/marcas/Electrolux.png',2 UNION
SELECT 'Exo','','Imagenes/marcas/Exo.png',2 UNION
SELECT 'Fuji Film','','Imagenes/marcas/Fuji Film.png',2 UNION
SELECT 'Gafa','','Imagenes/marcas/Gafa.png',2 UNION
SELECT 'Go Pro','','Imagenes/marcas/Go Pro.png',2 UNION
SELECT 'Godox','','Imagenes/marcas/Godox.png',2 UNION
SELECT 'Hisense','','Imagenes/marcas/Hisense.png',2 UNION
SELECT 'Hitachi','','Imagenes/marcas/Hitachi.png',2 UNION
SELECT 'HP','','Imagenes/marcas/HP.png',2 UNION
SELECT 'Huawei','Hazlo Posible','Imagenes/marcas/Huawei.png',2 UNION
SELECT 'HyperX','Drive your way','Imagenes/marcas/HyperX.png',2 UNION
SELECT 'Hyundai','','Imagenes/marcas/Hyundai.png',2 UNION
SELECT 'JVC','','Imagenes/marcas/JVC.png',2 UNION
SELECT 'Kanji','','Imagenes/marcas/Kanji.png',2 UNION
SELECT 'Karcher','','Imagenes/marcas/Karcher.png',2 UNION
SELECT 'Ken Brown','','Imagenes/marcas/Ken Brown.png',2 UNION
SELECT 'Kingston','','Imagenes/marcas/Kingston.png',2 UNION
SELECT 'KitchenAid','','Imagenes/marcas/KitchenAid.png',2 UNION
SELECT 'Kodak','Tú pulsas el botón,osotros haremos el resto','Imagenes/marcas/Kodak.png',2 UNION
SELECT 'Kodak Alaris','','Imagenes/marcas/Kodak Alaris.png',2 UNION
SELECT 'LG','Life´s Good','Imagenes/marcas/LG.png',2 UNION
SELECT 'Liliana','','Imagenes/marcas/Liliana.png',2 UNION
SELECT 'Logitech','','Imagenes/marcas/Logitech.png',2 UNION
SELECT 'Lusqtoff','','Imagenes/marcas/Lusqtoff.png',2 UNION
SELECT 'Makita','','Imagenes/marcas/Makita.png',2 UNION
SELECT 'Marumi','','Imagenes/marcas/Marumi.png',2 UNION
SELECT 'Microsoft','','Imagenes/marcas/Microsoft.png',2 UNION
SELECT 'Motorola','HelloMoto','Imagenes/marcas/Motorola.png',2 UNION
SELECT 'MSI','','Imagenes/marcas/MSI.png',2 UNION
SELECT 'Multilaser','','Imagenes/marcas/Multilaser.png',2 UNION
SELECT 'Nespresso','','Imagenes/marcas/Nespresso.png',2 UNION
SELECT 'Nikom','','Imagenes/marcas/Nikom.png',2 UNION
SELECT 'Noblex','','Imagenes/marcas/Noblex.png',2 UNION
SELECT 'Nokia','Connecting people','Imagenes/marcas/Nokia.png',2 UNION
SELECT 'Nvidia','','Imagenes/marcas/Nvidia.png',2 UNION
SELECT 'Oster','','Imagenes/marcas/Oster.png',2 UNION
SELECT 'Peabody','','Imagenes/marcas/Peabody.png',2 UNION
SELECT 'Philco','','Imagenes/marcas/Philco.png',2 UNION
SELECT 'Philips','','Imagenes/marcas/Philips.png',2 UNION
SELECT 'Phottix','','Imagenes/marcas/Phottix.png',2 UNION
SELECT 'PlayStation','','Imagenes/marcas/PlayStation.png',2 UNION
SELECT 'Quantum','','Imagenes/marcas/Quantum.png',2 UNION
SELECT 'RCA','','Imagenes/marcas/RCA.png',2 UNION
SELECT 'Redagon','','Imagenes/marcas/Redagon.png',2 UNION
SELECT 'Samsung','Designed for','Imagenes/marcas/Samsung.png',2 UNION
SELECT 'Sanyo','','Imagenes/marcas/Sanyo.png',2 UNION
SELECT 'Sigma','','Imagenes/marcas/Sigma.png',2 UNION
SELECT 'Sony','Make dot believe','Imagenes/marcas/Sony.png',2 UNION
SELECT 'Stanley','','Imagenes/marcas/Stanley.png',2 UNION
SELECT 'Starcam','','Imagenes/marcas/Starcam.png',2 UNION
SELECT 'TCL','The Creative Life','Imagenes/marcas/TCL.png',2 UNION
SELECT 'Telefunken','','Imagenes/marcas/Telefunken.png',2 UNION
SELECT 'Think Tank','','Imagenes/marcas/Think Tank.png',2 UNION
SELECT 'TopHouse','','Imagenes/marcas/TopHouse.png',2 UNION
SELECT 'Trust','','Imagenes/marcas/Trust.png',2 UNION
SELECT 'Trust Gaming','','Imagenes/marcas/Trust Gaming.png',2 UNION
SELECT 'Ubisoft','','Imagenes/marcas/Ubisoft.png',2 UNION
SELECT 'Whirlpool','','Imagenes/marcas/Whirlpool.png',2 UNION
SELECT 'Xiaomi','Innovación para todos','Imagenes/marcas/Xiaomi.png',2 UNION
SELECT 'ZTE','El mañanaunca espera','Imagenes/marcas/ZTE.png',2
GO

INSERT INTO Usuarios (usu_dni,usu_username,usu_pass,usu_nombre,usu_apellido,usu_telefono,usu_email,usu_direccion,usu_ciudad,usu_provincia,usu_codigo_postal,usu_ruta_imagen,usu_codigo_estado,usu_perfil_codigo)
SELECT '00000000','admin','admin','admin','admin','00 0000 0000','admin@yopmail.com','admin','Buenos Aires','Buenos Aires','1000','Recursos/img/avatar.png', 2, 1 UNION
SELECT '06854122','InAnOtAT','yWaRyLeY','Antonio Jose','Salazar','11 4655 3833','neippuharonnoi-2953@yopmail.com','Moreno 3653','Lomas del Mirador','Buenos Aires','1751','Imagenes/usuarios/1.png', 2, 2 UNION
SELECT '20898083','invitado','invitado','Otilia','Prada','38 2242 9373','quohegetanei-2241@yopmail.com','Sanicolas  526','La Rioja','La Rioja','5300','Imagenes/usuarios/2.png', 2, 2 UNION
SELECT '65753616','LetChTat','LetChTat','Tania','Pellicer','11 4585 2819','fodettaummuja-9696@yopmail.com','Don Tomas 207','Villa Del Parque','Buenos Aires','1417','Imagenes/usuarios/4.png', 2, 2 UNION
SELECT '69811171','nesTIAme','nesTIAme','Laura Maria','Cuellar','38 3342 3817','bruxoyaralau-4667@yopmail.com','General Pico','General Pico','La Pampa','6360','Imagenes/usuarios/3.png', 2, 2 UNION
SELECT '79447981','CIAlaNTe','CIAlaNTe','Gracia','Herrera','11 4483 3992','priboikosibro-4325@yopmail.com','Alsina 520','Morón','Buenos Aires','1708','Imagenes/usuarios/1.png', 2, 2
GO

INSERT INTO Medios_de_pago (mp_nombre,mp_otros_detalles)
SELECT 'American Express','Imagenes/mediosPago/americanExpress.png' UNION
SELECT 'Cabal','Imagenes/mediosPago/cabal.png' UNION
SELECT 'Diners','Imagenes/mediosPago/diners.png' UNION
SELECT 'Mastercard','Imagenes/mediosPago/mastercard.png' UNION
SELECT 'Naranja','Imagenes/mediosPago/naranja.png' UNION
SELECT 'Visa','Imagenes/mediosPago/visa.png'
GO

INSERT INTO Ventas (ven_usuarios_dni,ven_medio_pago_codigo,ven_fecha,ven_fecha_requerida,ven_fecha_envio,ven_total_facturado,ven_codigo_estado)
SELECT '20898083', 3,'2021-05-05','2021-05-05','2021-05-05','120000.00',2 UNION
SELECT '79447981', 1,'2021-06-06','2021-06-06','2021-06-06','90000.00',2 UNION
SELECT '65753616', 4,'2021-04-04','2021-04-04','2021-04-04','190000.00',2
GO

INSERT INTO Articulos (art_marca_codigo,art_categoria_codigo,art_nombre,art_descripcion,art_punto_pedido,art_precio_lista,art_ruta_imagen,art_codigo_estado) 
SELECT 9,7,'Smart TV BGH','Dimensiones: 96.8cm de ancho,56.8cm de alto,7.8cm de profundidad',4,'41999.00','Imagenes/articulos/5.png',2 UNION
SELECT 48,2,'Moto G9 Power','Con la pantalla Max Vision HD+ de 6.8"',12,'35999.00','Imagenes/articulos/10.png',2 UNION
SELECT 53,7,'Smart TV Noblex','Su resolución es 4K',5,'81499.00','Imagenes/articulos/1.png',2 UNION
SELECT 54,2,'Nokia 23 M','Memoria interna de 32GB. Apto para tarjeta SD de 512GB',12,'15999.00','Imagenes/articulos/6.png',2 UNION
SELECT 58,2,'Philco P241','Memoria interna de 512MB. Apto para tarjeta SD de 64GB',8,'9599.00','Imagenes/articulos/11.png',2 UNION
SELECT 58,6,'Taladro eléctrico percutor Philco','Velocidad mínima de rotación: 3000rpm.',20,'9212.00','Imagenes/articulos/12.png',2 UNION
SELECT 59,7,'Smart TV Philips','Con YouTube,Netflix,Web browser.',3,'43999.00','Imagenes/articulos/3.png',2 UNION
SELECT 65,2,'Samsung Galaxy A52','Tiene 4 cámaras traseras de 64Mpx/12Mpx/5Mpx/5Mpx.',8,'55999.00','Imagenes/articulos/7.png',2 UNION
SELECT 65,2,'Samsung Galaxy Note20','Pantalla Dynamic AMOLED 2X de 6.9',2,'155999.00','Imagenes/articulos/9.png',2 UNION
SELECT 65,7,'Smart TV Samsung','Tecnología HDR para una calidad de imagen mejorada.',3,'75999.00','Imagenes/articulos/2.png',2 UNION
SELECT 71,7,'Smart TV TCL','Con función Screen Share',6,'32999.00','Imagenes/articulos/4.png',2 UNION
SELECT 78,2,'Xiaomi Poco X3','Dispositivo liberado para que elijas la compañía telefónica que prefieras',3,'61200.00','Imagenes/articulos/8.png',2
GO

INSERT INTO Proveedores (pro_dni, pro_razon_social, pro_direccion, pro_email, pro_telefono, pro_nombre_contacto, pro_ruta_imagen, pro_codigo_estado)
SELECT '05905952', 'Samsonite', 'San Luis 597, CABA', 'Samsonite@yopmail.com', '011 5290-1053', 'Roque Gaspar', 'Imagenes/proveedores/1.png', 1 UNION
SELECT '08397217', 'Amec', 'Moldes 2658, CABA', 'Amec@yopmail.com', '011 4641-1359', 'Manuel Clemente', 'Imagenes/proveedores/2.png', 1 UNION
SELECT '38503846', 'Lenovo', 'Fray Rodríguez 3798, Lanus', 'Lenovo@yopmail.com', '011 3817-7518', 'Arsenio Gonzalo', 'Imagenes/proveedores/3.png', 1 UNION
SELECT '50408159', 'Hansa', 'Sarmiento 958, Villa Dominico', 'Hansa@yopmail.com', '011 6356-9715', 'Eulogio de Miguel', 'Imagenes/proveedores/4.png', 1 UNION
SELECT '65465388', 'Semak ', 'Olazábal 1515,  CABA', 'Semak@yopmail.com', '011 5368-5300', 'Pepe Laguna', 'Imagenes/proveedores/5.png', 1 UNION
SELECT '70951091', 'DNA', 'Larrea 1325, San Isidro', 'DNA@yopmail.com', '011 4922-4801', 'Luis Andreu', 'Imagenes/proveedores/6.png', 1 UNION
SELECT '74922070', 'Awara', 'Elizalde 155, Avellaneda', 'Awara@yopmail.com', '011 5588-9533', 'Sarah Nicolas', 'Imagenes/proveedores/7.png', 1 UNION
SELECT '98219940', 'Ametic', 'Maipu 734, CABA', 'Ametic@yopmail.com', '011 2107-5861', 'Almudena Sempere', 'Imagenes/proveedores/8.png', 1
GO

INSERT INTO Articulos_por_Proveedor (axp_proveedor_dni,axp_articulo_codigo,axp_stock_actual,axp_stock_anterior,axp_entrada,axp_salida,axp_precio_unitario)
SELECT '05905952', 10, 20, 0, 20, 0,'55000.00' UNION
SELECT '65465388', 12, 12, 0, 12, 0,'60000.00' UNION
SELECT '08397217', 11, 22, 0, 22, 0,'22000.00' UNION
SELECT '98219940', 7, 23, 0, 23, 0,'7000.00' UNION
SELECT '70951091', 9, 3, 0, 3, 0,'120000.00'
GO

INSERT INTO DetalleFactura (dt_venta_codigo,dt_numero_linea,dt_articulo_codigo,dt_cantidad_unidades,dt_precio_unitario)
SELECT 1,1,10,1,'120000.00' UNION
SELECT 2,1,11,1,'10000.00' UNION
SELECT 2,2,12,1,'80000.00' UNION
SELECT 3,1,11,1,'10000.00' UNION
SELECT 3,2,7,4,'10000.00' UNION
SELECT 3,3,9,1,'140000.00'
GO

CREATE PROCEDURE spActualizarStock
(
@axp_proveedor_dni CHAR(8),
@axp_articulo_codigo INT,
@axp_entrada INT,
@axp_salida INT,
@axp_precio_unitario DECIMAL(18,2)
)
AS
	IF EXISTS (SELECT * FROM Articulos_por_Proveedor WHERE axp_proveedor_dni=@axp_proveedor_dni AND axp_articulo_codigo=@axp_articulo_codigo)
	BEGIN
		IF EXISTS (SELECT * FROM Articulos_por_Proveedor WHERE axp_stock_actual >= @axp_salida)
			BEGIN
				UPDATE Articulos_por_Proveedor
				SET
				axp_entrada=@axp_entrada,
				axp_salida=@axp_salida,
				axp_precio_unitario=@axp_precio_unitario,
				axp_stock_anterior=axp_stock_actual,
				axp_stock_actual=axp_stock_actual+@axp_entrada-@axp_salida
				WHERE axp_proveedor_dni=@axp_proveedor_dni
				AND axp_articulo_codigo=@axp_articulo_codigo
			END
		END
	ELSE
	BEGIN
		INSERT INTO Articulos_por_Proveedor
		(
		axp_proveedor_dni,
		axp_articulo_codigo,
		axp_precio_unitario,
		axp_stock_actual,
		axp_entrada
		)
		VALUES
		(
		@axp_proveedor_dni,
		@axp_articulo_codigo,
		@axp_precio_unitario,
		@axp_entrada,
		@axp_entrada
		)
	END
GO

CREATE PROCEDURE spAgregarArticulo
(
@prmMarca int,
@prmCategoria int,
@prmNombre varchar(255),
@prmDescripcion varchar(255),
@prmPunto_pedido int,
@prmPrecio_lista decimal(18,2),
@prmRuta_imagen varchar(255),
@prmEstado int
)
AS
BEGIN
	INSERT INTO Articulos
		(
		art_marca_codigo,
		art_categoria_codigo,
		art_nombre,
		art_descripcion,
		art_punto_pedido,
		art_precio_lista,
		art_ruta_imagen,
		art_codigo_estado
		)
	VALUES
		(
		@prmMarca,
		@prmCategoria,
		@prmNombre,
		@prmDescripcion,
		@prmPunto_pedido,
		@prmPrecio_lista,
		@prmRuta_imagen,
		@prmEstado
		)
	END
GO

CREATE PROCEDURE spAgregarCategoria
(
@cat_nombre VARCHAR(255),
@cat_descripcion VARCHAR(255),
@cat_ruta_imagen VARCHAR(255),
@cat_codigo_estado INT
)
AS
INSERT INTO Categorias
(
cat_nombre,
cat_descripcion,
cat_ruta_imagen,
cat_codigo_estado
)
VALUES
(
@cat_nombre,
@cat_descripcion,
@cat_ruta_imagen,
@cat_codigo_estado
)
GO

CREATE PROCEDURE spAgregarMarca
(
@mar_nombre VARCHAR(255),
@mar_descripcion VARCHAR(255),
@mar_ruta_imagen VARCHAR(255),
@mar_codigo_estado INT
)
AS
INSERT INTO Marcas
(
mar_nombre,
mar_descripcion,
mar_ruta_imagen,
mar_codigo_estado
)
VALUES
(
@mar_nombre,
@mar_descripcion,
@mar_ruta_imagen,
@mar_codigo_estado
)
GO

CREATE PROCEDURE spAgregarProveedor
(
@pro_dni CHAR(8),
@pro_razon_social VARCHAR(255),
@pro_direccion VARCHAR(255),
@pro_email VARCHAR(255),
@pro_telefono VARCHAR(255),
@pro_nombre_contacto VARCHAR(255),
@pro_ruta_imagen VARCHAR(255),
@pro_codigo_estado INT
)
AS
INSERT INTO Proveedores
(
pro_dni,
pro_razon_social,
pro_direccion,
pro_email,
pro_telefono,
pro_nombre_contacto,
pro_ruta_imagen,
pro_codigo_estado
)
VALUES
(
@pro_dni,
@pro_razon_social,
@pro_direccion,
@pro_email,
@pro_telefono,
@pro_nombre_contacto,
@pro_ruta_imagen,
@pro_codigo_estado
)
GO


CREATE PROCEDURE spEditarContraseña
(
	@prmDni char(8),
	@prmNuevaPassword varchar(255)
)
AS
BEGIN
	UPDATE Usuarios set Usuarios.usu_pass=@prmNuevaPassword
	WHERE Usuarios.usu_dni=@prmDni
END
GO

CREATE PROCEDURE spEditarUsuario
(
	@prmDni char(8),
	@prmNombre varchar(255),
	@prmApellido varchar(255),
	@prmEmail varchar(255),
	@prmTelefono varchar(255),
	@prmDireccion varchar(255),
	@prmCiudad varchar(255),
	@prmProvincia varchar(255),
	@prmCodigo_Postal varchar(255)
)
AS
BEGIN
	UPDATE Usuarios set Usuarios.usu_nombre=@prmNombre,
						Usuarios.usu_apellido=@prmApellido,
						Usuarios.usu_email=@prmEmail,
						Usuarios.usu_telefono=@prmTelefono,
						Usuarios.usu_direccion=@prmDireccion,
						Usuarios.usu_codigo_postal=@prmCodigo_Postal,
						Usuarios.usu_ciudad=@prmCiudad,
						Usuarios.usu_provincia=@prmProvincia
	WHERE Usuarios.usu_dni=@prmDni
END
GO


CREATE PROCEDURE spEliminarArticulo
(
@art_codigo INT
) 
AS
DELETE FROM Articulos
WHERE art_codigo=@art_codigo
GO

CREATE PROCEDURE spEliminarCategoria
(
@cat_codigo INT
) 
AS
DELETE FROM Categorias
WHERE cat_codigo = @cat_codigo
GO

CREATE PROCEDURE spEliminarMarca
(
@mar_codigo INT
) 
AS
DELETE FROM Marcas
WHERE mar_codigo = @mar_codigo
GO

CREATE PROCEDURE spEliminarProveedor
(
@pro_dni CHAR(8)
) 
AS
DELETE FROM Proveedores
WHERE pro_dni=@pro_dni
GO


CREATE PROCEDURE spLeerUsername
(
@prmUsername varchar(255)
)
AS
BEGIN
	SELECT U.usu_dni, U.usu_username, U.usu_nombre,U.usu_apellido,U.usu_telefono,U.usu_email,U.usu_direccion,U.usu_ciudad,U.usu_provincia,U.usu_codigo_postal,U.usu_ruta_imagen,U.usu_codigo_estado, U.usu_perfil_codigo
	FROM Usuarios U
	WHERE U.usu_username = @prmUsername 
END
GO

CREATE PROCEDURE spLeerUsuario
(
@prmDni varchar(255)
)
AS
BEGIN
	SELECT U.usu_dni, U.usu_username, U.usu_nombre,U.usu_apellido,U.usu_telefono,U.usu_email,U.usu_direccion,U.usu_ciudad,U.usu_provincia,U.usu_codigo_postal,U.usu_ruta_imagen,U.usu_codigo_estado, U.usu_perfil_codigo
	FROM Usuarios U
	WHERE U.usu_dni = @prmDni
END
GO

CREATE PROCEDURE spLoginUsuario
(
@prmUsername varchar(255),
@prmPassword varchar(255)
)
AS
BEGIN
	SELECT U.usu_dni, U.usu_username, U.usu_nombre,U.usu_apellido,U.usu_telefono,U.usu_email,U.usu_direccion,U.usu_ciudad,U.usu_provincia,U.usu_codigo_postal,U.usu_ruta_imagen,U.usu_codigo_estado, U.usu_perfil_codigo
	FROM Usuarios U
	WHERE U.usu_username = @prmUsername and U.usu_pass = @prmPassword
END
GO

CREATE PROCEDURE spModificarArticulo
(
@art_codigo INT,
@art_marca_codigo INT,
@art_categoria_codigo INT,
@art_nombre VARCHAR(255),
@art_descripcion VARCHAR(255),
@art_punto_pedido INT,
@art_precio_lista DECIMAL(18, 2),
@art_ruta_imagen VARCHAR(255),
@art_codigo_estado INT
)
AS
UPDATE Articulos
SET
art_marca_codigo=@art_marca_codigo,
art_categoria_codigo=@art_categoria_codigo,
art_nombre=@art_nombre,
art_descripcion=@art_descripcion,
art_punto_pedido=@art_punto_pedido,
art_precio_lista=@art_precio_lista,
art_ruta_imagen=@art_ruta_imagen,
art_codigo_estado=@art_codigo_estado
WHERE art_codigo=@art_codigo
GO

CREATE PROCEDURE spModificarArticuloProveedor
(
@axp_proveedor_dni CHAR(8),
@axp_articulo_codigo INT,
@axp_stock_actual INT,
@axp_precio_unitario DECIMAL(18,2)
)
AS
UPDATE Articulos_por_Proveedor
SET
axp_stock_actual=@axp_stock_actual,
axp_precio_unitario=@axp_precio_unitario
WHERE axp_proveedor_dni=@axp_proveedor_dni
AND axp_articulo_codigo=@axp_articulo_codigo
GO

CREATE PROCEDURE spModificarCategoria
(
@cat_codigo INT,
@cat_nombre VARCHAR(255),
@cat_descripcion VARCHAR(255),
@cat_ruta_imagen VARCHAR(255),
@cat_codigo_estado INT
)
AS
UPDATE Categorias
SET
cat_nombre=@cat_nombre,
cat_descripcion=@cat_descripcion,
cat_ruta_imagen=@cat_ruta_imagen,
cat_codigo_estado=@cat_codigo_estado
WHERE
cat_codigo = @cat_codigo
GO

CREATE PROCEDURE spModificarMarca
(
@mar_codigo INT,
@mar_nombre VARCHAR(255),
@mar_descripcion VARCHAR(255),
@mar_ruta_imagen VARCHAR(255),
@mar_codigo_estado INT
)
AS
UPDATE Marcas
SET
mar_nombre=@mar_nombre,
mar_descripcion=@mar_descripcion,
mar_ruta_imagen=@mar_ruta_imagen,
mar_codigo_estado=@mar_codigo_estado
WHERE
mar_codigo = @mar_codigo
GO

CREATE PROCEDURE spModificarProveedor
(
@pro_dni CHAR(8),
@pro_razon_social VARCHAR(255),
@pro_direccion VARCHAR(255),
@pro_email VARCHAR(255),
@pro_telefono VARCHAR(255),
@pro_nombre_contacto VARCHAR(255),
@pro_ruta_imagen VARCHAR(255),
@pro_codigo_estado INT
)
AS
UPDATE Proveedores
SET
pro_razon_social=@pro_razon_social,
pro_direccion=@pro_direccion,
pro_email=@pro_email,
pro_telefono=@pro_telefono,
pro_nombre_contacto=@pro_nombre_contacto,
pro_ruta_imagen=@pro_ruta_imagen,
pro_codigo_estado=@pro_codigo_estado
WHERE pro_dni=@pro_dni
GO

CREATE PROCEDURE spRegistroUsuario
(
@prmDni char(8),
@prmUsername varchar(255),
@prmPassword varchar(255),
@prmNombre varchar(255),
@prmApellido varchar(255),
@prmTelefono varchar(255),
@prmEmail varchar(255),
@prmDireccion varchar(255),
@prmCiudad varchar(255),
@prmProvincia varchar(255),
@prmCodigo_Postal varchar(255),
@prmRuta_Img varchar(255),
@prmEstado int,
@prmCodigo_Perfil int
)
AS
BEGIN
	INSERT INTO Usuarios(usu_dni,usu_username,usu_pass,usu_nombre,usu_apellido,usu_telefono,usu_email,usu_direccion,usu_ciudad,usu_provincia,usu_codigo_postal,usu_ruta_imagen,usu_codigo_estado,usu_perfil_codigo)
	VALUES(@prmDni,@prmUsername,@prmPassword,@prmNombre,@prmApellido,@prmTelefono,@prmEmail,@prmDireccion,@prmCiudad,@prmProvincia,@prmCodigo_Postal,@prmRuta_Img,@prmEstado,@prmCodigo_Perfil)
END
GO