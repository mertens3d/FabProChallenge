using FabPro.Shared.Managers;
using System.Windows;

namespace FabPro.Shared.Views
{
    /// <summary>
    /// Interaction logic for MainControl.xaml
    /// </summary>
    public partial class MainControl : Window
    {
        internal ManagerHub Hub { get { return DataContext as ManagerHub; } }

        public MainControl()
        {
            InitializeComponent();
        }

        private void IdCreateAssemblyElem_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventManager.OnRequestTriggerCreate3DView();
            }
        }

        private void IdCreateAssemblySheet_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventManager.OnRequestTriggerCreateAssemblySheet();
            }
        }

        private void IdCreate3DView_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventManager.OnRequestTriggerCreate3DView();
            }
        }

        private void IdPlace3DViewOnSheet_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventManager.OnRequestPlaceOnSheet();
            }

        }

        private void IdAddMarkTags_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventManager.OnRequestTriggerCreate3DView();
            }
        }

        private void IdCreateTopView_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventManager.OnRequestTriggerCreate3DView();
            }
        }

        private void IdCreateFrontView_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventManager.OnRequestTriggerCreate3DView();
            }
        }

        private void IdDimensionTopandFrontViews_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventManager.OnRequestTriggerCreate3DView();
            }
        }

        private void IdCreateBillOfMaterialsSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (Hub != null)
            {
                Hub.EventManager.OnRequestTriggerCreate3DView();
            }
        }
    }
}