using FabPro.Shared.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace mertens3d.FabProChallenge.Shared.Views
{
    /// <summary>
    /// Interaction logic for Views.xaml
    /// </summary>
    public partial class Views : UserControl
    {
        private ManagerHub Hub { get { return DataContext as ManagerHub; } }

        public Views()
        {
            InitializeComponent();
            //this.Loaded += InitCtrl;
        }


        //public void InitCtrl()
        //{
        //    if (Hub != null)
        //    {
        //        List<string> viewsToShow = Hub
        //            .UiMan
        //            .ViewsToShow;

         

        //            this.idViews.ItemsSource = viewsToShow;
        //    }
        //}
    }
}