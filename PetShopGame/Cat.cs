/*
 * the cats class uses the pet interface to implement all function related to the cat
 * includes all methods that a cat would preform in our game as well as a few helper methods to lessen the clutter there are 
 * a lot of methods but i dont know where to offset them to reasonably
 * 
 */

using System;


namespace PetShopGame
{
    internal class Cat : PetInterface
    {
        private Random rnd = new Random();
        private String name;
        private String type = "cat";
        private int hunger;
        private int happiness;

        //cat constructor for the new cat you just adopted
        public Cat(string name)
        {
            setName(name);
            setHunger(2);
            setHappiness(4);

        }

        //feeds the cat if its tuna or cat food something good happens otherwise he doesnt like it
        public void Feed(string food)
        {
            int hung = getHunger();
            int happ = getHappiness();

            //tuna
            if (food == "3")
            {
                setHunger(0);
                setHappiness(happ + 3 );
                Console.WriteLine(getName() + " seems to really like the tuna!");
            }
            //catfood
            else if (food == "4") 
            {
                setHunger(hung / 2);
                setHappiness(happ + 1);
                Console.WriteLine(getName() + " seems to enjoy the cat food!");
            }
            else
            {
                change(2, -2, " hates that and swats it away.");
            }
        }

        //interactions with the cat
        public void interact(string ract)
        {
            int hung = getHunger();
            int happ = getHappiness();
            if (okCheck())
            {
                //pet
                if (ract == "1")
                {
                    int rand = rnd.Next(1,11);
                    //70% chance they like the pet 
                    if (rand < 8)
                    {
                        change(1, 1, " seems to enjoy being pet before darting off.");
                    }
                    //30% chance they hate it
                    else
                    {
                        change(2, -2, " hisses and darts away as you go to pet him.");
                    }
                }
                //ignore
                else if (ract == "4")
                {
                    change(1, 2, " works furiously to get your attention.");
                }
                else
                {
                    change(2, -2, " hates whatever your trying to do.");
                }
            }
            else
            {
                Console.WriteLine(getName() + " is too uncomfortable to play");
            }
        }

        //returns true if the cat is to hungry to play :(
        public bool isHungry()
        {
            int i = getHunger();
            Boolean ret;
            if (i == 8)
            {
                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;
        }

        //returns true if the cat is to sad to play :(((
        public bool isSad()
        {
            int i = getHappiness();
            Boolean ret;
            if (i == 0)
            {
                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;
        }

        //checks to make sure the cat is ok to play
        public bool okCheck()
        {
            Boolean ret;
            if (isHungry() == false && isSad() == false)
            {
                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;
        }

       //decrements hunger and happiness when called
        public void timePasses()
        {
            change(1 , -1 , " is getting a little more grumpy and hungry.");
        }

        //playing vs a cat
        public void vsCat()
        {
            if (okCheck())
            {
                int rand = rnd.Next(1, 11);
                //50% chance they like the pet 
                if (rand < 6)
                {
                    change(3, 3, " seems to enjoy enjoy playing.");
                }
                //50% chance they hate it
                else
                {
                    change(3, -3, " hisses at the other cat.");
                }
            }
            else
            {
                Console.WriteLine(getName() + " is too uncomfortable to play");
            }
        }

        //playing vs a dog
        public void vsDog()
        {
            if (okCheck())
            {
                change(4, -4, " doesnt enjoy playing with that dog.");
            }
            else
            {
                Console.WriteLine(getName() + " is too uncomfortable to play");
            }
        }

        
        //prints out the cats status
        public void stats()
        {
            Console.WriteLine("this is " + getName() + " the " + getType() + " they are " + getHunger() + " hungry and " + getHappiness() + " happy.");
        }

        //gets the name
        public string getName()
        {
            return name;
        }

        //sets the name should only be done by constructor
        private void setName(string name)
        {
            this.name = name;
        }

        //get what type of animal we got
        public string getType()
        {
            return type;
        }
        
        //sets the hunger wont go above or bellow constraints
        public void setHappiness(int i)
        {
            if (i > 5)
            {
                i = 5;
            }
            else if (i < 0)
            {
                i = 0;
            }
            happiness = i;
        }

        //gets the happines
        public int getHappiness()
        {
                return happiness;
        }

        //sets the happiness wont go above or bellow constarints
        public void setHunger(int i)
        {
            if (i > 8)
            {
                i = 5;
            }
            else if (i < 0)
            {
                i = 0;
            }
            hunger = i;
        }

        //gets hunger
        public int getHunger()
        {
            return hunger;
        }

        //used to set hunger and happiness and output a line of text
        public void change(int hung, int happ, string input)
        {
            int hungry = getHunger() + hung;
            int happy = getHappiness() + happ;
            setHappiness(happy);
            setHunger(hungry);
            Console.WriteLine(getName() + input);
        }

    }
}
