using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Sprilast
{
    public partial class Form1 : Form
    {
        public double höjd = 0;
        public string längd = "0";
        public string bredd = "0";
        public string area = "0";
        public double lastArea = 0;
        string LK = "";

        public void calcLK(string value)
        {
            switch (value)
            {
                case "1) 75 Kg/m":
                    LK = "75";
                    return;
                case "2) 150 Kg/m":
                    LK = "150";
                    return;
                case "3) 200 Kg/m":
                    LK = "200";
                    return;
                case "4) 300 Kg/m":
                    LK = "300";
                    return;
                case "5) 450 Kg/m":
                    LK = "450";
                    return;
                case "6) 600 Kg/m":
                    LK = "600";
                    return;
                case "":
                    LK = "0";
                    return;
                default:
                    MessageBox.Show("Välj en korrekt lastklass");
                    LK = "0";
                    comboBoxLastklass.Text = "Välj . . .";
                    return;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawLinePointF(e);
        }
        public void DrawLinePointF(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);

            // Create coordinates of points that define line.
            int x1 = 775;
            int y1 = 150;
            int x2 = 775;
            int y2 = 700;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);

            int X1 = 0;
            int Y1 = 602;
            int X2 = 1000;
            int Y2 = 602;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, X1, Y1, X2, Y2);
        }

        // LAUNCH
        public Form1()
        {
            InitializeComponent();

            // Draw lines
            this.Paint += new PaintEventHandler(Form1_Paint);
            // Hide area components
            textBox35.Hide();
            // Hides length elements
            comboBox1.Hide();
            comboBox2.Hide();
            comboBox3.Hide();
            comboBox4.Hide();
            comboBox5.Hide();
            comboBox6.Hide();
            comboBox7.Hide();
            comboBox8.Hide();
            comboBox9.Hide();
            comboBox10.Hide();

            // Hides material elements
            comboBoxItem2.Hide();
            comboBoxItem3.Hide();
            comboBoxItem4.Hide();
            comboBoxItem5.Hide();
            comboBoxItem6.Hide();
            comboBoxItem7.Hide();
            comboBoxItem8.Hide();
            comboBoxItem9.Hide();
            comboBoxItem10.Hide();

            // Hides amount inner
            textBox8.Hide();
            textBox9.Hide();
            textBox10.Hide();
            textBox11.Hide();
            textBox12.Hide();
            textBox13.Hide();
            textBox14.Hide();
            textBox15.Hide();
            textBox16.Hide();
            textBox17.Hide();

            // Hides amount outer
            textBox18.Hide();
            textBox19.Hide();
            textBox20.Hide();
            textBox21.Hide();
            textBox22.Hide();
            textBox23.Hide();
            textBox24.Hide();
            textBox25.Hide();
            textBox26.Hide();
            textBox27.Hide();

            PerformAutoScale();
        }


        // Image click event. Print page
        private void pictureBoxPrint_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDocument1.Print();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }

        // Prints the document

        Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        // Exit program method
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            const string message = "Är du säker på att du vill stänga ner programmet?";
            const string caption = "Avslutar . .";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                //e.Cancel = true;
            }
            else if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        // Hjälp meddelande
        private void pictureBoxHelp_Click(object sender, EventArgs e)
        {
            const string message = "Skriv ut hjälp meddelande";
            MessageBox.Show(message);
        }
        // TO CALCULATE MATERIAL WEIGHT
        public string[] Countbox(string box1, string box2, string label1)
        {
            switch (box1)
            {
                case "Spira":
                    switch (box2)
                    {
                        case "0,5":
                            label1 = "2,7";
                            break;
                        case "1":
                            label1 = "4,9";
                            break;
                        case "1,5":
                            label1 = "7,1";
                            break;
                        case "2":
                            label1 = "9,3";
                            break;
                        case "3":
                            label1 = "13,7";
                            break;
                    }
                    break;
                case "Plank stål":
                    switch (box2)
                    {
                        case "0,73":
                            label1 = "7";
                            break;
                        case "1,09":
                            label1 = "9,4";
                            break;
                        case "1,4":
                            label1 = "10,8";
                            break;
                        case "2,07":
                            label1 = "16";
                            break;
                        case "2,57":
                            label1 = "18,9";
                            break;
                        case "3,07":
                            label1 = "22,5";
                            break;
                    }
                    break;
                case "Plank alu":
                    switch (box2)
                    {
                        case "2,57":
                            label1 = "9";
                            break;
                        case "3,07":
                            label1 = "10,8";
                            break;
                    }
                    break;
                case "Horisontalstag":
                    switch (box2)
                    {
                        case "0,73":
                            label1 = "2,9";
                            break;
                        case "1,09":
                            label1 = "4";
                            break;
                        case "1,4":
                            label1 = "5";
                            break;
                        case "2,07":
                            label1 = "7";
                            break;
                        case "2,57":
                            label1 = "8,5";
                            break;
                        case "3,07":
                            label1 = "10,1";
                            break;
                    }
                    break;
                case "Diagonal":
                    switch (box2)
                    {
                        case "0,73":
                            label1 = "6,8";
                            break;
                        case "1,09":
                            label1 = "7";
                            break;
                        case "1,4":
                            label1 = "7,5";
                            break;
                        case "2,07":
                            label1 = "8,9";
                            break;
                        case "2,57":
                            label1 = "9,5";
                            break;
                        case "3,07":
                            label1 = "10,5";
                            break;
                    }
                    break;
                case "Sparklist":
                    switch (box2)
                    {
                        case "0,73":
                            label1 = "1,5";
                            break;
                        case "1,09":
                            label1 = "2,5";
                            break;
                        case "1,4":
                            label1 = "3,4";
                            break;
                        case "2,07":
                            label1 = "4,3";
                            break;
                        case "2,57":
                            label1 = "5,7";
                            break;
                        case "3,07":
                            label1 = "6,3";
                            break;
                    }
                    break;
                case "Förstärkt bom":
                    switch (box2)
                    {
                        case "2,07":
                            label1 = "11,4";
                            break;
                        case "2,57":
                            label1 = "14,3";
                            break;
                        case "3,07":
                            label1 = "17";
                            break;
                    }
                    break;

                case "Rör":
                    label1 = "4,5";
                    break;
                case "Koppling":
                    label1 = "1,3";
                    break;
                case "Lucka":
                    switch (box2)
                    {
                        case "1":
                            label1 = "6,5";
                            break;
                        case "1,5":
                            label1 = "10,3";
                            break;
                        case "2":
                            label1 = "12,8";
                            break;
                        case "2,5":
                            label1 = "15,3";
                            break;
                    }
                    break;
                case "Trappa":
                    switch (box2)
                    {
                        case "2,57":
                            label1 = "23,2";
                            break;
                        case "3,07":
                            label1 = "27,7";
                            break;
                    }
                    break;
                case "Trappräcke":
                    switch (box2)
                    {
                        case "2,57":
                            label1 = "18,1";
                            break;
                        case "3,07":
                            label1 = "20,1";
                            break;
                    }
                    break;
                case "Konsoll":
                    switch (box2)
                    {
                        case "0,39":
                            label1 = "3,9";
                            break;
                        case "0,73":
                            label1 = "6,8";
                            break;
                        case "1,09":
                            label1 = "12";
                            break;
                    }
                    break;
            }
            string[] arr = { box1, box2, label1 };
            return arr;
        }
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox8.Text = "";
            textBox27.Text = "";
            label7.Text = "";
            string[] arr = new string[3];
            arr = Countbox(comboBoxItem1.Text, comboBox1.Text, label7.Text);
            comboBoxItem1.Text = arr[0];
            comboBox1.Text = arr[1];
            label7.Text = arr[2];
            if (comboBox1.Text != null)
            {
                textBox8.Show();
                textBox27.Show();
            }
        }

        private void comboBoxItem2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Show();
            comboBox2.Items.Clear();
            textBox26.Text = "";
            textBox9.Text = "";
            comboBoxItem3.Show();
            if (comboBoxItem3.Text == "Koppling")
            {
                comboBox2.Hide();
                label8.Text = "1,3";
                textBox9.Show();
                textBox26.Show();
            }

            switch (comboBoxItem2.Text)
            {
                case "Spira":

                    comboBox2.Items.Add(0.5);
                    comboBox2.Items.Add(1);
                    comboBox2.Items.Add(1.5);
                    comboBox2.Items.Add(2);
                    comboBox2.Items.Add(3);
                    break;
                case "Plank stål":
                    comboBox2.Items.Add(0.73);
                    comboBox2.Items.Add(1.09);
                    comboBox2.Items.Add(1.40);
                    comboBox2.Items.Add(2.07);
                    comboBox2.Items.Add(2.57);
                    comboBox2.Items.Add(3.07);
                    break;
                case "Plank alu":
                    comboBox2.Items.Add(2.57);
                    comboBox2.Items.Add(3.07);
                    break;
                case "Horisontalstag":
                    comboBox2.Items.Add(0.73);
                    comboBox2.Items.Add(1.09);
                    comboBox2.Items.Add(1.40);
                    comboBox2.Items.Add(2.07);
                    comboBox2.Items.Add(2.57);
                    comboBox2.Items.Add(3.07);
                    break;
                case "Diagonal":
                    comboBox2.Items.Add(0.73);
                    comboBox2.Items.Add(1.09);
                    comboBox2.Items.Add(1.40);
                    comboBox2.Items.Add(2.07);
                    comboBox2.Items.Add(2.57);
                    comboBox2.Items.Add(3.07);
                    break;
                case "Sparklist":
                    comboBox2.Items.Add(0.73);
                    comboBox2.Items.Add(1.09);
                    comboBox2.Items.Add(1.40);
                    comboBox2.Items.Add(2.07);
                    comboBox2.Items.Add(2.57);
                    comboBox2.Items.Add(3.07);
                    break;
                case "Förstärkt bom":
                    comboBox2.Items.Add(2.07);
                    comboBox2.Items.Add(2.57);
                    comboBox2.Items.Add(3.07);
                    break;
                case "Rör":
                    comboBox2.Hide();
                    label8.Text = "4,5";
                    textBox9.Show();
                    textBox26.Show();
                    break;
                case "Lucka":
                    comboBox2.Items.Add(1);
                    comboBox2.Items.Add(1.5);
                    comboBox2.Items.Add(2);
                    comboBox2.Items.Add(2.5);
                    break;
                case "Trappa":
                    comboBox2.Items.Add(2.57);
                    comboBox2.Items.Add(3.07);
                    break;
                case "Trappräcke":
                    comboBox2.Items.Add(2.57);
                    comboBox2.Items.Add(3.07);
                    break;
                case "Konsoll":
                    comboBox2.Items.Add(0.39);
                    comboBox2.Items.Add(0.73);
                    comboBox2.Items.Add(1.09);
                    break;
            }
            if (comboBoxItem2.Text != "Koppling" && comboBoxItem2.Text != "Rör")
                label8.Text = "";
        }

        private void comboBoxItem1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Show();
            comboBox1.Items.Clear();
            textBox27.Text = "";
            textBox8.Text = "";
            comboBoxItem2.Show();
            if (comboBoxItem1.Text == "Koppling")
            {
                comboBox1.Hide();
                label7.Text = "1,3";
                textBox8.Show();
                textBox27.Show();
            }

            switch (comboBoxItem1.Text)
            {
                case "Spira":

                    comboBox1.Items.Add(0.5);
                    comboBox1.Items.Add(1);
                    comboBox1.Items.Add(1.5);
                    comboBox1.Items.Add(2);
                    comboBox1.Items.Add(3);
                    break;
                case "Plank stål":
                    comboBox1.Items.Add(0.73);
                    comboBox1.Items.Add(1.09);
                    comboBox1.Items.Add(1.40);
                    comboBox1.Items.Add(2.07);
                    comboBox1.Items.Add(2.57);
                    comboBox1.Items.Add(3.07);
                    break;
                case "Plank alu":
                    comboBox1.Items.Add(2.57);
                    comboBox1.Items.Add(3.07);
                    break;
                case "Horisontalstag":
                    comboBox1.Items.Add(0.73);
                    comboBox1.Items.Add(1.09);
                    comboBox1.Items.Add(1.40);
                    comboBox1.Items.Add(2.07);
                    comboBox1.Items.Add(2.57);
                    comboBox1.Items.Add(3.07);
                    break;
                case "Diagonal":
                    comboBox1.Items.Add(0.73);
                    comboBox1.Items.Add(1.09);
                    comboBox1.Items.Add(1.40);
                    comboBox1.Items.Add(2.07);
                    comboBox1.Items.Add(2.57);
                    comboBox1.Items.Add(3.07);
                    break;
                case "Sparklist":
                    comboBox1.Items.Add(0.73);
                    comboBox1.Items.Add(1.09);
                    comboBox1.Items.Add(1.40);
                    comboBox1.Items.Add(2.07);
                    comboBox1.Items.Add(2.57);
                    comboBox1.Items.Add(3.07);
                    break;
                case "Förstärkt bom":
                    comboBox1.Items.Add(2.07);
                    comboBox1.Items.Add(2.57);
                    comboBox1.Items.Add(3.07);
                    break;
                case "Rör":
                    comboBox1.Hide();
                    label7.Text = "4,5";
                    textBox8.Show();
                    textBox27.Show();
                    break;
                case "Lucka":
                    comboBox1.Items.Add(1);
                    comboBox1.Items.Add(1.5);
                    comboBox1.Items.Add(2);
                    comboBox1.Items.Add(2.5);
                    break;
                case "Trappa":
                    comboBox1.Items.Add(2.57);
                    comboBox1.Items.Add(3.07);
                    break;
                case "Trappräcke":
                    comboBox1.Items.Add(2.57);
                    comboBox1.Items.Add(3.07);
                    break;
                case "Konsoll":
                    comboBox1.Items.Add(0.39);
                    comboBox1.Items.Add(0.73);
                    comboBox1.Items.Add(1.09);
                    break;
            }
            if (comboBoxItem1.Text != "Koppling" && comboBoxItem1.Text != "Rör")
                label7.Text = "";
        }

        private void comboBoxItem3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Show();
            comboBox3.Items.Clear();
            textBox25.Text = "";
            textBox10.Text = "";
            comboBoxItem4.Show();
            if (comboBoxItem3.Text == "Koppling")
            {
                comboBox3.Hide();
                label9.Text = "1,3";
                textBox10.Show();
                textBox25.Show();
            }

            switch (comboBoxItem3.Text)
            {
                case "Spira":

                    comboBox3.Items.Add(0.5);
                    comboBox3.Items.Add(1);
                    comboBox3.Items.Add(1.5);
                    comboBox3.Items.Add(2);
                    comboBox3.Items.Add(3);
                    break;
                case "Plank stål":
                    comboBox3.Items.Add(0.73);
                    comboBox3.Items.Add(1.09);
                    comboBox3.Items.Add(1.40);
                    comboBox3.Items.Add(2.07);
                    comboBox3.Items.Add(2.57);
                    comboBox3.Items.Add(3.07);
                    break;
                case "Plank alu":
                    comboBox3.Items.Add(2.57);
                    comboBox3.Items.Add(3.07);
                    break;
                case "Horisontalstag":
                    comboBox3.Items.Add(0.73);
                    comboBox3.Items.Add(1.09);
                    comboBox3.Items.Add(1.40);
                    comboBox3.Items.Add(2.07);
                    comboBox3.Items.Add(2.57);
                    comboBox3.Items.Add(3.07);
                    break;
                case "Diagonal":
                    comboBox3.Items.Add(0.73);
                    comboBox3.Items.Add(1.09);
                    comboBox3.Items.Add(1.40);
                    comboBox3.Items.Add(2.07);
                    comboBox3.Items.Add(2.57);
                    comboBox3.Items.Add(3.07);
                    break;
                case "Sparklist":
                    comboBox3.Items.Add(0.73);
                    comboBox3.Items.Add(1.09);
                    comboBox3.Items.Add(1.40);
                    comboBox3.Items.Add(2.07);
                    comboBox3.Items.Add(2.57);
                    comboBox3.Items.Add(3.07);
                    break;
                case "Förstärkt bom":
                    comboBox3.Items.Add(2.07);
                    comboBox3.Items.Add(2.57);
                    comboBox3.Items.Add(3.07);
                    break;
                case "Rör":
                    comboBox3.Hide();
                    label9.Text = "4,5";
                    textBox10.Show();
                    textBox25.Show();
                    break;
                case "Lucka":
                    comboBox3.Items.Add(1);
                    comboBox3.Items.Add(1.5);
                    comboBox3.Items.Add(2);
                    comboBox3.Items.Add(2.5);
                    break;
                case "Trappa":
                    comboBox3.Items.Add(2.57);
                    comboBox3.Items.Add(3.07);
                    break;
                case "Trappräcke":
                    comboBox3.Items.Add(2.57);
                    comboBox3.Items.Add(3.07);
                    break;
                case "Konsoll":
                    comboBox3.Items.Add(0.39);
                    comboBox3.Items.Add(0.73);
                    comboBox3.Items.Add(1.09);
                    break;
            }
            if (comboBoxItem3.Text != "Koppling" && comboBoxItem3.Text != "Rör")
                label9.Text = "";

        }

        private void comboBoxItem4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Show();
            comboBox4.Items.Clear();
            textBox24.Text = "";
            textBox11.Text = "";
            comboBoxItem5.Show();
            if (comboBoxItem4.Text == "Koppling")
            {
                comboBox4.Hide();
                label10.Text = "1,3";
                textBox11.Show();
                textBox24.Show();
            }

            switch (comboBoxItem4.Text)
            {
                case "Spira":

                    comboBox4.Items.Add(0.5);
                    comboBox4.Items.Add(1);
                    comboBox4.Items.Add(1.5);
                    comboBox4.Items.Add(2);
                    comboBox4.Items.Add(3);
                    break;
                case "Plank stål":
                    comboBox4.Items.Add(0.73);
                    comboBox4.Items.Add(1.09);
                    comboBox4.Items.Add(1.40);
                    comboBox4.Items.Add(2.07);
                    comboBox4.Items.Add(2.57);
                    comboBox4.Items.Add(3.07);
                    break;
                case "Plank alu":
                    comboBox4.Items.Add(2.57);
                    comboBox4.Items.Add(3.07);
                    break;
                case "Horisontalstag":
                    comboBox4.Items.Add(0.73);
                    comboBox4.Items.Add(1.09);
                    comboBox4.Items.Add(1.40);
                    comboBox4.Items.Add(2.07);
                    comboBox4.Items.Add(2.57);
                    comboBox4.Items.Add(3.07);
                    break;
                case "Diagonal":
                    comboBox4.Items.Add(0.73);
                    comboBox4.Items.Add(1.09);
                    comboBox4.Items.Add(1.40);
                    comboBox4.Items.Add(2.07);
                    comboBox4.Items.Add(2.57);
                    comboBox4.Items.Add(3.07);
                    break;
                case "Sparklist":
                    comboBox4.Items.Add(0.73);
                    comboBox4.Items.Add(1.09);
                    comboBox4.Items.Add(1.40);
                    comboBox4.Items.Add(2.07);
                    comboBox4.Items.Add(2.57);
                    comboBox4.Items.Add(3.07);
                    break;
                case "Förstärkt bom":
                    comboBox4.Items.Add(2.07);
                    comboBox4.Items.Add(2.57);
                    comboBox4.Items.Add(3.07);
                    break;
                case "Rör":
                    comboBox4.Hide();
                    label10.Text = "4,5";
                    textBox11.Show();
                    textBox24.Show();
                    break;
                case "Lucka":
                    comboBox4.Items.Add(1);
                    comboBox4.Items.Add(1.5);
                    comboBox4.Items.Add(2);
                    comboBox4.Items.Add(2.5);
                    break;
                case "Trappa":
                    comboBox4.Items.Add(2.57);
                    comboBox4.Items.Add(3.07);
                    break;
                case "Trappräcke":
                    comboBox4.Items.Add(2.57);
                    comboBox4.Items.Add(3.07);
                    break;
                case "Konsoll":
                    comboBox4.Items.Add(0.39);
                    comboBox4.Items.Add(0.73);
                    comboBox4.Items.Add(1.09);
                    break;
            }
            if (comboBoxItem4.Text != "Koppling" && comboBoxItem4.Text != "Rör")
                label10.Text = "";

        }

        private void comboBoxItem5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Show();
            comboBox5.Items.Clear();
            textBox23.Text = "";
            textBox12.Text = "";
            comboBoxItem6.Show();
            if (comboBoxItem5.Text == "Koppling")
            {
                comboBox5.Hide();
                label11.Text = "1,3";
                textBox12.Show();
                textBox23.Show();
            }

            switch (comboBoxItem5.Text)
            {
                case "Spira":

                    comboBox5.Items.Add(0.5);
                    comboBox5.Items.Add(1);
                    comboBox5.Items.Add(1.5);
                    comboBox5.Items.Add(2);
                    comboBox5.Items.Add(3);
                    break;
                case "Plank stål":
                    comboBox5.Items.Add(0.73);
                    comboBox5.Items.Add(1.09);
                    comboBox5.Items.Add(1.40);
                    comboBox5.Items.Add(2.07);
                    comboBox5.Items.Add(2.57);
                    comboBox5.Items.Add(3.07);
                    break;
                case "Plank alu":
                    comboBox5.Items.Add(2.57);
                    comboBox5.Items.Add(3.07);
                    break;
                case "Horisontalstag":
                    comboBox5.Items.Add(0.73);
                    comboBox5.Items.Add(1.09);
                    comboBox5.Items.Add(1.40);
                    comboBox5.Items.Add(2.07);
                    comboBox5.Items.Add(2.57);
                    comboBox5.Items.Add(3.07);
                    break;
                case "Diagonal":
                    comboBox5.Items.Add(0.73);
                    comboBox5.Items.Add(1.09);
                    comboBox5.Items.Add(1.40);
                    comboBox5.Items.Add(2.07);
                    comboBox5.Items.Add(2.57);
                    comboBox5.Items.Add(3.07);
                    break;
                case "Sparklist":
                    comboBox5.Items.Add(0.73);
                    comboBox5.Items.Add(1.09);
                    comboBox5.Items.Add(1.40);
                    comboBox5.Items.Add(2.07);
                    comboBox5.Items.Add(2.57);
                    comboBox5.Items.Add(3.07);
                    break;
                case "Förstärkt bom":
                    comboBox5.Items.Add(2.07);
                    comboBox5.Items.Add(2.57);
                    comboBox5.Items.Add(3.07);
                    break;
                case "Rör":
                    comboBox5.Hide();
                    label11.Text = "4,5";
                    textBox12.Show();
                    textBox23.Show();
                    break;
                case "Lucka":
                    comboBox5.Items.Add(1);
                    comboBox5.Items.Add(1.5);
                    comboBox5.Items.Add(2);
                    comboBox5.Items.Add(2.5);
                    break;
                case "Trappa":
                    comboBox5.Items.Add(2.57);
                    comboBox5.Items.Add(3.07);
                    break;
                case "Trappräcke":
                    comboBox5.Items.Add(2.57);
                    comboBox5.Items.Add(3.07);
                    break;
                case "Konsoll":
                    comboBox5.Items.Add(0.39);
                    comboBox5.Items.Add(0.73);
                    comboBox5.Items.Add(1.09);
                    break;
            }
            if (comboBoxItem5.Text != "Koppling" && comboBoxItem5.Text != "Rör")
                label11.Text = "";

        }

        private void comboBoxItem6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Show();
            comboBox6.Items.Clear();
            textBox22.Text = "";
            textBox13.Text = "";
            comboBoxItem7.Show();
            if (comboBoxItem6.Text == "Koppling")
            {
                comboBox6.Hide();
                label12.Text = "1,3";
                textBox13.Show();
                textBox22.Show();
            }

            switch (comboBoxItem6.Text)
            {
                case "Spira":

                    comboBox6.Items.Add(0.5);
                    comboBox6.Items.Add(1);
                    comboBox6.Items.Add(1.5);
                    comboBox6.Items.Add(2);
                    comboBox6.Items.Add(3);
                    break;
                case "Plank stål":
                    comboBox6.Items.Add(0.73);
                    comboBox6.Items.Add(1.09);
                    comboBox6.Items.Add(1.40);
                    comboBox6.Items.Add(2.07);
                    comboBox6.Items.Add(2.57);
                    comboBox6.Items.Add(3.07);
                    break;
                case "Plank alu":
                    comboBox6.Items.Add(2.57);
                    comboBox6.Items.Add(3.07);
                    break;
                case "Horisontalstag":
                    comboBox6.Items.Add(0.73);
                    comboBox6.Items.Add(1.09);
                    comboBox6.Items.Add(1.40);
                    comboBox6.Items.Add(2.07);
                    comboBox6.Items.Add(2.57);
                    comboBox6.Items.Add(3.07);
                    break;
                case "Diagonal":
                    comboBox6.Items.Add(0.73);
                    comboBox6.Items.Add(1.09);
                    comboBox6.Items.Add(1.40);
                    comboBox6.Items.Add(2.07);
                    comboBox6.Items.Add(2.57);
                    comboBox6.Items.Add(3.07);
                    break;
                case "Sparklist":
                    comboBox6.Items.Add(0.73);
                    comboBox6.Items.Add(1.09);
                    comboBox6.Items.Add(1.40);
                    comboBox6.Items.Add(2.07);
                    comboBox6.Items.Add(2.57);
                    comboBox6.Items.Add(3.07);
                    break;
                case "Förstärkt bom":
                    comboBox6.Items.Add(2.07);
                    comboBox6.Items.Add(2.57);
                    comboBox6.Items.Add(3.07);
                    break;
                case "Rör":
                    comboBox6.Hide();
                    label12.Text = "4,5";
                    textBox13.Show();
                    textBox22.Show();
                    break;
                case "Lucka":
                    comboBox6.Items.Add(1);
                    comboBox6.Items.Add(1.5);
                    comboBox6.Items.Add(2);
                    comboBox6.Items.Add(2.5);
                    break;
                case "Trappa":
                    comboBox6.Items.Add(2.57);
                    comboBox6.Items.Add(3.07);
                    break;
                case "Trappräcke":
                    comboBox6.Items.Add(2.57);
                    comboBox6.Items.Add(3.07);
                    break;
                case "Konsoll":
                    comboBox6.Items.Add(0.39);
                    comboBox6.Items.Add(0.73);
                    comboBox6.Items.Add(1.09);
                    break;
            }
            if (comboBoxItem6.Text != "Koppling" && comboBoxItem6.Text != "Rör")
                label12.Text = "";

        }

        private void comboBoxItem7_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox7.Show();
            comboBox7.Items.Clear();
            textBox21.Text = "";
            textBox14.Text = "";
            comboBoxItem8.Show();
            if (comboBoxItem7.Text == "Koppling")
            {
                comboBox7.Hide();
                label13.Text = "1,3";
                textBox14.Show();
                textBox21.Show();
            }

            switch (comboBoxItem7.Text)
            {
                case "Spira":

                    comboBox7.Items.Add(0.5);
                    comboBox7.Items.Add(1);
                    comboBox7.Items.Add(1.5);
                    comboBox7.Items.Add(2);
                    comboBox7.Items.Add(3);
                    break;
                case "Plank stål":
                    comboBox7.Items.Add(0.73);
                    comboBox7.Items.Add(1.09);
                    comboBox7.Items.Add(1.40);
                    comboBox7.Items.Add(2.07);
                    comboBox7.Items.Add(2.57);
                    comboBox7.Items.Add(3.07);
                    break;
                case "Plank alu":
                    comboBox7.Items.Add(2.57);
                    comboBox7.Items.Add(3.07);
                    break;
                case "Horisontalstag":
                    comboBox7.Items.Add(0.73);
                    comboBox7.Items.Add(1.09);
                    comboBox7.Items.Add(1.40);
                    comboBox7.Items.Add(2.07);
                    comboBox7.Items.Add(2.57);
                    comboBox7.Items.Add(3.07);
                    break;
                case "Diagonal":
                    comboBox7.Items.Add(0.73);
                    comboBox7.Items.Add(1.09);
                    comboBox7.Items.Add(1.40);
                    comboBox7.Items.Add(2.07);
                    comboBox7.Items.Add(2.57);
                    comboBox7.Items.Add(3.07);
                    break;
                case "Sparklist":
                    comboBox7.Items.Add(0.73);
                    comboBox7.Items.Add(1.09);
                    comboBox7.Items.Add(1.40);
                    comboBox7.Items.Add(2.07);
                    comboBox7.Items.Add(2.57);
                    comboBox7.Items.Add(3.07);
                    break;
                case "Förstärkt bom":
                    comboBox7.Items.Add(2.07);
                    comboBox7.Items.Add(2.57);
                    comboBox7.Items.Add(3.07);
                    break;
                case "Rör":
                    comboBox7.Hide();
                    label13.Text = "4,5";
                    textBox14.Show();
                    textBox21.Show();
                    break;
                case "Lucka":
                    comboBox7.Items.Add(1);
                    comboBox7.Items.Add(1.5);
                    comboBox7.Items.Add(2);
                    comboBox7.Items.Add(2.5);
                    break;
                case "Trappa":
                    comboBox7.Items.Add(2.57);
                    comboBox7.Items.Add(3.07);
                    break;
                case "Trappräcke":
                    comboBox7.Items.Add(2.57);
                    comboBox7.Items.Add(3.07);
                    break;
                case "Konsoll":
                    comboBox7.Items.Add(0.39);
                    comboBox7.Items.Add(0.73);
                    comboBox7.Items.Add(1.09);
                    break;
            }
            if (comboBoxItem7.Text != "Koppling" && comboBoxItem7.Text != "Rör")
                label13.Text = "";

        }

        private void comboBoxItem8_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox8.Show();
            comboBox8.Items.Clear();
            textBox20.Text = "";
            textBox15.Text = "";
            comboBoxItem9.Show();
            if (comboBoxItem8.Text == "Koppling")
            {
                comboBox8.Hide();
                label14.Text = "1,3";
                textBox15.Show();
                textBox20.Show();
            }

            switch (comboBoxItem8.Text)
            {
                case "Spira":

                    comboBox8.Items.Add(0.5);
                    comboBox8.Items.Add(1);
                    comboBox8.Items.Add(1.5);
                    comboBox8.Items.Add(2);
                    comboBox8.Items.Add(3);
                    break;
                case "Plank stål":
                    comboBox8.Items.Add(0.73);
                    comboBox8.Items.Add(1.09);
                    comboBox8.Items.Add(1.40);
                    comboBox8.Items.Add(2.07);
                    comboBox8.Items.Add(2.57);
                    comboBox8.Items.Add(3.07);
                    break;
                case "Plank alu":
                    comboBox8.Items.Add(2.57);
                    comboBox8.Items.Add(3.07);
                    break;
                case "Horisontalstag":
                    comboBox8.Items.Add(0.73);
                    comboBox8.Items.Add(1.09);
                    comboBox8.Items.Add(1.40);
                    comboBox8.Items.Add(2.07);
                    comboBox8.Items.Add(2.57);
                    comboBox8.Items.Add(3.07);
                    break;
                case "Diagonal":
                    comboBox8.Items.Add(0.73);
                    comboBox8.Items.Add(1.09);
                    comboBox8.Items.Add(1.40);
                    comboBox8.Items.Add(2.07);
                    comboBox8.Items.Add(2.57);
                    comboBox8.Items.Add(3.07);
                    break;
                case "Sparklist":
                    comboBox8.Items.Add(0.73);
                    comboBox8.Items.Add(1.09);
                    comboBox8.Items.Add(1.40);
                    comboBox8.Items.Add(2.07);
                    comboBox8.Items.Add(2.57);
                    comboBox8.Items.Add(3.07);
                    break;
                case "Förstärkt bom":
                    comboBox8.Items.Add(2.07);
                    comboBox8.Items.Add(2.57);
                    comboBox8.Items.Add(3.07);
                    break;
                case "Rör":
                    comboBox8.Hide();
                    label14.Text = "4,5";
                    textBox15.Show();
                    textBox20.Show();
                    break;
                case "Lucka":
                    comboBox8.Items.Add(1);
                    comboBox8.Items.Add(1.5);
                    comboBox8.Items.Add(2);
                    comboBox8.Items.Add(2.5);
                    break;
                case "Trappa":
                    comboBox8.Items.Add(2.57);
                    comboBox8.Items.Add(3.07);
                    break;
                case "Trappräcke":
                    comboBox8.Items.Add(2.57);
                    comboBox8.Items.Add(3.07);
                    break;
                case "Konsoll":
                    comboBox8.Items.Add(0.39);
                    comboBox8.Items.Add(0.73);
                    comboBox8.Items.Add(1.09);
                    break;
            }
            if (comboBoxItem8.Text != "Koppling" && comboBoxItem8.Text != "Rör")
                label14.Text = "";

        }

        private void comboBoxItem9_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox9.Show();
            comboBox9.Items.Clear();
            textBox19.Text = "";
            textBox16.Text = "";
            comboBoxItem10.Show();
            if (comboBoxItem9.Text == "Koppling")
            {
                comboBox9.Hide();
                label15.Text = "1,3";
                textBox16.Show();
                textBox19.Show();
            }

            switch (comboBoxItem9.Text)
            {
                case "Spira":

                    comboBox9.Items.Add(0.5);
                    comboBox9.Items.Add(1);
                    comboBox9.Items.Add(1.5);
                    comboBox9.Items.Add(2);
                    comboBox9.Items.Add(3);
                    break;
                case "Plank stål":
                    comboBox9.Items.Add(0.73);
                    comboBox9.Items.Add(1.09);
                    comboBox9.Items.Add(1.40);
                    comboBox9.Items.Add(2.07);
                    comboBox9.Items.Add(2.57);
                    comboBox9.Items.Add(3.07);
                    break;
                case "Plank alu":
                    comboBox9.Items.Add(2.57);
                    comboBox9.Items.Add(3.07);
                    break;
                case "Horisontalstag":
                    comboBox9.Items.Add(0.73);
                    comboBox9.Items.Add(1.09);
                    comboBox9.Items.Add(1.40);
                    comboBox9.Items.Add(2.07);
                    comboBox9.Items.Add(2.57);
                    comboBox9.Items.Add(3.07);
                    break;
                case "Diagonal":
                    comboBox9.Items.Add(0.73);
                    comboBox9.Items.Add(1.09);
                    comboBox9.Items.Add(1.40);
                    comboBox9.Items.Add(2.07);
                    comboBox9.Items.Add(2.57);
                    comboBox9.Items.Add(3.07);
                    break;
                case "Sparklist":
                    comboBox9.Items.Add(0.73);
                    comboBox9.Items.Add(1.09);
                    comboBox9.Items.Add(1.40);
                    comboBox9.Items.Add(2.07);
                    comboBox9.Items.Add(2.57);
                    comboBox9.Items.Add(3.07);
                    break;
                case "Förstärkt bom":
                    comboBox9.Items.Add(2.07);
                    comboBox9.Items.Add(2.57);
                    comboBox9.Items.Add(3.07);
                    break;
                case "Rör":
                    comboBox9.Hide();
                    label15.Text = "4,5";
                    textBox16.Show();
                    textBox19.Show();
                    break;
                case "Lucka":
                    comboBox9.Items.Add(1);
                    comboBox9.Items.Add(1.5);
                    comboBox9.Items.Add(2);
                    comboBox9.Items.Add(2.5);
                    break;
                case "Trappa":
                    comboBox9.Items.Add(2.57);
                    comboBox9.Items.Add(3.07);
                    break;
                case "Trappräcke":
                    comboBox9.Items.Add(2.57);
                    comboBox9.Items.Add(3.07);
                    break;
                case "Konsoll":
                    comboBox9.Items.Add(0.39);
                    comboBox9.Items.Add(0.73);
                    comboBox9.Items.Add(1.09);
                    break;
            }
            if (comboBoxItem9.Text != "Koppling" && comboBoxItem9.Text != "Rör")
                label15.Text = "";

        }

        private void comboBoxItem10_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox10.Show();
            comboBox10.Items.Clear();
            textBox18.Text = "";
            textBox17.Text = "";
            if (comboBoxItem10.Text == "Koppling")
            {
                comboBox10.Hide();
                label16.Text = "1,3";
                textBox17.Show();
                textBox18.Show();
            }

            switch (comboBoxItem10.Text)
            {
                case "Spira":

                    comboBox10.Items.Add(0.5);
                    comboBox10.Items.Add(1);
                    comboBox10.Items.Add(1.5);
                    comboBox10.Items.Add(2);
                    comboBox10.Items.Add(3);
                    break;
                case "Plank stål":
                    comboBox10.Items.Add(0.73);
                    comboBox10.Items.Add(1.09);
                    comboBox10.Items.Add(1.40);
                    comboBox10.Items.Add(2.07);
                    comboBox10.Items.Add(2.57);
                    comboBox10.Items.Add(3.07);
                    break;
                case "Plank alu":
                    comboBox10.Items.Add(2.57);
                    comboBox10.Items.Add(3.07);
                    break;
                case "Horisontalstag":
                    comboBox10.Items.Add(0.73);
                    comboBox10.Items.Add(1.09);
                    comboBox10.Items.Add(1.40);
                    comboBox10.Items.Add(2.07);
                    comboBox10.Items.Add(2.57);
                    comboBox10.Items.Add(3.07);
                    break;
                case "Diagonal":
                    comboBox10.Items.Add(0.73);
                    comboBox10.Items.Add(1.09);
                    comboBox10.Items.Add(1.40);
                    comboBox10.Items.Add(2.07);
                    comboBox10.Items.Add(2.57);
                    comboBox10.Items.Add(3.07);
                    break;
                case "Sparklist":
                    comboBox10.Items.Add(0.73);
                    comboBox10.Items.Add(1.09);
                    comboBox10.Items.Add(1.40);
                    comboBox10.Items.Add(2.07);
                    comboBox10.Items.Add(2.57);
                    comboBox10.Items.Add(3.07);
                    break;
                case "Förstärkt bom":
                    comboBox10.Items.Add(2.07);
                    comboBox10.Items.Add(2.57);
                    comboBox10.Items.Add(3.07);
                    break;
                case "Rör":
                    comboBox10.Hide();
                    label16.Text = "4,5";
                    textBox17.Show();
                    textBox18.Show();
                    break;
                case "Lucka":
                    comboBox10.Items.Add(1);
                    comboBox10.Items.Add(1.5);
                    comboBox10.Items.Add(2);
                    comboBox10.Items.Add(2.5);
                    break;
                case "Trappa":
                    comboBox10.Items.Add(2.57);
                    comboBox10.Items.Add(3.07);
                    break;
                case "Trappräcke":
                    comboBox10.Items.Add(2.57);
                    comboBox10.Items.Add(3.07);
                    break;
                case "Konsoll":
                    comboBox10.Items.Add(0.39);
                    comboBox10.Items.Add(0.73);
                    comboBox10.Items.Add(1.09);
                    break;
            }
            if (comboBoxItem10.Text != "Koppling" && comboBoxItem10.Text != "Rör")
                label16.Text = "";

        }

        private void labelInnerspira_Click(object sender, EventArgs e)
        {

        }

        private void labelYtterspira_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void labelInnerFotTotal_Click(object sender, EventArgs e)
        {

        }

        public string[] kgCount(string kg, string styck, string total)
        {
            total = "";
            double y = 0;
            double x = 0;
            double z = 0;
            if (styck != string.Empty)
            {
                try
                {
                    x = double.Parse(styck);
                    y = double.Parse(kg);
                    z = x * y;
                    total = Convert.ToString(z);
                }
                catch
                {
                    styck = "";
                    total = "";
                    MessageBox.Show("Ett fel uppstod. Har du fyllt i rätt?");
                }
            }
            string[] arr = { kg, styck, total };
            return arr;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string[] arr = new string[3];
            arr = kgCount(labelFotKg.Text, textBox2.Text, labelInnerFotTotal.Text);
            labelFotKg.Text = arr[0];
            textBox2.Text = arr[1];
            labelInnerFotTotal.Text = arr[2];
        }

        private void comboBoxSpira_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox32.Text = "";
            switch (comboBoxSpira.Text)
            {
                case "0,5":
                    labelFotSpira.Text = "2,7";
                    break;
                case "1":
                    labelFotSpira.Text = "4,9";
                    break;
                case "1,5":
                    labelFotSpira.Text = "7,1";
                    break;
                case "2":
                    labelFotSpira.Text = "9,3";
                    break;
                case "3":
                    labelFotSpira.Text = "13,7";
                    break;

            }
        }

        private void comboBoxHorisontalstag_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox31.Text = "";
            switch (comboBoxPlank.Text)
            {
                case "0,73":
                    labelPlankKg.Text = "7";
                    break;
                case "1,09":
                    labelPlankKg.Text = "9,4";
                    break;
                case "1,4":
                    labelPlankKg.Text = "10,8";
                    break;
                case "2,07":
                    labelPlankKg.Text = "16";
                    break;
                case "2,57":
                    labelPlankKg.Text = "18,9";
                    break;
                case "3,07":
                    labelPlankKg.Text = "22,5";
                    break;

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            {
                string[] arr = new string[3];
                arr = kgCount(labelFotSpira.Text, textBox3.Text, labelInnerSpiraTotal.Text);
                labelFotSpira.Text = arr[0];
                textBox3.Text = arr[1];
                labelInnerSpiraTotal.Text = arr[2];
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string[] arr = new string[3];
            arr = kgCount(labelPlankKg.Text, textBox4.Text, labelInnerPlankTotal.Text);
            labelPlankKg.Text = arr[0];
            textBox4.Text = arr[1];
            labelInnerPlankTotal.Text = arr[2];
        }

        private void comboBoxHorisontalstag_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox30.Text = "";
            switch (comboBoxHorisontalstag.Text)
            {
                case "0,73":
                    labelRäckeKg.Text = "2,9";
                    break;
                case "1,09":
                    labelRäckeKg.Text = "4";
                    break;
                case "1,4":
                    labelRäckeKg.Text = "5";
                    break;
                case "2,07":
                    labelRäckeKg.Text = "7";
                    break;
                case "2,57":
                    labelRäckeKg.Text = "8,4";
                    break;
                case "3,07":
                    labelRäckeKg.Text = "10,1";
                    break;

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            {
                string[] arr = new string[3];
                arr = kgCount(labelRäckeKg.Text, textBox5.Text, labelInnerRäckeTotal.Text);
                labelRäckeKg.Text = arr[0];
                textBox5.Text = arr[1];
                labelInnerRäckeTotal.Text = arr[2];
            }
        }

        private void comboBoxDiagonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox6.Text = "";
            textBox29.Text = "";
            switch (comboBoxDiagonal.Text)
            {
                case "0,73":
                    labelDiagonalKg.Text = "6,8";
                    break;
                case "1,09":
                    labelDiagonalKg.Text = "7";
                    break;
                case "1,4":
                    labelDiagonalKg.Text = "7,5";
                    break;
                case "2,07":
                    labelDiagonalKg.Text = "8,9";
                    break;
                case "2,57":
                    labelDiagonalKg.Text = "9,5";
                    break;
                case "3,07":
                    labelDiagonalKg.Text = "10,5";
                    break;

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            {
                string[] arr = new string[3];
                arr = kgCount(labelDiagonalKg.Text, textBox6.Text, labelInnerDiagonalTotal.Text);
                labelDiagonalKg.Text = arr[0];
                textBox6.Text = arr[1];
                labelInnerDiagonalTotal.Text = arr[2];
            }
        }

        private void comboBoxSparklist_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox7.Text = "";
            textBox28.Text = "";
            switch (comboBoxSparklist.Text)
            {
                case "0,73":
                    labelSparklistKg.Text = "1,5";
                    break;
                case "1,09":
                    labelSparklistKg.Text = "2,5";
                    break;
                case "1,4":
                    labelSparklistKg.Text = "3,4";
                    break;
                case "2,07":
                    labelSparklistKg.Text = "4,3";
                    break;
                case "2,57":
                    labelSparklistKg.Text = "5,7";
                    break;
                case "3,07":
                    labelSparklistKg.Text = "6,3";
                    break;

            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            {
                string[] arr = new string[3];
                arr = kgCount(labelSparklistKg.Text, textBox7.Text, labelInnerSparklistTotal.Text);
                labelSparklistKg.Text = arr[0];
                textBox7.Text = arr[1];
                labelInnerSparklistTotal.Text = arr[2];
            }
        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {
            {
                string[] arr = new string[3];
                arr = kgCount(labelFotKg.Text, textBox33.Text, label64.Text);
                labelFotKg.Text = arr[0];
                textBox33.Text = arr[1];
                label64.Text = arr[2];
            }
        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {
            string[] arr = new string[3];
            arr = kgCount(labelFotSpira.Text, textBox32.Text, label63.Text);
            labelFotSpira.Text = arr[0];
            textBox32.Text = arr[1];
            label63.Text = arr[2];
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            {
                string[] arr = new string[3];
                arr = kgCount(labelPlankKg.Text, textBox31.Text, label62.Text);
                labelPlankKg.Text = arr[0];
                textBox31.Text = arr[1];
                label62.Text = arr[2];
            }
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            string[] arr = new string[3];
            arr = kgCount(labelRäckeKg.Text, textBox30.Text, label61.Text);
            labelRäckeKg.Text = arr[0];
            textBox30.Text = arr[1];
            label61.Text = arr[2];
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            string[] arr = new string[3];
            arr = kgCount(labelDiagonalKg.Text, textBox29.Text, label60.Text);
            labelDiagonalKg.Text = arr[0];
            textBox29.Text = arr[1];
            label60.Text = arr[2];
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            string[] arr = new string[3];
            arr = kgCount(labelSparklistKg.Text, textBox28.Text, label59.Text);
            labelSparklistKg.Text = arr[0];
            textBox28.Text = arr[1];
            label59.Text = arr[2];
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            {
                string[] arr = new string[3];
                arr = kgCount(label7.Text, textBox8.Text, label26.Text);
                label7.Text = arr[0];
                textBox8.Text = arr[1];
                label26.Text = arr[2];
            }
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            string[] arr = new string[3];
            arr = kgCount(label7.Text, textBox27.Text, label58.Text);
            label7.Text = arr[0];
            textBox27.Text = arr[1];
            label58.Text = arr[2];
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox9.Text = "";
            textBox26.Text = "";
            label8.Text = "";
            string[] arr = new string[3];
            arr = Countbox(comboBoxItem2.Text, comboBox2.Text, label8.Text);
            comboBoxItem2.Text = arr[0];
            comboBox2.Text = arr[1];
            label8.Text = arr[2];
            if (comboBox2.Text != null)
            {
                textBox9.Show();
                textBox26.Show();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox10.Text = "";
            textBox25.Text = "";
            label9.Text = "";
            string[] arr = new string[3];
            arr = Countbox(comboBoxItem3.Text, comboBox3.Text, label9.Text);
            comboBoxItem3.Text = arr[0];
            comboBox3.Text = arr[1];
            label9.Text = arr[2];
            if (comboBox3.Text != null)
            {
                textBox10.Show();
                textBox25.Show();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox11.Text = "";
            textBox24.Text = "";
            label10.Text = "";
            string[] arr = new string[3];
            arr = Countbox(comboBoxItem4.Text, comboBox4.Text, label10.Text);
            comboBoxItem4.Text = arr[0];
            comboBox4.Text = arr[1];
            label10.Text = arr[2];
            if (comboBox4.Text != null)
            {
                textBox11.Show();
                textBox24.Show();
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox12.Text = "";
            textBox23.Text = "";
            label11.Text = "";
            string[] arr = new string[3];
            arr = Countbox(comboBoxItem5.Text, comboBox5.Text, label11.Text);
            comboBoxItem5.Text = arr[0];
            comboBox5.Text = arr[1];
            label11.Text = arr[2];
            if (comboBox5.Text != null)
            {
                textBox12.Show();
                textBox23.Show();
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox13.Text = "";
            textBox22.Text = "";
            label12.Text = "";
            string[] arr = new string[3];
            arr = Countbox(comboBoxItem6.Text, comboBox6.Text, label12.Text);
            comboBoxItem6.Text = arr[0];
            comboBox6.Text = arr[1];
            label12.Text = arr[2];
            if (comboBox6.Text != null)
            {
                textBox13.Show();
                textBox22.Show();
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox14.Text = "";
            textBox21.Text = "";
            label13.Text = "";
            string[] arr = new string[3];
            arr = Countbox(comboBoxItem7.Text, comboBox7.Text, label13.Text);
            comboBoxItem7.Text = arr[0];
            comboBox7.Text = arr[1];
            label13.Text = arr[2];
            if (comboBox7.Text != null)
            {
                textBox14.Show();
                textBox21.Show();
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox15.Text = "";
            textBox20.Text = "";
            label14.Text = "";
            string[] arr = new string[3];
            arr = Countbox(comboBoxItem8.Text, comboBox8.Text, label14.Text);
            comboBoxItem8.Text = arr[0];
            comboBox8.Text = arr[1];
            label14.Text = arr[2];
            if (comboBox8.Text != null)
            {
                textBox15.Show();
                textBox20.Show();
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox16.Text = "";
            textBox19.Text = "";
            label15.Text = "";
            string[] arr = new string[3];
            arr = Countbox(comboBoxItem9.Text, comboBox9.Text, label15.Text);
            comboBoxItem9.Text = arr[0];
            comboBox9.Text = arr[1];
            label15.Text = arr[2];
            if (comboBox9.Text != null)
            {
                textBox16.Show();
                textBox19.Show();
            }
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            string[] arr = new string[3];
            arr = kgCount(label8.Text, textBox26.Text, label57.Text);
            label8.Text = arr[0];
            textBox26.Text = arr[1];
            label57.Text = arr[2];
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox17.Text = "";
            textBox18.Text = "";
            label16.Text = "";
            string[] arr = new string[3];
            arr = Countbox(comboBoxItem10.Text, comboBox10.Text, label16.Text);
            comboBoxItem10.Text = arr[0];
            comboBox10.Text = arr[1];
            label16.Text = arr[2];
            if (comboBox10.Text != null)
            {
                textBox17.Show();
                textBox18.Show();
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            {
                string[] arr = new string[3];
                arr = kgCount(label8.Text, textBox9.Text, label25.Text);
                label8.Text = arr[0];
                textBox9.Text = arr[1];
                label25.Text = arr[2];
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            {
                string[] arr = new string[3];
                arr = kgCount(label9.Text, textBox10.Text, label24.Text);
                label9.Text = arr[0];
                textBox10.Text = arr[1];
                label24.Text = arr[2];
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            {
                string[] arr = new string[3];
                arr = kgCount(label10.Text, textBox11.Text, label23.Text);
                label10.Text = arr[0];
                textBox11.Text = arr[1];
                label23.Text = arr[2];
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            {
                string[] arr = new string[3];
                arr = kgCount(label11.Text, textBox12.Text, label22.Text);
                label11.Text = arr[0];
                textBox12.Text = arr[1];
                label22.Text = arr[2];
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            {
                string[] arr = new string[3];
                arr = kgCount(label12.Text, textBox13.Text, label21.Text);
                label12.Text = arr[0];
                textBox13.Text = arr[1];
                label21.Text = arr[2];
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            {
                string[] arr = new string[3];
                arr = kgCount(label13.Text, textBox14.Text, label20.Text);
                label13.Text = arr[0];
                textBox14.Text = arr[1];
                label20.Text = arr[2];
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            {
                string[] arr = new string[3];
                arr = kgCount(label14.Text, textBox15.Text, label19.Text);
                label14.Text = arr[0];
                textBox15.Text = arr[1];
                label19.Text = arr[2];
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            {
                string[] arr = new string[3];
                arr = kgCount(label15.Text, textBox16.Text, label18.Text);
                label15.Text = arr[0];
                textBox16.Text = arr[1];
                label18.Text = arr[2];
            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            {
                string[] arr = new string[3];
                arr = kgCount(label16.Text, textBox17.Text, label17.Text);
                label16.Text = arr[0];
                textBox17.Text = arr[1];
                label17.Text = arr[2];
            }
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            string[] arr = new string[3];
            arr = kgCount(label9.Text, textBox25.Text, label56.Text);
            label9.Text = arr[0];
            textBox25.Text = arr[1];
            label56.Text = arr[2];
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            string[] arr = new string[3];
            arr = kgCount(label10.Text, textBox24.Text, label55.Text);
            label10.Text = arr[0];
            textBox24.Text = arr[1];
            label55.Text = arr[2];
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            string[] arr = new string[3];
            arr = kgCount(label11.Text, textBox23.Text, label54.Text);
            label11.Text = arr[0];
            textBox23.Text = arr[1];
            label54.Text = arr[2];
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            string[] arr = new string[3];
            arr = kgCount(label12.Text, textBox22.Text, label53.Text);
            label12.Text = arr[0];
            textBox22.Text = arr[1];
            label53.Text = arr[2];
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            string[] arr = new string[3];
            arr = kgCount(label13.Text, textBox21.Text, label52.Text);
            label13.Text = arr[0];
            textBox21.Text = arr[1];
            label52.Text = arr[2];
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            string[] arr = new string[3];
            arr = kgCount(label14.Text, textBox20.Text, label51.Text);
            label14.Text = arr[0];
            textBox20.Text = arr[1];
            label51.Text = arr[2];
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            string[] arr = new string[3];
            arr = kgCount(label15.Text, textBox19.Text, label50.Text);
            label15.Text = arr[0];
            textBox19.Text = arr[1];
            label50.Text = arr[2];
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            string[] arr = new string[3];
            arr = kgCount(label16.Text, textBox18.Text, label49.Text);
            label16.Text = arr[0];
            textBox19.Text = arr[1];
            label49.Text = arr[2];
        }

        // Calculates total weight
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // CALC INNER
            string[] XinnerStr = {
            labelInnerFotTotal.Text,
            labelInnerSpiraTotal.Text,
            labelInnerPlankTotal.Text,
            labelInnerRäckeTotal.Text,
            labelInnerDiagonalTotal.Text,
            labelInnerSparklistTotal.Text,
            label26.Text,
            label25.Text,
            label24.Text,
            label23.Text,
            label22.Text,
            label21.Text,
            label20.Text,
            label19.Text,
            label18.Text,
            label17.Text,
            };

            //Converter
            string[] innerStr = new string[XinnerStr.Length];
            for (int i = 0; i < XinnerStr.Length; i++)
                innerStr[i] = Convert.ToString(XinnerStr[i]);

            double[] inner = new double[innerStr.Length];
            for (int i = 0; i < innerStr.Length; i++)
            {
                if (innerStr[i] == "")
                {
                    innerStr[i] = "0";
                }
                inner[i] = double.Parse(innerStr[i]);
            }

            // CALC OUTER
            string[] xouterStr = {
            label64.Text,
            label63.Text,
            label62.Text,
            label61.Text,
            label60.Text,
            label59.Text,
            label58.Text,
            label57.Text,
            label56.Text,
            label55.Text,
            label54.Text,
            label53.Text,
            label52.Text,
            label51.Text,
            label50.Text,
            label49.Text
            };

            //Converter
            string[] outerStr = new string[xouterStr.Length];
            for (int i = 0; i < xouterStr.Length; i++)
                outerStr[i] = Convert.ToString(xouterStr[i]);

            double[] outer = new double[outerStr.Length];
            for (int i = 0; i < outerStr.Length; i++)
            {
                if (outerStr[i] == "")
                {
                    outerStr[i] = "0";
                }
                outer[i] = double.Parse(outerStr[i]);
            }

            double totalInner = 0;
            double totalOuter = 0;



            for (int i = 0; i < inner.Length; i++)
                totalInner += inner[i];
            for (int i = 0; i < outer.Length; i++)
                totalOuter += outer[i];

            string totIn = Convert.ToString(totalInner);
            string totOut = Convert.ToString(totalOuter);

            label3.Text = totIn;
            label4.Text = totOut;

            double valIn = innerCalc(labelNyttiglast.Text, textBox36.Text, label3.Text);
            double valOut = outerCalc(labelNyttiglast.Text, textBox36.Text, label4.Text);

            underläggCalc(valIn, valOut);

        }

        public double innerCalc(string x, string y, string z)
        {
            if (x == string.Empty)
                x = "0";
            if (y == string.Empty)
                y = "1";
            if (z == string.Empty)
                z = "0";
            if (textBox36.Text == "")
                textBox36.Text = "1";
            double intx = double.Parse(x);
            double inty = double.Parse(y);
            double intz = double.Parse(z);
            double value = ((intx * inty) + intz) / 100;

            labelInner.Text = Convert.ToString(value) + " " + "kN";
            return value;
        }

        public double outerCalc(string x, string y, string z)
        {
            if (x == string.Empty)
                x = "0";
            if (y == string.Empty)
                y = "1";
            if (z == string.Empty)
                z = "0";
            if (textBox36.Text == "")
                textBox36.Text = "1";
            double intx = double.Parse(x);
            double inty = double.Parse(y);
            double intz = double.Parse(z);
            double value = ((intx * inty) + intz) / 100;

            labelYtter.Text = Convert.ToString(value) + " " + "kN";
            return value;
        }

        public void underläggCalc(double x, double y)
        {
            double undrlag = 0;
            double undInner = x;
            double undYtter = y;
            double main = 0;
            if (undInner > undYtter)
                main = undInner;
            else
                main = undYtter;
            try
            {
                undrlag = double.Parse(textBox34.Text);
            }
            catch
            {
                MessageBox.Show("Skriv in bärighet i mark");
                return;
            }
            double result = main / undrlag;
            string val = Convert.ToString(result);

            if (result > 0.0225)
                label30.Text = val + " kvm";
            else
                label30.Text = "Krävs ej";
        }

        private void labelInnerSpiraTotal_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                labelArea.Hide();
                textBox35.Show();
                double egenm2 = 0;
                area = textBox35.Text;
                if (textBox35.Text == string.Empty)
                    area = "0";
                try
                {
                    egenm2 = double.Parse(area);
                }
                catch
                {
                    MessageBox.Show("Något gick snett. Har du skrivit rätt?");
                    textBox35.Text = "";
                }
                calcLK(comboBoxLastklass.Text);
                double lasten = double.Parse(LK);
                double count = egenm2 * lasten;
                string countstr = Convert.ToString(count);
                labelNyttiglast.Text = countstr;
            }

            else if (checkBox1.Checked == false)
            {
                labelArea.Show();
                textBox35.Hide();
                {
                    try
                    {
                        area = areacalc(längd, bredd);
                    }
                    catch
                    {
                        MessageBox.Show("Något gick snett. Har du skrivit rätt?");
                        textBoxBredd.Text = "";
                    }
                    labelArea.Text = area;

                    double lastklass = 0;

                    lastArea = Double.Parse(labelArea.Text);
                    calcLK(comboBoxLastklass.Text);
                    try
                    {
                        lastklass = Double.Parse(LK);
                    }
                    catch
                    {
                        MessageBox.Show("Välj en lastklass");
                        comboBoxLastklass.Text = "Välj . . .";
                    }

                    double Nyttiglast = lastArea * lastklass;
                    string nyttiglastStr = Convert.ToString(Nyttiglast);
                    labelNyttiglast.Text = nyttiglastStr;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                try
                {
                    höjd = double.Parse(textBox1.Text);
                }
                catch
                {
                    {
                        MessageBox.Show("Något gick snett. Har du skrivit rätt?");
                        textBox1.Text = "";
                    }
                }
        }

        private void textBoxLängd_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                labelArea.Hide();
                textBox35.Show();
                double egenm2 = 0;
                area = textBox35.Text;
                if (textBox35.Text == string.Empty)
                    area = "0";
                try
                {
                    egenm2 = double.Parse(area);
                }
                catch
                {
                    MessageBox.Show("Något gick snett. Har du skrivit rätt?");
                    textBox35.Text = "";
                }
                calcLK(comboBoxLastklass.Text);
                double lasten = double.Parse(LK);
                double count = egenm2 * lasten;
                string countstr = Convert.ToString(count);
                labelNyttiglast.Text = countstr;
            }

            if (checkBox1.Checked == false)
            {
                längd = textBoxLängd.Text;
                if (längd == string.Empty)
                    längd = "0";
                try
                {
                    area = areacalc(längd, bredd);
                }
                catch
                {
                    MessageBox.Show("Något gick snett. Har du skrivit rätt?");
                    textBoxLängd.Text = "";
                }
                labelArea.Text = area;

                double lastklass = 0;
                lastArea = Double.Parse(labelArea.Text);
                calcLK(comboBoxLastklass.Text);

                try
                {
                    lastklass = Double.Parse(LK);
                }
                catch
                {
                    MessageBox.Show("Välj en lastklass");
                    comboBoxLastklass.Text = "Välj . . .";
                }

                double Nyttiglast = lastArea * lastklass;
                string nyttiglastStr = Convert.ToString(Nyttiglast);
                labelNyttiglast.Text = nyttiglastStr;

            }
        }

        private void textBoxBredd_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                labelArea.Hide();
                textBox35.Show();
                double egenm2 = 0;
                area = textBox35.Text;
                if (textBox35.Text == string.Empty)
                    area = "0";
                try
                {
                    egenm2 = double.Parse(area);
                }
                catch
                {
                    MessageBox.Show("Något gick snett. Har du skrivit rätt?");
                    textBox35.Text = "";
                }
                calcLK(comboBoxLastklass.Text);
                double lasten = double.Parse(LK);
                double count = egenm2 * lasten;
                string countstr = Convert.ToString(count);
                labelNyttiglast.Text = countstr;
            }

            if (checkBox1.Checked == false)
            {
                bredd = textBoxBredd.Text;
                if (bredd == string.Empty)
                    bredd = "0";
                try
                {
                    area = areacalc(längd, bredd);
                }
                catch
                {
                    MessageBox.Show("Något gick snett. Har du skrivit rätt?");
                    textBoxBredd.Text = "";
                }
                labelArea.Text = area;

                double lastklass = 0;
                lastArea = Double.Parse(labelArea.Text);
                calcLK(comboBoxLastklass.Text);
                try
                {
                    lastklass = Double.Parse(LK);
                }
                catch
                {
                    MessageBox.Show("Välj en lastklass");
                    comboBoxLastklass.Text = "Välj . . .";
                }

                double Nyttiglast = lastArea * lastklass;
                string nyttiglastStr = Convert.ToString(Nyttiglast);
                labelNyttiglast.Text = nyttiglastStr;
            }

        }
        public string areacalc(string y)
        {
            double l = double.Parse(y);
            double areaStr = l / 4;
            string value = Convert.ToString(areaStr);
            return value;
        }
        public string areacalc(string y, string z)
        {
            double l = double.Parse(y);
            double b = double.Parse(z);
            double areaStr = (l * b) / 4;
            string value = Convert.ToString(areaStr);
            return value;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void labelNyttiglast_Click(object sender, EventArgs e)
        {

        }
        private void comboBoxLastklass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                labelArea.Hide();
                textBox35.Show();
                double egenm2 = 0;
                area = textBox35.Text;
                if (textBox35.Text == string.Empty)
                    area = "0";
                try
                {
                    egenm2 = double.Parse(area);
                }
                catch
                {
                    MessageBox.Show("Något gick snett. Har du skrivit rätt?");
                    textBox35.Text = "";
                }
                calcLK(comboBoxLastklass.Text);
                double lasten = double.Parse(LK);
                double count = egenm2 * lasten;
                string countstr = Convert.ToString(count);
                labelNyttiglast.Text = countstr;
            }

            if (checkBox1.Checked == false)
            {
                try
                {
                    area = areacalc(längd, bredd);
                }
                catch
                {
                    MessageBox.Show("Något gick snett. Har du skrivit rätt?");
                    textBoxBredd.Text = "";
                }
                labelArea.Text = area;

                double lastklass = 0;

                lastArea = Double.Parse(labelArea.Text);
                calcLK(comboBoxLastklass.Text);
                try
                {
                    lastklass = Double.Parse(LK);
                }
                catch
                {
                    MessageBox.Show("Välj en lastklass");
                    comboBoxLastklass.Text = "Välj . . .";
                }

                double Nyttiglast = lastArea * lastklass;
                string nyttiglastStr = Convert.ToString(Nyttiglast);
                labelNyttiglast.Text = nyttiglastStr;
            }
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                labelArea.Hide();
                textBox35.Show();
                double egenm2 = 0;
                area = textBox35.Text;
                if (textBox35.Text == string.Empty)
                    area = "0";
                try
                {
                    egenm2 = double.Parse(area);
                }
                catch
                {
                    MessageBox.Show("Något gick snett. Har du skrivit rätt?");
                    textBox35.Text = "";
                }
                calcLK(comboBoxLastklass.Text);
                double lasten = double.Parse(LK);
                double count = egenm2 * lasten;
                string countstr = Convert.ToString(count);
                labelNyttiglast.Text = countstr;
            }

            if (checkBox1.Checked == false)
            {
                try
                {
                    area = areacalc(längd, bredd);
                }
                catch
                {
                    MessageBox.Show("Något gick snett. Har du skrivit rätt?");
                    textBoxBredd.Text = "";
                }
                labelArea.Text = area;

                double lastklass = 0;

                lastArea = Double.Parse(labelArea.Text);
                calcLK(comboBoxLastklass.Text);
                try
                {
                    lastklass = Double.Parse(LK);
                }
                catch
                {
                    MessageBox.Show("Välj en lastklass");
                    comboBoxLastklass.Text = "Välj . . .";
                }

                double Nyttiglast = lastArea * lastklass;
                string nyttiglastStr = Convert.ToString(Nyttiglast);
                labelNyttiglast.Text = nyttiglastStr;
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox1.SelectedItem)
            {
                case "Betong*, Berg":
                    textBox34.Text = "";
                    break;
                case "Grus och sten":
                    textBox34.Text = "500";
                    break;
                case "Asfalt väg":
                    textBox34.Text = "500";
                    break;
                case "Grov sand packad":
                    textBox34.Text = "350";
                    break;
                case "Asfalt trottoar":
                    textBox34.Text = "";
                    break;
                case "Parkeringsplats, Innergård":
                    textBox34.Text = "300";
                    break;
                case "Fin sand packad":
                    textBox34.Text = "250";
                    break;
                case "Lös sand":
                    textBox34.Text = "125";
                    break;
                case "Lera":
                    textBox34.Text = "80";
                    break;
                case "Greting":
                    textBox34.Text = "2";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Vill du skapa ett nytt formulär?";
            string caption = "Skapar nytt formulär . . .";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Form1 NewForm = new Form1();
                NewForm.Show();
                message = "Vill du radera ditt förra formulär?";
                caption = "Radera";
                var result2 = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result2 == DialogResult.Yes)
                {
                    message = "Är du säker på att du vill radera?";
                    caption = "Raderar formulär . . .";
                    var result3 = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result3 == DialogResult.Yes)
                        this.Dispose(false);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string message = "Vill du stänga alla formulär och avsluta?";
            string caption = "Avslutar programmet . . .";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string message2 = "Är du säker?";
                string caption2 = "Avslutar programmet . . .";
                var result2 = MessageBox.Show(message2, caption2, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result2 == DialogResult.Yes)
                    Application.Exit();

            }
        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {
            double test = 0;
            string str = textBox36.Text;
            if (str == string.Empty)
                str = "1";
            try
            {
                test = double.Parse(str);
            }
            catch
            {
                MessageBox.Show("Något gick snett. Har du skrivit rätt?");
                textBox36.Text = "";
            }
        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {
            double test = 0;
            string str = textBox34.Text;
            if (str == string.Empty)
                str = "1";
            try
            {
                test = double.Parse(str);
            }
            catch
            {
                MessageBox.Show("Något gick snett. Har du skrivit rätt?");
                textBox34.Text = "";
            }
        }
    }
}
