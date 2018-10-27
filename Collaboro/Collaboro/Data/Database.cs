using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collaboro.Models;
using SQLite;

namespace Collaboro.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        /// <summary>
        /// Creates a connection with a database at a given file location
        /// </summary>
        /// <param name="dbPath">File location of Database</param>
        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
        }
    }
}
