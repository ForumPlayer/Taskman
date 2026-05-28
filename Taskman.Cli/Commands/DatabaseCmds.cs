using Taskman.Core;

namespace Taskman.Cli;

public partial class Command {

    protected void PullFromDb(CmdContext ctx) {
        using (var db = new Database(ctx)) {
            var q = db.LoadListFromDb();
            if (q == null) return;
            if (q.Count <= 0) return;
            ctx.Tasks.Clear();
            ctx.Tasks.AddRange(q);
        }

    }

    protected void PushToDb(CmdContext ctx) {
        using (var db = new Database(ctx)) {
            db.SaveListToDb(ctx.Tasks);
        }

    }

}
