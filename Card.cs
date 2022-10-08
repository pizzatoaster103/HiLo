
namespace HiLo
{
    public class Card
    {
        public int num;
        public int something;

        public Card()
        {
            draw();
        }

        /// Get a new card with a new number. Chooses 0-12 and adds 1 to get 1-13
        public void draw()
        {
            Random rand = new Random();
            num = rand.Next(12);
            num += 1;
        }

    }
}
//result = (scenario == 1) ? output 1: (scenario == 2) ? output 2: default output;
