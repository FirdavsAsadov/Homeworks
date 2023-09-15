namespace N36_HT_Task1
{
    public class EmailTemplate
    {
        public string Body { get; set;}
        public string Subject { get; set;}

        public EmailTemplate(string body, string subject)
        {
            Body = body;
            Subject = subject;
        }

        public EmailTemplate()
        {
            throw new System.NotImplementedException();
        }
    }
}