using System;
using System.Collections.Generic;
using System.Text;

namespace Abhi_Silver_Plating_Shop.Repository
{
    class Queries
    {
        /// <summary>
        /// customers table queries
        /// </summary>

        public const string CUSTOMER_SELECT_QUERY = "Select customerId,name as Name,address as Address, email as Email, mobile as Mobile from customers";
        public const string CUSTOMER_INSERT_QUERY = "INSERT INTO customers VALUES (@customerId, @name, @email, @mobile, @address)";
        public const string CUSTOMER_UPDATE_QUERY = "UPDATE customers SET `name` = @name,`email` = @email,`mobile` = @mobile,`address` = @address WHERE `customerId` = @customerId;";
        public const string CUSTOMER_DELETE_QUERY = "DELETE FROM customers WHERE customerId=@customerId;";

        /// <summary>
        /// items table queries
        /// </summary>

        public const string ITEM_SELECT_QUERY = "Select itemId,name as Name from items;";
        public const string ITEM_INSERT_QUERY = "INSERT INTO items VALUES (@itemId, @name);";
        public const string ITEM_UPDATE_QUERY = "UPDATE `items` SET `name` = @name WHERE `itemId` = @itemId;";
        public const string ITEM_DELETE_QUERY = "DELETE FROM items WHERE itemId = @itemId;";

        /// <summary>
        /// units table queries
        /// </summary>

        public const string UNIT_SELECT_QUERY = "Select unitId, name as 'Unit Name', rate as Rate  from units;";
        public const string UNIT_INSERT_QUERY = "INSERT INTO units VALUES (@unitId, @rate, @name);";
        public const string UNIT_UPDATE_QUERY = "UPDATE `units` SET `rate` = @rate WHERE `unitId` = @unitId;";
        public const string UNIT_DELETE_QUERY = "DELETE FROM units WHERE unitId = @unitId;";
        public const string UNIT_SELECT_BY_UNITNAME_QUERY = "Select * from units where name=@unitName;";

        /// <summary>
        /// user_auth table queries
        /// </summary>

        public const string USER_SELECT_QUERY = "Select * from user_auth;";
        public const string USER_SELECT_BY_USERNAME = "Select * from user_auth where username=@username;";
        public const string USER_INSERT_QUERY = "INSERT INTO user_auth VALUES(@username, @password, @name, @role);";
        public const string USER_UPDATE_QUERY = "UPDATE user_auth SET password = @password, name = @name, role = @role WHERE username = @username;";
        public const string USER_DELETE_QUERY = "DELETE FROM user_auth WHERE username = @username;";

        /// <summary>
        /// orders table queries
        /// </summary>

        public const string ORDER_SELECT_QUERY = "SELECT o.orderId, c.name as 'Customer Name'," +
        " i.name as 'Item Name', o.itemId, o.customerId,  o.in_weight, o.out_weight," +
        " o.fine, o.labour_rate, o.date, o.creation_date, o.last_modified, o.status, o.total_amount" +
        " FROM orders o" + " INNER JOIN customers c ON o.customerId=c.customerId" +
        " INNER JOIN items i ON o.itemId=i.itemId;";

        public const string ORDER_SELECT_QUERY_BY_CUSTOMER_AND_DATE = "SELECT o.orderId, c.name as 'Customer Name'," +
        " i.name as 'Item Name', o.itemId, o.customerId,  o.in_weight, o.out_weight," +
        " o.fine, o.labour_rate, o.date, o.creation_date, o.last_modified, o.status, o.total_amount" +
        " FROM orders o" + " INNER JOIN customers c ON o.customerId=c.customerId" +
        " INNER JOIN items i ON o.itemId=i.itemId" +
        " WHERE o.customerId = @customerId" +
        " AND (o.date between @fromDate and @toDate);";

        public const string ORDER_SELECT_QUERY_BY_CUSTOMER = "SELECT o.orderId, c.name as 'Customer Name'," +
       " i.name as 'Item Name', o.itemId, o.customerId,  o.in_weight, o.out_weight," +
       " o.fine, o.labour_rate, o.date, o.creation_date, o.last_modified, o.status, o.total_amount" +
       " FROM orders o" + " INNER JOIN customers c ON o.customerId=c.customerId" +
       " INNER JOIN items i ON o.itemId=i.itemId" +
       " WHERE o.customerId = @customerId;";



        public const string ORDER_INSERT_QUERY = "INSERT INTO `orders`\n" +
                "(`orderId`,\n" +
                "`itemId`,\n" +
                "`customerId`,\n" +
                "`in_weight`,\n" +
                "`out_weight`,\n" +
                "`fine`,\n" +
                "`labour_rate`,\n" +
                "`date`,\n" +
                "`status`,\n" +
                "`total_amount`)\n" +
                "VALUES\n" +
                "(@orderId,\n" +
                "@itemId,\n" +
                "@customerId,\n" +
                "@inWeight,\n" +
                "@outWeight,\n" +
                "@fine,\n" +
                "@labourRate,\n" +
                "@date,\n" +
                "@status,\n" +
                "@totalAmount);";

        public const string ORDER_UPDATE_QUERY = "UPDATE `orders`\n" +
        "SET\n" +
        "`itemId` = @itemId,\n" +
        "`customerId` = @customerId,\n" +
        "`in_weight` = @inWeight,\n" +
        "`out_weight` = @outWeight,\n" +
        "`fine` = @fine,\n" +
        "`labour_rate` = @labourRate,\n" +
        "`date` = @date,\n" +
        "`status` = @status,\n" +
        "`total_amount` = @totalAmount\n" +
        "WHERE `orderId` = @orderId;";

        public const string ORDER_DELETE_QUERY = "DELETE FROM orders WHERE orderId=@orderId;";
        public const string ORDER_TOTAL_FINE = "select sum(fine) as total_fine from orders; ";
        public const string ORDER_TOTAL_AMOUNT = "select sum(total_amount) as total_amount from orders; ";
        public const string ORDER_LAST_PLACED_BY_CUSTOMER = "select Max(creation_date) last_order_placed from orders where customerId=@customerId; ";

        public const string SELECT_AMT_INVENTORY = "SELECT `amountId`, `customerId`, `amount`, `remainingFine`, `type`, `orderTotalAmt` FROM `amount_inventory`;";
        public const string SELECT_AMT_INVENTORY_BY_CUSTOMER = "SELECT `amountId`, `customerId`, `amount`, `remainingFine`, `type`, `orderTotalAmt` FROM `amount_inventory` where customerId = @customerId;";
        public const string AMT_INVENTORY_UPDATE_BY_CUSTOMER = "UPDATE `amount_inventory` SET `orderTotalAmt` = @orderTotalAmt, `amount` = @amount, `remainingFine` = @remainingFine, `type` = @type  WHERE customerId = @customerId;";
        public const string AMT_INVENTORY_UPDATE_ORDER_AMT_FINE_BY_CUSTOMER = "UPDATE `amount_inventory` SET `orderTotalAmt` = @orderTotalAmt, `remainingFine` = @remainingFine WHERE customerId = @customerId;";

        public const string PAYMENT_INSERT_QUERY = "INSERT INTO `payment_history` (`orderId`,`amountId`,`amount_paid`,`fine_paid`,`customerId`) VALUES (@orderId, @amountId, @amount_paid, @fine_paid, @customerId);";
        public const string PAYMENT_LAST_DATE = "select Max(date) last_payment from payment_history where customerId=@customerId;";
    }
}
