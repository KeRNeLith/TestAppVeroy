namespace Tests
{
    /// <summary>
    /// Test class comment.
    /// </summary>
    public class TestClass
    {
        public string Test { get; set; }

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