USE PoliclinicoNuevo

CREATE SCHEMA Planilla

GO

CREATE TABLE [Planilla].[Lab_AreasLaboratorio](
	[IdAreaLaboratorio] INT IDENTITY NOT NULL PRIMARY KEY,
	[CodAre] [varchar](1) NOT NULL,
	[AreaLab] [varchar](25) NULL)
GO

INSERT INTO [Planilla].[Lab_AreasLaboratorio]
           ([CodAre]
           ,[AreaLab])
SELECT [CodAre]
      ,[AreaLab]
  FROM Policlinico.dbo.[vAreasLaboratorio]
GO

SELECT * FROM  [Planilla].[Lab_AreasLaboratorio]

GO


CREATE TABLE [Planilla].[dEspecialidades](
	[Id_Especialidades] INT IDENTITY NOT NULL PRIMARY KEY,
	[CodEsp] [varchar](4) NULL,
	[Descripcion] [varchar](80) NOT NULL,
	[PrecioConsulta] smallmoney NOT NULL,
	[MontoMedico] smallmoney NOT NULL
) ON [PRIMARY]

GO

INSERT INTO Planilla.dEspecialidades (CodEsp, Descripcion, PrecioConsulta, MontoMedico)
SELECT esp.CodEsp,esp.Especialidad, COALESCE(esp.PrecioConsulta,0), COALESCE(esp.MontoMedico,0)  FROM Policlinico.dbo.dEspecialidades esp

GO

SELECT * FROM PoliclinicoNuevo.Planilla.dEspecialidades 

GO

CREATE TABLE [Planilla].[Ubigeo](
	IdUbigeo INT IDENTITY NOT NULL PRIMARY KEY,
	[NOMDIS] [varchar](50) NULL,
	[NOMPRO] [varchar](50) NULL,
	[NOMDEP] [varchar](50) NULL,
	[CODDIS] [varchar](6) NULL,
	[CODPRO] [varchar](4) NULL,
	[CODDEP] [varchar](2) NULL
)

GO


INSERT INTO [Planilla].[Ubigeo]
           ([NOMDIS]
           ,[NOMPRO]
           ,[NOMDEP]
           ,[CODDIS]
           ,[CODPRO]
           ,[CODDEP])
SELECT [NOMDIS]
      ,[NOMPRO]
      ,[NOMDEP]
      ,[CODDIS]
      ,[CODPRO]
      ,[CODDEP]
  FROM Policlinico.dbo.[bUbigeo]

GO

SELECT * FROM [Planilla].[Ubigeo]

GO


CREATE TABLE [Planilla].[Lab_AreaAnalisis](
	[IdAreaAnalisis] INT IDENTITY NOT NULL PRIMARY KEY,
	[CodArea] [varchar](4) NULL,
	[AreaAnalisis] [varchar](25) NULL)

GO

INSERT INTO [Planilla].[Lab_AreaAnalisis]
           ([CodArea]
           ,[AreaAnalisis])
SELECT [CodArea]
      ,[AreaAnalisis]
  FROM Policlinico.[dbo].[vAreasAnalisis]
GO

Select * from Planilla.Lab_AreaAnalisis

GO

CREATE TABLE [Planilla].[dProcedimientos](
	Id_Procedimiento INT IDENTITY NOT NULL PRIMARY KEY,
	[CodPro] [varchar](4) NULL,
	[TipPro] [varchar](2) NULL,	
	[Procedimiento] [varchar](100) NULL,
	[Id_Especialidades] INT NULL,
	[CodEsp] [varchar](4) NULL,
	[PrecioProcedimiento] smallmoney NULL,
	[MontoMedico] smallmoney NULL,
	[Observacion] [varchar](150) NULL,
	[ProImprimir] [varchar](30) NULL,
	[IdAreaLaboratorio] INT NULL,
	[AreaLaboratorio] [varchar](1) NULL
) ON [PRIMARY]
GO

