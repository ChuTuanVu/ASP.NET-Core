using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IItemRepository
    {
        bool Add(Item item);
        bool Update(Item item);
        bool Delete(string userid);
        List<Item> GetAll();
        Item GetItemById(string id);
    }
}