using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yahtzee.Model;

namespace Yahtzee.View
{
    class StrictYahtzeeView : ClassicYahtzeeView
    {
        public void showStrictYahtzeeMenu()
        {
            Console.Clear();
            Console.WriteLine("--- Welcome to Linus Yahtzee Game ---");
            Console.WriteLine("1. Play Strict Yahtzee");
            Console.WriteLine("2. Show Compact score list");
            Console.WriteLine("3. Show Detailed score list");
            Console.WriteLine("4. Back");
        }
    }
}
