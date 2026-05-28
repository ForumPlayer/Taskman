using LiteDB;

namespace Taskman.Core;


public class Database(IManagerContext ctx) : IDisposable {

    readonly LiteDatabase _db = new(ctx.DbPath);

    public void Dispose() => _db.Dispose();


    public void SaveListToDb(TaskList tasks) {
        var col = _db.GetCollection<TaskNode>("tasks");

        col.DeleteAll();
        tasks.ForEach(task => {
            col.Insert(task);
        });

    }

    public TaskList LoadListFromDb() {

        var q = _db.GetCollection<TaskNode>("tasks").Query().ToList();

        return [.. q];
    }


}
