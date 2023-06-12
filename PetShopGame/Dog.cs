/*
 * similar to cats dogs houses all the functions needed for our dog implemented through the pet interface
 * includes all methods that a cat would preform in our game as well as a few helper methods to lessen the clutter there are 
 * a lot of methods but i dont know where to offset them to reasonably
 * 
 */

using System;


namespace PetShopGame
{
    internal class Dog : PetInterface
    {
        private String name;
        private String type = "dog";
        private int hunger;
        private int happiness;

        //dog constructor for the new dog you just adopted
        public Dog(string name)
        {
            setName(name);
            setHunger(2);
            setHappiness(5);

        }

        //feeds the dog if its a snack or dog food something good happens otherwise he doesnt like it
        public void Feed(string food)
        {
            int hung = getHunger();
            int happ = getHappiness();

            //dog food
            if (food == "2")
            {
                setHunger(0);
                setHappiness(happ + 1);
                Console.WriteLine(getName() + " seems to really like the dog food!");
            }
            //bacon snack
            else if (food == "1")
            {
                setHunger(hung / 2);
                setHappiness(happ + 1);
                Console.WriteLine(getName() + " seems to enjoy the bacon snack!");
            }
            else
            {
                change(2, -2, " refuses to eat it.");
            }
        }

        //interactions with the dog
        public void interact(string ract)
        {
            if (okCheck())
            {
                //pet
                if (ract == "2")
                {
                    change(1, 1, " really enjoys that belly rub.");
                }
                //fetch
                else if (ract == "3")
                {
                    change(3, 2, " loves playing fetch!");
                }
                else
                {
                    change(2, -2, " wimpers.");
                }
            }
        }

        //returns true if the dog is to hungry to play :(
        public bool isHungry()
        {
            int i = getHunger();
            Boolean ret;
            if (i == 10)
            {
                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;
        }

        //returns true if the dog is to sad to play :(((
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

        //checks to make sure the dog is ok to play
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
            change(1, -1, " is getting a little more irritated and hungry.");
        }

        //playing vs a cat
        public void vsCat()
        {
            if (okCheck())
            {
                change(4, -4, " barks furiosly at the cat.");           
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
                change(3, 3, " really loves playing with another dog!");
            }
            else
            {
                Console.WriteLine(getName() + " is too uncomfortable to play");
            }
        }


        //prints out the dogs status
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
            if (i > 10)
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
            if (i > 10)
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
