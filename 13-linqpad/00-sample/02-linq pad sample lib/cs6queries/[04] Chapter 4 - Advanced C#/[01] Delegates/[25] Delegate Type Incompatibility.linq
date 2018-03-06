<Query Kind="Program" />

// Delegate types are all incompatible with each other, even if their signatures are the same:

delegate void D1();
delegate void D2();

static void Main()
{
	D1 d1 = Method1;
	D2 d2 = d1;            // Compile-time error
}

static void Method1() { }