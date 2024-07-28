namespace MahmoudIbrahim_sun_wed_5pm_C_13
{
    internal class Program
    {
        private static void User_EmployeeLayOff(object sender, EmployeeLayOffEventArgs e)
        {
            Console.WriteLine($"Employee laid off due to: {e.Cause}");
        }
        static void Main(string[] args)
        {
            Employee user = new Employee(1, DateTime.Now, 12);

            bool isValidForVacation = user.RequestVacation(DateTime.Now, DateTime.Now + TimeSpan.FromDays(15));

            if (isValidForVacation)
            {
                Console.WriteLine("Request accepted");
            }
            else
            {
                Console.WriteLine("Request denied");
            }

            user.EmployeeLayOff += User_EmployeeLayOff;

            user.EndOfYearOperation();

            Department dept = new Department();
            dept.AddStaff(user);

            dept.RemoveStaff(user, new EmployeeLayOffEventArgs
            {
                Cause = LayOffCause.Retirement
            });

            foreach (var item in dept.Staff)
            {
                item.EmployeeLayOff += User_EmployeeLayOff;
            }
        }
    }
}
