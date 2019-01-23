using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GenFunc;

namespace MDI_VFD.Motor
{
    public partial class frmMtrCalcFLC : Form
    {
        List<string> Volts50Hz = new List<string>() 
        {
            "190 VAC",
            "200 VAC",
            "208 VAC",
            "220 VAC",
            "230 VAC",
            "240 VAC",
            "380 VAC",
            "400 VAC",
            "415 VAC"
        };
        List<string> Volts60Hz = new List<string>()
        {
            "200 VAC",
            "208 VAC",
            "220 VAC",
            "230 VAC",
            "240 VAC",
            "380 VAC",
            "460 VAC",
            "575 VAC"
        };

        List<string> lstVolts;


        // delegate and event for sending calculated results back to parent form
        public delegate void FLCCalcHandler(object sender, FLCEventArgs e);
        public event FLCCalcHandler FLCCalculated;

        public frmMtrCalcFLC()
        {
            InitializeComponent();
        }

        private void frmMtrCalcFLC_Load(object sender, EventArgs e)
        {
            cmbFreq.SelectedIndex = 0;
            cmbFreq.Focus();
        }

        private void cmbFreq_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbVoltLow.Items.Clear();
            cmbVoltHigh.Items.Clear();

            if(cmbFreq.SelectedIndex == 0)
                lstVolts = Volts50Hz;
            else
                lstVolts = Volts60Hz;

            for(int i=0;i<lstVolts.Count;i++)
            {
                cmbVoltLow.Items.Add(lstVolts[i]);
                cmbVoltHigh.Items.Add(lstVolts[i]);
            }
        }

        private void btnCalcFLC_Click(object sender, EventArgs e)
        {
            // Make sure there is a selection for both voltages
            if((cmbVoltLow.SelectedIndex < 0) || (cmbVoltHigh.SelectedIndex < 0))
            {
                MsgBox.Err("Valid selections for low and high voltage range are required");
                goto btnCalcFLC_Click_Return;
            }

            // Make sure there is an entry in both the FLC textboxes
            if((txtFLCHigh.Text == "") || (txtFLCLow.Text == ""))
            {
                MsgBox.Err("Entries required in both FLC entry boxes.");
                goto btnCalcFLC_Click_Return;
            }


            // make sure the FLC entries are valid decimal values
            double flc_low, flc_high;
            try
            {
                flc_low = Convert.ToDouble(txtFLCLow.Text);
                flc_high = Convert.ToDouble(txtFLCHigh.Text);
            }
            catch
            {
                MsgBox.Err("Numeric entries are required for both FLC entry boxes.");
                goto btnCalcFLC_Click_Return;
            }

            
            // Get the voltage selections and make sure the selections
            // produce a valid voltage range.
            int sel_low = cmbVoltLow.SelectedIndex;
            int volt_low = VoltText2Int(lstVolts[sel_low]);

            int sel_high = cmbVoltHigh.SelectedIndex;
            int volt_high = VoltText2Int(lstVolts[sel_high]);


            int volt_rng = volt_high - volt_low;
            if(volt_rng <= 0)
            {
                MsgBox.Err("High voltage selection must be greater than the low voltage selection");
                goto btnCalcFLC_Click_Return;
            }

            dgvFLC.Rows.Clear();

            // calculate the slope of the linear FLC range
            double flc_rng = flc_high - flc_low;
            double slope = flc_rng / ((double)volt_rng);

            // calculate the y-intercept of the range
            double y_int = flc_low - (slope * volt_low);

            for(int i=sel_low;i<=sel_high;i++)
            {
                double volts = (double)VoltText2Int(lstVolts[i]);
                double flc = (volts * slope) + y_int; // y = mx + b

                flc = Math.Round(flc, 2);
                dgvFLC.Rows.Add(new string[]
                    {
                        lstVolts[i], flc.ToString() + " A"
                    }
                    );
            }

            if(dgvFLC.Rows.Count > 0)
            {
                btnStore.Visible = true;
                this.AcceptButton = btnStore;
                btnStore.Focus();
            }

            btnCalcFLC_Click_Return:
            return;
        }

        int VoltText2Int(string p_VoltText)
        {
            return Convert.ToInt32(p_VoltText.Substring(0, p_VoltText.IndexOf(' ')));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbVoltLow.SelectedIndex = -1;
            cmbVoltHigh.SelectedIndex = -1;
            txtFLCLow.Text = "";
            txtFLCHigh.Text = "";
            dgvFLC.Rows.Clear();
            btnStore.Visible = false;
            this.AcceptButton = btnCalcFLC;
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            FLCEventArgs args = new FLCEventArgs();
            for(int i=0;i<dgvFLC.Rows.Count;i++)
            {
                FLCVals vals = new FLCVals();
                vals.Freq = Convert.ToInt32(cmbFreq.Text.Substring(0, cmbFreq.Text.IndexOf(' ')));
                vals.Volts = VoltText2Int(dgvFLC.Rows[i].Cells[0].Value.ToString());
                vals.FLC = Convert.ToDouble(dgvFLC.Rows[i].Cells[1].Value.ToString().Substring(0, dgvFLC.Rows[i].Cells[1].Value.ToString().IndexOf(' ')));
                args.FLCData.Add(vals);
            }

            FLCCalculated(this, args);

            this.Close();
        }

        private void frmMtrCalcFLC_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                this.Close();
        }
    }

    public class FLCEventArgs : EventArgs
    {
        public List<FLCVals> FLCData;

        public FLCEventArgs()
        {
            FLCData = new List<FLCVals>();
        }
    }

    public class FLCVals
    {
        public int Freq;
        public int Volts;
        public double FLC;

        public FLCVals()
        {
            Freq = 0;
            Volts = 0;
            FLC = 0.0;
        }
    }
}
