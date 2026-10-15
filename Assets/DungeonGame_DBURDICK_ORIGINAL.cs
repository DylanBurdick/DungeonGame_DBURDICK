using UnityEngine;

// ==========================================================================
// THE DUNGEON - Homework (Intro to C#  +  Variables & Operators)
// --------------------------------------------------------------------------
// One growing program - keep building this SAME file.
//   PART A: do after the INTRO lecture (uses only Debug.Log).
//   PART B: finish after the VARIABLES lecture (variables & operators).
// Attach to an empty GameObject and press Play to test as you go.
// ==========================================================================
public class DungeonGame_DBURDICK_ORIGINAL : MonoBehaviour
{
    void Start()
    {
        // (PART B) TODO B1: declare your stats here, at the very top of Start,
        //          once you have had the Variables lecture. You will need:
        //            playerName (string), health (int), attack (int),
        //            agility (int), gold (int), hasKey (bool),
        //            goblinHealth (int), goblinAttack (int).
        string playerName = "Dylan";
        int maxHealth = 100;
        int health = 100;
        int attack = 10;
        int agility = 10;
        int defense = 2;
        int AC = 12;
        int hitModifier = 3;
        int gold = 20;
        bool hasKey = false;
        int currentRoom = 0;

        int goblinHealth = 50;
        int goblinAttack = 5;
        int goblinDefense = 2;
        int goblinAC = 10;
        int goblinHitModifier = 1;
        // ===== ALREADY BUILT IN CLASS (Intro lecture): the opening + two rooms =====
        Debug.Log("=== THE DUNGEON ===");
        Debug.Log("Welcome, Dylan. Your escape begins."); // replace Hero with the name of your player.

        Debug.Log("");
        Debug.Log("The Entrance Hall");
        Debug.Log("A torch flickers on the wall. A stone doorway leads north.");
        Debug.Log("You move into the next room.");
        currentRoom += 1;
        if (currentRoom % 3 == 0)
        {
            Debug.Log("This room has a strange red-tinted glow.");
        }

        Debug.Log("");
        Debug.Log("The Guard Room");
        Debug.Log("A rusty sword rests on a table. A goblin snores in the corner.");
        currentRoom += 1;
        if (currentRoom % 3 == 0)
        {
            Debug.Log("This room has a strange red-tinted glow.");
        }
        Debug.Log("You decide to risk it and grab the sword. The commotion wakes up the goblin!");
        attack += 20;
        hitModifier += 3;
        Debug.Log("Your sword increases your damage to " + attack);
        //goblin battle start here
        while (goblinHealth > 0 && health > 0)
        {
            Debug.Log("The goblin attacks you, it's a weak slash of his claws without much force behind it.");
            int goblinHit = Random.Range(1,20);
            if (goblinHit == 20)
            {
                health -= (goblinAttack * 2) - defense;
                Debug.Log("The goblin deals massive damage! You now have: " + health + " HP.");
                if (health <= maxHealth / 2)
                {
                    Debug.Log("You are damaged but steady.");
                }
                else if (health <= maxHealth / 4)
                {
                    Debug.Log("You are gravely injured.");
                }
            }
            else if (goblinHit + goblinHitModifier >= AC)
            {
                health -= (goblinAttack - defense);
                Debug.Log("The goblin's blow lands. You now have: " + health + " health.");
                if (health <= maxHealth / 2)
                {
                    Debug.Log("You are damaged but steady.");
                }
                else if (health <= maxHealth / 4)
                {
                    Debug.Log("You are gravely injured.");
                }
            }
            else
            {
                Debug.Log("The goblin stumbles and misses their attack.");
            }
            int playerHit = Random.Range(1,20);
            if (playerHit == 20)
            {
                goblinHealth -= attack * 2;
                Debug.Log("You dealt massive damage! The goblin now has: " + goblinHealth + " health.");
            }
            else if (playerHit + hitModifier >= goblinAC)
            {
                Debug.Log("You strike back, dealing " + attack + " damage.");
                goblinHealth -= (attack - goblinDefense);
                Debug.Log("The goblin now has: " + goblinHealth + " health.");
            }
            else
            {
                Debug.Log("Your return-attack misses.");
            }
        }
        if (health > 0)
        {
            Debug.Log("The goblin lies defeated on the floor. After the fight, you take a moment to regain your breath, but not too long before you must get moving again.");
        }
        else
        {
            Debug.Log("You were defeated.");
            return;
        }
        //goblin battle end here

        Debug.Log("A fork in the road appears before you, a passage way opening into an open, flooded room, and another passage opening into a room filled with tiny holes - probably for not-so-well-hidden traps.");
        
        Debug.Log("The trapped room");
        currentRoom += 1;
        if (currentRoom % 3 == 0)
        {
            Debug.Log("This room has a strange red-tinted glow.");
        }
        Debug.Log("Despite your best efforts, even knowing that the room was booby-trapped, you mistep and press down something, darts on either side of the wall begin flying!");
        if (agility >= 10)
        {
            Debug.Log("You dodge most of the darts, only one or two hitting your armor. You are nearly unscathed, save for some scraps caught in the struggle.");
            int damage = 5 - defense;
            if (damage < 0)
            {
                damage = 0;
            }
            health -= damage;
            Debug.Log("You currently have: " + health + " HP.");
            if (health <= maxHealth / 2)
                {
                    Debug.Log("You are damaged but steady.");
                }
                else if (health <= maxHealth / 4)
                {
                    Debug.Log("You are gravely injured.");
                }
        }
        else 
        {
            Debug.Log("Your sluggish movements fail to avoid the brunt of the darts, taking a considerable amount of damage. The worst part is you'll have to sit here pulling darts out for a few minutes!");
            int damage = 25 - defense;
            if (damage < 0)
            {
                damage = 0;
            }
            health -= damage;
            Debug.Log("You currently have: " + health + " HP.");
            if (health <= maxHealth / 2)
                {
                    Debug.Log("You are damaged but steady.");
                }
                else if (health <= maxHealth / 4)
                {
                    Debug.Log("You are gravely injured.");
                }
        }
        Debug.Log("You continue on into the next room.");
        // ======================================================================
        // PART A  -  after the INTRO lecture (Debug.Log only)
        // ======================================================================

        // TODO A1: FIX THE BROKEN ROOM below. It has bugs that stops the program
        //          from running. Un-comment the lines, find the bug(s), fix it,
        //          and add a // comment saying what was wrong.
        Debug.Log("The Flooded Passage"); //no ; at the end.
        Debug.Log("Ankle-deep water fills the hall. A broken door is at the end of the hallway.");
        //I decided not to include the red glow check here, since the player won't pass through both rooms.
        Debug.Log("You feel a sharp pain in your foot, either something bit it or you scraped it hard. Best to run first and wonder later.");
        health -= (25 - defense);
        Debug.Log("You have: " + health + " health.");
        if (health <= maxHealth / 2)
                {
                    Debug.Log("You are damaged but steady.");
                }
                else if (health <= maxHealth / 4)
                {
                    Debug.Log("You are gravely injured.");
                }
        Debug.Log("You move into the next room.");

        // TODO A2: write at least one of your OWN room - a Room Name line,
        //          a description line, and a line describing how you exit. 
        Debug.Log("Disarmed Trap Room");
        Debug.Log("A large spiked ball on a steel rod sits in the middle of the room, looks like it was supposed to swing at you.");
        currentRoom += 1;
        if (currentRoom % 3 == 0)
        {
            Debug.Log("This room has a strange red-tinted glow.");
        }
        Debug.Log("A skeleton lays against the wall with some supplies next to it, looks like they took the hit for you.");
        hasKey = true;
        gold += 20;
        defense += 2;
        AC += 2;
        Debug.Log("Key obtained: " + hasKey);
        Debug.Log("You now have: " + gold + " gold.");
        Debug.Log("You pick up a small shield, increasing your defense to: " + defense + ".");

        Debug.Log("Before you can leave, a large orc ducks under the passage way leading to the next room, blocking your path.");
        int orcHealth = 75;
        int orcAttack = 20;
        int orcDefense = 4;
        int orcAC = 12;
        int orcHitModifier = 3;
        bool orcCanAttack = true;

        //orc battle begin here
        while (orcHealth > 0 && health > 0)
        {
            if (orcCanAttack == true)
            {
                Debug.Log("The orc attacks you, a heavy swing threatening to crush you flat.");
                int orcHit = Random.Range(1,20);
                if (orcHit == 20)
                {
                    health -= (orcAttack * 2) - defense; 
                    Debug.Log("The orc deals massive damage! You now have: " + health + " HP.");
                    if (health <= maxHealth / 2)
                    {
                        Debug.Log("You are damaged but steady.");
                    }
                    else if (health <= maxHealth / 4)
                    {
                        Debug.Log("You are gravely injured.");
                    }
                }
                else if (orcHit + orcHitModifier >= AC)
                {
                    health -= (orcAttack - defense);
                    Debug.Log("The orc's blow lands. You now have: " + health + " health.");
                    if (health <= maxHealth / 2)
                    {
                        Debug.Log("You are damaged but steady.");
                    }
                    else if (health <= maxHealth / 4)
                    {
                        Debug.Log("You are gravely injured.");
                    }
                }
                else
                {
                    Debug.Log("The orc stumbles and misses their attack.");
                }
                orcCanAttack = false;
            }
            else
            {
                Debug.Log("The orc readies it's great club to attack...");
                orcCanAttack = true;
            }
            
            int playerHit = Random.Range(1,20);
            if (playerHit == 20)
            {
                orcHealth -= attack * 2;
                Debug.Log("You dealt massive damage! The orc now has: " + orcHealth + " health.");
            }
            else if (playerHit + hitModifier >= orcAC)
            {
                Debug.Log("You strike back, dealing " + attack + " damage.");
                orcHealth -= (attack - orcDefense);
                Debug.Log("The goblin now has: " + orcHealth + " health.");
            }
            else
            {
                Debug.Log("Your return-attack misses.");
            }
        }
        if (health > 0)
        {
            Debug.Log("The orc lies defeated on the floor. After the fight, you take a moment to regain your breath, but not too long before you must get moving again.");
        }
        else
        {
            Debug.Log("You were defeated.");
            return;
        }
        //orc battle end here
        Debug.Log("You walk around the spiked ball and orc corpse, to the archway on the other side.");

        Debug.Log("Merchant Room");
        currentRoom += 1;
        if (currentRoom % 3 == 0)
        {
            Debug.Log("This room has a strange red-tinted glow.");
        }
        Debug.Log("You find a friendly goblin with wares to sell, 5 gold per potion. You have: " + gold + " gold.");
        Debug.Log("You can afford " + gold / 5 + " Potions, and will have " + gold % 5 + " gold leftover."); 
        Debug.Log("You decide to make a camp here."); // i decided to have the healing come before the final fight, itd be useless otherwise
        int campUses = 5;
        while (campUses > 0)
        {
            health += 10;
            if (health > 100)
            {
                health = 100;
            }
            Debug.Log("You healed 10 HP. You now have: " + health + " HP. The campfire has " + campUses + " uses remaining.");
            campUses -= 1;
        }
        Debug.Log("The fire runs out, it's time to move on.");
        
        
        // TODO A3: write the EXIT room - a final "room" and description that leads the
        //          player out of the dungeon.
        Debug.Log("Exit Room");
        Debug.Log("Sunlight streams in through the cracks in the cieling, and through a slit in the massive stone doors.");
        currentRoom += 1;
        if (currentRoom % 3 == 0)
        {
            Debug.Log("This room has a strange red-tinted glow.");
        }
        Debug.Log("Before you can breathe a sigh of relief, your ears take notice of a light, but noticeable tick-tacking noise on the cieling, looking up to see a humungous sider staring down at you.");
        int spiderHealth = 75;
        int spiderAttack = 10;
        int spiderDefense = 3;
        int spiderAC = 13;
        int spiderHitModifier = 4;
        bool playerPoisoned = false;
        int poisonTimer = 0;
        //spider battle start here
        while (spiderHealth > 0 && health > 0)
        {
            if (playerPoisoned == true)
            {
                health -= 10;
                Debug.Log("You feel poison coursing through you! You now have: " + health + " HP.");
                if (health <= maxHealth / 2)
                {
                    Debug.Log("You are damaged but steady.");
                }
                else if (health <= maxHealth / 4)
                {
                    Debug.Log("You are gravely injured.");
                }
                poisonTimer -= 1;
                if (poisonTimer == 0)
                {
                    playerPoisoned = false;
                    Debug.Log("You feel the venom's sting finally start to subside.");
                }
            }
            Debug.Log("The spider attacks you, attempting to pierce your skin with it's fangs.");
            int spiderHit = Random.Range(1,20);
            if (spiderHit == 20)
            {
                health -= (spiderAttack * 2) - defense;
                int poisonAttempt = Random.Range(1,3);
                if (playerPoisoned == false && poisonAttempt == 3)
                {
                    playerPoisoned = true;
                    poisonTimer = 2;
                    Debug.Log("You have been poisoned!");
                }
                Debug.Log("The spider deals massive damage! You now have: " + health + " HP.");
                if (health <= maxHealth / 2)
                {
                    Debug.Log("You are damaged but steady.");
                }
                else if (health <= maxHealth / 4)
                {
                    Debug.Log("You are gravely injured.");
                }
            }
            else if (spiderHit + spiderHitModifier >= AC)
            {
                health -= (spiderAttack - defense);
                Debug.Log("The spider sinks it's teeth into you. You now have: " + health + " health.");
                int poisonAttempt = Random.Range(1,3);
                if (playerPoisoned == false && poisonAttempt == 3)
                {
                    playerPoisoned = true;
                    poisonTimer = 2;
                    Debug.Log("You have been poisoned!");
                }
                if (health <= maxHealth / 2)
                {
                    Debug.Log("You are damaged but steady.");
                }
                else if (health <= maxHealth / 4)
                {
                    Debug.Log("You are gravely injured.");
                }
            }
            else
            {
                Debug.Log("The goblin stumbles and misses their attack.");
            }
            int playerHit = Random.Range(1,20);
            if (playerHit == 20)
            {
                spiderHealth -= attack * 2;
                Debug.Log("You dealt massive damage! The spider now has: " + spiderHealth + " health.");
            }
            else if (playerHit + hitModifier >= spiderAC)
            {
                Debug.Log("You strike back, dealing " + attack + " damage.");
                spiderHealth -= (attack - spiderDefense);
                Debug.Log("The spider now has: " + spiderHealth + " health.");
            }
            else
            {
                Debug.Log("Your return-attack misses.");
            }
        }
        if (health > 0)
        {
            Debug.Log("The spider lies defeated on the floor. After the fight, you take a moment to regain your breath, but not too long before you must get moving again.");
        }
        else
        {
            Debug.Log("You were defeated.");
            return;
        }
        //spider battle end here
        if (hasKey == true)
        {
            Debug.Log("You push open the stone doors after slotting your key into a golden lock, more and more sunlight hitting your skin, your eyes having to adjust.");
            hasKey = false;
            return;
        }
        else 
        {
            Debug.Log("A lock is fastened tightly to the door, you'll have to return with a key.");
        }
        // ======================================================================
        // PART B  -  after the VARIABLES lecture (variables & operators)
        // ======================================================================

        // TODO B2: FIX THE BROKEN ROOM below. It has bugs that stops the program
        //          from running. Un-comment the lines, find the bug(s), fix it,
        //          and add a // comment saying what was wrong.
        //int gold = 15;
        //already initialized earlier.
        Debug.Log("The Treasure Room");// missing quotation marks.
        Debug.Log("It seems this room has been raided. You find 5000 gold."); //technically not an error but you don't really need to make 5000 it's own separate thing.
        Debug.Log("You move into the next room."); //missing a quotation after the period and a semicolon at the end.

        // TODO B3: Go back through your rooms above and add an event/item to each
        //          one that changes a stat/variable, printing the new value right
        //          after the event. Like with the gold in the treasure room, keep
        //          each event inside the room where it happens. Possible events:
        //            pick up a sword to increase attack      
        //            step on a trap        
        //            grab the rusty key    
        //            (your own event)

        // TODO B4: In the appropriate room, add a goblin. The goblin attacks the
        //          player and the player attacks the goblin. Use the variables
        //          you've created in PART A to simulate this with code. After the
        //          simulation is done, Print both healths, then print whether or 
        //          not the goblin is defeated. 

        // TODO B5: Add a new room somewhere before the exit that has a merchant. 
        //          The merchant sells potions for 5 gold each. Print how many
        //          potions you can afford and how much gold you will have left over. 

        // TODO B6: Add a defense stat (declare it up top with the others). Use it
        //          in your combat so the goblin's hit damage is reduced by your
        //          defense and your hit damage is reduced by the goblin's defense
        //          Then, add an item that raises defense in a room. 


        // ================= PART A - CONDITIONALS (do after L7) =================

        // A1: After the goblin fight, report whether the goblin was defeated or

        //     the hero was the one who fell.

        // A2: At a vault door, the hero may pass only if they are carrying the

        //     key and are still alive. If they cannot pass, report which of the

        //     two requirements they are missing.

        // A3: The passage forks in two. Send the hero down one of the routes and

        //     describe each one - the two routes may even rejoin at the same

        //     place further on.

        // A4: As the hero explores, every third room they enter has a red glow.

        //     Given the number of the room the hero is standing in, report

        //     whether this room has the red glow.

        // A5: Whenever the hero takes damage, report their condition: collapsed

        //     if no health remains, badly wounded if their health has dropped

        //     dangerously low, or otherwise hurt but steady. This is a snippet

        //     you will reuse a lot - go back through everything you have already

        //     written (INCLUDING your previous assignment) and drop it in right

        //     after every place the hero loses health (the spike trap, and

        //     anywhere else). You will add it again in Part B after each hit the

        //     hero takes in a fight.

 

        // ================= PART B - LOOPS (do after L8) =================

        // Place the following combat encounters in different rooms of your choice.

        // B1: A goblin blocks the way - fight it round by round until one of you

        //     runs out of health. Give the hero and the goblin each an armor

        //     class. On every swing, roll a die (Random.Range works well) and

        //     compare it to the target's armor class: the blow only lands if the

        //     roll meets or beats that armor class. On top of that, any of the

        //     hero's landed hits can be a critical hit that deals extra damage.

        //     Report each roll and its result, and after any round in which the

        //     hero takes damage, run your A5 condition check.

        // B2: Beyond the goblin waits an ogre - slow, but brutal. Fight it the

        //     same way (armor classes, dice rolls to hit, and the hero's chance

        //     to crit), except the ogre is so sluggish it only swings every

        //     other round. Fight until one of them falls, and keep running your

        //     A5 check whenever the hero takes damage.

        // B3: Then a giant spider drops from the ceiling. Fight it just like the

        //     ogre - dice-and-armor-class swings, the hero's crits, and it too

        //     only strikes every other round - but its bite is venomous: any

        //     time it lands a hit, the hero is poisoned and loses 2 health at

        //     the start of each of the next three rounds, on top of the bite

        //     itself. Fight until one of them falls, running your A5 check after

        //     any damage (including the poison ticks).

        // B4: With the fights behind them, the hero rests at a campfire,

        //     recovering a little health each turn until fully healed or the

        //     fire dies after a set number of turns. Report their health as it

        //     climbs, and never let it rise above the maximum.
    }
}
