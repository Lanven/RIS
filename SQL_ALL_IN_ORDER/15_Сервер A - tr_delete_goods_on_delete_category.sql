CREATE OR REPLACE FUNCTION func_delete_goods_on_delete_category() RETURNS trigger AS $$
BEGIN
DELETE FROM sa.goods_info WHERE id IN (SELECT id FROM sa.goods_main WHERE category_id = OLD.id);
DELETE FROM sa.goods_main WHERE category_id = OLD.id;

return OLD;
END
$$ LANGUAGE plpgsql SECURITY DEFINER;

CREATE TRIGGER tr_delete_goods_on_delete_category
BEFORE DELETE ON sa.categories FOR EACH ROW
EXECUTE PROCEDURE func_delete_goods_on_delete_category();