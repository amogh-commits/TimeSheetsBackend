using System.ComponentModel.DataAnnotations;

namespace TimeSheets_App.Model
{
    public class SubProject
    {
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
