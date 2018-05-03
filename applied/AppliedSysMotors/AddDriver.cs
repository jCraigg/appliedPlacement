﻿using AppliedSysMotors.App_Code.BLL;
using System;
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
    public partial class AddDriver : Form
    {
        Boolean occAccountant;
        public AddDriver()
        {   //As the youngest age to drive is 17 the max date means the user can be no younger than 17
            InitializeComponent();
            dtpBirthdate.MaxDate = new DateTime(2000, 01, 01);
            
        }

        private void btnAddDriver_Click(object sender, EventArgs e)
        {
            //prevents the user to add drivers if the array is full
            if (Global.newPolicy.getPosition() == 5)
            {
                MessageBox.Show("Policy has reached driver limit");
            }
            else
            {   //ensures the user has entered all details for the driver before creating one
                if ((txtForename.Text == String.Empty || txtSurname.Text == String.Empty)||(chkAccountant.Checked==false && chkChauffeur.Checked==false))
                {

                    MessageBox.Show("Please enter all details");
                }
                else
                {   //if the driver array is null the values are passed through to the constructor in the driver class and is created
                    if (Global.newPolicy.getDriverAt(Global.newPolicy.getPosition()) == null)
                    {
                        App_Code.BLL.Driver newDriver = new App_Code.BLL.Driver(txtForename.Text, txtSurname.Text,
                                                Convert.ToDateTime(dtpBirthdate.Text), occAccountant, DateTime.Today);
                        //when a driver is created it is compared to various variables which will apply when calculating premium
                        Global.newPolicy.addToArray(newDriver);
                        if (Global.newPolicy.getYoungestDriver() ==null)
                        {
                            Global.newPolicy.setYoungestDriver(newDriver);
                        }
                        else if(newDriver.getAge() < Global.newPolicy.getYoungestDriverAge())
                        {
                            Global.newPolicy.setYoungestDriver(newDriver);
                        }
                        if (Global.newPolicy.getOldestDriver() == null)
                        {
                            Global.newPolicy.setOldestDriver(newDriver);
                        }
                        else if (newDriver.getAge() > Global.newPolicy.getOldestDriverAge())
                        {
                            Global.newPolicy.setOldestDriver(newDriver);
                        }
                        lblOutput.Text = "Driver added ";
                        txtForename.Text = "";
                        txtSurname.Text = "";
                    }
                    else
                    {
                        lblOutput.Text = "Policy has too many Drivers";
                    }
                }
                
            }
            
            
                
            
            
        }

        private void btnViewDrivers_Click(object sender, EventArgs e)
        {
            this.Close();
            Driver_Details newD = new Driver_Details();
            newD.ShowDialog();
            
        }

        private void chkAccountant_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAccountant.Checked == true)
            {
                chkChauffeur.Checked = false;
                occAccountant = true;
            }
            
        }

        private void chkChauffeur_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChauffeur.Checked == true)
            {
                chkAccountant.Checked = false;
                occAccountant = false;
            }
        }


    }
}
