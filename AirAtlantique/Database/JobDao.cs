using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.Database
{
    class JobDao : CommonDao
    {
        public IEnumerable<Job> GetAll()
        {
            return db.Job;
        }

        public ICollection<Job> GetMultipleById(IEnumerable<int> ids)
        {
            return db.Job.Where(x => ids.Contains(x.JobID)).ToList();
        }
    }
}
