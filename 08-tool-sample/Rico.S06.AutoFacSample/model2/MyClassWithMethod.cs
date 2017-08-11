namespace Rico.S06.AutoFacSample.model2
{
    public class MyClassWithMethod
    {
        public int Index { get; set; }
        public void Add(int value)
        {
            Index = Index + value;
        }
    }
}
