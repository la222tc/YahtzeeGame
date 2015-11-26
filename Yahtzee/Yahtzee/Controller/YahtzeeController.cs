using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yahtzee.View;
using Yahtzee.Model;
using System.Threading;

namespace Yahtzee.Controller
{
    class YahtzeeController
    {
        MainMenuView m_mainMenuView = new MainMenuView();
        ClassicYahtzeeView m_yahtzeeView = new ClassicYahtzeeView();
        YahtzeeGame m_yahtzeeGame = new YahtzeeGame();
        private bool loadedGame = false;

        // 1 = Classic Yahtzee
        // 2 = Strict Yahtzee
        private int versionOfGame;

        List<Player> playerList = new List<Player>();

        protected List<Player> checkIfAnySavedGame()
        {
            return m_yahtzeeGame.getOnGoingGame();
        }
        protected void setVersionOfGame(int number)
        {
            versionOfGame = number;
        }
        protected void setLoadedGameTrue()
        {
            loadedGame = true;
        }
        protected void playGame()
        {
            bool playGame = true;
            if (loadedGame == false)
            {
                m_mainMenuView.showYahtzeeHeader();
                m_mainMenuView.showYahtzeMenu();
                m_yahtzeeGame.chooseNumberOfPlayers();
            }

            playerList = m_yahtzeeGame.getPlayers();
            do
            {

                m_mainMenuView.showYahtzeeHeader();
                m_yahtzeeView.showBoard(playerList);

                for (int i = 0; i < playerList.Count; i++)
                {
                    m_yahtzeeView.showPlayersTurn(playerList[i]);
                    m_yahtzeeView.rollTheDiceMessage();

                    while (true)
                    {
                        try
                        {
                            m_yahtzeeView.showSaveMessage();

                            //check if player list holds a computer player
                            //then skip read key and switch statement and do the 
                            //call the computer roll sequence
                            //read more in the ComputerPlayer class

                            var input = Console.ReadKey();
                            switch (input.Key)
                            {
                                case ConsoleKey.R:
                                    int[] dices = sequenceRollOfDices(playerList[i]);
                                    m_yahtzeeView.showWereToPlaceScore();
                                    switch (versionOfGame)
                                    {
                                        case 1:
                                            playerList[i].placePlayerScore(dices);
                                            break;
                                        case 2:
                                            //Adds 1 to numbers of turns the player as done, 13 is max
                                            playerList[i].addOneToNumbersOfTurn();
                                            playerList[i].placePlayerScoreInOrder(dices, playerList[i].getNumbersOfTurn());
                                            break;
                                    }

                                    playerList[i].updateUpperScore();
                                    playerList[i].updateTotalScore();

                                    m_mainMenuView.showYahtzeeHeader();
                                    m_yahtzeeView.showBoard(playerList);
                                    if (playerList[i].checkIfEndOfGame())
                                    {
                                        playGame = false;
                                    }

                                    break;
                                case ConsoleKey.S:
                                    m_yahtzeeGame.saveOnGoingGame();
                                    m_mainMenuView.showPressAnyKeyToQuit();
                                    Console.ReadLine();
                                    Environment.Exit(0);
                                    break;

                                case ConsoleKey.Escape:
                                    Environment.Exit(0);
                                    break;
                            }
                            break;
                        }
                        catch (Exception)
                        {
                            m_mainMenuView.showYahtzeeHeader();
                            m_yahtzeeView.showBoard(playerList);
                            m_yahtzeeView.showPlayersTurn(playerList[i]);
                            m_yahtzeeView.rollTheDiceMessage();
                        }
                    }
                    playerList[i].setDate();

                }

            } while (playGame);

            m_mainMenuView.showPressAnyKeyToGoBackToMainMenu();
            m_yahtzeeGame.saveEndGameScore();
            Console.ReadLine();
            MasterController mc = new MasterController();
            mc.run();
        }

        protected int[] sequenceRollOfDices(Player player)
        {
            int sleep = 2000;
            //First roll
            int[] rollDice = m_yahtzeeGame.rollDice(player);
            m_yahtzeeView.showDices(rollDice);
            m_yahtzeeView.showIfUserWantsToHold();

            //Checks if player wants to hold any dices
            int[] diceHold = m_yahtzeeGame.holdedDice();

            //User Pressed enter and not held any dices
            if (diceHold == null || diceHold.Length == 0)
            {
                //Second roll
                rollDice = m_yahtzeeGame.rollDice(player);
                m_yahtzeeView.showDices(rollDice);
                m_yahtzeeView.showIfUserWantsToHold();

                //Checks if player wants to hold any dices
                diceHold = m_yahtzeeGame.holdedDice();

                //User Pressed enter and not held any dices
                //Returns the last roll of dices
                if (diceHold == null || diceHold.Length == 0)
                {
                    //Third roll
                    rollDice = m_yahtzeeGame.rollDice(player);
                    m_yahtzeeView.showDices(rollDice);
                    m_yahtzeeView.showFinalDices(player.getRolledDices());
                    Thread.Sleep(sleep);
                    return player.getRolledDices(); ;
                }
                //User wanted to hold dice's
                else
                {
                    //Holds the dices in array
                    diceHold = m_yahtzeeGame.holdDice(player, diceHold, rollDice);
                    m_yahtzeeView.showTheDicesHeld(diceHold);

                    //Rolls the remaining dices
                    //Third roll
                    rollDice = m_yahtzeeGame.rollDice(player);

                    m_yahtzeeView.showFinalDices(player.getRolledDices());
                    Thread.Sleep(sleep);
                    //returns the final dices
                    return player.getRolledDices();
                }
            }

            //User wanted to hold dice's
            else
            {

                diceHold = m_yahtzeeGame.holdDice(player, diceHold, rollDice);
                m_yahtzeeView.showTheDicesHeld(diceHold);

                //Second roll
                rollDice = m_yahtzeeGame.rollDice(player);
                m_yahtzeeView.showDices(rollDice);
                m_yahtzeeView.showIfUserWantsToHold();

                //Checks if player wants to hold any dices
                int[] diceHold2 = m_yahtzeeGame.holdedDice();
                if (diceHold2 == null || diceHold2.Length == 0)
                {
                    //Third roll
                    rollDice = m_yahtzeeGame.rollDice(player);
                    m_yahtzeeView.showDices(rollDice);

                    m_yahtzeeView.showFinalDices(player.getRolledDices());
                    Thread.Sleep(sleep);
                    //returns the final dices
                    return player.getRolledDices();
                }
                else
                {
                    diceHold = m_yahtzeeGame.holdDice(player, diceHold2, rollDice);
                    m_yahtzeeView.showTheDicesHeld(diceHold);

                    rollDice = m_yahtzeeGame.rollDice(player);
                    m_yahtzeeView.showDices(rollDice);

                    m_yahtzeeView.showFinalDices(player.getRolledDices());
                    Thread.Sleep(sleep);
                    //returns the final dices
                    return player.getRolledDices();
                }
            }

        }
    }
}
