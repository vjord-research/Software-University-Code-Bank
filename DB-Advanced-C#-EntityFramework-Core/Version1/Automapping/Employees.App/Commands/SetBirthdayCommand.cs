namespace Employees.App.Commands
{
    using System;
    using System.Globalization;
    using Employees.Services;

    internal class SetBirthdayCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetBirthdayCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // <employeeId> <dd-MM-yyyy>
        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);
            DateTime birthday = DateTime.ParseExact(args[1], "dd-MM-yyyy", CultureInfo.InvariantCulture);

            string employeeName = employeeService.SetBirthDay(employeeId, birthday);

            return $"{employeeName}'s birthday was set to {args[1]}";
        }
    }
}
