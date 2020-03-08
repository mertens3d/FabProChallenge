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
            //if (idCtrlViews != null)
            //{

            //    idCtrlViews.Loaded += InitViews;
                
            //}
        }

        //private void InitViews(object sender, RoutedEventArgs e)
        //{
        //    if(idCtrlViews != null)
        //    {

        //    //this.idCtrlViews.DataContext = Hub;
        //    this.idCtrlViews.InitCtrl();
        //    }
        //}

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

        private void IdPlace3DViewOnSheet_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventMan.OnRequestPlaceOnSheet();
            }
        }

        private void IdAddMarkTags_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventMan.OnRequestTriggerAddMarks();
            }
        }

        private void IdCreateTopView_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventMan.OnRequestTriggerCreateTopView();
            }
        }

        private void IdCreateFrontView_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventMan.OnRequestTriggerCreateFrontView();
            }
        }

        private void IdDimensionTopandFrontViews_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventMan.OnRequestTriggerCreateDimensionTopandFrontViews();
            }
        }

        private void IdCreateBillOfMaterialsSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventMan.OnRequestTriggerCreateBOM();
            }
        }

    }
}