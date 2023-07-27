using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmin
{
    internal interface IAdminFunctions
    {
        public void addStudent(ArrayList StudentData, CollegeStudent cs);

        public void removeStudent(ArrayList StudentData, CollegeStudent cs);

        public void displayStudents(ArrayList StudentData);

    }
}
