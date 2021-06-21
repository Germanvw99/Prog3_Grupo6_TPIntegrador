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