import json
import os

def OpenFile():
    """
    metoda z konfuguračního souboru vytáhne všechny data, ty se potom zpracovávaj v metodě getdata
    :return vráti promenou conf_text
    """
    conf_text = ""
    try:
        conf = open(os.path.join(os.path.dirname(__file__), 'config.conf'), "r")
    except:
        raise Exception("Chyba pri otervirani konfiguracniho souboru")
    else:
        for line in conf:
            conf_text += line
        conf.close()
        return conf_text

def GetData(key):
    """
    :param key: klíč pro hodnotu
    :return: vrátí hodnotu pro příslušným klíčem
    """
    try:
        data = json.loads(OpenFile())
        return data[str(key)]
    except:
        raise Exception("Chyba pri getovani dat")