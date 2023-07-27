// See https://aka.ms/new-console-template for more information
using StudentAdmin;
using System.Collections;
using System.Text.RegularExpressions;
using System.Xml.Linq;

helper help = new helper();
Validate val = new Validate();
CollegeStudent cs = new CollegeStudent();
ArrayList StudentData = new ArrayList();
help.loadData(StudentData);
//read textfile load data to program temp data struct 
Execute();
help.updateDetails(StudentData);


void Execute()
{
    Console.Clear();

    try
    {
        int Opt = Welcome();

        switch (Opt)
        {
            case 1:
                bool isAdd = true;
                do
                {
                    Console.Clear();
                    cs = askDetails();
                    if (help.redudant(cs, StudentData))
                    {
                        Console.WriteLine("\nTHE STUDENT ID ALREADY EXISTS IN THE GIVEN INSTITUTION.");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        cs.addStudent(StudentData, cs);
                    }
                    
                    Console.Clear();
                    Console.Write("ADD ANOTHER STUDENT?\nY - Yes\nE - Exit\nM - Menu\n");
                    string Answer = Console.ReadLine().ToUpper();

                    if (Answer == "Y")
                    {
                        isAdd = true;
                    }
                    else if (Answer == "M")
                    {
                        isAdd = false;
                        Execute();
                    }
                    else if (Answer == "E")
                    {
                        isAdd = false;
                    }
                    else
                    {
                        Console.WriteLine("INVALID INPUT\nGOING BACK TO MENU!");
                        Thread.Sleep(2000);
                        Execute();
                    }

                } while (isAdd);
                break;
            case 2:
                bool removeAnother = false;

                do
                {
                    Console.Clear();
                    bool isRemoved = help.remove(cs, StudentData);

                    if (isRemoved)
                    {
                        Console.WriteLine("STUDENT SUCCESSFULLY REMOVED!!");
                    }
                    else
                    {
                        Console.WriteLine("STUDENT ID DOES NOT EXIST IN THE SYSTEM!");
                    }

                    removeAnother = val.updateRemoveAnother();

                } while (removeAnother);
                break;
            case 3:
                Console.Clear();
                cs.displayStudents(StudentData);
                Console.WriteLine("\n\nPRESS ANY KEY WHEN DONE VIEWING");
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("\n\nCHOOSE BETWEEN 1-3");
                Thread.Sleep(2000);
                Execute();
                break;
        }
    }catch(Exception ex)
    {
        Console.WriteLine("\n\nINVALID INPUT");
        Thread.Sleep(2000);
        Console.Clear();
        Execute();
    }
    
}
int Welcome()
{
    Console.WriteLine("CRUD SCHOOL OF EXCELLENCE\n\n1 - ADD NEW STUDENT\n2 - DELETE STUDENT FROM SYSTEM\n3 - DISPLAY STUDENTS\n");
    Console.Write("SELECT OPTION: ");
    int Option = int.Parse(Console.ReadLine());
    return Option;
}
CollegeStudent askDetails()
{
    //Validate
    string name = "";
    do
    {
        Console.Write("Enter NAME: ");
        name = Console.ReadLine();
    } while (!val.valStringInput(name));

    string surname = "";
    do
    {
        Console.Write("Enter SURNAME: ");
        surname = Console.ReadLine();
    } while (!val.valStringInput(surname));

    bool AgeConverted = false;
    int Age = 0;
    do
    {
        Console.Write("Enter AGE: ");
        string age = (Console.ReadLine());

        try
        { 
            Age = int.Parse(age);
            AgeConverted = true;
        } catch(Exception e)
        {
            Console.WriteLine("INVALID AGE INPUT!, TRY AGAIN");
        }
        
    } while (AgeConverted == false);

    string Province = "";

    do
    {
        Console.Write("Enter the name of the PROVINCE: ");
        Province = Console.ReadLine();
    } while (!val.valStringInput(Province) | !help.validProvince(Province));


    bool instvalid = false;
    int StudentID = 0;
    do
    {
        Console.Write("Enter Student ID: ");
        string stIdAsString = (Console.ReadLine());

        try
        {
            StudentID = int.Parse(stIdAsString);
            if (StudentID.ToString().Length == 8) 
            {
                instvalid = true;
            }
            else
            {
                Console.WriteLine("STUDENT ID SHOULD BE 8 DIGITS!");
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine("INVALID STUDENT ID WAS ENTERED, TRY AGAIN");
        }

    } while (instvalid == false);

    bool AggregateConverted = false;
    int Aggregate = 0;
    do
    {
        Console.Write("Enter AGGREGATE: ");
        string AggregateAsString = Console.ReadLine();

        try
        {
            Aggregate = int.Parse(AggregateAsString);
            AggregateConverted = true;
        }
        catch (Exception e)
        {
            Console.WriteLine("INVALID AGGRAGATE INPUT!, TRY AGAIN");
        }

    } while (AggregateConverted == false);  

    return new CollegeStudent(name, surname, Age, Province, StudentID, Aggregate);
}


