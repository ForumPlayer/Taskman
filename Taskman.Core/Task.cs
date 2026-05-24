using System;
using System.Collections.Generic;

namespace Taskman.Core;

public class TaskNode {

    public TaskNode(string name) {
        this.Name = name;
    }


    public string Name { get; private set; } = string.Empty;
    public string? Description;


    public DateTime? Deadline { get; private set; }
    public TaskStatus Status { get; private set; } = TaskStatus.Pending;

}

public enum TaskStatus { Pending, Done }