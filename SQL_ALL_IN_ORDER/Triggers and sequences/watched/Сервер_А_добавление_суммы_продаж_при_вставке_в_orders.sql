CREATE OR REPLACE FUNCTION func_add_money_on_insert_order() RETURNS trigger AS $$
declare
v_company_id integer;
v_country_id integer;
BEGIN
SELECT company_id INTO v_company_id
FROM sa.goods_main
WHERE sa.goods_main.id = NEW.goods_id;

SELECT country_id INTO v_country_id
FROM sa.companies
WHERE sa.companies.id = v_company_id;

UPDATE sa.companies_monthly SET summa = summa + NEW.sale_amount WHERE month = NEW.month and id = v_company_id;
UPDATE sa.countries SET summa = summa + NEW.sale_amount WHERE id = v_country_id;

return NEW;
END
$$ LANGUAGE plpgsql;

CREATE TRIGGER tr_add_money_on_insert_order
BEFORE INSERT ON sa.orders_main FOR EACH ROW
EXECUTE PROCEDURE func_add_money_on_insert_order();