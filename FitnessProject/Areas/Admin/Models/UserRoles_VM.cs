namespace FitnessProject.Areas.Admin.Models
{
    public class UserRoles_VM
    {
        public string UserId { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string UserName { get; set; }
        
        public string Email { get; set; }
        
        public IEnumerable<string> Roles { get; set; }
    }
}
