CREATE TABLE `amount_inventory` (
  `amountId` int NOT NULL AUTO_INCREMENT,
  `customerId` varchar(45) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `amount` double DEFAULT '0',
  `remainingFine` double DEFAULT '0',
  `type` varchar(6) COLLATE utf8mb4_unicode_ci DEFAULT 'NA',
  `orderTotalAmt` double DEFAULT '0',
  PRIMARY KEY (`amountId`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `payment_history` (
  `paymentId` int NOT NULL AUTO_INCREMENT,
  `orderId` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `date` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `amountId` int DEFAULT NULL,
  `amount_paid` double DEFAULT NULL,
  `fine_paid` double DEFAULT NULL,
  PRIMARY KEY (`paymentId`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='				';