ALTER TABLE [Planilla].[dProcedimientos]
ADD FOREIGN KEY (Id_Especialidades)
REFERENCES [Planilla].[dEspecialidades](Id_Especialidades)
GO
ALTER TABLE [Planilla].[dProcedimientos]
ADD FOREIGN KEY (IdAreaLaboratorio)
REFERENCES [Planilla].[Lab_AreasLaboratorio](IdAreaLaboratorio)
GO

INSERT INTO [Planilla].[dProcedimientos]
           ([CodPro]
           ,[TipPro]
           ,[Procedimiento]
           ,[CodEsp]
           ,[PrecioProcedimiento]
           ,[MontoMedico]
           ,[Observacion]
           ,[ProImprimir]
           ,[AreaLaboratorio])
SELECT [CodPro]
      ,[TipPro]
      ,[Procedimiento]
      ,[CodEsp]
      ,[PrecioProcedimiento]
      ,[MontoMedico]
      ,[Observacion]
      ,[ProImprimir]
      ,[AreaLaboratorio]
  FROM [Policlinico].[dbo].[dProcedimientos]

GO

UPDATE [Planilla].[dProcedimientos]
SET [Planilla].[dProcedimientos].Id_Especialidades =  pe.Id_Especialidades from [Planilla].dProcedimientos pp
INNER JOIN  [Planilla].dEspecialidades pe 
ON pp.CodEsp = pe.CodEsp

GO

UPDATE [Planilla].[dProcedimientos]
SET [Planilla].[dProcedimientos].[IdAreaLaboratorio] =  pal.IdAreaLaboratorio from [Planilla].dProcedimientos pp
INNER JOIN  [Planilla].Lab_AreasLaboratorio pal 
ON pp.AreaLaboratorio = pal.CodAre

GO

Select * from Planilla.dProcedimientos

GO

CREATE TABLE [Planilla].[Lab_TablaAnalisis](
	[IdAnalisis] INT IDENTITY NOT NULL PRIMARY KEY,
	[CodAna] [varchar](5) NULL,
	[Analisis] [varchar](100) NULL,
	[Unidad] [varchar](30) NULL,
	[Titulo] [varchar](1) NULL,
	[Id_Procedimiento] INT NULL,
	[CodPro] [varchar](4) NULL,
	[Procedimiento] [varchar](100) NULL,
	[AreaLaboratorio] [varchar](30) NULL,
	[AreaAnalisis] [varchar](30) NULL,
	[TituloPerfil] [varchar](60) NULL
) ON [PRIMARY]
GO

ALTER TABLE [Planilla].[Lab_TablaAnalisis]
ADD FOREIGN KEY (Id_Procedimiento)
REFERENCES [Planilla].[dProcedimientos](Id_Procedimiento)
GO

INSERT INTO [Planilla].[Lab_TablaAnalisis]
           ([CodAna]
           ,[Analisis]
           ,[Unidad]
           ,[Titulo]       
           ,[CodPro]
           ,[Procedimiento]
           ,[AreaLaboratorio]
           ,[AreaAnalisis]
           ,[TituloPerfil])
SELECT [CodAna]
      ,[Analisis]
      ,[Unidad]
      ,[Titulo]
      ,[CodPro]
      ,[Procedimiento]
      ,[AreaLaboratorio]
      ,[AreaAnalisis]
      ,[TituloPerfil]
  FROM [Policlinico].[dbo].[vTablaAnalisis]
GO


UPDATE [Planilla].[Lab_TablaAnalisis]
SET [Planilla].[Lab_TablaAnalisis].Id_Procedimiento =  pal.Id_Procedimiento from [Planilla].[Lab_TablaAnalisis] pp
INNER JOIN  [Planilla].dProcedimientos pal 
ON pp.CodPro = pal.CodPro

GO

SELECT * FROM [Planilla].[Lab_TablaAnalisis]

GO


