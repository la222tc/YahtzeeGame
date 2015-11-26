using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yahtzee.Model;
using Yahtzee.View;

namespace Yahtzee.View
{
    class ScoreListView
    {

        public void showCompactList(List<Player> players)
        {
            Console.Clear();
            for (int i = 0; i < players.Count; i++)
            {

                Console.WriteLine("Date: " + players[i].getDate());
                Console.WriteLine("Name: " + players[i].getName());
                Console.WriteLine("Total Score : " + players[i].getTotalScore());
                Console.WriteLine();
                Console.WriteLine("---------------------------");
            }

            showPressToBack();
            Console.ReadLine();
        }

        public void showDetailedList(List<Player> players)
        {
            Console.Clear();
            ClassicYahtzeeView yw = new ClassicYahtzeeView();
            yw.showBoard(players);
            for (int i = 0; i < players.Count; i++)
            {

                Console.WriteLine("Date: " + players[i].getDate());
                Console.WriteLine("Name: " + players[i].getName());
                Console.WriteLine("---------------------------");
            }
            showPressToBack();
            Console.ReadLine();
        }

        private void showPressToBack()
        {
            Console.WriteLine("Press any key to back");
        }
    }
}
