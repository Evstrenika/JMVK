using Collaboro.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collaboro
{
	public interface IDataService
	{
        // Students
        Task<int> ReturnNumStudentsAsync();

        Task<Student> GetStudentAsync(string email);

        Task<List<Student>> GetStudentsAsync();

        Task SaveStudentAsync(Student student);

        Task<Student> CheckStudentAsync(string email, string password);


        // Availbility
        Task<List<UserAvailability>> GetPotentialMembersAsync(string code, string day, string time);

        Task AddAvailabilityAsync(UserAvailability userAvailability);

        Task<List<UserAvailability>> AvailabilityExists(string email, string day, string time);

        // Member
        Task AddMemberAsync(Member member);

        Task RemoveMemberAsync(Member member);

        Task<List<Member>> GetUndisplayedMembersAsync(Member member);

        Task<List<Member>> GetStudentMemberships(string email);

        Task<List<Member>> GetPendingStudentMemberships(string email);

        Task MemberDisplayed(Member member);

        Task AcceptMembership(Member member);

        Task<Student> GetTeamFounder(Group group);


        // Group
        Task AddGroupAsync(Group group);

        Task<Group> GetGroupAsync(int groupID);

        //Task<int> GetCurrentNumberMembers(int ID);


    }
}
