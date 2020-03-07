using FabPro.Shared.Managers;
using FabPro.Shared.Views;
using mertens3d.FabPro.Shared.Models;
using System;

namespace mertens3d.FabPro.Shared.Managers
{
    public class UiManager : ManagerBase
    {
        public UiManager(ManagerHub hub): base(hub)
        {

        }

        internal AddOnResult ShowMenu()
        {

            var toReturn = new AddOnResult();

            try
            {
                var mainMenu = new MainControl();
                mainMenu.InitializeForm(Hub);
                mainMenu.ShowDialog();
            }
            catch (Exception ex)
            {

                toReturn.Errors.Add(ex.ToString());
            }

            return toReturn;

        }
    }
}