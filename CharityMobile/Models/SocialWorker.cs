namespace CharityMobile.Models
{
    public class SocialWorker
    {
        public int Id { get; set; }
        public int SphereId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int Rating { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageLink  { get; set;}
    }
}
