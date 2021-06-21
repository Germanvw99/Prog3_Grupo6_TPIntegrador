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