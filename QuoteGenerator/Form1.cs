using System;
using System.Windows.Forms;
using System.IO;

namespace QuoteGenerator
{



    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        //Declare a variable to be assigned later indicating the type of product.
        string type = "";
        //Declare a constant to be the number of records in the results[,] array
        const int TOTAL_NUM_OF_QUOTES = 25;

        //Declare results multidimensional array which will store all quotes from the program instance in memory, to be saved when quoting is complete.
        string[,] results = new string[TOTAL_NUM_OF_QUOTES, 10];
        //statring point for the results array; when a quote is generated it will be saved a the results[quoteNum] index
        int quoteNum = 0;
        private void constructionComboBox_Click(object sender, EventArgs e)
        {
            //This method shows which text boxes and labels the program should show the user, based on which bag is selected. Try Cath statements are used to catch a null reference.
            try
            {
                //Sets the .Visible property of all the text boxts to whatever boolean value is passed throught the method.
                TextBoxVisible(true);
                //Clears the values the .Text properties of all text boxes onthe form.
                ClearText();
                outputLabel.Text = "";

                //switch statement turns off irrelevant boxes and labels for the bagConstruction
                switch (constructionComboBox.SelectedItem.ToString())
                {
                    case "Bottom Seal Bag":
                        //Sets type to bag, hides the Gusset and Lip controls, while also putting the 0 value in the .Text property.
                        //The 0 value must be present for any hidden components to prevent a false Null Reference exception.
                        type = "Bag";
                        HideGussetControls();
                        HideLipControls();
                        break;
                    case "Side Gusset Bag":
                        //Sets type to bag and hides the Lip controls
                        type = "Bag";
                        HideLipControls();
                        break;
                    case "Zipper Bag":
                        //Sets type to bag and hides the Gusset controls
                        type = "Bag";
                        HideGussetControls();
                        break;
                    case "Lip & Tape Bag":
                        //Sets the type to bag and hides the Gusset Controls
                        type = "Bag";
                        HideGussetControls();
                        break;
                    case "Tubing Roll":
                        //Sets type to roll and hired the gusset and lip controls
                        type = "Roll";
                        HideGussetControls();
                        HideLipControls();
                        break;
                    case "Gusseted Tubing Roll":
                        //Sets type to roll and hides the lips controls
                        type = "Roll";
                        HideLipControls();
                        break;
                    default:
                        //In case someone tries to enter their own text in the combo box
                        outputLabel.Text = "Please enter a valid construction.";
                        break;
                }
            }
            catch(NullReferenceException)
            {
                outputLabel.Text = "Please select an option from the drop down menu.";         
                TextBoxVisible(false);
            }
        }
        private void quoteButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Declare variables
                //bagConstruction will end up in results array
                string bagConstruction = constructionComboBox.SelectedItem.ToString();

                //totalWeight will be calculated with custom methods below, based on bagConstruction
                double totalWeight = 0;

                //this data is where all the user inputed data will be stored, so that it can easily be passed through a method as a single argument
                string[] dataStrings = new string[6];
                double[] data = new double[6];
                //GetItemData collects user input and assigns the data to the data array. This array should be emptied every 
                //time the button is clicked, and is only accessed from within the click button method so I've declared it 
                //within the method instead of outside the method.
                dataStrings = GetItemData();
                //This Arr.ConvertAll method uses a custom method at the bottom of this file that turns all string records in an array to doubles.
                data = Array.ConvertAll(dataStrings, new Converter<string, double>(StringToDouble));


                //This is where the results will results will write to at the end of the quoteButton_Click() method
                string outputText;

                //This is the target price per pound for the quote.
                double priceNum = Convert.ToDouble(priceTextBox.Text);

               

                //Convert data[] array to variable Strings for both outputText, and results[] arrya
                string width, gusset, length, lip, mil, qty, price, totalSale;
                width = dataStrings[0];
                gusset = dataStrings[1];
                length = dataStrings[2];
                lip = dataStrings[3];
                mil = (Convert.ToDouble(dataStrings[4]) / 1000).ToString();
                qty = dataStrings[5];
                price = priceNum.ToString("C");


