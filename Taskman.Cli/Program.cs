global using System;
global using Microsoft.Extensions.Logging;
namespace Taskman.Cli;

class Program {

    static void Main(string[] args) {
        var ch = new CommandLineHandler();

        ch.Main(new());
    }
}
