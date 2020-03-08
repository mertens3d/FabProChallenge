using Autodesk.Revit.UI;
using FabPro.Shared.Interfaces;
using FabProChallenge.RevitInterface.vAll.Model;

namespace FabProChallenge.RevitInterface.vAll
{
    public class RevitCrudHub
    {
        private RevitRead _revitRead;
        private RevitUpdate _revitUpdate;
        private RevitCreate _revitCreate;
        private RevitDelete _revitDelete;

        internal RevitRead RevitRead
        {
            get { return _revitRead ?? (_revitRead = new RevitRead(this)); }
        }

        internal RevitCreate RevitCreate
        {
            get { return _revitCreate ?? (_revitCreate = new RevitCreate(this)); }
        }

        internal RevitUpdate RevitUpdate
        {
            get { return _revitUpdate ?? (_revitUpdate = new RevitUpdate(this)); }
        }

        internal RevitDelete RevitDelete
        {
            get { return _revitDelete ?? (_revitDelete = new RevitDelete(this)); }
        }

        public ExternalCommandData ExternalCommandData { get; internal set; }

        public IRevitCRUDVSpec RevitCrudVerSpec { get; set; }


        public RevitCrudHub(ExternalCommandData ExternalCommandData, IRevitCRUDVSpec revitCrudVerSpec)
        {
            this.ExternalCommandData = ExternalCommandData;
            this.RevitCrudVerSpec = revitCrudVerSpec;

        }
    }
}