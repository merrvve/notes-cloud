using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nc2.Context;
using nc2.Models;

namespace nc2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        NcDbContext _db;
        public NoteController(NcDbContext db)
        {
                _db = db;
        }


        [HttpGet("{notebookId}")]

        public async Task<IEnumerable<Note>> GetNotes(int notebookId)
        {
            return (IEnumerable<Note>)await _db.Notes.Where(x=>x.notebookId==notebookId).ToListAsync();
        }


        [HttpPost]

        public async Task<Note> Post(Note note)
        {
            note.createdDate = DateTime.Now;
            note.modifiedDate = DateTime.Now;
           
                _db.Notes.Add(note);
            

            await _db.SaveChangesAsync();


            return note;
        }

        [HttpDelete("{id}")]

        public async Task<IEnumerable<Note>> DeleteNote(int id)
        {
            _db.Notes.Remove(_db.Notes.Find(id));
            await _db.SaveChangesAsync();
            return _db.Notes;

        }

        [HttpPut]

        public async Task<Note> UpdateUser(Note note)
        {
            note.modifiedDate = DateTime.Now;
            _db.Notes.Update(note);
            await _db.SaveChangesAsync();
            return note;
        }


    }
}
