namespace N36_HT_Task1
{
    public class EmailMessage
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverAddress { get; set; }

        public EmailMessage(string subject, string body, string sender, string receiver)
        {
            Subject = subject;
            Body = body;
            SenderAddress = sender;
            ReceiverAddress = receiver;
        }

        public EmailMessage()
        {
            throw new System.NotImplementedException();
        }
    }
}