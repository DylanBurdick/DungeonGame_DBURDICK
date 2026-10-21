using Unity.VisualScripting;
using UnityEngine;

public class DungeonGame_DBURDICK : MonoBehaviour
{

    const int goldInHall = 12;
    const int bootsAgility = 2;
    const int swordBonus = 7;
    const int trapDamage = 20;
    const int shieldBonus = 4;
    const int treasureGold = 11;
    int roomNumber = 0;
    
    const int redEvery = 3;
    //const int roomNumber = 6;
    const int torchCount = 3;
    const int coinPiles = 4;
    const int goldPerPile = 5;
    const int drawerWithKey = 3;
    const int gateSeconds = 5;
    const int dieSides = 20;
    const int heroAC = 12;
    const int critRoll = 20;
    const int critMultiplier = 2;
    const int poisonPerTurn = 2;
    const int poisonTurns = 3;
    //const int maxHealth = 100;
    const int healPerTurn = 8;
    const int campfireTurns = 6;
    const int potionPrice = 5;
    const int decentPurse = 10;
    const int lowHealth = 30;
    const int healAmount = 25;

    string playerName = "Dylan";
    int health = 100;
    int attack = 5;
    int maxHealth = 100;
    int gold = 0;
    int AC = 12;
    int defense = 0;
    bool takeLeftPath = true;

    string[] inventory = new string[6];

    string[] roomNames = {"The Entrance Hall", "The Guard Room", "The Flooded Passage", "The Armoury", "The Treasure Room", "The Forked Hall", "The Goblin's Den", "The Ogre's Lair", "The Web-Choked Vault", "The Campfire", "The Old Study", "The Merchant's Nook", "The Sunlit Gate"};
    string[] roomDescriptions = {"A torch flickers on the wall. A stone doorway leads north.", "A rusty sword rests on a table. A goblin snores in the corner.", "Ankle-deep water fills the hall; a broken door waits at the far end.", "Dented armour lines the walls. A sturdy shield still hangs here.", "Raided long ago, but a few coins still glint in the dust.", "The passage forks - two archways, left and right.", "A goblin blocks the way, blade bared - the fight begins!", "An ogre lumbers up out of the dark - slow, but monstrous.", "A giant spider drops from a ceiling thick with webbing!", "A ring of cold stones, just right for a short rest.", "A dusty desk stands against the wall, its drawers shut.", "A hooded trader waits beside a rack of healing potions.", "An iron portcullis stands open to the daylight beyond."};
    string[] closeLooks = {"There's nothing interesting here.", "There's a sword on the table.", "Lots of water!", "There's a nice looking shield here.", "There are some coins left.", "There's nothing interesting here.", "There's nothing special here.", "There's nothing special here.", "There's nothing special here.", "You might be able to make a campfire with the stuff in this room.", "Maybe there's something interesting in the desk?", "There's a trader here.", "There's a large door here."};
    int[] goldPerRooms = {12, 0 , 0, 0, 11, 0, 0, 0, 0, 0, 0, 0, 0};
    int[] enemyRooms = {-1,-1,-1,-1,-1,-1,0,1,2,-1,-1,-1};
    bool[] visitedRooms = {false, false, false, false, false, false, false, false, false, false, false, false, false};
    string[] rewards = {"Gold", "Silver Sword", "Silver Shield", "Bomb"};

    string[] enemyNames = {"Goblin", "Ogre", "Spider"};
    int[] enemyHP = {20, 34, 24};
    int[] enemyAttack = {8, 15, 6};
    int[] enemyAC = {10, 8, 13};
    int[] enemyDefense = {2, 3, 1};

    bool inCombat = false;
    int currentEnemy = -1;

    void Heal()
    {
        health += healAmount;
    }

    void Heal(int amount)
    {
        health += amount;
    }

    void AddGold(int amount)
    {
        gold += amount;
        Debug.Log("You now have " + gold + " gold.");
    }

    int RemoveCursedCoins(int cursedCoins)
    {
        cursedCoins -= 1;
        return cursedCoins;
    }

    string ReportCondition()
    {
        if (health < 30)
        {
            return "Badly Damaged";
        }
        else if (health >= 30 && health < 60)
        {
            return "Battred";
        }
        else
        {
            return "Fine";
        }
    }

