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
* *filehandles.cs* - Demonstrates that the body around a yield return is re-called
when trying to re-enumerate the state machine produced by the yield return. Also
shows a potential trap with opening and closing a file around a yield return.
