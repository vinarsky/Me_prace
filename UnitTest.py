import unittest
import ProcessCommand
import Translater

class MyTestCase(unittest.TestCase):
    def test_prescess_translatelocl_suc(self):
        command = ProcessCommand.Command('TRANSLATELOCL"water"')
        self.assertEqual(command.RunCommand(), 'TRANSLATEDSUC"voda"')

    def test_prescess_translatelocl_err(self):
        command = ProcessCommand.Command('TRANSLATELOCL"nespravne_slovo"')
        self.assertEqual(command.RunCommand(), 'TRANSLATEDERR"Tohle slovo nemam!"')

    def test_prescess_translateping(self):
        command = ProcessCommand.Command('TRANSLATEPING"Vzdálený program"')
        self.assertEqual(command.RunCommand(), 'TRANSLATEPONG"Vinarsky_Translater"')

    def test_invalid_command(self):
        command = ProcessCommand.Command('nespravnycommand')
        self.assertEqual(command.RunCommand(), 'Invalid command!')

    def test_translation(self):
        translate = Translater.Translation()
        self.assertEqual(translate.Translate("floor"), 'podlaha')

if __name__ == '__main__':
    unittest.main()
