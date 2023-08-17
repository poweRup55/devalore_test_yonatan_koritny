using devalore_test_yonatan_koritny.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;
using System.Diagnostics.Metrics;


namespace devalore_test_yonatan_koritny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _dbContext;

        private ValueTask<EntityEntry<User>> lastUserAdded;

        public UsersController(UserContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersData(string gender)
        {


            if (_dbContext == null)
            {
                return NotFound();
            }   
            var users = await _dbContext.Users.Where(p => p.Gender == gender).ToListAsync();

            if (users == null)
            {

                return NotFound();

            }

            return users.Take(10).ToList();

        }

        [HttpGet]
        public async Task<ActionResult<string>> GetMostPupalarCountry()
        {
            if (_dbContext == null)
            {
                return NotFound();
            }

            var country = await _dbContext.Users.MaxAsync(p => p.Location);

            if (country == null)
            {

                return NotFound();

            }

            return country;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string?>>> GetListOfMails()
        {
            if (_dbContext == null)
            {
                return NotFound();
            }

            var mails = await _dbContext.Users.Select(p => p.Email).Take(30).ToListAsync();

            if (mails == null)
            {

                return NotFound();

            }

            return mails;


        }

        [HttpGet]
        public async Task<ActionResult<User>> GetTheOldestUser()
        {
            if (_dbContext == null)
            {
                return NotFound();
            }

            var oldestAge = await _dbContext.Users.MaxAsync(p => p.Age);

            // Not optimal but don't have time to understand how to do it in one line

            var oldestUser = await _dbContext.Users.FirstOrDefaultAsync(p => p.Age == oldestAge);


            if (oldestUser == null)
            {

                return NotFound();

            }

            return oldestUser;
        }

        
        public async void CreateNewUser(int id, string? name, string? gender, string? phone, string? country)
        {

            lastUserAdded = _dbContext.AddAsync(new User(id, name, gender, phone, country));

        }

        public User GetNewUser()
        {
            return lastUserAdded.Result.Entity;
        }

        public async void UpdateUserData()
        {
            // TODO 
        }

    }
}
