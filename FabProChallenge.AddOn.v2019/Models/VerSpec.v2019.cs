using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FabPro.Shared.Interfaces;
using mertens3d.FabProChallenge.AddOn.v2019.Models;
using mertens3d.FabProChallenge.Shared.Interfaces;
using System;
using System.Linq;

namespace mertens3d.FabProAddOn.v2019.Models
{
    public class VerSpecV2019 : IVerSpec
    {
        private object _translatorReal;

        private ExternalCommandData externalCommandData { get; set; }

        public Document ActiveDoc { get { return externalCommandData.Application.ActiveUIDocument.Document; } }

        public VerSpecV2019(ExternalCommandData externalCommandData)
        {
            this.externalCommandData = externalCommandData;
        }

        public string RevitVersionStr { get; set; } = "2019";

        public IRevitTransaction FactoryTransaction(string transactionSuffix, bool useUiDoc)
        {
            IRevitTransaction toReturn = null;

            if (externalCommandData != null)
            {
                toReturn = new Revitv2019Transaction(externalCommandData, transactionSuffix);
            }

            return toReturn;
        }

        public bool Create3DView(string viewName)
        {
            bool toReturn = false;
            
            
            ViewFamilyType viewType = new FilteredElementCollector(externalCommandData.Application.ActiveUIDocument.Document)
                .OfClass(typeof(ViewFamilyType))
                .Cast<ViewFamilyType>()
                .FirstOrDefault(x => x.ViewFamily == ViewFamily.ThreeDimensional);

            if (viewType != null)
            {
                View3D view3D = View3D.CreateIsometric(ActiveDoc, viewType.Id);

                view3D.Name = viewName;

                toReturn = true;
            }

            return toReturn;
        }
    }
}