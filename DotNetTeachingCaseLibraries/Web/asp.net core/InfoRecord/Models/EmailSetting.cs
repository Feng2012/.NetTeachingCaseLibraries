using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoRecord.Models
{
    public class EmailSetting
    {
        public string UserName { get; set; }
        public string FromAccount { get; set; }
        public string FromPassword { get; set; }
        public string ToUserName { get; set; }
        public string ToAccount { get; set; }
        public string Server { get; set; } = "sv7041.xserver.jp";
        public int Port { get; set; } = 587;
    }
}
