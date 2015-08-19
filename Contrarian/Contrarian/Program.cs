using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrarian {
    class Program {
        static string[] HELPVERBS = {"am", "are", "is", "was", "were",
            "has", "had","shall", "will","do", "does", "did","may", "must",
            "might","can", "could", "would", "should","have"};

        static void Main(string[] args) {

            string response = "";
            string contrary = "";
            string helpVerb = "";
            Console.Write("Enter a statement: ");
            response = Console.ReadLine();

            var needNots = removeNots(ref contrary, response);
            if (needNots == true) {
                helpVerb = getHelpVerb(response);
                if (helpVerb != "") {
                    contrary = response.Insert(response.IndexOf(helpVerb) + helpVerb.Length, " not");
                } else {
                    contrary = "I'm sorry, your sentence needs a helping verb.";
                }
            }

            Console.WriteLine(contrary);
            Console.ReadLine();
        }

        static bool removeNots(ref string contrary, string response) {
            var needNots = true;
            if (response.Contains("n't")) {
                contrary = response.Replace("n't", "");
                needNots = false;
            } else if (response.Contains("not")) {
                contrary = response.Replace("not ", "");
                needNots = false;
            }
            return needNots;
        }

        static string getHelpVerb(string str) {
            foreach (var text in HELPVERBS) {
                if (str.Contains(text)) {
                    return text;
                }
            }
            return "";
        }
    }


}
