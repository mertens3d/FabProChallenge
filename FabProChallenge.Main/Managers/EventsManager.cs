using FabPro.Shared.Managers;
using System;

namespace mertens3d.FabPro.Shared.Managers
{
    public class EventsManager : ManagerBase
    {
        public EventsManager(ManagerHub hub) : base(hub)
        {
        }

        internal event Action ActionTriggerCreateAssemblyElem;

        internal event Action ActionTriggerCreateAssemblySheet;

        internal event Action ActionTriggerPlaceSelectViewOnSheet;

        internal event Action ActionTriggerCreateBOM;

        internal event Action ActionTriggerCreateFrontView;

        internal event Action ActionTriggerCreateTopView;

        internal event Action ActionTriggerCreate3DView;

        internal event Action ActionTriggerAddMarks;

        protected internal virtual void OnRequestTriggerCreate3DView()
        {
            if (ActionTriggerCreate3DView != null)
            {
                ActionTriggerCreate3DView.Invoke();
            }
        }

        internal void OnRequestTriggerCreateAssemblyElem()
        {
            if (ActionTriggerCreateAssemblyElem != null)
            {
                ActionTriggerCreateAssemblyElem.Invoke();
            }
        }

        internal void OnRequestTriggerCreateAssemblySheet()
        {
            if (ActionTriggerCreateAssemblySheet != null)
            {
                ActionTriggerCreateAssemblySheet.Invoke();
            }
        }

        internal void OnRequestPlaceSelectViewOnActiveSheet()
        {
            if (ActionTriggerPlaceSelectViewOnSheet != null)
            {
                ActionTriggerPlaceSelectViewOnSheet.Invoke();
            }
        }

        internal void OnRequestTriggerCreateBOM()
        {
            if (ActionTriggerCreateBOM != null)
            {
                ActionTriggerCreateBOM.Invoke();
            }
        }

        internal void OnRequestTriggerCreateFrontView()
        {
            if (ActionTriggerCreateFrontView != null)
            {
                ActionTriggerCreateFrontView.Invoke();
            }
        }

        internal void OnRequestTriggerCreateTopView()
        {
            if (ActionTriggerCreateTopView != null)
            {
                ActionTriggerCreateTopView.Invoke();
            }
        }

        internal void OnRequestTriggerAddMarks()
        {
            if (ActionTriggerAddMarks != null)
            {
                ActionTriggerAddMarks.Invoke();
            }
        }
    }
}