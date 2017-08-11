namespace Rico.S06.AutoFacSample.model2
{
    public class ClassA
    {
        private readonly ClassB b;

        public ClassA(ClassB b)
        {
            this.b = b;
        }
    }

    public class ClassB
    {
        public ClassA A { get; set; }

    }
}
