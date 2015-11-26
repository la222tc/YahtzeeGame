using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yahtzee.Model;

namespace Yahtzee.View
{
    class ClassicYahtzeeView
    {

        private int h = 70;
        private int w = 140;


        public void showClassicYahtzeeMenu()
        {
            Console.Clear();
            Console.WriteLine("--- Welcome to Linus Yahtzee Game ---");
            Console.WriteLine("1. Play Classic Yahtzee");
            Console.WriteLine("2. Show Compact score list");
            Console.WriteLine("3. Show Detailed score list");
            Console.WriteLine("4. Load Game");
            Console.WriteLine("5. Back");
        }
        public void rollTheDiceMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Press r to roll the dice | Esc to quit game");
        }
        public void showBoard(List<Player> players)
        {
            Console.SetWindowSize(w, h);
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("Name                |\t");
            foreach(Player player in players){
                Console.Write(player.getName());
                Console.Write("\t|");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");

            Console.Write("A : Ones            |\t");

            foreach (Player player in players)
            {
                Console.Write(player.getOnes());
                Console.Write("\t|");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("B : Twos            |\t");

            foreach (Player player in players)
            {
                Console.Write(player.getTwos());
                Console.Write("\t|");
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("C : Threes          |\t");
            foreach (Player player in players)
            {
                Console.Write(player.getThrees());
                Console.Write("\t|");
            }


            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("D : Fours           |\t");

            foreach (Player player in players)
            {
                Console.Write(player.getFours());
                Console.Write("\t|");
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("E : Fives           |\t");

            foreach (Player player in players)
            {
                Console.Write(player.getFives());
                Console.Write("\t|");
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("F : Sixes           |\t");

            foreach (Player player in players)
            {
                Console.Write(player.getSixes());
                Console.Write("\t|");
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("    Bonus           |\t");
            foreach (Player player in players)
            {
                Console.Write(player.getBonus());
                Console.Write("\t|");
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("    Upper-Score     |\t");
            foreach (Player player in players)
            {
                Console.Write(player.getUpperScore());
                Console.Write("\t|");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("G : Three-Of-A-Kind |\t");

            foreach (Player player in players)
            {
                Console.Write(player.getThreeOfAKind());
                Console.Write("\t|");
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("H : Four-Of-A-Kind  |\t");

            foreach (Player player in players)
            {
                Console.Write(player.getFourOfAKind());
                Console.Write("\t|");
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("I : Full House      |\t");

            foreach (Player player in players)
            {
                Console.Write(player.getFullHouse());
                Console.Write("\t|");
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("J : Small Straight  |\t");

            foreach (Player player in players)
            {
                Console.Write(player.getSmallStraight());
                Console.Write("\t|");
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("K : Large Straight  |\t");

            foreach (Player player in players)
            {
                Console.Write(player.getLargeStraight());
                Console.Write("\t|");
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("L : Chance          |\t");

            foreach (Player player in players)
            {
                Console.Write(player.getChance());
                Console.Write("\t|");
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("M : Yahtzee         |\t");

            foreach (Player player in players)
            {
                Console.Write(player.getYahtzee());
                Console.Write("\t|");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("Total Score         |\t");
            foreach (Player player in players)
            {
                Console.Write(player.getTotalScore());
                Console.Write("\t|");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
        }

       
        public void showPlayersTurn(Player p)
        {
            Console.WriteLine("Player {0} turn to roll", p.getName());
        }

        public void showDices(int[] dices)
        {
            Console.WriteLine();
            Console.WriteLine("Your dices:");
            for (int i = 0;  i < dices.Length; i++)
            {
                Console.Write(dices[i] + " : ");
             }
            Console.WriteLine();
           // Console.ReadLine();
        }
        public void showFinalDices(int[] dices)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Your final Dices:");
            for (int i = 0; i < dices.Length; i++)
            {
                Console.Write(dices[i] + " : ");
            }
            Console.WriteLine();
            // Console.ReadLine();
        }

        public void showIfUserWantsToHold()
        {

            Console.WriteLine("What die's do you like to hold?");
            Console.WriteLine("Press 1-5 to hold your desired dice or just enter for new roll");
            Console.WriteLine("1 beeing the first die and 5 beeing the last die");

        }

        public void showTheDicesHeld(int[] dices)
        {
            Console.WriteLine("Your dices held:");
            for ( int i = 0; i < dices.Length; i++)
             {
                Console.Write(dices[i] + " : ");                
            }
        }

        public void showChangeHeld()
        {
            Console.WriteLine("If you want do change your dices, press c");
            Console.WriteLine("Else choose another dice or press h to hold your dices as they are");
        }

        public void showWereToPlaceScore()
        {
            Console.WriteLine("Choose a Place to put your score in");
            Console.WriteLine("Press A-M.");
        }

        public void showSaveMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Press s to save and QUIT the game and make sure all players have done there turn");
        }

    }
}
