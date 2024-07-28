using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahmoudIbrahim_sun_wed_5pm_C_13
{
    public enum LayOffCause
    {
        Illness,
        Retirement,
        Death
    }
    public class EmployeeLayOffEventArgs
    {
        public LayOffCause Cause { get; set; }
    }
    public class Employee
    {
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;

        public virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }

        public int EmployeeID { get; set; }

        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        private int _vacationStock;
        public int VacationStock
        {
            get { return _vacationStock; }
            set { _vacationStock = value; }
        }

        // Default constructor
        public Employee()
        {
        }

        // Constructor with parameters
        public Employee(int employeeID, DateTime birthDate, int vacationStock): this()
        {
            this.EmployeeID = employeeID;
            this.BirthDate = birthDate;
            this.VacationStock = vacationStock;
        }

        public bool RequestVacation(DateTime from, DateTime to)
        {
            int requestedDays = (to - from).Days + 1;

            if (requestedDays <= this.VacationStock)
            {
                this.VacationStock -= requestedDays;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void EndOfYearOperation()
        {
            // check if user birthdate is greater than 60
            if ((DateTime.Now - this.BirthDate).Days > 60 * 365)
            {
                if (this.EmployeeLayOff != null)
                {
                    EmployeeLayOffEventArgs e = new EmployeeLayOffEventArgs();
                    e.Cause = LayOffCause.Retirement;
                    this.OnEmployeeLayOff(e);
                }
            }
        }

        public override string ToString()
        {
            return $"{this.EmployeeID} {this.BirthDate} {this.VacationStock}";
        }
    }
}
