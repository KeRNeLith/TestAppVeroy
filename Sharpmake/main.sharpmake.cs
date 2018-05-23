using System.IO;
using Sharpmake;

[module: Sharpmake.Include("projects.sharpmake.cs")]

namespace Tests.Sharpmake
{
    internal static class MainClass
    {
        [Main]
        public static void SharpmakeMain(Arguments arguments)
        {
            // Generate the solution
            arguments.Generate<TestsSolution>();
        }
    }

    // Solution
    [Generate]
    internal class TestsSolution : CSharpSolution
    {
        public TestsSolution()
        {
            // The name of the solution.
            Name = "TestsSolution";
            AddTargets(Settings.GetDefaultTargets());
        }

        [Configure]
        public void ConfigureAll(Configuration conf, Target target)
        {
            conf.SolutionPath = Path.Combine(@"[solution.SharpmakeCsPath]", "..");
            conf.SolutionFileName = @"[solution.Name]";

            conf.AddProject<TestsProject>(target);
            conf.AddProject<TestsProject_Tests>(target);
        }
    }
}