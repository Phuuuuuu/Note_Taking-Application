using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Note_Taking_Application
{
    public partial class NoteTaker : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;
     

        public NoteTaker()
        {
            InitializeComponent();
        }
        

        //private void Form1_Load(object sender, EventArgs e )
        //{
        //    notes.Columns.Add("Title");
        //    notes.Columns.Add("Notes");

        //    dataGridView1.DataSource = notes;

        //}
        private void NoteTaker_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Notes");

            dataGridView1.DataSource = notes;
        }
        private void Load_Click(object sender, EventArgs e)
        {
            titleBox.Text = notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            titleBox.Text = "";
            noteBox.Text = "";
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[dataGridView1.CurrentCell.RowIndex].Delete();
                
            } 
            catch (Exception) { Console.WriteLine("Not avalid note"); }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                notes.Rows[dataGridView1.CurrentCell.RowIndex]["Title"] = titleBox.Text;
                notes.Rows[dataGridView1.CurrentCell.RowIndex]["Notes"] = noteBox.Text;
            } else
            {
                notes.Rows.Add(titleBox.Text, noteBox.Text);
            }
            titleBox.Text = "";
            noteBox.Text = "";
            editing = false;
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            titleBox.Text = notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        
    }
}