    bool IsAlive()
    {
        if (health > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void AddItemToInventory(string item)
    {
        for (int i = 0; i <= inventory.Length - 1; i++)
        {
            if (inventory[i] != "")
            {
                inventory[i] = item;
            }
        }
    }

    int RollDice(int sides = 20)
    {
        int roll = Random.Range(1, sides + 1);
        return roll;
    }

    int RollDice(int min, int max)
    {
        int roll = Random.Range(min, max + 1);
        return roll;
    }

    void DescribeRoom()
    {
        Debug.Log(roomDescriptions[roomNumber]);
    }
    
    void DescribeRoom(bool lookClosely)
    {
        Debug.Log(roomDescriptions[roomNumber]);
        if (lookClosely)
        {
            Debug.Log(closeLooks[roomNumber]);
        }
    }

    void Combat(int enemyIndex)
    {
        int round = 0;
        while (inCombat == true)
        {
            CombatRound(enemyIndex);
            if (enemyHP[enemyIndex] <= 0)
            {
                Debug.Log("You slay the " + enemyNames[enemyIndex] + "! You continue deeper into the dungeon.");
                inCombat = false;
            }
            else if (health <= 0)
            {
                Debug.Log("You have fallen.");
                return;
            }
        }
        void CombatRound(int enemyIndex)
        {
            while (health > 0 && enemyHP[enemyIndex] > 0)
            {
                int heroAttackRoll = RollDice();
                string roundMessage = "on round " + round + "you rolled a " + heroAttackRoll + "."; 
                if (heroAttackRoll + attack >= enemyAC[enemyIndex])
                {
                    int damage = attack;
                    if (heroAttackRoll == 20)
                    {
                        damage += critMultiplier;
                    }
                    damage -= enemyDefense[enemyIndex];
                    enemyHP[enemyIndex] -= damage;
                    Debug.Log("You hit your enemy, and deal " + damage + " damage");
                }
                else
                {
                    Debug.Log("You miss");
                }
                if (enemyHP[enemyIndex] > 0)
                {
                    int enemyRoll = RollDice();
                    
                    if (enemyRoll + enemyAttack[enemyIndex] >= AC)
                    {
                        int damage = attack;
                        if (enemyRoll == 20)
                        {
                            damage *= critMultiplier;
                        }
                        damage -= defense;
                        health -= damage;
                        ReportCondition();
                        Debug.Log("The enemy deals " + damage + " damage to you.");
                    }
                    else
                    {
                        Debug.Log("The enemy misses you.");
                    }
                }
            }
        }
        void WaitRounds()
        {
            round ++;
        }

        // void WaitRounds(int amount)
        // {
        //     round += amount;
        // }

        
    }

    void Start()
    {
        void ShowTitle()
        {
            int easterEgg = Random.Range(1,101);
            if (easterEgg > 100)
            {
                Debug.Log("===DUNGEON GAME===");
            }
            else
            {
                Debug.Log("===DUNGEON GMAE==="); //i made a misspelling initially and thought this would be funny. im a comedic genius!!
            }
        }

        ShowTitle();

        for (int i = 0; i < rewards.Length; i++)
        {
            Debug.Log(rewards[i]);
        }
        
        Debug.Log("=== THE DUNGEON ===");
        Debug.Log("Welcome, " + playerName + ". Your escape begins.");

        Debug.Log("You pull out your map of this dungeon, finding a list of rooms.");
        for (int i = 0; i < roomNames.Length; i++)
        {
            Debug.Log(roomNames[i]);
        }

        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); // first room, 0
        DescribeRoom();
        AddGold(goldPerRooms[roomNumber]);
        visitedRooms[roomNumber] = true;
        roomNumber += 1;
        Debug.Log("You scoop up coins. Gold is now " + gold + ".");
        Debug.Log("You lace on leather boots. Agility is increased.");
        AddItemToInventory("Boots");
        if (gold >= decentPurse)
        {
            Debug.Log("A decent purse already.");
        }
        else
        {
            Debug.Log("Barely a handful of coins.");
        }

        for (int i = 1; i <= torchCount; i++)
        {
            Debug.Log("Torch " + i + " sputters to life.");
        }

        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); // guard room, 1
        DescribeRoom();
        visitedRooms[roomNumber] = true;
        roomNumber += 1;
        AddItemToInventory("Sword");
        Debug.Log("You take the sword.");
        AddItemToInventory("Key");
        Debug.Log("You grab the rusty key.");

        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); //flooded passageway, 2
        DescribeRoom();
        visitedRooms[roomNumber] = true;
        roomNumber += 1;
        health -= trapDamage;
        Debug.Log("A spike trap! Health is now " + health + ".");
        IsAlive();
        ReportCondition();

        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); //armory, 3
        visitedRooms[roomNumber] = true;
        DescribeRoom();
        roomNumber += 1;
        AddItemToInventory("Shield");
        Debug.Log("You take a shield. Defense is increased.");

        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); // treasure room, 4
        visitedRooms[roomNumber] = true;
        DescribeRoom();
        AddGold(goldPerRooms[roomNumber]);
        roomNumber += 1;
        Debug.Log("You pocket the coins. Gold is now " + gold + ".");
        for (int pile = 1; pile <= coinPiles; pile++)
        {
            AddGold(goldPerPile);
        }
        Debug.Log("You loot " + coinPiles + " more piles. Gold is now " + gold + ".");

        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); // passageway 5
        DescribeRoom();
        visitedRooms[roomNumber] = true;
        roomNumber += 1;
        if (takeLeftPath)
        {
            Debug.Log("You go left, down a damp stair.");
        }
        else
        {
            Debug.Log("You go right, past the old cells.");
        }
        Debug.Log("The two passages meet again at a red-lit landing.");

        if (roomNumber % redEvery == 0)
        {
            Debug.Log("Room " + roomNumber + " has a red glow.");
        }
        else
        {
            Debug.Log("Room " + roomNumber + " has no red glow.");
        }

        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); // goblin fight, 6
        DescribeRoom();
        visitedRooms[roomNumber] = true;
        Debug.Log("Current room number is" + roomNumber);
        if (enemyRooms[roomNumber] == 0)
        {
            inCombat = true;
            Combat(enemyRooms[roomNumber]);
            Debug.Log("Enemy Encounter Started");
        }
        roomNumber += 1;
        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); //ogre fight, 7
        DescribeRoom();
        visitedRooms[roomNumber] = true;
        if (enemyRooms[roomNumber] == 1)
        {
            inCombat = true;
            Combat(enemyRooms[roomNumber]);
        }
        roomNumber += 1;
        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); // spider fight, 8
        DescribeRoom();
        visitedRooms[roomNumber] = true;
        if (enemyRooms[roomNumber] == 2)
        {
            inCombat = true;
            Combat(enemyRooms[roomNumber]);
        }
        roomNumber += 1;

        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); //campfire, 9
        DescribeRoom();
        visitedRooms[roomNumber] = true;
        roomNumber += 1;
        Debug.Log("You make camp and tend your wounds.");
        int turnsRested = 0;
        while (health < maxHealth && turnsRested < campfireTurns)
        {
            health += healPerTurn;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
            turnsRested++;
            Debug.Log("You rest by the fire. Health is now " + health + ".");
        }

        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); //key room, 10
        DescribeRoom();
        visitedRooms[roomNumber] = true;
        roomNumber += 1;
        int drawer = 0;
        bool foundSpare = false;
        do
        {
            drawer++;
            Debug.Log("You rifle through drawer " + drawer + "...");
            if (drawer == drawerWithKey)
            {
                foundSpare = true;
            }
        }
        while (!foundSpare);
        Debug.Log("A spare key was in drawer " + drawer + "!");

        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); // merchant, 11
        DescribeRoom();
        visitedRooms[roomNumber] = true;
        roomNumber += 1;
        Debug.Log("The potions cost " + potionPrice + " gold each.");
        int potions = gold / potionPrice;
        int leftover = gold % potionPrice;
        Debug.Log("You can buy " + potions + " potions, with " + leftover + " gold left over.");

        Debug.Log("");
        for (int t = gateSeconds; t >= 1; t--)
        {
            Debug.Log("The gate closes in " + t + "...");
        }

        Debug.Log("");
        // if (hasKey && health > 0)
        // {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == "Key")
            {
                Debug.Log("Key in hand and still standing, you unlock the vault door.");
                Debug.Log(roomNames[roomNumber]);
                DescribeRoom(); // end, 12
                visitedRooms[roomNumber] = true;
                roomNumber += 1;
                Debug.Log("Daylight pours through the portcullis. You escape the dungeon!");
                Debug.Log("You escaped with the following loot: ");
                for (int t = 0; t < inventory.Length; t++)
                    {
                        Debug.Log(inventory[t]);
                    }
            }
            else
            {
                Debug.Log("The vault is locked - you never found the key.");
            }
        }
        // Debug.Log("Key in hand and still standing, you unlock the vault door.");
        // Debug.Log(roomNames[roomNumber]);
        // Debug.Log(roomDescriptions[roomNumber]);
        // roomNumber += 1;
        // Debug.Log("Daylight pours through the portcullis. You escape the dungeon!");
        // Debug.Log("You escaped with the following loot: ");
        // for (int i = 0; i < inventory.Length; i++)
        //     {
        //         Debug.Log(inventory[i]);
        //     }
    }
}
//         }
//         else if (!hasKey)
//         {
//             Debug.Log("The vault is locked - you never found the key.");
//         }
//         else
//         {
//             Debug.Log("Too wounded to force the door, you can go no further...");
//         }
//     }
// }
 

