using Tecjnology.tasks;


Console.WriteLine("Hello Maxim Technology");

ITask[] tasks = {new Task1()};
for(int i=0; i<tasks.Length; i++)
{
    var task = tasks[i];
    task.Execute();
}