                //determine which method is appropraite for the bag construction                
                    if (type == "Bag")
                    {
                        totalWeight = BagCalculator(data);
                    }
                    else if (type == "Roll")
                    {
                        totalWeight = RollCalculator(data);
                    }
            
                //Get sale price as a string
                totalSale =(priceNum * totalWeight).ToString("C");

                //based on bagConstrucion, the outputText is different. 
                switch (bagConstruction)
                {
                    case "Bottom Seal Bag":
                        outputText = String.Format("{0}\n{1}\"x{2}\"x{3}\n{4} Total for {5} units at {6} per pound", bagConstruction, width, length, mil, totalSale, qty, price);
                        break;
                    case "Side Gusset Bag":
                        outputText = String.Format("{0}\n{1}\"x{2}\"x{3}\"x{4}\n{5} Total for {6} units at {7} per pound", bagConstruction, width, gusset, length, mil, totalSale, qty, price);
                        break;
                    case "Zipper Bag":
                        outputText = String.Format("{0}\n{1}\"x{2}\"+{3}\"x{4}\n{5} Total for {6} units at {7} per pound", bagConstruction, width, length, lip, mil, totalSale, qty, price);
                        break;
                    case "Lip & Tape Bag":
                        outputText = String.Format("{0}\n{1}\"x{2}\"+{3}\"x{4}\n{5} Total for {6} units at {7} per pound", bagConstruction, width, length, lip, mil, totalSale, qty, price);
                        break;
                    case "Tubing Roll":
                        outputText = String.Format("{0}\n{1}\"x{2}'x{3}\n{4} Total for {5} units at {6} per pound", bagConstruction, width, length, mil, totalSale, qty, price);
                        break;
                    case "Gusseted Tubing Roll":
                        outputText = String.Format("{0}\n{1}\"x{2}\"x{3}'x{4}\n{5} Total for {6} units at {7} per pound", bagConstruction, width, gusset, length, mil, totalSale, qty, price);
                        break;
                    default:
                        outputText = "Try again";
                        break;
                }
                outputLabel.Text = outputText;

                /* Declare and initialize all quote data to be passed through the 
                SendToResults() method, which uses a loop to write all this data into a multidimensional array*/ 

                string[] quoteData = new string[10] { width, gusset, length, lip, mil, qty, price, totalWeight.ToString(), totalSale, bagConstruction };
                