CREATE TABLE [Planilla].[Cargo](
	[IdCargo] INT IDENTITY NOT NULL PRIMARY KEY,
	[CodCar] [varchar](3) NOT NULL,
	[Cargo] [varchar](50) NULL,
	[Estado] [tinyint] NULL)

GO


INSERT INTO [Planilla].[Cargo]
           ([CodCar]
           ,[Cargo]
           ,[Estado])
SELECT [CodCar]
      ,[Cargo]
	  ,1
  FROM [Policlinico].dbo.[pCargos]
GO


Select * from [Planilla].[Cargo]

GO


CREATE TABLE [Planilla].[Lab_TablaAnalisisVR](
	[IdValReferencial] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CodVal] [varchar](5) NULL,
	[ValReferencial] [varchar](35) NULL,
	[IdAnalisis] INT NULL,
	[CodAna] [varchar](5) NULL
) 
GO
ALTER TABLE [Planilla].[Lab_TablaAnalisisVR]
ADD FOREIGN KEY ([IdAnalisis])
REFERENCES [Planilla].[Lab_TablaAnalisis]([IdAnalisis])
GO


GO
INSERT INTO [Planilla].[Lab_TablaAnalisisVR]
           ([CodVal]
           ,[ValReferencial]
           ,[CodAna])
SELECT [CodVal]
      ,[ValReferencial]
      ,[CodAna]
  FROM [Policlinico].dbo.[vTablaAnalisisVR]

GO

UPDATE [Planilla].[Lab_TablaAnalisisVR]
SET [Planilla].[Lab_TablaAnalisisVR].IdAnalisis =  pal.IdAnalisis from [Planilla].[Lab_TablaAnalisisVR] pp
INNER JOIN  [Planilla].[Lab_TablaAnalisis] pal 
ON pp.CodAna = pal.CodAna

SELECT * FROM [Planilla].[Lab_TablaAnalisisVR]

GO


CREATE TABLE [Planilla].[DiasLaborables](
	[IdDiasLaborables] INT IDENTITY NOT NULL PRIMARY KEY,
	[CodMes] [varchar](6) NOT NULL,
	[Mes] [varchar](12) NULL,
	[Año] [int] NULL,
	[DiasLab] [tinyint] NULL,
	[Cerrado] [varchar](1) NULL)

GO

INSERT INTO [Planilla].[DiasLaborables]
           ([CodMes]
           ,[Mes]
           ,[Año]
           ,[DiasLab]
           ,[Cerrado])
SELECT [CodMes]
      ,[Mes]
      ,[Año]
      ,[DiasLab]
      ,[Cerrado]
  FROM [Policlinico].dbo.[pDiasLaborables]
GO

Select * from [Planilla].[DiasLaborables]

GO

CREATE TABLE [Planilla].[AreaServicio](
	[IdAreaServicio] INT IDENTITY NOT NULL PRIMARY KEY,
	[CodAre] [varchar](3) NOT NULL,
	[Area] [varchar](40) NULL,
	[Estado] tinyint NULL)

GO

INSERT INTO [Planilla].[AreaServicio]
           ([CodAre]
           ,[Area]
           ,[Estado])
SELECT [CodAre]
      ,[Area]
	  ,1
  FROM Policlinico.[dbo].[pAreasServicios]
GO

Select * from [Planilla].[AreaServicio]

GO

CREATE TABLE [Planilla].[FondoPensiones](
	[IdFondoPen] INT IDENTITY NOT NULL PRIMARY KEY,
	[CodFon] [varchar](3) NOT NULL,
	[Entidad] [varchar](30) NULL,
	[ApoOblF] [decimal](18, 4) NULL,
	[ComVarF] [decimal](18, 4) NULL,
	[PriSegF] [decimal](18, 4) NULL,
	[ApoOblM] [decimal](18, 4) NULL,
	[ComVarM] [decimal](18, 4) NULL,
	[PriSegM] [decimal](18, 4) NULL,
	[PorONP] [decimal](18, 4) NULL,
	[Estado] [tinyint] NULL)

	GO

