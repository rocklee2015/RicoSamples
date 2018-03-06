<Query Kind="Statements" />

//用巴比伦公式生成毕达哥拉斯三元组
Enumerable.Range(2,10)
			.Select (c => new {Length = 2*c, Height = c * c - 1, Hypotenuse = c * c + 1})
			.Dump("Pythagorean Triples");