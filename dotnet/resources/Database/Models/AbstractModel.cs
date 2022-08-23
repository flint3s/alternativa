﻿using System;
using Microsoft.EntityFrameworkCore;

namespace Database.Models
{
    public abstract class AbstractModel
    {
        public DateTime CreatedDate { get; internal set; } = DateTime.Now;

        public DateTime UpdatedDate { get; internal set; } = DateTime.Now;
        
        public virtual void AddToContext()
        {
            lock (ContextSingleton.Instance)
            {
                var context = ContextSingleton.Instance;
                context.Add(this);
                context.SaveChanges();
            }
        }
        
        private protected void UpdateDatabase()
        {
            try
            {
                UpdateInContext();
            }
            catch (DbUpdateException)
            {
                AddToContext();
            }
        }

        private void UpdateInContext()
        {
            lock (ContextSingleton.Instance)
            {
                var context = ContextSingleton.Instance;
                context.Update(this);
                context.SaveChanges();
            }
        }
    }
}