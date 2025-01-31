﻿using FabPro.Shared.Managers;
using FabPro.Shared.Views;
using mertens3d.FabProChallenge.Shared.Interfaces;
using mertens3d.FabProChallenge.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mertens3d.FabPro.Shared.Managers
{
    public class UiManager : ManagerBase
    {
        private List<FpView> _viewsToShow;

        public UiManager(ManagerHub hub) : base(hub)
        {
        }

        public List<FpView> ViewsToShow { get { return _viewsToShow ?? (_viewsToShow = Hub.RevitMan.GetAllEligibleViews()); } }

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
                toReturn.MarkSuccessful();
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
             .ViewsToShow
              .Select(x => x.ViewNameForDialog)
              .ToList();
        }

        private void InitForm(object sender, EventArgs e)
        {
        }

        internal FpView CurrentSelectViewId()
        {
            FpView toReturn = null;

            var selectIndex = Hub.BindableData.AllViewsSelectedIndex;
            if (ViewsToShow.Any())
            {
                toReturn = ViewsToShow[selectIndex];
            }

            return toReturn;
        }
    }
}