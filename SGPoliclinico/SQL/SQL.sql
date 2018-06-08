USE [SGPoliclinico]
GO
/*
CREATE TABLE [dbo].[Especialidad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodEsp] [char](4) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[PrecioConsulta] [decimal](18, 2) NULL,
	[MontoMedico] [decimal](18, 2) NULL,
	[idEstado] [int] NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaBaja] [datetime] NULL,
 CONSTRAINT [PK_Especialidad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Especialidad] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO 
*/
CREATE proc [dbo].[UPS_ESPECIALIDAD_MANT]  
@Opc   int=0,  
@Id    int=0,  
@CodEsp   varchar(4)='',  
@Descripcion varchar(200)='',  
@PrecioConsulta decimal(18, 2)=0,  
@MontoMedic  decimal(18, 2)=0,  
@idEstado  int=1  
as  
begin  
 if(@Opc=1)--SELECT *  
 begin   
  SELECT *
  FROM Especialidad  
  where CodEsp like '%'+@CodEsp+'%' and Descripcion like @Descripcion+'%'    
   and  ((idEstado=@idEstado)or(@idEstado=-1))   
 end  
 else if(@Opc=2)--SELECT 1  
 begin  
  SELECT Id, CodEsp, Descripcion, PrecioConsulta, MontoMedico, idEstado,(case idEstado when 1 then 'ACTIVO' else 'INACTIVO'end) 'ESTADOREG', FechaRegistro, FechaBaja  
  FROM  Especialidad  
  where   Id=@Id  
 end  
 else if(@Opc=3)--INSERT  
 begin  
  insert into Especialidad (CodEsp, Descripcion, PrecioConsulta, MontoMedico, idEstado)  
  values(@CodEsp,@Descripcion,@PrecioConsulta,@MontoMedic,@idEstado)   
 end  
 else if(@Opc=4)--UPDATE  
 begin  
  update Especialidad  
  set Descripcion=@Descripcion,PrecioConsulta=@PrecioConsulta, MontoMedico=@MontoMedic, idEstado=@idEstado  
   where id = @id  
 end  
 else if(@Opc=5)--DELETE  
 begin  
  delete from Especialidad where id = @id  
 end  
 else if(@Opc=6)--COD  
 begin  
  select 'E'+RIGHT('000'+(convert(varchar,(isnull(max(id),0)+1))),3) 'ID' from Especialidad where idEstado=1  
 end   
end
go 
/*
CREATE TABLE [dbo].[Procedimiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodPro] [char](4) NOT NULL,
	[TipPro] [char](1) NOT NULL,
	[Id_Especialidad] [int] NOT NULL references Especialidad,
	[Descripcion] [varchar](200) NULL,
	[PrecioConsulta] [decimal](18, 2) NULL,
	[MontoMedico] [decimal](18, 2) NULL,	
	[Observacion] [varchar](150) NULL,
	[ProImprimir] [char](30) NULL,
	[AreaLaborato] [char](1) NULL,
	[idEstado] [int] NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaBaja] [datetime] NULL,
 CONSTRAINT [PK_Procedimiento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Procedimiento] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO 
*/ 