using System.Collections.Generic;

using Taskman.Core;

namespace Taskman.Cli;

public class CommandLineHandler : Command {

    //void InitCmdList() { }
    public CommandLineHandler() {
        Console.WriteLine("ForumPlayer's Task Manager\n");

        this._context = new();

        _cmdList.Add("new", this.NewTask);
        _cmdList.Add("list", this.ListTasks);
        _cmdList.Add("delete", this.DelTask);
        _cmdList.Add("pull", this.PullFromDb);
        _cmdList.Add("push", this.PushToDb);
        _cmdList.Add("help", this.ListCommands);
#if DEBUG
        _cmdList.Add("break", InvokeDebugger);
#endif
    }
    private readonly ManagerContext _context;


    public System.Threading.Tasks.Task Main(System.Threading.CancellationToken stoppingToken) {

        while (!stoppingToken.IsCancellationRequested) {
            var input = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(input)) continue;

            var ctx = new CmdContext(input.Trim(), _context);

            if (ctx.Cmd == "quit") break;
            if (_cmdList.ContainsKey(ctx.Cmd)) {
                _cmdList[ctx.Cmd](ctx);
                continue;
            }
            ctx.Reply("Unknown command");
        }
        return System.Threading.Tasks.Task.CompletedTask;

    }

}


public class CmdContext : IManagerContext {
    public CmdContext(string input, ManagerContext context) {

        this.Args = [.. input.Split(' ')];
        this.Cmd = Args[0].ToLower();
        this.Args.RemoveAt(0);
        this.Tasks = context.Tasks;
        this.DbPath = context.DbPath;
    }

    public string Cmd;
    public List<string> Args;
    public Action<string> Reply = Console.WriteLine;
    public TaskList Tasks { get; set; }
    public string DbPath { get; set; }

}


public partial class Command {
    protected readonly Dictionary<string, Action<CmdContext>> _cmdList = [];
}
