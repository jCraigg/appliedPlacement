﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppliedSysMotors
{
    public partial class Driver_Details : Form
    {
        public Driver_Details()
        {
            InitializeComponent();
            
        }


        //set the Global position to the index from the dropdown and retrieves the driver's claim details using the position in the array of drivers
        private void btnAddClaim_Click(object sender, EventArgs e)
        {
            
            if(ddlDrivers.SelectedIndex != -1)
            {
                Global.position = ddlDrivers.SelectedIndex;
                AddClaims addClaim = new AddClaims();
                addClaim.Show();
                this.Close();
            }
            
        }

        private void Driver_Details_Load(object sender, EventArgs e)
        {
            ddlDrivers.Items.Clear();
            String occ;
            
            /*using the same technique by looping through the driver array
             * ensures the driver at the index does not equal null before continuing
             * it populates its respected label using accessors
             */
            
            for (int index=0; index<Global.newPolicy.getDriverArray().Length; index++)
            {
                if (Global.newPolicy.getDriverAt(index) != null)
                {
                    if (Global.newPolicy.getDriverAt(index).getOcc() == true)
                    {
                        occ = "Accountant";
                    }
                    else
                    {
                        occ = "Chauffeur";
                    }
                    ddlDrivers.Items.Add(Global.newPolicy.getDriverName(index));
                    switch (index)
                    {
                        case 0:
                            lblDriver1Details.Text = Global.newPolicy.getDriverName(0);
                            lblClaim1.Text = Global.newPolicy.getDriverAt(0).getNumOfClaims().ToString();
                            lblAge1.Text= Global.newPolicy.getDriverAt(0).getAge().ToString();
                            lblOcc1.Text = occ;
                            break;
                        case 1:
                            lblDriver2Details.Text = Global.newPolicy.getDriverName(1);
                            lblClaim2.Text = Global.newPolicy.getDriverAt(1).getNumOfClaims().ToString();
                            lblAge2.Text = Global.newPolicy.getDriverAt(1).getAge().ToString();
                            lblOcc2.Text = occ;
                            break;
                        case 2:
                            lblDriver3Details.Text = Global.newPolicy.getDriverName(2);
                            lblClaim3.Text = Global.newPolicy.getDriverAt(2).getNumOfClaims().ToString();
                            lblAge3.Text = Global.newPolicy.getDriverAt(2).getAge().ToString();
                            lblOcc3.Text = occ;
                            break;
                        case 3:
                            lblDriver4Details.Text = Global.newPolicy.getDriverName(3);
                            lblClaim4.Text = Global.newPolicy.getDriverAt(3).getNumOfClaims().ToString();
                            lblAge4.Text = Global.newPolicy.getDriverAt(3).getAge().ToString();
                            lblOcc4.Text = occ;
                            break;
                        case 4:
                            lblDriver5Details.Text = Global.newPolicy.getDriverName(4);
                            lblClaim5.Text = Global.newPolicy.getDriverAt(4).getNumOfClaims().ToString();
                            lblAge5.Text = Global.newPolicy.getDriverAt(4).getAge().ToString();
                            lblOcc5.Text = occ;
                            break;
                    }
                        


                 }
                
            }
        }

        private void btnViewClaims_Click(object sender, EventArgs e)
        {
            //validation to ensure a driver is selected
            //will open requested driver's claim details
            if(Global.position == -1)
            {
                MessageBox.Show("Please Select a owner of claims you wish view");
            }
            else
            {
                
                ViewClaims viewClaims = new ViewClaims();
                viewClaims.Show();
                this.Close();
            }
            
        }


    }
}
