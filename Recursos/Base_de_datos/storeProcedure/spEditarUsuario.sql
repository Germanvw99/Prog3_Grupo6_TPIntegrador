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
