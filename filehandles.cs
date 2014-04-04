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
		}
	}
}
