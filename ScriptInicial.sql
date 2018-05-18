USE PoliclinicoNuevo

CREATE SCHEMA Planilla

GO

CREATE TABLE [Planilla].[AreaLaboratorio](
	[IdAreaLaboratorio] INT IDENTITY NOT NULL PRIMARY KEY,
	[CodAre] [varchar](1) NOT NULL,
	[AreaLab] [varchar](25) NULL)
GO

INSERT INTO [Planilla].[AreaLaboratorio]
           ([CodAre]
           ,[AreaLab])
SELECT [CodAre]
      ,[AreaLab]
  FROM Policlinico.dbo.[vAreasLaboratorio]
GO

SELECT * FROM  [Planilla].[AreaLaboratorio]

GO


CREATE TABLE [Planilla].[Especialidad](
	[IdEspecialidad] INT IDENTITY NOT NULL PRIMARY KEY,
	[CodEsp] [varchar](4) NULL,
	[Descripcion] [varchar](80) NOT NULL,
	[PrecioConsulta] smallmoney NOT NULL,
	[MontoMedico] smallmoney NOT NULL
) ON [PRIMARY]

GO

INSERT INTO Planilla.Especialidad (CodEsp, Descripcion, PrecioConsulta, MontoMedico)
SELECT esp.CodEsp,esp.Especialidad, COALESCE(esp.PrecioConsulta,0), COALESCE(esp.MontoMedico,0)  FROM Policlinico.dbo.dEspecialidades esp

GO

SELECT * FROM PoliclinicoNuevo.Planilla.Especialidad 

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


CREATE TABLE [Planilla].[AreaAnalisis](
	[IdAreaAnalisis] INT IDENTITY NOT NULL PRIMARY KEY,
	[CodArea] [varchar](4) NULL,
	[AreaAnalisis] [varchar](25) NULL)

GO

INSERT INTO [Planilla].[AreaAnalisis]
           ([CodArea]
           ,[AreaAnalisis])
SELECT [CodArea]
      ,[AreaAnalisis]
  FROM Policlinico.[dbo].[vAreasAnalisis]
GO

Select * from Planilla.AreaAnalisis

GO

CREATE TABLE [Planilla].[Procedimiento](
	IdProcedimiento INT IDENTITY NOT NULL PRIMARY KEY,
	[CodPro] [varchar](4) NULL,
	[TipPro] [varchar](1) NULL,	
	[Procedimiento] [varchar](100) NULL,
	[IdEspecialidad] INT NULL,
	[CodEsp] [varchar](4) NULL,
	[PrecioProcedimiento] smallmoney NULL,
	[MontoMedico] smallmoney NULL,
	[Observacion] [varchar](150) NULL,
	[ProImprimir] [varchar](30) NULL,
	[IdAreaLaboratorio] INT NULL,
	[AreaLaboratorio] [varchar](1) NULL
) ON [PRIMARY]
GO

ALTER TABLE [Planilla].[Procedimiento]
ADD FOREIGN KEY (IdEspecialidad)
REFERENCES [Planilla].[Especialidad](IdEspecialidad)
GO
ALTER TABLE [Planilla].[Procedimiento]
ADD FOREIGN KEY (IdAreaLaboratorio)
REFERENCES [Planilla].[AreaLaboratorio](IdAreaLaboratorio)
GO

INSERT INTO [Planilla].[Procedimiento]
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

UPDATE [Planilla].[Procedimiento]
SET [Planilla].[Procedimiento].IdEspecialidad =  pe.IdEspecialidad from [Planilla].Procedimiento pp
INNER JOIN  [Planilla].Especialidad pe 
ON pp.CodEsp = pe.CodEsp

GO

UPDATE [Planilla].[Procedimiento]
SET [Planilla].[Procedimiento].[IdAreaLaboratorio] =  pal.IdAreaLaboratorio from [Planilla].Procedimiento pp
INNER JOIN  [Planilla].AreaLaboratorio pal 
ON pp.AreaLaboratorio = pal.CodAre

GO

Select * from Planilla.Procedimiento

