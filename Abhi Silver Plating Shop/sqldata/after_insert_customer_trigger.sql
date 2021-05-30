CREATE DEFINER=`root`@`localhost` TRIGGER `customers_AFTER_INSERT` AFTER INSERT ON `customers` FOR EACH ROW BEGIN
DECLARE orderTotalAmt DOUBLE DEFAULT 0;
DECLARE remainingFine DOUBLE DEFAULT 0;
SELECT COALESCE(sum(total_amount), 0) into orderTotalAmt FROM orders where customerId=new.customerId;
SELECT COALESCE(sum(fine), 0) into remainingFine FROM orders where customerId=new.customerId;
INSERT INTO `amount_inventory` (`customerId`,`amount`,`remainingFine`, `orderTotalAmt`) VALUES (new.customerId, 0, remainingFine, orderTotalAmt);
END