using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirAtlantique.Class;
using AirAtlantique.Database;

namespace AirAtlantique.ViewModel
{
    public class SessionsVM
    {
        public IEnumerable<Class.SessionView> theSessions { get; set; } 

        public SessionsVM()
        {
            SessionsDao sessiondao = new SessionsDao();

            theSessions = from p in sessiondao.GetAll()
                          select new Class.SessionView
                          {
                              Id = p.SessionID,
                              DateDebut = p.DateStart,
                              DateFin = p.DateEnd,
                              FormationSession = p.Formation.FormationName,
                              EmployesParticipants = p.Employee.Select(x => String.Concat( x.Name, ' ', x.FirstName )),
                          };
        }
    }
}