// ===== BEFORE YOU START: move shared variables up to CLASS variables =====

// A variable declared inside Start() cannot be seen by your other methods.

// Any variable that more than one method needs must live at the TOP of the

// class (above Start), as a class variable (field). Move these out of Start()

// and declare them at class level:

//

//  Player stats:

//   playerName  (string)

//   health    (int)

//   maxHealth   (int)

//   attack    (int)

//   defense    (int)

//   gold     (int)

//

//  The map (from the Arrays homework):

//   roomNames   (string[])

//   roomDescs   (string[])

//   roomGold   (int[])

//   currentRoom  (int)

//

//  The enemies (from the Arrays homework):

//   enemyNames  (string[])

//   enemyHealth  (int[])

//   enemyAttack  (int[])

//   enemyDefense (int[])

//

//  The inventory (from the Arrays homework):

//   inventory   (string[])

//

//  Combat state (so a fight can run one round at a time later):

//   inCombat   (bool)

//   currentEnemy (int)

//

//  Tunable constants:

//   lowHealth   (const int) - the "badly wounded" cutoff

//   potionPrice  (const int)

//   healAmount  (const int) - the default amount a potion heals

//

// (If you followed the Arrays homework, the arrays are already class variables.

// You mainly need to lift the player stats, combat state, and constants up here.)



