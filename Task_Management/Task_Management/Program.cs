
// See https://aka.ms/new-console-template for more information
using Task_Management.Enums;
using Task_Management.Models.BuilderPattern;
using Task_Management.Models.ChainOfResponsPattern;
using Task_Management.Models.StatePattern;
using Task_Management.Models;
using Task_Management.Models.MomentoPattern;

Console.WriteLine("Hello, World!");

User user = new() { email = "sd@gmail.com", name = "chaim", role = Role.manager };

var taskBuilder = new TaskBuilder(DateTime.Now, "abc", user,30);
taskBuilder.AddPriority(Priority.Low);
taskBuilder.AddReporter("Bob","rfdrf",Role.developer);

var task = taskBuilder.Build();


var taskBuilder1 = new TaskBuilder(DateTime.Now, "abc", user, 30);
taskBuilder1.AddPriority(Priority.Low);
taskBuilder1.AddReporter("Bob", "rfdrf", Role.developer);
taskBuilder1.AddSubTasks(task);
var task1 = taskBuilder1.Build();

var taskBuilder2 = new TaskBuilder(DateTime.Now, "abcd", user, 10);
taskBuilder2.AddSubTasks(task1);

taskBuilder2.AddPriority(Priority.High);


var bigTask = taskBuilder2.Build();

//Observer
bigTask.Attach(bigTask.Assignee);
bigTask.Attach(bigTask.Reporter);


var userManager = new UserManager();
var userQA = new UserQA();
var userDeveloper = new UserDeveloper();

userManager.SetNext(userQA);
userQA.SetNext(userDeveloper);

Console.WriteLine($"           {task.LoggedTime}");
userManager.Handle(bigTask, user);
Console.WriteLine($"           {bigTask.LoggedTime}");

//Composite
Console.WriteLine($"{bigTask.EstimationTime}");
//Console.WriteLine($"{bigTask.EstimationTime}");
//Console.WriteLine($"{bigTask.LoggedTime}");
//task.LoggedTime = 3;
//task.LoggedTime = 5;
//Console.WriteLine($"{task.LoggedTime}");
//Console.WriteLine($"{bigTask.LoggedTime}");

Console.WriteLine();
Console.WriteLine();


//Memento
// שמירה על המצב הראשוני
Console.WriteLine($"Current Status: {bigTask.Status}, Current Priority: {bigTask.Priority} Current Priority: {task.Priority}");
Console.WriteLine();
Console.WriteLine("Task History:");
bigTask.DisplayHistory();
// שינוי פרטי המשימה
//bigTask.Priority=Priority.Medium;
userManager.Handle(bigTask,user);
Console.WriteLine();

Console.WriteLine("Task History:");
bigTask.DisplayHistory();
Console.WriteLine();
Console.WriteLine($"Current Status: {bigTask.Status}, Current Priority: {bigTask.Priority} Current LoggedTime: {bigTask.LoggedTime}");

Console.WriteLine();

bigTask.Undo();

Console.WriteLine($"After Undo - Current Status: {bigTask.Status}, Current Priority: {bigTask.Priority} Current Priority: {task.Priority}");

Console.WriteLine("Task History:");
bigTask.DisplayHistory();
Console.WriteLine();



