using BL.Exceptions;
using Domains;
using Domains.Reports_Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class OrderReportsService:IOrderReportsService
    {
        private readonly BusinessLayer<Order> _OrderBL;
        public OrderReportsService(BusinessLayer<Order> orderBL)
        {
            _OrderBL = orderBL;
        }
        public async Task<TotalSalesSummary> TotalSalesSummary()
        {
            try
            {
                var Orders = await _OrderBL.GetData();
                return  new TotalSalesSummary
                {
                    CountOrder = Orders.Count(),
                    TotalPrice = Orders.Sum(a => a.TotalPrice)
                };
      
            }
            catch (BusinessException ex)
            {
                throw;
            }
        }
        public async Task<List<SalesByCustomer>> SalesByCustomer()
        {
            try
            {
                 
                var Orders = await _OrderBL.GetData();


                var Result = Orders.GroupBy(a => new { a.CustomerId, a.CustomerName })
                    .Select(g => new SalesByCustomer
                    {
                        Id = g.Key.CustomerId,
                        Name = g.Key.CustomerName,
                        OrderCount = g.Count(),
                        TotalPrice = g.Sum(o => o.TotalPrice)
                    }).OrderByDescending(a=>a.TotalPrice).ToList();
                return Result;
            }
            catch (BusinessException ex)
            {
                throw;
            }

        }
        public async Task<List<SalesByItem>> SalesByItem()
        {
            try
            {
                var Orders = await _OrderBL.GetData();

                var Result = Orders.GroupBy(a => new { a.ItemId, a.Name })
                    .Select(g => new SalesByItem
                    {
                        Id = g.Key.ItemId,
                        Name = g.Key.Name,
                        OrderCount = g.Count(),
                        TotalPrice = g.Sum(o => o.TotalPrice)
                    }).OrderByDescending(a=>a.TotalPrice).ToList();

                return Result;
            }
            catch (BusinessException ex)
            {
                throw;
            }
        }
        public async Task<List<SalesByCustomer>> TopCustomers(int top)
        {
            try
            {
             var Customers = await SalesByCustomer();
                return Customers.Take(top).ToList();
               
            }
            catch (BusinessException ex)
            {
                throw;
            }
        }
        public async Task<List<SalesByItem>> TopItems(int top)
        {
            try
            {
                var Items = await SalesByItem();
                return Items.Take(top).ToList();
            }
            catch (BusinessException ex)
            {
               throw;
            }
        }
    }
}
