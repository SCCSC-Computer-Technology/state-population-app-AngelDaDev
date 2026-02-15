using System;
using System.Data;
using System.Windows.Forms;

namespace AParada_Lab_3
{

    public partial class DetailForm : Form
    {
        //set from the MainForm
        public String StateName { get; set; }

        public DetailForm()
        {
            InitializeComponent();
        }

        private void DetailForm_Load(object sender, EventArgs e)
        {
            //set main label
            LblName.Text = StateName;
            
            //get the rest of the state data
            StatesDBDataSetTableAdapters.StatesTableAdapter adapter = new StatesDBDataSetTableAdapters.StatesTableAdapter();
            StatesDBDataSet.StatesDataTable dataTable = adapter.GetSelectedStateByName(StateName);

            //make sure data is available
            if (dataTable != null)
            {
                //get the row data
                DataRow row = dataTable.Rows[0];

                //show the row data
                TxtCapital.Text = row["Capitol"].ToString();
                TxtPopulation.Text = row["Population"].ToString();
                TxtFlag.Text = row["FlagDescription"].ToString();
                TxtFlower.Text = row["Flower"].ToString();
                TxtBird.Text = row["Bird"].ToString();
                TxtColors.Text = row["Colors"].ToString();

                TxtCity1.Text = row["LargeCity1"].ToString();
                TxtCity2.Text = row["LargeCity2"].ToString();
                TxtCity3.Text = row["LargeCity3"].ToString();
                TxtMedian.Text = row["MedianIncome"].ToString();
                TxtJobs.Text = row["ITJobPercentage"].ToString();
            }
        }

        private void BtnClosePopup_Click(object sender, EventArgs e)
        {
            //close pop up
            this.Close();
        }
    }
}
