using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.Class
{
    public class Formation
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

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int dureeValidite;

        public int DureeValidite
        {
            get { return dureeValidite; }
            set { dureeValidite = value; }
        }

        private IEnumerable<int> requriedForJobs;

        public IEnumerable<int> RequiredForJobs
        {
            get { return requriedForJobs; }
            set { requriedForJobs = value; }
        }
        

        public override string ToString()
        {
            return Nom;
        }

    }

    public class FormationView
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

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int dureeValidite;

        public int DureeValidite
        {
            get { return dureeValidite; }
            set { dureeValidite = value; }
        }

        private IEnumerable<string> requriedForJobs;

        public IEnumerable<string> RequiredForJobs
        {
            get { return requriedForJobs; }
            set { requriedForJobs = value; }
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}
