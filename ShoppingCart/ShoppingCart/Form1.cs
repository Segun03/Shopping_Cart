using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingCart
{
    public partial class Form1 : Form
    {
        int inputBox;
        int itemPrice;
        int qtyBox;
        int totalBox;
        int Qty;
        
        public Form1()
        {
            InitializeComponent();

            //inputBox = (Int32) NumberTextBox.Text;

            
            ErrorLabel.Visible = false;
            ErrorLabel.Text = "";
            labelGreen.Text = "";
            labelGreen.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            labelItemName.Text = "";
            labelPrice.Text = "";
            labelTotalAm.Text = "";
            label6.Visible = false;
            labelTotalAm.Text = "0";
            TotalTextBox.Visible = false;
            TotalButton.Text = "";
            TenderTextBox.Visible = false;
            

        }

        

        private void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text != "")
            {


                if (((label6.Text == "") || label6.Text != "") && label6.Visible == true)
                {

                    label6.Text += button.Text;
                }

                if (((TenderTextBox.Text == "") || TenderTextBox.Text != "") && TenderTextBox.Visible == true)
                {

                    TenderTextBox.Text += button.Text;
                }


            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
           
            ErrorLabel.Visible = false;
            labelGreen.Text = "";
            labelGreen.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            labelItemName.Text = "";
            labelPrice.Text = "";
           
            label6.Visible = false;
            TotalTextBox.Text = "";
            TenderTextBox.Text = "";
            TenderTextBox.Visible = false;

            if (ErrorLabel.Text == "Change " + labelTotalAm.Text)
            {
                listView1.Items.Clear();
                labelTotalAm.Text = "0";
                label5.Text = "Total Amount";
               
                buttonRemove.Text = "";
                buttonRemove.BackColor = System.Drawing.Color.DarkGray;
                TotalButton.Text = "";
                TotalButton.BackColor = System.Drawing.Color.DarkGray;

                if (buttonNonFood.Text == "Cash")
                {
                    buttonNonFood.Text = "Electronics";
                    buttonNonFood.BackColor = System.Drawing.Color.DarkGray;
                }
                if (buttonGrocery.Text == "Card")
                {
                    buttonGrocery.Text = "Food Items";
                    buttonGrocery.BackColor = System.Drawing.Color.DarkGray;
                }

            }

           

        }

        private void button_No_Click(object sender, EventArgs e)
        {
           
            ErrorLabel.Visible = false;

            buttonNonFood.Text = "Electronics";
            buttonNonFood.BackColor = System.Drawing.Color.DarkGray;
            buttonGrocery.Text = "Food Items";
            buttonGrocery.BackColor = System.Drawing.Color.DarkGray;
            buttonDeli.Text = "";
            buttonBakery.Text = "";
            buttonButchery.Text = "";
            buttonFruits.Text = "";
            buttonDrinks.Text = "";
            buttonFishShop.Text = "";
            buttonVeg.Text = "";
            buttonFE.Text = "";
            labelGreen.Text = "";
            labelGreen.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            labelItemName.Text = "";
            labelPrice.Text = "";
            
            label6.Visible = false;
            TotalTextBox.Text = "";
            TenderTextBox.Text = "";
            TenderTextBox.Visible = false;

            if (ErrorLabel.Text == "Change " + labelTotalAm.Text)
            {
                listView1.Items.Clear();
                labelTotalAm.Text = "0";
                label5.Text = "Total Amount";

                buttonRemove.Text = "";
                buttonRemove.BackColor = System.Drawing.Color.DarkGray;
                TotalButton.Text = "";
                TotalButton.BackColor = System.Drawing.Color.DarkGray;

                if (buttonNonFood.Text == "Cash")
                {
                    buttonNonFood.Text = "Electronics";
                    buttonNonFood.BackColor = System.Drawing.Color.DarkGray;
                }
                if (buttonGrocery.Text == "Card")
                {
                    buttonGrocery.Text = "Food Items";
                    buttonGrocery.BackColor = System.Drawing.Color.DarkGray;
                }
            }
        }

        private void button_Enter_Click(object sender, EventArgs e)
        {

            label5.Text = "Total Amount:";
            //string StringTotalBox = totalBox.ToString();
            //MessageBox.Show(StringTotalBox);



            if (labelItemName.Text != "" && labelPrice.Text != "" && label6.Text != "" && TotalTextBox.Text != "" && TotalTextBox.Text != "Invalid" && TenderTextBox.Visible == false)
            {
                string[] arr = new string[4];
                arr[0] = labelItemName.Text;
                arr[1] = labelPrice.Text;
                arr[2] = label6.Text;
                arr[3] = TotalTextBox.Text;

                ListViewItem lvi = new ListViewItem(arr);

                listView1.Items.Add(lvi);

                
                labelTotalAm.Text = (Convert.ToInt32(labelTotalAm.Text) + Convert.ToInt32(TotalTextBox.Text)).ToString();
                TotalButton.Text = "Total";
                TotalButton.BackColor = System.Drawing.Color.Green;

                buttonRemove.Text = "Remove";
                buttonRemove.BackColor = System.Drawing.Color.Red;
            }           
            else
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = "Invalid Input Hit(C)";
            }

            if (labelGreen.Visible == true && TenderTextBox.Text != "" && ((TenderTextBox.Text.All(char.IsDigit))) && !(Convert.ToInt32(TenderTextBox.Text) > Convert.ToInt32(labelTotalAm.Text)))
            {
                ErrorLabel.Visible = false;
            
                labelTotalAm.Text = (Convert.ToInt32(labelTotalAm.Text) - Convert.ToInt32(TenderTextBox.Text)).ToString();
                label5.Text = "Balance Due:";
            }

            


            if (labelGreen.Visible == true && TenderTextBox.Text != "" && ((TenderTextBox.Text.All(char.IsDigit))) && (Convert.ToInt32(TenderTextBox.Text) > Convert.ToInt32(labelTotalAm.Text)) && labelGreen.Text == "Tender Cash")
            {


                labelTotalAm.Text = (Convert.ToInt32(TenderTextBox.Text) - Convert.ToInt32(labelTotalAm.Text)).ToString();
                label5.Text = "Change:";

               
                    ErrorLabel.Visible = true;
                    ErrorLabel.Text = "Change " + labelTotalAm.Text;
                    if (!ErrorLabel.Visible == true)
                    {
                        label7.Visible = true;
                        label7.Text += " Next Customer Please.";
                    }
                

            }


            if (TotalButton.Text == "Total" && labelTotalAm.Text == "0")
            {
                label7.Visible = true;
                label7.Text += " Next Customer Please.";
            }



            if (Convert.ToInt32(labelTotalAm.Text) == 0)
            {
                listView1.Items.Clear();
                label5.Text = "Total Amount:";
                buttonRemove.Text = "";
                buttonRemove.BackColor = System.Drawing.Color.DarkGray;
                TotalButton.Text = "";
                TotalButton.BackColor = System.Drawing.Color.DarkGray;



                if (buttonNonFood.Text == "Cash")
                {
                    buttonNonFood.Text = "Electronics";
                    buttonNonFood.BackColor = System.Drawing.Color.DarkGray;
                }
                if(buttonGrocery.Text == "Card")
                {
                    buttonGrocery.Text = "Food Items";
                    buttonGrocery.BackColor = System.Drawing.Color.DarkGray;
                }
            }
           

            //if (Convert.ToInt32(TenderTextBox.Text) > Convert.ToInt32(labelTotalAm.Text))
            //{
            //    labelTotalAm.Text = (Convert.ToInt32(TenderTextBox.Text) - Convert.ToInt32(labelTotalAm.Text)).ToString();
            //    //string LB = (Convert.ToInt32(labelTotalAm.Text) - Convert.ToInt32(TenderTextBox.Text)).ToString();
            //    labelTotalAm.Text = (Convert.ToInt32(labelTotalAm.Text) - Convert.ToInt32(TenderTextBox.Text)).ToString();

            //    label5.Text = "Change:";

            //}



            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            labelItemName.Text = "";
            labelPrice.Text = "";
            label6.Text = "";
            label6.Visible = false;
            TotalTextBox.Text = "";
            labelGreen.Visible = false;
            TenderTextBox.Visible = false;
            TenderTextBox.Text = "";



            if (ErrorLabel.Text == "Change " + labelTotalAm.Text)
            {
                listView1.Items.Clear();
                labelTotalAm.Text = "0";
                label5.Text = "Total Amount";

                buttonRemove.Text = "";
                buttonRemove.BackColor = System.Drawing.Color.DarkGray;
                TotalButton.Text = "";
                TotalButton.BackColor = System.Drawing.Color.DarkGray;

                label7.Visible = true;
                label7.Text += " Next Customer Please.";

                if (buttonNonFood.Text == "Cash")
                {
                    buttonNonFood.Text = "Electronics";
                    buttonNonFood.BackColor = System.Drawing.Color.DarkGray;
                }
                if (buttonGrocery.Text == "Card")
                {
                    buttonGrocery.Text = "Food Items";
                    buttonGrocery.BackColor = System.Drawing.Color.DarkGray;
                }
            }
        }

       

        private void buttonNonFood_Click(object sender, EventArgs e)
        {
            

            if (buttonNonFood.Text == "Electronics")
            {
                buttonNonFood.Text = "Electronics";
                buttonNonFood.BackColor = System.Drawing.Color.SkyBlue;
                buttonGrocery.Text = "HeadPhone";
                buttonDeli.Text = "Plug";
                buttonBakery.Text = "Microwave";
                buttonButchery.Text = "DVD";
                buttonFE.Text = "Fan";
                buttonDrinks.Text = "Freezer";
                buttonFishShop.Text = "Phone";
                buttonVeg.Text = "Blender";

                
                
            }

            if (buttonNonFood.Text == "Cash")
            {
                labelGreen.Visible = true;
                labelGreen.Text = "Tender Cash";
                TenderTextBox.Visible = true;
            }

           

            //if (buttonGrocery.Text == "Tv" || buttonVeg.Text == "Blender" || buttonDeli.Text == "Plug" || buttonBakery.Text == "Microwave" || buttonButchery.Text == "Dvd" || buttonFE.Text == "Fan" || buttonDrinks.Text == "Freezer" || buttonFishShop.Text == "Phone")
            //{
            //    labelGreen.Visible = true;
            //}
        }

        private bool isClick = true;
        private void buttonGrocery_Click(object sender, EventArgs e)
        {
          

            if (isClick = true && buttonGrocery.Text == "Food Items")
            {
                
                buttonNonFood.Text = "Food Items";
                buttonNonFood.BackColor = System.Drawing.Color.SkyBlue;
                buttonGrocery.Text = "Pasta";
                buttonDeli.Text = "Granola";
                buttonBakery.Text = "Sugar";
                buttonButchery.Text = "Salt";
                buttonFE.Text = "Rice";
                buttonDrinks.Text = "Honey";
                buttonFishShop.Text = "Vinegar";
                buttonVeg.Text = "Spices";
                
            }
            

            if (isClick == false && buttonGrocery.Text == "Pasta")
            {

                labelGreen.Visible = true;
                labelGreen.Text = "Selected Item";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                labelItemName.Text = "Paster";

                labelPrice.Text = "400";

                label6.Visible = true;

                TotalTextBox.Visible = true;


            }

            


            if (buttonGrocery.Text == "HeadPhone")
            {
                labelGreen.Visible = true;
                labelGreen.Text = "Selected Item";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                labelItemName.Text = "HeadPhone";

                labelPrice.Text = "349";
               
                label6.Visible = true;
               
                TotalTextBox.Visible = true;
              
            }

            if (buttonGrocery.Text == "Card")
            {
                labelGreen.Visible = true;
                labelGreen.Text = "Tender Amount. (Over tender is not allowed!)";
                TenderTextBox.Visible = true;
            }


        }

        private void buttonDrinks_Click(object sender, EventArgs e)
        {
            if (buttonDrinks.Text == "Freezer")
            {
                labelGreen.Visible = true;
                labelGreen.Text = "Selected Item";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                labelItemName.Text = "Freezer";

                labelPrice.Text = "249";
                label6.Visible = true;
               
                TotalTextBox.Visible = true;
            }

            if (buttonDrinks.Text == "Honey")
            {
                labelGreen.Visible = true;
                labelGreen.Text = "Selected Item";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                labelItemName.Text = "Honey";

                labelPrice.Text = "179";
                label6.Visible = true;
               
                TotalTextBox.Visible = true;
            }
        }

        private void buttonDeli_Click(object sender, EventArgs e)
        {
            if (buttonDeli.Text == "Plug")
            {
                labelGreen.Visible = true;
                labelGreen.Text = "Selected Item";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                labelItemName.Text = "Plug";

                labelPrice.Text = "299";
                label6.Visible = true;
                
                TotalTextBox.Visible = true;
            }

            if (buttonDeli.Text == "Granola")
            {
                labelGreen.Visible = true;
                labelGreen.Text = "Selected Item";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                labelItemName.Text = "Granola";

                labelPrice.Text = "199";
                label6.Visible = true;
                
                TotalTextBox.Visible = true;
            }
        }

        private void buttonBakery_Click(object sender, EventArgs e)
        {
            if (buttonBakery.Text == "Microwave")
            {
                labelGreen.Visible = true;
                labelGreen.Text = "Selected Item";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                labelItemName.Text = "Microwave";

                labelPrice.Text = "289";
                label6.Visible = true;
                
                TotalTextBox.Visible = true;
            }

            if (buttonBakery.Text == "Sugar")
            {
                labelGreen.Visible = true;
                labelGreen.Text = "Selected Item";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                labelItemName.Text = "Sugar";

                labelPrice.Text = "139";
                label6.Visible = true;
                
                TotalTextBox.Visible = true;
            }
        }

        private void buttonButchery_Click(object sender, EventArgs e)
        {
            if (buttonButchery.Text == "DVD")
            {
                labelGreen.Visible = true;
                labelGreen.Text = "Selected Item";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                labelItemName.Text = "DVD";

                labelPrice.Text = "599";
                label6.Visible = true;
               
                TotalTextBox.Visible = true;
            }

            if (buttonButchery.Text == "Salt")
            {
                labelGreen.Visible = true;
                labelGreen.Text = "Selected Item";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                labelItemName.Text = "Salt";

                labelPrice.Text = "549";
                label6.Visible = true;
               
                TotalTextBox.Visible = true;
            }
        }

        private void buttonFishShop_Click(object sender, EventArgs e)
        {
            if (buttonFishShop.Text == "Phone")
            {
                labelGreen.Visible = true;
                labelGreen.Text = "Selected Item";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                labelItemName.Text = "Phone";

                labelPrice.Text = "999";
                label6.Visible = true;
            
                TotalTextBox.Visible = true;

            }

            if (buttonFishShop.Text == "Vinegar")
            {
                labelGreen.Visible = true;
                labelGreen.Text = "Selected Item";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                labelItemName.Text = "Vinegar";

                labelPrice.Text = "789";
                label6.Visible = true;
               
                TotalTextBox.Visible = true;
            }
        }

        private void buttonVeg_Click(object sender, EventArgs e)
        {
            if (buttonVeg.Text == "Blender")
            {
                labelGreen.Visible = true;
                labelGreen.Text = "Selected Item";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                labelItemName.Text = "Blender";

                labelPrice.Text = "689";
                label6.Visible = true;
               
                TotalTextBox.Visible = true;
            }

            if (buttonVeg.Text == "Spices")
            {
                labelGreen.Visible = true;
                labelGreen.Text = "Selected Item";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                labelItemName.Text = "Spices";

                labelPrice.Text = "499";
                label6.Visible = true;
                
                TotalTextBox.Visible = true;
            }
        }
        private void buttonFE_Click(object sender, EventArgs e)
        {
            if (buttonFE.Text == "Fan")
            {
                    labelGreen.Visible = true;
                    labelGreen.Text = "Selected Item";
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    labelItemName.Text = "Fan";

                    labelPrice.Text = "459";
                label6.Visible = true;
               
                TotalTextBox.Visible = true;
            }

            if (buttonFE.Text == "Rice")
            {
                    labelGreen.Visible = true;
                    labelGreen.Text = "Selected Item";
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    labelItemName.Text = "Rice";

                    labelPrice.Text = "749";
                label6.Visible = true;
               
                TotalTextBox.Visible = true;
            }

        }

        private void QtyTextBox_TextChanged(object sender, EventArgs e)
        {
            //totalBox = itemPrice * qtyBox;
            //TotalTextBox.Text = totalBox.ToString();
            
            if ((label6.Text.All(char.IsDigit)) && label6.Text != "")
            {
                TotalTextBox.Text = (Convert.ToInt32(labelPrice.Text) * Convert.ToInt32(label6.Text)).ToString();
                TotalTextBox.ForeColor = System.Drawing.Color.SkyBlue;
            }
            else
            {
                TotalTextBox.Text = "Invalid";

                TotalTextBox.ForeColor = System.Drawing.Color.Red;
            }

           
        }

        private void button_BackSpace_Click(object sender, EventArgs e)
        {
            if (labelGreen.Visible == true)
            {
                label6.Text = "";
            }

            if (labelGreen.Visible == true)
            {
                TenderTextBox.Text = "";
            }
        }

        private void TotalButton_Click(object sender, EventArgs e)
        {
            if (TotalButton.Text != "")
            {
                buttonNonFood.Text = "Cash";
                buttonNonFood.BackColor = System.Drawing.Color.CadetBlue;
                buttonGrocery.Text = "Card";
                buttonGrocery.BackColor = System.Drawing.Color.CadetBlue;
                buttonDeli.Text = "";
                buttonBakery.Text = "";
                buttonButchery.Text = "";
                buttonFE.Text = "";
                buttonDrinks.Text = "";
                buttonFishShop.Text = "";
                buttonVeg.Text = "";
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (buttonRemove.Text == "Remove")
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (listView1.Items[i].Selected)
                        {
                            labelTotalAm.Text = (Convert.ToInt32(labelTotalAm.Text) - Convert.ToInt32(listView1.Items[i].SubItems[3].Text)).ToString();
                            listView1.Items[i].Remove();
                        }
                    }
                }
            }

            if (listView1.Items.Count == 0)
            {
                buttonRemove.Text = "";
                buttonRemove.BackColor = System.Drawing.Color.DarkGray;
                TotalButton.Text = "";
                TotalButton.BackColor = System.Drawing.Color.DarkGray;

                if (buttonNonFood.Text == "Cash")
                {
                    buttonNonFood.Text = "Electronics";
                    buttonNonFood.BackColor = System.Drawing.Color.DarkGray;
                }
                if (buttonGrocery.Text == "Card")
                {
                    buttonGrocery.Text = "Food Items";
                    buttonGrocery.BackColor = System.Drawing.Color.DarkGray;
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
        }
    }
}
