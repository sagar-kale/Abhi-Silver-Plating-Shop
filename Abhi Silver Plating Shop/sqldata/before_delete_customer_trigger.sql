CREATE DEFINER=`root`@`localhost` TRIGGER `customers_BEFORE_DELETE` BEFORE DELETE ON `customers` FOR EACH ROW BEGIN
DELETE FROM `amount_inventory`
WHERE customerId = old.customerId;
END