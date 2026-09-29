using BL;
using Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store_Windows
{
    public static class MainClass
    {
       public static DAL.StorageType storageType = DAL.StorageType.JsonFile;
       
        //Business liars
         public static BusinessLayer<Item> itemBL = new BusinessLayer<Item>(storageType);
         public static BusinessLayer<Customer> customerBL = new BusinessLayer<Customer>(storageType);
         public static BusinessLayer<Order> orderBL = new BusinessLayer<Order>(storageType);
         public static OrderReportsService reportBL = new OrderReportsService(orderBL);
    }
}
