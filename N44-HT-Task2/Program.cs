using N44_HT_Task2;

var users = new List<User>
{
    new User("Jonibek", 15,"xbdsxb@gmail.com"),
    new User("G'ayrat", 15, "xbdsxb@gmail.com"),
    new User("Garri", 21, "xbdsxb@gmail.com"),
    new User("AbduVali", 20, "xbdsxb@gmail.com")
};

var updatedUsersQuery = users.Select(user => user.Age += 1);
var oldUsersQuery = users.Where(user => user.Age >= 18);
var orderedUsersQuery = users.OrderBy(user => user.Age);
var updatedUsersList = updatedUsersQuery.ToList();
var oldUsersArray = oldUsersQuery.ToArray();
var firstUser = users.First();
var exampleForTake = users.Take(10);
var exampleForSkip = users.Skip(5);
