CREATE DATABASE [Devsu]
GO

USE [Devsu]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 26/06/2023 14:03:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[Contrasena] [varchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 26/06/2023 14:03:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[IdCuenta] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Numero] [varchar](50) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[SaldoInicial] [decimal](10, 2) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[IdCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimiento]    Script Date: 26/06/2023 14:03:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimiento](
	[IdMovimiento] [int] IDENTITY(1,1) NOT NULL,
	[IdCuenta] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[Valor] [decimal](10, 2) NOT NULL,
	[Saldo] [decimal](10, 2) NOT NULL,
	[Limite] [decimal](10, 2) NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_Movimiento] PRIMARY KEY CLUSTERED 
(
	[IdMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 26/06/2023 14:03:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[IdPersona] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](100) NOT NULL,
	[Genero] [varchar](50) NOT NULL,
	[Edad] [int] NOT NULL,
	[Identificacion] [varchar](50) NOT NULL,
	[Direccion] [varchar](250) NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Persona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([IdPersona])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Persona]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_Cliente]
GO
ALTER TABLE [dbo].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Movimiento_Cuenta] FOREIGN KEY([IdCuenta])
REFERENCES [dbo].[Cuenta] ([IdCuenta])
GO
ALTER TABLE [dbo].[Movimiento] CHECK CONSTRAINT [FK_Movimiento_Cuenta]
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarMovimientosPorActualizarLimite]    Script Date: 26/06/2023 14:03:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_ListarMovimientosPorActualizarLimite]
@fechaActual DATETIME
AS
BEGIN
	SELECT * FROM Movimiento
	WHERE Eliminado = 0 AND IdMovimiento IN 
	(
		SELECT MAX(IdMovimiento) FROM Movimiento
		WHERE Eliminado = 0 AND DATEDIFF(DAY, Fecha, @fechaActual) = 1
		GROUP BY IdCuenta
	)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ReporteEstadoCuenta]    Script Date: 26/06/2023 14:03:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_ReporteEstadoCuenta]
@idCliente INT,
@fechaInicio DATETIME NULL,
@fechafin DATETIME NULL
AS
BEGIN
	SELECT CONVERT(datetime, movimiento.Fecha, 103) AS Fecha, persona.Nombres AS Cliente, cuenta.Numero AS NumeroCuenta, cuenta.Tipo, cuenta.SaldoInicial,
		   cuenta.Estado, movimiento.Valor AS Movimiento, movimiento.Saldo
	FROM Cuenta cuenta
	INNER JOIN Movimiento movimiento 
	ON cuenta.IdCuenta = movimiento.IdCuenta AND 
	   movimiento.IdMovimiento IN (SELECT MAX(IdMovimiento) FROM Movimiento WHERE Eliminado = 0 GROUP BY IdCuenta)
	INNER JOIN Cliente cliente
	ON cuenta.IdCliente = cliente.IdCliente AND
	   cliente.Eliminado = 0
	INNER JOIN Persona persona
	ON cliente.IdPersona = persona.IdPersona AND
	   persona.Eliminado = 0
	WHERE cuenta.Eliminado = 0 AND cuenta.IdCliente = @idCliente AND
	((@fechaInicio IS NULL OR @fechaInicio <=  movimiento.Fecha) AND (@fechafin IS NULL OR @fechafin >= movimiento.Fecha))
END
GO
