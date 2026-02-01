using UnityEngine;

public class Problem2 : MonoBehaviour
{
    //Summary
    //Suppose that the cover price of a book is $X, but the bookstores get a 40% discount.
    //Shipping costs $3 for the first copy and ¢75 for each additional copy. Calculate the
    //total wholescale cost and profit (before operational costs) when the bookstore sells
    // Y copies of a book. I want to enter the X and Y values and get the cost and the
    // profit as a meaningful output.
    //Summary

    [SerializeField]protected float coverPrice = 0f;
    [SerializeField]protected int numberOfCopies = 0;
    [SerializeField]protected float sellingPricePerCopy = 0f;
    

    void OnValidate()
    {
        PublicCalculateProfitAndCost();
    }

    void Start()
    {
        PublicCalculateProfitAndCost();
    }

    public void PublicCalculateProfitAndCost()
    {
        string result = CalculateProfitAndCost(coverPrice, numberOfCopies, sellingPricePerCopy);
        Debug.Log(result);
    }

    protected string CalculateProfitAndCost(float coverPrice, int numberOfCopies, float sellingPricePerCopy)
    {
        //Calculate wholesale price after 40% discount
        float wholesalePrice = coverPrice * 0.6f;

        //Calculate shipping cost
        float shippingCost = 3f; // Cost for the first copy
        if (numberOfCopies > 1)
        {
            shippingCost += (numberOfCopies - 1) * 0.75f; // Additional copies
        }

        //Calculate total wholesale cost
        float totalWholesaleCost = (wholesalePrice * numberOfCopies) + shippingCost;

        //Calculate total revenue from selling the books
        float totalRevenue = sellingPricePerCopy * numberOfCopies;

        //Calculate profit
        float profit = totalRevenue - totalWholesaleCost;

        //Return meaningful output
        return $"Total Wholesale Cost: ${totalWholesaleCost:F2}, Total Revenue: ${totalRevenue:F2}, Profit: ${profit:F2}";
    }
}
