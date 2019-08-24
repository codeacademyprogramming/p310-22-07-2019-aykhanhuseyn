using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person { Birthday = new DateTime(1995, 10, 10), Name = "Aykhan", Surname = "Huseyn" };
            Person p2 = new Person { Birthday = new DateTime(1995, 10, 10), Name = "Orkhan", Surname = "Huseyn" };
            Person p3 = new Person { Birthday = new DateTime(1992, 10, 10), Name = "Sarkhan", Surname = "Huseyn" };
            Person p4 = new Person { Birthday = new DateTime(1995, 10, 10), Name = "Elkhan", Surname = "Huseyn" };
            Person p5 = new Person { Birthday = new DateTime(1995, 10, 10), Name = "Aghakhan", Surname = "Huseyn" };
            Person p6 = new Person { Birthday = new DateTime(1995, 10, 10), Name = "Aykhan", Surname = "Huseyn" };

            //Console.WriteLine(p.CompareTo(p2));
            //Console.WriteLine(p.CompareTo(p2, "Name"));
            
            SortItems(new Person[] { p, p6, p4, p3, p2, p5 });
            //SortItem(new int[] { 1, 5, 7, 2, 5, 1, 0, 4, 7 });
            SortItem(new char[] { 'a', 'n', 'b', 'x' });
            Console.ReadLine();
        }
        static void SortItems<T>(T[] items) where T : Person  //generic method for person 
        {
            T temp;
            if (items.Length < 2)
            {
                return;
            }
            if (items.Length == 2 && items[0].CompareTo(items[1]) > 0)
            {
                temp = items[0];
                items[0] = items[1];
                items[1] = temp;
            } else
            {
                for (int j = 0; j < items.Length - 1; j++)
                {
                    for (int i = 0; i < items.Length - 1; i++)
                    {
                        if (items[i].CompareTo(items[i + 1]) < 0)
                        {
                            temp = items[i];
                            items[i] = items[i + 1];
                            items[i + 1] = temp;
                        }
                        else if (items[i].CompareTo(items[i + 1]) == 0)
                        {
                            if (items[i].CompareTo(items[i + 1], "Name") > 0)
                            {
                                temp = items[i];
                                items[i] = items[i + 1];
                                items[i + 1] = temp;
                            }
                            else if (items[i].CompareTo(items[i + 1], "Name") == 0)
                            {
                                if (items[i].CompareTo(items[i + 1], "Surname") < 0)
                                {
                                    temp = items[i];
                                    items[i] = items[i + 1];
                                    items[i + 1] = temp;
                                }
                            }
                        }
                    }
                }
            }
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        static void SortItem<T>(T[] items) where T : IComparable  //generic method for person 
        {
            T temp;
            if (items.Length < 2)
            {
                return;
            }
            if (items.Length == 2 && items[0].CompareTo(items[1]) > 0)
            {
                temp = items[0];
                items[0] = items[1];
                items[1] = temp;
            } else
            {
                for (int j = 0; j < items.Length - 1; j++)
                {
                    for (int i = 0; i < items.Length - 1; i++)
                    {
                        if (items[i].CompareTo(items[i + 1]) > 0)
                        {
                            temp = items[i];
                            items[i] = items[i + 1];
                            items[i + 1] = temp;
                        }
                    }
                }
            }
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
    class Person : IComparable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public int CompareTo(object obj)
        {
            Person person = (Person)obj;
            if (this.Birthday < person.Birthday) return -1;
            if (this.Birthday == person.Birthday) return 0;
            return 1;
        }
        public int CompareTo(object obj, string PropName)
        {
            Person person = (Person)obj;
            if (PropName == "Name") { return String.Compare(this.Name, person.Name, StringComparison.OrdinalIgnoreCase); }
            if (PropName == "Surname") { return String.Compare(this.Name, person.Name, StringComparison.OrdinalIgnoreCase); }
            throw new ArgumentOutOfRangeException($"There is no such property called {PropName}");
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
