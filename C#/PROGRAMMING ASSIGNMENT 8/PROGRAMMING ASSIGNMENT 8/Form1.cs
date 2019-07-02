using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROGRAMMING_ASSIGNMENT_8
{
    public partial class timeKeepingLogin : Form
    {
        public timeKeepingLogin()
        {
            InitializeComponent();
        }
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = "";//rest text box

                Employee employee1 = new Employee(this.textBoxEmployeeName.Text, this.textBoxSupervisorName.Text);
                NumberValidation.weeksInYear(Convert.ToInt32(this.numericWeekNumber.Value));

                checkMaintTabel();
                checkOutputTable();
                calculateWorkHours();
            }
            catch (FormatException formatException)//used for potential invalid input IE letters in doubles or ints 
            {//this is a system method 
                richTextBox1.Text = formatException.Message;
            }
            catch (NegativeNumberException negativeNumberException)//if negative number error is given 
            {//this is a custom method 
                richTextBox1.Text = negativeNumberException.Message;
            }
            catch (NumberValidationException NumberValidationException)//if negative number error is given 
            {//this is a custom method 
                richTextBox1.Text = NumberValidationException.Message;
            }
            catch (StringValidationException StringValidationException)//if negative number error is given 
            {//this is a custom method 
                richTextBox1.Text = StringValidationException.Message;
            }
        }
        private void timeKeepingLogin_Load(object sender, EventArgs e)
        {
            foreach (string name in Clients.getClients())//load time sheet
                this.dataGridView1.Rows.Add(name);

            foreach (string day in Weekdays.getDays())//load totals sheet
                this.dataGridView3.Rows.Add(day);
            dataGridView3.Rows[5].Cells[2].Value = true;//check Saturday
            dataGridView3.Rows[6].Cells[2].Value = true;//check Sunday
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void textBoxEmployeeName_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBoxSupervisorName_TextChanged(object sender, EventArgs e)
        {
        }
        private void numericWeekNumber_ValueChanged(object sender, EventArgs e)
        {
        }
        private void checkMaintTabel()
        {
            //loop through all the hours that are entered 
            for (int col = 4; col <= Weekdays.getDays().Count() + 3; col++)//first check each day 
            {
                double total = 0;//reset daily total to 0
                for (int row = 0; row <= Clients.getClients().Count() - 1; row++)//check each client for a given day
                {
                    double num = 0;// number used to hold value of cell
                    if (dataGridView1.Rows[row].Cells[col].Value != null)//if the cell contains data
                    {
                        double.TryParse(dataGridView1.Rows[row].Cells[col].Value.ToString(), out num);//try to convert that data to a double
                        total += num;//and add it to the daily total
                    }
                }
                dataGridView3.Rows[col - 4].Cells[1].Value = NumberValidation.hoursInDay(total);// at the end of each day put the total hours in the output chart also check to validate the time 
            }

            //loop though all the non hour data entered
            for (int row = 0; row <= Clients.getClients().Count() -1 ; row++)//first check each client
            {
                double total = 0;//reset each client, to 0
                for (int col = 4; col <= Weekdays.getDays().Count() + 3; col++)//check each work day
                {
                    double num = 0;// number used to hold value of cell
                    if (dataGridView1.Rows[row].Cells[col].Value != null)//if the cell contains data
                    {
                        double.TryParse(dataGridView1.Rows[row].Cells[col].Value.ToString(), out num);//try to convert that data to a double
                        total += num;//add all hours for each client
                    }
                }
                if (total > 0)// if a given client has work hours
                    for (int col = 1; col <= 3; col++)// check each non-hour cell for data 
                        if (dataGridView1.Rows[row].Cells[col].Value == null)//if its empty
                            throw new StringValidationException("please enter contract/project/billing level information for " + Clients.getClient(row));//throw error
            }
        }
        private void checkOutputTable()
        {
            for (int row = 0; row <= Weekdays.getDays().Count() - 1; row++)//loop though the days in the output chart 
            {
                bool check;// bool used to hold value of cell
                double num = 0;// number used to hold value of cell
                if (dataGridView3.Rows[row].Cells[2].Value != null)//if cell contains data
                    bool.TryParse(dataGridView3.Rows[row].Cells[2].Value.ToString(), out check);//try to make it a bool and assign it to check
                else// if cell has no value
                    check = false;//than set the check to false 
                if (dataGridView3.Rows[row].Cells[1].Value.ToString() == "0" & check == false)//if the hours are 0 and box is unchecked
                    if (MessageBox.Show(Weekdays.getDay(row) + " is missing information", "Timekeeping",//warn user
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                        throw new NumberValidationException("Please enter information for " + Weekdays.getDay(row));//and throw excepting 
                if (dataGridView3.Rows[row].Cells[1].Value != null)//if cell contains data
                    double.TryParse(dataGridView3.Rows[row].Cells[1].Value.ToString(), out num);//try to convert that data to a double
                if (num > 0)//if the cell has some hours
                    dataGridView3.Rows[row].Cells[2].Value = false;//uncheck the box
            }
        }
        private void calculateWorkHours()
        {
            Employee employee1 = new Employee(this.textBoxEmployeeName.Text, this.textBoxSupervisorName.Text);
            double totalHours = 0;
            double regularHours;
            double overTimeHours = 0;
            double HOURSTILLOVERTIME = 40;
            double regularPay;
            double overTimePay;
            double totalPay;
            int ptoDays = 0;
            bool fullTime;

            for (int row = 0; row <= Weekdays.getDays().Count() - 1; row++)
            {
                double num = 0;// number used to hold value of cell
                bool check;// bool used to hold value of cell
                if (dataGridView3.Rows[row].Cells[1].Value != null)//if cell contains data
                    double.TryParse(dataGridView3.Rows[row].Cells[1].Value.ToString(), out num);//try to convert that data to a double
                totalHours += num;
                if (dataGridView3.Rows[row].Cells[2].Value != null)//if cell contains data
                    bool.TryParse(dataGridView3.Rows[row].Cells[2].Value.ToString(), out check);//try to make it a bool and assign it to check
                else// if cell has no value
                    check = false;//than set the check to false 
                if (check == true)
                    ptoDays++;
            }

            if (totalHours >= HOURSTILLOVERTIME)
            {
                regularHours = HOURSTILLOVERTIME;
                overTimeHours = totalHours - HOURSTILLOVERTIME;
                fullTime = true;
            }
            else
            {
                regularHours = totalHours;
                fullTime = false;
            }

            regularPay = regularHours * employee1.getPayRate();
            overTimePay = overTimeHours * employee1.getPayRate() * 1.5;
            totalPay = regularPay + overTimePay;

            richTextBox1.Text = "Payroll information for "+employee1.getName() + " for the week " + NumberValidation.weeksInYear(Convert.ToInt32(this.numericWeekNumber.Value));
            if(fullTime)
                richTextBox1.AppendText("\nSupervisor:" + employee1.getSupervisorName());
            else
                richTextBox1.AppendText("\nSupervisor: " + employee1.getSupervisorName()+ "\nNote: less than " + HOURSTILLOVERTIME+" hours worked");
            richTextBox1.AppendText("\nNumber of Weekend/Holiday/Vacation days claimed: " + ptoDays);
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("\nTotal Hours Worked:               " + totalHours);
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("\nRegular Hours Worked:             " + regularHours);
            richTextBox1.AppendText("\nRate per regular work hour:      $" + employee1.getPayRate());
            richTextBox1.AppendText("\nRegular Hourly Pay:              $" + regularPay);
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("\nOverTime Hours Worked:            " + overTimeHours);
            richTextBox1.AppendText("\nRate per overtime work hour:     $" + employee1.getPayRate()*1.5);
            richTextBox1.AppendText("\nOvertime Hourly Pay:             $" + overTimePay);
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("\nGross Pay:                       $" + totalPay);
        }
    }
}
