CREATE OR REPLACE FUNCTION func_delete_company_from_companies_monthly_on_delete() RETURNS trigger AS $$
BEGIN
DELETE FROM sa.companies_monthly
WHERE id = OLD.id;
return OLD; 
END
$$ LANGUAGE plpgsql;

CREATE TRIGGER tr_delete_company_from_companies_monthly_on_delete
BEFORE DELETE ON sa.companies FOR EACH ROW
EXECUTE PROCEDURE func_delete_company_from_companies_monthly_on_delete();