INSERT INTO [Planilla].[FondoPensiones]
           ([CodFon]
           ,[Entidad]
           ,[ApoOblF]
           ,[ComVarF]
           ,[PriSegF]
           ,[ApoOblM]
           ,[ComVarM]
           ,[PriSegM]
           ,[PorONP]
           ,[Estado])
SELECT [CodFon]
      ,[Entidad]
      ,[ApoOblF]
      ,[ComVarF]
      ,[PriSegF]
      ,[ApoOblM]
      ,[ComVarM]
      ,[PriSegM]
      ,[PorONP]
      ,1
  FROM [Policlinico].dbo.[pFondoPensiones]
GO

GO
Select * from [Planilla].FondoPensiones

GO

CREATE TABLE [Planilla].[AporteEmpleador](
	[IdAporteEmpleador] INT IDENTITY NOT NULL PRIMARY KEY,
	[CodApo] [varchar](3) NOT NULL,
	[Aporte] [varchar](20) NULL,
	[Porcentaje] [decimal](18, 2) NULL)

GO
INSERT INTO [Planilla].[AporteEmpleador]
           ([CodApo]
           ,[Aporte]
           ,[Porcentaje])
SELECT [CodApo]
      ,[Aporte]
      ,[Por]
  FROM Policlinico.[dbo].[pAportesEmpleador]
GO
Select * from [Planilla].[AporteEmpleador]
GO

CREATE TABLE [Planilla].[pPersonal](
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[CodPer] [varchar](4) NOT NULL,
	[DNI] [varchar](8) NULL,
	[ApePaterno] [varchar](60) NULL,
	[ApeMaterno] [varchar](60) NULL,
	[Nombre] [varchar](60) NULL,
	[Direccion] [varchar](100) NULL,
	IdUbigeo INT NULL,
	[CodDistrito] [varchar](8) NULL,
	[FecNac] [smalldatetime] NULL,
	[Telefono] [varchar](15) NULL,
	[Celular] [varchar](15) NULL,
	[Email] [varchar](50) NULL,
	[Sex] [varchar](1) NULL,
	[EstadoCivil] [varchar](1) NULL,
	[NumHij] [tinyint] NULL,
	[FecIngreso] [smalldatetime] NULL,
	[Estudios] [varchar](25) NULL,
	[Grado] [varchar](30) NULL,
	[NumCol] [varchar](6) NULL,
	IdAreaServicio INT NULL,
	[CodAre] [varchar](3) NULL,
	IdCargo INT NULL,
	[CodCar] [varchar](3) NULL,
	IdFondoPen INT NULL,
	[CodFon] [varchar](3) NULL,
	[TipComAFP] [varchar](1) NULL,
	[CUSPP] [varchar](12) NULL,
	[EVida] [varchar](1) NULL,
	[RemBas] smallmoney NULL,
	[AsiFam] smallmoney NULL,
	[RieCaj] smallmoney NULL,
	[SCTR] [char](1) NULL,
	[HorLab] [int] NULL,
	[Observacion] [varchar](100) NULL,
	[Estado] [char](1) NULL,
	[FecBaja] [datetime] NULL,
	[EntidadCTS] [varchar](50) NULL,
	[NumCtaCTS] [varchar](20) NULL,
	[CustomDiasHoras] TINYINT NULL,
	[CustomDias] TINYINT NULL,
	[CustomHoras] TINYINT NULL)
GO
ALTER TABLE [Planilla].[pPersonal]
ADD FOREIGN KEY (IdUbigeo)
REFERENCES [Planilla].[Ubigeo](IdUbigeo)
GO
ALTER TABLE [Planilla].[pPersonal]
ADD FOREIGN KEY (IdAreaServicio)
REFERENCES [Planilla].AreaServicio(IdAreaServicio)
GO
ALTER TABLE [Planilla].[pPersonal]
ADD FOREIGN KEY (IdCargo)
REFERENCES [Planilla].Cargo(IdCargo)
GO
ALTER TABLE [Planilla].[pPersonal]
ADD FOREIGN KEY (IdFondoPen)
REFERENCES [Planilla].FondoPensiones(IdFondoPen)
GO


