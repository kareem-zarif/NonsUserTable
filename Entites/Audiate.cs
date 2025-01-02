namespace NonsUserTable.Entites
{
    public class Audiate<T>
        where T : struct
    {
        public T CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public T ModifiedBY { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
