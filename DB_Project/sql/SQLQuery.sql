use vinarsky;

CREATE TABLE kategorie (
	id int primary key identity(1,1),
    nazev        VARCHAR(30) NOT NULL,
);

CREATE TABLE mesto (
	id int primary key identity(1,1),
    nazev    VARCHAR(20) NOT NULL,
);


CREATE TABLE objednane_produkty (
	id int primary key identity(1,1),
    produkt_id       int NOT NULL,
    objednavka_id int NOT NULL
);

CREATE TABLE objednavka (
	id int primary key identity(1,1),
    datum_zalozeni       DATE NOT NULL,
    datum_splatnosti     DATE NOT NULL,
    datum_prevzeti       DATE,
    zaplaceno_hotove     CHAR(1) NOT NULL,
    pobocka_id   int NOT NULL,
    uzivatel_id int NOT NULL,
	celkova_cena numeric(10,2)
);


CREATE TABLE pobocka (
	id int primary key identity(1,1),
    ulice          VARCHAR(20) NOT NULL,
    cislo_popisny  INTEGER NOT NULL,
    tel            NUMERIC(6) NOT NULL,
    mesto_id int NOT NULL
);

CREATE TABLE produkt (
	id int primary key identity(1,1),
    nazev                  VARCHAR(30) NOT NULL,
    cena                   NUMERIC(10, 2) NOT NULL,
    vaha                   INTEGER NOT NULL,
	popis				   varchar(100),
    kategorie_id int NOT NULL
);


CREATE TABLE uskladneno (
	id int primary key identity(1,1),
    produkt_id int NOT NULL,
    pobocka_id int NOT NULL,
	pocet_kusu int NOT NULL
);

CREATE TABLE uzivatel (
	id int primary key identity(1,1),
    jmeno          VARCHAR(20) NOT NULL,
    prijmeni       VARCHAR(20) NOT NULL,
    email          VARCHAR(50) unique NOT NULL,
    tel            NUMERIC(6),
    ulice          VARCHAR(20),
    cislo_popisny  INTEGER,
    bankovni_ucet  VARCHAR(20),
    mesto_id int
);


CREATE TABLE zamestnanci (
	id int primary key identity(1,1),
    jmeno          VARCHAR(20) NOT NULL,
    prijmeni       VARCHAR(20) NOT NULL,
    email          VARCHAR(50) unique NOT NULL,
    tel            NUMERIC(9),
    ulice          VARCHAR(20) NOT NULL,
    cislo_popisne  INTEGER NOT NULL,
    datum_nastupu  DATE NOT NULL,
    mesto_id int NOT NULL,
	pobocka_id int NOT NULL
);


CREATE TABLE propusteni_zamestnanci (
	id int primary key identity(1,1),
    jmeno          VARCHAR(20) NOT NULL,
    prijmeni       VARCHAR(20) NOT NULL,
    email          VARCHAR(50) unique NOT NULL,
    tel            NUMERIC(9),
    datum_nastupu  DATE NOT NULL,
	datum_propusteni DATE NOT NULL
);


ALTER TABLE objednane_produkty
    ADD CONSTRAINT objednane_produkty_objednavka_fk FOREIGN KEY ( objednavka_id )
        REFERENCES objednavka ( id );

ALTER TABLE objednane_produkty
    ADD CONSTRAINT objednane_produkty_produkt_fk FOREIGN KEY ( produkt_id )
        REFERENCES produkt ( id );

ALTER TABLE objednavka
    ADD CONSTRAINT objednavka_pobocka_fk FOREIGN KEY ( pobocka_id )
        REFERENCES pobocka ( id );

ALTER TABLE objednavka
    ADD CONSTRAINT objednavka_uzivatel_fk FOREIGN KEY ( uzivatel_id )
        REFERENCES uzivatel ( id );

ALTER TABLE pobocka
    ADD CONSTRAINT pobocka_mesto_fk FOREIGN KEY ( mesto_id )
        REFERENCES mesto ( id );

ALTER TABLE produkt
    ADD CONSTRAINT produkt_kategorie_fk FOREIGN KEY ( kategorie_id )
        REFERENCES kategorie ( id );
