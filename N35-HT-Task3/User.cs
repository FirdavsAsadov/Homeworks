namespace N35_HT_Task3
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User(int id, string firstName, string Last)
        {
            Id = id;
            FirstName = firstName;
            LastName = Last;
        }
    }
}