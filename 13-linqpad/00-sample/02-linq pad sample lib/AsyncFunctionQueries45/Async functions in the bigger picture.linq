<Query Kind="Statements">
  <Namespace>System.Drawing</Namespace>
</Query>

/* Asynchronous functions in C# 5 address the issue of latency. (Hit F5 for a picture.)

Latency = anything that takes time to run. Latency is half of the broader issue of concurrency;
the other half is parallel programming (making all CPU cores hot, primarily via fork/join patterns).

Just as Framework 4.0 gave us both functional and imperative solutions for parallel programming,
we now have both functional and imperative solutions for dealing with latency.

The functional is Reactive Framework; the imperative is asynchronous functions. The two approches
are complementary. Some problems are best solved functionally; others are best solved imperatively.
(And some problems are equally well solved either way.) */

Util.Image (Util.GetSampleFilePath ("Asynchronous Functions in C#", "Overview.png")).Dump();