using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatCounter {
    class Program {

        public static int CountCatsSplit(string str) {
            str = str.ToLower();
            var words = str.Split(' ');
            int count = 0;
            foreach (var word in words) {
                if (word == "cat") {
                    count++;
                }
            }
            return count;
        }

        public static int CountCatsIndex(string str) {
            int currIdx = 0;
            int count = 0;
            str = str.ToLower();
            while (currIdx < str.Length) {
                if (str.ToLower().IndexOf("cat", currIdx) != -1) {
                    currIdx = str.ToLower().IndexOf("cat", currIdx) + 1;
                    count++;
                } else {
                    currIdx = str.Length;
                }
            }
            return count;
        }

        public static int CountCatsChar(string str) {
            int count = 0;
            char first = 'n';                       //checks to see if the 'c' character was found
            char second = 'n';                      //checks to see if the 'a' character was found
            str = str.ToLower();
            foreach (char letter in str) {
                if (letter == 'c') {
                    if (first == 'n') { first = 'y'; second = 'n'; }
                } else if (letter == 'a') {
                    if (second == 'n' && first == 'y') { second = 'y'; }
                } else if (letter == 't') {
                    if (first == 'y' && second == 'y') {
                        count++;
                        first = 'n';
                        second = 'n';
                    }
                } else {
                    first = 'n'; second = 'n';
                }
            }
            return count;
        }

        static void Main(string[] args) {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine(CountCatsSplit("cat can Cat can cad cud nat bat concatenation."));
            stopwatch.Stop();
            Console.WriteLine("The first method took {0} milliseconds.", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            Console.WriteLine(CountCatsIndex("cat can Cat can cad cud nat bat concatenation."));
            stopwatch.Stop();
            Console.WriteLine("The second method took {0} milliseconds.", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            Console.WriteLine(CountCatsChar("cat can Cat can cad cud nat bat concatenation."));
            stopwatch.Stop();

            Console.WriteLine("The third method took {0} milliseconds.", stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
