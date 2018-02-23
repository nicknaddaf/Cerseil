using System;

namespace Cerseil.Data
{
    public interface IDataEntity
    {
        Guid Id { get; set; }

        DateTime CreateDate { get; set; }
    }
}
