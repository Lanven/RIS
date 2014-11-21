--DROP TRIGGER tr_add_money_on_insert_order ON sa.orders_main;
--DROP TRIGGER tr_change_money_on_update_order ON sa.orders_main;
--DROP TRIGGER tr_change_money_on_delete_order ON sa.orders_main;

CREATE OR REPLACE FUNCTION func_add_money_on_insert_order() RETURNS trigger AS $$
declare
v_company_id integer;
v_country_id integer;
v_summa numeric(12,2);
BEGIN
SELECT company_id INTO v_company_id
FROM sa.goods_main
WHERE sa.goods_main.id = NEW.goods_id;

SELECT country_id INTO v_country_id
FROM sa.companies
WHERE sa.companies.id = v_company_id;



SELECT summa INTO v_summa
FROM sa.companies_monthly
WHERE month = NEW.month and id = v_company_id;

IF v_summa IS NULL THEN
	v_summa := NEW.sale_amount;
ELSE
	v_summa := v_summa + NEW.sale_amount;
END IF;
UPDATE sa.companies_monthly SET summa = v_summa WHERE month = NEW.month and id = v_company_id;



SELECT summa INTO v_summa
FROM sa.countries
WHERE id = v_country_id;

IF v_summa IS NULL THEN
	v_summa := NEW.sale_amount;
ELSE
	v_summa := v_summa + NEW.sale_amount;
END IF;

UPDATE sa.countries SET summa = v_summa WHERE id = v_country_id;

return NEW;
END
$$ LANGUAGE plpgsql SECURITY DEFINER;

CREATE TRIGGER tr_add_money_on_insert_order
BEFORE INSERT ON sa.orders_main FOR EACH ROW
EXECUTE PROCEDURE func_add_money_on_insert_order();



CREATE OR REPLACE FUNCTION func_change_money_on_update_order() RETURNS trigger AS $$
declare
v_company_id integer;
v_country_id integer;
BEGIN
NEW.month = EXTRACT(MONTH FROM NEW.on_sale_date);

SELECT company_id INTO v_company_id
FROM sa.goods_main
WHERE sa.goods_main.id = OLD.goods_id;

SELECT country_id INTO v_country_id
FROM sa.companies
WHERE sa.companies.id = v_company_id;

UPDATE sa.companies_monthly SET summa = summa - OLD.sale_amount WHERE month = OLD.month and id = v_company_id;
UPDATE sa.companies_monthly SET summa = summa + NEW.sale_amount WHERE month = NEW.month and id = v_company_id;

UPDATE sa.countries SET summa = summa - OLD.sale_amount + NEW.sale_amount WHERE id = v_country_id;

return NEW;
END
$$ LANGUAGE plpgsql SECURITY DEFINER;

CREATE TRIGGER tr_change_money_on_update_order
BEFORE UPDATE ON sa.orders_main FOR EACH ROW
EXECUTE PROCEDURE func_change_money_on_update_order();



CREATE OR REPLACE FUNCTION func_change_money_on_delete_order() RETURNS trigger AS $$
declare
v_company_id integer;
v_country_id integer;
v_summa numeric(12,2);
BEGIN
SELECT company_id INTO v_company_id
FROM sa.goods_main
WHERE sa.goods_main.id = OLD.goods_id;

SELECT country_id INTO v_country_id
FROM sa.companies
WHERE sa.companies.id = v_company_id;



SELECT summa INTO v_summa
FROM sa.companies_monthly
WHERE month = OLD.month and id = v_company_id;
v_summa := v_summa - OLD.sale_amount;
IF v_summa = 0 THEN
	v_summa := NULL;
END IF;
UPDATE sa.companies_monthly SET summa = v_summa WHERE month = OLD.month and id = v_company_id;



SELECT summa INTO v_summa
FROM sa.countries
WHERE id = v_country_id;
v_summa := v_summa - OLD.sale_amount;

IF v_summa = 0 THEN
	v_summa := NULL;
END IF;
UPDATE sa.countries SET summa = v_summa WHERE id = v_country_id;

return OLD;
END
$$ LANGUAGE plpgsql SECURITY DEFINER;

CREATE TRIGGER tr_change_money_on_delete_order
BEFORE DELETE ON sa.orders_main FOR EACH ROW
EXECUTE PROCEDURE func_change_money_on_delete_order();