ALTER TABLE sb.categories ADD PRIMARY KEY (id);
ALTER TABLE sb.countries ADD PRIMARY KEY (id);
ALTER TABLE sb.payment_methods ADD PRIMARY KEY (id);
ALTER TABLE sb.sale_types ADD PRIMARY KEY (id);
ALTER TABLE sb.companies ADD PRIMARY KEY (id);
ALTER TABLE sb.clients ADD PRIMARY KEY (id);
ALTER TABLE sb.goods_main ADD PRIMARY KEY (id);
ALTER TABLE sb.goods_info ADD PRIMARY KEY (id);
ALTER TABLE sb.orders_main ADD PRIMARY KEY (id);
ALTER TABLE sb.orders_info ADD PRIMARY KEY (id);


ALTER TABLE sb.companies ADD CONSTRAINT companies_country_id
	FOREIGN KEY (country_id) REFERENCES sb.countries (id);

ALTER TABLE sb.goods_main ADD CONSTRAINT goods_main_category_id
	FOREIGN KEY (category_id) REFERENCES sb.categories (id);
ALTER TABLE sb.goods_main ADD CONSTRAINT goods_main_company_id
	FOREIGN KEY (company_id) REFERENCES sb.companies (id);

ALTER TABLE sb.goods_info ADD CONSTRAINT goods_info_id
	FOREIGN KEY (id) REFERENCES sb.goods_main (id);
	
ALTER TABLE sb.orders_main ADD CONSTRAINT orders_main_goods_id
	FOREIGN KEY (goods_id) REFERENCES sb.goods_main (id);
ALTER TABLE sb.orders_main ADD CONSTRAINT orders_main_client_id
	FOREIGN KEY (client_id) REFERENCES sb.clients (id);
ALTER TABLE sb.orders_main ADD CONSTRAINT orders_payment_method_id
	FOREIGN KEY (payment_method_id) REFERENCES sb.payment_methods (id);

ALTER TABLE sb.orders_info ADD CONSTRAINT orders_sale_type_id
	FOREIGN KEY (sale_type_id) REFERENCES sb.sale_types (id);
ALTER TABLE sb.orders_info ADD CONSTRAINT orders_main_info
	FOREIGN KEY (id) REFERENCES sb.orders_main (id);

	
	
CREATE INDEX index_goods_main_category_id ON sb.goods_main (category_id);
CREATE INDEX index_goods_main_company_id ON sb.goods_main (company_id);

CREATE INDEX index_orders_main_goods_id ON sb.orders_main (goods_id);
CREATE INDEX index_orders_main_client_id ON sb.orders_main (client_id);
CREATE INDEX index_orders_main_payment_method_id ON sb.orders_main (payment_method_id);
CREATE INDEX index_orders_main_month ON sb.orders_main(month);