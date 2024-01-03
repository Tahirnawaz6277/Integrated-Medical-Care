using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_Course
{
    public class Person
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Contact { get; set; }
        public List<string> Programs { get; set; }
    }


    public class studentComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person? x, Person? y)
        {
            if (x == null && y == null) return false;
            return x.Id.Equals(y.Id) && x.firstName.Equals(y.firstName);
        }

        public int GetHashCode(Person obj)
        {
            var idHashCode = obj.Id.GetHashCode();
            var firstNameHashCode = obj.firstName == null ? 0 : obj.firstName.GetHashCode();

            return idHashCode ^ firstNameHashCode;
        }
    }



    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }

        public static List<Employee> getEmployee()
        {
            return    new List<Employee>()
            {
                new Employee() { Id = 1  , Name="Imran " , Salary="700$"},
                  new Employee() { Id = 2  , Name="Tahir " , Salary="700$"},
                    new Employee() { Id = 3  , Name="Junaid " , Salary="700$"},
                      new Employee() { Id = 4  , Name="Arshad " , Salary="700$"},
                        new Employee() { Id = 5  , Name="Inam " , Salary="700$"},
                          new Employee() { Id = 6  , Name="Imran " , Salary="700$"},
                          new Employee() { Id = 7  , Name="Imran " , Salary="700$"},
                          new Employee() { Id = 8  , Name="Imran " , Salary="700$"},
                      new Employee() { Id = 9  , Name="Imran " , Salary="700$"},
                      new Employee() { Id = 10  , Name="Imran " , Salary="700$"},
                       new Employee() { Id = 11  , Name="Imran " , Salary="700$"},
                  new Employee() { Id = 12  , Name="Imran " , Salary="700$"},
                    new Employee() { Id = 13  , Name="Imran " , Salary="700$"},
                      new Employee() { Id = 14  , Name="Imran " , Salary="700$"},
                        new Employee() { Id = 15  , Name="Imran " , Salary="700$"},
                          new Employee() { Id = 16  , Name="Imran " , Salary="700$"},
                          new Employee() { Id = 17  , Name="Imran " , Salary="700$"},
                          new Employee() { Id = 18  , Name="Imran " , Salary="700$"},
                      new Employee() { Id = 19  , Name="Imran " , Salary="700$"},
                      new Employee() { Id = 20  , Name="Imran " , Salary="700$"},
            };
            }
        
    };
}
