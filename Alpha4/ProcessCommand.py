from Commands import TRANSLATEPING
from Commands import TRANSLATELOCL
from Commands import TRANSLATESCAN

class Command:
    def __init__(self, command):
        """
        Rozdělení příchozího příkazu na 2 části. Samotný příkaz a slovo pro překlad
        :param command: Příkaz od klienta
        """
        try:
            self.command = command[0:13]
            self.word = command.split('"')[1]
            if self.word == None:
                raise Exception
        except Exception:
            pass

    def RunCommand(self):
        """
        Zpracování příchozích příkazů a vracení nějaké odezvy.
        Každý if porovnává příkaz se jménem třídy v Commands package. Pokud nastane schoda, vytvoří se instance tohoto
        příkazu. Potom se volají metody, které vytvoří nějakou odezvu, ta se potom vrátí.
        :return:
        """
        if str('Commands.' + self.command) == str(TRANSLATEPING.__name__):
            ping = TRANSLATEPING.TRANSLATEPING()
            return 'TRANSLATEPONG"' + ping.name + '"'   #Vrácení pongu se jménem

        elif str('Commands.' + self.command) == str(TRANSLATELOCL.__name__):
            locl = TRANSLATELOCL.TRANSLATELOCL()
            return locl.Translate(self.word)            #Přeložení slova a vrácení přeloženého slova

        elif str('Commands.' + self.command) == str(TRANSLATESCAN.__name__):
            scan = TRANSLATESCAN.TRANSLATESCAN(self.word)
            scan.ScanForDivices()                       #Nalezení všech zařízení v síti
            scan.ScanPortsOfDevices()                   #Sken portů těchto zařízeních aby se našel compatibilní program
            scan.Send_Request_To_Each_Alpha()           #Odeslání TRANSLATELOCL na všechny compatibliní pregramy
            if scan.response == None:                   #Pokud se po prohledání všech compatibilních programů nenajde žádný s hledaným slovem, response se nastavý na následujcí string
                scan.response = 'TRANSLATEDERR"Slovo v síti nebylo nalezeno"'
            return scan.response

        else:
            return 'Invalid command!'

