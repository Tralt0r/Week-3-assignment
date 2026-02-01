using Unity.VisualScripting;
using UnityEngine;


public class Problem1 : MonoBehaviour
{
    //Summary
    //You are supposed to be paid $X dollars. How many bills of hundred,
    //fifty, twenty, ten, five, or one will you get? (For example, if you
    //are to be paid $47, you will get 2 x $20 bills, 1 x $5 bill, and 2 x $1 bills.)

    [Header("Input Cash Amount")]
    [Space]
    //Amount to be paid
    [SerializeField]protected float amount = 0f;

    [Header("Customize Bill Types")]
    [Space]
    //Customize bills
    [SerializeField]protected bool wantsHundreds;
    [SerializeField]protected bool wantsFifties;
    [SerializeField]protected bool wantsTwenties;
    [SerializeField]protected bool wantsTens;
    [SerializeField]protected bool wantsFives;
    [SerializeField]protected bool wantsOnes;

    public void Start()
    {
        InsertCash((int)amount);
    }

    void OnValidate()
    {
        InsertCash((int)amount);
    }

    public void InsertCash(int amount)
    {
        this.amount = amount;
        CalculateTotalCash();
    }

    protected string CalculateTotalCash()
    {
        //Temporary variable to hold current amount
        int currentAmount = (int)amount;

        //Calculate Hundreds
        int hundreds = 0;
        if (wantsHundreds)
        {
            hundreds = currentAmount / 100;
            if (hundreds > 0)
            {
                currentAmount = currentAmount - (hundreds * 100);
            }
        }
        
        //Calculate Fifties
        int fifties = 0;
        if (wantsFifties)
        {
            fifties = currentAmount / 50;
            if (fifties > 0)
            {
                currentAmount = currentAmount - (fifties * 50);
            }
        }

        //Calculate Twenties
        int twenties = 0;
        if (wantsTwenties)
        {
            twenties = currentAmount / 20;
            if (twenties > 0)
            {
                currentAmount = currentAmount - (twenties * 20);
            }
        }

        //Calculate Tens
        int tens = 0;
        if (wantsTens)
        {
            tens = currentAmount / 10;
            if (tens > 0)
            {
                currentAmount = currentAmount - (tens * 10);
            }
        }

        //Calculate Fives
        int fives = 0;
        if (wantsFives)
        {
            fives = currentAmount / 5;
            if (fives > 0)
            {
                currentAmount = currentAmount - (fives * 5);
            }
        }

        //Calculate Ones
        int ones = 0;
        if (wantsOnes)
        {
            ones = currentAmount / 1;
            if (ones > 0)
            {
                currentAmount = currentAmount - (ones * 1);
            }
        }


        Debug.Log("Hundreds: " + hundreds + ", Fifties: " + fifties + ", Twenties: " + twenties 
        + ",Tens: " + tens + ", Fives: " + fives + ", Ones: " + ones);

        return "Hundreds: " + hundreds + ", Fifties: " + fifties + ", Twenties: " + twenties 
        + ",Tens: " + tens + ", Fives: " + fives + ", Ones: " + ones;
    }
}
