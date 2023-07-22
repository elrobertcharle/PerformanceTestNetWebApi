using System.ComponentModel.DataAnnotations;

namespace PerformanceTestNetWebApi.Dal
{
    public class Office
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public List<Person> People { get; set; } = new();

        [MaxLength(200)]
        public string? Address { get; set; }

        public DateTime? OpeningDate { get; set; }
    }
}
