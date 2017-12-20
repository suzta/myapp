using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travelapp.models
{
    public class Image
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string ImageTitle { get; set; }

        [Required, MaxLength(2000)]
        public string Description { get; set; }
        public int FileId { get; set; }
        public string SystemFileName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public byte[] ByteArray { get; set; }
        public string UserFileName { get; set; }
        public string Extension { get; set; }
        public string SaveLocation { get; set; }
    }
}

