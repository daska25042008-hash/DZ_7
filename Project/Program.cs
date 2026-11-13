using System;
using System.Collections.Generic;
enum TaskType
{
    System,
    Developer,
    Management,
    Accounting
}
class Employee
{
    public string Name;
    public TaskType Department;
    public List<Employee> Managers = new List<Employee>();
    public Employee(string name, TaskType department)
    {
        Name = name;
        Department = department;
    }
    public void AddManager(Employee manager)
    {
        Managers.Add(manager);
    }
    public bool CanAcceptTask(Employee manager, TaskType taskType)
    {
        return Managers.Contains(manager) &&
               (Department == taskType ||
               Department == TaskType.Management && taskType == TaskType.Management ||
               Department == TaskType.Accounting && taskType == TaskType.Accounting);
    }
}
class Task
{
    public string Name;
    public TaskType Type;
    public Task(string name, TaskType type)
    {
        Name = name;
        Type = type;
    }
}
class Program
{
    static void GiveTask(Employee manager, Employee worker, Task task)
    {
        Console.WriteLine("От " + manager.Name + " даётся задача \"" +
                          task.Name + "\" человеку " + worker.Name);
        if (worker.CanAcceptTask(manager, task.Type))
        {
            Console.WriteLine(worker.Name + " принимает задачу.");
        }
        else
        {
            Console.WriteLine(worker.Name + " отказывается от задачи.");
        }
        Console.WriteLine();
    }
    static void Main()
    {
        Employee timur = new Employee("Тимур", TaskType.Management);
        Employee rashid = new Employee("Рашид", TaskType.Accounting);
        Employee ilham = new Employee("О Ильхам", TaskType.Management);
        Employee lukas = new Employee("Лукас", TaskType.Accounting);
        Employee arkadiy = new Employee("Оркадий", TaskType.Management);
        Employee volodya = new Employee("Володя", TaskType.Management);
        Employee ilshat = new Employee("Ильшат", TaskType.System);
        Employee ivanych = new Employee("Иваныч", TaskType.System);
        Employee ilya = new Employee("Илья", TaskType.System);
        Employee vitya = new Employee("Витя", TaskType.System);
        Employee zhenya = new Employee("Женя", TaskType.System);
        Employee sergey = new Employee("Сергей", TaskType.Developer);
        Employee laysan = new Employee("Ляйсан", TaskType.Developer);
        Employee marat = new Employee("Марат", TaskType.Developer);
        Employee dina = new Employee("Дина", TaskType.Developer);
        Employee ildar = new Employee("Ильдар", TaskType.Developer);
        Employee anton = new Employee("Антон", TaskType.Developer);

        rashid.AddManager(timur);
        ilham.AddManager(timur);
        lukas.AddManager(rashid);

        arkadiy.AddManager(ilham);
        volodya.AddManager(ilham);

        ilshat.AddManager(arkadiy);
        ilshat.AddManager(volodya);
        ivanych.AddManager(ilshat);
        ilya.AddManager(ivanych);
        vitya.AddManager(ivanych);
        zhenya.AddManager(ivanych);

        sergey.AddManager(arkadiy);
        sergey.AddManager(volodya);
        laysan.AddManager(sergey);
        marat.AddManager(laysan);
        dina.AddManager(laysan);
        ildar.AddManager(laysan);
        anton.AddManager(laysan);

        Task systemTask = new Task("Настроить сеть", TaskType.System);
        Task developerTask = new Task("Исправить программу", TaskType.Developer);
        Task managementTask = new Task("Подготовить отчёт", TaskType.Management);
        Task accountingTask = new Task("Подготовить бухгалтерию", TaskType.Accounting);

        GiveTask(ilshat, ivanych, systemTask);
        GiveTask(ivanych, ilya, systemTask);
        GiveTask(sergey, laysan, developerTask);
        GiveTask(laysan, dina, developerTask);
        GiveTask(arkadiy, sergey, developerTask);
        GiveTask(timur, dina, developerTask);
        GiveTask(rashid, lukas, accountingTask);
        GiveTask(timur, rashid, managementTask);
    }
}

