using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrarian {
    class Program {
        static void Main(string[] args) {

            string response = "";
            string contrary = "";
            Console.Write("Enter a statement: ");
            response = Console.ReadLine();
            //int helpingIndex = getHelpVerbIndex(response);
            //string notWord = getNotWord(response);
            //if (helpingIndex > -1) {
            //    if (notIndex > -1 && notIndex > helpingIndex) {
            //        contrary = response.Replace(response.Substring())
            //    }
            //}
            if (response.Contains("n't")) {
                contrary = response.Replace("n't", "");
            } else if (response.Contains(" not")) {
                contrary = response.Replace("not", "");
            } else {
                contrary = response.Insert(response.IndexOf("like"), "don't ");
            }
            Console.WriteLine(contrary);
            Console.ReadLine();


        }
        //static int getHelpVerbIndex(string str) {
        //    string[] helpVerbs = {"am", "are", "is", "was", "were", "be", "being", "been",
        //        "have", "has", "had","shall", "will","do", "does", "did","may", "must",
        //        "might","can", "could", "would", "should" };
        //    foreach (var text in helpVerbs) {
        //        if (str.Contains(text)) {
        //            return str.IndexOf(text);
        //        }
        //    }
        //    return -1;
        //}
        //static string getNotWord(string str) {
        //    string word = "";
        //    if (str.Contains("not")) {
        //        word = "not";
        //    } else if (str.Contains("n't")) {
        //        word = "n't";
        //    }
        //    return word;
        //}

    }
}