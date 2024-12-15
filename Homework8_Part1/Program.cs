internal class Program
{
    private static void Main(string[] args)
    {

        /*1-In the land of Puzzlevania, Aaron, Bob, and Charlie had an argument over which one of them was the greatest puzzler of all time. To end the argument once and for all, they agreed on a duel to the death. Aaron was a poor shooter and only hit his target with a probability of 1/3.  Bob was a bit better and hit his target with a probability of ½. Charlie was an expert marksman and hit 99.5% of his shots.  A hit means a kill and the person hit drops out of the duel.

To compensate for the inequities in their marksmanship skills, the three decided that they would fire in turns, starting with Aaron, followed by Bob, and then by Charlie.  The cycle would repeat until there was one man standing, and that mans would be the Greatest Duelist of All-Time.

 An obvious and reasonable strategy is for each man to shoot at the most accurate shooter still alive, on the grounds that this shooter is the deadliest and has the best chance of hitting back.

Write a program to simulate the duel using this strategy.  Your program should use random numbers and the probabilities given in the problem to determine whether a shooter hits the target.  Create a class named Duelist that contains the dueler’s name and shooting accuracy, a Boolean indicating whether the dueler is still alive, and a method ShootAtTarget(Duelist target) that sets the target to dead if the dueler hits his target (using a random number and the shooting accuracy) and does nothing otherwise.  Use properties for your Duelist class.

Once you can simulate a single duel, add a loop to your program that simulates 10,000 duels.  Count the number of times that each contestant wins and print the probability of winning for each contestant (ie for Aaron your program might output “Aaron won 3595/10000 duels or 35.95%).
         * 
         */
        Duelist aaron = new Duelist("Aaron", 0.33, true);
        Duelist bob = new Duelist("Bob", 0.5, true);
        Duelist charlie = new Duelist("Charlie", .995, true);
        const int NUMBER_OF_DUELS = 10000;
        int aaronWins = 0;
        int bobWins = 0;
        int charlieWins = 0;





        //for loop for 10000 duels

        for (int i = 0; i < NUMBER_OF_DUELS; i++)
        {
            //reset the life of the duelists
            aaron.setLife(true);
            bob.setLife(true);
            charlie.setLife(true);
            
            //Console.WriteLine("First duel");
            //1st turn Aaron
            aaron.ShootAtTarget(charlie);

            if (charlie.getLife() == false)
            {
                Console.WriteLine("Charlie is dead");
                bob.ShootAtTarget(aaron);
            }
            else
            {
                Console.WriteLine("Charlie is alive");
                bob.ShootAtTarget(charlie);
            }

            //2nd turn Bob
            bob.ShootAtTarget(charlie);

            if (charlie.getLife() == false)
            {
                Console.WriteLine("Charlie is dead");
            }
            else
            {
                Console.WriteLine("Charlie is alive");
                charlie.ShootAtTarget(bob);
            }
            //3rd turn Charlie
            charlie.ShootAtTarget(bob);
            if (bob.getLife() == false)
            {
                Console.WriteLine("Bob is dead");
                charlie.ShootAtTarget(aaron);
            }
            else
            {
                Console.WriteLine("Bob is alive");
                charlie.ShootAtTarget(bob);
            }

            //check who is alive
            if (aaron.getLife() == true)
            {
                aaronWins++;
            }
            else if (bob.getLife() == true)
            {
                bobWins++;
            }
            else if (charlie.getLife() == true)
            {
                charlieWins++;
            }
           

        } // end of for loop
          //print the results
        Console.WriteLine("Aaron won " + aaronWins + "/10000 duels.");
        Console.WriteLine("Bob won " + bobWins + "/10000 duels.");
        Console.WriteLine("Charlie won " + charlieWins + "/10000 duels.");






    }

    class Duelist
    {
        private string name;
        private double shootingAccuracy;
        private Boolean life;


        //constructor
        public Duelist() { }

        public Duelist(string name, double shootingAccuracy, Boolean life)
        {
            this.name = name;
            this.shootingAccuracy = shootingAccuracy;
            this.life = life;
        }

        //setters and getters
        string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }

        double getShootingAccuracy()
        {
            return shootingAccuracy;
        }
        public void setShootingAccuracy(double shootingAccuracy)
        {
            this.shootingAccuracy = shootingAccuracy;
        }

         public Boolean getLife()
        {
            return life;
        }
        public void setLife(Boolean life)
        {
            this.life = life;
        }

        //methods
        public void ShootAtTarget(Duelist target)
        {
            Random random = new Random();
            double randomValue = random.NextDouble(); //random number between 0 and 1
            if (randomValue < shootingAccuracy)
            {
                target.setLife(false);
            }
        }


    }
}