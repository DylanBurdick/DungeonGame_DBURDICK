using UnityEngine;

public class DungeonGameHW2 : MonoBehaviour
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
        const int roomNumber = 6;
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

        string playerName = "Hero";
        int health = 100;
        int attack = 5;
        int agility = 3;
        int gold = 0;
        bool hasKey = false;
        int defense = 0;
        bool takeLeftPath = true;

        int goblinHealth = 20;
        int goblinAttack = 8;
        int goblinDefense = 2;
        int goblinAC = 10;
        int ogreHealth = 34;
        int ogreAttack = 15;
        int ogreDefense = 3;
        int ogreAC = 8;
        int spiderHealth = 24;
        int spiderAttack = 6;
        int spiderDefense = 1;
        int spiderAC = 13;

        Debug.Log("=== THE DUNGEON ===");
        Debug.Log("Welcome, " + playerName + ". Your escape begins.");

        Debug.Log("");
        Debug.Log("The Entrance Hall");
        Debug.Log("A torch flickers on the wall. A stone doorway leads north.");
        gold += goldInHall;
        Debug.Log("You scoop up coins. Gold is now " + gold + ".");
        agility += bootsAgility;
        Debug.Log("You lace on leather boots. Agility is now " + agility + ".");
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
        Debug.Log("The Guard Room");
        Debug.Log("A rusty sword rests on a table. A goblin snores in the corner.");
        attack += swordBonus;
        Debug.Log("You take the sword. Attack is now " + attack + ".");
        hasKey = true;
        Debug.Log("You grab the rusty key. hasKey is now " + hasKey + ".");

        Debug.Log("");
        Debug.Log("The Flooded Passage");
        Debug.Log("Ankle-deep water fills the hall; a broken door waits at the far end.");
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
        Debug.Log("The Armoury");
        Debug.Log("Dented armour lines the walls. A sturdy shield still hangs here.");
        defense += shieldBonus;
        Debug.Log("You take a shield. Defense is now " + defense + ".");

        Debug.Log("");
        Debug.Log("The Treasure Room");
        Debug.Log("Raided long ago, but a few coins still glint in the dust.");
        gold += treasureGold;
        Debug.Log("You pocket the coins. Gold is now " + gold + ".");
        for (int pile = 1; pile <= coinPiles; pile++)
        {
            gold += goldPerPile;
        }
        Debug.Log("You loot " + coinPiles + " more piles. Gold is now " + gold + ".");

        Debug.Log("");
        Debug.Log("The Forked Hall");
        Debug.Log("The passage forks - two archways, left and right.");
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
        Debug.Log("The Goblin's Den");
        Debug.Log("A goblin blocks the way, blade bared - the fight begins!");
        int gRound = 1;
        while (health > 0 && goblinHealth > 0)
        {
            int heroRoll = Random.Range(1, dieSides + 1);
            if (heroRoll >= goblinAC)
            {
                int damage = attack - goblinDefense;
                if (heroRoll == critRoll)
                {
                    damage = attack * critMultiplier - goblinDefense;
                    Debug.Log("Round " + gRound + ": you roll " + heroRoll + " - CRITICAL for " + damage + "!");
                }
                else
                {
                    Debug.Log("Round " + gRound + ": you roll " + heroRoll + " and hit for " + damage + ".");
                }
                goblinHealth -= damage;
            }
            else
            {
                Debug.Log("Round " + gRound + ": you roll " + heroRoll + " and miss.");
            }

            if (goblinHealth > 0)
            {
                int goblinRoll = Random.Range(1, dieSides + 1);
                if (goblinRoll >= heroAC)
                {
                    health -= goblinAttack - defense;
                    Debug.Log("   the goblin rolls " + goblinRoll + " and hits. Health: " + health);
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
                    Debug.Log("   the goblin rolls " + goblinRoll + " and misses.");
                }
            }
            gRound++;
        }
        if (goblinHealth <= 0)
        {
            Debug.Log("The goblin is defeated!");
        }
        else
        {
            Debug.Log("The goblin still stands, and you have fallen...");
        }

        Debug.Log("");
        Debug.Log("The Ogre's Lair");
        Debug.Log("An ogre lumbers up out of the dark - slow, but monstrous.");
        int oRound = 1;
        while (health > 0 && ogreHealth > 0)
        {
            int heroRoll = Random.Range(1, dieSides + 1);
            if (heroRoll >= ogreAC)
            {
                int damage = attack - ogreDefense;
                if (heroRoll == critRoll)
                {
                    damage = attack * critMultiplier - ogreDefense;
                    Debug.Log("Round " + oRound + ": you roll " + heroRoll + " - CRITICAL for " + damage + "!");
                }
                else
                {
                    Debug.Log("Round " + oRound + ": you roll " + heroRoll + " and hit for " + damage + ".");
                }
                ogreHealth -= damage;
            }
            else
            {
                Debug.Log("Round " + oRound + ": you roll " + heroRoll + " and miss.");
            }

            if (ogreHealth > 0 && oRound % 2 == 0)
            {
                int ogreRoll = Random.Range(1, dieSides + 1);
                if (ogreRoll >= heroAC)
                {
                    health -= ogreAttack - defense;
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
        if (ogreHealth <= 0)
        {
            Debug.Log("The ogre topples!");
        }
        else
        {
            Debug.Log("The ogre stands over your fallen hero...");
        }

        Debug.Log("");
        Debug.Log("The Web-Choked Vault");
        Debug.Log("A giant spider drops from a ceiling thick with webbing!");
        int sRound = 1;
        int poisonLeft = 0;
        while (health > 0 && spiderHealth > 0)
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

            int heroRoll = Random.Range(1, dieSides + 1);
            if (heroRoll >= spiderAC)
            {
                int damage = attack - spiderDefense;
                if (heroRoll == critRoll)
                {
                    damage = attack * critMultiplier - spiderDefense;
                    Debug.Log("Round " + sRound + ": you roll " + heroRoll + " - CRITICAL for " + damage + "!");
                }
                else
                {
                    Debug.Log("Round " + sRound + ": you roll " + heroRoll + " and hit for " + damage + ".");
                }
                spiderHealth -= damage;
            }
            else
            {
                Debug.Log("Round " + sRound + ": you roll " + heroRoll + " and miss.");
            }

            if (spiderHealth > 0 && sRound % 2 == 0)
            {
                int spiderRoll = Random.Range(1, dieSides + 1);
                if (spiderRoll >= heroAC)
                {
                    health -= spiderAttack - defense;
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
        if (spiderHealth <= 0)
        {
            Debug.Log("The spider curls up, defeated!");
        }
        else
        {
            Debug.Log("The spider looms over your fallen hero...");
        }

        Debug.Log("");
        Debug.Log("The Campfire");
        Debug.Log("A ring of cold stones, just right for a short rest.");
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
        Debug.Log("The Old Study");
        Debug.Log("A dusty desk stands against the wall, its drawers shut.");
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
        Debug.Log("The Merchant's Nook");
        Debug.Log("A hooded trader waits beside a rack of healing potions.");
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
        if (hasKey && health > 0)
        {
            Debug.Log("Key in hand and still standing, you unlock the vault door.");
            Debug.Log("The Sunlit Gate");
            Debug.Log("An iron portcullis stands open to the daylight beyond.");
            Debug.Log("Daylight pours through the portcullis. You escape the dungeon!");
        }
        else if (!hasKey)
        {
            Debug.Log("The vault is locked - you never found the key.");
        }
        else
        {
            Debug.Log("Too wounded to force the door, you can go no further...");
        }
    }
}