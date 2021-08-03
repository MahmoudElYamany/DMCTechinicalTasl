using Context;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class productMoc : IProduct
    {
        private readonly ApiContext _db;

        public productMoc(ApiContext db)
        {
            _db = db;
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            var items = await _db.items.Include(x=>x.Category).ToListAsync();
            var data = new List<ProductModel>();
            string bb;
            foreach (var i in items)
            {
                if(i.quatity == 0)
                {
                    bb = "OutStock";
                }
                else
                {
                    bb = "InStock";
                }

                data.Add(new ProductModel()
                {
                    id = i.ID,
                    Category = i.Category.Cat_Desc,
                    avaliable = bb,
                    price = i.price,
                    image = i.image,
                    description = i.description,
                    name = i.name,
                    size = i.size,
                    uom = _db.UOMs.FirstOrDefault(x=>x.ID == i.UOM_ID).name,
                    color = i.color

                }); 
            }

            return data;

        }
    }
}
