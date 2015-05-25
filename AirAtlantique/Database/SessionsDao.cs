using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.Database
{
    class SessionsDao : CommonDao
    {
        EmployesDao employedao = new EmployesDao();
        FormationsDao formationdao = new FormationsDao();

        /// <summary>
        /// Retourne toutes les sessions
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Session> GetAll()
        {
            return db.Session;
        }

        public void DeleteById(int id)
        {
            var del = db.Session.Where(x => x.SessionID == id).First();
            db.Session.Remove(del);
            db.SaveChanges();
        }

        public Session GetById(int id)
        {
           return db.Session.FirstOrDefault(x => x.SessionID == id);
        }

        /// <summary>
        /// Update une session par une nouvelle
        /// </summary>
        /// <param name="idToModify"></param>
        /// <param name="newSession"></param>
        public void Modify(int idToModify, Class.Session newSession)
        {
            var old = db.Session.First(x => x.SessionID == idToModify);
            old.DateStart = newSession.DateDebut;
            old.DateEnd = newSession.DateFin;
            old.Employee = employedao.GetMultipleById(newSession.EmployesParticipants);
            old.Formation = formationdao.GetById(newSession.FormationSession.Id);
            db.SaveChanges();
        }

        public void Save(Class.Session aSession) 
        {
            if (aSession.EmployesParticipants.Count() == 0)
                throw new Exception("Aucun employé fournie");

            if (aSession.DateDebut == null)
                throw new Exception("Aucune date de début fournie");

            if (aSession.FormationSession == null)
                throw new Exception("Aucune formation fournie");

            if (aSession.DateDebut >= aSession.DateFin)
                throw new Exception("La date de début doit être avant la date de fin");

            var nouveau = new Database.Session()
            {
               Employee =  employedao.GetMultipleById(aSession.EmployesParticipants),
               DateStart = aSession.DateDebut,
               DateEnd = aSession.DateFin,
               Formation =  formationdao.GetById(aSession.FormationSession.Id)

            };

            db.Session.Add(nouveau);
            db.SaveChanges();
        }
    }
}
