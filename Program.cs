using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HealthCombat
{ 

}

internal class Program
{

    //Add numbers to the game//XP should go here if I do it
    static int health = 100;
    static int shield = 100;
    static int lives = 1;

    static void Main(string[] args)
    {;
        UnitTestHealthSystem();

        //Game//Add methods to start
        ShowHUD();
        TakeDamage(10);
        ShowHUD();
        TakeDamage(20);
        ShowHUD();
        TakeDamage(30);
        ShowHUD();
        TakeDamage(30);
        ShowHUD();
        TakeDamage(10);
        ShowHUD();
        TakeDamage(10);
        ShowHUD();
        Revive();
        ShowHUD();
        RegenerateShield(100);
        ShowHUD();
        TakeDamage(150);
        ShowHUD();
        Heal(50);
        ShowHUD();
        TakeDamage(200);
        ShowHUD();
        Console.WriteLine("Gameplay Over");
        Console.WriteLine("Debug Test");
        Console.ReadKey(true);
        health =  100;
        shield = 100;
        lives  = 1;
        Console.WriteLine();
        ShowHUD();
        TakeDamage(-100);
        ShowHUD();
        RegenerateShield(-100);
        ShowHUD();
        Heal(-100);
        ShowHUD();
    }

    static void ShowHUD()
    {
        //Shows HUD and elements of methods
        Console.WriteLine($"Health: {health}%" + $" Lives: {lives}");
        Console.WriteLine($"Shield: {shield}%");
        Console.WriteLine(HPpercent());
        Console.WriteLine();
        Console.ReadKey(true);
    }

    static void Heal(int hp)
    {
        //Debug for Healing
        if (hp < 0)
        {
            Console.WriteLine("Error wrong input for Healing");
            return;
        }
        //Healing using an int as hp to heal remaining health
       health = Math.Min(100, health + hp);
        //Writes the healing amount in HUD
        Console.WriteLine("Heal " + hp + " HP");

    }

    static void RegenerateShield(int hp)
    {
        //Debug for ShieldChargedUP
        if (hp < 0)
        {
            Console.WriteLine("Error wrong input for Shield Charge");
            return;
        }
        //Shield regenating 
        shield = Math.Max(100, shield + hp);
        //Show shield regen in HUD
        Console.WriteLine("Regan " + shield + " Shield");

    }

    static void TakeDamage(int Damage)
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

        if (shield > 0)
        {
            if (shield >= remainingDamage)
            {
                shield -= remainingDamage;
                remainingDamage = 0;
            }
            else
            {
                remainingDamage -= shield;
                shield = 0;
            }
        }
        //Damage Health after Shields
        if (health > 0 && remainingDamage > 0)
        {
            health = Math.Max(0, health - remainingDamage);
        }

        if (health <=0 && lives <=0) 
        {
            Console.WriteLine("Game Over");
        }


    }
    static void Revive()
    {
        //Health goes to zero revive the player
        health = 100;
        shield = 0;
        lives--;
        Console.WriteLine("Player Revive");

    }
        static string HPpercent()
        {
             //Just a string telling you how low Health you are at
              if (health <= 0)
              {
                 return "Player Died";
              }       
             else if (health <= 10)
             {
                return "YOUR GOING TO LOSE A LIVE ";
             }
             else if (health <= 20)
             {
                return ("Gonna Die so Stop taking damage");
             }
             else if (health <= 50)
             {
                return ("Warning, Stop taking damage");
             }
             else if (health <= 80)
             {
                return ("Don't take anymore damage");
             }
             else
             {
                return "Not Touched";
             }
        }
    static void UnitTestHealthSystem()
    {
        Debug.WriteLine("Unit testing Health System started...");

        // TakeDamage()

        // TakeDamage() - only shield
        shield = 100;
        health = 100;
        lives = 3;
        TakeDamage(10);
        Debug.Assert(shield == 90);
        Debug.Assert(health == 100);
        Debug.Assert(lives == 3);

        // TakeDamage() - shield and health
        shield = 10;
        health = 100;
        lives = 3;
        TakeDamage(50);
        Debug.Assert(shield == 0);
        Debug.Assert(health == 60);
        Debug.Assert(lives == 3);

        // TakeDamage() - only health
        shield = 0;
        health = 50;
        lives = 3;
        TakeDamage(10);
        Debug.Assert(shield == 0);
        Debug.Assert(health == 40);
        Debug.Assert(lives == 3);

        // TakeDamage() - health and lives
        shield = 0;
        health = 10;
        lives = 3;
        TakeDamage(25);
        Debug.Assert(shield == 0);
        Debug.Assert(health == 0);
        Debug.Assert(lives == 3);

        // TakeDamage() - shield, health, and lives
        shield = 5;
        health = 100;
        lives = 3;
        TakeDamage(110);
        Debug.Assert(shield == 0);
        Debug.Assert(health == 0);
        Debug.Assert(lives == 3);

        // TakeDamage() - negative input
        shield = 50;
        health = 50;
        lives = 3;
        TakeDamage(-10);
        Debug.Assert(shield == 50);
        Debug.Assert(health == 50);
        Debug.Assert(lives == 3);

        // Heal()

        // Heal() - normal
        shield = 0;
        health = 90;
        lives = 3;
        Heal(5);
        Debug.Assert(shield == 0);
        Debug.Assert(health == 95);
        Debug.Assert(lives == 3);

        // Heal() - already max health
        shield = 90;
        health = 100;
        lives = 3;
        Heal(5);
        Debug.Assert(shield == 90);
        Debug.Assert(health == 100);
        Debug.Assert(lives == 3);

        // Heal() - negative input
        shield = 50;
        health = 50;
        lives = 3;
        Heal(-10);
        Debug.Assert(shield == 50);
        Debug.Assert(health == 50);
        Debug.Assert(lives == 3);

        // RegenerateShield()

        // RegenerateShield() - normal
        shield = 50;
        health = 100;
        lives = 3;
        RegenerateShield(10);
        Debug.Assert(shield == 60);
        Debug.Assert(health == 100);
        Debug.Assert(lives == 3);

        // RegenerateShield() - already max shield
        shield = 100;
        health = 100;
        lives = 3;
        RegenerateShield(10);
        Debug.Assert(shield == 100);
        Debug.Assert(health == 100);
        Debug.Assert(lives == 3);

        // RegenerateShield() - negative input
        shield = 50;
        health = 50;
        lives = 3;
        RegenerateShield(-10);
        Debug.Assert(shield == 50);
        Debug.Assert(health == 50);
        Debug.Assert(lives == 3);

        // Revive()

        // Revive()
        shield = 0;
        health = 0;
        lives = 2;
        Revive();
        Debug.Assert(shield == 100);
        Debug.Assert(health == 100);
        Debug.Assert(lives == 1);

        Debug.WriteLine("Unit testing Health System completed.");
        Console.Clear();
    }

}
