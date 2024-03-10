-- Insert into Users table
INSERT INTO [dbo].[Users] ([firstName], [lastName], [userName], [phoneNumber], [email], [password], [isActive])
VALUES 
('Ali', 'Ahmed', 'aliahmed', '01111111111', 'ali347@email.com', '@aliPass123', 1),
('Ahmed', 'Omar', 'ahmedomar', '01222222222', 'ahmed165@email.com', '@ahmedPass123', 1),
('Omar', 'Mohamed', 'omarMohamed', '01133333333', 'omar242@email.com', '@omarPass123', 1),
('Peter', 'Girgus', 'petergirgus', '01244444444', 'peter134@email.com', '$peterPass456', 1),
('Omnia', 'Sayed', 'omniasayed', '01055555555', 'omnia834@email.com', '$omniaPass456', 1),
('Ahmed', 'Mohamed', 'ahmedmohamed', '01121411811', 'ahmed123@email.com', '$ahmedPass456', 1),
('Ahmed', 'Sayed', 'ahmedsayed', '01228172222', 'ahmed356@email.com', '$ahmedPass456', 1),
('Mohamed', 'Ali', 'mohamedali', '0113331968', 'mohamed178@email.com', '$mohamedPass456', 1),
('Eslam', 'Ahmed', 'eslamahmed', '01244424734', 'eslam235@email.com', '#eslamPass789', 1),
('Arwa', 'Waleed', 'arwawaleed', '0105523955', 'arwa194@email.com', '#arwaPass789', 1),
('Mohamed', 'Waleed', 'mohamedwaleed', '0105123955', 'mohamed145@email.com', '#mohamedPass789', 1);
('Asmaa', 'Ali', 'asmaaali', '0113132968', 'asmaa148@email.com', '#asmaaPass789', 1),
('Wafaa', 'Ahmed', 'Wafaaahmed', '01242424734', 'Wafaa235@email.com', '#WafaaPass789', 1),
('Hazam', 'Waleed', 'hazamwaleed', '0125223955', 'hazam194@email.com', '#hazamPass789', 1),
('Mostafa', 'Ahmed', 'mostafaahmed', '0125123955', 'mostafa145@email.com', '#mostafaPass789', 1);

-- Insert into Admins table
INSERT INTO [dbo].[Admins] ([adminID], [authorityLevelID])
VALUES 
(1, 3),
(2, 2),
(3, 1);


-- Insert into Sellers table
INSERT INTO [dbo].[Sellers] ([sellerID], [commercialName], [rate], [address])
VALUES 
(4, 'Carrefour', 4.5, 'Maadi'),
(5, 'Kazyoun', 3.2, 'Helwan'),
(6, 'Kheir zaman', 4.8, 'Nasr City'),
(7, 'Circle K', 3.9, 'Smart Village'),
(8, 'Gomla market ', 4.1, 'Heliopolis');

-- Insert into Customers table
INSERT INTO [dbo].[Customers] ([customerID], [address])
VALUES 
(9, 'Maadi'),
(10, 'Capital City'),
(11, '6 October'),
(12, 'Nasr City'),
(13, 'Giza'),
(14, 'Zahraa Maadi'),
(15, 'Sakr Korish');

INSERT INTO [dbo].[Messages] ([title], [content], [date], [isActive], [userID])
VALUES 
('Welcome!', 'Thank you for joining our platform.', '2024-03-09 15:00:00', 1, 9),
('Order Confirmation', 'Your order has been confirmed. We are preparing it for shipment.', '2024-03-09 15:30:00', 1, 10),
('Feedback Request', 'We would love to hear your feedback on your recent purchase. Please share your thoughts with us.', '2024-03-09 16:00:00', 1, 11);

