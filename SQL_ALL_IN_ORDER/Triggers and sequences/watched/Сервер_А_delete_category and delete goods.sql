CREATE OR REPLACE FUNCTION func_delete_category_to_A_on_delete() RETURNS trigger AS $$
BEGIN
DELETE FROM sa.goods_info WHERE id IN (SELECT id FROM sa.goods_main WHERE category_id = OLD.id);
DELETE FROM sa.goods_main WHERE category_id = OLD.id;

return OLD;
END
$$ LANGUAGE plpgsql;

CREATE TRIGGER tr_delete_category_to_A_on_delete
BEFORE DELETE ON sa.categories FOR EACH ROW
EXECUTE PROCEDURE func_delete_category_to_A_on_delete();