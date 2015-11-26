using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yahtzee.View;
using Yahtzee.Model;

namespace Yahtzee.Controller
{
    class ClassicYahtzeeController : YahtzeeController
    {
        ClassicYahtzeeView m_yahtzeeView = new ClassicYahtzeeView();
        YahtzeeGame m_yahtzeeGame = new YahtzeeGame();

        
        public void runClassicYahtzee()
        {
            m_yahtzeeView.showClassicYahtzeeMenu();
            var input = Console.ReadKey();
            switch (input.Key)
            {
                //Play Classic Yahtzee
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    // 1 = Classic Yahtzee
                    setVersionOfGame(1);
                    playGame();
                    break;

                //Show Compact list
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    DBYahtzee db = new DBYahtzee();
                    List<Player> pl = db.getEndGameScore();
                    ScoreListView scoreList = new ScoreListView();
                    scoreList.showCompactList(pl);
                    runClassicYahtzee();
                    break;

                // Show Detailed list
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    DBYahtzee db2 = new DBYahtzee();
                    List<Player> pl2 = db2.getEndGameScore();
                    ScoreListView scoreList2 = new ScoreListView();
                    scoreList2.showDetailedList(pl2);
                    runClassicYahtzee();
                    break;
                    
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    if (checkIfAnySavedGame() == null)
                    {
                        runClassicYahtzee();
                    }
                    setLoadedGameTrue();
                    setVersionOfGame(1);
                    playGame();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    MasterController mc = new MasterController();
                    mc.run();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    runClassicYahtzee();
                    break;
            }

        }
        
        
    }
}
