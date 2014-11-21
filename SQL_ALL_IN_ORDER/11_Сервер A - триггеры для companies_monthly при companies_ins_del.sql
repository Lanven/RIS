--DROP TRIGGER tr_add_company_into_companies_monthly_on_insert ON sa.companies;
--DROP FUNCTION func_add_company_into_companies_monthly_on_insert();

CREATE OR REPLACE FUNCTION func_add_into_companies_monthly_on_companies_insert() RETURNS trigger AS $$
BEGIN
INSERT INTO sa.companies_monthly VALUES
(NEW.id, 1, null),
(NEW.id, 2, null),
(NEW.id, 3, null),
(NEW.id, 4, null),
(NEW.id, 5, null),
(NEW.id, 6, null),
(NEW.id, 7, null),
(NEW.id, 8, null),
(NEW.id, 9, null),
(NEW.id, 10, null),
(NEW.id, 11, null),
(NEW.id, 12, null);
return NEW; 
END
$$ LANGUAGE plpgsql SECURITY DEFINER;

CREATE TRIGGER tr_add_into_companies_monthly_on_companies_insert
AFTER INSERT ON sa.companies FOR EACH ROW
EXECUTE PROCEDURE func_add_into_companies_monthly_on_companies_insert();



CREATE OR REPLACE FUNCTION func_delete_from_companies_monthly_on_companies_delete() RETURNS trigger AS $$
BEGIN
DELETE FROM sa.companies_monthly
WHERE id = OLD.id;
return OLD; 
END
$$ LANGUAGE plpgsql SECURITY DEFINER;

CREATE TRIGGER tr_delete_company_from_companies_monthly_on_delete
BEFORE DELETE ON sa.companies FOR EACH ROW
EXECUTE PROCEDURE func_delete_from_companies_monthly_on_companies_delete();