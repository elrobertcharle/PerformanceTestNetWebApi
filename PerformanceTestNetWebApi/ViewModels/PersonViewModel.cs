namespace PerformanceTestNetWebApi.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime Dob { get; set; }

        public int? OfficeId { get; set; }

        public decimal Income { get; set; }

        public Guid SSN { get; set; }

        public float Weight { get; set; }
    }
}
