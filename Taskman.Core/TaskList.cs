namespace Taskman.Core;

public class TaskList : List<TaskNode> {
    public TaskList() { }
    public TaskList(IEnumerable<TaskNode> collection) { this.AddRange(collection); }

    public TaskNode CreateTask(string name) {
        var task = new TaskNode(name);
        this.Add(task);
        return task;
    }

    public void DeleteTask(Guid id) {
        var task = this.Find(x => x.Id == id);
        if (task != null) {
            this.Remove(task);
        } else {

        }
    }

}
