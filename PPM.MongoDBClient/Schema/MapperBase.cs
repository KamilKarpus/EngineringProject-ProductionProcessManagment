namespace PPM.MongoDBClient.Schema
{
    public abstract class MapperBase<T> : IMapper
    {
        public abstract DocumentBase<T> ToDocument(T entity);
        public abstract T AsEntity(DocumentBase<T> documentBase);
    }
}
