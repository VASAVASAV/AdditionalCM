using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private Button button3;
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
            this.button3 = new System.Windows.Forms.Button();
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
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(480, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(215, 40);
            this.button3.TabIndex = 6;
            this.button3.Text = "Розв\'язати обома методами і порівняти";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Lab
            // 
            this.ClientSize = new System.Drawing.Size(1025, 465);
            this.Controls.Add(this.button3);
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
            if (!(Length > 30 || Length < 1))
            {
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
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].HeaderText = "x";
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].Width = 75;
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].HeaderText = "x0(опціонально)";
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].Width = 100;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
                if (("" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value).Contains("-"))
                {
                    LogOutput("Підтримуються лише додатні значення");
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    return;
                }
                dataGridView1.Rows[e.ColumnIndex].Cells[e.RowIndex].Value = "" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            }
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
