using Models;

namespace BLL.Interfaces
{
    public interface IItemBusiness
    {
        bool Add(Item item);
        bool Update(Item item);
        bool Delete(string userid);
        List<Item> GetAll();
        Item GetItemById(string id);
    }
}
