using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee.Model
{
    [Serializable]
    class PlayerScores
    {
        private int? Ones = null;
        private int? Twos = null;
        private int? Threes = null;
        private int? Fours = null;
        private int? Fives = null;
        private int? Sixes = null;
        private int? Bonus = null;
        private int? Upper_Score = null;
        private int? Three_Of_A_Kind = null;
        private int? Four_Of_A_Kind = null;
        private int? Full_House = null;
        private int? Small_Straight = null;
        private int? Large_Straight = null;
        private int? Chance = null;
        private int? Yahtzee = null;
        private int? Total_Score = null;

        public int? getOnes()
        {
            return Ones;
        }

        public void setOnes(int[] number)
        {
            if (Ones == null)
            {
                int score = 0;
                for (int i = 0; i < number.Length; i++)
                {
                    if (number[i] == 1)
                    {
                        score += 1;
                    }
                }
                Ones = score;
            }
            else
            {
                throw new ArgumentException();
            }

        }

        public int? getTwos()
        {
            return Twos;
        }

        public void setTwos(int[] number)
        {
            if (Twos == null)
            {
                int score = 0;
                for (int i = 0; i < number.Length; i++)
                {
                    if (number[i] == 2)
                    {
                        score += 2;
                    }
                }
                Twos = score;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int? getThrees()
        {
            return Threes;
        }

        public void setThrees(int[] number)
        {
            if (Threes == null)
            {
                int score = 0;
                for (int i = 0; i < number.Length; i++)
                {
                    if (number[i] == 3)
                    {
                        score += 3;
                    }
                }
                Threes = score;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int? getFours()
        {
            return Fours;
        }

        public void setFours(int[] number)
        {
            if (Fours == null)
            {
                int score = 0;
                for (int i = 0; i < number.Length; i++)
                {
                    if (number[i] == 4)
                    {
                        score += 4;
                    }
                }
                Fours = score;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int? getFives()
        {
            return Fives;
        }

        public void setFives(int[] number)
        {
            if (Fives == null)
            {
                int score = 0;
                for (int i = 0; i < number.Length; i++)
                {
                    if (number[i] == 5)
                    {
                        score += 5;
                    }
                }
                Fives = score;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int? getSixes()
        {
            return Sixes;
        }

        public void setSixes(int[] number)
        {
            if (Sixes == null)
            {
                int score = 0;
                for (int i = 0; i < number.Length; i++)
                {
                    if (number[i] == 6)
                    {
                        score += 6;
                    }
                }
                Sixes = score;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int? getBonus()
        {
            if (getUpperScore() >= 63)
            {
                Bonus = 50;
            }
            return Bonus;
        }

        public int? getUpperScore()
        {
            return Upper_Score;
        }

        public void setUpperScore()
        {
            int score = 0;

            if (Ones != null)
            {
                score += (int)Ones;
            }
            if (Twos != null)
            {
                score += (int)Twos;
            }
            if (Threes != null)
            {
                score += (int)Threes;
            }
            if (Fours != null)
            {
                score += (int)Fours;
            }
            if (Fives != null)
            {
                score += (int)Fives;
            }
            if (Sixes != null)
            {
                score += (int)Sixes;
            }

            Upper_Score = score;
        }

        public int? getThreeOfAKind()
        {
            return Three_Of_A_Kind;
        }

        public void setThreeOfAKind(int[] number)
        {
            if (Three_Of_A_Kind == null)
            {
                int score = 0;
                for (int i = 0; i < number.Length; i++)
                {
                    int count = 0;
                    for (int j = 0; j < number.Length; j++)
                    {

                        if (number[i] == number[j])
                        {
                            count++;
                        }

                        if (count >= 3)
                        {
                            score = 3 * number[i];
                        }
                    }
                }
                Three_Of_A_Kind = score;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int? getFourOfAKind()
        {
            return Four_Of_A_Kind;
        }

        public void setFourOfAKind(int[] number)
        {
            if (Four_Of_A_Kind == null)
            {
                int score = 0;
                for (int i = 0; i < number.Length; i++)
                {
                    int count = 0;
                    for (int j = 0; j < number.Length; j++)
                    {

                        if (number[i] == number[j])
                        {
                            count++;
                        }

                        if (count >= 4)
                        {
                            score = 4 * number[i];
                        }
                    }
                }
                Four_Of_A_Kind = score;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int? getFullHouse()
        {
            return Full_House;
        }

          

        public void setFullHouse(int[] number)
        {
            if (Full_House == null)
            {
                bool hasTwo = false;
                bool hasThree = false;
                int score = 0;
                for (int i = 0; i < number.Length; i++)
                {
                    int count = 0;
                    for (int j = 0; j < number.Length; j++)
                    {

                        if (number[i] == number[j])
                        {
                            count++;
                        }
                    }
                    if(count == 2){
                        hasTwo = true;
                    }
                    if(count == 3){
                        hasThree = true;
                    }
                }
                if(hasTwo && hasThree){
                    for (int i = 0; i < number.Length; i++)
                    {
                        score += number[i];
                    }
                }
                Full_House = score;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int? getSmallStraight()
        {
            return Small_Straight;
        }

        public void setSmallStraight(int[] number)
        {
            if (Small_Straight == null)
            {
                Array.Sort(number);
                int score = 0;
                    if (number[0] == 1 && number[1] == 2 && number[2] == 3 
                        && number[3] == 4 && number[4] == 5)
                    {
                        score = 15;
                    }

                Small_Straight = score;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int? getLargeStraight()
        {
            return Large_Straight;
        }

        public void setLargeStraight(int[] number)
        {
            if (Large_Straight == null)
            {
                Array.Sort(number);
                int score = 0;
                if (number[0] == 2 && number[1] == 3 && number[2] == 4
                    && number[3] == 5&& number[4] == 6)
                {
                    score = 20;
                }

                Large_Straight = score;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int? getChance()
        {
            return Chance;
        }

        public void setChance(int[] number)
        {
            if (Chance == null)
            {
                int score = 0;
                    for (int i = 0; i < number.Length; i++)
                    {
                        score += number[i];
                    }
                Chance = score;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int? getYahtzee()
        {
            return Yahtzee;
        }

        public void setYahtzee(int[] number)
        {

            if (Yahtzee == null)
            {
                int score = 0;
                for (int i = 0; i < number.Length; i++)
                {
                    int count = 0;
                    for (int j = 0; j < number.Length; j++)
                    {

                        if (number[i] == number[j])
                        {
                            count++;
                        }

                        if (count >= 5)
                        {
                            score = 50;
                        }
                    }
                }
                Yahtzee = score;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int? getTotalScore()
        {
            return Total_Score;
        }

        public void setTotalScore()
        {
            int score = 0;

            if (Yahtzee != null)
            {
                score += (int)Yahtzee;
            }
            if (Chance != null)
            {
                score += (int)Chance;
            }
            if (Large_Straight != null)
            {
                score += (int)Large_Straight;
            }
            if (Small_Straight != null)
            {
                score += (int)Small_Straight;
            }
            if (Four_Of_A_Kind != null)
            {
                score += (int)Four_Of_A_Kind;
            }
            if (Three_Of_A_Kind != null)
            {
                score += (int)Three_Of_A_Kind;
            }
            if (Full_House != null)
            {
                score += (int)Full_House;
            }
            if (Bonus != null)
            {
                score += (int)Bonus;
            }

            Total_Score = score + getUpperScore();
        }
    }
}
