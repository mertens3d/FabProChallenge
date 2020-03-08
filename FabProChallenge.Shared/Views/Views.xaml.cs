using FabPro.Shared.Managers;
using System;
using System.Windows.Controls;

namespace mertens3d.FabProChallenge.Shared.Views
{
    /// <summary>
    /// Interaction logic for Views.xaml
    /// </summary>
    public partial class Views : UserControl
    {

        private ManagerHub Hub { get{return DataContext as ManagerHub; } }

        public Views()
        {
            Init();
        }

        internal void InitCtrl()
        {
           if(Hub != null)
            {


                this.idViews.ItemsSource = Hub.VerSpec.DocState.FabProDocState.Views;
            }
        }
    }
}