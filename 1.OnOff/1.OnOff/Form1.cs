using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// Phần trên là phần khởi tạo mặc định bạn không cần quan tâm
using System.IO.Ports; // Thêm dòng Code này để dùng lệnh với Serial.Port


namespace _1.OnOff
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) // Khi phần mềm được mở
        {
            comboBox1.DataSource = SerialPort.GetPortNames();//Quét các cổng Serial đang hoạt động lên ComboBox1
        }

        private void button1_Click(object sender, EventArgs e)// 
        {
            if (!serialPort1.IsOpen) // Nếu đối tượng serialPort1 chưa được mở , sau khi nhấn button 1 thỳ…
            {
                serialPort1.PortName = comboBox1.Text;//cổng serialPort1 = ComboBox mà bạn đang chọn
                serialPort1.Open();// Mở cổng serialPort1
                serialPort1.DataReceived += SerialPort1_DataReceived;
            }
            else
            {
                serialPort1.Close();
            }
            button1.Text = serialPort1.IsOpen ? "Ngắt kết nối" : "Kết nối";
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = (serialPort1.ReadLine()).Trim();
            int dec = Convert.ToInt32(data);
            char cha = (char)dec;
            string text =cha.ToString();
            

            textBox1.Invoke(new Action(() => { textBox1.Text = text.ToString(); }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write("2");//Nếu button2 được nhấn,gửi byte “1” đến cổng serialPort1
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.Write("1");//gửi byte “0” đến cổng serialPort1
        }



}
}
