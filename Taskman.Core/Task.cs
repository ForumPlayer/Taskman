global using System;
global using System.Collections.Generic;

namespace Taskman.Core;

public class TaskNode : TaskProperties {

    public TaskNode(string name) {
        this.Name = name;
        this.Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }
    public TaskList RequiredBy = [];
    public TaskList Requires = [];

    public void AddDependency(TaskNode task) {
        task.RequiredBy.Add(this);
        this.Requires.Add(task);
    }

    public void AddDependency(List<TaskNode> tasks) {
        tasks.ForEach((task) => task.RequiredBy.Add(this));
        this.Requires.AddRange(tasks);
    }

}

public class TaskProperties {
    public string Name { get; protected set; } = string.Empty;
    public string? Description;

    public DateTime? Deadline { get; protected set; }
    public TaskStatus Status { get; protected set; } = TaskStatus.Pending;

    public DateTime? Created { get; } = DateTime.UtcNow;
}

public enum TaskStatus { Pending, Done }
