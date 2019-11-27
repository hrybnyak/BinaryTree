using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentLibrary
{
    public class TestResult:IComparable<TestResult>
    {
        public int CompareTo([AllowNull] TestResult other) => TestName.CompareTo(other.TestName);
        public string StudentName { get; }
        public string TestName { get; }
        public double Score { get; set; }
        [DataType(DataType.Date)]
        public DateTime DayTaken { get; }
        public TestResult() { }
        public TestResult(string name, string test, double score, DateTime date)
        {
            StudentName = name ?? throw new ArgumentNullException(nameof(name));
            TestName = test ?? throw new ArgumentNullException(nameof(test));
            Score = score;
            DayTaken = date;
        }
        public TestResult(string name, string test, double score)
        {
            StudentName = name ?? throw new ArgumentNullException(nameof(name));
            TestName = test ?? throw new ArgumentNullException(nameof(test));
            Score = score;
            DayTaken = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{StudentName} took {TestName} test on {DayTaken} and got {Score} points";
        }

    }
}
