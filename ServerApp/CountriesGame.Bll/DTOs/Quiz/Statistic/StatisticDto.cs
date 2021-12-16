using System.Collections.Generic;

namespace CountriesGame.Bll.DTOs
{
    public class StatisticDto
    {
        public double AvarageGrade { get; set; }

        public int SubmittedCount { get; set; }

        public int ExpectedSubmittedCount { get; set; }

        public QuizDto Quiz { get; set; }

        public IEnumerable<TestResultDto> TestResults { get; set; }
    }
}