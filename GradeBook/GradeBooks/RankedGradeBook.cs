using System;
using System.Collections.Generic;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            List<Student> sortedStudents = Students.OrderByDescending(student => student.AverageGrade).ToList();

            double x = sortedStudents.Count * 20 / 100d;

            double A = x;
            double B = 2 * x;
            double C = 3 * x;
            double D = 4 * x;

            int lowestA = (int)A;
            int lowestB = (int)B;
            int lowestC = (int)C;
            int lowestD = (int)D;

            if (averageGrade > sortedStudents[lowestA].AverageGrade) return 'A';
            if (averageGrade > sortedStudents[lowestB].AverageGrade) return 'B';
            if (averageGrade > sortedStudents[lowestC].AverageGrade) return 'C';
            if (averageGrade > sortedStudents[lowestD].AverageGrade) return 'D';

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}