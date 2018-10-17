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

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Student>().Wait();
        }

        public Task<List<Student>> GetItemsAsync()
        {
            return database.Table<Student>().ToListAsync();
        }

        public Task<List<Student>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Student>("SELECT * FROM [Student] WHERE [Done] = 0");
        }

        public Task<Student> GetItemAsync(string id)
        {
            return database.Table<Student>().Where(i => i.Email == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Student item)
        {
            if (item.Email != null)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Student item)
        {
            return database.DeleteAsync(item);
        }
    }
}
