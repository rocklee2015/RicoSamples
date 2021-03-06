<Query Kind="VBStatements" />

Dim words As String() = {"hello", "wonderful", "linq", "beautiful", "world"}

' Get only short words
Dim shortWords = _
  From word In words _
  Where word.Length <= 5 _
  Select word

' Print each word out
shortWords.Dump()