INSERT INTO [dbo].[Vouchers] ([amount], [description], [expireDate], [isActive], [customerID])
VALUES 
(10.0, 'Discount Voucher', '2024-04-30 23:59:59', 1, 10),
(20.5, 'Special Offer Voucher', '2024-05-15 23:59:59', 1, 11),
(15.2, 'Summer Sale Voucher', '2024-06-30 23:59:59', 1, 12),
(25.8, 'Holiday Bonus Voucher', '2024-07-31 23:59:59', 1, 13),
(30.0, 'Customer Appreciation Voucher', '2024-08-15 23:59:59', 1, 14);

-- Insert into CustomersVouchers table
INSERT INTO [dbo].[CustomersVouchers] ([customerID], [voucherID], [isUsed])
VALUES 
(9, 1, 0),  -- Customer 9 has Discount Voucher
(10, 2, 0), -- Customer 10 has Special Offer Voucher
(11, 3, 0), -- Customer 11 has Summer Sale Voucher
(12, 4, 0), -- Customer 12 has Holiday Bonus Voucher
(13, 5, 0); -- Customer 13 has Customer Appreciation Voucher

-- Insert into Categories table
INSERT INTO [dbo].[Categories] ([name], [isActive], [parentCategoryID])
VALUES 
('Fruits', 1, NULL),
('Vegetables', 1, NULL),
('Dairy', 1, NULL),
('Beverages', 1, NULL),
('Snacks', 1, NULL)
('Mango',1,1),
('Apple',1,1),
('Orange',1,1);

-- Insert into Products table
INSERT INTO [dbo].[Products] ([description], [stock], [rate], [name], [price], [costPrice], [categoryID], [sellerID])
VALUES 
('Sweet and crisp, the Red Apple is a favorite for snacking and baking. Packed with vitamins and antioxidants.', 100, 4.0, 'Red Apple', 100.0, 20.0, 1, 4),
('Fresh and crunchy, our Orange Carrots are rich in beta-carotene, promoting good vision and immune health.', 50, 3.0, 'Orange Carrot', 150.0, 30.0, 2, 4),
('Our Fresh Milk is sourced from local farms, ensuring quality and freshness. Perfect for daily consumption or cooking.', 200, 2.5, 'Fresh Milk', 30.0, 10.0, 3, 5),
('Indulge in the goodness of Pure Orange Juice, made from handpicked oranges. A refreshing and healthy beverage option.', 80, 3.5, 'Pure Orange Juice', 50.0, 20.0, 4, 5),
('Satisfy your snack cravings with our Potato Chips. Thinly sliced and perfectly seasoned for a delightful snacking experience.', 120, 2.0, 'Potato Chips', 10.0, 5.0, 5, 7),
('Sweet and juicy, our Mangoes are a tropical delight. Packed with flavor and vitamins, they make for a delicious and healthy treat.', 50, 4.5, 'Mango', 80.0, 15.0, 6, 4);
-- Insert into CardsDetails table
INSERT INTO [dbo].[CardsDetails] ([cardName], [cvv], [cardNumber], [isActive], [customerID])
VALUES 
('Visa Card', 123, '1234567890123456', 1, 11),
('MasterCard', 456, '2345678901234567', 1, 12),
('American Express', 789, '3456789012345678', 1, 13),
('Discover Card', 321, '4567890123456789', 1, 14),
('Diners Club', 654, '5678901234567890', 1, 15);



-- Insert into Offers table
INSERT INTO [dbo].[Offers] ([description], [discount], [expireDate], [isActive])
VALUES 
('Summer Sale', 10.0, '2024-07-31 23:59:59', 1),
('Back-to-School Special', 15.0, '2024-09-15 23:59:59', 2),
('Holiday Discount', 20.0, '2024-12-31 23:59:59', 1),
('New Years Flash Sale', 25.0, '2025-01-15 23:59:59', 3),
('Spring Clearance',10.0, '2025-03-31 23:59:59', 5);


