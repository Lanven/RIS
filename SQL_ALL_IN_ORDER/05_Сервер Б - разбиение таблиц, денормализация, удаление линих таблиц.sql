CREATE TABLE sb.goods_main (LIKE sb.goods INCLUDING CONSTRAINTS);
ALTER TABLE sb.goods_main DROP COLUMN price;
ALTER TABLE sb.goods_main DROP COLUMN description;
INSERT INTO sb.goods_main SELECT id, category_id, company_id, model FROM sb.goods;

CREATE TABLE sb.goods_info (LIKE sb.goods INCLUDING CONSTRAINTS);
ALTER TABLE sb.goods_info DROP COLUMN category_id;
ALTER TABLE sb.goods_info DROP COLUMN company_id;
ALTER TABLE sb.goods_info DROP COLUMN model;
INSERT INTO sb.goods_info SELECT id, price, description FROM sb.goods;



CREATE TABLE sb.orders_main (LIKE sb.orders INCLUDING CONSTRAINTS);
ALTER TABLE sb.orders_main DROP COLUMN details;
ALTER TABLE sb.orders_main DROP COLUMN sale_type_id;
INSERT INTO sb.orders_main SELECT id, goods_id, client_id, on_sale_date, sale_amount, payment_method_id FROM sb.orders;

CREATE TABLE sb.orders_info (LIKE sb.orders INCLUDING CONSTRAINTS);
ALTER TABLE sb.orders_info DROP COLUMN goods_id;
ALTER TABLE sb.orders_info DROP COLUMN client_id;
ALTER TABLE sb.orders_info DROP COLUMN on_sale_date;
ALTER TABLE sb.orders_info DROP COLUMN sale_amount;
ALTER TABLE sb.orders_info DROP COLUMN payment_method_id;
INSERT INTO sb.orders_info SELECT id, sale_type_id, details FROM sb.orders;

ALTER TABLE sb.orders_main ADD COLUMN month integer;
UPDATE sb.orders_main SET month = EXTRACT(MONTH FROM on_sale_date);
ALTER TABLE sb.orders_main ALTER COLUMN month SET NOT NULL;

DROP TABLE sb.goods;
DROP TABLE sb.orders;

