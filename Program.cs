using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace HealthCombat
{ 

}

internal class Program
{

    //Add numbers to the game//XP should go here if I do it
    static int Health = 100;
    static int Shield = 100;
    static int Lives = 1;

    static void Main(string[] args)
    {
        //Game//Add methods to start
        ShowHUD();
        EnemyDamage(100);
        ShowHUD();
        EnemyDamage(20);
        ShowHUD();
        EnemyDamage(30);
        ShowHUD();
        EnemyDamage(30);
        ShowHUD();
        EnemyDamage(10);
        ShowHUD();
        EnemyDamage(10);
        ShowHUD();
        Revive();
        ShowHUD();
        ShieldChargeUP(100);
        ShowHUD();
        EnemyDamage(150);
        ShowHUD();
        Healing(50);
        ShowHUD();
        EnemyDamage(200);
        ShowHUD();
        Console.WriteLine("Gameplay Over");
        Console.WriteLine("Debug Test");
        Console.ReadKey(true);
        Health =  100;
        Shield = 100;
        Lives = 1;
        Console.WriteLine();
        ShowHUD();
        EnemyDamage(-100);
        ShowHUD();
        ShieldChargeUP(-100);
        ShowHUD();
        Healing(-100);
        ShowHUD();
    }

    static void ShowHUD()
    {
        //Shows HUD and elements of methods
        Console.WriteLine($"Health: {Health}%" + $" Lives: {Lives}");
        Console.WriteLine($"Shield: {Shield}%");
        Console.WriteLine(HPpercent());
        Console.WriteLine();
        Console.ReadKey(true);
    }

    static void Healing(int hp)
    {
        //Debug for Healing
        if (hp < 0)
        {
            Console.WriteLine("Error wrong input for Healing");
            return;
        }
        //Healing using an int as hp to heal remaining health
       Health = Math.Min(100, Health + hp);
        //Writes the healing amount in HUD
        Console.WriteLine("Heal " + hp + " HP");

    }

    static void ShieldChargeUP(int hp)
    {
        //Debug for ShieldChargedUP
        if (hp < 0)
        {
            Console.WriteLine("Error wrong input for Shield Charge");
            return;
        }
        //Shield regenating 
        Shield = Math.Max(100, Shield + hp);
        //Show shield regen in HUD
        Console.WriteLine("Regan " + Shield + " Shield");

    }

    static void EnemyDamage(int Damage)
    {
        //Debug for Damage
        if (Damage < 0) 
        {
            Console.WriteLine("Error wrong input for Damage");
            return;
        }
        //Remaining Damage coverts to Health after Shields 
        int remainingDamage = Damage;
        //Writes How much the player takes in HUD
        Console.WriteLine("Player took " + Damage + " damage ");
        //Doesn't go below 0 for shields (No -10 shield)
        if (Shield > 0)
        {
            if (Shield >= remainingDamage)
            {
                Shield -= remainingDamage;
                remainingDamage = 0;
            }
            else
            {
                remainingDamage -= Shield;
                Shield = 0;
            }
        }
        //Damage Health after Shields
        if (Health > 0 && remainingDamage > 0)
        {
            Health = Math.Max(0, Health - remainingDamage);
        }

        if (Health <=0 && Lives <=0) 
        {
            Console.WriteLine("Game Over");
        }


    }
    static void Revive()
    {
        //Health goes to zero revive the player
        Health = 100;
        Shield = 0;
        Lives--;
        Console.WriteLine("Player Revive");

    }
        static string HPpercent()
        {
             //Just a string telling you how low Health you are at
              if (Health <= 0)
              {
                 return "Player Died";
              }       
             else if (Health<= 10)
             {
                return "YOUR GOING TO LOSE A LIVE ";
             }
             else if (Health <= 20)
             {
                return ("Gonna Die so Stop taking damage");
             }
             else if (Health <= 50)
             {
                return ("Warning, Stop taking damage");
             }
             else if (Health <= 80)
             {
                return ("Don't take anymore damage");
             }
             else
             {
                return "Not Touched";
             }
        }

}