INSERT INTO [Planilla].[pPersonal]
           ([CodPer]
           ,[DNI]
           ,[ApePaterno]
           ,[ApeMaterno]
           ,[Nombre]
           ,[Direccion]
           ,[CodDistrito]
           ,[FecNac]
           ,[Telefono]
           ,[Celular]
           ,[Email]
           ,[Sex]
           ,[EstadoCivil]
           ,[NumHij]
           ,[FecIngreso]
           ,[Estudios]
           ,[Grado]
           ,[NumCol]
           ,[CodAre]
           ,[CodCar]
           ,[CodFon]
           ,[TipComAFP]
           ,[CUSPP]
           ,[EVida]
           ,[RemBas]
           ,[AsiFam]
           ,[RieCaj]
           ,[SCTR]
           ,[HorLab]
           ,[Observacion]
           ,[Estado]
           ,[FecBaja]
           ,[EntidadCTS]
           ,[NumCtaCTS])
SELECT [CodPer]
      ,[DNI]
      ,[ApePat]
      ,[ApeMat]
      ,[Nom]
      ,[Dir]
      ,[CodDis]
      ,[FecNac]
      ,[Tel]
      ,[Cel]
      ,[Email]
      ,[Sex]
      ,[EstCiv]
      ,[NumHij]
      ,[FecIng]
      ,[Estudios]
      ,[Gra]
      ,[NumCol]
      ,[CodAre]
      ,[CodCar]
      ,[CodFon]
      ,[TipComAFP]
      ,[CUSPP]
      ,[EVida]
      ,[RemBas]
      ,[AsiFam]
      ,[RieCaj]
      ,[SCTR]
      ,[HorLab]
      ,[Obs]
      ,[Estado]
      ,[FecBaj]
      ,[EntidadCTS]
      ,[NumCtaCTS]
  FROM Policlinico.[dbo].[pPersonal]

GO


UPDATE [Planilla].[pPersonal]
SET [Planilla].[pPersonal].IdUbigeo =  pal.IdUbigeo from [Planilla].[pPersonal] pp
INNER JOIN  [Planilla].Ubigeo pal 
ON pp.CodDistrito = pal.CODDIS

GO

UPDATE [Planilla].[pPersonal]
SET [Planilla].[pPersonal].IdAreaServicio =  pal.IdAreaServicio from [Planilla].[pPersonal] pp
INNER JOIN  [Planilla].AreaServicio pal 
ON pp.CodAre = pal.CodAre

GO

UPDATE [Planilla].[pPersonal]
SET [Planilla].[pPersonal].IdCargo =  pal.IdCargo from [Planilla].[pPersonal] pp
INNER JOIN  [Planilla].Cargo pal 
ON pp.CodCar = pal.CodCar

GO


UPDATE [Planilla].[pPersonal]
SET [Planilla].[pPersonal].IdFondoPen =  pal.IdFondoPen from [Planilla].[pPersonal] pp
INNER JOIN  [Planilla].FondoPensiones pal 
ON pp.CodFon = pal.CodFon

GO

SELECT * FROM [Planilla].[pPersonal]

GO

CREATE TABLE [Planilla].[Vacaciones](
	IdVacaciones INT IDENTITY NOT NULL PRIMARY KEY,
	[Año] [int] NULL,
	[Id] INT NULL,
	[CodPer] [varchar](4) NULL,
	[IniProg] [datetime] NULL,
	[FinProg] [datetime] NULL,
	[IniEje1] [datetime] NULL,
	[FinEje1] [datetime] NULL,
	[IniEje2] [datetime] NULL,
	[FinEje2] [datetime] NULL,
	[IniEje3] [datetime] NULL,
	[FinEje3] [datetime] NULL,
	[Completo] [varchar](1) NULL,
	[Obs] [varchar](50) NULL
)
GO

