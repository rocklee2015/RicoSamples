<Query Kind="Statements" />

//使用L系统语法的藻类生长
string algae = "A";

Func<string,string> transformA = x => x.Replace("A","AB");
Func<string,string> markBs = x => x.Replace("B","[B]");
Func<string,string> transformB = x => x.Replace("[B]","A");
int length = 7;

Enumerable.Range(1,length)
          .ToList()
		  .ForEach ( k => algae = transformB(transformA(markBs(algae))));
		  
algae.Dump("Algae at 7th Iteration");