<Query Kind="Statements" />

Dictionary<int, string> frenchNumbers;
frenchNumbers = new Dictionary<int, string>();
frenchNumbers.Add(0, "zero");
frenchNumbers.Add(1, "un");
frenchNumbers.Add(2, "deux");
frenchNumbers.Add(3, "trois");
frenchNumbers.Add(4, "quatre");

var evenFrenchNumbers =
  from entry in frenchNumbers
  where (entry.Key % 2) == 0
  select entry.Value;

evenFrenchNumbers.Dump();