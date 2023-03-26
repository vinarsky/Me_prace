import Konfiguratoin

class Translation:
    def __init__(self):
        self.czech_words = []
        self.engilsh_words = []
        self.FillInWords()

    def FillInWords(self):
        """
        Naplnění kolekcí slov, slovy z configu
        :return:
        """
        self.czech_words = Konfiguratoin.GetData("czech")
        self.engilsh_words = Konfiguratoin.GetData("english")

    def Translate(self, en_word):
        """
        Přeloží anglické slovo do češtiny
        :param en_word:
        :return:
        """
        try:
            index = self.engilsh_words.index(en_word)
        except ValueError:
            return None
        return self.czech_words[index]
