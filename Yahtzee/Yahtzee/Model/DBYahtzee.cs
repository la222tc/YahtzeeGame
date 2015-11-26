using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Yahtzee.Model
{
    class DBYahtzee
    {
        private static string endGameScorePath = "ClassicYahtzeeList.txt";
        private static string onGoingGamePath = "OngoingGame.txt";
        List<Player> listOfPlayers = new List<Player>();

        public void addData(Player player)
        {
            listOfPlayers.Add(player);
        }
        public void saveOnGoingScore(List<Player> players)
        {
            //serialize
            using (Stream stream = File.Open(onGoingGamePath, FileMode.Create, FileAccess.Write))
            {
                var bformatter = new BinaryFormatter();

                bformatter.Serialize(stream, players);

            }
        }

        public List<Player> getOnGoingScore()
        {
            try
            {
                using (Stream stream = File.Open(onGoingGamePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
                {
                    var bformatter = new BinaryFormatter();
                   
                    return (List<Player>)bformatter.Deserialize(stream);;
                }
            }
            catch (Exception)
            {
                return null;
            }

        }
        public void saveEndGameScore()
        {

            //serialize
            using (Stream stream = File.Open(endGameScorePath, FileMode.Create, FileAccess.Write))
            {
                var bformatter = new BinaryFormatter();

                bformatter.Serialize(stream, listOfPlayers);

                listOfPlayers.Clear();
            }
        }

        public List<Player> getEndGameScore()
        {
            listOfPlayers.Clear();
            try
            {
                using (Stream stream = File.Open(endGameScorePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
                {
                    var bformatter = new BinaryFormatter();
                    listOfPlayers = (List<Player>)bformatter.Deserialize(stream);
                    return listOfPlayers;
                }
            }
            catch (Exception)
            {
                return listOfPlayers;
            }

        }
    }
}
