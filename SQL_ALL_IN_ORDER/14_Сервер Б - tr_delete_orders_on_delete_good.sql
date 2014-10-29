CREATE OR REPLACE FUNCTION func_delete_orders_on_delete_good() RETURNS trigger AS $$
BEGIN
DELETE FROM sb.orders_info WHERE id IN (SELECT id FROM sb.orders_main WHERE goods_id = OLD.id);
DELETE FROM sb.orders_main WHERE goods_id = OLD.id;

return OLD;
END
$$ LANGUAGE plpgsql;

CREATE TRIGGER tr_delete_orders_on_delete_good
BEFORE DELETE ON sb.goods_main FOR EACH ROW
EXECUTE PROCEDURE func_delete_orders_on_delete_good();