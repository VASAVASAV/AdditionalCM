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
        private DataGridView dataGridView2;
        private Label label3;
        private Button button2;
        private DataGridView dataGridView1;
        private bool MatrixExist = false;
        private double[,] InverseMatrix;
        private double[,] NewMatrix;

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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
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
            this.dataGridView1.Size = new System.Drawing.Size(775, 257);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(793, 15);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(220, 568);
            this.textBox2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "Розв\'язати першу систему";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 326);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(775, 257);
            this.dataGridView2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Result";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(337, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 40);
            this.button2.TabIndex = 11;
            this.button2.Text = "Розв\'язати другу систему";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Lab
            // 
            this.ClientSize = new System.Drawing.Size(1031, 603);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Lab";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
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
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].HeaderText = "x";
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Width = 75;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].HeaderText = "b";
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Width = 100;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].HeaderText = "u";
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Width = 75;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].HeaderText = "v";
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Width = 75;
        }

        



        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MatrixExist = false;
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
            }

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
            double[,] x = new double[Length, 1];
            double[,] u = new double[Length, 1];
            double[,] v = new double[Length, 1];
            double[,] b = new double[Length, 1];
            double[,] A = new double[Length, Length];
            try
            {
                for (int i = 0; i < Length; i++)
                {
                    x[i, 0] = (Convert.ToDouble(dataGridView1.Rows[i].Cells[Length].Value));
                }
            }
            catch
            {
                LogOutput("Initial x vector is wrong;");
                return;
            }
            try
            {
                for (int i = 0; i < Length; i++)
                {
                    b[i, 0] = (Convert.ToDouble(dataGridView1.Rows[i].Cells[Length + 1].Value));
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
            try
            {
                for (int i = 0; i < Length; i++)
                {
                    u[i, 0] = (Convert.ToDouble(dataGridView1.Rows[i].Cells[Length + 2].Value));
                }
            }
            catch
            {
                LogOutput("U vector is wrong");
                return;
            }
            try
            {
                for (int i = 0; i < Length; i++)
                {
                    v[i, 0] = (Convert.ToDouble(dataGridView1.Rows[i].Cells[Length + 3].Value));
                }
            }
            catch
            {
                LogOutput("V vector is wrong");
                return;
            }
            DateTime Now = DateTime.Now;
            InverseMatrix = Matrixes.GetReverse(A,Length);
            var res = Matrixes.Multiply(InverseMatrix, b);
            for (int i = 0; i < Length; i++)
            {
                dataGridView1.Rows[i].Cells[Length].Value = res[i, 0];
            }
            var UV = Matrixes.Multiply(u, Matrixes.GetTransp(v,Length,1));
            MatrixExist = true;
            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();
            for (int i = 0; i < Length; i++)
            {
                dataGridView2.Columns.Add(new DataGridViewTextBoxColumn());
            }
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn());
            for (int i = 0; i < Length; i++)
            {
                dataGridView2.Rows.Add();
            }
            NewMatrix = new double[3, 3];
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = (NewMatrix[i,j] = A[i,j] - UV[i,j]);
                }
                dataGridView2.Rows[i].Cells[Length + 1].Value = b[i, 0];
            }
            LogOutput("Time of work =" + (DateTime.Now - Now).TotalMilliseconds / 1000 + "s");
            MatrixExist = true;
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
            if (!MatrixExist)
            {
                LogOutput("You need to precompute inverte matrix");
                return;
            }
            double[,] x = new double[Length, 1];
            double[,] u = new double[Length, 1];
            double[,] v = new double[Length, 1];
            double[,] z = new double[Length, 1];
            double[,] y = new double[Length, 1];
            double[,] b = new double[Length, 1];
            double[,] A = new double[Length, Length];
            try
            {
                for (int i = 0; i < Length; i++)
                {
                    x[i, 0] = (Convert.ToDouble(dataGridView1.Rows[i].Cells[Length].Value));
                }
            }
            catch
            {
                LogOutput("Initial x vector is wrong;");
                return;
            }
            try
            {
                for (int i = 0; i < Length; i++)
                {
                    b[i, 0] = (Convert.ToDouble(dataGridView1.Rows[i].Cells[Length + 1].Value));
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
            try
            {
                for (int i = 0; i < Length; i++)
                {
                    u[i, 0] = (Convert.ToDouble(dataGridView1.Rows[i].Cells[Length + 2].Value));
                }
            }
            catch
            {
                LogOutput("U vector is wrong");
                return;
            }
            try
            {
                for (int i = 0; i < Length; i++)
                {
                    v[i, 0] = (Convert.ToDouble(dataGridView1.Rows[i].Cells[Length + 3].Value));
                }
            }
            catch
            {
                LogOutput("V vector is wrong");
                return;
            }
            DateTime Now = DateTime.Now;
            var UV = Matrixes.Multiply(u, Matrixes.GetTransp(v, Length, 1));
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    NewMatrix[i, j] = A[i, j] - UV[i, j];
                }
            }
            z = Matrixes.GetTransp(Matrixes.Multiply(Matrixes.GetTransp(v,Length,1),InverseMatrix),1,Length);
            y = Matrixes.Multiply(InverseMatrix,u);
            double alfa = 1d / (1 - Matrixes.Multiply(Matrixes.GetTransp(v, Length, 1), y)[0,0]);
            double beta = Matrixes.Multiply(Matrixes.GetTransp(z, Length, 1), b)[0, 0];
            for (int i = 0; i < Length; i++)
            {
                x[i, 0] = x[i, 0] + alfa * beta * y[i, 0];
            }
            for (int i = 0; i < Length; i++)
            {
                dataGridView2.Rows[i].Cells[Length].Value = x[i, 0];
            }
            LogOutput("Time of work =" + (DateTime.Now - Now).TotalMilliseconds / 1000 + "s");
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
