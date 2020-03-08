using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FabProChallenge.RevitInterface.vAll.Utilities;
using mertens3d.FabProChallenge.Shared.Interfaces;
using System.Collections.Generic;

namespace mertens3d.FabProChallenge.AddOn.v2019.Models
{
    internal class RevitDocState2019 : IRevitDocState
    {
        private ExternalCommandData externalCommandData;

        public RevitDocState2019(ExternalCommandData externalCommandData)
        {
            this.externalCommandData = externalCommandData;
        }

        public UIDocument ActiveUiDoc { get { return externalCommandData.Application.ActiveUIDocument; } }
        public Document ActiveDoc { get { return ActiveUiDoc.Document; } }
        public View ActiveView { get { return ActiveDoc.ActiveView; } }

        public List<FpView> Views
        {
            get
            {
                List<FpView> toReturn = new List<FpView>();

                var allViews = RevitUtilitiesVAll.GetAllViewsInDoc(ActiveDoc);

                return toReturn;
            }
        }

        public FpDocState FabProDocState
        {
            get
            {
                var toReturn = new FpDocState();

                RevitUtilitiesVAll.GetAllViewsInDoc(ActiveDoc)
                    .ForEach(x => toReturn.Views.Add(new FpView(x.Id.IntegerValue, x.Name, (Shared.Enums.FpViewTypes)x.ViewType)));

                return toReturn;
            }
        }
    }
}