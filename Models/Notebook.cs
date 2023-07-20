using nc2.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace nc2.Models
{
    public class Notebook : BaseEntity
    {
        public string? name { get; set; }
        public NotebookType? notebookType { get; set; }

       
        public int? textCount { get; set; }
        public int? checkedCount { get; set; }
        public int? uncheckedCount { get; set; }

        public ShareStatus? shareStatus { get; set; }
        public int? imageCount { get; set; }

        public int addedBy { get; set; }




        //relations

        public int cloudId { get; set; }
        public Cloud? Cloud { get; set; }

        //public virtual List<User>? users { get; set; }
       // public virtual List<Note>? notes { get; set; }

    }
}