ALTER TABLE uskladneno
    ADD CONSTRAINT uskladneno_pobocka_fk FOREIGN KEY ( pobocka_id )
        REFERENCES pobocka ( id );

ALTER TABLE uskladneno
    ADD CONSTRAINT uskladneno_produkt_fk FOREIGN KEY ( produkt_id )
        REFERENCES produkt ( id );

ALTER TABLE uzivatel
    ADD CONSTRAINT uzivatel_mesto_fk FOREIGN KEY ( mesto_id )
        REFERENCES mesto ( id );

ALTER TABLE uzivatel
	add CONSTRAINT check_email_uzi
		check(email like '%___@___%');

ALTER TABLE zamestnanci
    ADD CONSTRAINT zamestnanci_mesto_fk FOREIGN KEY ( mesto_id )
        REFERENCES mesto ( id );

ALTER TABLE zamestnanci
	add CONSTRAINT check_email_zam
		check(email like '%___@___%');

ALTER TABLE zamestnanci
    ADD CONSTRAINT zamestnanci_pobocka_fk FOREIGN KEY ( pobocka_id )
        REFERENCES pobocka ( id );


begin;
insert into mesto(nazev) values('Praha');
insert into mesto(nazev) values('Kolin');
insert into mesto(nazev) values('Zlin');
insert into mesto(nazev) values('Plzen');
insert into mesto(nazev) values('Ostrava');
insert into mesto(nazev) values('Brno');


insert into kategorie(nazev) values('Mobily');
insert into kategorie(nazev) values('Notebooky');
insert into kategorie(nazev) values('Tablety');
insert into kategorie(nazev) values('Mysy');
insert into kategorie(nazev) values('Klavesnice');
insert into kategorie(nazev) values('Herni prislusenstvi');


insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Rossy', 'Edgcombe', 'redgcombe0@reddit.com', '444555666', 'Mochova', 23, '2017-05-09', 2, 21);
insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Manolo', 'Whittaker', 'mwhittaker1@wiley.com', '999333111', 'Na Rohu', 92, '2013-01-15', 5, 28);
insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Gabey', 'Hindrich', 'ghindrich2@java.com', '999222111', 'Pod Skalou', 12, '2014-06-14', 5, 29);
insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Loise', 'Gaishson', 'lgaishson3@wsj.com', '999999111', 'Na Vrchu', 566, '2015-01-14', 6, 25);
insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Kelci', 'Tanti', 'ktanti4@imdb.com', '999000111', 'Tisnovska', 120, '2016-01-18', 1, 24);
insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Bobbee', 'Roobottom', 'broobottom5@usgs.gov', '999000333', 'Americka', 64, '2017-01-18', 4, 23);
insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Lezlie', 'Bullimore', 'lbullimore6@networksolutions.com', '666333111', 'Brnenska', 54, '2018-01-18', 3, 22);
insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Ervin', 'Bordman', 'ebordman7@stanford.edu', '999666111', 'Vrsovicka', 277, '2019-07-19', 1, 21);
insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Joy', 'Vondra', 'jvondra8@gizmodo.com', '000333111', 'Kosicka', 9, '2018-08-18', 3, 30);
insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Trudie', 'Tyreman', 'ttyreman9@cbslocal.com', '456338111', 'Rostovksa', 748, '2015-09-18', 3, 29);
insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Rebekkah', 'McGriele', 'rmcgrielea@prweb.com', '999338646', 'Madridska', 222, '2017-02-18', 4, 28);
insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Fee', 'Hakey', 'fhakeyb@feedburner.com', '999333351', 'Na Safrance', 52, '2012-03-18', 1, 27);
insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Herta', 'De la Yglesia', 'hdelayglesiac@columbia.edu', '999333111', 'Na Kralovce', 641, '2011-04-18', 1, 26);
insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Vale', 'Fenby', 'vfenbyd@google.com.hk', '997353111', 'Slovenska', 245, '2012-05-14', 4, 25);
insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Edwina', 'Highman', 'ehighmane@google.de', '997533011', 'Kodanska', 67, '2018-06-18', 5, 24);
insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Amalea', 'Brister', 'abristerf@seattletimes.com', '999333131', 'Francouzska', 168, '2018-07-17', 6, 30);
insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Prince', 'Crombie', 'pcrombieg@telegraph.co.uk', '994333111', 'Vltavska', 249, '2015-03-13', 3, 21);
insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Sonja', 'Skippings', 'sskippingsh@mayoclinic.com', '999348111', 'Krimicka', 266, '2012-04-15', 4, 22);
insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Stormi', 'Warrender', 'swarrenderi@bandcamp.com', '999333082', 'Korunni', 85, '2019-05-10', 5, 23);
insert into zamestnanci (jmeno, prijmeni, email, tel, ulice, cislo_popisne, datum_nastupu, mesto_id, pobocka_id) values ('Barclay', 'Turvey', 'bturveyj@weather.com', '258333111', 'Hradecinska', 22, '2017-06-28', 6, 24);



insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Lilian', 'Dossettor', 'ldossettor0@live.com', '825455196', 'Beilfuss', '38411', 'PL49 8397 7331 9931 5791 3147 5395', 1);
insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Kitti', 'Wreak', 'kwreak1@mtv.com', '881256498', 'Pepper Wood', '59173', 'SM91 F829 2430 989H VHDE WOJE FHV', 3);
insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Cristin', 'Gawkroge', 'cgawkroge2@sakura.ne.jp', '584014138', 'Fordem', '030', 'AL45 2662 3969 AUX7 1PG7 C3KM OFXZ', 6);
insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Robinette', 'Redborn', 'rredborn3@rambler.ru', '569767164', 'Dawn', '38', 'CY33 5126 7808 2BOV KHK9 ZW3V R2DZ', 5);
insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Eberhard', 'Rowden', 'erowden4@google.co.uk', '580570696', 'Memorial', '362', 'MU54 XQYD 1014 9057 9322 4765 208Q HQ', 1);
insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Tawnya', 'Hessay', 'thessay5@alibaba.com', '247360357', 'Rigney', '0147', 'GL96 3400 2660 7312 85', 2);
insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Dill', 'Kenington', 'dkenington6@multiply.com', '239285190', 'Meadow Ridge', '34865', 'AL58 3755 6966 1JOI PA9W 2RPB AFQT', 2);
insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Marijo', 'Wedlock', 'mwedlock7@parallels.com', '381535203', 'Fisk', '02', 'EE71 8790 1457 5902 8597', 2);
insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Aveline', 'Quogan', 'aquogan8@last.fm', '919155351', 'Badeau', '15742', 'LV88 TGPG FH9I SN3T WKPK F', 1);
insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Tadeo', 'Jakov', 'tjakov9@godaddy.com', '731511550', 'Warbler', '06488', 'CY42 6095 7882 USZ0 GDFW 07E9 89WP', 3);
insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Michal', 'Golborne', 'mgolbornea@so-net.ne.jp', '817616626', 'New Castle', '370', 'GE26 ZZ39 6627 2632 7255 38', 2);
insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Whitman', 'Buttwell', 'wbuttwellb@abc.net.au', '272760282', 'Gina', '8', 'ME88 5959 2589 1326 8227 96', 5);
insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Blondelle', 'Fihelly', 'bfihellyc@gizmodo.com', '19293250', 'Bay', '4', 'IL14 7752 3187 8553 9718 522', 3);
insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Ronny', 'Calley', 'rcalleyd@linkedin.com', '335074039', 'Sheridan', '4', 'FR73 4981 2987 08PZ VVTW FAI4 131', 3);
insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Kara', 'Cockrem', 'kcockreme@ezinearticles.com', '731636688', 'Armistice', '309', 'CY20 4126 4562 GKUM TM5G VVMB SAXW', 1);
insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Nalani', 'Pykerman', 'npykermanf@4shared.com', '9099804', 'Manley', '064', 'MR14 9275 6457 6763 4262 8526 676', 3);
insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Vanni', 'Duckering', 'vduckeringg@discuz.net', '686415418', 'Ludington', '84395', 'CY68 8855 9241 2KWG C0HK 9AKV 1IVD', 5);
insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Modestine', 'Hayers', 'mhayersh@scientificamerican.com', '740702107', 'Macpherson', '89752', 'FR71 9627 7830 10LY 5UVN 4FW3 M55', 5);
insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Angy', 'Rushe', 'arushei@timesonline.co.uk', '254594444', 'Clove', '0898', 'LV66 AWFB OCCC KRWD FYJW Y', 1);
insert into uzivatel (jmeno, prijmeni, email, tel, ulice, cislo_popisny, bankovni_ucet, mesto_id) values ('Danya', 'Bothbie', 'dbothbiej@t.co', '81135040', 'Twin Pines', '3', 'GT35 DTKG OFAB 5MLY RE0H QY4S ILSZ', 6);


