﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

using AdventureWorks.Models.SalesOrder;

namespace AdventureWorks.Repository
{
    public class DapperSalesOrdersRepository: ISalesOrdersRepository
	{
        private SqlConnection GetConnection()
        {
            string sqlConString = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();
            return new SqlConnection(sqlConString);
        }

        // TODO: add query and pagination params
        public List<SalesOrder> GetSalesOrders()
        {
            try
            {
                SqlConnection connect = this.GetConnection();
                IList<SalesOrder> orderList = SqlMapper.Query<SalesOrder>(
                    connect, "SalesGetSalesOrders").ToList();
                connect.Close();
                return orderList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<SalesOrderDetails> GetSalesOrderDetails(int orderId)
        {
            return null; 
        }

    }
}