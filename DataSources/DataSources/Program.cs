using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSources {
    class Counter {
        public static int CountWords(string str) {
            return str.Split(' ').Length;
        }
    }
    class Program {
        static void Main(string[] args) {
            var words = Counter.CountWords("This is the longest string I've ever written!");
            Console.WriteLine("The longest string you've ever written is {0} words long!", words);
            Console.ReadLine();
        }
    }

}
