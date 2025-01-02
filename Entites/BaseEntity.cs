namespace NonsUserTable.Entites
{
    public class BaseEntity<T> : Audiate<T>
        where T : struct
    {
        public T Id { get; set; }
    }
}
