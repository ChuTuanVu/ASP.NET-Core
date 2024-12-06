using BLL.Interfaces;
using DAL.Interfaces;
using Models;
namespace BLL
{
    public class ItemBusiness : IItemBusiness
    {
        private IItemRepository _repository;

        public ItemBusiness(IItemRepository repository)
        {
            _repository = repository;
        }
        public bool Add(Item item)
        {
            return _repository.Add(item);
        }

        public bool Update(Item item)
        {
            return _repository.Update(item);
        }

        public bool Delete(string userid)
        {
            return _repository.Delete(userid);
        }

        public List<Item> GetAll()
        {
            return _repository.GetAll();
        }

        public Item GetItemById(string itemid)
        {
            return _repository.GetItemById(itemid);
        }
    }
}