namespace CustomMidleWare
{
    public class UserService
    {
        private List<User> _users = new List<User>();
        public User Create(User user)
        {
            var result = _users.FirstOrDefault(x => x.Id == user.Id);
            if (result != null)
            {
                throw new Exception("Error!!");
            }
            _users.Add(user);

            return result;
        }
    }
}
