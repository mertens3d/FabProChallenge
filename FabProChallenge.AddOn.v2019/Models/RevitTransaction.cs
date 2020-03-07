using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using mertens3d.FabProChallenge.Shared.Interfaces;

namespace mertens3d.FabProChallenge.AddOn.v2019.Models
{
    public class Revitv2019Transaction : IRevitTransaction
    {
        public Revitv2019Transaction(ExternalCommandData externalCommandData, string title)
        {
            CurrentTransaction = new Transaction(externalCommandData.Application.ActiveUIDocument.Document, title);
        }

        public Transaction CurrentTransaction { get; set; }
        public string CurrentError { get;  set; }

        public void Commit()
        {
            try
            {
                CurrentTransaction.Commit();
            }
            catch (System.Exception ex)
            {
                CurrentError = ex.ToString();
            }
        }

        public void Dispose()
        {
            if (CurrentTransaction != null)
            {
                CurrentTransaction.Dispose();
            }
        }

        public void RollBack()
        {
            if (CurrentTransaction != null)
            {
                CurrentTransaction.RollBack();
            }
        }

        public void Start()
        {
            if (CurrentTransaction != null)
            {
                CurrentTransaction.Start();
            }
        }
    }
}