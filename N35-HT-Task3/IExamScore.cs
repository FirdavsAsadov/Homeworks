using System.Collections;
using System.Collections.Generic;

namespace N35_HT_Task3
{
    public interface IExamScore
    {
        ExamScore CreateExamScore(ExamScore examScore);
        ExamScore GetExamScoreById(int id);
        IEnumerable<ExamScore> GetAllExamScore();
        void UpdateExamScore(int id,ExamScore examScore);
        void DeleteExamScore(int id);
    }
}