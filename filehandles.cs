using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

// When using yield return to read from a file, does it
// reopen the file every time?
namespace FileHandles {
	public class Demo {
		public static IEnumerable<string> YieldReturnItems() {
			Console.WriteLine("Opening file...");

			string line;
			using(StreamReader f = new StreamReader("io.txt")) {
				while((line = f.ReadLine()) != null) {
					yield return line;
				}
			}

			Console.WriteLine("Done with the file.");
		}

		public static void Main(String[] args) {
			var items = Demo.YieldReturnItems();
			// Read once...
			foreach(var line in items) {
				Console.WriteLine(line);
			}
			// Then again...
			foreach(var line in items) {
				Console.WriteLine(line);
			}
			// What about if an exception happens halfway through?
			Console.WriteLine("Starting exception demo.");
			try {
				foreach(var line in items) {
					if(line.Contains("isn't")) {
							throw new Exception("Bailing out!");
					}
				}
			}
			catch(Exception e) {
				Console.WriteLine("Caught exception: " + e.Message);
			}
			finally {
				Console.WriteLine("Completed exception demo.");
			}
			// What happens if we cherry pick?
			for(var i = 0; i < 5; ++i) {
				var n = items.ElementAt(i);
				Console.WriteLine(n);
				// Does the file ever get closed?
				// Could this cause a memory leak pulling from any
				// large IDisposable?
			}
		}
	}
}
