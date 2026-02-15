/**
 * Angel Parada
 * CPT-205-A80H
 * Lab 3
 * States Database
 * 
 * This application displays a list of US State details. Provides a quick navigation list box and a detail view.
 */
using System;
using System.Data;
using System.Windows.Forms;


namespace AParada_Lab_3
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }
        //generated database connections
        private void statesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.statesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.statesDBDataSet);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //populate data grid with data on init
            this.statesTableAdapter.Fill(this.statesDBDataSet.States);
            //get list of names and populate the list box
            foreach (DataRow row in this.statesDBDataSet.States.Rows)
            {
                LBStateNames.Items.Add(row["Name"].ToString());
            }

        }

        //Trigger data grid filter for selected state name
        private void BtnGoTo_Click(object sender, EventArgs e)
        {
            //get selected state in list box
            String selectedState = LBStateNames.Text;
            //query and populate data grid
            this.statesTableAdapter.FillSelectedStateByName(this.statesDBDataSet.States, selectedState);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            //close application
            this.Close();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            //reset the data grid to all rows (default view)
            this.statesTableAdapter.Fill(this.statesDBDataSet.States);
        }
        //Display a pop up window with a complete view of the state data
        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            //get DetailForm
            DetailForm frm = new DetailForm();
            //get selected State from list box
            String selectedState = LBStateNames.Text;
            //ensure something is seleted or else notify to make selection
            if (LBStateNames.SelectedItems.Count == 0)
            {
                MessageBox.Show("You must select a state from the list");
            }
            else
            {
                //set StateName to the selected state to use for display and queries
                frm.StateName = selectedState;
                //show DetailForm
                frm.ShowDialog();
            }

        }
    }
}
