using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PreventXSS {
    public class Security {
        public string SanitizeHTML(string stringToCheck, List<string> safeTags) {
            int foundCharAt = -1;               //index of "<"
            int lastCharAt;                     //index of ">"
            int tagLength = 0;                  //length of the potentially unsafe tag
            int currIdx = 0;                    //placeholder index of the last found "<"
            string tagToCheck = "";             //tag name of the potentially unsafe tag

            //Loop through all characters of the stringToCheck, looking for instances of "<"
            for (var i = 0; i < stringToCheck.Length && currIdx < stringToCheck.Length; i++) {
                foundCharAt = stringToCheck.IndexOf("<", currIdx);

                //If "<" is found set variables pertaining to that string and check if the tag is in the list.
                if (foundCharAt != -1) {
                    tagLength = (stringToCheck.IndexOf(">", currIdx) - foundCharAt) + 1;
                    lastCharAt = foundCharAt + (tagLength - 1);
                    tagToCheck = stringToCheck.Substring(foundCharAt, tagLength);

                    //If unsafe tag is found remove ">" and "<" and insert "&lt;" and "&gt;"
                    if (!(safeTags.Contains(tagToCheck))) {
                        stringToCheck = stringToCheck.Remove(lastCharAt,1);
                        stringToCheck = stringToCheck.Insert(lastCharAt, "&gt;");
                        stringToCheck = stringToCheck.Remove(foundCharAt,1);
                        stringToCheck = stringToCheck.Insert(foundCharAt, "&lt;");
                        foundCharAt = -1;
                    }
                    currIdx = foundCharAt + tagLength;  //increase the current index.
                } else {
                    currIdx = stringToCheck.Length;
                }
            }
            return stringToCheck;
        }
    }


    public class SafeTags {

        public List<string> TagList { get; set; }

        public SafeTags() {
            TagList = new List<string>();
            if (File.Exists(@"C:\Projects\Week01\Day01-git\PreventXSS\safe_tags.txt")) {
                foreach (string item in File.ReadLines(@"C:\Projects\Week01\Day01-git\PreventXSS\safe_tags.txt")) {
                    TagList.Add(item);
                    TagList.Add(item.Insert(1, "/"));
                }

            }
        }
    }



    class Program {
        static void Main(string[] args) {
            var secure = new Security();
            var list = new SafeTags();
            Console.WriteLine(secure.SanitizeHTML("<b>hello</b><script>evil</script>", list.TagList));
            Console.ReadLine();
        }
    }
}

