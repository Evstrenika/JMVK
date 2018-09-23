using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collaboro.Models;
using SQLite;

namespace Collaboro
{
    public class DBService : IDataService
    {
        readonly SQLiteAsyncConnection database;

        public DBService(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Student>().Wait();
            database.CreateTableAsync<Availability>().Wait();
        }


        // Student Commands
        public Task<Student> GetStudentAsync(string email)
        {
            return database.Table<Student>().Where(i => i.Email == email).FirstOrDefaultAsync();
        }

        public Task<List<Student>> GetStudentsAsync()
        {
            return database.Table<Student>().ToListAsync();
        }

        public Task SaveStudentAsync(Student student)
        {
            return database.InsertAsync(student);
        }

        public Task<Student> CheckStudentAsync(string email, string password)
        {
            return database.Table<Student>().Where(i => i.Email == email && i.Password == password).FirstOrDefaultAsync();
        }


        // Availability Commands
        public Task<List<Availability>> GetPotentialMembersAsync(string code, string day, string time)
        {
            return database.Table<Availability>().Where(i => i.Day == day && i.Time == time && i.Activity == code).ToListAsync();
        }


        // Member Commands
        public Task AddMemberAsync(Member member)
        {
            return database.InsertAsync(member);
        }

        public Task RemoveMemberAsync(Member member)
        {
            return database.DeleteAsync(member);
        }


        // Group Commands
        public Task AddGroupAsync(Group group)
        {
            return database.InsertAsync(group);
        }


        // COMMANDS WE MAY NEED TO MODIFY AND USE LATER
        /*
        public Task DeleteTodoItemAsync(string id)
        {
            return database.ExecuteScalarAsync<int>("DELETE FROM TodoItem WHERE ID=?", id); // using SQL statements

            // Alternative using Linq, but which requires the entire item:
            //return database.DeleteAsync(item);
        }

        public Task SaveTodoItemAsync(TodoItem item)
        {
            if (item.Id != null)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                item.Id = DateTime.Now.GetHashCode().ToString();
                return database.InsertAsync(item);

            }
        }*/

    }
}
