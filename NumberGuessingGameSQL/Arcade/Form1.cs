using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Arcade
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string constring = ("Data Source=.;Initial Catalog = arcade; Integrated Security = True");
        SqlConnection baglan = new SqlConnection(constring);
        public void kayitlari_getir()
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    string getir = "Select * From highscore";
                    SqlCommand komut = new SqlCommand(getir, baglan);
                    SqlDataAdapter ad = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglan.Close();
                }
            }
            catch (Exception error)
            {

                MessageBox.Show("Connection Problem! \n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        Random random = new Random();
        int ksay;
        int tsay;
        int can;
        int yours = 0;
        int scan = 8;
        int sks = 0;
        int sbs = 50;

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                yours++;
                label7.Text = yours.ToString();
                if (can != 0)
                {

                    try
                    {
                        ksay = Convert.ToInt32(textBox1.Text);
                    }
                    catch (Exception h)
                    {
                        MessageBox.Show("Please enter number only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (ksay < tsay)
                    {
                        label6.Text = "The number you entered '" + ksay + "', slightly smaller than mine...";
                        can--;
                        label2.Text = can.ToString();
                        textBox1.Text = "";
                    }
                    else if (ksay > tsay)
                    {
                        label6.Text = "The number you entered '" + ksay + "', slightly bigger than mine...";
                        can--;
                        label2.Text = can.ToString();
                        textBox1.Text = "";
                    }
                    else if (ksay == tsay)
                    {
                        label6.Text = "Congratulations You've Entered  '" + ksay + "', number is correct...";
                        textBox1.Text = "";
                        MessageBox.Show("Congratulations You've Entered  '" + ksay + "', number is correct... If you want to play again, please press 'OK'", "Play Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string hsc = dataGridView1.Rows[0].Cells[0].Value.ToString();

                        if (Convert.ToInt32(label7.Text) < Convert.ToInt32(hsc))
                        {
                            baglan.Open();
                            string upd = "update highscore set highs = @hgh";
                            SqlCommand komut = new SqlCommand(upd, baglan);
                            komut.Parameters.AddWithValue("@hgh", label7.Text);
                            komut.ExecuteNonQuery();
                            MessageBox.Show("Congrats, new highscore!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            baglan.Close();

                            label4.Text = label7.Text;
                        }
                        can = scan;
                        yours = 0;
                        label2.Text = "8";
                        tsay = random.Next(sks, sbs);
                        label7.Text = "0";

                    }

                }
                else
                {
                    MessageBox.Show("You're out of life. The number was: " + tsay + ", please try again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tsay = random.Next(sks, sbs);
                    can = scan;
                    label2.Text = can.ToString();
                    yours = 0;
                    label7.Text = "0";
                    textBox1.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Please make a guess.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kayitlari_getir();

            label4.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();


            tsay = random.Next(sks, sbs);
            can = scan;
            label2.Text = can.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string reset = "update highscore set highs = '100'";
            SqlCommand komut = new SqlCommand(reset, baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            //System.IO.File.WriteAllText(filePath, String.Empty);
            //System.IO.File.AppendAllText(filePath, "100");
            label4.Text = "100";
            tsay = random.Next(sks, sbs);
            can = scan;
            label2.Text = can.ToString();
            yours = 0;
            label7.Text = "0";
            MessageBox.Show("Game reset successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                scan = 8;
                sks = 0;
                sbs = 50;
                tsay = random.Next(sks, sbs);

                can = scan;
                label2.Text = can.ToString();
                yours = 0;
                label7.Text = "0";
                MessageBox.Show("Settings successfully updated.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (radioButton2.Checked)
            {
                scan = 8;
                sks = 0;
                sbs = 75;
                tsay = random.Next(sks, sbs);

                can = scan;
                label2.Text = can.ToString();
                yours = 0;
                label7.Text = "0";
                MessageBox.Show("Settings successfully updated.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (radioButton3.Checked)
            {
                scan = 8;
                sks = 0;
                sbs = 100;
                tsay = random.Next(sks, sbs);

                can = scan;
                label2.Text = can.ToString();
                yours = 0;
                label7.Text = "0";
                MessageBox.Show("Settings successfully updated.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please make choose.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}