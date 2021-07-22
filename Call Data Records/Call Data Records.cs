using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_2
{
    public partial class CallDataRecords : Form
    {
        public CallDataRecords()
        {
            InitializeComponent();
        }

        private void CallDataRecords_Load(object sender, EventArgs e)
        {

        }

        private void Insert_Click(object sender, EventArgs e)
        {
            DataTable CDR = new DataTable();
            CDR.Columns.Add("Time of Call");
            CDR.Columns.Add("Duration");
            CDR.Columns.Add("Destination");
            CDR.Columns.Add("Area Code");
            CDR.Columns.Add("Connection");
            CDR.Columns.Add("PPM");
            CDR.Columns.Add("Total");

            DataRow row = CDR.NewRow();

            
            
            int duration = int.Parse(textBox3.Text);

            

            string prefix0 = textBox2.Text;
            string prefix = prefix0.Substring(0, 2);
            double connection, ppm, total;
            String areaCode;
            switch (prefix)
            {
                case "02":
                case "03":
                    areaCode = "Domestic";
                    connection = 0;
                    ppm = 0.5;
                    break;
                case "07":
                    areaCode = "Mobile";
                    connection = 0;
                    ppm = 5.5;
                    break;
                case "00":
                    areaCode = "International";
                    connection = 5;
                    ppm = 11.3;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Wrong input");
            }//switch

            total = duration * ppm + connection;

            row["Time of Call"] = textBox1.Text;
            row["Duration"] = textBox3.Text;
            row["Destination"] = textBox2.Text;
            row["Area Code"] =areaCode;
            row["Connection"] = connection;
            row["PPM"] = ppm;
            row["Total"] = total;
            CDR.Rows.Add(row);

            addRecord(textBox1.Text, textBox3.Text, textBox2.Text, areaCode, connection, ppm, total);

            foreach (DataRow Drow in CDR.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = Drow["Time of Call"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = Drow["Duration"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = Drow["Destination"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = Drow["Area Code"].ToString();
                dataGridView1.Rows[num].Cells[4].Value = Drow["Connection"].ToString();
                dataGridView1.Rows[num].Cells[5].Value = Drow["PPM"].ToString();
                dataGridView1.Rows[num].Cells[6].Value = Drow["Total"].ToString();

            }//foreach

        }//insertclick

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public static void addRecord(string time, string duration, string destination, string area, double connection, double ppm, double total)
        {
           

            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Daniele\source\repos\Assignment 2\Assignment 2\CSV.txt", true))
                {
                    file.WriteLine(time + ", "+ duration + ", " + destination + ", " + area + ", " + connection + ", " + ppm + ", " + total);
                }
            }//try
            catch(Exception ex)
            {
                throw new ApplicationException("This application did an oopsie",ex);

            }//catch
        }
    }
}
