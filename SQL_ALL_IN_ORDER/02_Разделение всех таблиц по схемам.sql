--Общие таблицы на обоих серверах:
CREATE TABLE sa.sale_types (LIKE initial.sale_types INCLUDING CONSTRAINTS);
INSERT INTO sa.sale_types SELECT * FROM initial.sale_types;
CREATE TABLE sb.sale_types (LIKE initial.sale_types INCLUDING CONSTRAINTS);
INSERT INTO sb.sale_types SELECT * FROM initial.sale_types;

CREATE TABLE sa.payment_methods (LIKE initial.payment_methods INCLUDING CONSTRAINTS);
INSERT INTO sa.payment_methods SELECT * FROM initial.payment_methods;
CREATE TABLE sb.payment_methods (LIKE initial.payment_methods INCLUDING CONSTRAINTS);
INSERT INTO sb.payment_methods SELECT * FROM initial.payment_methods;

CREATE TABLE sa.categories (LIKE initial.categories INCLUDING CONSTRAINTS);
INSERT INTO sa.categories SELECT * FROM initial.categories;
CREATE TABLE sb.categories (LIKE initial.categories INCLUDING CONSTRAINTS);
INSERT INTO sb.categories SELECT * FROM initial.categories;

--Страны - Россия лежит на B, а все остальное - на А
CREATE TABLE sa.countries (LIKE initial.countries INCLUDING CONSTRAINTS);
INSERT INTO sa.countries SELECT * FROM initial.countries;
CREATE TABLE sb.countries (LIKE initial.countries INCLUDING CONSTRAINTS);
INSERT INTO sb.countries SELECT * FROM initial.countries;

DELETE FROM sa.countries WHERE name LIKE 'Российская Федерация';
DELETE FROM sb.countries WHERE name <> 'Российская Федерация';

--Остальные таблицы, в зависимости от сервера
CREATE TABLE sa.clients (LIKE initial.clients INCLUDING CONSTRAINTS);
INSERT INTO sa.clients SELECT * FROM initial.clients;
ALTER TABLE sa.clients DROP COLUMN passport_series;
ALTER TABLE sa.clients DROP COLUMN passport_number;
ALTER TABLE sa.clients DROP COLUMN issue_date;
ALTER TABLE sa.clients DROP COLUMN issue_department;

CREATE TABLE sb.clients (LIKE initial.clients INCLUDING CONSTRAINTS);
INSERT INTO sb.clients SELECT * FROM initial.clients;
ALTER TABLE sb.clients DROP COLUMN phone;
ALTER TABLE sb.clients DROP COLUMN email;
ALTER TABLE sb.clients DROP COLUMN address;
-----------------------------------------------------------------------
CREATE TABLE sa.companies (LIKE initial.companies INCLUDING CONSTRAINTS);
INSERT INTO sa.companies 
	SELECT initial.companies.id, initial.companies.name, country_id, head_full_name, phone, address, bank_details FROM initial.companies 
	LEFT JOIN initial.countries on initial.countries.id = initial.companies.country_id 
	WHERE initial.countries.name <> 'Российская Федерация';

CREATE TABLE sb.companies (LIKE initial.companies INCLUDING CONSTRAINTS);
INSERT INTO sb.companies 
	SELECT initial.companies.id, initial.companies.name, country_id, head_full_name, phone, address, bank_details FROM initial.companies 
	LEFT JOIN initial.countries on initial.countries.id = initial.companies.country_id 
	WHERE initial.countries.name LIKE 'Российская Федерация';
-------------------------------------------------------------------
CREATE TABLE sa.goods (LIKE initial.goods INCLUDING CONSTRAINTS);
INSERT INTO sa.goods 
	SELECT initial.goods.id, category_id, company_id, model, price, description
	FROM initial.goods 
	LEFT JOIN initial.companies on initial.companies.id = initial.goods.company_id
	LEFT JOIN initial.countries on initial.countries.id = initial.companies.country_id 
	WHERE initial.countries.name <> 'Российская Федерация';

CREATE TABLE sb.goods (LIKE initial.goods INCLUDING CONSTRAINTS);
INSERT INTO sb.goods 
	SELECT initial.goods.id, category_id, company_id, model, price, description
	FROM initial.goods 
	LEFT JOIN initial.companies on initial.companies.id = initial.goods.company_id
	LEFT JOIN initial.countries on initial.countries.id = initial.companies.country_id 
	WHERE initial.countries.name LIKE 'Российская Федерация';
-----------------------------------------------------------------
CREATE TABLE sa.orders (LIKE initial.orders INCLUDING CONSTRAINTS);
INSERT INTO sa.orders 
	SELECT initial.orders.id, goods_id, client_id, on_sale_date, sale_amount, payment_method_id, sale_type_id, details
	FROM initial.orders 
	LEFT JOIN initial.goods on initial.goods.id = initial.orders.goods_id
	LEFT JOIN initial.companies on initial.companies.id = initial.goods.company_id
	LEFT JOIN initial.countries on initial.countries.id = initial.companies.country_id 
	WHERE initial.countries.name <> 'Российская Федерация';

CREATE TABLE sb.orders (LIKE initial.orders INCLUDING CONSTRAINTS);
INSERT INTO sb.orders 
	SELECT initial.orders.id, goods_id, client_id, on_sale_date, sale_amount, payment_method_id, sale_type_id, details
	FROM initial.orders 
	LEFT JOIN initial.goods on initial.goods.id = initial.orders.goods_id
	LEFT JOIN initial.companies on initial.companies.id = initial.goods.company_id
	LEFT JOIN initial.countries on initial.countries.id = initial.companies.country_id 
	WHERE initial.countries.name LIKE 'Российская Федерация';