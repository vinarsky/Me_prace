import Translater

class TRANSLATELOCL:
    def __init__(self):
        self.translation = Translater.Translation()

    def Translate(self, en_word):
        """
        Přeložení slova
        :param en_word: anglické slovo
        :return: české slovo
        """
        cze_word = self.translation.Translate(en_word)
        if cze_word == None:
            return 'TRANSLATEDERR"Tohle slovo nemam!"'
        return 'TRANSLATEDSUC"' + cze_word + '"'
