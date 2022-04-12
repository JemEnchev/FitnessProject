namespace FitnessProject.Core.Contracts
{
    using FitnessProject.Core.Models;

    public interface IUserService
    {
        Task<IEnumerable<UserList_VM>> GetUsersAsync();
    }
}
