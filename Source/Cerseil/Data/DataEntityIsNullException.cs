namespace Cerseil.Data
{
    public class DataEntityIsNullException<TDataEntity> : CerseilDataException<TDataEntity> where TDataEntity : DataEntity
    {
        public DataEntityIsNullException()
            : base(null, string.Format("The data entity of type [{0}] is null!", typeof(TDataEntity).Name))
        {
        }
    }
}
