namespace nc2.Models
{
    public class NotebookCloud : BaseEntity
    {
        public int cloudId { get; set; }

        public int notebookId { get; set; }

        public Notebook? Notebook { get; set; }

        public Cloud? Cloud { get; set; }
    }
}
