using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NPath.Framework;
using System.Collections;

namespace InMemFilter
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> realList = new List<Person>();

            Person p1 = new Person();
            p1.Age = 11;
            p1.FirstName = "Billy";
            p1.LastName = "Boolean";
            p1.Address.City = "Bla town";
            realList.Add (p1);

            Person p2 = new Person();
            p2.Age = 33;
            p2.FirstName = "Ivar";
            p2.LastName = "Integer";
            p2.Address.City = "SomeVille";
            realList.Add (p2);

            Person p3 = new Person();
            p3.Age = 3;
            p3.FirstName = "Sture";
            p3.LastName = "Gates";
            p3.Address.City = "Sharpston";
            realList.Add (p3);


            Person p4 = new Person();
            p4.Age = 55;
            p4.FirstName = "Bill";
            p4.LastName = "Gates";
            p4.Address.City = "larsson";
            realList.Add (p4);

            Person p5 = new Person();
            p5.Age = 30;
            p5.FirstName = null;
            p5.LastName = "Johansson";
            p5.Address.City = "Somewhere";
            realList.Add (p5);


            
            ////sort
            //RunQuery("order by LastName desc,FirstName asc", realList);

            ////not null
            //RunQuery("where FirstName != null", realList);

            ////sql like
            //RunQuery("where FirstName like 'b%'", realList);

            ////filter on method result
            //RunQuery("where SomeMethod(Age + 3) != 12", realList);

            //property path 
            RunQuery("where Address.MyMethod() like 'LARSSON' order by Address.MyMethod() Asc", realList);


            ////complex 
            //RunQuery("where Address.City like 's%' and (FirstName != null or LastName = 'Johansson')", realList);

            

            Console.ReadLine ();

        }

        private static void RunQuery(string npathQuery, List<Person> realList)
        {
            Console.WriteLine ("Running query:");
            Console.WriteLine (npathQuery);
            Console.WriteLine ();
            SimpleEngine engine = new SimpleEngine();
            IList<Person> resultList;


            //run the query
            resultList = engine.Select<Person>(npathQuery, realList);
            
            //-------------

            int i=1;
            foreach (Person person in resultList)
            {
                Console.WriteLine("{0} {1} {2}", i,person.FirstName, person.LastName);
                i++;
            }
            Console.WriteLine ("-----------------------------------------");
        }
    }
}
