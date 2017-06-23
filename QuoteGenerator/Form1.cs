using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        
        string type = "";
        string[,] results = new string[25, 10];
        int quoteNum = 0;

        //This entire method is a very verbose chunk of code, that just chooses what text boxes and labels to show based on the construction
        private void constructionComboBox_Click(object sender, EventArgs e)
        {
            try
            {
                //Once the button is clicked, they are all set to visible
                quoteButton.Visible = true;
                widthTextBox.Visible = true;
                widthLabel.Visible = true;
                lengthTextBox.Visible = true;
                lengthLabel.Visible = true;
                milTextBox.Visible = true;
                milLabel.Visible = true;
                quantityTextBox.Visible = true;
                quantityLabel.Visible = true;
                priceTextBox.Visible = true;
                priceLabel.Visible = true;

                //switch statement turns off irrelevant boxes and labels for the bagConstruction
                switch (constructionComboBox.SelectedItem.ToString())
                {
                    case "Bottom Seal Bag":
                        type = "Bag";
                        gussetTextBox.Visible = false;
                        gussetLabel.Visible = false;
                        lipTextBox.Visible = false;
                        lipLabel.Visible = false;
                        break;
                    case "Side Gusset Bag":
                        type = "Bag";
                        gussetTextBox.Visible = true;
                        gussetLabel.Visible = true;
                        lipTextBox.Visible = false;
                        lipLabel.Visible = false;
                        break;
                    case "Zipper Bag":
                        type = "Bag";
                        gussetTextBox.Visible = false;
                        gussetLabel.Visible = false;
                        lipTextBox.Visible = true;
                        lipLabel.Visible = true;
                        break;
                    case "Lip & Tape Bag":
                        type = "Bag";
                        gussetTextBox.Visible = false;
                        gussetLabel.Visible = false;
                        lipTextBox.Visible = true;
                        lipLabel.Visible = true;
                        break;
                    case "Tubing Roll":
                        type = "Roll";
                        gussetTextBox.Visible = false;
                        gussetLabel.Visible = false;
                        lipTextBox.Visible = false;
                        lipLabel.Visible = false;
                        break;
                    case "Gusseted Tubing Roll":
                        type = "Roll";
                        gussetTextBox.Visible = true;
                        gussetLabel.Visible = true;
                        lipTextBox.Visible = false;
                        lipLabel.Visible = false;
                        break;
                    default:
                        outputLabel.Text = "Please enter a valid construction.";
                        break;
                }
                //Resets all values back to empty or 0 each time the bagConstruction button is clicked. 
                widthTextBox.Text = "";
                lengthTextBox.Text = "";
                gussetTextBox.Text = "0";
                lipTextBox.Text = "0";
                milTextBox.Text = "";
                quantityTextBox.Text = "";
                priceTextBox.Text = "";
                outputLabel.Text = "";
            }
            catch(NullReferenceException nr)
            {
                outputLabel.Text = "Please select an option from the drop down menu.";
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
                double[] data = new double[6];
                //GetItemData collects user input and assigns the data to the data array. This array should be emptied every 
                //time the button is clicked, and is only accessed from within the click button method so I've declared it 
                //within the method instead of outside the method.
                data = GetItemData();              
                
                //This is where the results will results will write to at the end of the quoteButton_Click() method
                string outputText;

                //This is the target price per pound for the quote.
                double priceNum = Convert.ToDouble(priceTextBox.Text);

                //This the total sale amount for the quote. 
                double totalSaleNum;

                //Convert data[] array to variable Strings for both outputText, and results[] arrya
                string width, gusset, length, lip, mil, qty, price, totalSale;
                width = data[0].ToString();
                gusset = data[1].ToString();
                length = data[2].ToString();
                lip = data[3].ToString();
                mil = (data[4] / 1000).ToString();
                qty = data[5].ToString();
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
              

                //Calculate total sale price
                totalSaleNum = priceNum * totalWeight;
                //Get sale price as a string
                totalSale = totalSaleNum.ToString("C");

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

                //Declare and initialize all quote data to be passed through the 
                //SendToResults() method, which uses a loop to write all this data into a multidimensional array;
                string[] quoteData = new string[10] { width, gusset, length, lip, mil, qty, price, totalWeight.ToString(), totalSale, bagConstruction };
                /*
                 quote data array is:
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
                 */
                //Send array to multidimensional results[,] array.
                SendToResults(quoteData);
                ++quoteNum;
            }
            catch(FormatException fe)
            {
                outputLabel.Text = "Whoops! You need to put numbers in all of the required fields to the left.";
            }
        }

        
        private double[] GetItemData()
        {
            //This Method grabs all the user data and returns it as an array to be passed into either of the calculator methods
           
            /*
            Legend for data array records:
            0: Width
            1: Gusset
            2: Length
            3: Lip
            4: mil
            5: Quantity
            
             */
            //The calculator needs them all as doubles, so all of the text is converted to doubles here.
            //NOTE: THIS DOES NOT GRAB THE PRICE TEXT. The price per pound does not need to go into the claculator
            //methods so the price is grabbed separately within the Main() method.
            double width = Convert.ToDouble(widthTextBox.Text);
            double gusset = Convert.ToDouble(gussetTextBox.Text);
            double length = Convert.ToDouble(lengthTextBox.Text);
            double lip = Convert.ToDouble(lipTextBox.Text);
            double mil = Convert.ToDouble(milTextBox.Text);
            double qty = Convert.ToDouble(quantityTextBox.Text);
            double[] itemData = new double[6] { width, gusset, length, lip, mil, qty };
            return itemData;
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

        //Method that takes the quote results and sends them to the results[,] array
        private void SendToResults(string[] quoteData)
        {
            /* for(int numQuotes = 0; numQuotes < 25; ++numQuotes)
            {

                for (int itemRecord = 0; itemRecord < quoteData.Length; ++itemRecord)
                {
                    results[numQuotes, itemRecord] = quoteData[itemRecord];
                }
            }*/
            for(int itemRecord = 0; itemRecord < quoteData.Length; ++itemRecord)
            {
                results[quoteNum, itemRecord] = quoteData[itemRecord];
            }

        }

        //Event Method to save the array to a txt file.
        private void saveQuotesButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
            string path = saveFileDialog.FileName;

            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);

            for(int quoteNum = 0; quoteNum < 25; ++quoteNum)
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
    }
}
