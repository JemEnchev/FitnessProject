namespace FitnessProject.Core.Models
{
    public class CreateUser_VM
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { set; get; }
    }
}
