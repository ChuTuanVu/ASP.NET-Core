using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    public class itemController : Controller
    {
        private IItemBusiness _itemBusiness;
        public itemController(IItemBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }

        [Route("item-add")]
        [HttpPost]
        public Item additem([FromBody] Item item)
        {
            item.itemid = Guid.NewGuid().ToString();
            _itemBusiness.Add(item);
            return item;
        }

        [Route("item-update")]
        [HttpPost]
        public Item updateitem([FromBody] Item item)
        {
            _itemBusiness.Update(item);
            return item;
        }

        [Route("item-delete")]
        [HttpPost]
        public IActionResult Deleteitem([FromBody] Dictionary<string, object> formData)
        {
            string itemid = string.Empty;
            if (formData.Keys.Contains("itemid") && !string.IsNullOrEmpty(Convert.ToString(formData["itemid"]))) { itemid = Convert.ToString(formData["itemid"]); }
            _itemBusiness.Delete(itemid);
            return Ok();
        }


        [Route("get-item-by-id/{id}")]
        [HttpGet]
        public Item GetDatabyID(string id)
        {
            return _itemBusiness.GetItemById(id);
        }
    }
}
