import threading
import ipaddress
import Client
import subprocess
import logging
import Konfiguratoin
from threading import Lock

class TRANSLATESCAN:
    def __init__(self, word):
        logging.basicConfig(filename='logs.txt', level=logging.INFO)

        self.response = None
        self.word = word
        self.network = ipaddress.IPv4Network(str(Konfiguratoin.GetData("NetAddress")) + "/" + str(Konfiguratoin.GetData("NetMask")), strict=False)
        self.devices = []
        self.compatibleApp = []
        self.threadpool = []

        self.min = Konfiguratoin.GetData("AvaiableRangeOfPorts")[0]
        self.max = Konfiguratoin.GetData("AvaiableRangeOfPorts")[1]

    def ScanForDivices(self):
        """
        Pro každou ip se vytvoří vlákno, smustí se a čeká se na join, potom se pool vyčistí.
        Do vláken se posílá metoda pro ping s názvem CheckAddress
        :return:
        """
        for address in self.network.hosts():
            t1 = threading.Thread(target=self.CheckAddress, args=(address,))
            self.threadpool.append(t1)
        for thread in self.threadpool:
            thread.start()
        for thread in self.threadpool:
            thread.join()
        self.threadpool.clear()

    def CheckAddress(self, address):
        """
        Motoda která pinká na danou addressu, pokud je pink úspěšný, addressa se zapíše do kolekce devices,
        paremetr -n znamená kolik pingů poslat, -w kolik milisekund se má počkat na oedzvu, strout a strerr potlačí
        jakýkoliv výpis do konzole
        :param address: Address na kterou se bude pinkat
        :return:
        """
        with open('nul', 'w') as devnull:
            result = subprocess.run(['ping', '-n', '2', '-w', '500', str(address)], stdout=devnull, stderr=devnull)
            if result.returncode == 0:
                self.devices.append(address)

    def ScanPortsOfDevices(self):
        """
        Pro všechna nalezená zařízení se založí vlákno s metodou CheckPortsOfDevice, vlákno se spustí a počká se na ukončení
        :return:
        """
        lock = Lock()
        lock.aquire()
        for device in self.devices:
            t1 = threading.Thread(target=self.CheckPortsOfDevice, args=(device,))
            self.threadpool.append(t1)
        for thread in self.threadpool:
            thread.start()
        for thread in self.threadpool:
            thread.join()
        self.threadpool.clear()
        lock.release()

    def CheckPortsOfDevice(self, device):
        """
        Zkontroluje všechny porty v rozmezí u daného zařízení, pokud se klient úspěšně vytvořích na daném portu a zařízení
        a odezva je TranslatePong, klient se zapíše do kolekce compatibilních programů
        :param device:Ip addressa ke které se client snaří připoji
        :return:
        """
        for port in range(int(self.min), int(self.max)):
            client = Client.Client(device, port, self.word)
            try:
                if client.response[0:13] == "TRANSLATEPONG":        #pokud client na daném portu a adrese příjme TRANSLATEPONG
                    self.compatibleApp.append(client)               #zapíše se do listu compatibilích programů
            except Exception:
                pass


    def Send_Request_To_Each_Alpha(self):
        """
        Pro všechny klienty v kolekci klientů připojených ke komplatibilnímu programu, se pošle request na přeložení,
        pokud se response rovná translatedsuc, response klienta se zapíše do response skenu
        :return:
        """
        for client in self.compatibleApp:
            logging.info("Asking " + str(client.address) + " for word.")
            client.SendRequest()
            if client.response[0:13] == "TRANSLATEDSUC":
                self.response = client.response
        self.compatibleApp.clear()

    def __str__(self):
        return str(self.response)
