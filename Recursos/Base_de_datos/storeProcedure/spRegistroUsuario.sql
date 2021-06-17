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