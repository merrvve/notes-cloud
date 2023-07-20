using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nc2.Context;
using nc2.Models;
using System.Numerics;

namespace nc2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class NotebookController : ControllerBase
    {
        NcDbContext _db;

        public NotebookController(NcDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Notebook>> GetNotebooksList()
        {
            return (IEnumerable<Notebook>)await _db.Notebooks.ToListAsync();
        }

        [HttpGet("{userId}")]
        public async Task<IEnumerable<Notebook>> GetByUser(int userId)
        {
              List<int> notebookIds =  _db.UserNotebooks.Where(x=>x.userId== userId).Select(x=>x.notebookId).ToList(); 
           return await _db.Notebooks.Where(x=>notebookIds.Contains(x.id)).ToListAsync();
            
        }




        [HttpPost]

        public async Task<Notebook> Post(Notebook notebook)
        {
            notebook.createdDate = DateTime.Now;
            notebook.modifiedDate= DateTime.Now;
             _db.Notebooks.Add(notebook);
            
            
            await _db.SaveChangesAsync();
            
               _db.UserNotebooks.Add(new UserNotebook() { userId = notebook.addedBy, notebookId = notebook.id });
          
           await _db.SaveChangesAsync();
            //NotebookUser newRel = new NotebookUser() { usersId = 1, notebooksId=notebook.id };
            //if(!_db.NotebookUsers.Any(x=> x.notebooksId==newRel.notebooksId && x.usersId==newRel.usersId ))
            //{
            //    _db.NotebookUsers.Add(newRel);
            //    await _db.SaveChangesAsync();
            //}


            //return _db.NotebookUsers.Where(x=>x.notebooksId==notebook.id);
            return notebook;
        }



        [HttpDelete("{id}")]

        public async Task<IEnumerable<Notebook>> DeleteNotebook(int id)
        {
            _db.Notebooks.Remove(_db.Notebooks.Find(id));
          //  _db.Notes.RemoveRange(_db.Notes.Where(x=>x.notebookId==id));
            await _db.SaveChangesAsync();
            return _db.Notebooks;
         
        }

        [HttpDelete("all/{cloudId}")]

        public async Task<IEnumerable<Notebook>> DeleteAllNotebooks(int cloudId)
        {
            _db.Notebooks.RemoveRange(_db.Notebooks.Where(x=>x.cloudId==cloudId));
            //  _db.Notes.RemoveRange(_db.Notes.Where(x=>x.notebookId==id));
            await _db.SaveChangesAsync();
            return _db.Notebooks;

        }

        [HttpPut]

        public async Task<Notebook> UpdateNotebook(Notebook notebook)
        {
            notebook.modifiedDate= DateTime.Now;
            _db.Notebooks.Update(notebook);
            await _db.SaveChangesAsync();
            return notebook;
        }

    }
}
