using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using InfoRecord.Controllers;

namespace InfoRecord.Models
{
    public class RecordRepository : IRecordRepository
    {
        readonly string _connectionString;
        SqliteConnection _conn;
        public RecordRepository(string connectionString)
        {
            _connectionString = connectionString;
            _conn = new SqliteConnection(_connectionString);
        }
        public (bool Result, string Message) AddRecord(Record record)
        {
            try
            {
                var sql = @"INSERT INTO Records (                      
                        CompanyName,
                        CompanyType,
                        Principal,
                        Address,
                        Tel,
                        Conferee,
                        Attendance
                    )
                    VALUES (                       
                        @CompanyName,
                        @CompanyType,
                        @Principal,
                        @Address,
                        @Tel,
                        @Conferee,
                        @Attendance
                    );";
                var result = _conn.Execute(sql, record) > 0;
                return (result, "");
            }
            catch (Exception exc)
            {
                return (false, exc.Message);
            }

        }

        public List<Record> GetAllRecord()
        {
            var sql = @"select ID,                      
                        CompanyName,
                        CompanyType,
                        Principal,
                        Address,
                        Tel,
                        Conferee,
                        Attendance
                    From Records";
            return _conn.Query<Record>(sql).ToList();
        }

    }
}
