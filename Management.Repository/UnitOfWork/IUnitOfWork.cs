using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Management.Repository.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        void Commit();
    }
}
