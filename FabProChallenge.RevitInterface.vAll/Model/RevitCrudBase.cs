using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace FabProChallenge.RevitInterface.vAll.Model
{
    internal abstract class RevitCrudBase
    {
        protected RevitCrudHub CrudHub;
        protected UIDocument ActiveUiDoc { get { return ExternalCommandData.Application.ActiveUIDocument; } }
        protected Document ActiveDoc { get { return ActiveUiDoc.Document; } }
        protected View ActiveView { get { return ActiveDoc.ActiveView; } }

        public ExternalCommandData ExternalCommandData { get; private set; }

        protected RevitCrudBase(RevitCrudHub crudHub)
        {
            this.CrudHub = crudHub;
            this.ExternalCommandData = crudHub.ExternalCommandData;
        }
    }
}