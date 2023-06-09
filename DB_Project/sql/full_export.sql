USE [master]
GO
/****** Object:  Database [vinarsky]    Script Date: 04/01/2023 17:39:49 ******/
CREATE DATABASE [vinarsky]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'vinarsky', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS2019\MSSQL\DATA\vinarsky.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'vinarsky_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS2019\MSSQL\DATA\vinarsky_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [vinarsky] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [vinarsky].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [vinarsky] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [vinarsky] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [vinarsky] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [vinarsky] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [vinarsky] SET ARITHABORT OFF 
GO
ALTER DATABASE [vinarsky] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [vinarsky] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [vinarsky] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [vinarsky] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [vinarsky] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [vinarsky] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [vinarsky] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [vinarsky] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [vinarsky] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [vinarsky] SET  ENABLE_BROKER 
GO
ALTER DATABASE [vinarsky] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [vinarsky] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [vinarsky] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [vinarsky] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [vinarsky] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [vinarsky] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [vinarsky] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [vinarsky] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [vinarsky] SET  MULTI_USER 
GO
ALTER DATABASE [vinarsky] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [vinarsky] SET DB_CHAINING OFF 
GO
ALTER DATABASE [vinarsky] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [vinarsky] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [vinarsky] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [vinarsky] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [vinarsky] SET QUERY_STORE = OFF
GO
USE [vinarsky]
GO
/****** Object:  User [manager]    Script Date: 04/01/2023 17:39:49 ******/
CREATE USER [manager] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [manager]
GO
/****** Object:  Table [dbo].[mesto]    Script Date: 04/01/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mesto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nazev] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pobocka]    Script Date: 04/01/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pobocka](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ulice] [varchar](20) NOT NULL,
	[cislo_popisny] [int] NOT NULL,
	[tel] [varchar](9) NULL,
	[mesto_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[uskladneno]    Script Date: 04/01/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[uskladneno](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[produkt_id] [int] NOT NULL,
	[pobocka_id] [int] NOT NULL,
	[pocet_kusu] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Pobocka_s_nejvice_produkty]    Script Date: 04/01/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[Pobocka_s_nejvice_produkty] as
select top(1) pobocka.id, sum(uskladneno.pocet_kusu) as mnozstvi_produktu, mesto.nazev as Mesto_pobocky, pobocka.ulice, pobocka.tel from pobocka
inner join mesto on pobocka.mesto_id = mesto.id
inner join uskladneno on uskladneno.pobocka_id = pobocka.id
group by mesto.nazev, pobocka.ulice, pobocka.tel, pobocka.id
order by mnozstvi_produktu desc;
GO
/****** Object:  Table [dbo].[objednavka]    Script Date: 04/01/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[objednavka](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[datum_zalozeni] [date] NOT NULL,
	[datum_splatnosti] [date] NOT NULL,
	[datum_prevzeti] [date] NULL,
	[zaplaceno_hotove] [char](1) NOT NULL,
	[pobocka_id] [int] NOT NULL,
	[uzivatel_id] [int] NOT NULL,
	[celkova_cena] [numeric](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[uzivatel]    Script Date: 04/01/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[uzivatel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jmeno] [varchar](20) NOT NULL,
	[prijmeni] [varchar](20) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[tel] [varchar](9) NULL,
	[ulice] [varchar](20) NULL,
	[cislo_popisny] [int] NULL,
	[bankovni_ucet] [varchar](50) NULL,
	[mesto_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Nejdrazsi_objednavka]    Script Date: 04/01/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Nejdrazsi_objednavka] as
select objednavka.id, objednavka.celkova_cena, objednavka.datum_zalozeni, objednavka.datum_splatnosti, uzivatel.jmeno, uzivatel.prijmeni from objednavka
inner join uzivatel on uzivatel.id = objednavka.uzivatel_id
where celkova_cena = (select max(celkova_cena) from objednavka)
GO
/****** Object:  Table [dbo].[kategorie]    Script Date: 04/01/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kategorie](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nazev] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[objednane_produkty]    Script Date: 04/01/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[objednane_produkty](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[produkt_id] [int] NOT NULL,
	[objednavka_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[produkt]    Script Date: 04/01/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[produkt](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nazev] [varchar](30) NOT NULL,
	[cena] [numeric](10, 2) NOT NULL,
	[vaha] [int] NOT NULL,
	[popis] [varchar](100) NULL,
	[kategorie_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[propusteni_zamestnanci]    Script Date: 04/01/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[propusteni_zamestnanci](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jmeno] [varchar](20) NOT NULL,
	[prijmeni] [varchar](20) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[tel] [numeric](9, 0) NULL,
	[datum_nastupu] [date] NOT NULL,
	[datum_propusteni] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zamestnanci]    Script Date: 04/01/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zamestnanci](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jmeno] [varchar](20) NOT NULL,
	[prijmeni] [varchar](20) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[tel] [numeric](9, 0) NULL,
	[ulice] [varchar](20) NOT NULL,
	[cislo_popisne] [int] NOT NULL,
	[datum_nastupu] [date] NOT NULL,
	[mesto_id] [int] NOT NULL,
	[pobocka_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[kategorie] ON 

INSERT [dbo].[kategorie] ([id], [nazev]) VALUES (1, N'Mobily')
INSERT [dbo].[kategorie] ([id], [nazev]) VALUES (2, N'Notebooky')
INSERT [dbo].[kategorie] ([id], [nazev]) VALUES (3, N'Tablety')
INSERT [dbo].[kategorie] ([id], [nazev]) VALUES (4, N'Mysy')
INSERT [dbo].[kategorie] ([id], [nazev]) VALUES (5, N'Klavesnice')
INSERT [dbo].[kategorie] ([id], [nazev]) VALUES (6, N'Herni prislusenstvi')
SET IDENTITY_INSERT [dbo].[kategorie] OFF
GO
SET IDENTITY_INSERT [dbo].[mesto] ON 

INSERT [dbo].[mesto] ([id], [nazev]) VALUES (1, N'Praha')
INSERT [dbo].[mesto] ([id], [nazev]) VALUES (2, N'Kolin')
INSERT [dbo].[mesto] ([id], [nazev]) VALUES (3, N'Zlin')
INSERT [dbo].[mesto] ([id], [nazev]) VALUES (4, N'Plzen')
INSERT [dbo].[mesto] ([id], [nazev]) VALUES (5, N'Ostrava')
INSERT [dbo].[mesto] ([id], [nazev]) VALUES (6, N'Brno')
SET IDENTITY_INSERT [dbo].[mesto] OFF
GO
SET IDENTITY_INSERT [dbo].[objednane_produkty] ON 

INSERT [dbo].[objednane_produkty] ([id], [produkt_id], [objednavka_id]) VALUES (3, 2, 2)
INSERT [dbo].[objednane_produkty] ([id], [produkt_id], [objednavka_id]) VALUES (7, 5, 2)
INSERT [dbo].[objednane_produkty] ([id], [produkt_id], [objednavka_id]) VALUES (5, 1, 3)
INSERT [dbo].[objednane_produkty] ([id], [produkt_id], [objednavka_id]) VALUES (4, 3, 3)
INSERT [dbo].[objednane_produkty] ([id], [produkt_id], [objednavka_id]) VALUES (6, 5, 3)
SET IDENTITY_INSERT [dbo].[objednane_produkty] OFF
GO
SET IDENTITY_INSERT [dbo].[objednavka] ON 

INSERT [dbo].[objednavka] ([id], [datum_zalozeni], [datum_splatnosti], [datum_prevzeti], [zaplaceno_hotove], [pobocka_id], [uzivatel_id], [celkova_cena]) VALUES (2, CAST(N'2022-12-30' AS Date), CAST(N'2023-01-13' AS Date), NULL, N'0', 26, 41, CAST(40800.00 AS Numeric(10, 2)))
INSERT [dbo].[objednavka] ([id], [datum_zalozeni], [datum_splatnosti], [datum_prevzeti], [zaplaceno_hotove], [pobocka_id], [uzivatel_id], [celkova_cena]) VALUES (3, CAST(N'2022-12-30' AS Date), CAST(N'2023-01-13' AS Date), NULL, N'1', 27, 45, CAST(71800.00 AS Numeric(10, 2)))
INSERT [dbo].[objednavka] ([id], [datum_zalozeni], [datum_splatnosti], [datum_prevzeti], [zaplaceno_hotove], [pobocka_id], [uzivatel_id], [celkova_cena]) VALUES (4, CAST(N'2023-01-01' AS Date), CAST(N'2023-01-15' AS Date), NULL, N'0', 28, 46, CAST(0.00 AS Numeric(10, 2)))
SET IDENTITY_INSERT [dbo].[objednavka] OFF
GO
SET IDENTITY_INSERT [dbo].[pobocka] ON 

INSERT [dbo].[pobocka] ([id], [ulice], [cislo_popisny], [tel], [mesto_id]) VALUES (21, N'Prairieview', 6843, N'195329372', 1)
INSERT [dbo].[pobocka] ([id], [ulice], [cislo_popisny], [tel], [mesto_id]) VALUES (22, N'Everett', 6219, N'777385336', 3)
INSERT [dbo].[pobocka] ([id], [ulice], [cislo_popisny], [tel], [mesto_id]) VALUES (23, N'Lunder', 496, N'923994080', 4)
INSERT [dbo].[pobocka] ([id], [ulice], [cislo_popisny], [tel], [mesto_id]) VALUES (24, N'Sunbrook', 783, N'391791057', 2)
INSERT [dbo].[pobocka] ([id], [ulice], [cislo_popisny], [tel], [mesto_id]) VALUES (25, N'Nancy', 364, N'251643080', 5)
INSERT [dbo].[pobocka] ([id], [ulice], [cislo_popisny], [tel], [mesto_id]) VALUES (26, N'Melody', 4655, N'783021397', 3)
INSERT [dbo].[pobocka] ([id], [ulice], [cislo_popisny], [tel], [mesto_id]) VALUES (27, N'Hallows', 482, N'329262520', 5)
INSERT [dbo].[pobocka] ([id], [ulice], [cislo_popisny], [tel], [mesto_id]) VALUES (28, N'Aberg', 46726, N'842562796', 2)
INSERT [dbo].[pobocka] ([id], [ulice], [cislo_popisny], [tel], [mesto_id]) VALUES (29, N'Anzinger', 4, N'143369069', 1)
INSERT [dbo].[pobocka] ([id], [ulice], [cislo_popisny], [tel], [mesto_id]) VALUES (30, N'Glacier Hill', 1, N'721077315', 6)
SET IDENTITY_INSERT [dbo].[pobocka] OFF
GO
SET IDENTITY_INSERT [dbo].[produkt] ON 

INSERT [dbo].[produkt] ([id], [nazev], [cena], [vaha], [popis], [kategorie_id]) VALUES (1, N'Legion 5', CAST(30000.00 AS Numeric(10, 2)), 2900, N'popis', 3)
INSERT [dbo].[produkt] ([id], [nazev], [cena], [vaha], [popis], [kategorie_id]) VALUES (2, N'Iphone 12', CAST(39000.00 AS Numeric(10, 2)), 1500, N'popis', 1)
INSERT [dbo].[produkt] ([id], [nazev], [cena], [vaha], [popis], [kategorie_id]) VALUES (3, N'Macbook', CAST(40000.00 AS Numeric(10, 2)), 1000, N'popis', 5)
INSERT [dbo].[produkt] ([id], [nazev], [cena], [vaha], [popis], [kategorie_id]) VALUES (4, N'Legion i7', CAST(25000.00 AS Numeric(10, 2)), 2800, N'popis', 2)
INSERT [dbo].[produkt] ([id], [nazev], [cena], [vaha], [popis], [kategorie_id]) VALUES (5, N'Xbox Controler', CAST(1800.00 AS Numeric(10, 2)), 800, N'popis', 3)
INSERT [dbo].[produkt] ([id], [nazev], [cena], [vaha], [popis], [kategorie_id]) VALUES (6, N'PS Controler', CAST(18000.00 AS Numeric(10, 2)), 800, N'popis', 5)
INSERT [dbo].[produkt] ([id], [nazev], [cena], [vaha], [popis], [kategorie_id]) VALUES (7, N'Logitech keyboard', CAST(2000.00 AS Numeric(10, 2)), 1500, N'popis', 2)
INSERT [dbo].[produkt] ([id], [nazev], [cena], [vaha], [popis], [kategorie_id]) VALUES (8, N'Logitech mouse', CAST(2500.00 AS Numeric(10, 2)), 500, N'popis', 1)
INSERT [dbo].[produkt] ([id], [nazev], [cena], [vaha], [popis], [kategorie_id]) VALUES (9, N'Herni zidle', CAST(12000.00 AS Numeric(10, 2)), 3000, N'popis', 5)
INSERT [dbo].[produkt] ([id], [nazev], [cena], [vaha], [popis], [kategorie_id]) VALUES (10, N'Modlozka pod mys', CAST(900.00 AS Numeric(10, 2)), 100, N'popis', 6)
INSERT [dbo].[produkt] ([id], [nazev], [cena], [vaha], [popis], [kategorie_id]) VALUES (11, N'Dell notebook', CAST(19000.00 AS Numeric(10, 2)), 2100, N'popis', 3)
INSERT [dbo].[produkt] ([id], [nazev], [cena], [vaha], [popis], [kategorie_id]) VALUES (12, N'Asus zenphone', CAST(7000.00 AS Numeric(10, 2)), 300, N'popis', 4)
INSERT [dbo].[produkt] ([id], [nazev], [cena], [vaha], [popis], [kategorie_id]) VALUES (13, N'Lenovo tablet', CAST(4000.00 AS Numeric(10, 2)), 1200, N'popis', 1)
SET IDENTITY_INSERT [dbo].[produkt] OFF
GO
SET IDENTITY_INSERT [dbo].[propusteni_zamestnanci] ON 

INSERT [dbo].[propusteni_zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [datum_nastupu], [datum_propusteni]) VALUES (1, N'Kelci', N'Tanti', N'ktanti4@imdb.com', CAST(999000111 AS Numeric(9, 0)), CAST(N'2016-01-18' AS Date), CAST(N'2022-12-29' AS Date))
SET IDENTITY_INSERT [dbo].[propusteni_zamestnanci] OFF
GO
SET IDENTITY_INSERT [dbo].[uskladneno] ON 

INSERT [dbo].[uskladneno] ([id], [produkt_id], [pobocka_id], [pocet_kusu]) VALUES (41, 13, 30, 6)
INSERT [dbo].[uskladneno] ([id], [produkt_id], [pobocka_id], [pocet_kusu]) VALUES (42, 4, 27, 9)
INSERT [dbo].[uskladneno] ([id], [produkt_id], [pobocka_id], [pocet_kusu]) VALUES (43, 11, 27, 10)
INSERT [dbo].[uskladneno] ([id], [produkt_id], [pobocka_id], [pocet_kusu]) VALUES (44, 4, 22, 10)
INSERT [dbo].[uskladneno] ([id], [produkt_id], [pobocka_id], [pocet_kusu]) VALUES (45, 1, 23, 1)
INSERT [dbo].[uskladneno] ([id], [produkt_id], [pobocka_id], [pocet_kusu]) VALUES (46, 9, 28, 7)
INSERT [dbo].[uskladneno] ([id], [produkt_id], [pobocka_id], [pocet_kusu]) VALUES (47, 2, 23, 10)
INSERT [dbo].[uskladneno] ([id], [produkt_id], [pobocka_id], [pocet_kusu]) VALUES (48, 4, 26, 4)
INSERT [dbo].[uskladneno] ([id], [produkt_id], [pobocka_id], [pocet_kusu]) VALUES (49, 8, 28, 10)
INSERT [dbo].[uskladneno] ([id], [produkt_id], [pobocka_id], [pocet_kusu]) VALUES (50, 7, 24, 3)
INSERT [dbo].[uskladneno] ([id], [produkt_id], [pobocka_id], [pocet_kusu]) VALUES (53, 8, 30, 6)
INSERT [dbo].[uskladneno] ([id], [produkt_id], [pobocka_id], [pocet_kusu]) VALUES (54, 11, 26, 11)
INSERT [dbo].[uskladneno] ([id], [produkt_id], [pobocka_id], [pocet_kusu]) VALUES (55, 11, 30, 3)
INSERT [dbo].[uskladneno] ([id], [produkt_id], [pobocka_id], [pocet_kusu]) VALUES (56, 9, 21, 5)
INSERT [dbo].[uskladneno] ([id], [produkt_id], [pobocka_id], [pocet_kusu]) VALUES (57, 7, 29, 10)
INSERT [dbo].[uskladneno] ([id], [produkt_id], [pobocka_id], [pocet_kusu]) VALUES (58, 5, 26, 4)
INSERT [dbo].[uskladneno] ([id], [produkt_id], [pobocka_id], [pocet_kusu]) VALUES (59, 13, 29, 4)
INSERT [dbo].[uskladneno] ([id], [produkt_id], [pobocka_id], [pocet_kusu]) VALUES (60, 3, 27, 2)
INSERT [dbo].[uskladneno] ([id], [produkt_id], [pobocka_id], [pocet_kusu]) VALUES (61, 5, 27, 1)
SET IDENTITY_INSERT [dbo].[uskladneno] OFF
GO
SET IDENTITY_INSERT [dbo].[uzivatel] ON 

INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (41, N'Lilian', N'Dossettor', N'ldossettor0@live.com', N'825455196', N'Beilfuss', 38411, N'PL49 8397 7331 9931 5791 3147 5395', 1)
INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (42, N'Kitti', N'Wreak', N'kwreak1@mtv.com', N'881256498', N'Pepper Wood', 59173, N'SM91 F829 2430 989H VHDE WOJE FHV', 3)
INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (43, N'Cristin', N'Gawkroge', N'cgawkroge2@sakura.ne.jp', N'584014138', N'Fordem', 30, N'AL45 2662 3969 AUX7 1PG7 C3KM OFXZ', 6)
INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (44, N'Robinette', N'Redborn', N'rredborn3@rambler.ru', N'569767164', N'Dawn', 38, N'CY33 5126 7808 2BOV KHK9 ZW3V R2DZ', 5)
INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (45, N'Eberhard', N'Rowden', N'erowden4@google.co.uk', N'580570696', N'Memorial', 362, N'MU54 XQYD 1014 9057 9322 4765 208Q HQ', 1)
INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (46, N'Tawnya', N'Hessay', N'thessay5@alibaba.com', N'247360357', N'Rigney', 147, N'GL96 3400 2660 7312 85', 2)
INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (47, N'Dill', N'Kenington', N'dkenington6@multiply.com', N'239285190', N'Meadow Ridge', 34865, N'AL58 3755 6966 1JOI PA9W 2RPB AFQT', 2)
INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (48, N'Marijo', N'Wedlock', N'mwedlock7@parallels.com', N'381535203', N'Fisk', 2, N'EE71 8790 1457 5902 8597', 2)
INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (49, N'Aveline', N'Quogan', N'aquogan8@last.fm', N'919155351', N'Badeau', 15742, N'LV88 TGPG FH9I SN3T WKPK F', 1)
INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (50, N'Tadeo', N'Jakov', N'tjakov9@godaddy.com', N'731511550', N'Warbler', 6488, N'CY42 6095 7882 USZ0 GDFW 07E9 89WP', 3)
INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (51, N'Michal', N'Golborne', N'mgolbornea@so-net.ne.jp', N'817616626', N'New Castle', 370, N'GE26 ZZ39 6627 2632 7255 38', 2)
INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (52, N'Whitman', N'Buttwell', N'wbuttwellb@abc.net.au', N'272760282', N'Gina', 8, N'ME88 5959 2589 1326 8227 96', 5)
INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (53, N'Blondelle', N'Fihelly', N'bfihellyc@gizmodo.com', N'19293250', N'Bay', 4, N'IL14 7752 3187 8553 9718 522', 3)
INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (54, N'Ronny', N'Calley', N'rcalleyd@linkedin.com', N'335074039', N'Sheridan', 4, N'FR73 4981 2987 08PZ VVTW FAI4 131', 3)
INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (55, N'Kara', N'Cockrem', N'kcockreme@ezinearticles.com', N'731636688', N'Armistice', 309, N'CY20 4126 4562 GKUM TM5G VVMB SAXW', 1)
INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (56, N'Nalani', N'Pykerman', N'npykermanf@4shared.com', N'9099804', N'Manley', 64, N'MR14 9275 6457 6763 4262 8526 676', 3)
INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (57, N'Vanni', N'Duckering', N'vduckeringg@discuz.net', N'686415418', N'Ludington', 84395, N'CY68 8855 9241 2KWG C0HK 9AKV 1IVD', 5)
INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (58, N'Modestine', N'Hayers', N'mhayersh@scientificamerican.com', N'740702107', N'Macpherson', 89752, N'FR71 9627 7830 10LY 5UVN 4FW3 M55', 5)
INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (59, N'Angy', N'Rushe', N'arushei@timesonline.co.uk', N'254594444', N'Clove', 898, N'LV66 AWFB OCCC KRWD FYJW Y', 1)
INSERT [dbo].[uzivatel] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisny], [bankovni_ucet], [mesto_id]) VALUES (60, N'Danya', N'Bothbie', N'dbothbiej@t.co', N'81135040', N'Twin Pines', 3, N'GT35 DTKG OFAB 5MLY RE0H QY4S ILSZ', 6)
SET IDENTITY_INSERT [dbo].[uzivatel] OFF
GO
SET IDENTITY_INSERT [dbo].[zamestnanci] ON 

INSERT [dbo].[zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisne], [datum_nastupu], [mesto_id], [pobocka_id]) VALUES (1, N'Rossy', N'Edgcombe', N'redgcombe0@reddit.com', CAST(444555666 AS Numeric(9, 0)), N'Mochova', 23, CAST(N'2017-05-09' AS Date), 2, 21)
INSERT [dbo].[zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisne], [datum_nastupu], [mesto_id], [pobocka_id]) VALUES (2, N'Manolo', N'Whittaker', N'mwhittaker1@wiley.com', CAST(999333111 AS Numeric(9, 0)), N'Na Rohu', 92, CAST(N'2013-01-15' AS Date), 5, 28)
INSERT [dbo].[zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisne], [datum_nastupu], [mesto_id], [pobocka_id]) VALUES (3, N'Gabey', N'Hindrich', N'ghindrich2@java.com', CAST(999222111 AS Numeric(9, 0)), N'Pod Skalou', 12, CAST(N'2014-06-14' AS Date), 5, 29)
INSERT [dbo].[zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisne], [datum_nastupu], [mesto_id], [pobocka_id]) VALUES (4, N'Loise', N'Gaishson', N'lgaishson3@wsj.com', CAST(999999111 AS Numeric(9, 0)), N'Na Vrchu', 566, CAST(N'2015-01-14' AS Date), 6, 25)
INSERT [dbo].[zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisne], [datum_nastupu], [mesto_id], [pobocka_id]) VALUES (6, N'Bobbee', N'Roobottom', N'broobottom5@usgs.gov', CAST(999000333 AS Numeric(9, 0)), N'Americka', 64, CAST(N'2017-01-18' AS Date), 4, 23)
INSERT [dbo].[zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisne], [datum_nastupu], [mesto_id], [pobocka_id]) VALUES (7, N'Lezlie', N'Bullimore', N'lbullimore6@networksolutions.com', CAST(666333111 AS Numeric(9, 0)), N'Brnenska', 54, CAST(N'2018-01-18' AS Date), 3, 22)
INSERT [dbo].[zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisne], [datum_nastupu], [mesto_id], [pobocka_id]) VALUES (8, N'Ervin', N'Bordman', N'ebordman7@stanford.edu', CAST(999666111 AS Numeric(9, 0)), N'Vrsovicka', 277, CAST(N'2019-07-19' AS Date), 1, 21)
INSERT [dbo].[zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisne], [datum_nastupu], [mesto_id], [pobocka_id]) VALUES (9, N'Joy', N'Vondra', N'jvondra8@gizmodo.com', CAST(333111 AS Numeric(9, 0)), N'Kosicka', 9, CAST(N'2018-08-18' AS Date), 3, 30)
INSERT [dbo].[zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisne], [datum_nastupu], [mesto_id], [pobocka_id]) VALUES (10, N'Trudie', N'Tyreman', N'ttyreman9@cbslocal.com', CAST(456338111 AS Numeric(9, 0)), N'Rostovksa', 748, CAST(N'2015-09-18' AS Date), 3, 29)
INSERT [dbo].[zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisne], [datum_nastupu], [mesto_id], [pobocka_id]) VALUES (11, N'Rebekkah', N'McGriele', N'rmcgrielea@prweb.com', CAST(999338646 AS Numeric(9, 0)), N'Madridska', 222, CAST(N'2017-02-18' AS Date), 4, 28)
INSERT [dbo].[zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisne], [datum_nastupu], [mesto_id], [pobocka_id]) VALUES (12, N'Fee', N'Hakey', N'fhakeyb@feedburner.com', CAST(999333351 AS Numeric(9, 0)), N'Na Safrance', 52, CAST(N'2012-03-18' AS Date), 1, 27)
INSERT [dbo].[zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisne], [datum_nastupu], [mesto_id], [pobocka_id]) VALUES (13, N'Herta', N'De la Yglesia', N'hdelayglesiac@columbia.edu', CAST(999333111 AS Numeric(9, 0)), N'Na Kralovce', 641, CAST(N'2011-04-18' AS Date), 1, 26)
INSERT [dbo].[zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisne], [datum_nastupu], [mesto_id], [pobocka_id]) VALUES (14, N'Vale', N'Fenby', N'vfenbyd@google.com.hk', CAST(997353111 AS Numeric(9, 0)), N'Slovenska', 245, CAST(N'2012-05-14' AS Date), 4, 25)
INSERT [dbo].[zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisne], [datum_nastupu], [mesto_id], [pobocka_id]) VALUES (15, N'Edwina', N'Highman', N'ehighmane@google.de', CAST(997533011 AS Numeric(9, 0)), N'Kodanska', 67, CAST(N'2018-06-18' AS Date), 5, 24)
INSERT [dbo].[zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisne], [datum_nastupu], [mesto_id], [pobocka_id]) VALUES (16, N'Amalea', N'Brister', N'abristerf@seattletimes.com', CAST(999333131 AS Numeric(9, 0)), N'Francouzska', 168, CAST(N'2018-07-17' AS Date), 6, 30)
INSERT [dbo].[zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisne], [datum_nastupu], [mesto_id], [pobocka_id]) VALUES (17, N'Prince', N'Crombie', N'pcrombieg@telegraph.co.uk', CAST(994333111 AS Numeric(9, 0)), N'Vltavska', 249, CAST(N'2015-03-13' AS Date), 3, 21)
INSERT [dbo].[zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisne], [datum_nastupu], [mesto_id], [pobocka_id]) VALUES (18, N'Sonja', N'Skippings', N'sskippingsh@mayoclinic.com', CAST(999348111 AS Numeric(9, 0)), N'Krimicka', 266, CAST(N'2012-04-15' AS Date), 4, 22)
INSERT [dbo].[zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisne], [datum_nastupu], [mesto_id], [pobocka_id]) VALUES (19, N'Stormi', N'Warrender', N'swarrenderi@bandcamp.com', CAST(999333082 AS Numeric(9, 0)), N'Korunni', 85, CAST(N'2019-05-10' AS Date), 5, 23)
INSERT [dbo].[zamestnanci] ([id], [jmeno], [prijmeni], [email], [tel], [ulice], [cislo_popisne], [datum_nastupu], [mesto_id], [pobocka_id]) VALUES (20, N'Barclay', N'Turvey', N'bturveyj@weather.com', CAST(258333111 AS Numeric(9, 0)), N'Hradecinska', 22, CAST(N'2017-06-28' AS Date), 6, 24)
SET IDENTITY_INSERT [dbo].[zamestnanci] OFF
GO
/****** Object:  Index [objednane_produkty_index]    Script Date: 04/01/2023 17:39:50 ******/
CREATE NONCLUSTERED INDEX [objednane_produkty_index] ON [dbo].[objednane_produkty]
(
	[objednavka_id] ASC,
	[produkt_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [objednavka_uzivatel_index]    Script Date: 04/01/2023 17:39:50 ******/
CREATE NONCLUSTERED INDEX [objednavka_uzivatel_index] ON [dbo].[objednavka]
(
	[uzivatel_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__propuste__AB6E6164871C2FC1]    Script Date: 04/01/2023 17:39:50 ******/
ALTER TABLE [dbo].[propusteni_zamestnanci] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [uskladneno_index]    Script Date: 04/01/2023 17:39:50 ******/
CREATE NONCLUSTERED INDEX [uskladneno_index] ON [dbo].[uskladneno]
(
	[pobocka_id] ASC,
	[produkt_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__uzivatel__AB6E61641A2E12CD]    Script Date: 04/01/2023 17:39:50 ******/
ALTER TABLE [dbo].[uzivatel] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__zamestna__AB6E61644F94F15E]    Script Date: 04/01/2023 17:39:50 ******/
ALTER TABLE [dbo].[zamestnanci] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[pobocka]  WITH CHECK ADD  CONSTRAINT [pobocka_mesto_fk] FOREIGN KEY([mesto_id])
REFERENCES [dbo].[mesto] ([id])
GO
ALTER TABLE [dbo].[pobocka] CHECK CONSTRAINT [pobocka_mesto_fk]
GO
ALTER TABLE [dbo].[produkt]  WITH CHECK ADD  CONSTRAINT [produkt_kategorie_fk] FOREIGN KEY([kategorie_id])
REFERENCES [dbo].[kategorie] ([id])
GO
ALTER TABLE [dbo].[produkt] CHECK CONSTRAINT [produkt_kategorie_fk]
GO
ALTER TABLE [dbo].[uskladneno]  WITH CHECK ADD  CONSTRAINT [uskladneno_pobocka_fk] FOREIGN KEY([pobocka_id])
REFERENCES [dbo].[pobocka] ([id])
GO
ALTER TABLE [dbo].[uskladneno] CHECK CONSTRAINT [uskladneno_pobocka_fk]
GO
ALTER TABLE [dbo].[uskladneno]  WITH CHECK ADD  CONSTRAINT [uskladneno_produkt_fk] FOREIGN KEY([produkt_id])
REFERENCES [dbo].[produkt] ([id])
GO
ALTER TABLE [dbo].[uskladneno] CHECK CONSTRAINT [uskladneno_produkt_fk]
GO
ALTER TABLE [dbo].[uzivatel]  WITH CHECK ADD  CONSTRAINT [uzivatel_mesto_fk] FOREIGN KEY([mesto_id])
REFERENCES [dbo].[mesto] ([id])
GO
ALTER TABLE [dbo].[uzivatel] CHECK CONSTRAINT [uzivatel_mesto_fk]
GO
ALTER TABLE [dbo].[zamestnanci]  WITH CHECK ADD  CONSTRAINT [zamestnanci_pobocka_fk] FOREIGN KEY([pobocka_id])
REFERENCES [dbo].[pobocka] ([id])
GO
ALTER TABLE [dbo].[zamestnanci] CHECK CONSTRAINT [zamestnanci_pobocka_fk]
GO
ALTER TABLE [dbo].[uzivatel]  WITH CHECK ADD  CONSTRAINT [check_email_uzi] CHECK  (([email] like '%___@___%'))
GO
ALTER TABLE [dbo].[uzivatel] CHECK CONSTRAINT [check_email_uzi]
GO
/****** Object:  StoredProcedure [dbo].[Prevoz_zbozi_na_jinou_pobocku]    Script Date: 04/01/2023 17:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Prevoz_zbozi_na_jinou_pobocku] @Kam_pobocka_id int, @Odkud_pobocka_id int, @Produkt_id int, @Pocet_prevezen int
AS
BEGIN
BEGIN TRANSACTION;
if EXISTS(SELECT id FROM uskladneno WHERE pobocka_id = @Kam_pobocka_id and produkt_id = @Produkt_id)
	if @Pocet_prevezen <= (select pocet_kusu from uskladneno WHERE pobocka_id = @Odkud_pobocka_id and produkt_id = @Produkt_id)
		begin
		update uskladneno set pocet_kusu = pocet_kusu - @Pocet_prevezen WHERE pobocka_id = @Odkud_pobocka_id and produkt_id = @Produkt_id;
		update uskladneno set pocet_kusu = pocet_kusu + @Pocet_prevezen WHERE pobocka_id = @Kam_pobocka_id and produkt_id = @Produkt_id;
		end
	else
		select 'Pocet produktu k prevozu presahuje uskladneny pocet';
else 
	begin
	insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (@Produkt_id, @Kam_pobocka_id, @Pocet_prevezen);
	update uskladneno set pocet_kusu = pocet_kusu - @Pocet_prevezen WHERE pobocka_id = @Odkud_pobocka_id and produkt_id = @Produkt_id;
	end
COMMIT TRANSACTION;
END
GO
/****** Object:  StoredProcedure [dbo].[Zalozeni_objednavky]    Script Date: 04/01/2023 17:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Zalozeni_objednavky] @uzivatel_id int, @pobocka_id int, @zaplaceno_hotove CHAR(1)
AS
BEGIN
	insert into objednavka(datum_zalozeni, datum_splatnosti, zaplaceno_hotove, pobocka_id, uzivatel_id, celkova_cena) values((SELECT CAST( GETDATE() AS Date )), DATEADD(day,14,(SELECT CAST( GETDATE() AS Date ))),  @zaplaceno_hotove, @pobocka_id, @uzivatel_id, 0);
END
GO
/****** Object:  Trigger [dbo].[vlozeni_do_kosiku]    Script Date: 04/01/2023 17:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[vlozeni_do_kosiku]
ON [dbo].[objednane_produkty]
instead of insert
AS
	BEGIN
	BEGIN TRANSACTION;
		declare @produkt_id int, @objednavka_id int, @cena numeric(10,2)

		select @produkt_id = produkt_id, @objednavka_id = objednavka_id from inserted;
		select @cena = (select cena from produkt where id = @produkt_id);

		insert into objednane_produkty(produkt_id, objednavka_id) values (@produkt_id, @objednavka_id);

		update objednavka set celkova_cena = celkova_cena + @cena where id = @objednavka_id;
	COMMIT TRANSACTION;
	END
GO
ALTER TABLE [dbo].[objednane_produkty] ENABLE TRIGGER [vlozeni_do_kosiku]
GO
/****** Object:  Trigger [dbo].[zam_do_propusteny_zam]    Script Date: 04/01/2023 17:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[zam_do_propusteny_zam]
ON [dbo].[zamestnanci]
instead of delete
AS
	BEGIN
	BEGIN TRANSACTION;
		declare @id int,@prijmeni varchar(20), @jmeno varchar(20),@email varchar(50), @tel NUMERIC(9), @datum_nastupu date, @datum_propusteni date;

		select @id = id, @prijmeni = prijmeni, @jmeno = jmeno,@email = email, @tel = tel, @datum_nastupu = datum_nastupu,  @datum_propusteni = (SELECT CAST( GETDATE() AS Date )) from deleted;

		insert into propusteni_zamestnanci(jmeno, prijmeni, email, tel, datum_nastupu, datum_propusteni) values (@jmeno, @prijmeni, @email, @tel, @datum_nastupu, @datum_propusteni)

		delete from zamestnanci where id = @id;
		COMMIT TRANSACTION;
	END
GO
ALTER TABLE [dbo].[zamestnanci] ENABLE TRIGGER [zam_do_propusteny_zam]
GO
USE [master]
GO
ALTER DATABASE [vinarsky] SET  READ_WRITE 
GO
