using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeProject.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace CodeProject.Data.EntityFramework
{
   

    public class EntityFrameworkService : IDataRepository, IDisposable
    {

        CodeProjectDatabase _connection;

        /// <summary>
        /// Database Context
        /// </summary>
        public CodeProjectDatabase dbConnection
        {
            get { return _connection; }
        }

        /// <summary>
        /// Commit Transaction
        /// </summary>
        /// <param name="closeSession"></param>
        public void CommitTransaction(Boolean closeSession)
        {
            dbConnection.SaveChanges();
        }

        /// <summary>
        /// Rollback Transaction
        /// </summary>
        /// <param name="closeSession"></param>
        public void RollbackTransaction(Boolean closeSession)
        {

        }

        public void Save(object entity) { }
        public void CreateSession() 
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CodeProjectDatabase, Configuration>()); 

            _connection = new CodeProjectDatabase(); 
        }
        public void BeginTransaction() { }

        public void CloseSession() { }

        /// <summary>
        /// Dispose of connection
        /// </summary>
        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
        }
    }
}
