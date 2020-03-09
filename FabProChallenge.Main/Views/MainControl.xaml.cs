using FabPro.Shared.Managers;
using System;
using System.Windows;

namespace FabPro.Shared.Views
{
    /// <summary>
    /// Interaction logic for MainControl.xaml
    /// </summary>
    public partial class MainControl : Window
    {
        internal ManagerHub Hub { get; set; }// { return DataContext as ManagerHub; } }

        internal void InitializeForm(ManagerHub hub)
        {
            Hub = hub;
            DataContext = Hub;
        }

        public MainControl()
        {
            InitializeComponent();
        }

        private void IdCreateAssemblyElem_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventMan.OnRequestTriggerCreateAssemblyElem();
            }
            this.Close();
        }

        private void IdCreateAssemblySheet_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventMan.OnRequestTriggerCreateAssemblySheet();
            }
            this.Close();
        }

        private void IdCreate3DView_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventMan.OnRequestTriggerCreate3DView();
            }

            this.Close();
        }

        private void IdPlaceSelectViewOnActiveSheet_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventMan.OnRequestPlaceSelectViewOnActiveSheet();
            }
            this.Close();
        }

        private void IdAddMarkTags_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventMan.OnRequestTriggerAddMarks();
            }
            this.Close();
        }

        private void IdCreateTopView_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventMan.OnRequestTriggerCreateTopView();
            }

            this.Close();
        }

        private void IdCreateFrontView_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventMan.OnRequestTriggerCreateFrontView();
            }
            this.Close();
        }


        private void IdCreateBillOfMaterialsSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventMan.OnRequestTriggerCreateBOM();
            }
            this.Close();
        }

    }
}