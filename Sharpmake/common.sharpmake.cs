using System.IO;
using Sharpmake;
using Tests.Sharpmake.Extern;

[module: Sharpmake.Include("externs.sharpmake.cs")]

namespace Tests.Sharpmake
{
    // Target settings
    internal static class Settings
    {
        public static ITarget[] GetDefaultTargets()
        {
            return new ITarget[]
            {
                new Target(
                    // Target that build for both 32 and 64-bit
                    Platform.anycpu,
                    // Visual Studio 2017
                    DevEnv.vs2017,
                    // Debug & release configuration
                    Optimization.Debug | Optimization.Release,
                    // Target framework
                    framework: DotNetFramework.v4_5)
            };
        }
    }

    // Base class for C# projects
    internal class TestsBaseProject : CSharpProject
    {
        public string TestsRootPath = Path.Combine(@"[project.SharpmakeCsPath]", "..");

        public TestsBaseProject()
        {
            Name = GetType().Name.Replace("_", ".");
            RootPath = Path.Combine(@"[project.TestsRootPath]", "src");
            AddTargets(Settings.GetDefaultTargets());

            // Sources
            SourceRootPath = Path.Combine(@"[project.RootPath]", @"[project.Name]");
        }

        public virtual void ConfigureAll(Configuration conf, Target target)
        {
            // Project settings
            conf.ProjectFileName = "[project.Name]";
            conf.ProjectPath = Path.Combine(@"[project.RootPath]", @"[project.Name]");
            conf.TargetPath = Path.Combine(@"[project.TestsRootPath]", "bin", @"[project.Name]", @"[target.Optimization]");

            conf.Options.Add(Options.CSharp.LanguageVersion.CSharp7);

            // References
            conf.ReferencesByName.Add("System");
            conf.ReferencesByName.Add("System.Core");

            conf.ReferencesByNuGetPackage.Add(Externs.JetBrainsAnnotations, Externs.JetBrainsAnnotationsVersion);
        }
    }
}