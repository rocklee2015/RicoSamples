<Query Kind="Program" />

// A delegate variable is assigned a method dynamically. This is useful for writing plug-in methods:

delegate int Transformer (int x);

class Util
{
  public static void Transform (int[] values, Transformer t)
  {
	for (int i = 0; i < values.Length; i++)
	  values[i] = t (values[i]);
  }
}

static void Main()
{
	int[] values = { 1, 2, 3 };
	Util.Transform (values, Square);      // Hook in the Square method
	values.Dump();
	
	values = new int[] { 1, 2, 3 };
	Util.Transform (values, Cube);        // Hook in the Cube method
	values.Dump();
}

static int Square (int x) => x * x;
static int Cube (int x)   => x * x * x;