insert into produkt (nazev, cena, vaha, popis, kategorie_id) values ('Legion 5', '30000', '2900', 'popis', 3);
insert into produkt (nazev, cena, vaha, popis, kategorie_id) values ('Iphone 12', '39000', '1500', 'popis', 1);
insert into produkt (nazev, cena, vaha, popis, kategorie_id) values ('Macbook', '40000', '1000', 'popis', 5);
insert into produkt (nazev, cena, vaha, popis, kategorie_id) values ('Legion i7', '25000', '2800', 'popis', 2);
insert into produkt (nazev, cena, vaha, popis, kategorie_id) values ('Xbox Controler', '1800', '800', 'popis', 3);
insert into produkt (nazev, cena, vaha, popis, kategorie_id) values ('PS Controler', '18000', '800', 'popis', 5);
insert into produkt (nazev, cena, vaha, popis, kategorie_id) values ('Logitech keyboard', '2000', '1500', 'popis', 2);
insert into produkt (nazev, cena, vaha, popis, kategorie_id) values ('Logitech mouse', '2500', '500', 'popis', 1);
insert into produkt (nazev, cena, vaha, popis, kategorie_id) values ('Herni zidle', '12000', '3000', 'popis', 5);
insert into produkt (nazev, cena, vaha, popis, kategorie_id) values ('Modlozka pod mys', '900', '100', 'popis', 6);
insert into produkt (nazev, cena, vaha, popis, kategorie_id) values ('Dell notebook', '19000', '2100', 'popis', 3);
insert into produkt (nazev, cena, vaha, popis, kategorie_id) values ('Asus zenphone', '7000', '300', 'popis', 4);
insert into produkt (nazev, cena, vaha, popis, kategorie_id) values ('Lenovo tablet', '4000', '1200', 'popis', 1);


insert into pobocka (ulice, cislo_popisny, tel, mesto_id) values ('Prairieview', '6843', '195329372', 1);
insert into pobocka (ulice, cislo_popisny, tel, mesto_id) values ('Everett', '06219', '777385336', 3);
insert into pobocka (ulice, cislo_popisny, tel, mesto_id) values ('Lunder', '496', '923994080', 4);
insert into pobocka (ulice, cislo_popisny, tel, mesto_id) values ('Sunbrook', '783', '391791057', 2);
insert into pobocka (ulice, cislo_popisny, tel, mesto_id) values ('Nancy', '0364', '251643080', 5);
insert into pobocka (ulice, cislo_popisny, tel, mesto_id) values ('Melody', '4655', '783021397', 3);
insert into pobocka (ulice, cislo_popisny, tel, mesto_id) values ('Hallows', '482', '329262520', 5);
insert into pobocka (ulice, cislo_popisny, tel, mesto_id) values ('Aberg', '46726', '842562796', 2);
insert into pobocka (ulice, cislo_popisny, tel, mesto_id) values ('Anzinger', '4', '143369069', 1);
insert into pobocka (ulice, cislo_popisny, tel, mesto_id) values ('Glacier Hill', '1', '721077315', 6);


insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (13, 30, 6);
insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (4, 27, 7);
insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (11, 27, 2);
insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (4, 22, 10);
insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (1, 23, 1);
insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (9, 28, 7);
insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (2, 23, 10);
insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (4, 26, 6);
insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (8, 28, 10);
insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (7, 24, 3);
insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (11, 26, 10);
insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (4, 27, 6);
insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (8, 30, 6);
insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (11, 26, 8);
insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (11, 30, 3);
insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (9, 21, 5);
insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (7, 29, 10);
insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (5, 26, 7);
insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (13, 29, 4);
insert into uskladneno (produkt_id, pobocka_id, pocet_kusu) values (3, 27, 4);
commit;

select * from mesto;
select * from zamestnanci;
select * from uzivatel;
select * from kategorie;
select * from produkt;
select * from pobocka;
select * from propusteni_zamestnanci;
select * from uskladneno;
select * from objednavka;
select * from objednane_produkty;

delete from mesto;
delete from zamestnanci;
delete from uzivatel
delete from kategorie;
delete from produkt;
delete from pobocka;
delete from propusteni_zamestnanci;
delete from uskladneno;
delete from objednavka;
delete from objednane_produkty;

----------------------------------------------
----------------------------------------------
--Triggery
-----------------------
go
alter trigger zam_do_propusteny_zam
ON zamestnanci
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
go
delete from zamestnanci where id = 5;	--otestovani
-----------------------
go
alter trigger vlozeni_do_kosiku
ON objednane_produkty
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
go
insert into objednane_produkty(produkt_id, objednavka_id) values (5,2);
----------------------------------------------
----------------------------------------------
--Procedury
-----------------------
alter PROCEDURE Prevoz_zbozi_na_jinou_pobocku @Kam_pobocka_id int, @Odkud_pobocka_id int, @Produkt_id int, @Pocet_prevezen int
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

EXECUTE Prevoz_zbozi_na_jinou_pobocku 26, 27, 11, 5	--otestovani
select * from uskladneno WHERE pobocka_id = 26
select * from uskladneno WHERE pobocka_id = 27
-----------------------
alter PROCEDURE Zalozeni_objednavky @uzivatel_id int, @pobocka_id int, @zaplaceno_hotove CHAR(1)
AS
BEGIN
	insert into objednavka(datum_zalozeni, datum_splatnosti, zaplaceno_hotove, pobocka_id, uzivatel_id, celkova_cena) values((SELECT CAST( GETDATE() AS Date )), DATEADD(day,14,(SELECT CAST( GETDATE() AS Date ))),  @zaplaceno_hotove, @pobocka_id, @uzivatel_id, 0);
END

execute Zalozeni_objednavky 46, 28, 0
----------------------------------------------
----------------------------------------------
--Pohledy
-----------------------
alter view Pobocka_s_nejvice_produkty as
select top(1) pobocka.id, sum(uskladneno.pocet_kusu) as mnozstvi_produktu, mesto.nazev as Mesto_pobocky, pobocka.ulice, pobocka.tel from pobocka
inner join mesto on pobocka.mesto_id = mesto.id
inner join uskladneno on uskladneno.pobocka_id = pobocka.id
group by mesto.nazev, pobocka.ulice, pobocka.tel, pobocka.id
order by mnozstvi_produktu desc;

select * from Pobocka_s_nejvice_produkty
-----------------------
create view Nejdrazsi_objednavka as
select objednavka.id, objednavka.celkova_cena, objednavka.datum_zalozeni, objednavka.datum_splatnosti, uzivatel.jmeno, uzivatel.prijmeni from objednavka
inner join uzivatel on uzivatel.id = objednavka.uzivatel_id
where celkova_cena = (select max(celkova_cena) from objednavka)

select * from Nejdrazsi_objednavka
----------------------------------------------
----------------------------------------------
--Indexes
-----------------------
CREATE INDEX uskladneno_index
ON uskladneno (pobocka_id, produkt_id);

CREATE INDEX objednavka_uzivatel_index
ON objednavka (uzivatel_id);

CREATE INDEX objednane_produkty_index
ON objednane_produkty (objednavka_id, produkt_id);
