CREATE TABLE sa.goods_main (LIKE sa.goods INCLUDING CONSTRAINTS);
ALTER TABLE sa.goods_main DROP COLUMN price;
ALTER TABLE sa.goods_main DROP COLUMN description;
INSERT INTO sa.goods_main 
	SELECT id, category_id, company_id, model 
	FROM sa.goods;

CREATE TABLE sa.goods_info (LIKE sa.goods INCLUDING CONSTRAINTS);
ALTER TABLE sa.goods_info DROP COLUMN category_id;
ALTER TABLE sa.goods_info DROP COLUMN company_id;
ALTER TABLE sa.goods_info DROP COLUMN  model;
INSERT INTO sa.goods_info 
	SELECT id, price, description 
	FROM sa.goods;


CREATE TABLE sa.orders_main (LIKE sa.orders INCLUDING CONSTRAINTS);
ALTER TABLE sa.orders_main DROP COLUMN details;
INSERT INTO sa.orders_main 
	SELECT id, goods_id, client_id, on_sale_date, sale_amount, payment_method_id, sale_type_id 
	FROM sa.orders;

CREATE TABLE sa.orders_info (LIKE sa.orders INCLUDING CONSTRAINTS);
ALTER TABLE sa.orders_info DROP COLUMN goods_id;
ALTER TABLE sa.orders_info DROP COLUMN client_id;
ALTER TABLE sa.orders_info DROP COLUMN on_sale_date;
ALTER TABLE sa.orders_info DROP COLUMN sale_amount;
ALTER TABLE sa.orders_info DROP COLUMN payment_method_id;
ALTER TABLE sa.orders_info DROP COLUMN sale_type_id;
INSERT INTO sa.orders_info 
	SELECT id, details 
	FROM sa.orders;

ALTER TABLE sa.orders_main ADD COLUMN month integer;
UPDATE sa.orders_main SET month = EXTRACT(MONTH FROM on_sale_date);
ALTER TABLE sa.orders_main ALTER COLUMN month SET NOT NULL;

CREATE TABLE sa.countries_temp (LIKE sa.countries INCLUDING CONSTRAINTS);
ALTER TABLE sa.countries_temp ADD COLUMN summa numeric(12,2);
INSERT INTO sa.countries_temp (id, name, summa)
SELECT sa.countries.id, sa.countries.name, sum(sale_amount)
	FROM sa.orders_main
	RIGHT JOIN sa.goods_main ON sa.orders_main.goods_id=goods_main.id
	RIGHT JOIN sa.companies ON sa.goods_main.company_id = sa.companies.id
	RIGHT JOIN sa.countries ON sa.companies.country_id = sa.countries.id
	GROUP BY sa.countries.id, sa.countries.name;
DROP TABLE sa.countries;
ALTER TABLE sa.countries_temp RENAME TO countries;

CREATE TABLE sa.companies_monthly
(
	id integer NOT NULL,
	month integer NOT NULL,
	summa numeric(12,2)
);

INSERT INTO sa.companies_monthly (id, month, summa)
(SELECT sa.companies.id,1,sum(sale_amount)
	from sa.companies
	left join sa.goods_main on sa.goods_main.company_id = sa.companies.id
	left join sa.orders_main on sa.orders_main.goods_id = sa.goods_main.id
	WHERE EXTRACT(MONTH FROM on_sale_date)=1 or sale_amount is null
	GROUP BY sa.companies.id);
	
INSERT INTO sa.companies_monthly (id, month, summa)
(SELECT sa.companies.id,2,sum(sale_amount)
	from sa.companies
	left join sa.goods_main on sa.goods_main.company_id = sa.companies.id
	left join sa.orders_main on sa.orders_main.goods_id = sa.goods_main.id
	WHERE EXTRACT(MONTH FROM on_sale_date)=2 or sale_amount is null
	GROUP BY sa.companies.id);
	
INSERT INTO sa.companies_monthly (id, month, summa)
(SELECT sa.companies.id,3,sum(sale_amount)
	from sa.companies
	left join sa.goods_main on sa.goods_main.company_id = sa.companies.id
	left join sa.orders_main on sa.orders_main.goods_id = sa.goods_main.id
	WHERE EXTRACT(MONTH FROM on_sale_date)=3 or sale_amount is null
	GROUP BY sa.companies.id);
	
