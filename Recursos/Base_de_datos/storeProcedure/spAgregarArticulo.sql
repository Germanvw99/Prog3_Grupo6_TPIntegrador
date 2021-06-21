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