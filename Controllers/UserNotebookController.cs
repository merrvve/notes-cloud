using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nc2.Context;
using nc2.Models;

namespace nc2.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class UserNotebookController : Controller
    {
        NcDbContext _db;

        public UserNotebookController(NcDbContext db)
        {
            _db = db;
        }


        [HttpGet("{notebookId}")]
        public async Task<IEnumerable<User>> GetByUser(int notebookId)
        {
            List<int> userIds = _db.UserNotebooks.Where(x => x.notebookId == notebookId).Select(x => x.userId).ToList();
            return await _db.Users.Where(x => userIds.Contains(x.id)).ToListAsync();

        }



        [HttpPost]

        public async Task<UserNotebook> Post(UserNotebook userNotebook)
        {
            
            _db.UserNotebooks.Add(userNotebook);

            await _db.SaveChangesAsync();
            return userNotebook;
            
        }

    }
}
