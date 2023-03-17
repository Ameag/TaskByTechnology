using Tecjnology.tasks;

const string taskPreviewTemplate = "Task number {0} is started";

Console.WriteLine("Hello Maxim Technology");

ITask[] tasks = { new Task1() };
for(int i=0; i<tasks.Length; i++)
{
    var task = tasks[i];
    Console.WriteLine(taskPreviewTemplate, i+1);
    task.Execute();
}