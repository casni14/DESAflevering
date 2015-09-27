﻿using AdminGUI.Facade;
using System;
using System.Collections.Generic;
using System.Windows;

namespace AdminGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DomainFacade df;

        public MainWindow()
        {
            InitializeComponent();
            df = new DomainFacade();
            UpdateListView();
        }

        public void UpdateListView()
        {
            lstCourses.Items.Clear();
            foreach (int i in df.GetListOfCourseId())
            {
                List<string> courseInfo = df.GetCourseInfo(i);
                lstCourses.Items.Add(courseInfo);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                df.CreateCourse(txbName.Text, cmbInstance.SelectedIndex + 1, Int32.Parse(txbInstanceYear.Text), txbDescription.Text, Int32.Parse(txbEcts.Text));
                UpdateListView();
            }
            catch (FormatException)
            {
                MessageBox.Show("Some of the filled textfield doesn't match the required input. Please fill out form correctly.");
            }
        }
    }
}
