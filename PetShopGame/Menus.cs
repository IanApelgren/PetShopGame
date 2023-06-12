/*
 * Menus houses all the text and decision making for the interface of the game
 * it also handles all interaction with the pet list and passes most of the grunt work to it to interact with specific animals
 */

using System;
using System.Collections.Generic;


namespace PetShopGame
{
    internal class Menus
    {
        public static PetList list = new PetList();

        //main is the primary menu users interact with and is where most of the movement through the game is done
        public static void DisplayMain()
        {
            Console.WriteLine("Input the number of what you would like to do.");
            Console.WriteLine("1. See list of avalible pets.");
            Console.WriteLine("2. Get a new pet from the store.");
            Console.WriteLine("3. Give up a pet for addoption.");
            Console.WriteLine("4. Feed one of your pets.");
            Console.WriteLine("5. Interact with one of your pets.");
            Console.WriteLine("6. Let two pets play together");
            Console.WriteLine("7. See the current state of your pets.");
            string input = Console.ReadLine();
            mainMenuChoice(input);
        }

        //looks at your choice for the next menu to move to
        private static void mainMenuChoice(string input)
        {
            switch (input)
            {
                case "1":
                    petsInStoreMenu();
                    break;

                case "2":
                    getPetsMenu();
                    break;

                case "3":
                    removePetsMenu();
                    break;

                case "4":
                    feedingMenu();
                    break;

                case "5":
                    interactMenu();
                    break;

                case "6":
                    petsPlayMenu();
                    break;

                case "7":
                    statusMenu();
                    break;

                default:
                    Console.WriteLine("make sure you use the number with no spaces.");
                    backToMain();
                    break;

                    
            }
            
        }
        //listing for all the pets you cant interact from this menu
        public static void petsInStoreMenu()
        {
            Console.WriteLine("Here is a list of the currently purchasable pets.");
            Console.WriteLine("1. Cats.");
            Console.WriteLine("2. Dogs.");
            Console.WriteLine("More may come in the future press any button to return to the main menu.");
            backToMain();
        }

        //uses the print list function in petlists to get the status of all animals
        private static void statusMenu()
        {
            list.printLists();
            backToMain();
        }

        //two pets playing together gathers name and type for playtogether function in petList
        private static void petsPlayMenu()
        {
            Console.WriteLine("Sure, is your first animal a.");
            Console.WriteLine("1. A cat.");
            Console.WriteLine("2. A dog.");
            string input1 = Console.ReadLine();
            Console.WriteLine("and its name is?");
            string name1 = Console.ReadLine();
            Console.WriteLine("Great, and the second?");
            Console.WriteLine("1. A cat.");
            Console.WriteLine("2. A dog.");
            string input2 = Console.ReadLine();
            Console.WriteLine("and its name is?");
            string name2 = Console.ReadLine();
            list.playTogether(input1, name1, input2, name2);
            backToMain() ;
        }

        //the menu and function for the interactions collects data before passing it to the interact animals notembly lacking code for edge cases
        private static void interactMenu()
        {
            Console.WriteLine("Sure, do you want to play with a.");
            Console.WriteLine("1. A cat.");
            Console.WriteLine("2. A dog.");
            string input = Console.ReadLine();
            Console.WriteLine("and what was the name?");
            string name = Console.ReadLine();
            Console.WriteLine("what would you like to do with them?");
            Console.WriteLine("1. Pet them.");
            Console.WriteLine("2. Rub their belly.");
            Console.WriteLine("3. Play fetch with them.");
            Console.WriteLine("4. Ignore them.");
            Console.WriteLine("5. Scold them.");
            string choice = Console.ReadLine();
            list.interactAnimal(input, name, choice);
            backToMain();
        }

        //similar to the interaction menu for feeding a single pet.
        private static void feedingMenu()
        {
            Console.WriteLine("Sure, do you want to play with a.");
            Console.WriteLine("1. A cat.");
            Console.WriteLine("2. A dog.");
            string input = Console.ReadLine();
            Console.WriteLine("and what was the name?");
            string name = Console.ReadLine();
            Console.WriteLine("what would you like to feed them?");
            Console.WriteLine("1. Bacon Snack.");
            Console.WriteLine("2. Dry dog food.");
            Console.WriteLine("3. Tuna.");
            Console.WriteLine("4. Dry cat food.");
            string choice = Console.ReadLine();
            list.feedAnimal(input, name, choice);
            backToMain();
        }

        //menu for removing pets
        private static void removePetsMenu()
        {
            Console.WriteLine("Sure, do you want to get rid of.");
            Console.WriteLine("1. A cat.");
            Console.WriteLine("2. A dog.");
            string input = Console.ReadLine();
            removeMenuChoice(input);

        }

        //the work required to remove a pet passes it down to list function notably doesnt work properly a different storage tpye would probably be my solution
        private static void removeMenuChoice(string input)
        {
            switch (input)
            {
                case "1":
                    Console.WriteLine("Whats the cats name?");
                    string catname = Console.ReadLine();
                    list.removeCat(catname);
                    backToMain();
                    break;
                case "2":
                    Console.WriteLine("Whats the dogs name?");
                    string dogname = Console.ReadLine();
                    list.removeDog(dogname);
                    backToMain();
                    break;
                default:
                    backToMain();
                    break;

            }
        }

        //the text menu for getting a new animal
        private static void getPetsMenu()
        {
            Console.WriteLine("Sure, imput the number of the animal you would like to add.");
            Console.WriteLine("1. A cat.");
            Console.WriteLine("2. A dog.");
            string input = Console.ReadLine();
            getMenuChoice(input);
        }

        //work required to get a new animal passes the work down to the list function
        private static void getMenuChoice(string input)
        {
            switch (input)
            {
                case "1":
                    Console.WriteLine("What would you like to name it?");
                    string catname = Console.ReadLine();
                    list.addCat(catname);
                    backToMain();
                    break;
                case "2":
                    Console.WriteLine("What would you like to name it?");
                    string dogname = Console.ReadLine();
                    list.addDog(dogname);
                    backToMain();
                    break;
                default:
                    backToMain();
                    break;

            }
        }

        //clears the console and displays the main menu
        public static void backToMain()
        {
            Console.WriteLine("input anything to return");
            string waiting = Console.ReadLine();
            Console.Clear();
            DisplayMain();
        }

        //takes the timer from launcher and notifies the list with it to update the hunger of your pets
        public static void timerGoesOff()
        {
            list.updateHunger();
        }
       

    }
}
