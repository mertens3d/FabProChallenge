﻿using mertens3d.FabProChallenge.Shared.Interfaces;
using System.Collections.Generic;

namespace mertens3d.FabProChallenge.Shared.Models
{
    public class FpDocState
    {
        public List<FpView> ElegibleViews { get; } = new List<FpView>();
    }
}