// ================= PART A: METHODS I (build in this order) =================



// A1: Write a method, ShowTitle(), that prints the game's title banner (it

//   takes nothing and returns nothing). Call it at the start of the game.



// A2: Write a method, ShowRoom(int index), that prints that room's name and

//   description from your arrays. Use it everywhere you print a room by hand,

//   and each time the player moves to a new room.



// A3: Split the fight into ONE round plus a loop that repeats it. (This makes it

//   painless to add player input later, when each round will run on a key

//   press instead of inside a loop.)

//

//   First write CombatRound(int enemyIndex): a SINGLE exchange using the

//   enemy's stats from your arrays. The player attacks the enemy (enemy health

//   drops by the player's attack); then, ONLY IF the enemy is still alive, it

//   attacks back (player health drops by the enemy's attack). Report the

//   round. If either side has run out of health, print the outcome and set

//   inCombat to false.

//

//   Then write Combat(int enemyIndex) as a thin wrapper that runs the whole

//   fight for now: set currentEnemy, set inCombat to true, then keep calling

//   CombatRound(enemyIndex) while inCombat is true. Call Combat in each

//   enemy's room - Combat(0) in the Goblin's Den, Combat(1) in the Ogre's

//   Lair, Combat(2) in the Spider's Vault. Your three copied fight blocks

//   become three one-line calls, and each enemy stays in its own room.

//

//   (Later, when we add input, we delete this loop and call CombatRound once

//   each time the player chooses to attack - the round method stays the same.)



// A4: Write a method, IsAlive(), that returns whether the hero is still alive

//   (health above 0). Use the value it returns to decide the ending.



// A5: Write a method, AddGold(int amount), that adds the amount to the player's

//   gold and hands back the new total. Print the value it returns.



// A6: Write a method, RollDice(), that returns a random number from 1 to 20. Use

//   what it returns in your combat or a skill check instead of calling

//   Random.Range in line.



// A7: Write a method, ReportCondition(int health), that prints the hero's

//   condition: fallen if no health remains, badly wounded if it is low,

//   otherwise steady. Call it right after the hero takes damage, anywhere in

//   the dungeon.



// ================= PART B: METHODS II =================



// B1: Overload RollDice from A6 (same name, different inputs). Add

//   RollDice(int sides) that returns a number from 1 to the sides you pass in,

//   and RollDice(int min, int max) that returns a number from min to max. Now

//   one name rolls a d20, any-sided die, or any range you need.



// B2: Give healing an optional amount, so Heal() restores a sensible default and

//   Heal(25) restores that much - all from one method. Keep the default in a

//   named value.



// B3: Make two ways to describe a room under one name (overloading): one that

//   prints just the short description, and one that takes an extra value for

//   "look closely" that also lists the room's exits and any item in it. Now

//   the player can glance or examine in detail.



// B4: Write a method that passes time in the dungeon for a number of turns,

//   defaulting to 1 turn when no number is given (think "wait" versus

//   "wait 3"). Report each turn that passes.



// B5: Write a method that takes a number - say a "cursed coins" amount -

//   subtracts from it INSIDE the method, and prints it there. Back in Start,

//   print the original variable afterward and notice it did NOT change: a

//   parameter is the method's own copy. Then make the change actually stick by

//   returning the new value (or using a field).


