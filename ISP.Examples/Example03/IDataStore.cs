namespace ISP.Examples.Example03
{
    public interface IDataStore<in TKey, in TItem> 
        where TItem : class
    {
        void AddItem(TKey key, TItem item);
        bool Contains(TKey key);
    }
}