namespace N36_HT_Task1
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Status Status { get; set;}
        public string Email { get; set; }

        public User(string firstName, string lastName, Status status, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Status = status;
            Email = email;
        }
    }
}