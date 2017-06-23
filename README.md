# QuoteGenerator
Generates quotes for LDPE Bags

This program has a few methods, two that are dependent on the first one functioning properly. 
The GetData() method, grabs all of the user data from the form and saves it to an array. This array is the return value for the method. If you look inside the form1.cs file, you can see the order in which the data is stored in the comments. 
The GetData() method passes and array through to either the BagCalculator(double[6]) method, or the RollCalculator(double[6]) method. These take the same kinds of data, but depending on the product type, the total weight is calculated slightly different. 
Finally the last method, SaveToResults(string[10]), takes an array of strings created at the end of the button click method and writes the array to a record of a multidimensional array. This multi dimensional array stores all of the quote data during the program instance, and at the end of using the program, the Save button can be clicked to save all quote data to a .txt file.
