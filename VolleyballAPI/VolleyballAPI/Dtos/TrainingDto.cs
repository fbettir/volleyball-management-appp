namespace VolleyballAPI.Dtos
{
    public class TrainingDto
    {
        public Guid Id { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Guid TeamId { get; set; }
    }
}
