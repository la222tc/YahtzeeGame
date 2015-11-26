using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yahtzee.View;
using Yahtzee.Model;

namespace Yahtzee.Controller
{
    class MasterController
    {
        MainMenuView m_mainMenuView = new MainMenuView();
        
        StrictYahtzeeController m_strictYahtzee = new StrictYahtzeeController();
        ClassicYahtzeeController m_classicYahtzee = new ClassicYahtzeeController();
      
        public void run()
        {
            m_mainMenuView.showMainMenu();

            var input = Console.ReadKey();
            switch (input.Key)
            {
                    // Classic Yahtzee
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    m_mainMenuView.showYahtzeeHeader();
                    m_mainMenuView.showYahtzeMenu();
                    
                    m_classicYahtzee.runClassicYahtzee();
                    break;

                    //Strict-Yahtzee
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    m_mainMenuView.showYahtzeeHeader();
                    m_mainMenuView.showYahtzeMenu();
                   
                    m_strictYahtzee.runStrictYahtzee();
                    break;

                //Exit program
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    run();
                    break;
            }
        }
    }
}
