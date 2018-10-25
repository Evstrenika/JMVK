using Collaboro.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collaboro
{
	public class DBManager
	{
		IDataService DbService;
        public List<Student> CurrentItems { get; set; }

		public DBManager (IDataService service)
		{
            DbService = service;
		}

        // Students
        public Task<int> ReturnNumStudentsAsync()
        {
            return DbService.ReturnNumStudentsAsync();
        }

		public Task<List<Student>> ReturnStudentsAsync ()
		{
			return DbService.GetStudentsAsync ();	
		}

        public Task<Student> ReturnStudentAsync(string email)
        {
            return DbService.GetStudentAsync(email);
        }

        public Task RecordStudentAsync(Student student)
        {
            return DbService.SaveStudentAsync(student);
        }

        public Task<Student> CheckCredentialsStudentAsync(string email, string password)
        {
            return DbService.CheckStudentAsync(email, password);
        }


        // Availability      
        public Task<List<UserAvailability>> GetPotentialMembersAsync(string code, string day, string time)
        {
            return DbService.GetPotentialMembersAsync(code, day, time);
        } 
        // something that will add a new time to the table
        public Task AddAvailabilityAsync(UserAvailability userAvailability)
        {
            return DbService.AddAvailabilityAsync(userAvailability);
        }
        // searches for if the availability exists
        public Task<List<UserAvailability>> AvailabilityExists(string email, string day, string time)
        {
            return DbService.AvailabilityExistsAsync(email, day, time);
        }
        // alters the already existing availability slot
        public Task AlterActivityAsync(UserAvailability newUserAvailability, UserAvailability oldUserAvailability)
        {
            return DbService.AlterActivityAsync(newUserAvailability, oldUserAvailability);
        }
        // delete the availability
        public Task RemoveAvailabilityAsync(UserAvailability userAvailability)
        {
            return DbService.RemoveAvailabilityAsync(userAvailability);
        }


        // Member Commands
        public Task AddMemberAsync(Member member)
        {
            return DbService.AddMemberAsync(member);
        }

        public Task RemoveMemberAsync(Member member)
        {
            return DbService.RemoveMemberAsync(member);
        }

        public Task<List<Member>> GetUndisplayedMembersAsync(Member member)
        {
            return DbService.GetUndisplayedMembersAsync(member);
        }

        public Task<List<Member>> GetStudentMemberships(string email)
        {
            return DbService.GetStudentMemberships(email);
        }

        public Task<List<Member>> GetPendingStudentMemberships(string email)
        {
            return DbService.GetPendingStudentMemberships(email);
        }

        public Task MemberDisplayed(Member member)
        {
            return DbService.MemberDisplayed(member);
        }

        public Task AcceptMembership(Member member)
        {
            return DbService.AcceptMembership(member);
        }

        public Task<Student> GetTeamFounder(Group group)
        {
            return DbService.GetTeamFounder(group);
        }

        public Task<List<Member>> GetTeamMembers(Group group)
        {
            return DbService.GetTeamMembers(group);
        }


        // Group Commands
        public Task AddGroupAsync(Group group)
        {
            return DbService.AddGroupAsync(group);
        }

        public Task<Group> GetGroupAsync(int groupID)
        {
            return DbService.GetGroupAsync(groupID);
        }


        // Meeting Commands
        public Task AddMeetingAsync(Meeting meeting)
        {
            return DbService.AddMeetingAsync(meeting);
        }
    }
}
