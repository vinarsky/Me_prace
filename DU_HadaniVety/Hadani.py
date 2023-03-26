import time
from multiprocessing import *
import string
import random
import re
from ctypes import c_char_p

from InterFaces_UnitTests import Hadanka

class MocDlouheSlovoException(Exception):
    pass

class NeplatnyZnakException(Exception):
    pass

class MojeHadanka(Hadanka.Hadanka):
    def __init__(self, veta: str, max_delka_slova: int):
        """
        zalozeni noveho objetu, kontroluje se zda veta neporusuje nektere z pravidel, neplatny znak a moc dlouhe slovo
        :param veta: veta ktera ma byt uhadnuta
        :param max_delka_slova: maximalni delka slova
        """
        self.veta = veta
        self.slova = veta.split(" ")
        self.novy_nalez = Value('i', 0)
        self.ukonci_proces = Value('i', 0)
        if not re.match("^[a-z ]+$",veta):
            raise NeplatnyZnakException("Veta muze obsahovat jen mala pismena anglicke abecedy a mezery!")
        for i in range(self.pocet_slov()):
            if len(self.slova[i]) > int(max_delka_slova):
                raise MocDlouheSlovoException("Pismeno na " + str(i+1) + ". miste je prilis dlouhe!")

    def pocet_slov(self):
        """
        :return: vrati pocet slovi ve vete
        """
        return len(self.slova)

    def hadej_slovo(self, veta_dict, abeceda, max_delka_slova):
        """
        Kontroluje zda vygenerovane slovo je nekde v hadane vete. Pokud tam je, tak se zkontroluje jestli slovo uz bylo nalezeno,
        pokud ano, tak se vlozi do dictionary a v metode hadej_vetu se otestuje zda uz to neni vse, v pripade ze to je vse, ukonci_proces se nastavi na 1
        :param veta_dict: dictionary kam se zapisuji nalezena slova, key je misto slova ve veta, hodnota je zamotne slovo
        :param abeceda: kolekce malych pismen
        :param max_delka_slova: maximalni delka slova
        :return: otestuje zda se self.ukonci_proces rovna 1, v tom pripade metoda skonci
        """
        while True:
            slovo = ""
            for k in self.generator_slova(abeceda, max_delka_slova):
                slovo += k
            for j in range(self.pocet_slov()):
                if self.slova[j] == slovo:
                    if j not in veta_dict:
                        veta_dict[j] = slovo
                        self.novy_nalez.value = j
                        self.hadej_vetu(veta_dict)
            if self.ukonci_proces.value == 1:
                return

    def hadej_vetu(self, veta_dict):
        """
        Funkce kontroluje zda se hadana veta schoduje s uhadnutymi zerazenymi slovy, pokud ano, ukonci_proces se nastavi na 1
        :param veta_dict: dictionary kam se zapisuji nalezena slova, key je misto slova ve veta, hodnota je zamotne slovo
        :return: vrati true pokud se veti schoduji
        """
        result = ""
        for i in sorted(veta_dict.keys()):
            result = result + veta_dict[i] + " "
        if self.veta + " " == result:
            self.ukonci_proces.value = 1

    def generator_slova(self, abeceda, max_delka_slova):
        """
        Generator, ktery vrati slovo o nahodne delce s naahodnymi pismeny, negeneruje 2 nebo vice stejnych pisman za sebou
        :param abeceda: abeceda malych pismen
        :param max_delka_slova: maximalni delka slova
        :return: nahodna pismena
        """
        predchozi_pismeno = ""
        for i in range(random.randint(1, int(max_delka_slova))):
            pismeno = abeceda[random.randint(0, 25)]
            if predchozi_pismeno != pismeno:
                yield pismeno
                predchozi_pismeno = pismeno


class Pool:
    def __init__(self, pocet_procesu):
        self.pool = []
        self.pocet_procesu = pocet_procesu
    def add_proces(self, p):
        """
        pridani noveho procesu do poolu
        :param p: proces k pridani
        """
        self.pool.append(p)
    def start_proces(self):
        for p in range(len(self.pool)):
            self.pool[p].start()
    def ukonci_proces(self):
        for p in range(len(self.pool)):
            self.pool[p].join()

class MojeHra(Hadanka.Hra):
    def __init__(self, hadanka:MojeHadanka):
        self.abeceda = string.ascii_lowercase
        self.veta_dict = Manager().dict()
        self.hadanka = hadanka
    def hraj(self, proces_pool, timeout, max_delka_slova):
        """
        spusti procesy pro hadani vety, pocka na join
        :param proces_pool: pool prcesu ktere se pouzijou na uhadnuti vety
        :param timeout: maximalni cas hadani
        :param max_delka_slova: maximalni delka slova
        :param hadanka: object typu hadanka s vetou, ktera se bude hadat
        """
        for i in range(proces_pool.pocet_procesu):
            p = Process(target=self.hadanka.hadej_slovo, args=(self.veta_dict, self.abeceda, max_delka_slova))
            proces_pool.add_proces(p)
        proces_pool.start_proces()
        self.prubezni_stav()
        proces_pool.ukonci_proces()

    def seradit_vetu(self):
        """
        serati slova v dictionary podle klice
        :return: vrati serazene slova ve vete
        """
        result = ""
        for i in sorted(self.veta_dict):
            result = result + self.veta_dict[i] + " "
        return result

    def prubezni_stav(self):
        """
        kazdou sekundu vypise slovo v novy_nalez, pokud uz ale vypsano bylo, nevypise to, vypise jen nova slova
        pokud se delka dictionary rovna poctu slov, metoda skoci
        :return:
        """
        loop = True
        index = None
        while loop:
            time.sleep(1)
            for i in self.veta_dict.keys():
                if i == self.hadanka.novy_nalez.value and index != i:
                    index = i
                    print(self.veta_dict[i])
            if len(self.veta_dict.keys()) == self.hadanka.pocet_slov():
                loop = False