using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee.View
{
    [Serializable]
    class MainMenuView
    {
        public void showMainMenu()
        {
            Console.Clear();
            Console.WriteLine("--- Welcome to Linus Yahtzee Game ---");
            Console.WriteLine("1. Classic Yahtzee");
            Console.WriteLine("2. Strict-Yahtzee");
            Console.WriteLine("3. Exit");
        }

        public void showYahtzeeHeader()
        {
            Console.Clear();
            Console.WriteLine("--- Linus Yahtzee Game ---");
            Console.WriteLine("--------------------------");
            Console.WriteLine();
        }

        public void showYahtzeMenu()
        {
            Console.WriteLine("Enter Number of Players 1-5");
        }

        public void chooseRightNumberOfPlayers()
        {
            Console.WriteLine("Invalid number of players!");
            Console.WriteLine();
            Console.WriteLine("Choose Number of players between 1 and 5");
        }

        public void enterNameOfPlayer()
        {
            Console.WriteLine("If you want a computerplayer, Enter a number");
            Console.WriteLine();
            Console.Write("Enter Name: ");
        }

        public void scoreInWrongPlace()
        {
            Console.WriteLine("Please choose an empty space!");
        }

        public void showPressAnyKeyToQuit()
        {
            Console.WriteLine("Press any key to Quit");
        }

        public void showPressAnyKeyToGoBackToMainMenu()
        {
            Console.WriteLine("Press any key to get back to main menu");
        }
    }
}
