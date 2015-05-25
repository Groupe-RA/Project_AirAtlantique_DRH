using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.Class
{
    public class Employes
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

        private string prenom;

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        private string poste;

        public string Poste
        {
            get { return poste; }
            set { poste = value; }
        }

        private IEnumerable<string> formationsAcquises;

        public IEnumerable<string> FormationsAcquises
        {
            get { return formationsAcquises; }
            set { formationsAcquises = value; }
        }

        private IEnumerable<DateTime> formationsDates;

        public IEnumerable<DateTime> FormationsDates
        {
            get { return formationsDates; }
            set { formationsDates = value; }
        }

        public override string ToString()
        {
            return Nom + " " + Prenom;
        }

    }
}
