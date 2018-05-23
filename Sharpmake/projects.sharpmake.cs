using System.IO;
using Sharpmake;

[module: Sharpmake.Include("common.sharpmake.cs")]
[module: Sharpmake.Include("unittests.sharpmake.cs")]

namespace Tests.Sharpmake
{
    [Generate]
    internal class TestsProject : TestsBaseProject
    {
        public TestsProject()
        {
        }

        [Configure]
        public override void ConfigureAll(Configuration conf, Target target)
        {
            base.ConfigureAll(conf, target);
            conf.Output = Configuration.OutputType.DotNetClassLibrary;
        }
    }

    // Tests
    [Generate]
    internal class TestsProject_Tests : UnitTests<TestsProject>
    {
        public TestsProject_Tests()
        {
        }
    }
}