using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BarcodeLib;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Threading;

namespace barc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            // TODO: 这行代码将数据加载到表“barcodeDataSet.bc_memo”中。您可以根据需要移动或删除它。
            this.bc_memoTableAdapter.Fill(this.barcodeDataSet.bc_memo);
            // TODO: 这行代码将数据加载到表“barcodeDataSet.bc_product”中。您可以根据需要移动或删除它。
            this.bc_productTableAdapter.Fill(this.barcodeDataSet.bc_product);
            // TODO: 这行代码将数据加载到表“barcodeDataSet.BC_ELECFLOW”中。您可以根据需要移动或删除它。
            this.bC_ELECFLOWTableAdapter.Fill(this.barcodeDataSet.BC_ELECFLOW);
            // TODO: 这行代码将数据加载到表“barcodeDataSet.bc_factory”中。您可以根据需要移动或删除它。
            this.bc_factoryTableAdapter.Fill(this.barcodeDataSet.bc_factory);
            // TODO: 这行代码将数据加载到表“barcodeDataSet.bc_oem”中。您可以根据需要移动或删除它。
            this.bc_oemTableAdapter.Fill(this.barcodeDataSet.bc_oem);
            // TODO: 这行代码将数据加载到表“barcodeDataSet.bc_type3”中。您可以根据需要移动或删除它。
            this.bc_type3TableAdapter.Fill(this.barcodeDataSet.bc_type3);
            // TODO: 这行代码将数据加载到表“barcodeDataSet.bc_type2”中。您可以根据需要移动或删除它。
            this.bc_type2TableAdapter.Fill(this.barcodeDataSet.bc_type2);
            // TODO: 这行代码将数据加载到表“barcodeDataSet.bc_class”中。您可以根据需要移动或删除它。
            this.bc_classTableAdapter.Fill(this.barcodeDataSet.bc_class);
            // TODO: 这行代码将数据加载到表“barcodeDataSet.BC_ctype”中。您可以根据需要移动或删除它。
            this.bC_ctypeTableAdapter.Fill(this.barcodeDataSet.BC_ctype);
            // TODO: 这行代码将数据加载到表“barcodeDataSet.bc_color”中。您可以根据需要移动或删除它。
            this.bc_colorTableAdapter.Fill(this.barcodeDataSet.bc_color);
            // TODO: 这行代码将数据加载到表“barcodeDataSet.bc_gonglv”中。您可以根据需要移动或删除它。

            this.bc_gonglvTableAdapter.Fill(this.barcodeDataSet.bc_gonglv);

            // TODO: 这行代码将数据加载到表“barcodeDataSet.BC_TYPE4”中。您可以根据需要移动或删除它。
            this.bC_TYPE4TableAdapter.Fill(this.barcodeDataSet.BC_TYPE4);
            // TODO: 这行代码将数据加载到表“barcodeDataSet.bc_type1”中。您可以根据需要移动或删除它。
            this.bc_type1TableAdapter.Fill(this.barcodeDataSet.bc_type1);

            this.textBox5.Text = dateTimePicker1.Value.Year + "." + dateTimePicker1.Value.Month + "." + dateTimePicker1.Value.Day;
           
            basehelp hl = new basehelp();
            Thread th1 = new Thread(hl.run);
            Thread th2 = new Thread(hl.uprun);
            th1.IsBackground = true;
            th2.IsBackground = true;
            th1.Start();
            th2.Start();

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void type4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void type4_DropDown(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Bitmap bit = new Bitmap(400,340);
            Graphics g= Graphics.FromImage(bit);
            Brush brush = System.Drawing.Brushes.Black;
            Pen pen = new Pen(brush, 2);
            Font font = new Font("华文楷体", 12);
            g.Clear(Color.White);
            g.DrawRectangle(pen, 0, 0, 390, 335);

            //横线
            g.DrawLine(pen, 150, 40, 390, 40);
            g.DrawLine(pen, 0, 80, 390, 80);
            g.DrawLine(pen, 150, 140, 390, 140);
            g.DrawLine(pen, 0, 180, 390, 180);
            g.DrawLine(pen, 150, 220, 390, 220);
            g.DrawLine(pen, 150, 260, 390, 260);
            g.DrawLine(pen, 0, 285, 390, 285);


            //竖线
            g.DrawLine(pen, 150, 0, 150, 285);
            g.DrawLine(pen, 270, 0, 270, 80);
            g.DrawLine(pen, 270, 140, 270, 260);


            g.DrawString("功率/Pm:", new Font("华文楷体", 19), brush, 5, 90);


            g.DrawString("等级/Class:", new Font("华文楷体", 17), brush, 5, 190);


            g.DrawString("规格/Model", new Font("华文楷体", 13), brush, 150, 10);
            g.DrawString("日期/Date", new Font("华文楷体", 13), brush, 150, 50);
            g.DrawString("颜色/Colour", new Font("华文楷体", 13), brush, 150, 150);
            g.DrawString("尺寸/Cell Size", new Font("华文楷体", 13), brush, 150, 190);
            g.DrawString("数量/Quantity", new Font("华文楷体", 13), brush, 150, 230);
            bit.Save("c:\\myBitmap.png");



        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox6_MouseClick(null, null);
            Console.Write("开始打印" );
            if(check()){
                PrintDocument doprint = new PrintDocument();
                //doprint.DefaultPageSettings.PaperSize = new PaperSize("Custom1", 400, 340);
                //MessageBox.Show(doprint.DefaultPageSettings.PaperSize.PaperName + doprint.DefaultPageSettings.PaperSize.Height);

                doprint.PrintPage += new PrintPageEventHandler(doPrintPage);
                printDialog1.Document = doprint;
                printPreviewDialog1.Document = doprint;

                
                DialogResult re = printDialog1.ShowDialog();
                
                if (re != DialogResult.OK)
                {
                   //doprint.Print();
                   
                    return;
                }

                int copies = doprint.PrinterSettings.Copies;
                doprint.PrinterSettings.Copies = 1;
      
                for (int i = 0; i < copies; i++)
                {
                    doprint.Print();
                }

                //同步打印后的数据
                basehelp hl = new basehelp();
                Thread th1 = new Thread(hl.uprun);
                th1.Start();
            }
        }

        //最新标签打印样式
        private void doPrintPage(object sender, PrintPageEventArgs e)
        {
            int width = 390;
            int height = 335;
            Graphics g = e.Graphics;


            Brush brush = System.Drawing.Brushes.Black;
            Pen pen = new Pen(brush, 2);
            Font font = new Font("华文楷体", 12);

            e.Graphics.DrawRectangle(pen, 0, 0, width, height);

            //第一格横线
            g.DrawLine(pen, 0, 60, 150, 60);
            g.DrawLine(pen, 0, 105, 150, 105);
            g.DrawLine(pen, 0, 150, 150, 150);
            g.DrawLine(pen, 0, 195, 150, 195);
            g.DrawLine(pen, 0, 240, 150, 240);

            g.DrawLine(pen, 0, 285, 390, 285);

            //第二格横线
            g.DrawLine(pen, 150, 35, 390, 35);
            g.DrawLine(pen, 150, 70, 390, 70);
            g.DrawLine(pen, 150, 120, 390, 120);
            g.DrawLine(pen, 150, 155, 390, 155);
            g.DrawLine(pen, 150, 190, 390, 190);
            g.DrawLine(pen, 150, 225, 390, 225);
            g.DrawLine(pen, 150, 260, 390, 260);


            //竖线
            g.DrawLine(pen, 150, 0, 150, 285);
            g.DrawLine(pen, 270, 0, 270, 70);
            g.DrawLine(pen, 270, 120, 270, 260);

            //打印Magi
            g.DrawString(textBox10.Text, new Font("华文楷体", 30, FontStyle.Bold), brush, 5, 14);

            g.DrawString("功率/Pm:", new Font("华文楷体", 9, FontStyle.Bold), brush, 0, 65);
            g.DrawString(textBox8.Text, new Font("华文楷体", 20, FontStyle.Bold), brush, 30, 75);
            g.DrawString(textBox9.Text, new Font("华文楷体", 15, FontStyle.Bold), brush, 120, 85);

            g.DrawString("效率/Eff:", new Font("华文楷体", 9, FontStyle.Bold), brush, 0, 110);
            g.DrawString("电流/Impp:", new Font("华文楷体", 9, FontStyle.Bold), brush, 0, 155);
            g.DrawString("等级/Class:", new Font("华文楷体", 9, FontStyle.Bold), brush, 0, 200);

            SizeF sizf = g.MeasureString(textBox11.Text, new Font("华文楷体", 17, FontStyle.Bold));
            g.DrawString(textBox11.Text, new Font("华文楷体", 15, FontStyle.Bold), brush, (150 - sizf.Width) / 2, 210);

            g.DrawString("PECVD Type:", new Font("华文楷体", 9, FontStyle.Bold), brush, 0, 245);


            g.DrawString("规格/Model", new Font("华文楷体", 13, FontStyle.Bold), brush, 150, 10);
            g.DrawString(textBox7.Text, new Font("华文楷体", 11, FontStyle.Bold), brush, 270, 11);
           

            g.DrawString("日期/Date", new Font("华文楷体", 13, FontStyle.Bold), brush, 150, 45);
            g.DrawString(textBox5.Text, new Font("华文楷体", 13, FontStyle.Bold), brush, 270, 45);
            
            

            //打印代码
            sizf = g.MeasureString(textBox6.Text, new Font("华文楷体", 14, FontStyle.Bold));
            g.DrawString(textBox6.Text, new Font("华文楷体", 14, FontStyle.Bold), brush, 150 + (240 - sizf.Width) / 2, 70 + (60 - sizf.Height) / 2);
            g.DrawString(textBox14.Text, new Font("华文楷体", 13, FontStyle.Bold), brush, 365, 100);


            g.DrawString("栅线数量/Busbar No", new Font("华文楷体", 9, FontStyle.Bold), brush, 150, 130);

            g.DrawString("颜色/Colour", new Font("华文楷体", 13, FontStyle.Bold), brush, 150, 165);
            g.DrawString(textBox4.Text, new Font("华文楷体", 12, FontStyle.Bold), brush, 270, 165);
            g.DrawString("厚度/Thickness", new Font("华文楷体", 12, FontStyle.Bold), brush, 150, 200);
            g.DrawString(textBox3.Text, new Font("华文楷体", 13, FontStyle.Bold), brush, 270, 200);
            g.DrawString("数量/Quantity", new Font("华文楷体", 13, FontStyle.Bold), brush, 150, 235);
            g.DrawString(textBox12.Text, new Font("华文楷体", 13, FontStyle.Bold), brush, 270, 235);

            //打印内部代码
            g.DrawString(textBox15.Text, new Font("华文楷体", 8, FontStyle.Bold), brush, 151, 265);
            
            

        }
        

        private void doPrintPage1(object sender, PrintPageEventArgs e)
        {
            int width = 390;
            int height = 335;
            Graphics g = e.Graphics;


            Brush brush = System.Drawing.Brushes.Black;
            Pen pen = new Pen(brush, 2);
            Font font = new Font("华文楷体", 12);

            e.Graphics.DrawRectangle(pen, 0, 0, width, height);

            //横线
            g.DrawLine(pen, 150, 40, 390, 40);
            g.DrawLine(pen, 0, 80, 390, 80);
            g.DrawLine(pen, 150, 140, 390, 140);
            g.DrawLine(pen, 0, 180, 390, 180);
            g.DrawLine(pen, 150, 220, 390, 220);
            g.DrawLine(pen, 150, 260, 390, 260);


            g.DrawLine(pen, 0, 285, 390, 285);


            //竖线
            g.DrawLine(pen, 150, 0, 150, 285);
            g.DrawLine(pen, 270, 0, 270, 80);
            g.DrawLine(pen, 270, 140, 270, 260);

            //打印Magi
            g.DrawString(textBox10.Text, new Font("华文楷体", 30, FontStyle.Bold), brush, 5, 14);
            g.DrawString("功率/Pm:", new Font("华文楷体", 19, FontStyle.Bold), brush, 5, 90);

            g.DrawString(textBox8.Text, new Font("华文楷体", 25, FontStyle.Bold), brush, 20, 125);
            g.DrawString(textBox9.Text, new Font("华文楷体", 15, FontStyle.Bold), brush, 120, 153);

            g.DrawString("等级/Class:", new Font("华文楷体", 17, FontStyle.Bold), brush, 5, 190);

            SizeF sizf = g.MeasureString(textBox11.Text, new Font("华文楷体", 17, FontStyle.Bold));
            g.DrawString(textBox11.Text, new Font("华文楷体", 17, FontStyle.Bold), brush, (150 - sizf.Width) / 2, 235);

            g.DrawString("规格/Model", new Font("华文楷体", 13, FontStyle.Bold), brush, 150, 10);
            g.DrawString("日期/Date", new Font("华文楷体", 13, FontStyle.Bold), brush, 150, 50);
            g.DrawString("颜色/Colour", new Font("华文楷体", 13, FontStyle.Bold), brush, 150, 150);
            g.DrawString("尺寸/Cell Size", new Font("华文楷体", 13, FontStyle.Bold), brush, 150, 190);
            g.DrawString("数量/Quantity", new Font("华文楷体", 13, FontStyle.Bold), brush, 150, 230);

            sizf = g.MeasureString(textBox6.Text, new Font("华文楷体", 14, FontStyle.Bold));
            g.DrawString(textBox6.Text, new Font("华文楷体", 14, FontStyle.Bold), brush, 150 + (240 - sizf.Width) / 2, 80 + (60 - sizf.Height) / 2);

            g.DrawString(textBox7.Text, new Font("华文楷体", 11, FontStyle.Bold), brush, 270, 11);
            g.DrawString(textBox5.Text, new Font("华文楷体", 13, FontStyle.Bold), brush, 270, 50);

            g.DrawString(textBox14.Text, new Font("华文楷体", 13, FontStyle.Bold), brush, 365, 120);

            g.DrawString(textBox4.Text, new Font("华文楷体", 12, FontStyle.Bold), brush, 270, 150);
            g.DrawString(textBox3.Text, new Font("华文楷体", 13, FontStyle.Bold), brush, 270, 190);
            g.DrawString(textBox12.Text, new Font("华文楷体", 13, FontStyle.Bold), brush, 270, 230);
            g.DrawString(textBox15.Text, new Font("华文楷体", 8, FontStyle.Bold), brush, 151, 265);
            
            Barcode.DoEncode(g, 2, 290, BarcodeLib.TYPE.CODE93, getbarcode(), true, 385, 40);
            g.DrawString("Made in china", new Font("华文楷体", 8, FontStyle.Bold), brush, 320, 315);
        }


        public bool check()
        {
            if (comboBox5.SelectedValue == null) {
                MessageBox.Show("电池片类别无效");
                return false;
            }
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("电池片型号无效");
                return false;
            }
            if (comboBox3.SelectedValue == null)
            {
                MessageBox.Show("正面图案无效");
                return false;
            }
            if (comboBox7.SelectedValue == null)
            {
                MessageBox.Show("背面图案无效");
                return false;
            }
            if (type4.SelectedValue == null)
            {
                MessageBox.Show("产品工艺无效");
                return false;
            }
            if (comboBox8.SelectedValue == null)
            {
                MessageBox.Show("OEM厂商无效");
                return false;
            }
            if (comboBox9.SelectedValue == null)
            {
                MessageBox.Show("生产厂商无效");
                return false;
            }
            if (comboBox2.SelectedValue == null)
            {
                MessageBox.Show("电池片等级无效");
                return false;
            }
            if (comboBox4.SelectedValue == null)
            {
                MessageBox.Show("电池片功率无效");
                return false;
            }
            if (comboBox11.SelectedValue == null)
            {
                MessageBox.Show("电池片颜色无效");
                return false;
            }
            if (comboBox6.SelectedValue == null)
            {
                MessageBox.Show("电池片电流无效");
                return false;
            }
            if (comboBox10.SelectedValue == null)
            {
                MessageBox.Show("电池片状态无效");
                return false;
            }
            if ("".Equals(textBox2.Text))
            {
                MessageBox.Show("电池片数量无效");
                return false;
            }
          
            if (textBox13.Text=="")
            {
                MessageBox.Show("内部代码无效");
                return false;
            }
            if (comboBox13.SelectedValue == null) {
                MessageBox.Show("电池片备注无效");
                return false;
            }
            if (comboBox12.SelectedItem == null)
            {
                MessageBox.Show("电脑编号无效");
                return false;
            }
            return true;
        }

        public String getbarcode()
        {
            String[] dates = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W,", "X", "Y", "Z" };

            String product_code = comboBox5.SelectedValue.ToString();//电池片类别
            String type1_code = comboBox1.SelectedValue.ToString();//电池片型号
            String type2_code = comboBox3.SelectedValue.ToString();//正面图案
            String type3_code = comboBox7.SelectedValue.ToString();//背面图案
            String type4_code = type4.SelectedValue.ToString();//工艺代码   
            String oem_code = comboBox8.SelectedValue.ToString();//OEM
            String factory_code = comboBox9.SelectedValue.ToString();//制造厂商
            String class_code = comboBox2.SelectedValue.ToString();//电池片等级
            String gonglv_code = comboBox4.SelectedValue.ToString();//功率代码
            String color_code = comboBox11.SelectedValue.ToString();//电池片颜色
            String flow_code = comboBox6.SelectedValue.ToString();//电池片电流
            String ctype_code = comboBox10.SelectedValue.ToString();//电池片状态
            String ddate = dateTimePicker1.Value.Year % 100 + dates[dateTimePicker1.Value.Month] + dates[dateTimePicker1.Value.Day];
            String ddatenum = "";
            String computer = comboBox12.SelectedItem.ToString();
            Console.WriteLine("computer"+computer);
            if (bc_numTableAdapter.selectBy(ddate) == null)
            {
                bc_numTableAdapter.InsertQuery(ddate, 1);
                ddatenum = String.Format("{0:0000}", 1);
            }
            else
            {
                bc_numTableAdapter.UpdateQuery(ddate);

                ddatenum = String.Format("{0:0000}", (Int32)bc_numTableAdapter.selectBy(ddate));
            }


            StringBuilder sb = new StringBuilder();
            sb.Append(product_code);
            sb.Append(type1_code);
            sb.Append(type2_code);
            sb.Append(type3_code);//背面图案      
            sb.Append(type4_code);
            sb.Append(oem_code);//OEM  
            sb.Append(factory_code);//制造厂商
            sb.Append(class_code.Split('.')[1]);//电池片等级
            sb.Append(gonglv_code);//功率代码
            sb.Append(color_code);//电池片颜色
            sb.Append(flow_code);//高低电流
            sb.Append("-");
            sb.Append(computer);
            sb.Append(ctype_code);
            sb.Append(ddate);
            sb.Append(ddatenum);
            String barcode = sb.ToString();
            bc_barcodeTableAdapter.Insert(class_code, color_code, ctype_code, flow_code, factory_code,
                gonglv_code, oem_code, product_code, type1_code,
                type2_code, type3_code, type4_code, dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day, barcode,
                ddate + ddatenum, false, int.Parse(textBox2.Text), textBox1.Text, textBox13.Text, comboBox13.SelectedValue.ToString());
            
            
            return barcode;
        }


        



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox10_DropDown(object sender, EventArgs e)
        {

        }

        private void comboBox11_DropDown(object sender, EventArgs e)
        {

        }

        private void comboBox4_DropDown(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.textBox5.Text = dateTimePicker1.Value.Year+"."+dateTimePicker1.Value.Month+"."+dateTimePicker1.Value.Day;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            if ("" != comboBox4.Text)
            {
                textBox8.Text = comboBox4.Text;
            }

            if (comboBox4.Text.IndexOf("无") == -1)
            {
                textBox8.Text = comboBox4.Text;
            }
            else {
                textBox8.Text = "";
            }

        }

        private void comboBox11_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox11.Text.IndexOf("无") == -1)
            {
                textBox4.Text = comboBox11.Text;
            }
            else
            {
                textBox4.Text = "";
            }

        }

        private void comboBox6_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox6.Text.IndexOf("无") == -1)
            {
                textBox9.Text = comboBox6.Text;
            }
            else
            {
                textBox9.Text = "";
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text.IndexOf("A") != -1)
            {
                textBox11.Text = comboBox2.Text.Substring(0,comboBox2.Text.IndexOf("A")+1);
            }
            else
            {
                textBox11.Text = comboBox2.Text;
            }

            textBox7_MouseClick(null, null);
        }

        private void comboBox5_SelectedValueChanged(object sender, EventArgs e)
        {
            // this.bc_classTableAdapter.Fill(this.barcodeDataSet.bc_class);
            //
            if (comboBox5.SelectedValue != null)
            {
                //MessageBox.Show(comboBox5.SelectedValue.ToString());
                this.bc_classTableAdapter.FillBy(this.barcodeDataSet.bc_class, comboBox5.SelectedValue.ToString() + "%");
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            //MessageBox.Show("5");
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if(e.KeyChar>='0'&& e.KeyChar<='9'){
                e.Handled = false;
               
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox12.Text = textBox2.Text + " pcs";
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            if (comboBox5.SelectedValue != null)
            {
                //MessageBox.Show(comboBox5.SelectedValue.ToString());
                this.bc_classTableAdapter.FillBy(this.barcodeDataSet.bc_class, comboBox5.SelectedValue.ToString() + "%");
            }
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
           
        }
        //打印小标签

        private void doPrintPagelittle(object sender, PrintPageEventArgs e)
        {
           Barcode.DoEncode(e.Graphics, 2, 2, BarcodeLib.TYPE.CODE93, getbarcode(), true, 340, 40);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) {
                this.Hide();
               
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Visible = true;

            this.WindowState = FormWindowState.Normal;


        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此程序为迈吉电池片打印标签设计。\nautor:Mr.Chen\ndate:2013.7\nversion:1.8");
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_DropDown_1(object sender, EventArgs e)
        {
            this.bc_type1TableAdapter.Fill(this.barcodeDataSet.bc_type1);
        }

        private void comboBox13_SelectedValueChanged(object sender, EventArgs e)
        {
            
            if (comboBox13.Text.IndexOf("无") == -1)
            {
                if (comboBox13.SelectedValue == null)
                {
                    textBox14.Text = "";
                }
                else {
                    textBox14.Text = comboBox13.SelectedValue.ToString();
                    
                }
                
            }
            else
            {
                textBox14.Text = "";
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox7_MouseClick(null, null);
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (check()) { 
                StringBuilder sb = new StringBuilder("MGSC-");
                if (comboBox1.Text.IndexOf("P型156直角单晶") != -1)
                {
                    sb.Append("R6");
                }
                else if (comboBox1.Text.IndexOf("P型156准单晶") != -1)
                {
                    sb.Append("Q6");
                }
                else if (comboBox1.Text.IndexOf("P型156多晶") != -1)
                {
                    sb.Append("P6");
                }
                else  if (comboBox1.Text.IndexOf("P型156单晶") != -1)
                    {
                        sb.Append("M6");
                    }
                sb.Append(comboBox3.SelectedValue.ToString());
                sb.Append(comboBox7.SelectedValue.ToString());
                if(!"0".Equals(type4.SelectedValue.ToString())){
                    sb.Append(type4.SelectedValue.ToString());
                }
                sb.Append("-");
                if (comboBox1.Text.IndexOf("2BB") != -1)
                {
                    sb.Append("2BB");
                }
                else if (comboBox1.Text.IndexOf("3BB") != -1) {
                    sb.Append("3BB");
                }
                if (comboBox8.Text.IndexOf("无") == -1) {
                    sb.Append("-");
                    sb.Append(comboBox8.SelectedValue.ToString());
                }

                textBox6.Text=sb.ToString();
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            textBox15.Text = textBox13.Text;
        }

        private void textBox7_MouseClick(object sender, MouseEventArgs e)
        {
            textBox7.Text = "";
            if (comboBox1.Text.IndexOf("直角单晶") != -1)
            {
                textBox7.Text = "直角/Rect";
            }
            else if (comboBox1.Text.IndexOf("准单晶") != -1)
            {
                textBox7.Text = "准单晶/Monolike";
            }
            else if (comboBox1.Text.IndexOf("多晶") != -1)
            {
                textBox7.Text = "多晶/Multi";
            }
            else if (comboBox1.Text.IndexOf("单晶") != -1)
                {
                    textBox7.Text = "单晶/Mono";

                }

            if (comboBox2.Text.IndexOf("A") != -1) {
                String A=comboBox2.Text.Substring(comboBox2.Text.IndexOf("A")+1);
                textBox7.Text += "-"+A;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

       






    }
}