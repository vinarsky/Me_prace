import Konfiguratoin
import socket

class Client:
    def __init__(self, address, port, word):
        """
        Při každém založení nového klienta se rovnou na daný server socket pošle Translateping, jestli tam vůbec něco je
        něco s čím se dá komunikovat. Pokud server odpoví, response se zkontroluje ve skenu. Při jakékoliv vyjímce se
        socket zavře.
        :param address:
        :param port:
        :param word:
        """
        try:
            self.word = word
            self.address = (address, port)
            self.client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
            self.client_socket.settimeout(float(Konfiguratoin.GetData("Timeout")))
            self.client_socket.connect((str(address), port))
            self.client_socket.send(b'TRANSLATEPING"Vinarsky_Translater"')
            self.response = self.client_socket.recv(1024).decode()
        except socket.timeout as e:
            self.client_socket.close()
        except ConnectionRefusedError as e:
            self.client_socket.close()
        except WindowsError as e:
            self.client_socket.close()


    def SendRequest(self):
        """
        Pošle request pro překlad na server socket, o kterém jasně vím, že na tam je compatibilní program, který něco
        úrčitě odpoví, počká na response.
        :return:
        """
        self.client_socket.send(f'TRANSLATELOCL"{self.word}"'.encode())
        self.response = self.client_socket.recv(1024).decode()

    def __str__(self):
        return self.address
