/* Author: Ian Apelgren
 * This program is a coding excersise given to me by castle hill games as a practical exam
 * The purpose of this program is to emulate a pet owner where you can play with and feed your pets as you race against the clock to keep them happy
 * 
 */
using System;
using System.Collections.Generic;

namespace PetShopGame
{
    internal class Launcher
    {
        //timer for the events
        static System.Timers.Timer timer = new System.Timers.Timer();
        public Menus menu = new Menus();
        

        static void Main(string[] args)
        {

            timer.Interval = 1000 * 120; //2 minutes
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timerHandler);
            timer.Start();

            Menus.DisplayMain();
        }

        //event for the timer trickles through menus to petlist to pets
        static private void timerHandler(object sender, System.Timers.ElapsedEventArgs e)
        {

            Menus.timerGoesOff();
        }
    }
}