GO

CREATE TABLE [Planilla].[TablaAnalisis](
	[IdAnalisis] INT IDENTITY NOT NULL PRIMARY KEY,
	[CodAna] [varchar](5) NULL,
	[Analisis] [varchar](100) NULL,
	[Unidad] [varchar](30) NULL,
	[Titulo] [varchar](1) NULL,
	[IdProcedimiento] INT NULL,
	[CodPro] [varchar](4) NULL,
	[Procedimiento] [varchar](100) NULL,
	[AreaLaboratorio] [varchar](30) NULL,
	[AreaAnalisis] [varchar](30) NULL,
	[TituloPerfil] [varchar](60) NULL
) ON [PRIMARY]
GO

ALTER TABLE [Planilla].[TablaAnalisis]
ADD FOREIGN KEY (IdProcedimiento)
REFERENCES [Planilla].[Procedimiento](IdProcedimiento)
GO

INSERT INTO [Planilla].[TablaAnalisis]
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


UPDATE [Planilla].[TablaAnalisis]
SET [Planilla].[TablaAnalisis].IdProcedimiento =  pal.IdProcedimiento from [Planilla].[TablaAnalisis] pp
INNER JOIN  [Planilla].Procedimiento pal 
ON pp.CodPro = pal.CodPro

GO

SELECT * FROM [Planilla].[TablaAnalisis]

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


CREATE TABLE [Planilla].[TablaAnalisisVR](
	[IdValReferencial] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CodVal] [varchar](5) NULL,
	[ValReferencial] [varchar](35) NULL,
	[IdAnalisis] INT NULL,
	[CodAna] [varchar](5) NULL
) 
GO
ALTER TABLE [Planilla].[TablaAnalisisVR]
ADD FOREIGN KEY ([IdAnalisis])
REFERENCES [Planilla].[TablaAnalisis]([IdAnalisis])
GO


GO
INSERT INTO [Planilla].[TablaAnalisisVR]
           ([CodVal]
           ,[ValReferencial]
           ,[CodAna])
SELECT [CodVal]
      ,[ValReferencial]
      ,[CodAna]
  FROM [Policlinico].dbo.[vTablaAnalisisVR]

GO

UPDATE [Planilla].[TablaAnalisisVR]
SET [Planilla].[TablaAnalisisVR].IdAnalisis =  pal.IdAnalisis from [Planilla].[TablaAnalisisVR] pp
INNER JOIN  [Planilla].[TablaAnalisis] pal 
ON pp.CodAna = pal.CodAna

SELECT * FROM [Planilla].[TablaAnalisisVR]

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

CREATE TABLE [Planilla].[Personal](
	[IdPersonal] INT IDENTITY NOT NULL PRIMARY KEY,
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
	[NumCtaCTS] [varchar](20) NULL)

GO
ALTER TABLE [Planilla].[Personal]
ADD FOREIGN KEY (IdUbigeo)
REFERENCES [Planilla].[Ubigeo](IdUbigeo)
GO
ALTER TABLE [Planilla].[Personal]
ADD FOREIGN KEY (IdAreaServicio)
REFERENCES [Planilla].AreaServicio(IdAreaServicio)
GO
ALTER TABLE [Planilla].[Personal]
ADD FOREIGN KEY (IdCargo)
REFERENCES [Planilla].Cargo(IdCargo)
GO
ALTER TABLE [Planilla].[Personal]
ADD FOREIGN KEY (IdFondoPen)
REFERENCES [Planilla].FondoPensiones(IdFondoPen)
GO


INSERT INTO [Planilla].[Personal]
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


UPDATE [Planilla].[Personal]
SET [Planilla].[Personal].IdUbigeo =  pal.IdUbigeo from [Planilla].[Personal] pp
INNER JOIN  [Planilla].Ubigeo pal 
ON pp.CodDistrito = pal.CODDIS

GO

UPDATE [Planilla].[Personal]
SET [Planilla].[Personal].IdAreaServicio =  pal.IdAreaServicio from [Planilla].[Personal] pp
INNER JOIN  [Planilla].AreaServicio pal 
ON pp.CodAre = pal.CodAre

