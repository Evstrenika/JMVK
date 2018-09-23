using Collaboro.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collaboro
{
	public interface IDataService
	{
        // Students
        Task<Student> GetStudentAsync(string email);

        Task<List<Student>> GetStudentsAsync();

        Task SaveStudentAsync(Student student);

        Task<Student> CheckStudentAsync(string email, string password);


        // Availbility
        Task<List<Availability>> GetPotentialMembersAsync(string code, string day, string time);


        // Member
        Task AddMemberAsync(Member member);

        Task RemoveMemberAsync(Member member);


        // Group
        Task AddGroupAsync(Group group);

        //Task<int> GetCurrentNumberMembers(int ID);


    }
}
