using Autodesk.Revit.UI;
using FabPro.Shared.Interfaces;

namespace mertens3d.FabProAddOn.v2019.Models
{
    public class VerSpecV2019 : IVerSpec
    {
        private ExternalCommandData externalCommandData { get; set; }

        public VerSpecV2019(ExternalCommandData externalCommandData)
        {
            this.externalCommandData = externalCommandData;
        }

        public string RevitVersionStr { get; set; } = "2019";
    }
}