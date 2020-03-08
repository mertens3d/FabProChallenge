using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FabProChallenge.RevitInterface.vAll.Utilities;
using mertens3d.FabProChallenge.Shared.Interfaces;
using System.Collections.Generic;

namespace mertens3d.FabProChallenge.AddOn.v2019.Models
{
    internal class RevitDocState2019
    {
        private ExternalCommandData externalCommandData;

        public RevitDocState2019(ExternalCommandData externalCommandData)
        {
            this.externalCommandData = externalCommandData;
        }

        public UIDocument ActiveUiDoc { get { return externalCommandData.Application.ActiveUIDocument; } }
        public Document ActiveDoc { get { return ActiveUiDoc.Document; } }
        public View ActiveView { get { return ActiveDoc.ActiveView; } }

       
    }
}