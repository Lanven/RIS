ALTER TABLE initial.clients ADD PRIMARY KEY (id);
ALTER TABLE initial.categories ADD PRIMARY KEY (id);
ALTER TABLE initial.countries ADD PRIMARY KEY (id);
ALTER TABLE initial.payment_methods ADD PRIMARY KEY (id);
ALTER TABLE initial.sale_types ADD PRIMARY KEY (id);
ALTER TABLE initial.companies ADD PRIMARY KEY (id);
ALTER TABLE initial.goods ADD PRIMARY KEY (id);
ALTER TABLE initial.orders ADD PRIMARY KEY (id);


ALTER TABLE initial.companies 
ADD CONSTRAINT country_id_name 
FOREIGN KEY (country_id) 
REFERENCES initial.countries (id);

ALTER TABLE initial.goods 
ADD CONSTRAINT category_id_name 
FOREIGN KEY (category_id) 
REFERENCES initial.categories (id);

ALTER TABLE initial.goods 
ADD CONSTRAINT company_id_name 
FOREIGN KEY (company_id) 
REFERENCES initial.companies (id);

ALTER TABLE initial.orders 
ADD CONSTRAINT goods_id_name 
FOREIGN KEY (goods_id) 
REFERENCES initial.goods (id);

ALTER TABLE initial.orders 
ADD CONSTRAINT client_id_name 
FOREIGN KEY (client_id) 
REFERENCES initial.clientsb (id);

ALTER TABLE initial.orders 
ADD CONSTRAINT payment_id_name 
FOREIGN KEY (payment_method_id) 
REFERENCES initial.payment_methods (id);

ALTER TABLE initial.orders 
ADD CONSTRAINT sale_id_name 
FOREIGN KEY (sale_type_id) 
REFERENCES initial.sale_types (id);