ALTER TABLE [Planilla].[Vacaciones]
ADD FOREIGN KEY (Id)
REFERENCES [Planilla].[pPersonal](Id)
GO

INSERT INTO [Planilla].[Vacaciones]
           ([Año]
           ,[CodPer]
           ,[IniProg]
           ,[FinProg]
           ,[IniEje1]
           ,[FinEje1]
           ,[IniEje2]
           ,[FinEje2]
           ,[IniEje3]
           ,[FinEje3]
           ,[Completo]
           ,[Obs])
SELECT [Año]
      ,[CodPer]
      ,[IniProg]
      ,[FinProg]
      ,[IniEje1]
      ,[FinEje1]
      ,[IniEje2]
      ,[FinEje2]
      ,[IniEje3]
      ,[FinEje3]
      ,[Completo]
      ,[Obs]
  FROM Policlinico.[dbo].[pVacaciones]
GO

UPDATE [Planilla].[Vacaciones]
SET [Planilla].[Vacaciones].Id =  pal.Id from [Planilla].[Vacaciones] pp
INNER JOIN  [Planilla].pPersonal pal 
ON pp.CodPer = pal.CodPer

GO


CREATE TABLE [Planilla].[dMedicos](
	[Id_Medico] INT IDENTITY NOT NULL PRIMARY KEY,
	[CodMed] [varchar](4) NULL,
	[DNI] [varchar](8) NULL,
	[ApePaterno] [varchar](60) NULL,
	[ApeMaterno] [varchar](60) NULL,
	[Nombre] [varchar](60) NULL,
	[Direccion] [varchar](80) NULL,
	IdUbigeo INT NULL,
	[CodDistrito] [varchar](6) NULL,
	[FecNac] [datetime] NULL,
	[Telefono] [varchar](10) NULL,
	[Celular] [varchar](10) NULL,
	[Email] [varchar](40) NULL,
	[RUC] [varchar](11) NULL,
	[FecIngreso] [smalldatetime] NULL,
	[Grado] [varchar](5) NULL,
	[NumCol] [varchar](6) NULL,
	[Sit] [varchar](1) NULL,
	[RNE] [varchar](6) NULL,
	Id_Especialidades1 INT NULL,
	[CodEsp1] [varchar](4) NULL,
	Id_Especialidades2 INT NULL,
	[CodEsp2] [varchar](4) NULL,
	[Estado] [varchar](1) NULL,
	[Tipo] [varchar](1) NULL
)
GO

ALTER TABLE [Planilla].[dMedicos]
ADD FOREIGN KEY (IdUbigeo)
REFERENCES [Planilla].Ubigeo(IdUbigeo)
GO

ALTER TABLE [Planilla].[dMedicos]
ADD FOREIGN KEY (Id_Especialidades1)
REFERENCES [Planilla].dEspecialidades(Id_Especialidades)
GO

ALTER TABLE [Planilla].[dMedicos]
ADD FOREIGN KEY (Id_Especialidades2)
REFERENCES [Planilla].dEspecialidades(Id_Especialidades)

GO

INSERT INTO [Planilla].[dMedicos]
           ([CodMed]
           ,[DNI]
           ,[ApePaterno]
           ,[ApeMaterno]
           ,[Nombre]
           ,[Direccion]
           ,[CodDistrito]
           ,[FecNac]
           ,[Telefono]
           ,[Celular]
           ,[Email]
           ,[RUC]
           ,[FecIngreso]
           ,[Grado]
           ,[NumCol]
           ,[Sit]
           ,[RNE]
           ,[CodEsp1]
           ,[CodEsp2]
           ,[Estado]
           ,[Tipo])
SELECT [CodMed]
      ,[DNI]
      ,[ApePat]
      ,[ApeMat]
      ,[Nom]
      ,[Dir]
      ,[CodDis]
      ,[FecNac]
      ,[Tel]
      ,[Cel]
      ,[Email]
      ,[RUC]
      ,[FecIng]
      ,[Gra]
      ,[NumCol]
      ,[Sit]
      ,[RNE]
      ,[CodEsp1]
      ,[CodEsp2]
      ,[Estado]
      ,[Tipo]
  FROM Policlinico.[dbo].[dMedicos]
