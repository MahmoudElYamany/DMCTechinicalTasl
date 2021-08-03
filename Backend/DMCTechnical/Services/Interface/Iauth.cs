using Models;
using Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface Iauth
    {
        Task<Customer> RegisterAsync(RegisterModel rm);
        Task<Customer> RegisterAsyncAdmin(RegisterModel rm);
        Task<Customer> LogInAsync(LogInModel lm);
    }
}
