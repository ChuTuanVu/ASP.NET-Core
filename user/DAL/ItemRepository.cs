using DAL.Helper;
using DAL.Interfaces;
using Models;

namespace DAL
{
    public partial class ItemRepository : IItemRepository
    {
        private IDatabaseHelper _databaseHelper;
        public ItemRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }
        public bool Add(Item item)
        {
            string msgError = string.Empty;
            try
            {
                var result = _databaseHelper.ExecuteScalarProcedure(out msgError, "item_add",
                    "@itemid", item.itemid,
                    "@itemname", item.itemname,
                    "@description", item.description,
                    "@price", item.price,
                    "@stock", item.stock,
                    "@categoryid", item.categoryid,
                    "@createdtime", item.createdtime,
                    "@updatedtime", item.updatedtime);
    
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Item item)
        {
            string msgError = string.Empty;
            try
            {
                var result = _databaseHelper.ExecuteScalarProcedure(out msgError, "item_update",
                    "@itemid", item.itemid,
                    "@itemname", item.itemname,
                    "@description", item.description,
                    "@price", item.price,
                    "@stock", item.stock,
                    "@categoryid", item.categoryid,
                    "@updatedtime", item.updatedtime);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(string itemid)
        {
            string msgError = string.Empty;
            try
            {
                var result = _databaseHelper.ExecuteScalarProcedure(out msgError, "item_delete",
                "@itemid", itemid);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Item> GetAll()
        {
            string msgError = string.Empty;
            try
            {
                var dt = _databaseHelper.ExecuteProcedureReturnDataTable(out msgError, "item_get_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Item>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Item GetItemById(string itemid)
        {
            string msgError = string.Empty;
            try
            {
                var dt = _databaseHelper.ExecuteProcedureReturnDataTable(out msgError, "item_get_by_id", "@itemid", itemid);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return dt.ConvertTo<Item>().FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}