-- Insert into Orders table
INSERT INTO [dbo].[Orders] ([customerNote], [state], [date], [shippingState], [shippingAddress], [totalPrice], [isActive], [orderName], [customerID], [shippingFees], [voucher])
VALUES 
('Include a gift card', 1, '2024-03-09 15:00:00', 1, 'Maadi', 82.5, 1, 'Order Maadi', 9, 10.0, 0.0),
('Urgent delivery requested', 1, '2024-03-09 15:30:00', 1, 'Capital City', 129.0, 1, 'Order Capital City', 10, 10.0, 0.0),
('Preferred delivery time: Evening', 1, '2024-03-09 16:00:00', 1, '6 October', 33.0, 1, 'Order 6 October', 11, 10.0, 0.0),
('Contact before delivery', 1, '2024-03-09 16:30:00', 1, 'Nasr City', 60.0, 1, 'Order Nasr City', 12, 10.0, 0.0),
('Handle with care, fragile items', 1, '2024-03-09 17:00:00', 1, 'Giza', 27.0, 1, 'Order Giza', 13, 10.0, 0.0);

-- Insert into Items table
INSERT INTO [dbo].[Items] ([address], [discount], [quantity], [subTotalPrice], [momentPrice], [isActive], [orderID], [productID])
VALUES 
('123 Nile Street, Giza', 0.0, 2, 4.0, 4.0, 1, 1, 1),
('456 Sphinx Avenue, Zamalek', 0.5, 3, 4.5, 4.0, 1, 2, 2),
('789 Pyramid Road, Maadi', 1.0, 1, 1.5, 1.0, 1, 3, 3),
('101 Pharaoh''s Lane, Heliopolis', 1.5, 4, 6.0, 4.5, 1, 4, 4),
('202 Cleopatra Boulevard, Nasr City', 2.0, 2, 3.0, 2.0, 1, 5, 5);

-- Insert into PaymentsDetails table
INSERT INTO [dbo].[PaymentsDetails] ([amount], [paymentMethod], [date], [isActive], [orderID], [cardID])
VALUES 
(82.5, 'Credit Card', '2024-03-09 15:15:00', 1, 1, 1),
(129.0, 'Credit Card', '2024-03-09 15:45:00', 1, 2, 2),
(33.0, 'Credit Card', '2024-03-09 16:15:00', 1, 3, 3),
(60.0, 'Credit Card', '2024-03-09 16:45:00', 1, 4, 4),
(27.0, 'Credit Card', '2024-03-09 17:15:00', 1, 5, 5);


-- Insert into ProductsOffers table
INSERT INTO [dbo].[ProductsOffers] ([productID], [offerID])
VALUES 
(1, 1),  -- Red Apple is part of Summer Sale
(2, 2),  -- Orange Carrot is part of Back-to-School Special
(3, 3),  -- Fresh Milk is part of Holiday Discount
(4, 4),  -- Pure Orange Juice is part of New Years Flash Sale
(5, 5);  -- Potato Chips is part of Spring Clearance

INSERT INTO [dbo].[FeedBacks] ([review], [rate], [date], [isActive], [productID], [customerID])
VALUES 
('Delicious apples! They were sweet and fresh. Highly recommended.', 4.5, '2024-03-09 15:15:00', 1, 1, 9),
('Carrots were crisp and tasty. Great quality and value for money.', 4.0, '2024-03-09 15:45:00', 1, 2, 10),
('The fresh milk was exactly what I needed. Will order again for sure.', 5.0, '2024-03-09 16:15:00', 1, 3, 11),
('Pure Orange Juice was refreshing and natural. Loved the taste!', 4.5, '2024-03-09 16:45:00', 1, 4, 12),
('Potato Chips were a perfect snack. Crispy and well-seasoned.', 3.5, '2024-03-09 17:15:00', 1, 5, 13);


select * from customers;
select * from Products;
select * from Orders;
select * from items;
select * from users;
select * from admins;
select * from Sellers;
select * from customers;
select * from Vouchers;
select * from CardsDetails;
select * from Categories
select * from Products;
select * from Offers;
select * from orders;
select * from items;