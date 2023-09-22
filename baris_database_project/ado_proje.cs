using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baris_database_project
{
    public partial class ado_proje : Form
    {
        public static ado_proje instance;
        public DataGridView dview;
        private db databs ;
        
        public ado_proje()
        {
            InitializeComponent();
            instance = this;
            dview = dataGridView1;
            databs = new db();
        }

        private void ado_proje_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            databs.getdata("select * from Person.Person",dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ado_proje_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                data_form data_Form = new data_form();
                DataGridViewRow  selectedRow = dataGridView1.Rows[e.RowIndex];
                
                data_Form.setdata(selectedRow,e.RowIndex);


                
                this.Hide();

                data_Form.ShowDialog();
                
                databs.getdata("select * from Person.Person", dataGridView1);
                this.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            data_form data_Form = new data_form();

            this.Hide();

            data_Form.ShowDialog();

            this.Show();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sq = "select * from Person.Person where BusinessEntityID=" + textBox1.Text;
            textBox1.Text = "";
            databs.getperson(sq,dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sq = "delete from Person.BusinessEntity where BusinessEntityID = @bid;" +
                "delete from Person.EmailAddress where BusinessEntityID = @eid; delete from Person.Person where BusinessEntityID=@id";
            databs.deletedata(sq, textBox1.Text);
            databs.getdata("select * from Person.Person", dataGridView1);
            textBox1.Text = "";
        }
    }
}
