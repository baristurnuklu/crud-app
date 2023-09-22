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
    public partial class data_form : Form
    {
        private int rindex;
        private int id;
        public Person person;
        private db db;
        public data_form()
        {
            InitializeComponent();
            db = new db();
        }
        
        public void persontext()
        {
            person.PersonType = (textBox1.Text);
            //person.NameStyle = int.Parse(textBox2.Text);
            person.Title = textBox3.Text;

            person.FirstName = textBox4.Text;
            person.MiddleName = textBox5.Text;
            person.LastName = textBox6.Text;

            person.Suffix = textBox7.Text;
            person.EmailPromotion = int.Parse(textBox8.Text);
            //person.AdditionalContactInfo = textBox9.Text;
            //person.Demographics = textBox10.Text;
            person.rowquid = Guid.Parse(textBox11.Text);
            person.ModifiedDate = DateTime.Parse(textBox12.Text);
        }
        

        private void data_form_Load(object sender, EventArgs e)
        {

        }
        public void setdata(DataGridViewRow row, int rowindex)
        {
            
            DataTable dt = new DataTable();
            dt = db.getrow("Select * From Person.Person Where BusinessEntityId=@BusinessEntityId", (int)(row.Cells[0].Value));
            person = new Person();
            person.fillPerson(dt);



            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();

            textBox4.Text = row.Cells[4].Value.ToString();
            textBox5.Text = row.Cells[5].Value.ToString();
            textBox6.Text = row.Cells[6].Value.ToString();

            textBox7.Text = row.Cells[7].Value.ToString();
            textBox8.Text = row.Cells[8].Value.ToString();
            textBox9.Text = row.Cells[9].Value.ToString();

            textBox10.Text = row.Cells[10].Value.ToString();
            textBox11.Text = row.Cells[11].Value.ToString();
            textBox12.Text = row.Cells[12].Value.ToString();

            rindex = rowindex;
            


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string sq = "update Person.Person Set " + /*"PersonType=@PersonType,*/  
                //"NameStyle=@NameStyle, " +
                //"Title=@Title, " +
                "FirstName = @FirstName, " +
                "MiddleName=@MiddleName, " +
                "LastName=@LastName " +
                //"Suffix=@Suffix, " +
                //"EmailPromotion=@EmailPromotion, " +
                //"AdditionalContactInfo=@AdditionalContactInfo, " +
                //"Demographics=@Demographics, " +
                //"rowquid=@rowquid, " +
                //"ModifiedDate=@ModifiedDate " +
                "where BusinessEntityId=@BusinessEntityId";

            persontext();
            db.update(sq, person, person.BusinessEntityId);
            this.Close();


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string guidString1 = Guid.NewGuid().ToString();
            string guidString2 = Guid.NewGuid().ToString();

            string sq = " insert into Person.BusinessEntity (rowguid,ModifiedDate) values ('"+ guidString1 + "','2013-6-04'); Declare @id INT; Set @id = SCOPE_IDENTITY(); insert into Person.Person (BusinessEntityID,PersonType,NameStyle,FirstName,MiddleName,LastName, EmailPromotion,rowguid,ModifiedDate) values" +
                " (@id ,'EM', '0' , @FirstName, @MiddleName, @LastName,'0','" + guidString2 + "','2022-09-05');";
            db.adddata(sq,textBox4.Text,textBox5.Text,textBox6.Text);
            this.Close();

        }
    }
}
