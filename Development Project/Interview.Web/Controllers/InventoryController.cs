using Microsoft.AspNetCore.Mvc;
using Sparcpoint.Abstract;
using Sparcpoint.Data.Models;

namespace Interview.Web.Controllers
{
    [Route("api/v1/inventory")]
    public class InventoryController:Controller
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        [HttpPost("add")]
        public IActionResult AddProductToInventory([FromBody]ProductInventoryInfo prodInfo)
        {
            _inventoryService.AddInventory(prodInfo.ProductId,prodInfo.Quantity);
            return Ok();
        }
        
        [HttpPost("removeFromInventory")]
        public IActionResult RemoveFromInventory([FromBody]int transactionId)
        {
            var res= _inventoryService.RemoveFromInventory(transactionId);
            return res!=""?Ok():BadRequest();
        }
        
        [HttpPost("inventoryCount")]
        public IActionResult GetInventoryCount([FromBody] InventorySearchFilter filter)
        {
            var res= _inventoryService.GetInventoryCount(filter);
            return Ok(res);
        }
        

    }
}
