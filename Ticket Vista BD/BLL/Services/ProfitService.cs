using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProfitService
    {
        public static int EventProfit(int id)
        {
            return DataAccessFactory.ProfitData().Amount(id);
        }

        public static int AllEventProfit()
        {
            return DataAccessFactory.ProfitData().TotalAmount();
        }

    }
}
