Alter PROCEDURE dbo.InsertExtraMedico
@IdMedico int
AS
BEGIN
	INSERT INTO zTmpNumTurMed(CodMed,NumOrdMan,NumOrdTar,NumOrdNoc) VALUES(@IdMedico,0,0,0)
	SELECT 1
	--SELECT * FROM Planilla.dMedicos where Id_Medico = @IdMedico
END
