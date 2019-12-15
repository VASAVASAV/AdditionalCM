using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MathParserNet;

namespace InterMn
{
    class MyProg : Form
    {
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private TextBox textBox1;
        private Button button2;
        private TextBox textBox2;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox textBox3;
        private bool MatrixCreated;
        private int NumOfPoints;
        private double[] grid;
        private double[] fgrid;
        private double LB, RB, TLB, TRB;
        private double[][] DivDif;
        private Label label2;
        private CheckBox checkBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label label3;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox5;
        private CheckBox checkBox2;
        private double[] Polynom;

        public MyProg()
        {
            MatrixCreated = false;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 133);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "Вузли сітки";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Інтерполянт";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Функція, що інтерполюється";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(889, 410);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(182, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(237, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(682, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(219, 89);
            this.button2.TabIndex = 4;
            this.button2.Text = "Інтерполювати!";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(182, 9);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 20);
            this.textBox2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Кількість точок сітки";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Location = new System.Drawing.Point(907, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 537);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Журнал";
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Location = new System.Drawing.Point(6, 19);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(179, 512);
            this.textBox3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Функція, що інтерполюється";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(425, 37);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(134, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Відображати функцію";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 87);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(285, 17);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Інтерполювати по рівномірно розподіленим вузлам";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(12, 110);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(210, 17);
            this.radioButton2.TabIndex = 12;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Інтерполювати по вузлам Чебишева";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Інтерполювати на проміжку від";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(182, 61);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(67, 20);
            this.textBox4.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "до";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(280, 61);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(67, 20);
            this.textBox5.TabIndex = 16;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(303, 98);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(150, 17);
            this.checkBox2.TabIndex = 17;
            this.checkBox2.Text = "Відображати вузли сітки";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // MyProg
            // 
            this.ClientSize = new System.Drawing.Size(1110, 562);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chart1);
            this.Name = "MyProg";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                NumOfPoints = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                textBox3.Text += "Кількість вузлів введена невірно. Спробуйте ввести ціле число" + Environment.NewLine;
                return;
            }
            if (NumOfPoints <= 1)
            {
                textBox3.Text += "Для інтерполяції необхідно більше точок" + Environment.NewLine;
                return;
            }
            int i, j, k;
            grid = new double[NumOfPoints];
            fgrid = new double[NumOfPoints];
            string function = textBox1.Text;
            Parser pars = new Parser();
            if (!(radioButton1.Checked || radioButton2.Checked))
            {
                textBox3.Text += "Виберіть тип вузлів" + Environment.NewLine;
                return;
            }
            try
            {
                LB = Convert.ToDouble(textBox4.Text);
                RB = Convert.ToDouble(textBox5.Text);
            }
            catch
            {
                textBox3.Text += "Невірно введена ліва або права границя. Спробуйте ввести число" + Environment.NewLine;
                return;
            }
            if (LB >= RB)
            {
                textBox3.Text += "Невірно заданий інтервал" + Environment.NewLine;
                return;
            }
            try
            {
                pars.AddVariable("e", Math.E);
                pars.AddVariable("pi", Math.PI);
                pars.AddVariable("x",Convert.ToDouble(LB));
                pars.SimplifyDouble(function);
                pars.RemoveVariable("x");
                pars.AddVariable("x", Convert.ToDouble(RB));
                pars.SimplifyDouble(function);
                pars.RemoveVariable("x");
            }
            catch
            {
                textBox3.Text += "Функція введена невірно" + Environment.NewLine;
                return;
            }
            if (radioButton1.Checked)
            {
                for (i = 0; i < NumOfPoints-1; i++)
                {
                    grid[i] = LB + i * ((RB - LB) / (NumOfPoints - 1));
                    pars.AddVariable("x", Convert.ToDouble(grid[i]));
                    fgrid[i] = pars.SimplifyDouble(function);
                    pars.RemoveVariable("x");
                }
                grid[NumOfPoints - 1] = RB;
                pars.AddVariable("x", Convert.ToDouble(RB));
                fgrid[NumOfPoints-1]=pars.SimplifyDouble(function);
                pars.RemoveVariable("x");
            }
            else
            {
                //double[] ChebGrid = new double[NumOfPoints];
                double Multipl = 1.0 / Math.Cos(((1.0) * Math.PI) / (2 * NumOfPoints));
                for (i = 1; i <= NumOfPoints; i++)
                {

                    //ChebGrid[i - 1] = Math.Cos(((2.0 * i - 1) * Math.PI) / (2 * NumOfPoints));
                    //grid[i - 1] = (LB + RB) / 2 - ((RB - LB) * Math.Cos(((2.0 * i - 1) * Math.PI) / (2 * NumOfPoints))) / 2;
                    grid[i - 1] = (LB + RB) / 2 - ((RB - LB) * Math.Cos(((2.0 * i - 1) * Math.PI) / (2 * NumOfPoints)) * Multipl) / 2;
                    pars.AddVariable("x", Convert.ToDouble(grid[i-1]));
                    fgrid[i-1] = pars.SimplifyDouble(function);
                    pars.RemoveVariable("x");
                }
            }
                //////////////////////
            
