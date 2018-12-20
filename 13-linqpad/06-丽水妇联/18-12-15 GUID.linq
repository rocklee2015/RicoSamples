<Query Kind="Program" />

void Main()
{
	Enumerable.Range(1,10).Select(a=>Guid.NewGuid()).ToList().Dump();
}

// Define other methods and classes here