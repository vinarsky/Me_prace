USE [master]
GO
/****** Object:  Database [vinarsky]    Script Date: 04/01/2023 17:38:34 ******/
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
/****** Object:  User [manager]    Script Date: 04/01/2023 17:38:34 ******/
CREATE USER [manager] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [manager]
GO
/****** Object:  Table [dbo].[mesto]    Script Date: 04/01/2023 17:38:34 ******/
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
/****** Object:  Table [dbo].[pobocka]    Script Date: 04/01/2023 17:38:35 ******/
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
/****** Object:  Table [dbo].[uskladneno]    Script Date: 04/01/2023 17:38:35 ******/
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
/****** Object:  View [dbo].[Pobocka_s_nejvice_produkty]    Script Date: 04/01/2023 17:38:35 ******/
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
/****** Object:  Table [dbo].[objednavka]    Script Date: 04/01/2023 17:38:35 ******/
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
/****** Object:  Table [dbo].[uzivatel]    Script Date: 04/01/2023 17:38:35 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Nejdrazsi_objednavka]    Script Date: 04/01/2023 17:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Nejdrazsi_objednavka] as
select objednavka.id, objednavka.celkova_cena, objednavka.datum_zalozeni, objednavka.datum_splatnosti, uzivatel.jmeno, uzivatel.prijmeni from objednavka
inner join uzivatel on uzivatel.id = objednavka.uzivatel_id
where celkova_cena = (select max(celkova_cena) from objednavka)
GO
/****** Object:  Table [dbo].[kategorie]    Script Date: 04/01/2023 17:38:35 ******/
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
/****** Object:  Table [dbo].[objednane_produkty]    Script Date: 04/01/2023 17:38:35 ******/
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
/****** Object:  Table [dbo].[produkt]    Script Date: 04/01/2023 17:38:35 ******/
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
/****** Object:  Table [dbo].[propusteni_zamestnanci]    Script Date: 04/01/2023 17:38:35 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zamestnanci]    Script Date: 04/01/2023 17:38:35 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [objednane_produkty_index]    Script Date: 04/01/2023 17:38:35 ******/
CREATE NONCLUSTERED INDEX [objednane_produkty_index] ON [dbo].[objednane_produkty]
(
	[objednavka_id] ASC,
	[produkt_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [objednavka_uzivatel_index]    Script Date: 04/01/2023 17:38:35 ******/
CREATE NONCLUSTERED INDEX [objednavka_uzivatel_index] ON [dbo].[objednavka]
(
	[uzivatel_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [uskladneno_index]    Script Date: 04/01/2023 17:38:35 ******/
CREATE NONCLUSTERED INDEX [uskladneno_index] ON [dbo].[uskladneno]
(
	[pobocka_id] ASC,
	[produkt_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
/****** Object:  StoredProcedure [dbo].[Prevoz_zbozi_na_jinou_pobocku]    Script Date: 04/01/2023 17:38:35 ******/
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
/****** Object:  StoredProcedure [dbo].[Zalozeni_objednavky]    Script Date: 04/01/2023 17:38:35 ******/
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
/****** Object:  Trigger [dbo].[vlozeni_do_kosiku]    Script Date: 04/01/2023 17:38:35 ******/
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
/****** Object:  Trigger [dbo].[zam_do_propusteny_zam]    Script Date: 04/01/2023 17:38:35 ******/
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
