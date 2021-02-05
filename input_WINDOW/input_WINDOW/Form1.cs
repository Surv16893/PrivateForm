using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.IO;
using System.Windows.Forms;


namespace input_WINDOW
{
    public partial class Form1 : Form
    {
        string pass, password, previousPass, newPass;
        int attempt = 0, remained = 3;
        bool confirmation = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            do
            {
                Encoding UTF8Encoding = Encoding.GetEncoding(1251);
                StreamReader path = new StreamReader(@"C:\Users\chike\OneDrive\Рабочий стол\input_WINDOW\Key.txt", UTF8Encoding);
                if (File.Exists(@"C:\Users\chike\OneDrive\Рабочий стол\input_WINDOW\Key.txt"))
                    password = path.ReadLine();
                path.Close();

                pass = Interaction.InputBox("Input your password \n" +
                "If you type incorrect password 3 times program would be close.",
                "PASSWORD");
                if (pass == password)
                {
                    confirmation = true;
                    break;
                }
                else
                {
                    attempt++;
                    remained = 3 - attempt;
                    MessageBox.Show("Password isn't correct you have " + (remained).ToString() + " remains");
                }
            }
            while (attempt < 3);
            {
                if (confirmation)
                    MessageBox.Show("Password is right");
                else
                {
                    MessageBox.Show("U input wrong password for 3 time, program will be close");
                    FormClosing -= Form1_FormClosing;
                    this.Close();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show
                (
                "Do u wanna change your password before u leave?",
                "exit", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                    previousPass = Interaction.InputBox("Enter your previous password");
                     if (previousPass == password)
                     {
                        newPass = Interaction.InputBox("Enter your new Password");
                        StreamWriter path = new StreamWriter(@"C:\Users\chike\OneDrive\Рабочий стол\input_WINDOW\Key.txt");
                        path.WriteLine(newPass);
                        path.Close();
                        MessageBox.Show("OK");
                     }
                     else
                     {
                        MessageBox.Show("You entered wrong previous password");
                     }
            }
            else
            {
                MessageBox.Show("Program is closing");
                e.Cancel = false;
            }
        }
    }
}
