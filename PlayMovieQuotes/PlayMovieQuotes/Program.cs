using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace PlayMovieQuotes {
    class Program {
        static void Main(string[] args) {
            string varURL = "";
            SoundPlayer quote = new SoundPlayer();
            Random randNum = new Random();
            int selectedQuote = (randNum.Next(1, 3));
            switch (selectedQuote) {
                case 1:
                    varURL = "http://www.wavsource.com/snds_2015-08-16_6897529750891327/tv/sharknado/sharknado_afraid.wav";
                    break;
                case 2:
                    varURL = "http://www.wavsource.com/snds_2015-08-16_6897529750891327/movies/misc/silence_lambs_dinner.wav";
                    break;
                case 3:
                    varURL = "http://www.wavsource.com/snds_2015-08-16_6897529750891327/movies/aladdin/aladdin_cant_believe.wav";
                    break;
                default:
                    break;
            }
            quote.SoundLocation = varURL;
            if (quote == null) { }
            try {
                quote.Play();
            } catch (Exception e) {
                Console.WriteLine(@"I'm sorry, you are not connected to the internet.  Please reconnect and try again.");
            }
            Console.ReadLine();
        }
    }
}
