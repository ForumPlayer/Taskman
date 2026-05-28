namespace Taskman.Cli;

public partial class Command {

    protected void ListCommands(CmdContext ctx) {

        var output = "Avaliable commands:\n";
        foreach (string cmd in _cmdList.Keys) output += $" - {cmd}\n";
        ctx.Reply(output);
        
    }
}
