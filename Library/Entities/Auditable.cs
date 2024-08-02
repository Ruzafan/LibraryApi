namespace Library.Entities
{
    public abstract class Auditable : Mongeable
    {
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set;}
    }
}
