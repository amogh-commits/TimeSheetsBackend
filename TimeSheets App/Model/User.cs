using System.ComponentModel.DataAnnotations;
using System.Data;

namespace TimeSheets_App.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        
    }
}
