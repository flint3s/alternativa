﻿using System.Diagnostics.CodeAnalysis;

namespace Database.Models.RealEstate
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public abstract class AbstractRealEstate : AbstractRoom
    {
        // ReSharper disable once EmptyConstructor
        protected AbstractRealEstate()
        {
        }
        
        public long Cost { get; protected set; } 
        
        public Character Owner { get; protected set; }
    }
}