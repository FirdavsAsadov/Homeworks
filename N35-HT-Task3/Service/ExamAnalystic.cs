using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace N35_HT_Task3
{
    public class ExamAnalystic
    {
        private readonly IExamScore _score;
        private readonly IUserService _user;
        public ExamAnalystic(IExamScore score, IUserService user)
        {
            _score = score;
            _user = user;
        }
        public IEnumerable<(string fullname, int score)> GetScore()
        {
            try
            {
                return _user.GetUsers().Select(user =>
                {
                    var name = $"{user.FirstName} {user.LastName}";
                    var score = _score.GetAllExamScore(user.Id);
                    return (name, score);
                });
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                return Enumerable.Empty<(string, int)>();
            }
        }
    }
}
/*public IEnumerable<(string FullName, double Score)> GetScore()
{
    return _userService.GetAllUsers.Select(user =>
    {
        var fullName = $"{user.FirstName} {user.LastName}";
        var score = _scoreService.GetUSerScore(user.Id);
        return (fullName, score);
    });*/