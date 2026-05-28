namespace Taskman.Cli;

public partial class Command {

    protected void NewTask(CmdContext ctx) {

        var name = string.Join(" ", ctx.Args);
        var task = ctx.Tasks.CreateTask(name);
        if (task != null) {
            ctx.Reply($"Task \"{task.Name}\" created successfully.");
        }

    }

    protected void ListTasks(CmdContext ctx) {

        var output = "# My Tasks:\n";
        var i = 1;

        ctx.Tasks.ForEach(task => {
            output += $"\n - Task {i}: {task.Id}\n   Name: {task.Name}\n   Status: {task.Status}\n";
            i++;
        });

        ctx.Reply(output);

    }

    protected void DelTask(CmdContext ctx) => ctx.Tasks.DeleteTask(System.Guid.Parse(string.Join(" ", ctx.Args).Trim()));

}
