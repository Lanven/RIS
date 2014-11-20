ALTER TABLE sa.categories ADD PRIMARY KEY (id);
ALTER TABLE sa.countries ADD PRIMARY KEY (id);
ALTER TABLE sa.payment_methods ADD PRIMARY KEY (id);
ALTER TABLE sa.sale_types ADD PRIMARY KEY (id);
ALTER TABLE sa.companies ADD PRIMARY KEY (id);
ALTER TABLE sa.goods_main ADD PRIMARY KEY (id);
ALTER TABLE sa.goods_info ADD PRIMARY KEY (id);
ALTER TABLE sa.clients ADD PRIMARY KEY (id);
ALTER TABLE sa.orders_main ADD PRIMARY KEY (id);
ALTER TABLE sa.orders_info ADD PRIMARY KEY (id);

ALTER TABLE sa.companies ADD CONSTRAINT companies_country_id
	FOREIGN KEY (country_id) REFERENCES sa.countries (id); 

ALTER TABLE sa.companies_monthly ADD CONSTRAINT companies_monthly_id
	FOREIGN KEY (id) REFERENCES sa.companies (id); 

ALTER TABLE sa.goods_main ADD CONSTRAINT goods_main_category_id
	FOREIGN KEY (category_id) REFERENCES sa.categories (id);
ALTER TABLE sa.goods_main ADD CONSTRAINT goods_main_company_id
	FOREIGN KEY (company_id) REFERENCES sa.companies (id);

ALTER TABLE sa.orders_main ADD CONSTRAINT orders_main_goods_id
	FOREIGN KEY (goods_id) REFERENCES sa.goods_main (id);
ALTER TABLE sa.orders_main ADD CONSTRAINT orders_main_client_id
	FOREIGN KEY (client_id) REFERENCES sa.clients (id);
ALTER TABLE sa.orders_main ADD CONSTRAINT orders_main_payment_method_id
	FOREIGN KEY (payment_method_id) REFERENCES sa.payment_methods (id);
ALTER TABLE sa.orders_main ADD CONSTRAINT orders_main_sale_type_id
	FOREIGN KEY (sale_type_id) REFERENCES sa.sale_types (id);

ALTER TABLE sa.goods_info ADD CONSTRAINT goods_info_id
	FOREIGN KEY (id) REFERENCES sa.goods_main (id);

ALTER TABLE sa.orders_info ADD CONSTRAINT orders_info_id
	FOREIGN KEY (id) REFERENCES sa.orders_main (id);

	
CREATE INDEX index_companies_country_id ON sa.companies (country_id);

CREATE INDEX index_companies_monthly_month ON sa.companies_monthly (month);

CREATE INDEX index_goods_main_category_id ON sa.goods_main (category_id);
CREATE INDEX index_goods_main_company_id ON sa.goods_main (company_id);

CREATE INDEX index_orders_main_goods_id ON sa.orders_main (goods_id);
CREATE INDEX index_orders_main_client_id ON sa.orders_main (client_id);
CREATE INDEX index_orders_main_payment_method_id ON sa.orders_main (payment_method_id);
CREATE INDEX index_orders_main_sale_type_id ON sa.orders_main (sale_type_id);
CREATE INDEX index_orders_main_sale_cond ON sa.orders_main(sale_amount) WHERE sale_amount <= 1000;
CREATE INDEX index_orders_main_month ON sa.orders_main(month);

CREATE INDEX index_clients ON sa.clients (birthdate DESC, surname, name, patronymic);
ALTER TABLE sa.categories ADD CONSTRAINT categories_unique UNIQUE (title);
ALTER TABLE sa.countries ADD CONSTRAINT countries_unique UNIQUE (name);