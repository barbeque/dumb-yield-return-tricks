using System;
using System.Collections.Generic;

// Demo from http://visualstudiomagazine.com/Articles/2012/02/01/Demystifying-the-C-Yield-Return-Mechanism.aspx?Page=2
// Showing chainable yield return statements
namespace YieldTest {
  class Person
  {
    private string name;
    private int age;

    public Person(string name, int age)
    {
      this.name = name;
      this.age = age;
    }

    public string Name { get { return this.name; } }

    public int Age { get { return this.age; } }

    public override string ToString() { return name + " " + age; }

    public static IEnumerable<Person> GetYoung(IEnumerable<Person> source)
    {
      foreach (Person p in source) {
        if (p.age < 20)
          yield return p;
      }
    }
    public static IEnumerable<Person>
      GetStartWithA(IEnumerable<Person> source)
    {
      foreach (Person p in source) {
        if (p.name.StartsWith("A"))
          yield return p;
      }
    }

    public static void Main(String[] args) {
      List<Person> people = new List<Person>();
      people.Add(new Person("Foo", 25));
      people.Add(new Person("ARod", 26));
      people.Add(new Person("Abby", 12));
      people.Add(new Person("David", 10));
      people.Add(new Person("Alexander", 6));

      foreach(var p in Person.GetYoung(Person.GetStartWithA(people))) {
        Console.WriteLine(p.ToString());
      }
    }
  } // Person
}
