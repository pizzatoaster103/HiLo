
namespace HiLo
{
    //This class is the director of the game
    public class Director
    {
        /// Keeps track of if the game is ongoing or should be ended
        public bool isPlaying;

        /// Score in-progress
        public int score;

        /// Total score for how long user has been playing
        public int totalScore;



        public Director()
        {
            score = 300;
        }
        /// <summary>
        /// Resets game values and begins the main loop
        /// </summary>

        public void StartGame()
        {
            Card card = new Card();
            bool guess = true;
            isPlaying = true;
            Console.WriteLine($"You pull a {card.num}");

            while (isPlaying)
            {
                int last_card = card.num;
                card.draw();
                guess = GetInputs();
                score += UpdateScore(card.num, last_card, guess);
                DoOutputs(card.num);
            }
        }

        ///<summary>
        /// Asks for input (higher or lower), saves to a bool where true = higher, false = lower
        ///</summary>
        public bool GetInputs()
        {
            string answer = "";
            Console.WriteLine("Higher(h) or lower(l)?");
            answer = Console.ReadLine();

            if (answer == "h")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ///Updates the score
        /// +100 for a correct guess, -75 for incorrect, 0 for same value of card
        public int UpdateScore(int current, int last, bool higher)
        {
            int points = 0;
            if (current > last)
            {
                points = (higher) ? 100 : -75;
            }
            else if (current < last)
            {
                if (higher)
                {
                    points = -75;
                }
                else
                {
                    points = 100;
                }
            }

            return points;
        }


        ///Prints the card that was drawn and points
        public void DoOutputs(int num)
        {
            Console.WriteLine($"You pulled a {num}.");
            Console.WriteLine($"Points: {score}");
            isPlaying = keepPlaying(score);
        }

        ///Asks if the player would like to keep playing
        public bool keepPlaying(int score)
        {
            string response = "n";
            if (score < 1)
            {
                Console.WriteLine("Oh no! You've lost all your points! Game over");
                return false;
            }
            else
            {
                Console.WriteLine("Keep playing? (y or n)");
                response = Console.ReadLine();
                if (response == "y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }


}
