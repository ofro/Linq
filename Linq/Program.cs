using System;
using System.Collections.Generic;
using System.Linq;
using AdventurWorks;
using Linq.Linq_Extension;


namespace Linq
{

    class Program
    {
        static void Main(string[] args)
        {
            //Linq Extension
            //double[] numbers1 = { 1.2, 1.3, 5.6, 10.7 };
            //var median1 = numbers1.Median();
            //int[] numbers2 = { 1, 1, 5, 10 };
            //var median2 = numbers2.Median();

            int[] numbers3 = { 1, 1, 5, 10 };
            var median3 = numbers3.Median(n=>n);


            AdventurWorks.Data data = new Data();
            var addresses = data.Addresses();
            //ClassLibrary2.AdventureWorks2014Entities adwEnt = new  ClassLibrary2.AdventureWorks2014Entities();
            //foreach (var item in adwEnt.Addresses)
            //{
            //    Console.WriteLine(item.AddressLine1);
            //}

            List<object> list = new List<object>();
            var objTeam = new { Vorname = "Cloe", Nachname = "Webster", Alter = 42 };
            list.Add(objTeam);
            objTeam = new { Vorname = "Helmut", Nachname = "Sacher", Alter = 44 };
            list.Add(objTeam);
            objTeam = new { Vorname = "Annemarie", Nachname = "Mustermann", Alter = 39 };
            list.Add(objTeam);
            objTeam = new { Vorname = "Heidrun", Nachname = "Hufflatich", Alter = 41 };
            list.Add(objTeam);
            
            //var objResult = (from o in list where o.Vorname == "Cloe" select o).ToList;
            foreach (var result in list)
            {
                Console.WriteLine(result); 
            }


            // Aggregate
            Aggregate();

            // All
            System.Collections.Generic.IEnumerable<string> listLower = new[] { "a", "b", "c" };
            System.Collections.Generic.IEnumerable<string> listLowerAndUpper = new[] { "a", "b", "c", "D" };
            var b = listLower.All(p => p.Equals(p.ToLower()));
            b = listLowerAndUpper.All(p => p.Equals(p.ToLower()));
            
            // Any
            Any();

            // Append
            listLower = listLower.Append("y");

            //listLower.

            Console.Read();
        }

        static void Aggregate()
        {
            //Die Aggregate<TSource>(IEnumerable<TSource>, Func<TSource, TSource, TSource>) Methode ganz einfach eine Berechnung für eine Sequenz von Werten ausführen.
            //Diese Methode kann durch Aufrufen von func einmal für jedes Element im source mit Ausnahme der ersten. 
            //Bei jedem func aufgerufen wird, Aggregate<TSource>(IEnumerable<TSource>, Func<TSource, TSource, TSource>) übergibt das Element aus der Sequenz und einen Aggregatwert(als erstes Argument für func).
            //Das erste Element der source wird als erster Aggregatwert verwendet.
            //Das Ergebnis des func ersetzt den vorherigen Aggregatwert. Aggregate<TSource>(IEnumerable<TSource>, Func<TSource, TSource, TSource>) Gibt das endgültige Ergebnis der func.
            //Diese Überladung von der Aggregate<TSource> methodisn't für alle Casesbecause verwendet das erste Element der source als erster Aggregatwert. 
            //Wählen Sie eine andere Überladung, wenn der Rückgabewert nur die Elemente der sollen source die eine bestimmte Bedingung erfüllen. 
            //Beispielsweise wird diese Überladung nicht Reliableif zum Berechnen der Summe der geraden Zahlen im gewünschten source. Das Ergebnis nicht korrekt, wenn das erste Element anstelle sogar ungerade ist.

            //Um häufige Aggregationsoperationen zu vereinfachen, enthalten die Standardabfrageoperatoren auch allgemeine Zählmethode Count<TSource>, sowie vier numerische Aggregationsmethoden, nämlich Min, Max, Sum, und Average.

            //Überladung 1
            //z.B. Sortierung umdrehen
            System.Collections.Generic.IEnumerable<string> listString = new[] { "a", "b", "c" };
            var result = listString.Aggregate((w, next) => next + " " + w);
            Console.WriteLine(result);

            //Überladung 2
            //ermitteln Anzahl aller geraden Zahlen
            System.Collections.Generic.IEnumerable<int> listInt = new[] { 1, 2, 3, 4, 5, 6, 8, 0, 0, 2 }; // 7 gerade Zahlen
            Console.WriteLine("Anzahl gerader Zahlen: " + listInt.Aggregate(0,
                                                                           (total, next) =>
                                                                                next % 2 == 0 ? total + 1 : total));

            //Überladung 3
            //z.B. längsten Namen finden
            string[] fruits = { "apple", "mango", "orange", "passionfruit", "grape" };

            // Determine whether any string in the array is longer than "banana".
            string longestName =
                fruits.Aggregate("banana",
                                (longest, next) =>
                                    next.Length > longest.Length ? next : longest,
                                // Return the final result as an upper case string.
                                fruit => fruit);

            Console.WriteLine("The fruit with the longest name is {0}.", longestName);
        }

        static void Any()
        {
            string[] list = new string[] { "a", "b", "c", "D" };
            bool hatWerte = list.Any();
            Console.WriteLine($"Die Liste enthält {(hatWerte ? "" : "keine ")}Werte");

            list = new string[] { };
            hatWerte = list.Any();
            Console.WriteLine($"Die Liste enthält {(hatWerte ? "" : "keine ")}Werte");

            list = new string[] { "a", "b", "c", "D" };
            bool hatD = list.Any(p => p == "D");
            Console.WriteLine($"Die Liste enthält {(hatD ? "" : "kein ")}D");

            list = new string[] { "a", "b", "c", "d" };
            hatD = list.Any(p => p == "D");
            Console.WriteLine($"Die Liste enthält {(hatD ? "" : "kein ")}D");

            //list.Except
            //auf Objektebene
            //var posis = belegBestellung.Positionen.Where(p => posHandles.Any(ph => ph == p.Handle));
            //var posis = from p in Positionen where p.Handle = posHandles.Any() select p;
        }
    }
}
