using System;

namespace Infrastucture.Interfaces.Interfaces
{
    public interface IContextFactory: IDisposable
    {
        IDefaultContext GetDefaultContext();
    }
}
