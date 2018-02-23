using System;

namespace Cerseil.Data
{
    [Serializable]
    public class CerseilDataException<TDataEntity> : CerseilException where TDataEntity : DataEntity
    {
        public CerseilDataException(TDataEntity dataEntity) 
            : this(dataEntity, null, null)
        {
        }

        public CerseilDataException(TDataEntity dataEntity, string message) 
            : this(dataEntity, message, null)
        {
        }

        public CerseilDataException(TDataEntity dataEntity, string message, Exception innerException)
            : base(message, innerException)
        {
            this.DataEntity = dataEntity;
        }

        public TDataEntity DataEntity { get; private set; }
    }
}
