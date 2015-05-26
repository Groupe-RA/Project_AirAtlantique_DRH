using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.Database
{
    class FormationsDao : CommonDao
    {
        JobDao jobdao = new JobDao();

        /// <summary>
        /// Retourne toutes les formations
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Formation> GetAll()
        {
            return db.Formation;
        }

        /// <summary>
        /// Retourne une formation à partir de son ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Database.Formation GetById(int id)
        {
            return db.Formation.FirstOrDefault(x => x.FormationID == id);
        }

        /// <summary>
        /// Supprime la formation par son id (en la rendant inactive pour conserver les sessions archivées)
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            var del = db.Formation.Where(x => x.FormationID == id).First();
            del.Active = false;
            db.SaveChanges();
        }

        /// <summary>
        /// Enregistrer une formation
        /// </summary>
        /// <param name="aFormation"></param>
        public void Save(Class.Formation aFormation)
        {
            var nouveau = new Database.Formation()
            {
                FormationName = aFormation.Nom,
                FormationDescription = aFormation.Description,
                ValidityDuration = aFormation.DureeValidite,
                Job = jobdao.GetMultipleById(aFormation.RequiredForJobs),
                Active = true
            };

            db.Formation.Add(nouveau);
            db.SaveChanges();
        }
    }
}
