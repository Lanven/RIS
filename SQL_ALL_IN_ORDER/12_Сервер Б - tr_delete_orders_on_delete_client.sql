--DROP TRIGGER tr_delete_category_to_A_on_delete ON sb.categories;
--DROP FUNCTION func_delete_category_to_A_on_delete();

CREATE OR REPLACE FUNCTION func_delete_orders_on_delete_client() RETURNS trigger AS $$
BEGIN
DELETE FROM sb.orders_info WHERE id IN (SELECT id FROM sb.orders_main WHERE client_id = OLD.id);
DELETE FROM sb.orders_main WHERE client_id = OLD.id;

return OLD;
END
$$ LANGUAGE plpgsql SECURITY DEFINER;

CREATE TRIGGER tr_delete_orders_on_delete_client
BEFORE DELETE ON sb.clients FOR EACH ROW
EXECUTE PROCEDURE func_delete_orders_on_delete_client();