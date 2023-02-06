using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Xml;


namespace laba7
{
    public partial class Form1 : Form
    {
        private DAO dao = new DAO();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ReadXml();
            dataGridView1.Columns["Id"].ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

        }

        private void Removee_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int indexRow = dataGridView1.Rows.IndexOf(row);
                int removeId = int.Parse(dataGridView1.Rows[indexRow].Cells[0].Value.ToString());
                dao.Remove(removeId);
                dataGridView1.Rows.Remove(row);
            }
        }

        private void Replace_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Person person = new Person();
                int indexRow = dataGridView1.Rows.IndexOf(row);

                int id = int.Parse(dataGridView1.Rows[indexRow].Cells[0].Value.ToString());
                String name = dataGridView1.Rows[indexRow].Cells[1].Value.ToString();
                int age = int.Parse(dataGridView1.Rows[indexRow].Cells[2].Value.ToString());
                String company = dataGridView1.Rows[indexRow].Cells[3].Value.ToString();

                person.id = id;
                person.name = name;
                person.age = age;
                person.company = company;

                dao.Replace(person);
            }
            MessageBox.Show("XML update processing complete.");
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable("People");

            DataColumn colID = new DataColumn("id", typeof(Int32));
            DataColumn colName = new DataColumn("name", typeof(String));
            DataColumn colAge = new DataColumn("age", typeof(Int32));
            DataColumn colCompany = new DataColumn("company", typeof(String));

            dt.Columns.Add(colID);
            dt.Columns.Add(colName);
            dt.Columns.Add(colAge);
            dt.Columns.Add(colCompany);

            return dt;
        }

        private DataTable ReadXml()
        {
            List<Person> people = dao.FindAll();
            DataTable dt = CreateTable();
            try
            {
                foreach (Person person in people)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["id"] = person.id;
                    newRow["name"] = person.name;
                    newRow["age"] = person.age;
                    newRow["company"] = person.company;
                    dt.Rows.Add(newRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
