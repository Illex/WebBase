using ContosoUniversity.Models;
using System;
using System.Collections;
using System.Linq;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student{uid="u0000000", FirstMidName="Carson",LastName="Alexander", phoneNumber="000-000-0000", currentDegree="BS", currentProgram="CS", gpa=4.0f, numHours=2, personalStatement="life sucks", fluency='f', completedSemesters=4, linkedin="nothing", resume="none", creationDate=System.DateTime.Now, modificatonDate=System.DateTime.Now},
            new Student{uid="u0000001", FirstMidName="Meredith",LastName="Alonso", phoneNumber="000-000-0001", currentDegree="BS", currentProgram="CS" , gpa=4.0f, numHours=2, personalStatement="life sucks", fluency='f', completedSemesters=4, linkedin="nothing", resume="none", creationDate=System.DateTime.Now, modificatonDate=System.DateTime.Now},
            new Student{uid="u0000002", FirstMidName="Arturo",LastName="Anand", phoneNumber="000-000-0002", currentDegree="BS", currentProgram="CS", gpa=4.0f, numHours=2, personalStatement="life sucks", fluency='f', completedSemesters=4, linkedin="nothing", resume="none", creationDate=System.DateTime.Now, modificatonDate=System.DateTime.Now},
            new Student{uid="u0000003", FirstMidName="Gytis",LastName="Barzdukas", phoneNumber="000-000-0030", currentDegree="BS", currentProgram="CS", gpa=4.0f, numHours=2, personalStatement="life sucks", fluency='f', completedSemesters=4, linkedin="nothing", resume="none", creationDate=System.DateTime.Now, modificatonDate=System.DateTime.Now},
            new Student{uid="u0000004", FirstMidName="Yan",LastName="Li", phoneNumber="000-000-0004", currentDegree="BS", currentProgram="CS", gpa=4.0f, numHours=2, personalStatement="life sucks", fluency='f', completedSemesters=4, linkedin="nothing", resume="none", creationDate=System.DateTime.Now, modificatonDate=System.DateTime.Now},
            new Student{uid="u0000005", FirstMidName="Peggy",LastName="Justice", phoneNumber="000-000-0005", currentDegree="BS", currentProgram="CS", gpa=4.0f, numHours=2, personalStatement="life sucks", fluency='f', completedSemesters=4, linkedin="nothing", resume="none", creationDate=System.DateTime.Now, modificatonDate=System.DateTime.Now},
            new Student{uid="u0000006", FirstMidName="Laura",LastName="Norman", phoneNumber="000-000-0006", currentDegree="BS", currentProgram="CS", gpa=4.0f, numHours=2, personalStatement="life sucks", fluency='f', completedSemesters=4, linkedin="nothing", resume="none", creationDate=System.DateTime.Now, modificatonDate=System.DateTime.Now},
            new Student{uid="u0000007", FirstMidName="Nino",LastName="Olivetto", phoneNumber="000-000-0007", currentDegree="BS", currentProgram="CS", gpa=4.0f, numHours=2, personalStatement="life sucks", fluency='f', completedSemesters=4, linkedin="nothing", resume="none", creationDate=System.DateTime.Now, modificatonDate=System.DateTime.Now}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
            new Course{CourseID="1400", semesters="Spring", title="Chemistry", year=2022, department="CS", section="001", description="liberal propoganda", professorUNID = "u1111111", professorName="Jonald Jorts", ClassTimes="M/W 3:30-5:00", location="MEB 1000", Credits=3, numEnrollments=12, notes="This class is very hard."},
            new Course{CourseID="1500", semesters="Spring", title="Microeconomics", year=2022,  department="CS", section="001", description="liberal propoganda", professorUNID = "u1111111", professorName="Jonald Jorts", ClassTimes="M/W 3:30-5:00", location="MEB 1000", Credits=3, numEnrollments=12, notes=""},
            new Course{CourseID="1600", semesters="Spring", title="Macroeconomics", year=2022, department="CS", section="001", description="liberal propoganda", professorUNID = "u1111111", professorName="Jonald Jorts", ClassTimes="M/W 3:30-5:00", location="MEB 1000", Credits=3, numEnrollments=12, notes=""},
            new Course{CourseID="1700", semesters="Spring", title="Calculus", year=2022, department="CS", section="001", description="liberal propoganda", professorUNID = "u1111111", professorName="Jonald Jorts", ClassTimes="M/W 3:30-5:00", location="MEB 1000", Credits=4, numEnrollments=12, notes=""},
            new Course{CourseID="1800", semesters="Spring", title="Trigonometry", year=2022, department="CS", section="001", description="liberal propoganda", professorUNID = "u1111111", professorName="Jonald Jorts", ClassTimes="M/W 3:30-5:00", location="MEB 1000", Credits=4, numEnrollments=12, notes=""},
            new Course{CourseID="1900", semesters="Spring", title="Composition", year=2022, department="CS", section="001", description="liberal propoganda", professorUNID = "u1111111", professorName="Jonald Jorts", ClassTimes="M/W 3:30-5:00", location="MEB 1000", Credits=3, numEnrollments=12, notes=""},
            new Course{CourseID="4400", semesters="Spring", title="Literature", year=2022, department="CS", section="001", description="liberal propoganda", professorUNID = "u1111111", professorName="Jonald Jorts", ClassTimes="M/W 3:30-5:00", location="MEB 1000", Credits=4, numEnrollments=12, notes="This class is also very hard."}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{StudentID=3,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{StudentID=6,CourseID=1045},
            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();

            //TODO: add availability seeding?
            ArrayList slots = new ArrayList();

            //need to make id manually for some reason?
            int id = 0;
            
            for(int i = 0; i < 24; i++)
            {
                slots.Add(new Slot {ID=id, day = "Monday", time = i });
                id++;
            }
            for (int i = 0; i < 24; i++)
            {
                slots.Add(new Slot { ID = id, day = "Tuesday", time = i });
                id++;
            }
            for (int i = 0; i < 24; i++)
            {
                slots.Add(new Slot { ID = id, day = "Wednesday", time = i });
                id++;
            }
            for (int i = 0; i < 24; i++)
            {
                slots.Add(new Slot { ID = id, day = "Thursday", time = i });
                id++;
            }
            for (int i = 0; i < 24; i++)
            {
                slots.Add(new Slot { ID = id, day = "Friday", time = i });
                id++;
            }

            foreach (Slot item in slots)
            {
                context.Slots.Add(item);
            }

            context.SaveChanges();

        }
    }
}