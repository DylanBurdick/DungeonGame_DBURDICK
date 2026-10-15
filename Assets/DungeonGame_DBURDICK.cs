using System.Linq;
using UnityEngine;

public class DungeonGame_DBURDICK : MonoBehaviour
{
    void Start()
    {
        const int goldInHall = 12;
        const int bootsAgility = 2;
        const int swordBonus = 7;
        const int trapDamage = 20;
        const int shieldBonus = 4;
        const int treasureGold = 11;
        const int potionPrice = 5;
        const int decentPurse = 10;
        const int lowHealth = 30;
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
        const int maxHealth = 100;
        const int healPerTurn = 8;
        const int campfireTurns = 6;

        string playerName = "Dylan";
        int health = 100;
        int attack = 5;
        int agility = 3;
        int gold = 0;

        int defense = 0;
        bool takeLeftPath = true;

        string[] enemyNames = {"Goblin", "Ogre", "Spider"};
        int[] enemyHP = {20, 34, 24};
        int[] enemyAttack = {8, 15, 6};
        int[] enemyAC = {10, 8, 13};
        int[] enemyDefense = {2, 3, 1};

        // int goblinHealth = 20; making a change to be flagged by github as a change
        // int goblinAttack = 8;
        // int goblinDefense = 2;
        // int goblinAC = 10;
        // int ogreHealth = 34;
        // int ogreAttack = 15;
        // int ogreDefense = 3;
        // int ogreAC = 8;
        // int spiderHealth = 24;
        // int spiderAttack = 6;
        // int spiderDefense = 1;
        // int spiderAC = 13;
        int roomNumber = 0;

        string[] inventory = {};

        string[] roomNames = {"The Entrance Hall", "The Guard Room", "The Flooded Passage", "The Armoury", "The Treasure Room", "The Forked Hall", "The Goblin's Den", "The Ogre's Lair", "The Web-Choked Vault", "The Campfire", "The Old Study", "The Merchant's Nook", "The Sunlit Gate"};
        string[] roomDescriptions = {"A torch flickers on the wall. A stone doorway leads north.", "A rusty sword rests on a table. A goblin snores in the corner.", "Ankle-deep water fills the hall; a broken door waits at the far end.", "Dented armour lines the walls. A sturdy shield still hangs here.", "Raided long ago, but a few coins still glint in the dust.", "The passage forks - two archways, left and right.", "A goblin blocks the way, blade bared - the fight begins!", "An ogre lumbers up out of the dark - slow, but monstrous.", "A giant spider drops from a ceiling thick with webbing!", "A ring of cold stones, just right for a short rest.", "A dusty desk stands against the wall, its drawers shut.", "A dusty desk stands against the wall, its drawers shut.", "A hooded trader waits beside a rack of healing potions.", "An iron portcullis stands open to the daylight beyond."};
        int[] goldPerRooms = {12, 0 , 0, 0, 11, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] enemyRooms = {-1,-1,-1,-1,-1,-1,0,1,2,-1,-1,-1};
        bool[] visitedRooms = {false, false, false, false, false, false, false, false, false, false, false, false, false};
        string[] rewards = {"Gold", "Silver Sword", "Silver Shield", "Bomb"};
        for (int i = 0; i < rewards.Length; i++)
        {
            Debug.Log(rewards[i]);
        }
        
        Debug.Log("=== THE DUNGEON ===");
        Debug.Log("Welcome, " + playerName + ". Your escape begins.");

        Debug.Log("You pull out your map of this dungeon, finding a list of rooms.");
        for (int i = 0; i < roomNames.Length - 1; i++)
        {
            Debug.Log(roomNames[i]);
        }

        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); // first room, 0
        Debug.Log(roomDescriptions[roomNumber]);
        gold += goldPerRooms[roomNumber];
        visitedRooms[roomNumber] = true;
        roomNumber += 1;
        Debug.Log("You scoop up coins. Gold is now " + gold + ".");
        Debug.Log("You lace on leather boots. Agility is increased.");
        inventory.Append("Boots");
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
        Debug.Log(roomDescriptions[roomNumber]);
        visitedRooms[roomNumber] = true;
        roomNumber += 1;
        inventory.Append("Sword");
        Debug.Log("You take the sword.");
        inventory.Append("Key");
        Debug.Log("You grab the rusty key.");

        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); //flooded passageway, 2
        Debug.Log(roomDescriptions[roomNumber]);
        visitedRooms[roomNumber] = true;
        roomNumber += 1;
        health -= trapDamage;
        Debug.Log("A spike trap! Health is now " + health + ".");
        if (health <= 0)
        {
            Debug.Log("You collapse. GAME OVER.");
        }
        else if (health < lowHealth)
        {
            Debug.Log("You are badly wounded - be careful!");
        }
        else
        {
            Debug.Log("Hurt, but still standing.");
        }

        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); //armory, 3
        visitedRooms[roomNumber] = true;
        Debug.Log(roomDescriptions[roomNumber]);
        roomNumber += 1;
        inventory.Append("Shield");
        Debug.Log("You take a shield. Defense is increased.");

        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); // treasure room, 4
        visitedRooms[roomNumber] = true;
        Debug.Log(roomDescriptions[roomNumber]);
        roomNumber += 1;
        gold += goldPerRooms[roomNumber];
        Debug.Log("You pocket the coins. Gold is now " + gold + ".");
        for (int pile = 1; pile <= coinPiles; pile++)
        {
            gold += goldPerPile;
        }
        Debug.Log("You loot " + coinPiles + " more piles. Gold is now " + gold + ".");

        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); // passageway 5
        Debug.Log(roomDescriptions[roomNumber]);
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
        Debug.Log(roomDescriptions[roomNumber]);
        visitedRooms[roomNumber] = true;
        roomNumber += 1;
        int gRound = 1;
        if (enemyRooms[roomNumber] == 0)
        {
            while (health > 0 && enemyHP[0] > 0)
            {
                bool hasSword = false;
                int heroRoll = 0;
                    for (int i = 0; i < inventory.Length; i++)
                    {
                        if (inventory[i] == "Sword")
                        {
                            hasSword = true;
                        }
                    }
                if (hasSword == true)
                {
                    heroRoll = Random.Range(1, dieSides + 1) + swordBonus;
                }
                else
                {
                    heroRoll = Random.Range(1, dieSides + 1);
                }
                
                if (heroRoll >= enemyAC[0])
                {
                    int damage = 0;
                    if (hasSword == true)
                    {
                        damage = attack + swordBonus - enemyDefense[0];
                    }
                    else
                    {
                        damage = attack - enemyDefense[0];
                    }
                    if (heroRoll == critRoll)
                    {
                        damage = attack * critMultiplier - enemyDefense[0];
                        Debug.Log("Round " + gRound + ": you roll " + heroRoll + " - CRITICAL for " + damage + "!");
                    }
                    else
                    {
                        Debug.Log("Round " + gRound + ": you roll " + heroRoll + " and hit for " + damage + ".");
                    }
                    enemyHP[0] -= damage;
                }
                else
                {
                    Debug.Log("Round " + gRound + ": you roll " + heroRoll + " and miss.");
                }

                if (enemyHP[0] > 0)
                {
                    bool hasShield = false;
                    for (int i = 0; i < inventory.Length; i++)
                    {
                        if (inventory[i] == "Shield")
                        {
                            hasShield = true;
                        }
                    }
                    int goblinRoll = Random.Range(1, dieSides + 1);
                    if (goblinRoll >= heroAC)
                    {
                        if (hasShield == true)
                        {
                            health -= enemyAttack[0] - (defense + shieldBonus); 
                        }
                        else
                        {
                            health -= enemyAttack[0] - defense;
                        }
                        Debug.Log(enemyNames[0] + " rolls " + goblinRoll + " and hits. Health: " + health);
                        if (health <= 0)
                        {
                            Debug.Log("   You collapse. GAME OVER.");
                        }
                        else if (health < lowHealth)
                        {
                            Debug.Log("   You are badly wounded - be careful!");
                        }
                        else
                        {
                            Debug.Log("   Hurt, but still standing.");
                        }
                    }
                    else
                    {
                        Debug.Log("the " + enemyNames[0] + " rolls " + goblinRoll + " and misses.");
                    }
                }
                gRound++;
            }
            if (enemyHP[0] <= 0)
            {
                Debug.Log("The goblin is defeated!");
            }
            else
            {
                Debug.Log("The goblin still stands, and you have fallen...");
            }
        }
        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); //ogre fight, 7
        Debug.Log(roomDescriptions[roomNumber]);
        visitedRooms[roomNumber] = true;
        roomNumber += 1;
        int oRound = 1;
        if (enemyRooms[roomNumber] == 1)
        {
            while (health > 0 && enemyHP[1] > 0)
            {
                bool hasSword = false;
                int heroRoll = 0;
                    for (int i = 0; i < inventory.Length; i++)
                    {
                        if (inventory[i] == "Sword")
                        {
                            hasSword = true;
                        }
                    }
                if (hasSword == true)
                {
                    heroRoll = Random.Range(1, dieSides + 1) + swordBonus;
                }
                else
                {
                    heroRoll = Random.Range(1, dieSides + 1);
                }
                if (heroRoll >= enemyAC[1])
                {
                    int damage = 0;
                    if (hasSword == true)
                    {
                        damage = attack + swordBonus - enemyDefense[1];
                    }
                    else
                    {
                        damage = attack - enemyDefense[1];
                    }
                    if (heroRoll == critRoll)
                    {
                        damage = attack * critMultiplier - enemyDefense[1];
                        Debug.Log("Round " + oRound + ": you roll " + heroRoll + " - CRITICAL for " + damage + "!");
                    }
                    else
                    {
                        Debug.Log("Round " + oRound + ": you roll " + heroRoll + " and hit for " + damage + ".");
                    }
                    enemyHP[1] -= damage;
                }
                else
                {
                    Debug.Log("Round " + oRound + ": you roll " + heroRoll + " and miss.");
                }

                if (enemyHP[1] > 0 && oRound % 2 == 0)
                {
                    bool hasShield = false;
                    for (int i = 0; i < inventory.Length; i++)
                    {
                        if (inventory[i] == "Shield")
                        {
                            hasShield = true;
                        }
                    }
                    int ogreRoll = Random.Range(1, dieSides + 1);
                    if (ogreRoll >= heroAC)
                    {
                        if (hasShield == true)
                        {
                            health -= enemyAttack[1] - (defense + shieldBonus); 
                        }
                        else
                        {
                            health -= enemyAttack[1] - defense;
                        }
                        Debug.Log("   the ogre rolls " + ogreRoll + " and smashes you. Health: " + health);
                        if (health <= 0)
                        {
                            Debug.Log("   You collapse. GAME OVER.");
                        }
                        else if (health < lowHealth)
                        {
                            Debug.Log("   You are badly wounded - be careful!");
                        }
                        else
                        {
                            Debug.Log("   Hurt, but still standing.");
                        }
                    }
                    else
                    {
                        Debug.Log("   the ogre rolls " + ogreRoll + " and misses.");
                    }
                }
                oRound++;
            }
            if (enemyHP[1] <= 0)
            {
                Debug.Log("The ogre topples!");
            }
            else
            {
                Debug.Log("The ogre stands over your fallen hero...");
            }
        }
        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); // spider fight, 8
        Debug.Log(roomDescriptions[roomNumber]);
        visitedRooms[roomNumber] = true;
        roomNumber += 1;
        int sRound = 1;
        int poisonLeft = 0;
        if (enemyRooms[roomNumber] == 2)
        {
            while (health > 0 && enemyHP[2] > 0)
            {
                if (poisonLeft > 0)
                {
                    health -= poisonPerTurn;
                    poisonLeft--;
                    Debug.Log("Venom burns (-" + poisonPerTurn + "). Health: " + health);
                    if (health <= 0)
                    {
                        Debug.Log("   You collapse. GAME OVER.");
                    }
                    else if (health < lowHealth)
                    {
                        Debug.Log("   You are badly wounded - be careful!");
                    }
                    else
                    {
                        Debug.Log("   Hurt, but still standing.");
                    }
                }
                if (health <= 0)
                {
                    break;
                }
                bool hasSword = false;
                int heroRoll = 0;
                    for (int i = 0; i < inventory.Length; i++)
                    {
                        if (inventory[i] == "Sword")
                        {
                            hasSword = true;
                        }
                    }
                if (hasSword == true)
                {
                    heroRoll = Random.Range(1, dieSides + 1) + swordBonus;
                }
                else
                {
                    heroRoll = Random.Range(1, dieSides + 1);
                }
                if (heroRoll >= enemyAC[2])
                {
                    int damage = 0;
                    if (hasSword == true)
                    {
                        damage = attack + swordBonus - enemyDefense[2];
                    }
                    else
                    {
                        damage = attack - enemyDefense[2];
                    }
                    if (heroRoll == critRoll)
                    {
                        damage = attack * critMultiplier - enemyDefense[2];
                        Debug.Log("Round " + sRound + ": you roll " + heroRoll + " - CRITICAL for " + damage + "!");
                    }
                    else
                    {
                        Debug.Log("Round " + sRound + ": you roll " + heroRoll + " and hit for " + damage + ".");
                    }
                    enemyHP[2] -= damage;
                }
                else
                {
                    Debug.Log("Round " + sRound + ": you roll " + heroRoll + " and miss.");
                }

                if (enemyHP[2] > 0 && sRound % 2 == 0)
                {
                    bool hasShield = false;
                    for (int i = 0; i < inventory.Length; i++)
                    {
                        if (inventory[i] == "Shield")
                        {
                            hasShield = true;
                        }
                    }
                    int spiderRoll = Random.Range(1, dieSides + 1);
                    if (spiderRoll >= heroAC)
                    {
                        if (hasShield == true)
                        {
                            health -= enemyAttack[2] - (defense + shieldBonus); 
                        }
                        else
                        {
                            health -= enemyAttack[2] - defense;
                        }
                        poisonLeft = poisonTurns;
                        Debug.Log("   the spider rolls " + spiderRoll + ", bites, and poisons you. Health: " + health);
                        if (health <= 0)
                        {
                            Debug.Log("   You collapse. GAME OVER.");
                        }
                        else if (health < lowHealth)
                        {
                            Debug.Log("   You are badly wounded - be careful!");
                        }
                        else
                        {
                            Debug.Log("   Hurt, but still standing.");
                        }
                    }
                    else
                    {
                        Debug.Log("   the spider rolls " + spiderRoll + " and misses.");
                    }
                }
                sRound++;
            }
            if (enemyHP[2] <= 0)
            {
                Debug.Log("The spider curls up, defeated!");
            }
            else
            {
                Debug.Log("The spider looms over your fallen hero...");
            }
        }
        Debug.Log("");
        Debug.Log(roomNames[roomNumber]); //campfire, 9
        Debug.Log(roomDescriptions[roomNumber]);
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
        Debug.Log(roomDescriptions[roomNumber]);
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
        Debug.Log(roomDescriptions[roomNumber]);
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
                Debug.Log(roomDescriptions[roomNumber]); // end, 12
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
 

