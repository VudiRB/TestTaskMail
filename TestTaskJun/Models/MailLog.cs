using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using Dapper;
using Npgsql;

namespace TestTaskJun.Models
{
    /// <summary>
    /// This class contains a database table model for Dapper
    /// and methods for interacting with this table.
    /// </summary>
    public class MailLog
    {
        /// <summary>
        /// This field contains information about the subject
        /// in the message for interaction with the database.
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// This field contains information about the body
        /// in the message for interaction with the database.
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// This field contains information about the recipient
        /// in the message for interaction with the database.
        /// </summary>
        public string Recipient { get; set; }
        /// <summary>
        /// This field contains information about the date when the message was sent.
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// This field contains information about the result of sending the message (OK, Failed).
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// This field contains the error text if the message could not be sent,
        /// or an empty string if successful.
        /// </summary>
        public string FailedMessage { get; set; }
        
        /// <summary>
        /// Method for getting data about sent messages from the database.
        /// </summary>
        /// <returns>
        /// Returns all MailLog type data from the database.
        /// </returns>
        public static IEnumerable<MailLog> GetAllMails()
        {
            IEnumerable<MailLog> mailLogObjects;
            using (IDbConnection db =
                new NpgsqlConnection(ConfigurationManager.ConnectionStrings["mailLog"].ConnectionString))
            {
                mailLogObjects = db.Query<MailLog>("SELECT * FROM maillog");
            }
            return mailLogObjects;
        }
        
        /// <summary>
        /// Adds data about the sent message to the database.
        /// </summary>
        /// <param name="mailLog">
        /// A parameter of the MailLog type.
        /// Passes the data necessary for writing to the database.
        /// </param>
        public static void InsertMail(MailLog mailLog)
        {
            string sql = @"INSERT INTO maillog (Subject,Body,Recipient,Date,Result,FailedMessage) 
                                       Values (@Subject,@Body,@Recipient,@Date,@Result,@FailedMessage);";
            using (IDbConnection dbConnection =
                new NpgsqlConnection(ConfigurationManager.ConnectionStrings["mailLog"].ConnectionString))
            {
                dbConnection.Execute(sql, mailLog);
            }
        }
    }
}