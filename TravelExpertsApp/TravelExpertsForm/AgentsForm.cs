﻿//Author: Owen Huot
//Date: 14.02.24
//Description: agents form page
//wasn't required of workshop, but there weren't enough tasks to go around otherwise

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelPackageData;
using TravelPackageData.Models;
using TravelPackageGUI;
using TravelExpertsSuppliersDB;

namespace TravelExpertsForm
{
    public partial class AgentsForm : Form
    {
        TravelExpertsContext Context = new();

        //cleans form
        private void CleanForm()
        {
            Context = new();
            radioButton1.Checked = true;
            listBox1.DataSource = Context.Agents.ToList();
        }

        //validates form
        private bool ValidateForm()
        {
            Regex PhoneFilter = new Regex(@"\([0-9]{3}\) [0-9]{3}-[0-9]{4}$");
            Regex EmailFilter = new Regex(@"@travelexperts.com$");

            if (!PhoneFilter.IsMatch(textBox5.Text))
            {
                MessageBox.Show("!!! PHONE MUST BE OF FORM (XXX) XXX-XXXX !!!", "ERROR");
                textBox5.Select();
                return false;
            }

            if (!EmailFilter.IsMatch(textBox6.Text))
            {
                MessageBox.Show("!!! EMAIL MUST BE OF FORM ...@travelexperts.com !!!", "ERROR");
                textBox6.Select();
                return false;
            }

            return true;
        }

        //adds form entry to database
        private void ADD()
        {
            if (!ValidateForm()) { return; }

            Agent Solution = new();

            Solution.AgtFirstName = textBox2.Text;
            Solution.AgtMiddleInitial = textBox3.Text;
            Solution.AgtLastName = textBox4.Text;
            Solution.AgtBusPhone = textBox5.Text;
            Solution.AgtEmail = textBox6.Text;
            Solution.AgtPosition = textBox7.Text;

            Context.Agents.Add(Solution);
            Context.SaveChanges();
            CleanForm();
        }

        //removes form entry from database
        private void RMV()
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("! ! ! NO ITEM SELECTED ! ! !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var Solution = listBox1.SelectedItem as Agent;

            Context.Agents.Remove(Solution);
            Context.SaveChanges();
            CleanForm();
        }

        //updates form entry in dataase
        private void UPD()
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("! ! ! NO ITEM SELECTED ! ! !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateForm()) { return; }

            var Solution = listBox1.SelectedItem as Agent;

            Solution.AgtFirstName = textBox2.Text;
            Solution.AgtMiddleInitial = textBox3.Text;
            Solution.AgtLastName = textBox4.Text;
            Solution.AgtBusPhone = textBox5.Text;
            Solution.AgtEmail = textBox6.Text;
            Solution.AgtPosition = textBox7.Text;

            Context.Agents.Update(Solution);
            Context.SaveChanges();
            CleanForm();
        }

        //class constructor
        public AgentsForm()
        {
            InitializeComponent();
            CleanForm();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Solution = listBox1.SelectedItem as Agent;

            if (radioButton1.Checked)
            {
                textBox1.Text = "AUTOGENERATED";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }
            else
            {
                textBox1.Text = Solution.AgentId.ToString();
                textBox2.Text = Solution.AgtFirstName;
                textBox3.Text = Solution.AgtMiddleInitial;
                textBox4.Text = Solution.AgtLastName;
                textBox5.Text = Solution.AgtBusPhone;
                textBox6.Text = Solution.AgtEmail;
                textBox7.Text = Solution.AgtPosition;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) { ADD(); }
            if (radioButton2.Checked) { RMV(); }
            if (radioButton3.Checked) { UPD(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}