// A1: ROOMS INTO ARRAYS. Put your existing room names and descriptions into

//     two arrays (roomNames[i] and roomDescsriptions[i] describe the SAME

//     room). Keep the same rooms you already have (do not add or remove any).

// 

//     Hint: How many elements should be in the roomNames array? What about

//     the roomDescriptions array? Should they be different lengths or the same?



// A2: SHOW THE MAP. At the very start of the game, output every room name with

//     a single loop (a quick map of the dungeon) using Debug.Log

//

//      Hint: What new type of loop can you use for this that works specifically

//      with containers?



// A3: MOVE BY INDEX. Keep a currentRoom number that starts at 0. Each time the

//     player moves on, add 1 to it and show that room's name and description

//     from the arrays, instead of hand-writing each room's header.

 

// A4: ONE INVENTORY ARRAY. Replace your separate item flags (hasKey, the

//     sword, the shield, and so on) with a single inventory array. Add an item

//     to it each time the player picks something up.

//

//     Hint: How big does this array need to be? What data type should it be?

 

// A5: SHOW THE LOOT. At the end of the run, print the player's whole inventory

 

// A6: KEY FROM THE INVENTORY. At the vault door, do not use a hasKey bool.

//     Check whether "key" is in the inventory array to decide if the hero may

//     pass.

