//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirAtlantique.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public Employee()
        {
            this.AcquiredFormation = new HashSet<AcquiredFormation>();
            this.Session = new HashSet<Session>();
        }
    
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public int JobID { get; set; }
    
        public virtual ICollection<AcquiredFormation> AcquiredFormation { get; set; }
        public virtual Job Job { get; set; }
        public virtual ICollection<Session> Session { get; set; }
    }
}
