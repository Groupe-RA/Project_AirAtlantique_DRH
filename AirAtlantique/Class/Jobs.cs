using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.Class
{
    public class Jobs
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nom;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public override string ToString()
        {
            return Nom;
        }
        
    }
}
