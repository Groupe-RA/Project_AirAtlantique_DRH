using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.Database
{
    class EmployesDao : CommonDao
    {
        /// <summary>
        /// Retourne tous les employes
        /// </summary>
        /// <returns>liste d'employes</returns>
        public IEnumerable<Database.Employee> GetAll()
        {
            return db.Employee;
        }

        /// <summary>
        /// Supprime un employe
        /// </summary>
        /// <param name="id">Identifiant employé</param>
        public void DeleteByID(int id)
        {
            var del = db.Employee.Where(x => x.EmployeeID == id).First();
            db.Employee.Remove(del);
            db.SaveChanges();
        }

        /// <summary>
        /// Retourne l'employé par l'id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetByID(int id)
        {
            return db.Employee.FirstOrDefault(x => x.EmployeeID == id);
        }

        public ICollection<Employee> GetMultipleById(IEnumerable<int> ids)
        {
            return db.Employee.Where(x => ids.Contains(x.EmployeeID)).ToList();
        }
    }
}
