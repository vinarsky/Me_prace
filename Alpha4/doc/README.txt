P2P aplikace pro překlad slov
Autor: Radek Vinařský, radek.vinarsky@post.cz
Dokončení: 18.2.2023
Vytvořeno jako školní projekt během studia na SPŠE Ječná ve 4.ročníku.

Pro spuštění programu můžete poklepat na soubor main.py v hlavní adresáři, pokud tato metoda selže, je možné 
do příkazové řádky napsat 'python <absolutní cesta k souboru main.py.>. Po spuštění se připojte k serveru pomocí puttyny. Adressa je v souboru config.conf
pod klíčem LocalAddress a port je pod klíčem LocalServerPort. Nezapomente zaškrtnout raw připojení.


Package Commands obsahuje všechny příkazy které server příjímá:
exit - command vestavěný do serveru, vypne server a clienta
TRANSLATELOCL"slovo" - překládání na lokálním serveru, vratí bud TRANSLATEDSUC"překlad" nebo TRANSLATEDERR"slovo nenalezeno"
TRANSLATEPING"název" - po příchodu tohoto příkazu se odešle translatepong s názvem programu, slouží pro hledání compatibilních programů
TRANSLATESCAN"slovo" - Proskenuje všechny dostuponé IP v síti, při úspěšném pingu se IP zapíše do listu. Pro všechny IP v tomto listu se potom 
		       pokusí připojit client, pokaždé pomocí jiného portu v rozmezí školních portů. Při vytvářní clienta se rovnou pošle
		       translateping. Pokud se client úspěšně vytvoří a příjme od serveru TRANSLATEPONG, client se vloží do listu compatabilních
		       programů. Následuje samotný request na překlad. Všichni clienti v listu compatabilních
		       programů odešlou TRANSLATELOCL, pokud je response clienta TRANSLATEDSUC, odešle se TRANSLATEDSUC"překlad" zpět 
		       do putty. Pokud každý klient příjme TRANSLATEDERR, response lokálního serveru se nastavý
		       TRANSLATEDERR"slovo v síti nebylo nalezeno" a to se pošle do puuty. Toto se děje při každém příkazu TRANSLATESCAN"hledané slovo"


Možné odpovědi:
TRANSLATEDSUC"překlad" 			- odpověd příkazu TRANSLATELOCL"slovo", podkud server přeloží slovo, toto je jeho odpověd
TRANSLATEDERR"chyba.." 			- odpověd příkazu TRANSLATELOCL"slovo", podkud server nenajde slovo, toto je jeho odpověd
TRANSLATEPONG"jméno lokálního programu" - pokud příjde TRANSLATEPING"název vzáleného programu", vrátí se TRANSLATEPONG"jméno lokálního programu"
Invalid Command! 			- v případě že příjde nesmysl


Pro konfiguraci je tu config.conf:
czech 	- česká slova
english - anglická slova

!Poznámka! Překlady slov se musí psát nad sebe, aby např. třetí české slovo musí být překladem třetího anglického slova
	   příklad:
	   	kost,motor,podlaha,voda,sklo
		bone,engine,floor,water,glass

Timeout 		- čas, který je vyhrazen pro odpověd potenciálně compatibilního programu
AvaiableRangeOfPorts 	- stanovu rozmezí portů, které se skenují na nalezeném zařízení
NetMask a NetAddress 	- informace o síti ,ve které se program nachází a kterou taky skenuje, maskou se dají omezit addresy pro skenování
LocalServerPort 	- port lokálního serveru

Logování:
Soubor logs.txt obsahuje logy o:
Startování serveru, Nových klientech, příchozí a odchozí správy a koho se lokální server ptá na slovo.
