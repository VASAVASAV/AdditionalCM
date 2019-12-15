using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab1Grads
{
    class Lab : Form
    {
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private TextBox textBox3;
        private Label label2;
        private DataGridView dataGridView1;

        public Lab()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Size of matrix";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(775, 403);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(793, 15);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(220, 443);
            this.textBox2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "Розв\'язати методом CG";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(337, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 40);
            this.button2.TabIndex = 5;
            this.button2.Text = "Розв\'язати методом найшвидшого спуску";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(650, 25);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 8;
            this.textBox3.Text = "0,01";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(650, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Accuracy";
            // 
            // Lab
            // 
            this.ClientSize = new System.Drawing.Size(1025, 465);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Lab";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void LogOutput(string Message)
        {
            textBox2.Text += Message + Environment.NewLine;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int Length;
            try
            {
                Length = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                return;
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if ((Length > 30 || Length < 1))
            {
                LogOutput("Wrong size");
                return;
            }
            for (int i = 0; i < Length; i++)
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].HeaderText = "a" + (i + 1);
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].Width = 75;
            }
            for (int i = 0; i < Length; i++)
            {
                dataGridView1.Rows.Add();
            }
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].HeaderText = "b";
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Width = 75;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].HeaderText = "x0(опціонально)";
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Width = 100;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].HeaderText = "x";
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Width = 75;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Length;
            try
            {
                Length = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                return;
            }
            if ((Length > 30 || Length < 1))
            {
                LogOutput("Wrong size");
                return;
            }
            double epsiolon;
            try
            {
                epsiolon = Convert.ToDouble(textBox3.Text);
            }
            catch
            {
                LogOutput("Wrong accuracy");
                return;
            }
            if (epsiolon < 0)
            {
                LogOutput("Wrong size");
                return;
            }
            double[,] x = new double[Length,1];
            double[,] p = new double[Length,1];
            double[,] r = new double[Length,1];
            double[,] b = new double[Length,1];
            double[,] A = new double[Length,Length];
            try
            {
                for (int i = 0; i < Length; i++)
                {
                    x[i,0] = (Convert.ToDouble(dataGridView1.Rows[i].Cells[Length + 1].Value));
                }
            }
            catch
            {
                LogOutput("Initial x vector is wrong; 0 values are taken instead");
                for (int i = 0; i < Length; i++)
                {
                    x[i,0] = 0; 
                }
            }
            try
            {
                for (int i = 0; i < Length; i++)
                {
                    b[i,0] = (Convert.ToDouble(dataGridView1.Rows[i].Cells[Length].Value));
                }
            }
            catch
            {
                LogOutput("B vector is wrong");
                return;
            }
            try
            {
                for (int i = 0; i < Length; i++)
                {
                    for (int j = 0; j < Length; j++)
                    {
                        A[i, j] = (Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value));
                    }
                }
            }
            catch
            {
                LogOutput("A matrix is wrong");
                return;
            }
            DateTime Now = DateTime.Now;
            var temp = Matrixes.Multiply(A, x);
            for (int i = 0; i < Length; i++)
            {
                r[i, 0] = b[i, 0] - temp[i, 0];
            }
            for (int i = 0; i < Length; i++)
            {
                p[i, 0] = r[i, 0];
            }
            double alfa = 0, beta;
            double tempDouble=0;
            for (int i = 0; i < Length; i++)
            {
                alfa += r[i, 0] * r[i, 0];
            }
            temp = Matrixes.Multiply(A, p);
            for (int i = 0; i < Length; i++)
            {
                tempDouble += temp[i,0] * r[i, 0];
            }
            alfa /= tempDouble;
            for (int i = 0; i < Length; i++)
            {
                x[i, 0] = x[i, 0] + alfa * p[i, 0];
            }
            for (int i = 0; i < Length; i++)
            {
                r[i,0] = r[i,0] - alfa*    temp[i, 0];
            }
            while (!Less(epsiolon, r))
            {
                beta = 0;
                temp = Matrixes.Multiply(A, p);
                tempDouble = 0;
                for (int i = 0; i < Length; i++)
                {
                    tempDouble += temp[i, 0] * p[i, 0];
                }
                for (int i = 0; i < Length; i++)
                {
                    beta += temp[i, 0] * r[i, 0];
                }
                beta = -1 * (beta / tempDouble);
                for (int i = 0; i < Length; i++)
                {
                    p[i,0] += beta*p[i,0]+r[i,0];
                }
                alfa = 0;
                tempDouble = 0;
                for (int i = 0; i < Length; i++)
                {
                    alfa += r[i, 0] * r[i, 0];
                }
                temp = Matrixes.Multiply(A, p);
                for (int i = 0; i < Length; i++)
                {
                    tempDouble += temp[i, 0] * r[i, 0];
                }
                alfa /= tempDouble;
                for (int i = 0; i < Length; i++)
                {
                    x[i, 0] = x[i, 0] + alfa * p[i, 0];
                }
                for (int i = 0; i < Length; i++)
                {
                    r[i, 0] = r[i, 0] - alfa * temp[i, 0];
                }
            }
            for (int i = 0; i < Length; i++)
            {
                dataGridView1.Rows[i].Cells[Length + 2].Value = x[i, 0];
            }
            LogOutput("Time of work =" + (DateTime.Now - Now).TotalMilliseconds/1000 +"s");
        }

        private bool Less(double eps, double[,] Vector)
        {
            for (int i = 0; i < Vector.GetLength(0); i++)
            {
                for (int j = 0; j < Vector.GetLength(1); j++)
                {
                    if (eps < Math.Abs(Vector[i,j]))
                        return false;
                }
            }
            return true;
        }
        
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < dataGridView1.Rows.Count)
            {
                try
                {
                    Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                }
                catch
                {
                    LogOutput("Було введено не число");
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    return;
                }
                //if (("" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value).Contains("-"))
                //{
                //    LogOutput("Підтримуються лише додатні значення");
                //    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                //    return;
                //}
                dataGridView1.Rows[e.ColumnIndex].Cells[e.RowIndex].Value = "" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Length;
            try
            {
                Length = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                return;
            }
            if ((Length > 30 || Length < 1))
            {
                LogOutput("Wrong size");
                return;
            }
            double epsiolon;
            try
            {
                epsiolon = Convert.ToDouble(textBox3.Text);
            }
            catch
            {
                LogOutput("Wrong accuracy");
                return;
            }
            if (epsiolon < 0)
            {
                LogOutput("Wrong size");
                return;
            }
            double[,] x = new double[Length, 1];
            double[,] r = new double[Length, 1];
            double[,] b = new double[Length, 1];
            double[,] A = new double[Length, Length];
            try
            {
                for (int i = 0; i < Length; i++)
                {
                    x[i, 0] = (Convert.ToDouble(dataGridView1.Rows[i].Cells[Length + 1].Value));
                }
            }
            catch
            {
                LogOutput("Initial x vector is wrong; 0 values are taken instead");
                for (int i = 0; i < Length; i++)
                {
                    x[i, 0] = 0;
                }
            }
            try
            {
                for (int i = 0; i < Length; i++)
                {
                    b[i, 0] = (Convert.ToDouble(dataGridView1.Rows[i].Cells[Length].Value));
                }
            }
            catch
            {
                LogOutput("B vector is wrong");
                return;
            }
            try
            {
                for (int i = 0; i < Length; i++)
                {
                    for (int j = 0; j < Length; j++)
                    {
                        A[i, j] = (Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value));
                    }
                }
            }
            catch
            {
                LogOutput("A matrix is wrong");
                return;
            }
            DateTime Now = DateTime.Now;
            var temp = Matrixes.Multiply(A, x);
            for (int i = 0; i < Length; i++)
            {
                r[i, 0] = b[i, 0] - temp[i, 0];
            }
            double tau=0;
            double tempDouble = 0;
            temp = Matrixes.Multiply(A, r);
            for (int i = 0; i < Length; i++)
            {
                tau += r[i, 0] * r[i, 0];
            }
            temp = Matrixes.Multiply(A, r);
            for (int i = 0; i < Length; i++)
            {
                tempDouble += temp[i, 0] * r[i, 0];
            }
            tau /= -tempDouble;
            for (int i = 0; i < Length; i++)
            {
                x[i,0] = x[i,0] - tau * r[i,0];
            }
            temp = Matrixes.Multiply(A, x);
            for (int i = 0; i < Length; i++)
            {
                r[i, 0] = b[i, 0] - temp[i, 0];
            }
            while (!Less(epsiolon, r))
            {
                tau = 0;
                tempDouble = 0;
                temp = Matrixes.Multiply(A, r);
                for (int i = 0; i < Length; i++)
                {
                    tau += r[i, 0] * r[i, 0];
                }
                temp = Matrixes.Multiply(A, r);
                for (int i = 0; i < Length; i++)
                {
                    tempDouble += temp[i, 0] * r[i, 0];
                }
                tau /= -tempDouble;
                for (int i = 0; i < Length; i++)
                {
                    x[i, 0] = x[i, 0] - tau * r[i, 0];
                }
                temp = Matrixes.Multiply(A, x);
                for (int i = 0; i < Length; i++)
                {
                    r[i, 0] = b[i, 0] - temp[i, 0];
                }
            }
            for (int i = 0; i < Length; i++)
            {
                dataGridView1.Rows[i].Cells[Length + 2].Value = x[i, 0];
            }
            LogOutput("Time of work =" + (DateTime.Now - Now).TotalMilliseconds / 1000 + "s");
        }

        double Scalar(List<double> a, List<double> b)
        {
            double result = 0;
            for (int i = 0; i < a.Count; i++)
            {
                result += a[i] * b[i];
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Lab lol = new Lab();
            Application.Run(lol);
        }
    }
}
