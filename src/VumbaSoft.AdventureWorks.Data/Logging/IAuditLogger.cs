using Microsoft.EntityFrameworkCore.ChangeTracking;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Collections.Generic;

namespace VumbaSoft.AdventureWorks.Data.Logging
{
    public interface IAuditLogger : IDisposable
    {
        void Log(IEnumerable<EntityEntry<BaseModel>> entries);
        void Save();
    }
}