GO

UPDATE [Planilla].[Personal]
SET [Planilla].[Personal].IdCargo =  pal.IdCargo from [Planilla].[Personal] pp
INNER JOIN  [Planilla].Cargo pal 
ON pp.CodCar = pal.CodCar

GO


UPDATE [Planilla].[Personal]
SET [Planilla].[Personal].IdFondoPen =  pal.IdFondoPen from [Planilla].[Personal] pp
INNER JOIN  [Planilla].FondoPensiones pal 
ON pp.CodFon = pal.CodFon

GO

SELECT * FROM [Planilla].[Personal]

GO

CREATE TABLE [Planilla].[Vacaciones](
	IdVacaciones INT IDENTITY NOT NULL PRIMARY KEY,
	[Año] [int] NULL,
	[IdPersonal] INT NULL,
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
ADD FOREIGN KEY (IdPersonal)
REFERENCES [Planilla].[Personal](IdPersonal)
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
SET [Planilla].[Vacaciones].IdPersonal =  pal.IdPersonal from [Planilla].[Vacaciones] pp
INNER JOIN  [Planilla].Personal pal 
ON pp.CodPer = pal.CodPer

GO


CREATE TABLE [Planilla].[Medico](
	[IdMedico] INT IDENTITY NOT NULL PRIMARY KEY,
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
	IdEspecialidad1 INT NULL,
	[CodEsp1] [varchar](4) NULL,
	IdEspecialidad2 INT NULL,
	[CodEsp2] [varchar](4) NULL,
	[Estado] [varchar](1) NULL,
	[Tipo] [varchar](1) NULL
)
GO

ALTER TABLE [Planilla].[Medico]
ADD FOREIGN KEY (IdUbigeo)
REFERENCES [Planilla].Ubigeo(IdUbigeo)
GO

ALTER TABLE [Planilla].[Medico]
ADD FOREIGN KEY (IdEspecialidad1)
REFERENCES [Planilla].Especialidad(IdEspecialidad)
GO

ALTER TABLE [Planilla].[Medico]
ADD FOREIGN KEY (IdEspecialidad2)
REFERENCES [Planilla].Especialidad(IdEspecialidad)

GO

INSERT INTO [Planilla].[Medico]
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

UPDATE [Planilla].[Medico]
SET [Planilla].[Medico].IdUbigeo =  pal.IdUbigeo from [Planilla].[Medico] pp
INNER JOIN  [Planilla].Ubigeo pal 
ON pp.CodDistrito = pal.CODDIS

GO

UPDATE [Planilla].[Medico]
SET [Planilla].[Medico].IdEspecialidad1 =  pal.IdEspecialidad from [Planilla].[Medico] pp
INNER JOIN  [Planilla].Especialidad pal 
ON pp.CodEsp1 = pal.CodEsp

GO

UPDATE [Planilla].[Medico]
SET [Planilla].[Medico].IdEspecialidad2 =  pal.IdEspecialidad from [Planilla].[Medico] pp
INNER JOIN  [Planilla].Especialidad pal 
ON pp.CodEsp2 = pal.CodEsp

GO

CREATE TABLE [Planilla].[PlanillasRem](
	IdPlanilla INT IDENTITY NOT NULL PRIMARY KEY,
	[Periodo] [varchar](6) NULL,
	IdPersonal INT NULL,
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
	[TipoPlan] [varchar](1) NULL
)
GO
ALTER TABLE [Planilla].[PlanillasRem]
ADD FOREIGN KEY (IdPersonal)
REFERENCES [Planilla].Personal(IdPersonal)
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
           ,[TipoPlan])
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
  FROM Policlinico.[dbo].[pPlanillasRem]

GO

UPDATE [Planilla].[PlanillasRem]
SET [Planilla].[PlanillasRem].IdPersonal =  pal.IdPersonal from [Planilla].[PlanillasRem] pp
INNER JOIN  [Planilla].Personal pal 
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



