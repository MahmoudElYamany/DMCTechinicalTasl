using Models;
using Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICart
    {
        Task<List<Discount>> GetAllDiscount();
        Task<Discount> GetVAlueDiscount(string code);
        Task<string> checkout(CartModel cm);
        Task<List<orderHeaderCustomer>> GetInvoiceno(string us);
        Task<InvoiceModel> InvoiceDetials(string id);
        Task<List<Status>> GetAllStatus();
    }
}
