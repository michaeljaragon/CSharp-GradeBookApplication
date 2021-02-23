using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name) 
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Need at least 5 students.");
            }
            else
            {
                int increment = (int)Math.Ceiling(Students.Count * 0.2);
                var grades = Students.OrderBy(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();


                if (averageGrade >= grades[increment - 1])
                    return 'A';
                if (averageGrade >= grades[increment * 2 - 1])
                    return 'B';
                if (averageGrade >= grades[increment * 3 - 1])
                    return 'C';
                if (averageGrade >= grades[increment * 4 - 1])
                    return 'D';
                return 'F';
            }
        }
    }
}
