using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.Class
{
    public class Session
    {
        private IEnumerable<int> employesParticipants;

        public IEnumerable<int> EmployesParticipants
        {
            get { return employesParticipants; }
            set { employesParticipants = value; }
        }

        private DateTime dateDebut;

        public DateTime DateDebut
        {
            get { return dateDebut; }
            set { dateDebut = value; }
        }

        private DateTime dateFin;

        public DateTime DateFin
        {
            get { return dateFin; }
            set { dateFin = value; }
        }

        private FormationView formationSession;

        public FormationView FormationSession
        {
            get { return formationSession; }
            set { formationSession = value; }
        }      
    }

    public class SessionView
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private IEnumerable<string> employesParticipants;

        public IEnumerable<string> EmployesParticipants
        {
            get { return employesParticipants; }
            set { employesParticipants = value; }
        }

        private DateTime dateDebut;

        public DateTime DateDebut
        {
            get { return dateDebut; }
            set { dateDebut = value; }
        }

        private DateTime dateFin;

        public DateTime DateFin
        {
            get { return dateFin; }
            set { dateFin = value; }
        }

        private string formationSession;

        public string FormationSession
        {
            get { return formationSession; }
            set { formationSession = value; }
        }

        public string Status
        {
            get {
                if (dateFin < DateTime.Now)
                    return "Terminée";
                if (dateDebut > DateTime.Now)
                    return "En attente";
                else
                    return "En cours";
            }
        }
        

        public override string ToString()
        {
            return formationSession;
        }
    }
}
