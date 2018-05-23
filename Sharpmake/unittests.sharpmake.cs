using System.IO;
using Sharpmake;
using Tests.Sharpmake.Extern;

[module: Sharpmake.Include("common.sharpmake.cs")]
[module: Sharpmake.Include("externs.sharpmake.cs")]

namespace Tests.Sharpmake
{
    // Unit Tests
    internal abstract class UnitTests : TestsBaseProject
    {
        public UnitTests()
        {
        }

        [Configure]
        public override void ConfigureAll(Configuration conf, Target target)
        {
            base.ConfigureAll(conf, target);
            conf.Output = Configuration.OutputType.DotNetClassLibrary;

            conf.TargetPath = Path.Combine(@"[project.TestsRootPath]", "bin", "Tests", @"[target.Optimization]");

            conf.ReferencesByNuGetPackage.Add(Externs.NUnit, Externs.NUnitVersion);
            conf.ReferencesByNuGetPackage.Add(Externs.NUnitTestAdapter, Externs.NUnitTestAdapterVersion);
        }
    }

    // Unit Tests
    internal abstract class UnitTests<TProject> : UnitTests
        where TProject : TestsBaseProject, new()
    {
        public UnitTests()
        {
        }

        [Configure]
        public override void ConfigureAll(Configuration conf, Target target)
        {
            base.ConfigureAll(conf, target);
            conf.AddPrivateDependency<TProject>(target);
        }
    }
}