GO

UPDATE [Planilla].[dMedicos]
SET [Planilla].[dMedicos].IdUbigeo =  pal.IdUbigeo from [Planilla].[dMedicos] pp
INNER JOIN  [Planilla].Ubigeo pal 
ON pp.CodDistrito = pal.CODDIS

GO

UPDATE [Planilla].[dMedicos]
SET [Planilla].[dMedicos].Id_Especialidades1 =  pal.Id_Especialidades from [Planilla].[dMedicos] pp
INNER JOIN  [Planilla].dEspecialidades pal 
ON pp.CodEsp1 = pal.CodEsp

GO

UPDATE [Planilla].[dMedicos]
SET [Planilla].[dMedicos].Id_Especialidades2 =  pal.Id_Especialidades from [Planilla].[dMedicos] pp
INNER JOIN  [Planilla].dEspecialidades pal 
ON pp.CodEsp2 = pal.CodEsp

GO

CREATE TABLE [Planilla].[PlanillasRem](
	IdPlanilla INT IDENTITY NOT NULL PRIMARY KEY,
	[Periodo] [varchar](6) NULL,
	Id INT NULL,
	[CodPer] [varchar](4) NULL,
	IdCargo INT NULL,
	[CodCar] [varchar](3) NULL,
	IdFondoPen INT NULL,
	[CodFon] [varchar](3) NULL,
	[TipComAFP] [varchar](1) NULL,
	[RemBas] smallmoney NULL,
	[AsiFam] smallmoney NULL,
	[Subsidio] smallmoney NULL,
	[Gratif] smallmoney NULL,
	[RemVac] smallmoney NULL,
	[RieCaj] smallmoney NULL,
	[Reinte] smallmoney NULL,
	[HE] smallmoney NULL,
	[OtrIng] smallmoney NULL,
	[TotIng] smallmoney NULL,
	[PorONP] smallmoney NULL,
	[PorApoObl] smallmoney NULL,
	[PorPriSeg] smallmoney NULL,
	[PorComVar] smallmoney NULL,
	[ONP] smallmoney NULL,
	[ApoObl] smallmoney NULL,
	[PriSeg] smallmoney NULL,
	[ComVar] smallmoney NULL,
	[Quinta] smallmoney NULL,
	[OtrDes] smallmoney NULL,
	[TotDes] smallmoney NULL,
	[Neto] smallmoney NULL,
	[PorEssalud] smallmoney NULL,
	[PorSCTR] smallmoney NULL,
	[Essalud] smallmoney NULL,
	[SCTR] smallmoney NULL,
	[TotApo] smallmoney NULL,
	[DiasLab] [int] NULL,
	[HorasLab] [int] NULL,
	[IniVac] [datetime] NULL,
	[FinVac] [datetime] NULL,
	[DiasVac] [int] NULL,
	[IniIncapacidad] [datetime] NULL,
	[FinIncapacidad] [datetime] NULL,
	[DiasIncapacidad] [int] NULL,
	[InicioSinGoceHaber] [datetime] NULL,
	[FinSinGoceHaber] [datetime] NULL,
	[DiasSinGoceHaber] [int] NULL,
	[Cerrado] [varchar](1) NULL,
	[TipoPlan] [varchar](1) NULL,
	[Corregido] [varchar](1) NULL)
GO
ALTER TABLE [Planilla].[PlanillasRem]
ADD FOREIGN KEY (Id)
REFERENCES [Planilla].pPersonal(Id)
GO
ALTER TABLE [Planilla].[PlanillasRem]
ADD FOREIGN KEY (IdFondoPen)
REFERENCES [Planilla].FondoPensiones(IdFondoPen)
GO
ALTER TABLE [Planilla].[PlanillasRem]
ADD FOREIGN KEY (IdCargo)
REFERENCES [Planilla].Cargo(IdCargo)
GO


