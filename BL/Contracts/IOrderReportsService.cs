using Domains.Reports_Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public interface IOrderReportsService
    {
        public  Task<TotalSalesSummary> TotalSalesSummary();
        public  Task<List<SalesByCustomer>> SalesByCustomer();
        public  Task<List<SalesByItem>> SalesByItem();
        public  Task<List<SalesByCustomer>> TopCustomers(int top);
        public  Task<List<SalesByItem>> TopItems(int top);
    }
}
