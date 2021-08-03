using Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interface;
using Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class cartMoc : ICart
    {
        private readonly ApiContext _db;
        private readonly UserManager<Customer> _user;

        public cartMoc(ApiContext db, UserManager<Customer> user)
        {
            _db = db;
            _user = user;
        }

        public async Task<List<Status>> GetAllStatus()
        {
            return await _db.statuses.ToListAsync();
        }

        public async Task<List<Discount>> GetAllDiscount()
        {
            return await _db.Discounts.ToListAsync();
        }

        public async Task<Discount> GetVAlueDiscount(string code)
        {
            var result = await _db.Discounts.FirstOrDefaultAsync(x => x.TaxCode == code);
            if (result != null)
                return result;
            else
            {
                var cc = new Discount();
                cc.TaxCode = "noCode";
                cc.Value = 0;
                return cc;

            }
        }

        public async Task<List<orderHeaderCustomer>> GetInvoiceno(string us)
        {
            var user = await _user.FindByNameAsync(us);
            var result = await _db.headerCustomers.Where(x => x.customerID == user.Id).ToListAsync();
            var data = new List<orderHeaderCustomer>();
            if (result != null)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    data.Add(new orderHeaderCustomer()
                    {
                        orderHeaderID = result[i].orderHeaderID,
                        ID = result[i].ID
                    });
                }
                return data;
            }
            else
            {
                return new List<orderHeaderCustomer>();
            }
        }

        public async Task<string> checkout(CartModel cm)
        {
            var cartview = _db.orderHeaders.FirstOrDefault(x => x.ID == cm.orderId);
            orderHeader oh = new orderHeader();
            if (cartview == null)
            {
                oh.ID = cm.orderId;
                oh.orderDate = DateTime.Today;
                oh.Status = 1;
                oh.tax = 14;
                oh.paymentType = cm.paymenttype;

                var discourtValue = await _db.Discounts.FirstOrDefaultAsync(x => x.TaxCode == cm.discount);
                double ST = 0;
                if (discourtValue != null)
                {
                    oh.DiscountID = discourtValue.ID;
                    for (int i = 0; i < cm.items.Count(); i++)
                    {
                        ST += cm.items[i].price;
                    }
                    oh.TotalValue = (int)Math.Round(ST + (ST * oh.tax/100) - (ST * discourtValue.Value/100));
                }
                else
                {
                    
                    for (int i = 0; i < cm.items.Count(); i++)
                    {
                        ST += cm.items[i].price;
                    }
                    oh.TotalValue = (int)Math.Round(ST + (ST * oh.tax/100));
                }

                var user = await _user.FindByNameAsync(cm.username);
                if (user.Country_Id == cm.countryid)
                {
                    oh.DueDate = DateTime.Today.AddDays(7);
                    
                }
                else
                {
                    oh.DueDate = DateTime.Today.AddMonths(2);
                    oh.TotalValue += 100;

                }      
                
                if(user.Country_Id == cm.countryid && cm.paymenttype == "Cash")
                {
                    oh.TotalValue += 5;
                }

                await _db.orderHeaders.AddAsync(oh);

                var oc = new orderHeaderCustomer()
                {
                    orderHeaderID = oh.ID,
                    customerID = user.Id,
                    address = cm.address,
                    city_id = cm.cityid,
                    country_id = cm.countryid                    
                };
                await _db.headerCustomers.AddAsync(oc);

                var od = new List<orderDetial>();

                for (int i = 0; i < cm.items.Count(); i++)
                {
                    od.Add(new orderDetial()
                    {
                        itemID = cm.items[i].id,
                        Quantity = cm.quantity[i],
                        orderHeaderID = oh.ID
                    });
                }
                _db.orderDetials.AddRange(od);

                try
                {
                   await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    throw;
                }

                
            }
            return "done";
        }

        public async Task<InvoiceModel> InvoiceDetials (string id)
        {
            var hc = await _db.headerCustomers.Include(x=>x.Country).Include(c=>c.City).FirstOrDefaultAsync(x => x.orderHeaderID == id);
            if (hc == null)
            {
                return null;
            }
            else
            {
                var user = await _user.FindByIdAsync(hc.customerID);
                var oh = await _db.orderHeaders.Include(x=>x.discount).FirstOrDefaultAsync(x => x.ID == id);
                var od = await _db.orderDetials.Where(x => x.orderHeaderID == id).ToListAsync();
                var item = new List<ProductModel>();
                var quantities = new List<int>();
                for (int i = 0; i < od.Count; i++)
                {
                    var x = _db.items.Include(x=>x.Category).Include(x=>x.uOM).FirstOrDefault(x=>x.ID == od[i].itemID);
                    item.Add(new ProductModel()
                    {
                        id = x.ID,
                        Category = x.Category.Cat_Desc,
                        color = x.color,
                        description = x.description,
                        image = x.image,
                        name = x.name ,
                        price = x.price,
                        size = x.size,
                        uom = x.uOM.name
                    });
                    quantities.Add(od[i].Quantity);
                }
                Boolean cc;
                if (user.Country_Id == hc.country_id)
                {
                    cc = false;
                }
                else
                {
                    cc = true;
                }


                var result = new InvoiceModel()
                {
                    address = hc.address,
                    city = hc.City.City_Name,
                    country = hc.Country.Country_Name,
                    discountCode = oh.DiscountID ==null ? "" : oh.discount.TaxCode,
                    discountvalue = oh.DiscountID == null ? 0 : (int)oh.discount.Value,
                    dueDate = oh.DueDate,
                    orderDate = oh.orderDate,
                    tax = oh.tax,
                    paymentType = oh.paymentType,
                    status = oh.Status,
                    totalValue = oh.TotalValue,
                    userName = user.UserName,
                    items = item,
                    quantity = quantities,
                    anotherCountry = cc
                };


                return result;
            }
        }
    }
}
