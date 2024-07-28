using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahmoudIbrahim_sun_wed_5pm_C_13
{
    internal class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }

        public List<Employee> Staff = new List<Employee>();

        public void AddStaff(Employee E)
        {
            Staff.Add(E);
        }
        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            Employee emp = (Employee)sender;
            emp.EndOfYearOperation();
            emp.OnEmployeeLayOff(e);
        }
    }
}
