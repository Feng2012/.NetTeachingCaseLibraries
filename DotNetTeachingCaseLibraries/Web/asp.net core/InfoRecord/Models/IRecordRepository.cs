using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoRecord.Models
{
    public interface IRecordRepository
    {
        (bool Result, string Message) AddRecord(Record record);
        List<Record> GetAllRecord();
    }
}
