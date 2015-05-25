using AirAtlantique.Class;
using AirAtlantique.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.ViewModel
{
    public class FormationsVM
    {
        public IEnumerable<FormationView> theFormations { get; set; } 

        public FormationsVM()
        {
            FormationsDao formationsdao = new FormationsDao();

            theFormations = from p in formationsdao.GetAll()
                          select new Class.FormationView
                          {
                              Id = p.FormationID,
                              Nom = p.FormationName,
                              Description = p.FormationDescription,
                              DureeValidite = p.ValidityDuration,
                              RequiredForJobs = p.Job.Select(x => x.JobName)
                          };
        }
    }
}
