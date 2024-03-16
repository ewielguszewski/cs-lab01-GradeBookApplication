using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    internal class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeight) : base(name, isWeight)
        {
            Type = GradeBookType.Ranked;
            IsWeighted = true;
        }

        public override char GetLetterGrade(double averageGrade)
        {

            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Required at least 5 students");
            }

            var percentageOfTop = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (averageGrade >= grades[percentageOfTop])
                return 'A';
            else if (averageGrade >= grades[percentageOfTop * 2])
                return 'B';
            else if (averageGrade >= grades[percentageOfTop * 3])
                return 'C';
            else if (averageGrade >= grades[percentageOfTop * 4])
                return 'D';
            else
                return 'F';

        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
            }else
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
            }else
                base.CalculateStudentStatistics(name);
        }
        
    }
}
