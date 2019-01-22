<Query Kind="Program" />

void Main()
{
	//Enum-->String
	(Enum.GetName(typeof(Colors),3)).Dump();
	(Enum.GetName(typeof(Colors), Colors.Blue)).Dump();
	Enum.GetNames(typeof(Colors)).Dump();
	//String-->Enum
	((Colors)Enum.Parse(typeof(Colors), "Red")).Dump("String-->Enum");
	//Enum-->Int
	//
	"-------------------------------------------------".Dump();
	Color color  =  Color.Blue;  
       string  colorString  =   " Blue " ;  
       int  colorValue  =   0x0000FF ;  
  
       // 枚举转字符串   
       string  enumStringOne  =  color.ToString().Dump(); //效率低，不推荐  
       string  enumStringTwo  =  Enum.GetName( typeof (Color), color).Dump();//推荐  
       "-----------------------".Dump();
       // 枚举转值   
       int  enumValueOne  =  color.GetHashCode().Dump();  
       int  enumValueTwo  =  ( int )color.Dump();  
       int  enumValueThree  =  Convert.ToInt32(color).Dump();  
   "-----------------------".Dump();
       // 字符串转枚举   
      Color enumOne  =  (Color)Enum.Parse( typeof (Color), colorString).Dump();  
   "-----------------------".Dump();
       // 字符串转值   
       int  enumValueFour  =  ( int )Enum.Parse( typeof (Color), colorString).Dump();  
   "-----------------------".Dump();
       // 值转枚举   
      Color enumTwo  =  (Color)colorValue.Dump();  
      Color enumThree  =  (Color)Enum.ToObject( typeof (Color), colorValue).Dump();  
   "-----------------------".Dump();
       // 值转字符串   
       string  enumStringThree  =  Enum.GetName( typeof (Color), colorValue).Dump();  
}

public enum Colors { Red, Green, Blue, Yellow };
public   enum  Color  
   {  
      Red  =   0xff0000 ,  
      Orange  =   0xFFA500 ,  
      Yellow  =   0xFFFF00 ,  
      Lime  =   0x00FF00 ,  
      Cyan  =   0x00FFFF ,  
      Blue  =   0x0000FF ,  
      Purple  =   0x800080   
   }  
// Define other methods and classes here
