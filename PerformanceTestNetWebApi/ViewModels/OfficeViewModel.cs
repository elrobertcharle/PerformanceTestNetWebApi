using PerformanceTestNetWebApi.Dal;
using System.ComponentModel.DataAnnotations;

namespace PerformanceTestNetWebApi.ViewModels
{
    public class OfficeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public List<PersonViewModel> People { get; set; } = new();

        public string? Address { get; set; }

        public DateTime? OpeningDate { get; set; }
    }
}
