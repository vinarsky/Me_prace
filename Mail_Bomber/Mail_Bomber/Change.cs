using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail_Bomber
{
    public class Change
    {
        private string type;
        private string fileName;

        public string FileName { get { return fileName; } set { fileName = value; } }
        public string Type { get { return type; } set { type = value; } }

        public Change(string t, string fn)
        {
            Type = t;
            FileName = fn;
        }
        public Change() { }

        public override bool Equals(object obj)
        {
            return obj is Change c &&
                   FileName == c.FileName;
        }

        public override string ToString()
        {
            return "Typ: " + Type + ", název souboru: " + FileName;
        }
    }
}
