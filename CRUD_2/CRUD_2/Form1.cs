using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_2
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
           
        }
        CRUD_2Entities db = new CRUD_2Entities();
        BooksTable BookTable1 = new BooksTable();
        
    private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {
            string BookNameData = txtBoxBookName.Text;
            string ISBNData = txtBoxISBN.Text;
            string AuthorData = txtBoxAuthor.Text;
            string CategoryData = CMBBOXCatID.Text;
            CMBBOXCatID.Text = "";
         



            if (string.IsNullOrEmpty(BookNameData) || string.IsNullOrEmpty(ISBNData) || string.IsNullOrEmpty(AuthorData))
            {
                MessageBox.Show("Bos Buraxma!!!");
            }
            else
            {
                BookTable1.BookName = BookNameData;
                BookTable1.ISBN = Convert.ToInt32(ISBNData);
                BookTable1.Author = AuthorData;
                BookTable1.CategoryID = db.CategoryTables.Where(x=> x.CategoryName == CMBBOXCatID.SelectedItem.ToString()).First().id;
                db.BooksTables.Add(BookTable1);


                
                db.SaveChanges();
                txtBoxAuthor.Clear();
                txtBoxBookName.Clear();
                txtBoxISBN.Clear();
      

            }
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            CategoryTable CategoryTable1 = new CategoryTable();
            CategoryTable1.CategoryName = cmBoxCatName.Text;
            cmBoxCatName.Clear();
            db.CategoryTables.Add(CategoryTable1);
            db.SaveChanges();

        }

        private void CMBBOXCatID_Click(object sender, EventArgs e)
        {
            CMBBOXCatID.Items.Clear();
            foreach (var item in db.CategoryTables.ToList())
            {
                CMBBOXCatID.Items.Add(item.CategoryName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.BooksTables.ToList();
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            //BookTable1.CategoryID = db.CategoryTables.Where(x => x.CategoryName == CMBBOXCatID.SelectedItem.ToString()).First().id;
           int setir = Convert.ToInt32(comboBoxSelectedRow.SelectedItem);
            foreach (var item in db.BooksTables)
            {
                if (item.id==setir)
                {
                    db.BooksTables.Remove(item);
                    comboBoxSelectedRow.Items.Remove(comboBoxSelectedRow.SelectedItem);
                    comboBoxSelectedRow.Text = "";
                    
                }
            }
            dataGridView1.DataSource = db.BooksTables.ToList();
            db.SaveChanges();
        }
        //Uptade begin
        private void button2_Click(object sender, EventArgs e)
        {
            BooksTable booktable2 = new BooksTable();
            string bookData1 = txtBoxBookName.Text;
            int ISBNdata1 = Convert.ToInt32(txtBoxISBN.Text);
            string authorDAta1 = txtBoxAuthor.Text;
            string CategoryData1 = CMBBOXCatID.Text;

            int setirUpdated = Convert.ToInt32(comboBoxSelectedRow.SelectedItem);
            foreach (var item in db.BooksTables)
            {
                
                if (item.id == setirUpdated)
                {
                    //db.BooksTables.;
                    //comboBoxSelectedRow.Items.Remove(comboBoxSelectedRow.SelectedItem);
                    //comboBoxSelectedRow.Text = "";
                    
                    item.BookName = bookData1;
                    item.ISBN = ISBNdata1;
                    item.Author = authorDAta1;
                    item.CategoryID = db.CategoryTables.Where(x => x.CategoryName == CMBBOXCatID.SelectedItem.ToString()).First().id;

                    txtBoxAuthor.Clear();
                    txtBoxBookName.Clear();
                    txtBoxISBN.Clear();
                    comboBoxSelectedRow.Text = "";
                    CMBBOXCatID.Text = "";

                   
                }
            }
          
            db.SaveChanges();
        }

        private void comboBoxSelectedRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            
    }

        private void comboBoxSelectedRow_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxSelectedRow_DropDown(object sender, EventArgs e)
        {
            comboBoxSelectedRow.Items.Clear();
            var elements = db.BooksTables.ToList();
            foreach (var item in elements)
            {
                comboBoxSelectedRow.Items.Add(item.id);
            }
        }

        //UPDATE END
    }
}
