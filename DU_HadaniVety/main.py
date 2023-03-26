from Hadani import *
import configparser

if __name__ == "__main__":
    config = configparser.ConfigParser()
    config.read("config.ini")
    timeout = config.get("info", "timeout")
    max_delka_slova = config.get("info", "maxdelkaslova")
    veta = config.get("info", "veta")

    proces_pool = Pool(8)
    hadanka = MojeHadanka(veta, max_delka_slova)
    hra = MojeHra(hadanka)
    hra.hraj(proces_pool, timeout, max_delka_slova)
    print("Vysledna veta je: " + hra.seradit_vetu())