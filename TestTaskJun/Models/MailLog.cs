using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Npgsql;

namespace TestTaskJun.Models
{
    public class MailLog
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Recipient { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public string FailedMessage { get; set; }
        
        
        public static List<MailLog> GetMails()
        {
            List<MailLog> mailLogObjects;
            using (IDbConnection db =
                new NpgsqlConnection("Host=localhost;Database=mailLog;User Id=postgres;Password=admin;"))
            {
                mailLogObjects = db.Query<MailLog>("SELECT * FROM maillog").ToList();
            }
            return mailLogObjects;
        }
        
        public static void InsertMail(MailLog mailLog) //вынести в константу таблицу, и переименовать мейллогобжекс
        {
            string sql = @"INSERT INTO maillog (Subject,Body,Recipient,Date,Result,FailedMessage) 
                                       Values (@Subject,@Body,@Recipient,@Date,@Result,@FailedMessage);";
            using (IDbConnection dbConnection =
                new NpgsqlConnection("Host=localhost;Database=mailLog;User Id=postgres;Password=admin;"))
            {
                dbConnection.Execute(sql, mailLog);
            }
        }
    }
}