using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoRecord.Models
{
    public interface IEmailRepository
    {
        (bool Result, string Message) SendEmail(Record record);
    }
}
