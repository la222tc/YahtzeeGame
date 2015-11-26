using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yahtzee.View;
using Yahtzee.Model;

namespace Yahtzee.Controller
{
    class StrictYahtzeeController : YahtzeeController
    {
        StrictYahtzeeView m_yahtzeeView = new StrictYahtzeeView();
        public void runStrictYahtzee()
        {
            m_yahtzeeView.showStrictYahtzeeMenu();
            var input = Console.ReadKey();
            switch (input.Key)
            {
                //Play Strict Yahtzee
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    // 2 = Strict Yahtzee
                    setVersionOfGame(2);
                    playGame();
                    break;

                //Show Compact list
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    DBYahtzee db = new DBYahtzee();
                    List<Player> pl = db.getEndGameScore();
                    ScoreListView scoreList = new ScoreListView();
                    scoreList.showCompactList(pl);
                    runStrictYahtzee();
                    break;

                // Show Detailed list
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    DBYahtzee db2 = new DBYahtzee();
                    List<Player> pl2 = db2.getEndGameScore();
                    ScoreListView scoreList2 = new ScoreListView();
                    scoreList2.showDetailedList(pl2);
                    runStrictYahtzee();
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    MasterController mc = new MasterController();
                    mc.run();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    runStrictYahtzee();
                    break;
            }

        }
    }
}
