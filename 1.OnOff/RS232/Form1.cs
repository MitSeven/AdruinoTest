using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace RS232
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbCom.DataSource = SerialPort.GetPortNames();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serialPort1.PortName = cbCom.Text;
                serialPort1.Open();
                serialPort1.DataReceived += SerialPort1_DataReceived;
                lbStatus.Text = "Connected";
            }
            else
            {
                serialPort1.Close();
            }
            btnConnect.Text = serialPort1.IsOpen ? "Disconnect" : "Connect";
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] by = new byte[64];
            int len = serialPort1.Read(by,0,64);
            byte[] ch = new byte[len];
            Array.Copy(by, ch, len);
            string text = System.Text.Encoding.ASCII.GetString(ch);
            this.Invoke(new Action(() => { txtrcv.Text += text+"\n";lbStatus.Text = text; }));
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSend.Text))
            {
                lbStatus.Text = "String send empty";
            }
            else
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.WriteLine(txtSend.Text);
                }
                else
                {
                    lbStatus.Text = "Not connect";
                }
            }
        }
    }
}
