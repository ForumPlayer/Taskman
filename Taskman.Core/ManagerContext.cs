using System.IO;

namespace Taskman.Core;

public interface IManagerContext {
    TaskList Tasks { get; set; }
    string DbPath { get; set; }
}

public class ManagerContext() : IManagerContext {
    public TaskList Tasks { get; set; } = [];
    public string DbPath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "Taskman.db");
}
