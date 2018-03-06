<Query Kind="VBProgram" />

' Section 3.2.3

Function Square(ByVal n As Double) As Double
	Console.WriteLine("Computing Square(" & n & ")...")
	Return Math.Pow(n, 2)
End Function

Sub Main()
	Dim numbers As Integer() = {1, 2, 3}
	
	Dim query = _
		From n In numbers _
		Select Square(n)
	
	For Each n In query.ToList()
		Console.WriteLine(n)
	Next
End Sub