                /* Legend for quoteData[] is:
                     0: width
                     1: gusset
                     2: length
                     3: lip
                     4: mil
                     5: qty
                     6: price (price per pound)
                     7: totalWeight
                     8: total Sale   
                     9: bagConstruction                    
                 
                Send array to multidimensional results[,] array.*/
                SendToResults(quoteData);
                ++quoteNum;
                ClearText();
            }
            catch(FormatException)
            {
                outputLabel.Text = "Whoops! You need to put numbers in all of the required fields to the left.";
            }
        }     
        private string[] GetItemData()
        {
            /*This Method grabs all the user data and returns it as an array to be passed into either of the calculator methods
             * Legend for data array records:
            0: Width
            1: Gusset
            2: Length
            3: Lip
            4: mil
            5: Quantity

            The calculator methods needs them all as doubles, so all of the text is converted to doubles here.
            ***NOTE*** THIS DOES NOT GRAB THE PRICE TEXT. The price per pound does not need to go into the claculator
            methods so the price is grabbed separately within the Main() method.*/
            string width, gusset, length, lip, mil, qty;
            width = widthTextBox.Text;
            gusset = gussetTextBox.Text;
            length = lengthTextBox.Text;
            lip = lipTextBox.Text;
            mil = milTextBox.Text;
            qty = quantityTextBox.Text;
            string[] itemDataStrings = new string[6] { width, gusset, length, lip, mil, qty };
            return itemDataStrings;
        }        
        private double BagCalculator(double[] itemData)
        {
            //Calculator for if the item is a bag.
            double width, gusset, length, lip, mil, qty;
            width = itemData[0];
            gusset = itemData[1];
            length = itemData[2];
            lip = itemData[3];
            mil = itemData[4];
            qty = itemData[5];
            double totalWeight = ((width + gusset) * (length + lip) * mil) / 15000 * qty;
            return totalWeight;
        }        
        private double RollCalculator(double[] itemData)
        {
            //Calculator for if the item is a roll
            double width, gusset, length, lip, mil, qty;
            width = itemData[0];
            gusset = itemData[1];
            length = itemData[2];
            lip = itemData[3];
            mil = itemData[4];
            qty = itemData[5];
            double totalWeight = ((width + gusset) * length * mil * 12) / 15000 * qty;
            return totalWeight;
        }
        private void SendToResults(string[] quoteData)
        {
            //Method that takes the quote results and sends them to the results[,] array
            for (int itemRecord = 0; itemRecord < quoteData.Length; ++itemRecord)
            {
                results[quoteNum, itemRecord] = quoteData[itemRecord];
            }

        }
        private void saveQuotesButton_Click(object sender, EventArgs e)
        {
            //Event Method to save the array to a txt file.
            saveFileDialog.ShowDialog();
            string path = saveFileDialog.FileName;

            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);

            for(int quoteNum = 0; quoteNum < TOTAL_NUM_OF_QUOTES; ++quoteNum)
            {
                if (results[quoteNum, 0] != null) 
                {
                    writer.WriteLine("Bag Type: " + results[quoteNum, 9]);
                    writer.WriteLine("Width: " + results[quoteNum, 0]);
                    writer.WriteLine("Gusset: " + results[quoteNum, 1]);
                    writer.WriteLine("Length: " + results[quoteNum, 2]);
                    writer.WriteLine("Lip: " + results[quoteNum, 3]);
                    writer.WriteLine("Mil: " + results[quoteNum, 4]);
                    writer.WriteLine("Qty: " + results[quoteNum, 5]);
                    writer.WriteLine("Price Per Pound: " + results[quoteNum, 6]);
                    writer.WriteLine("Total Weight: " + results[quoteNum, 7]);
                    writer.WriteLine("Total Sale: " + results[quoteNum, 8]);
                    writer.WriteLine("\n");
                }

            }
            writer.Close();
            fs.Close();
        }
        private void ClearText()
        {
            //Clears the data from all text boxes
            widthTextBox.Text = "";
            lengthTextBox.Text = "";
            gussetTextBox.Text = "";
            lipTextBox.Text = "";
            milTextBox.Text = "";
            quantityTextBox.Text = "";
            priceTextBox.Text = "";
        }
        private void TextBoxVisible(bool vis)
        {
            //Sets all .Visible values to the boolean value passed through the method
            quoteButton.Visible = vis;
            widthTextBox.Visible = vis;
            widthLabel.Visible = vis;
            lengthTextBox.Visible = vis;
            lengthLabel.Visible = vis;
            milTextBox.Visible = vis;
            milLabel.Visible = vis;
            quantityTextBox.Visible = vis;
            quantityLabel.Visible = vis;
            priceTextBox.Visible = vis;
            priceLabel.Visible = vis;
            gussetTextBox.Visible = vis;
            gussetLabel.Visible = vis;
            lipTextBox.Visible = vis;
            lipLabel.Visible = vis;
        }
        private void HideGussetControls()
        {
            //hides gusset controls, and sets the text box value to 0. This prevents a false Null Response exception, while notinterfering with the calculator formulas since the gusset is added to the width.
            gussetTextBox.Visible = false;
            gussetTextBox.Text = "0";
            gussetLabel.Visible = false;
        }
        private void HideLipControls()
        {
            //hides lip controls and sets the text box to 0 for the same reason as the gusset box being set to zero.
            lipTextBox.Visible = false;
            lipTextBox.Text = "0";
            lipLabel.Visible = false;
        }
        public static double StringToDouble(string input)
        {
            //Converter method to convert strings in an array to doubles. 
            double output = Convert.ToDouble(input);
            return output;
        }
    }
}
