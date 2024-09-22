namespace TimeSheets_App.Model
{
    public class Activity
    {
        public int Id { get; set; }
        public string Project { get; set; }
        public string SubProject { get; set; }
        public string Batch { get; set; }
        public string HoursNeeded { get; set; }
        public string Description { get; set; }
    }
}
