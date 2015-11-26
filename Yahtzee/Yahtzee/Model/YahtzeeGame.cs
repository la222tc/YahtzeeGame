using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yahtzee.View;
using Yahtzee.Model;

namespace Yahtzee.Model
{
    class YahtzeeGame
    {
        MainMenuView m_mainMenuView = new MainMenuView();
        List<Player> playerList = new List<Player>();
        DBYahtzee db = new DBYahtzee();

        private static int startingDices = 5;
        public void saveOnGoingGame()
        {
            db.saveOnGoingScore(playerList);
        }
        public List<Player> getOnGoingGame()
        {
            if (db.getOnGoingScore() == null)
            {
                return db.getOnGoingScore();
            }
            playerList = db.getOnGoingScore();
            return playerList;
        }
        public void saveEndGameScore()
        {
            db.getEndGameScore();
            for (int i = 0; i < playerList.Count; i++)
            {
                db.addData(playerList[i]);
            }
            db.saveEndGameScore();
        
        }
        public int[] rollDice(Player player)
        {

            return player.rollDices(startingDices - player.getdicesTurn().Length, startingDices);
        }

        public int[] holdedDice()
        {
            int[] dicesHold = new int[0];

            while (true)
            {
                int n = 0;
                string userHold = Console.ReadLine();
                //User only enter
                if (userHold == "")
                {
                    break;
                }
                //Checks if user pressed number
                if (int.TryParse(userHold, out n))
                {
                    if (userHold.Length <= 5)
                    {
                        
                        int[] temp = new int[userHold.Length];

                        for (int i = 0; i < userHold.Length; i++)
                        {
                            temp[i] = (int)Char.GetNumericValue(userHold[i]) - 1;
                        }
                        Array.Sort(temp);
                        dicesHold = temp;
                        break;
                    }
               
                }
                
            }
            return dicesHold;
        }
        public void addPlayers(int numbPlayers)
        {

            for (int i = 0; i < numbPlayers; i++)
            {
                Player player = new Player();
                //ComputerPlayer compPlayer = new ComputerPlayer();
                m_mainMenuView.showYahtzeeHeader();
                m_mainMenuView.enterNameOfPlayer();

                string name = Console.ReadLine();

                //Check if the name is Numeric
                //Numeric == Player is a Computer
               if (player.checkIfComputerPlayer(name))
                {
                    player.setName("Comp" + i);
                }
                else
                {
                    player.setName(name);
                }
                playerList.Add(player);

            }
        }

        public List<Player> getPlayers()
        {
            return playerList;
        }
        public void chooseNumberOfPlayers()
        {
            try
            {
                int numbPlayers = int.Parse(Console.ReadLine());
                switch (numbPlayers)
                {
                    // 1 Player
                    case 1:
                        addPlayers(numbPlayers);
                        break;
                    // 2 Players
                    case 2:
                        addPlayers(numbPlayers);
                        break;
                    // 3 Players
                    case 3:
                        addPlayers(numbPlayers);
                        break;
                    // 4 Players
                    case 4:
                        addPlayers(numbPlayers);
                        break;
                    // 5 Players
                    case 5:
                        addPlayers(numbPlayers);
                        break;

                    default:
                        m_mainMenuView.showYahtzeeHeader();
                        m_mainMenuView.chooseRightNumberOfPlayers();
                        chooseNumberOfPlayers();
                        break;
                }
            }
            catch (Exception)
            {
                m_mainMenuView.showYahtzeeHeader();
                m_mainMenuView.chooseRightNumberOfPlayers();
                chooseNumberOfPlayers();
            }
        }



        public int[] holdDice(Player player, int[] diceHold, int[] rollDice)
        {
            return player.holdDice(diceHold, rollDice);
        }

    }
}
