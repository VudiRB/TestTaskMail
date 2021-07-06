using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Npgsql;

namespace TestTaskJun.Models
{
    public static class DBHandler
    {
        public static List<MailLogObject> GetMails()
        {
            List<MailLogObject> mailLogObjects;
            using (IDbConnection db =
                new NpgsqlConnection("Host=localhost;Database=mailLog;User Id=postgres;Password=admin;"))
            {
                mailLogObjects = db.Query<MailLogObject>("SELECT * FROM maillog").ToList();
            }
            return mailLogObjects;
        }
        
        public static void InsertMail(MailLogObject mailLogObject)
        {
            string sql = @"INSERT INTO maillog (Subject,Body,Recipient,Date,Result,FailedMessage) 
                                       Values (@Subject,@Body,@Recipient,@Date,@Result,@FailedMessage);";
            using (IDbConnection dbConnection =
                new NpgsqlConnection("Host=localhost;Database=mailLog;User Id=postgres;Password=admin;"))
            {
                dbConnection.Execute(sql, mailLogObject);
            }
        }
    }
    
}