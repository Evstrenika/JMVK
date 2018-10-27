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
            CreateTables();
        }

        /// <summary>
        /// Creates tables in the database if they do not already exist
        /// </summary>
        private void CreateTables()
        {
            database.CreateTableAsync<Student>().Wait();
            database.CreateTableAsync<UserAvailability>().Wait();
            database.CreateTableAsync<Group>().Wait();
            database.CreateTableAsync<Member>().Wait();
            database.CreateTableAsync<Meeting>().Wait();
        }


        // Student Commands
        public Task<int> ReturnNumStudentsAsync()
        {
            return database.Table<Student>().CountAsync();
        }

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
        public Task<List<UserAvailability>> GetPotentialMembersAsync(string code, string day, string time)
        {
            return database.Table<UserAvailability>().Where(i => i.Day == day && i.Time == time && i.Activity == code).ToListAsync();
        }
        // something that will add a new time to the table
        public Task AddAvailabilityAsync(UserAvailability userAvailability)
        {
            return database.InsertAsync(userAvailability);
        }
        // remove the availability
        public Task RemoveAvailabilityAsync(UserAvailability userAvailability)
        {
            return database.DeleteAsync(userAvailability);
        }
        // check if the availability exists
        public Task<List<UserAvailability>> AvailabilityExistsAsync(string email, string day, string time)
        {
            return database.Table<UserAvailability>().Where(i => i.Email == email && i.Day == day && i.Time == time).ToListAsync();
        } 
        // alter the availability
        public Task AlterActivityAsync(UserAvailability newUserAvailability, UserAvailability oldUserAvailability)
        {
            database.DeleteAsync(oldUserAvailability);
            return database.InsertAsync(newUserAvailability);
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

        public Task<List<Member>> GetUndisplayedMembersAsync(Member member)
        {
            return database.Table<Member>().Where(i => i.GroupID == member.GroupID && i.Confirmed == true && i.Displayed == false && i.MemberEmail != App.AccountEmail).ToListAsync();
        }

        public Task<List<Member>> GetStudentMemberships(string email)
        {
            return database.Table<Member>().Where(i => i.MemberEmail == email && i.Confirmed == true).ToListAsync();
        }

        public Task<List<Member>> GetPendingStudentMemberships(string email)
        {
            return database.Table<Member>().Where(i => i.MemberEmail == email && i.Confirmed == false).ToListAsync();
        }

        public Task MemberDisplayed(Member member)
        {
            return database.ExecuteScalarAsync<bool>("UPDATE Member SET Displayed=? WHERE GroupID=? AND MemberEmail=?", true, member.GroupID, member.MemberEmail);
        }

        public Task AcceptMembership(Member member)
        {
            return database.ExecuteScalarAsync<bool>("UPDATE Member SET Confirmed=? WHERE GroupID=? AND MemberEmail=?", true, member.GroupID, member.MemberEmail);
        }

        public async Task<Student> GetTeamFounder(Group group)
        {
            Member founder =  await database.Table<Member>().Where(i => i.GroupID == group.ID && i.Displayed == true).FirstOrDefaultAsync();
            return await database.Table<Student>().Where(i => i.Email == founder.MemberEmail).FirstOrDefaultAsync();
        }

        public Task<List<Member>> GetTeamMembers(Group group)
        {
            return database.Table<Member>().Where(i => i.GroupID == group.ID && i.Confirmed == true).ToListAsync();
        }

        public Task<Member> GetMember(string email, int groupID)
        {
            return database.Table<Member>().Where(i => i.GroupID == groupID && i.MemberEmail == email).FirstOrDefaultAsync();
        }


        // Group Commands
        public Task AddGroupAsync(Group group)
        {
            return database.InsertAsync(group);
        }

        public Task<Group> GetGroupAsync(int groupID)
        {
            return database.Table<Group>().Where(i => i.ID == groupID).FirstOrDefaultAsync();
        }


        // Meeting Commands
        public Task AddMeetingAsync(Meeting meeting)
        {
            return database.InsertAsync(meeting);
        }

    }
}
