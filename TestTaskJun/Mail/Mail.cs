namespace TestTaskJun.Mail
{
    /// <summary>
    /// This class describes the structure of the message
    /// that will be used for subsequent sending.
    /// </summary>
    public class Mail
    {
        /// <summary>
        /// This field serves as a repository of information about the mail subject
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// This field serves as a repository of information about the mail body
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// This field serves as a repository of information about the mail recipient
        /// </summary>
        public string Recipient { get; set; }
    }
}