INSERT INTO [Planilla].[PlanillasRem]
           ([Periodo]
           ,[CodPer]
           ,[CodCar]
           ,[CodFon]
           ,[TipComAFP]
           ,[RemBas]
           ,[AsiFam]
           ,[Subsidio]
           ,[Gratif]
           ,[RemVac]
           ,[RieCaj]
           ,[Reinte]
           ,[HE]
           ,[OtrIng]
           ,[TotIng]
           ,[PorONP]
           ,[PorApoObl]
           ,[PorPriSeg]
           ,[PorComVar]
           ,[ONP]
           ,[ApoObl]
           ,[PriSeg]
           ,[ComVar]
           ,[Quinta]
           ,[OtrDes]
           ,[TotDes]
           ,[Neto]
           ,[PorEssalud]
           ,[PorSCTR]
           ,[Essalud]
           ,[SCTR]
           ,[TotApo]
           ,[DiasLab]
           ,[HorasLab]
           ,[IniVac]
           ,[FinVac]
           ,[DiasVac]
           ,[IniIncapacidad]
           ,[FinIncapacidad]
           ,[DiasIncapacidad]
           ,[InicioSinGoceHaber]
           ,[FinSinGoceHaber]
           ,[DiasSinGoceHaber]
           ,[Cerrado]
           ,[TipoPlan]
           ,[Corregido])
SELECT [Periodo]
      ,[CodPer]
      ,[CodCar]
      ,[CodFon]
      ,[TipComAFP]
      ,[RemBas]
      ,[AsiFam]
      ,[Subsidio]
      ,[Gratif]
      ,[RemVac]
      ,[RieCaj]
      ,[Reinte]
      ,[HE]
      ,[OtrIng]
      ,[TotIng]
      ,[PorONP]
      ,[PorApoObl]
      ,[PorPriSeg]
      ,[PorComVar]
      ,[ONP]
      ,[ApoObl]
      ,[PriSeg]
      ,[ComVar]
      ,[Quinta]
      ,[OtrDes]
      ,[TotDes]
      ,[Neto]
      ,[PorEssalud]
      ,[PorSCTR]
      ,[Essalud]
      ,[SCTR]
      ,[TotApo]
      ,[DiasLab]
      ,[HorasLab]
      ,[IniVac]
      ,[FinVac]
      ,[DiasVac]
      ,[IniIncapacidad]
      ,[FinIncapacidad]
      ,[DiasIncapacidad]
      ,[InicioSinGoceHaber]
      ,[FinSinGoceHaber]
      ,[DiasSinGoceHaber]
      ,[Cerrado]
      ,[TipoPlan]
      ,'F'
  FROM Policlinico.[dbo].[pPlanillasRem]

GO

UPDATE [Planilla].[PlanillasRem]
SET [Planilla].[PlanillasRem].Id =  pal.Id from [Planilla].[PlanillasRem] pp
INNER JOIN  [Planilla].pPersonal pal 
ON pp.CodPer = pal.CodPer

GO

UPDATE [Planilla].[PlanillasRem]
SET [Planilla].[PlanillasRem].IdCargo =  pal.IdCargo from [Planilla].[PlanillasRem] pp
INNER JOIN  [Planilla].Cargo pal 
ON pp.CodCar = pal.CodCar

GO

UPDATE [Planilla].[PlanillasRem]
SET [Planilla].[PlanillasRem].IdFondoPen =  pal.IdFondoPen from [Planilla].[PlanillasRem] pp
INNER JOIN  [Planilla].FondoPensiones pal 
ON pp.CodFon = pal.CodFon

GO

UPDATE Planilla.dProcedimientos
SET TipPro = 43 WHERE Id_Procedimiento < 300

GO


UPDATE Planilla.dProcedimientos
SET TipPro = 44 WHERE Id_Procedimiento >= 300
