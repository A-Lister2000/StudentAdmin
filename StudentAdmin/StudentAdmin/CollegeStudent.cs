using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmin
{
    internal class CollegeStudent:Student , IAdminFunctions
    {
        private int StudentID;
        private int Aggregate;

        public CollegeStudent(string name, string surname, int age, string province,int studentID, int aggregate):
            base(name,surname, age, province)
        {
            this.StudentID = studentID;
            this.Aggregate = aggregate;
        }

        public CollegeStudent()
        {

        }
        
        public void addStudent(ArrayList StudentData, CollegeStudent cs)
        {
            StudentData.Add(cs);
        }

        public void removeStudent(ArrayList StudentData, CollegeStudent cs)
        {
            StudentData.Remove(cs);
        }

        public void displayStudents(ArrayList StudentData)
        {
            Console.WriteLine("STUDENT DATA\n\n");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine(string.Format("{0, -12} {1, -15} {2, -4} {3, -10} {4, -10} {5, -10}", "NAME", "SURNAME", "AGE", "PROVINCE", "STUDENTID", "AGGREGATE"));
            Console.WriteLine("------------------------------------------------------------------");
            foreach (CollegeStudent cs in StudentData)
            {
                Console.WriteLine(cs.ToString());
            }
            Console.WriteLine("------------------------------------------------------------------");
        }

        public void setStudentID(int _StudentID)
        {
            this.StudentID = _StudentID;
        }

        public int getStudentID()
        {
            return this.StudentID;
        }

        public void setAggregate(int aggregate)
        {
            this.Aggregate = aggregate; 
        }

        public int getAggregate()
        {
            return this.Aggregate;
        }

        public string ToString()
        {
            return base.ToString() + string.Format("{0, -10} {1,5}", this.StudentID, this.Aggregate);
        }

        public string ToFile()
        {
            return this.getName() + "," + this.getSurname() + "," + this.getAge() + "," + this.getProvince() + "," + this.StudentID + "," + this.Aggregate;
        }
    }
}

