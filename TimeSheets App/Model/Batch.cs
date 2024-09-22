using System.ComponentModel.DataAnnotations;

namespace TimeSheets_App.Model
{
    public class Batch
    {
        [Key]
        
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
