using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yahtzee.View;

namespace Yahtzee.Model
{
    [Serializable]
    class Player
    {
        MainMenuView m_mainMenuView = new MainMenuView();

        
        private string name;
        private PlayerScores playerScores;
        private int[] heldDices;
        private int[] rolledDices;
        private int[] dicesTurn;
        private string date = "";
        private int numbersOfTurns;

        public Player()
        {
            playerScores = new PlayerScores();
            dicesTurn = new int[0];
            heldDices = new int[0];
        }

        public void addOneToNumbersOfTurn()
        {
            numbersOfTurns++;
        }
        public int getNumbersOfTurn()
        {
            return numbersOfTurns;
        }
        public bool checkIfComputerPlayer(string Name)
        {
            // Checl if Name is number
            int number = 0;
            bool isInt = int.TryParse(Name, out number);

            // If Name is a number then it's a Computer player else it's a Human player
            if (isInt == true)
            {
                Console.WriteLine("It's a COMPUTER!! AAAWHHA RUN!");
                return true;
            }
            else
            {
                Console.WriteLine("It's just a Human..Boring ;)");
                return false;
            }
        }

        public int[] rollDices(int numberOfDices, int totalDices)
        {
            int[] dice = new int[numberOfDices];
            Random rand = new Random();

            for (int i = 0; i < dice.Length ; i++)
            {
                dice[i] = rand.Next(1, 7);
            }
            setRolledDices(dice, totalDices);
            dicesTurn = new int[0];
            heldDices = new int[0];
            return rolledDices;

        }

        private void setRolledDices(int[] dice, int totalDices)
        {
            int[] dices = new int[totalDices];
            for (int i = 0; i < dice.Length; i++)
            {
                dices[i] = dice[i];
            }
            for (int i = 0; i < heldDices.Length; i++)
            {
                dices[i + dice.Length] = heldDices[i];
            }
            rolledDices = dices;
        }

        public string getDate()
        {
            return date;
        }
        public void setDate()
        {
            date = System.DateTime.Now.ToString("yyyy.MM.dd");
        }  
        public int[] getRolledDices()
        {
            return rolledDices;
        }
        public int[] holdDice(int[] diceHold, int[] rollDice)
        {
            int[] dicesHeld = new int[diceHold.Length];

            for (int i = 0; i < dicesHeld.Length; i++)
            {
                dicesHeld[i] = rollDice[diceHold[i]];
            }
            setDicesHeld(dicesHeld);
            setdicesTurn(dicesHeld);
            return dicesHeld;
        }

        private void setdicesTurn(int[] dicesHeld)
        {
            dicesTurn = dicesHeld;
        }
        public int[] getdicesTurn()
        {
            return dicesTurn;
        }

        public int[] getDicesHeld()
        {
            return heldDices;
        }

        private void setDicesHeld(int[] dicesHeld)
        {
            heldDices = dicesHeld;
        }