INSERT INTO sa.companies_monthly (id, month, summa)
(SELECT sa.companies.id,4,sum(sale_amount)
	from sa.companies
	left join sa.goods_main on sa.goods_main.company_id = sa.companies.id
	left join sa.orders_main on sa.orders_main.goods_id = sa.goods_main.id
	WHERE EXTRACT(MONTH FROM on_sale_date)=4 or sale_amount is null
	GROUP BY sa.companies.id);
	
INSERT INTO sa.companies_monthly (id, month, summa)
(SELECT sa.companies.id,5,sum(sale_amount)
	from sa.companies
	left join sa.goods_main on sa.goods_main.company_id = sa.companies.id
	left join sa.orders_main on sa.orders_main.goods_id = sa.goods_main.id
	WHERE EXTRACT(MONTH FROM on_sale_date)=5 or sale_amount is null
	GROUP BY sa.companies.id);
	
INSERT INTO sa.companies_monthly (id, month, summa)
(SELECT sa.companies.id,6,sum(sale_amount)
	from sa.companies
	left join sa.goods_main on sa.goods_main.company_id = sa.companies.id
	left join sa.orders_main on sa.orders_main.goods_id = sa.goods_main.id
	WHERE EXTRACT(MONTH FROM on_sale_date)=6 or sale_amount is null
	GROUP BY sa.companies.id);
	
INSERT INTO sa.companies_monthly (id, month, summa)
(SELECT sa.companies.id,7,sum(sale_amount)
	from sa.companies
	left join sa.goods_main on sa.goods_main.company_id = sa.companies.id
	left join sa.orders_main on sa.orders_main.goods_id = sa.goods_main.id
	WHERE EXTRACT(MONTH FROM on_sale_date)=7 or sale_amount is null
	GROUP BY sa.companies.id);
	
INSERT INTO sa.companies_monthly (id, month, summa)
(SELECT sa.companies.id,8,sum(sale_amount)
	from sa.companies
	left join sa.goods_main on sa.goods_main.company_id = sa.companies.id
	left join sa.orders_main on sa.orders_main.goods_id = sa.goods_main.id
	WHERE EXTRACT(MONTH FROM on_sale_date)=8 or sale_amount is null
	GROUP BY sa.companies.id);
	
INSERT INTO sa.companies_monthly (id, month, summa)
(SELECT sa.companies.id,9,sum(sale_amount)
	from sa.companies
	left join sa.goods_main on sa.goods_main.company_id = sa.companies.id
	left join sa.orders_main on sa.orders_main.goods_id = sa.goods_main.id
	WHERE EXTRACT(MONTH FROM on_sale_date)=9 or sale_amount is null
	GROUP BY sa.companies.id);
	
INSERT INTO sa.companies_monthly (id, month, summa)
(SELECT sa.companies.id,10,sum(sale_amount)
	from sa.companies
	left join sa.goods_main on sa.goods_main.company_id = sa.companies.id
	left join sa.orders_main on sa.orders_main.goods_id = sa.goods_main.id
	WHERE EXTRACT(MONTH FROM on_sale_date)=10 or sale_amount is null
	GROUP BY sa.companies.id);
	
INSERT INTO sa.companies_monthly (id, month, summa)
(SELECT sa.companies.id,11,sum(sale_amount)
	from sa.companies
	left join sa.goods_main on sa.goods_main.company_id = sa.companies.id
	left join sa.orders_main on sa.orders_main.goods_id = sa.goods_main.id
	WHERE EXTRACT(MONTH FROM on_sale_date)=11 or sale_amount is null
	GROUP BY sa.companies.id);
	
INSERT INTO sa.companies_monthly (id, month, summa)
(SELECT sa.companies.id,12,sum(sale_amount)
	from sa.companies
	left join sa.goods_main on sa.goods_main.company_id = sa.companies.id
	left join sa.orders_main on sa.orders_main.goods_id = sa.goods_main.id
	WHERE EXTRACT(MONTH FROM on_sale_date)=12 or sale_amount is null
	GROUP BY sa.companies.id);


DROP TABLE sa.goods;
DROP TABLE sa.orders;