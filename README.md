Dumb Yield Return Tricks
===
A handful of small programs that I used to get my head around the yield
return functionality in late-model C# versions. Everything should build
on Mono with gmcs:

    gmcs foo.cs

Each file is its own individual program.

* *chains.cs* - Demonstrates effective use of yield return to provide
filtering. This is probably what LINQ does internally.
* *wtf.cs* - Demonstrates a common but annoying bug with manipulating IEnumerables
returned from a yield return generator without first holding onto the entire collection
in memory.
