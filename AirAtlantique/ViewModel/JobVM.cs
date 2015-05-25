using AirAtlantique.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.ViewModel
{
    public class JobVM
    {
        
        public IEnumerable<Class.Jobs> theJobs { get; set; } 

        public JobVM()
        {
            JobDao jobsdao = new JobDao();

            theJobs = from p in jobsdao.GetAll()
                          select new Class.Jobs
                          {
                              Id = p.JobID,
                              Nom = p.JobName
                          };
        }
         
    }
}
