namespace webapp_travel_agency.Models
{
    public class Info
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime Created { get; set; }

        public Info()
        {
            this.Created = DateTime.Now;
        }
    }
}