        public void placePlayerScoreInOrder(int[] dices, int numbersOfTurn)
        {
            switch (numbersOfTurns)
            {
                 case 1:
                    playerScores.setOnes(dices);
                    break;
                case 2:
                    playerScores.setTwos(dices);
                    break;
                case 3:
                    playerScores.setThrees(dices);
                    break;
                case 4:
                    playerScores.setFours(dices);
                    break;
                case 5:
                    playerScores.setFives(dices);
                    break;
                case 6:
                    playerScores.setSixes(dices);
                    break;
                case 7:
                    playerScores.setThreeOfAKind(dices);
                    break;
                case 8:
                    playerScores.setFourOfAKind(dices);
                    break;
                case 9:
                    playerScores.setFullHouse(dices);
                    break;
                case 10:
                    playerScores.setSmallStraight(dices);
                    break;
                case 11:
                    playerScores.setLargeStraight(dices);
                    break;
                case 12:
                    playerScores.setChance(dices);
                    break;
                case 13:
                    playerScores.setYahtzee(dices);
                    break;
                default:
                    m_mainMenuView.scoreInWrongPlace();
                    placePlayerScoreInOrder(dices, numbersOfTurns);
                    break;
            }
        }
        public void placePlayerScore(int[] dices)
        {

            try
            {
                switch (char.ToLower(char.Parse(Console.ReadLine())))
                {
                    case 'a':
                        playerScores.setOnes(dices);
                        break;
                    case 'b':
                        playerScores.setTwos(dices);
                        break;
                    case 'c':
                        playerScores.setThrees(dices);
                        break;
                    case 'd':
                        playerScores.setFours(dices);
                        break;
                    case 'e':
                        playerScores.setFives(dices);
                        break;
                    case 'f':
                        playerScores.setSixes(dices);
                        break;
                    case 'g':
                        playerScores.setThreeOfAKind(dices);
                        break;
                    case 'h':
                        playerScores.setFourOfAKind(dices);
                        break;
                    case 'i':
                        playerScores.setFullHouse(dices);
                        break;
                    case 'j':
                        playerScores.setSmallStraight(dices);
                        break;
                    case 'k':
                        playerScores.setLargeStraight(dices);
                        break;
                    case 'l':
                        playerScores.setChance(dices);
                        break;
                    case 'm':
                        playerScores.setYahtzee(dices);
                        break;
                    default:
                        m_mainMenuView.scoreInWrongPlace();
                        placePlayerScore(dices);
                        break;
                }
            }
            catch (Exception)
            {
                m_mainMenuView.scoreInWrongPlace();
                placePlayerScore(dices);
            }
           
        }

        public string getName()
        {
            return name;
        }

        public void setName(string Name)
        {
            name = Name;
        }

        public int? getOnes()
        {
           return playerScores.getOnes();
        }

        public int? getTwos()
        {
            return playerScores.getTwos();
        }

        public int? getThrees()
        {
            return playerScores.getThrees();
        }

        public int? getFours()
        {
            return playerScores.getFours();
        }

        public int? getFives()
        {
            return playerScores.getFives();
        }

        public int? getSixes()
        {
            return playerScores.getSixes();
        }

        public int? getBonus()
        {
            return playerScores.getBonus();
        }

        public int? getUpperScore()
        {
            return playerScores.getUpperScore();
        }

        public int? getThreeOfAKind()
        {
            return playerScores.getThreeOfAKind();
        }

        public int? getFourOfAKind()
        {
            return playerScores.getFourOfAKind();
        }

        public int? getFullHouse()
        {
            return playerScores.getFullHouse();
        }

        public int? getSmallStraight()
        {
            return playerScores.getSmallStraight();
        }

        public int? getLargeStraight()
        {
            return playerScores.getLargeStraight();
        }

        public int? getChance()
        {
            return playerScores.getChance();
        }

        public int? getYahtzee()
        {
            return playerScores.getYahtzee();
        }

        public int? getTotalScore()
        {
            return playerScores.getTotalScore();
        }

        public void updateUpperScore()
        {
            playerScores.setUpperScore();
        }

        public void updateTotalScore()
        {
            playerScores.setTotalScore();
        }


        public bool checkIfEndOfGame()
        {
            int numberOfTurns = 13;
            int count = 0;
            if (getOnes() != null)
            {
                count++;
            }
            if (getTwos() != null)
            {
                count++;
            }
            if (getThrees() != null)
            {
                count++;
            }
            if (getFours() != null)
            {
                count++;
            }
            if (getFives() != null)
            {
                count++;
            }
            if (getSixes() != null)
            {
                count++;
            }
            if (getThreeOfAKind() != null)
            {
                count++;
            }
            if (getFourOfAKind() != null)
            {
                count++;
            }
            if (getFullHouse() != null)
            {
                count++;
            }
            if (getSmallStraight() != null)
            {
                count++;
            }
            if (getLargeStraight() != null)
            {
                count++;
            }
            if (getChance() != null)
            {
                count++;
            }
            if (getYahtzee() != null)
            {
                count++;
            }

            if (count == numberOfTurns)
            {
                return true;
            }

            return false;
        }
    }
}
