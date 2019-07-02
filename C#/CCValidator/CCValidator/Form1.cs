using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCValidator;

namespace CCValidator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void validateButton_Click(object sender, EventArgs e)
        {try
            {
                creditCardService.CCCheckerSoapClient soap = new creditCardService.CCCheckerSoapClient("CCCheckerSoap");
                this.outputLabel.Text = "Chacking...";
                string validation = soap.ValidateCardNumber(this.comboBox.Text, this.cctextBox.Text);
                this.outputLabel.Text = validation;
            }
            catch (Exception error)
            {
                this.outputLabel.Text = "" + error;
            }
        }
    }
}
