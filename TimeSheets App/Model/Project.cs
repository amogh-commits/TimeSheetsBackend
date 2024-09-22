using System.ComponentModel.DataAnnotations;

namespace TimeSheets_App.Model
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        public string Name {  get; set; }
    }
}
