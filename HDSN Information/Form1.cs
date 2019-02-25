using System;
using System.Management;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDSN_Information
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList hardDriveDetails = new ArrayList();

            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject wmi_HD in moSearcher.Get())
            {
                HardDrive hd = new HardDrive();  // User Defined Class
                hd.Model = wmi_HD["Model"].ToString();  //Model Number
                hd.Type = wmi_HD["InterfaceType"].ToString();  //Interface Type
                hd.SerialNo = wmi_HD["SerialNumber"].ToString(); //Serial Number
                hardDriveDetails.Add(hd);
                //label1.Text = "Manufacturer : " + hd.Manufacturer;
                textBox1.Text = hd.Model;
                textBox2.Text = hd.Type;
                textBox3.Text = hd.SerialNo;
            }
        }
    }
}

class HardDrive
{
    private string model = null;
    private string type = null;
    private string serialNo = null;
    public string Model
    {
        get { return model; }
        set { model = value; }
    }
    public string Type
    {
        get { return type; }
        set { type = value; }
    }
    public string SerialNo
    {
        get { return serialNo; }
        set { serialNo = value; }
    }
}