using System.Collections.Generic;
using System.Linq;

namespace N35_HT_Task3
{
    public class ExamScoreService : IExamScore
    {
        private List<ExamScore> _exams = new List<ExamScore>();
        private int nextId = 1;
        public ExamScore CreateExamScore(ExamScore examScore)
        {
            examScore.Id = nextId++;
            _exams.Add(examScore);
            return examScore;
        }

        public ExamScore GetExamScoreById(int id)
        {
            return _exams.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ExamScore> GetAllExamScore()
        {
            return _exams;
        }

        public void UpdateExamScore(int id, ExamScore examScore)
        {
            var exam = _exams.FirstOrDefault(x => x.Id == id);
            if (exam!= null)
            {
                _exams.Remove(exam);
                _exams.Add(examScore);
            }
        }

        public void DeleteExamScore(int id)
        {
            var exam = _exams.FirstOrDefault(x => x.Id == id);
            if (exam!= null)
            {
                _exams.Remove(exam);
            }
        }
    }
}