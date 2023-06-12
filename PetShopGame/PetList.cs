/*
 * PetList contains the the storage for the pet class objects created by the user and handles all the direct interaction with those objects
 * should be able to remove objects but the implementation of linked lists in c# class is outside my knowledge 
 * my idea for putting it to a save load state is to have the list stored in a text file that the menu could find again but i sadly lack the know how of C# to accomplish that
 * i am gererally unhappy with this class as there is too much nesting and its still missing a lot of checks for edge casses and im not sure how to fix it deffinatly the powerhouse of the program
 */
using System;
using System.Collections.Generic;


namespace PetShopGame
{

    internal class PetList
    {

        public static LinkedList<Dog> dogList = new LinkedList<Dog>();
        public static LinkedList<Cat> catList = new LinkedList<Cat>();

        //adds to the dog list
        public void addDog(string name)
        {
            dogList.AddLast(new Dog(name));
        }

        //adds to the cat list
        public void addCat(string name)
        {
            catList.AddLast(new Cat(name));
        }

        //prints both lists of animals
        public void printLists()
        {
            foreach (Dog dog in dogList)
            {
                dog.stats();
            }
            foreach (Cat cat in catList)
            {
                cat.stats();
            }
        }

        //this doesnt work and i dont know why
        public void removeCat(string name)
        {
            foreach (Cat cat in catList)
            {
                if (cat.getName() == name)
                {
                    catList.Remove(cat);
                }
            }
        }

        //similarly this doesnt work either and i similarly dont know why
        public void removeDog(string name)
        {
            foreach (Dog dog in dogList)
            {
                if (dog.getName() == name)
                {
                    dogList.Remove(dog);
                }
            }
        }

        //finds a cat from its repsective list
        public Cat findCat(string name)
        {
            foreach (Cat cat in catList)
            {
                if (cat.getName() == name)
                {
                    return cat;
                }
            }
            return null;
        }

        //finds a dog from its list
        public Dog findDog(string name)
        {
            foreach (Dog dog in dogList)
            {
                if (dog.getName() == name)
                {
                    return dog;
                }
            }
            return null;
        }

        //called every 2 minutes by the timer notifies all animals they are hungry
        public void updateHunger()
        {
            foreach (Dog dog in dogList)
            {
                dog.timePasses();
            }
            foreach (Cat cat in catList)
            {
                cat.timePasses();
            }
        }

        //this is for playing to gether it takes in the breed and name of the pets and applies the appropriate fuction to both notably doesnt check that both animals are real
        public void playTogether(string first, string name1, string second, string name2)
        {
            if ((!first.Equals("1") && !first.Equals ("2")) && (!second.Equals("1") && !second.Equals("2")))
            {
                return;
            }
            if (first.Equals("1"))
            {
                playCat(name1, second);
            }
            else
            {
                playDog(name1, second);
                
            }
            if (second.Equals("1"))
            {
                playCat(name2, first);
            }
            else
            {
                playDog(name2, first);
            }
        }

        //if we are playing with a dog this will see what its mached against 
        public void playDog(string name, string opponent)
        {
            foreach (Dog dog in dogList)
            {
                if (dog.getName() == name)
                {
                    if (opponent.Equals("1"))
                    {
                        dog.vsCat();
                    }
                    else
                    {
                        dog.vsDog();
                    }
                }
            }
        }

        //if we are playing with a cat send its matchup to the base class
        public void playCat(string name, string opponent)
        {
            foreach (Cat cat in catList)
            {
                if (cat.getName() == name)
                {
                    if (opponent.Equals("1"))
                    {
                        cat.vsCat();
                    }
                    else
                    {
                        cat.vsDog();
                    }
                }
            }
        }

        //interactions with the animal goes to base class
        public void interactAnimal(string input, string name, string choice)
        {
            //if input for animal type is correct
            if (!input.Equals("1") && !input.Equals("2") ) 
            {
                return;
            }

            //if were interacting with a cat
            if (input.Equals("1"))
            {
                foreach (Cat cat in catList)
                {
                    if (cat.getName() == name)
                    {
                        cat.interact(choice);
                    }
                }
            }

            //if its a dog were interacting with
            else
            {
                foreach (Dog dog in dogList)
                {
                    if (dog.getName() == name)
                    {
                        dog.interact(choice);
                    }
                }
            }
        }

        //feeds the animal passing it to the base class
        public void feedAnimal(string input, string name, string choice)
        {
            if (!input.Equals("1") && !input.Equals("2"))
            {
                return;
            }
            //if were interacting with a cat
            if (input.Equals("1"))
            {
                foreach (Cat cat in catList)
                {
                    if (cat.getName() == name)
                    {
                        cat.Feed(choice);
                    }//->>> ah the beautiful mountains...
                }
            }
            //if its a dog were interacting with
            else
            {
                foreach (Dog dog in dogList)
                {
                    if (dog.getName() == name)
                    {
                        dog.Feed(choice);
                    }
                }
            }
        }

    }
}
