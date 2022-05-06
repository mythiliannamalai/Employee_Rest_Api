using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace EmpJson
{
    public class Program
    {
        private List<Employee> emp;
        private Dictionary<int, Employee> employeeDetailsMap;
        Employee employee=new Employee();

        public Program()
        {
            emp = new List<Employee>();
            employeeDetailsMap = new Dictionary<int, Employee>();
        }
        public void AddDetails()
        {
            Console.WriteLine("\n Enter the Employee Id");
            employee.Emp_Id= int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Employee Name");
            employee.Emp_Name= Console.ReadLine();
            Console.WriteLine("Enter the Employee Salary");
            employee.Salary=int.Parse(Console.ReadLine());       
            
            emp.Add(employee);
            employeeDetailsMap.Add(employee.Emp_Id,employee);
            foreach (var contact in employeeDetailsMap)
            {
                Console.WriteLine(contact);
            }
        }
        public void JsonFile()
        {

            string jsonpath = @"C:\Users\user\source\repos\ConsoleApp2\ConsoleApp2\Json\EmpDetail\EmpDetail.json";
            string jsonData = JsonConvert.SerializeObject(emp);
            using (StreamWriter writer = File.CreateText(jsonpath))
            {
                writer.Flush();
                writer.Write(jsonData);
                Console.WriteLine(jsonData);
            }
            string result = File.ReadAllText(jsonpath);

            List<Employee> contactDetails = JsonConvert.DeserializeObject<List<Employee>>(result);
        }
        static void Main(string[]args)
        {
            Program program = new Program();
            program.AddDetails();
            program.JsonFile();

        }
    }
}