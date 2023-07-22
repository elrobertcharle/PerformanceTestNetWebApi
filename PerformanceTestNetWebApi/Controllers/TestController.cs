using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerformanceTestNetWebApi.ViewModels;

namespace PerformanceTestNetWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpPost("insert-data")]
        public async Task<IActionResult> InsertData(CancellationToken cancellationToken)
        {
            var random = new Random();
            var dbContext = new Dal.TestDbContext();
            for (var i = 0; i < 10; i++)
            {
                var office = new Dal.Office
                {
                    Address = Guid.NewGuid().ToString(),
                    Name = Guid.NewGuid().ToString(),
                    OpeningDate = DateTime.UtcNow,


                };

                for (var j = 0; j < 10; j++)
                {
                    office.People.Add(new Dal.Person
                    {
                        Dob = DateTime.UtcNow.AddYears(-30),
                        FirstName = Guid.NewGuid().ToString(),
                        LastName = Guid.NewGuid().ToString(),
                        Income = (decimal)random.NextDouble(),
                        SSN = Guid.NewGuid(),
                        Weight = random.NextSingle()
                    });
                }

                dbContext.Offices.Add(office);
            }

            await dbContext.SaveChangesAsync(cancellationToken);
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> ReadData(CancellationToken cancellationToken)
        {
            var dbContext = new Dal.TestDbContext();

            var query = dbContext.Offices.Select(o => new OfficeViewModel
            {
                Id = o.Id,
                Name = o.Name,
                Address = o.Address,
                OpeningDate = o.OpeningDate,
                People = o.People.Select(p => new PersonViewModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Dob = p.Dob,
                    Income = p.Income,
                    OfficeId = p.OfficeId,
                    SSN = p.SSN,
                    Weight = p.Weight
                }).ToList(),
            });

            var qs = query.ToQueryString();

            var offices = await query.ToListAsync(cancellationToken);

            return Ok(offices);
        }

        [HttpGet("ok")]
        public IActionResult Ok()
        {
            return Ok("ok");
        }
    }
}