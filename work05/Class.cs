public class EmployeeBook
{
    private readonly List<Employee> emplist = new List<Employee>
    {
        new("Косых Иван Андреевич", 1, 70000000.00),
        new("Комочков Денис Александрович", 2, 80000.00),
        new("Коробов Влад Андреевич", 3, 600.00),
        new("Жуков Антон Павлович", 4, 75000.00),
        new("Шевченко Макар Николаевич", 4, 85000.00),
        new("Логунов Данил", 5, 100000.00),
        new("Королёв Андрей", 5, 90000.00),
        new("Ламтюгина Олеся", 3, 73000.00),
        new("Калашников Пётр Витальевич", 1, 77000.00),
        new("Ларин Данил", 2, 60000.00),
    };

    public void Info()
    {
        var select = emplist.OrderBy(x => x.Department);
        foreach (var e in select)
        {
            Console.WriteLine($"id={e.Id}|{e.fullName}|{e.Salary}|{e.Department}");
        }
    }

    public double Sum() => emplist.Sum(e => e.Salary);

    public void Max() => Console.WriteLine($"Человек с самой максимальной зарплатой {emplist.Max(e => $"{e.Salary} рублей: {e.fullName}")}");

    public void GetMin() => Console.WriteLine($"Человек с самой минимальной зарплатой {emplist.Min(e => $"{e.Salary} рублей: {e.fullName}")}");

    public void Indexer(double num) => emplist.ForEach(e => Console.WriteLine($"{e.fullName}|{e.Salary *= num}"));

    public void AverageSalary() => Console.WriteLine($"Среднее значение зарплат: {emplist.Average(e => e.Salary)}");

    public void fullName() => emplist.ForEach(e => Console.WriteLine(e.fullName));

    public void MaxSalaryByDep()
    {
        Console.WriteLine("Введите номер отдела");
        var department = double.Parse(Console.ReadLine());
        var employeesInDepartment = emplist.Where(e => e.Departament == department);
        if (employeesInDepartment.Any())
        {
            var employeeWithMinSalary = employeesInDepartment.OrderBy(e => e.Salary).First();
            Console.WriteLine($" {employeeWithMinSalary.fullName}|{employeeWithMinSalary.Salary}");
        }
        else
        {
            Console.WriteLine($"Отдел {department} не найден или не имеет сотрудников.");
        }
    }

    public void MaxSalaryByDep1()
    {
        Console.WriteLine("Введите номер отдела");
        var department = double.Parse(Console.ReadLine());
        var employeesInDepartment = emplist.Where(e => e.Departament == department);
        if (employeesInDepartment.Any())
        {
            var employeeWithMaxSalary = employeesInDepartment.OrderByDescending(e => e.Salary).First();
            Console.WriteLine($" {employeeWithMaxSalary.fullName}|{employeeWithMaxSalary.Salary}");
        }
        else
        {
            Console.WriteLine($"Отдел {department} не найден или не имеет сотрудников.");
        }
    }

    public void DeprtmentAvgInfo()
    {
        Console.WriteLine("Введите номер отдела");
        var department = int.Parse(Console.ReadLine());
        var empInDpt = emplist.Where(p => p.Departament == department);
        Console.WriteLine(empInDpt.Average(e => e.Salary));
    }

    public void DeprtmentInfo()
    {
        Console.WriteLine("Введите номер отдела:");
        var departmentID = int.Parse(Console.ReadLine());
        var empInDpt = emplist.Where(p => p.Departament == departmentID);
        if (empInDpt.Any())
        {
            foreach (var e in empInDpt)
            {
                Console.WriteLine($"{e.Id}|{e.fullName}|{e.Salary}");
            }
        }
    }

    public void EmployeesWithSalaryLessThan(double num) => emplist.Where(p => p.Salary < num).ToList().ForEach(e => Console.WriteLine($"{e.fullName}|{e.Salary}"));
}
