using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmin
{
    internal class Student
    {

        private string Name;
        private string Surname;
        private int Age;
        private string Province;

        protected Student()
        {

        }

        protected Student(string name, string surname, int age, string province)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.Province = province;
        }


        public void setName(string _Name)
        {
            this.Name = _Name;
        }

        public string getName()
        {
            return this.Name;
        }

        public void setSurname(string _Surname)
        {
            this.Surname = _Surname;
        }

        public string getSurname()
        {
            return this.Surname;
        }

        public void setAge(int _Age)
        {
            this.Age = _Age;
        }

        public int getAge()
        {
            return this.Age;
        }

        public void setProvince(string province)
        {
            this.Province = province;
        }

        public string getProvince()
        {
            return this.Province;
        }

        public string ToString()
        {
            
            return string.Format("{0, -12} {1, -15} {2, -4} {3, -11}", Name, Surname, Age, Province);
        }

    }
}