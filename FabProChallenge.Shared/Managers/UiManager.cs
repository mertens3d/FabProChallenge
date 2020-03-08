using FabPro.Shared.Managers;
using FabPro.Shared.Views;
using mertens3d.FabProChallenge.Shared.Models;
using System;

namespace mertens3d.FabPro.Shared.Managers
{
    public class UiManager : ManagerBase
    {
        public UiManager(ManagerHub hub) : base(hub)
        {
        }

        internal EffortResult ShowMenu()
        {
            var toReturn = new EffortResult();

            try
            {
                var mainMenu = new MainControl();
                mainMenu.InitializeForm(Hub);
                mainMenu.ShowDialog();
            }
            catch (Exception ex)
            {
                toReturn.MarkFailed(ex.ToString());
            }

            return toReturn;
        }
    }
}