//     

//     Hint: How could you use what we've previously learned (loops and ifs) to

//     find if a specific item is in an array?

 

// A7: COMBAT ITEMS, NOT PERMANENT UPGRADES. Right now picking up the

//     sword or shield permanently raises attack or defense. Stop doing that. Leave the

//     Do not increase the base stats (attack and defense) of the player.

//

//     Instead, INSIDE each fight, check the inventory and apply the appropriate bonus

//     only in the attack and damage calculations. For example:

//     If the hero is carrying the sword, add swordBonus to the attack and damage roll

//     If the hero is carrying the shield, subtract shieldBonus when reducing damage taken

 

// A8: ENEMIES INTO ARRAYS (the data, not the encounters). Right now each enemy

//     is a pile of separate variables (goblinHealth, goblinAttack, ogreHealth,

//     and so on). Put them into arrays instead (enemyNames[], enemyHealth[],

//     enemyAttack[], enemyArmorClass[] and enemyDefense[]), one array element

//     per enemy (element 0 = goblin, element 1 = ogre, element 2 = spider)

//    Keep each fight in its OWN room and read the enemy from the arrays by index.

//

//     Hint: How many arrays do you need? How many elements per array?



// A9: GOLD BY ROOM. Store the gold each room holds in a roomGold[] array and

//     total it with a loop, instead of adding gold by hand in each room. As the player

//     walks through each room, add however much gold is in the room to the player's

//     overall gold.

//

//     Hint: How many elements do you need in this array? What should you do if

//     a room doesn't have gold in it?



// A10: ROOM ENEMIES. Create a roomEnemy[] array alongside your room arrays,

//      one slot per room, holding the index of the enemy waiting there (or -1 for none).

//      As currentRoom advances, if roomEnemy[currentRoom] is not -1, run the

//      enemy's fight. This ties each enemy to its room through the arrays.

//

//      Hint: What data type should the roomEnemy array be if it is an array of indexes?



// A11: TRACK VISITED ROOMS: Create a "visited" array of bools, one per room,

//      so you can mark the rooms the player has already been through.

//

//      Hint: How big should this array be? What data type should it be? What should

//      the starting values be?



// A12: LOOT TABLE: an array of possible rewards. Print the whole table (or

//      pick from it) with a loop instead of writing each reward out by hand. We won't

//      be using this table for anything yet, but add at least three possible rewards.

//      Example rewards could be some kind of healing item, weapon, armor, etc.