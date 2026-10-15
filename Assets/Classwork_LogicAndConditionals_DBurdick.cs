using UnityEngine;

// L7 - Comparison, Logic & Conditionals (In-Class Reps)
// Work through the TODOs. Attach this to an empty GameObject and press Play to test.
public class L7_Logic_Conditionals_Reps : MonoBehaviour
{
    void Start()
    {
        // ============================================================
        // A1: True or False (answer in a comment)
        // ============================================================
        // 1. 5 == 5
        // Answer: True
        // 2. 5 != 5
        // Answer: False (!= means "does not equal")
        // 3. 7 > 3
        // Answer: True
        // 4. 7 < 3
        // Answer: False
        // 5. 4 >= 4
        // Answer: True (>= is more than *or* equal to)
        // 6. 6 <= 2
        // Answer: False

        // ============================================================
        // A2: Evaluate the Logic (write the result)
        // ============================================================
        // 7. true && false
        // Answer: Will not run anything below it, because nothing can be true and false
        // 8. false || true
        // Answer: Will run, || means "or"
        // 9. !true
        // Answer: Means false
        // 10. (2 > 1) && (3 > 2)
        // Answer: Will run

        // These values are shared by A3, A5 and A6 below.
        int health = 20;
        int gold = 100;
        bool hasKey = true;

        // ============================================================
        // A3: Scenario - True or False (health = 20, gold = 100, hasKey = true)
        // ============================================================
        // 11. health < 30
        // Answer: True
        // 12. hasKey && health > 50
        // Answer: False
        // 13. !hasKey
        // Answer: False
        // 14. gold >= 100 || hasKey
        // Answer: True

        // ============================================================
        // A4: Predict What Prints (write your prediction, then test)
        // ============================================================
        // 15.
        //     int h = 0;
        //     if (h <= 0)
        //     {
        //         Debug.Log("dead");
        //     }
        //     else
        //     {
        //         Debug.Log("alive");
        //     }
        // Answer: dead
        //
        // 16.
        //     int s = 75;
        //     if (s >= 90)
        //     {
        //         Debug.Log("A");
        //     }
        //     else if (s >= 70)
        //     {
        //         Debug.Log("C");
        //     }
        //     else
        //     {
        //         Debug.Log("F");
        //     }
        // Answer: C

        // ============================================================
        // A5: Fix the Bug (write the corrected code)
        // ============================================================
        // 17. This should print "dead" when health is 0, but it has a bug:
        //     if (health = 0)
        //     {
        //         Debug.Log("dead");
        //     }
        //
        if (health == 0) //was missing the "==" here, since it's comparing rather than setting a value.
             {
                 Debug.Log("dead");
             }
        // 18. Both calls are meant to run only when hasKey is true,
        //     but right now only the first one is:
        //     if (hasKey)
        //         Open();
        //         Enter();
        // if (hasKey) // Missing the {}
        //     {
        //         Open();
        //         Enter();
        //     }
        // ============================================================
        // A6: Problem Solving (write the code)
        // ============================================================
        // 19. Make ONE boolean called canOpenVault that is true only when
        //     hasKey is true AND health is greater than 0.

            bool canOpenVault;
                if (hasKey == true && health > 0)
                {
                    canOpenVault = true;
                    Debug.Log(canOpenVault);
                }

        // 20. Using the health above, write an if / else-if / else that prints
        //     "Dead" when health <= 0, "Low" when health < 30, otherwise "Fine".
        if (health <0)
        {
            Debug.Log("Dead");
        }
        else if (health < 30)
        {
            Debug.Log("Low");
        }
        else
        {
            Debug.Log("Fine");
        }

        // 21. Apply a trap (health -= 50), then clamp health so it never goes
        //     below 0.

        health -= 50;
        if (health < 0)
        {
            health = 0;
        }

        // 22. LETTER GRADE: given int score (for example 75), print A, B, C, D
        //     or F using the 90 / 80 / 70 / 60 cutoffs.
        int score = 75;
        if (score >= 90)
        {
            Debug.Log('A');
        }
        else if (score >= 80)
        {
            Debug.Log('B');
        }
        else if (score >= 70)
        {
            Debug.Log('C');
        }
        else if (score >= 60)
        {
            Debug.Log('D');
        }
        else 
        {
            Debug.Log('F');
        }

        // 23. LEAP YEAR: given int year, print whether it is a leap year.
        //     A year is a leap year when it is divisible by 4, except that
        //     century years must also be divisible by 400.
        int year = 2024;
        if (year % 400 == 0 && year % 4 == 0)
        {
            Debug.Log("Leap year!!");
        }
        else if (year % 400 != 0 && year % 4 == 0)
        {
            Debug.Log("Leap year!!!");
        }
        else
        {
            Debug.Log("Not a leap year...");
        }

        // 24. FIZZBUZZ (one number): given int n, print "Fizz" if it is
        //     divisible by 3, print "Buzz" if it is divisible by 5, print
        //     "FizzBuzz" if it is divisible by both 3 and 5, otherwise print
        //     the number itself.
        int number = 15;
        if (number % 3 == 0 && number % 5 == 0)
        {
            Debug.Log("FizzBuzz");
        }
        else if (number % 3 == 0 && number % 5 != 0)
        {
            Debug.Log("Fizz");
        }
        else if (number % 3 != 0 && number % 5 == 0)
        {
            Debug.Log("Buzz");
        }
        else
        {
            Debug.Log(number);
        }
    }
}
