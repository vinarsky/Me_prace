import unittest
from Hadani import *


class MyTestCase(unittest.TestCase):
    def test_moc_dlouhe_slovo(self):
        """
        testuje zda cod vyhodi vyjimku v privade ze nektere ze slov je moc dlouhe
        :return:
        """
        with self.assertRaises(MocDlouheSlovoException):
            H1 = MojeHadanka("ahooooj", 5)
    def test_neplatny_znak(self):
        """
        testuje zda cod vyhodi vyjimku v pripade ze veta obsahuje neplatny znak
        :return:
        """
        with self.assertRaises(NeplatnyZnakException):
            H1 = MojeHadanka("$$#%č", 5)
    def test_pocet_slov(self):
        """
        testuje zda metoda pocet_slov() vrati spravne cislo
        :return:
        """
        H1 = MojeHadanka("ahoj jak se mas", 5)
        self.assertEqual(4, H1.pocet_slov())



if __name__ == '__main__':
    unittest.main()
