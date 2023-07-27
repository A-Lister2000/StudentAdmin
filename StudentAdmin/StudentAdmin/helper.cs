using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmin
{
    
    internal class helper
    {

        
        public void loadData(ArrayList StudentData)
        {
            string[] data = File.ReadAllLines(@"StudentData.txt");


            foreach (string Entity in data)
            {
                CollegeStudent cs = new CollegeStudent();
                string[] StudentInfo = Entity.Split(",");
                cs.setName(StudentInfo[0]);
                cs.setSurname(StudentInfo[1]);
                cs.setAge(int.Parse(StudentInfo[2]));
                cs.setProvince(StudentInfo[3]);
                cs.setStudentID(int.Parse(StudentInfo[4]));
                cs.setAggregate(int.Parse(StudentInfo[5]));
                StudentData.Add(cs);
            }

            Console.WriteLine("DATA LOADED SUCCESSFULLY...");
            Console.WriteLine(StudentData.Count + " STUDENT RECORDS WERE LOADED FROM THE FILE!");
            Thread.Sleep(3000);
            Console.Clear();

        }
        public bool redudant(CollegeStudent newCS, ArrayList StudentData)
        {
            bool isDuplicate = false;

            foreach (CollegeStudent cs in StudentData)
            {
                if (newCS.getStudentID() == cs.getStudentID())
                {
                    isDuplicate = true;
                }
            }
            return isDuplicate;
        }

        public bool validProvince(String province)
        {

            String[] validProvices = { "KZN", "GP", "WP", "NW", "LP", "EC", "FS", "MP" };

            bool isMatch = false;
            foreach (string prov in validProvices)
            {
                if (province == prov)
                {
                    isMatch = true;
                    break;
                }
            }

            if (!isMatch)
            {
                Console.WriteLine(province + " IS NOT A VALID PROVINCE IS SA");
                Thread.Sleep(2000);
            }
            return isMatch;
        }

        public bool remove(CollegeStudent cs, ArrayList StudentData)
        {
            Console.Write("Enter the student ID of student to remove: ");
            int StID = Convert.ToInt32(Console.ReadLine());

            bool isMatch = false;

            foreach (CollegeStudent newCS in StudentData)
            {
                if (newCS.getStudentID() == StID)
                {
                    isMatch = true;
                    cs.removeStudent(StudentData, newCS);
                    break;
                }
            }

            return isMatch;
        }

        public void updateDetails(ArrayList StudentData)
        {
            string[] data = new string[StudentData.Count];

            int Counter = 0;
            foreach (CollegeStudent cs in StudentData)
            {
                data[Counter] = cs.ToFile();
                Counter++;
            }
            File.WriteAllLines(@"StudentData.txt", data);
            string Output = "\nUPDATING DETAILS.";
            Console.Write(Output);
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.WriteLine(".\n");
            Console.Write("DONE, THANKS FOR USING THE SYSTEM.");
            Thread.Sleep(2000);
        }

    }
}
