using mertens3d.FabProChallenge.Shared.Models;
using System;

namespace mertens3d.FabProChallenge.Shared.Interfaces
{

    public interface IRevitTransaction : IDisposable
    {
        void Commit();

        void Start();

        void RollBack();

        string CurrentError { get; set; }

        void CommitIfSuccess(EffortResult result);
    }
}