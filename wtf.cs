using System;
using System.Collections.Generic;
using System.Linq;

// Demonstrates that yield returned objects are transient
// Shows the error from http://www.daedtech.com/getting-too-cute-with-c-yield-return
namespace Wtf {
	public class Demo {
		public static IEnumerable<Nubbin> YieldReturnItems() {
			for(int i = 1; i < 20; ++i) {
				yield return new Nubbin {
					Age = i,
					Name = "Foobar" + i
				};
			}
		}

		public static void ManipulateItems(IEnumerable<Nubbin> items) {
			foreach(var f in items) {
				// f exists only in this scope..
				// ..and is destroyed right after.
				f.Age *= 2;
			}
		}

		public static void Main(String[] args) {
			var items = Demo.YieldReturnItems();
			Demo.ManipulateItems(items); // "should" modify the ages...
			Console.WriteLine(items.ElementAt(0).Age); // wait, why isn't this 2?

			// Still not the case when you run a select over the collection!
			Console.WriteLine("Altered IEnumerable of ages: " + string.Join(", ", items.Select(i => i.Age.ToString()).ToArray()));
			var itemsAsList = items.ToList();
			Demo.ManipulateItems(itemsAsList);
			Console.WriteLine("Altered List of ages: " + string.Join(", ", itemsAsList.Select(i => i.Age.ToString()).ToArray()));
			// The moral? Don't rely on side effects!
			// When dealing with these, err on the side of caution and work
			// with a pure functional approach.
		}
	}  

	public class Nubbin {
		public int Age {get;set;}
		public string Name {get;set;}
	}
}
