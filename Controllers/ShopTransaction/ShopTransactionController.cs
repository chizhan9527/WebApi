﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Models.ShopTransaction;

namespace WebApi.Controllers.ShopTransaction
{
  public class ShopTransactionController
  {
    /*
     * 返回全部的收货地址
     */
    [Route("/ShopTransaction/get_delivery_address/{UserID}")]
    [HttpGet]
    public string get_delivery_address(string UserID)
    {
      ShopTransactionModel shopTransactionModel = new ShopTransactionModel();
      return shopTransactionModel.Get_delivery_address(UserID);
    }
    /*
     * 创建新的订单
     */
    [Route("/ShopTransaction/add_deal_record")]
    [HttpPost]
    public string add_deal_record(string Trade_id, string Product_id, string Ord_price, string UserID)
    {
      ShopTransactionModel shopTransactionModel = new ShopTransactionModel();
      return shopTransactionModel.Add_deal_record(Trade_id, Product_id, Ord_price, UserID);
    }
    /*
     * 返回用户订单
     */
    [Route("/ShopTransaction/get_deal_record/{UserID}")]
    [HttpGet]
    public string get_deal_record(string UserID)
    {
      ShopTransactionModel shopTransactionModel = new ShopTransactionModel();
      return shopTransactionModel.Get_deal_record(UserID);
    }
    /*
     * 修改订单信息
     */
    [Route("/ShopTransaction/modify_deal_record/{UserID}")]
    [HttpPut]
    public string modify_deal_record(string UserID,string Trade_id,string Ord_payment)
    {
      ShopTransactionModel shopTransactionModel = new ShopTransactionModel();
      return shopTransactionModel.Modify_deal_record(UserID, Trade_id, Ord_payment);
    }
    /*
     * 返回用户积分
     */
    [Route("/ShopTransaction/get_User_Creadits/{UserID}")]
    [HttpGet]
    public string get_User_Creadits(string UserID)
    {
      ShopTransactionModel shopTransactionModel = new ShopTransactionModel();
      return shopTransactionModel.Get_User_Creadits(UserID);
    }
    /*
     *修改用户积分
     */
    [Route("/ShopTransaction/modify_Creadits_Record/{UserID}")]
    [HttpPut]
    public string modify_Creadits_Record(string UserID, string Trade_id, int Creadits_change, string Status)
    {
      ShopTransactionModel shopTransactionModel = new ShopTransactionModel();
      return shopTransactionModel.Modify_Creadits_Record(UserID, Trade_id, Creadits_change, Status);
    }
  }
}