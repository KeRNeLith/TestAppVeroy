using System;
//using System.Runtime.Serialization;
using SharedProject1;
using Tests;

namespace SubTests
{
//    /// <summary>
//    /// Test class2 comment.
//    /// </summary>
//#if NET45
//    [Serializable]
//#endif
//    public class TestClass2 : ISerializable
//    {
//        /// <inheritdoc />
//        public void GetObjectData(SerializationInfo info, StreamingContext context)
//        {
//            throw new NotImplementedException();
//        }
//    }

    /// <summary>
    /// Test class comment.
    /// </summary>
#if NET45
    [Serializable]
#endif
    public class SubTestClass
    {
        /// <summary>
        /// Test property.
        /// </summary>
        public TestClass Test { get; set; }

        public int TestMethod()
        {
            int a = 12;
            int b = 42;
            int c = a + b;
            int d = a * b;
            int e = a - b;

            return c + d + e;
        }

        /// <summary>
        /// Method with comment
        /// </summary>
        public int TestMethod(int a, int b)
        {
            int c = a + b;
            int d = a * b;
            int e = a - b;

            return c + d + e;
        }

        public int ComputedProp
        {
            get
            {
                int a = 12;
                int b = 42;
                return a / b;
            }
        }

        public string TestMethod(string p)
        {
            TestSharedProject.Foo();
            if (p == "Hello")
                return "World";
            return null;
        }

#if NET35
        public string Property35 { get; set; }
#elif NET40
        public string Property40 { get; set; }
#elif NET45
        public string Property45 { get; set; }
#elif NET452
        public string Property452 { get; set; }
#elif NETSTANDARD1_1
        public string PropertyStandard11 { get; set; }
#elif NETCOREAPP1_0
        public string PropertyCore1 { get; set; }
#elif NETCOREAPP2_0
        public string PropertyCore2 { get; set; }
#else
        public string PropertyOther { get; set; }
#endif
    }
}