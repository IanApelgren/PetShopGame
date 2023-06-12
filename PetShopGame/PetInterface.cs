using System;

namespace PetShopGame
{
    internal interface PetInterface
    {
        Boolean isHungry();
        Boolean isSad();
        Boolean okCheck();
        void stats();
        void Feed(string food);
        void interact(string ract);
        void vsDog();
        void vsCat();
        void timePasses();
        string getName();
        string getType();
        void setHunger(int i);
        int getHunger();
        void setHappiness(int i);
        int getHappiness();
        void change(int hung, int happ, string input);
    }
}
