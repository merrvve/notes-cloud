using nc2.Models.Enums;

namespace nc2.Models
{
    public class Note : BaseEntity
    {
        public string? textNote { get; set; }
        

        public string? stickerNote { get; set; }
        public StickerType? stickerType { get; set; }

        public NoteType? noteType { get; set; }
        public Boolean? isChecked { get; set; }

        public string? header { get; set; }

        public DayOfWeek? day { get; set; }

        public string? hour { get; set; }

        //relation

        public int notebookId { get; set; }

        public Notebook? Notebook { get; set; }
    }
}
