using System;
using System.Collections.Generic;

namespace Taskman.Core;

public class TaskNode : TaskProperties {

    public TaskNode(string name) {
        this.Name = name;
    }

    public List<TaskNode> RequiredBy = [];
    public List<TaskNode> Requires = [];

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
}

public enum TaskStatus { Pending, Done }