using System;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IService : IDisposable
    {
        Int32 CurrentAccountId { get; set; }
    }
}