           /* try
            {
                for (i = 0; i < NumOfPoints; i++)
                {
                    Convert.ToDouble(this.dataGridView1.Rows[i].Cells[1].Value);
                    Convert.ToDouble(this.dataGridView1.Rows[i].Cells[2].Value);
                }
            }
            catch
            {
                textBox3.Text += "Сітка введена невірно" + Environment.NewLine;
                return;
            }*/
            /*string XFS, FXFS;
            for (i = NumOfPoints; i > 1; i--)
            {
                for (j = 0; j < i - 1; j++)
                {
                    if (Convert.ToDouble(this.dataGridView1.Rows[j].Cells[1].Value) > Convert.ToDouble(this.dataGridView1.Rows[j + 1].Cells[1].Value))
                    {
                        XFS = Convert.ToString(this.dataGridView1.Rows[j].Cells[1].Value);
                        FXFS = Convert.ToString(this.dataGridView1.Rows[j].Cells[2].Value);
                        this.dataGridView1.Rows[j].Cells[1].Value = this.dataGridView1.Rows[j + 1].Cells[1].Value;
                        this.dataGridView1.Rows[j].Cells[2].Value = this.dataGridView1.Rows[j + 1].Cells[2].Value;
                        this.dataGridView1.Rows[j + 1].Cells[1].Value = XFS;
                        this.dataGridView1.Rows[j + 1].Cells[2].Value = FXFS;
                    }
                }
            }*/
           /* for (i = 0; i < NumOfPoints; i++)
            {
                try
                {
                    grid[i] = Convert.ToDouble(this.dataGridView1.Rows[i].Cells[1].Value);
                }
                catch
                {
                    grid[i] = 0;
                }
                try
                {
                    fgrid[i] = Convert.ToDouble(this.dataGridView1.Rows[i].Cells[2].Value);
                }
                catch
                {
                    fgrid[i] = 0;
                }
            }*/
            TLB = LB; // - 0.05 * (RB - LB);
            TRB = RB;// +0.05 * (RB - LB);
            if (TLB == TRB)
            {
                TLB -= 0.5;
                TRB += 0.5;
            }
            this.chart1.ChartAreas[0].AxisY.Title = "f(x)";
            this.chart1.ChartAreas[0].AxisX.Title = "X";
            this.chart1.ChartAreas[0].AxisX.Minimum = Convert.ToDouble(TLB);
            this.chart1.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(TRB);
            this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0.0000}";
            this.chart1.Series[0].Color = Color.FromName("Black");
            this.chart1.Series[1].Color = Color.FromName("Red");
            this.chart1.Series[2].Color = Color.FromName("Blue");
            this.chart1.Series[2].MarkerSize = 6;
            this.chart1.Series[1].MarkerSize = 7;
            this.chart1.Series[0].MarkerSize = 8;
            this.chart1.Series[2].Points.Clear();
            this.chart1.Series[1].Points.Clear();
            this.chart1.Series[0].Points.Clear();
            double permval;
            double v1, v2;
            if (checkBox1.Checked)
            {
                string func = textBox1.Text;
                for (i = 0; i < 400; i++)
                {
                    pars.AddVariable("x", Convert.ToDouble(TLB + (((double)i) / 400) * (TRB - TLB)));
                    permval = pars.SimplifyDouble(func);
                    pars.RemoveVariable("x");
                    this.chart1.Series[2].Points.AddXY(TLB + (((double)i) / 400) * (TRB - TLB), permval);
                }

            }
            if (checkBox2.Checked)
            {
                for (i = 0; i < NumOfPoints; i++)
                {
                    this.chart1.Series[0].Points.AddXY(grid[i], fgrid[i]);
                }
            }
            DivDif = new double[NumOfPoints][];
            for (i = 0; i < NumOfPoints; i++)
            {
                DivDif[i] = new double[NumOfPoints - i];
            }
            for (i = 0; i < NumOfPoints; i++)
            {
                DivDif[0][i] = fgrid[i];
            }
            // for (i = 0; i < NumOfPoints - 1; i++)
            //  {
            // DivDif[0][i] = (fgrid[i] - fgrid[i + 1]) / (grid[i] - grid[i + 1]);
            // }
            for (i = 1; i < NumOfPoints; i++)
            {
                for (j = 0; j < NumOfPoints - i; j++)
                {
                    DivDif[i][j] = (DivDif[i - 1][j] - DivDif[i - 1][j + 1]) / (grid[j] - grid[j + i]);
                }
            }
            int Num = NumOfPoints * 10 + 5;
            double permx;
            for (i = 0; i <= Num; i++)
            {
                permx = TLB + (((double)i) / Num) * (TRB - TLB);
                permval = DivDif[NumOfPoints - 1][0];
                for (j = NumOfPoints - 2; j >= 0; j--)
                {
                    permval = permval * (permx - grid[j]) + DivDif[j][0];
                }
                //pars.RemoveVariable("x");
                this.chart1.Series[1].Points.AddXY(permx, permval);
            }
            /*Polynom = new double[NumOfPoints];
            for (i = 0; i < NumOfPoints-1; i++)
            {
                for (j = 0; j <= i; j++)
                {
 
                }
            }*/
        }

        
    }
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MyProg Prog = new MyProg();
            Application.Run(Prog);
        }
    }
}
