namespace TimeSheets_App.Model
{
    public class Timesheet
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool OnLeave { get; set; }
        public List<Activity>? Activities { get; set; }
    }
}
