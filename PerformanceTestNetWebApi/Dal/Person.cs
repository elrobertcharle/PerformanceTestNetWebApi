using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceTestNetWebApi.Dal
{
    public class Person
    {
        public int Id { get; set; }

        [MaxLength(60)]
        public string? FirstName { get; set; }

        [MaxLength(60)]
        public string? LastName { get; set; }

        public DateTime Dob { get; set; }

        [ForeignKey(nameof(Office))]
        public int? OfficeId { get; set; }

        public Office? Office { get; set; }

        public decimal Income { get; set; }

        public Guid SSN { get; set; }

        public float Weight { get; set; }
    }
}
