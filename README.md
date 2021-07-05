# CASH Masters POS App

Point of Sale Application that calculates the optimal money change (the less amount bills and coins) to return when using a cash register.

## Purpose

The purpose of this application is to return the optimal change using the less amount of bills and coins based on a country set of denominations (different types of bills and coins).

## Inputs

The calculator takes two inputs:

-	Price of the item being purchased
-	All bills and coins provided by the customer to pay for the item

### Example
An input example can be: 


 ```c# 
 decimal itemPrice = 150.00m;
 ```
 
 
 ```c#
 decimal[] billsAndCoins = new decimal[]{ 100.00m, 100.00m }
 ```


For all inputs the Decimal type is used as money is being handled.

## Outputs

- Returns an optimal (minimum) set of bills and coins that represents the change due to the customer using the available denominations for the country configured.
### Example
An example output for the input mentioned above will be:


`[50.00m]` <-- This represents the output array that contains only 1 bill of value **$50.00** after processing the inputs (an item with a price of $150.00 will be paid using two bills
with a value of $100.00) Therefore the change due will be 50.00 (which is the only bill in the array). If the change due happened to be **$55.00** then the result would be something like this:


`[50.00m, 5.00m]` <-- This represents an output that contains a bill of $50.00 and a coin of $5.00. So depending on the change due and on the denominations available for that country, the calculator
will return the minimum amount of bills and coins in the array.

## Usage

```c#
          // The price of the Item being purchased
          decimal itemPrice = 145m;
          // The cash provided by the customer to buy the item
          decimal[] cashProvided = new decimal[]{100m, 100m};
          
          // Create the calculator Object
          POSChangeCalculator calculator = new POSChangeCalculator();
          
          //Call the ReturnOptimalChange() method and pass the input parameters to generate the optimal change array.
          decimal[] result = calculator.ReturnOptimalChange(itemPrice, cashProvided);
          
         // In this case, the result variable will contain the following array: [50.00, 55.00]
          
```

## Configuration

The calculator can be configured to use different country denominations. The current supported countries are: **Mexico** and **US**.

### appconfig.json

To change this configuration you need to modify the `appconfig.json` file and set the `DenominationCountry` setting to the country needed.

Currently supported values:

- `US`
- `Mexico`

### Example
```json
{
    "DenominationCountry" : "Mexico" 
}
```

or 

```json
{
    "DenominationCountry" : "US" 
}
```

## Notes

The calculator takes as input arrays of type **decimal** and returns outputs of the same. It is recommended to use this data structure to perform the operations with the calculator.


