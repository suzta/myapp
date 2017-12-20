using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travelapp.models
{
    public class UserFile
    {
        public int UserId { get; set; }
        public byte[] ByteArray { get; set; }
        public string UserFileName { get; set; }
        public string Extension { get; set; }
        public string SaveLocation { get; set; }
    }
}
