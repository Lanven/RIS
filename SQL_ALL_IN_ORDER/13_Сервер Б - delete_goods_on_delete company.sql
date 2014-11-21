CREATE OR REPLACE FUNCTION func_delete_goods_on_delete_company() RETURNS trigger AS $$
BEGIN
DELETE FROM sb.goods_info WHERE id IN (SELECT id FROM sb.goods_main WHERE company_id = OLD.id);
DELETE FROM sb.goods_main WHERE company_id = OLD.id;

return OLD;
END
$$ LANGUAGE plpgsql SECURITY DEFINER;

CREATE TRIGGER tr_delete_goods_on_delete_company
BEFORE DELETE ON sb.companies FOR EACH ROW
EXECUTE PROCEDURE func_delete_goods_on_delete_company();