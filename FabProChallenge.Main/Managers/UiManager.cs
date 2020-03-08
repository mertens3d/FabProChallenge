using FabPro.Shared.Managers;
using FabPro.Shared.Views;
using mertens3d.FabProChallenge.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mertens3d.FabPro.Shared.Managers
{
    public class UiManager : ManagerBase
    {
        public UiManager(ManagerHub hub) : base(hub)
        {
        }

        public List<string> ViewsToShow { get { return Hub.RevitMan.GetAllViews().Select(x => x.ViewFriendly).ToList();  } }

        private MainControl mainMenu { get; set; }

        internal EffortResult ShowMenu()
        {
            var toReturn = new EffortResult();

            try
            {
                mainMenu = new MainControl();
                //mainMenu.Loaded += InitForm;
                mainMenu.InitializeForm(Hub);
                mainMenu.ContentRendered += InitBinding;
                //InitBinding();
                mainMenu.ShowDialog();
            }
            catch (Exception ex)
            {
                toReturn.MarkFailed(ex.ToString());
            }

            return toReturn;
        }

        private void InitBinding(object sender, EventArgs e)
        {
            Hub.BindableData.AllViews = Hub
             .UiMan
             .ViewsToShow;
        }

        private void InitBindinxg()
        {
          
        }

        private void InitForm(object sender, EventArgs e)
        {
        }
    }
}