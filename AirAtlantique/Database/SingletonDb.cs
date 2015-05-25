using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.Database
{
    public sealed class SingletonDb
    {
        private static SingletonDb instance = null;
        private static readonly object padlock = new object();

        private SingletonDb()
        {
        }

        public static SingletonDb Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SingletonDb();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// Accès à la base de données
        /// </summary>
        public AirAtlantiqueDRHEntities db = new AirAtlantiqueDRHEntities();

        /// <summary>
        /// Commit des créations, modifications et suppressions dans la base de données
        /// </summary>
        public static void Commit()
        {
            Instance.db.SaveChanges();
        }
    }
}
