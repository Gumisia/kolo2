using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class File
    {
        public int FileId { get; set; }
        public int TeamId { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public int FileSize { get; set; }

        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }

    }
}
