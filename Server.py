import socket
import threading
import ProcessCommand
import logging
import Konfiguratoin

class Server:
    def __init__(self):
        Konfiguratoin.OpenFile()

        self.address = str(Konfiguratoin.GetData("LocalAddress"))
        self.port = int(Konfiguratoin.GetData("LocalServerPort"))
        logging.basicConfig(filename='logs.txt', level=logging.INFO)

    def ServerStart(self):
        """
        Nastartuje server a naslouchání na přísloušném protu. Spoustí Metodu pro příjímání nových klinetů
        :return:
        """
        server_inet_address = (self.address, self.port)
        self.server_socket = socket.socket()
        self.server_socket.bind(server_inet_address)
        self.server_socket.listen()
        logging.info("Server started on " + str(self.server_socket))
        self.NewClient(self.server_socket)

    def NewClient(self, server_socket):
        """
        Nekonečný loop, každé kolo se čeká na nového klienta. Klinetovi se vytvoří vlákno s metodou která čeká na příkazy
        :param server_socket:Socket na který se připojují klienti
        :return:
        """
        while True:
            (clientsocket, address) = server_socket.accept()
            t1 = threading.Thread(target=self.RunCommands, args=(clientsocket,))
            t1.start()
            logging.info("New client on" + str(address))

    def RunCommands(self, clientsocket):
        """
        Motoda čeká na nový příkaz od klienta, když něco příjde a není to enter, tak se to
        pošle na zpracování ve třídě ProcessCommand.
        V této třídě, metoda RunCommand vrátí nějako odezvu na základě vstupního příkazu a to pošle zpět klientovi
        :param clientsocket: Klinet, kterému se posílá odezva na jeho příkaz
        :return: V případě že se motoda send pokusí poslat zprávu na socket, který už neexistuje, vyhodí se vyjímka,
        nastane return, metoda skončí a vlákno se smaže
        """
        while True:
            try:
                command_as_bytes = clientsocket.recv(1024)                            #čekání na příjem zpávy z putty
                if command_as_bytes.decode() == "exit":                               #vypnuti v případě že příjde exit command
                    self.server_socket.close()
                    clientsocket.close()
                if command_as_bytes != b'\r\n':                                       #vyfiltrování entru z puttyny
                    logging.info("Incoming message: " + command_as_bytes.decode())
                    command = ProcessCommand.Command(command_as_bytes.decode())       #vytvoření comandu
                    response = command.RunCommand()                                   #zpracování commandu a vrácení hodnoty
                    logging.info("Outgoing message: " + response)
                    clientsocket.send(response.encode())                              #odeslání hodnoty zpět do putty
            except WindowsError:
                return
