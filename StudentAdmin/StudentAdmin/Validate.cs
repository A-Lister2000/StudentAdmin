using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentAdmin
{
    internal class Validate
    {

        public Validate() { }

            //surbodinate 
            //ig i was emotionallly depedent, sense of worth and security comes from other peoples opinions
            //pedestal
            //authoritarian plus permissive
            //thomas paine .. that which we obtain easily
        

        public bool updateRemoveAnother()
        {

            Console.Write("\n\nREMOVE ANOTHER STUDENR?(Y/N): ");
            char response = Console.ReadKey().KeyChar;

            //use tenary method

            return response == 'y' | response == 'Y';
        }

        public bool valStringInput(string _var)
        {

            Regex reg = new Regex(@"^[a-zA-Z]+$");
            bool result = reg.IsMatch(_var);

            if (!result)
            {
                Console.WriteLine(_var.ToString() + " IS A INVALID INPUT, TRY AGAIN");
                Thread.Sleep(3000);
                Console.Clear();
            }

            return reg.IsMatch(_var);
        }
    }
}
