using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirAtlantique.Class;
using AirAtlantique.Database;

namespace AirAtlantique.ViewModel
{
    public class EmployesVM
    {
        public IEnumerable<Employes> theEmployes { get; set; }      

        public EmployesVM()
        {
            EmployesDao employesdao = new EmployesDao();

            theEmployes = from p in employesdao.GetAll()
                       select new Class.Employes() {
                           Id = p.EmployeeID,
                           Nom = p.Name,
                           Prenom = p.FirstName,
                           Poste = p.Job.JobName,
                           FormationsAcquises = p.AcquiredFormation.Select(x => x.Formation.FormationName),
                           FormationsDates = p.AcquiredFormation.Select(x => x.AcquiredDate)
                       };
        }
    }
}
