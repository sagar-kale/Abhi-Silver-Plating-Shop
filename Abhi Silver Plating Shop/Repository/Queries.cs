﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Abhi_Silver_Plating_Shop.Repository
{
    class Queries
    {
        public const string CUSTOMER_SELECT_QUERY = "Select customerId,name as Name,address as Address, email as Email, mobile as Mobile from customers";
        public const string CUSTOMER_INSERT_QUERY = "INSERT INTO customers VALUES (@customerId, @name, @email, @mobile, @address)";
        public const string CUSTOMER_UPATE_QUERY = "UPDATE customers SET `name` = @name,`email` = @email,`mobile` = @mobile,`address` = @address WHERE `customerId` = @customerId;";
        public const string CUSTOMER_DELETE_QUERY = "DELETE FROM customers WHERE customerId=@customerId;";

        public const string ITEM_SELECT_QUERY = "Select itemId,name as Name from items;";
        public const string ITEM_INSERT_QUERY = "INSERT INTO items VALUES (@itemId, @name);";
        public const string ITEM_UPATE_QUERY = "UPDATE `items` SET `name` = @name WHERE `itemId` = @itemId;";
        public const string ITEM_DELETE_QUERY = "DELETE FROM items WHERE itemId = @itemId;";

        public const string UNIT_SELECT_QUERY = "Select unitId, name as 'Unit Name', rate as Rate  from units;";
        public const string UNIT_INSERT_QUERY = "INSERT INTO units VALUES (@unitId, @rate, @name);";
        public const string UNIT_UPATE_QUERY = "UPDATE `units` SET `rate` = @rate WHERE `unitId` = @unitId;";
        public const string UNIT_DELETE_QUERY = "DELETE FROM units WHERE unitId = @unitId;";

        public const string USER_SELECT_QUERY = "Select * from user_auth;";
        public const string USER_INSERT_QUERY = "INSERT INTO user_auth VALUES(@username, @password, @name, @role);";
        public const string USER_UPATE_QUERY = "UPDATE user_auth SET password = @password, name = @name, role = @role WHERE username = @username;";
        public const string USER_DELETE_QUERY = "DELETE FROM user_auth WHERE username = @username;";

        public const string ORDER_SELECT_QUERY = "SELECT o.orderId, c.name as 'Customer Name'," +
        " i.name as 'Item Name', o.itemId, o.customerId, COALESCE(o.in_weight, 0) as in_weight," +
        " COALESCE(o.out_weight, 0) as out_weight, o.fine, o.labour_rate, o.creation_date, o.last_modified" +
        " FROM orders o" + " INNER JOIN customers c ON o.customerId=c.customerId" +
        " INNER JOIN items i ON o.itemId=i.itemId;";

    }
}
