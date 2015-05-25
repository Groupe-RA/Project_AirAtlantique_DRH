using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.Database
{
    partial class CommonDao
    {
        protected AirAtlantiqueDRHEntities db
        { get { return SingletonDb.Instance.db; } }


        /// <summary>
        /// Commit des créations, modifications et suppressions dans la base de données
        /// </summary>
        public void Commit()
        {
            SingletonDb.Commit();
        }

    }
}
