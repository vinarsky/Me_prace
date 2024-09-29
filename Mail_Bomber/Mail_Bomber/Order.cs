using System;
using System.Collections.Generic;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace Mail_Bomber
{
    public class Order
    {
        private string reference;
        private string pdffile;

        private string ship;
        private string port;
        private string loadingAddress;
        private DateTime DeliveryTime;

        public List<Change> ChangesAlreadySent = new List<Change>();

        public string Reference
        {
            get { return reference; }

        }
        public string PdfFile
        {
            get { return pdffile; }
            set { pdffile = value; }
        }
        public void AddToChangesAlreadySent(Change c)
        {
            if (!IsInChangesAlreadySent(c))
            {
                ChangesAlreadySent.Add(c);
            }
        }
        public bool IsInChangesAlreadySent(Change c)
        {
            for (int i = 0; i < ChangesAlreadySent.Count; i++)
            {
                if (ChangesAlreadySent[i].Equals(c))
                    return true;
            }
            return false;
        }

        string GetReferenceFromFile()
        {
            using (PdfReader pdfReader = new PdfReader("../../Mails/Objednavky/" + PdfFile))
            {
                string PDF_in_text = PdfTextExtractor.GetTextFromPage(pdfReader, 1);
                string phrase = ReadAppConf.ReferencePlacement(PDF_in_text.Split(' ')[0]);

                string StarterPhrase = phrase.Split(',')[0].Trim();
                string EndPhrase = phrase.Split(',')[1].Trim();

                int startPhraseIndex = PDF_in_text.IndexOf(StarterPhrase);
                int endPhraseIndex = PDF_in_text.IndexOf(EndPhrase);

                int startIndex = startPhraseIndex + StarterPhrase.Length;
                int length = endPhraseIndex - startIndex;

                return PDF_in_text.Substring(startIndex, length).Trim();
            }
        }

        public Order() { }
        public Order(string pdffilename)
        {
            pdffile = pdffilename;
            reference = GetReferenceFromFile();
        }

        public override string ToString() { return "OrderRef: " + Reference + ", Order name: " + PdfFile; }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   pdffile == order.pdffile;
        }
    }
}
