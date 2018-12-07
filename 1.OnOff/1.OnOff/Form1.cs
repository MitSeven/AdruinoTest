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
            }
            else
            {
                serialPort1.Close();
            }
            button1.Text = serialPort1.IsOpen ? "Ngắt kết nối" : "Kết nối";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write("2");//Nếu button2 được nhấn,gửi byte “1” đến cổng serialPort1
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.Write("1");//gửi byte “0” đến cổng serialPort1
        }

        private void tácGiảToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phần mềm được viết bởi Ðỗ Hữu Toàn (Bạn của Ðinh Hồng Thái)", "Tác giả");// Nếu MenuTrip tác giả được nhấn thỳ hiện lên hộp thoại 
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Nếu ấn thoát…Thoát chương trình
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                button1.Text = ("Kết nối");
                label3.Text = ("Chưa kết nối");
                label3.ForeColor = Color.Red;
                //Nếu Timer được làm mới, Cổng serialPort1 chưa được mở thì thay đổi Text trong button1, label3…đổi màu text label3 thành màu đỏ 
            }
            else if (serialPort1.IsOpen)
            {
                button1.Text = ("Ngắt kết nối");
                label3.Text = ("Ðã kết nối");
                label3.ForeColor = Color.Green;
                //Nếu Timer được làm mới, Cổng serialPort1 đã mở thì thay đổi Text trong button1, label3…đổi màu text label3 thành màu xanh

            }
        }

}
}
