CREATE OR REPLACE FUNCTION func_delete_orders_on_delete_client() RETURNS trigger AS $$
BEGIN
DELETE FROM sa.orders_info WHERE id IN (SELECT id FROM sa.orders_main WHERE client_id = OLD.id);
DELETE FROM sa.orders_main WHERE client_id = OLD.id;

return OLD;
END
$$ LANGUAGE plpgsql;

CREATE TRIGGER tr_delete_orders_on_delete_client
BEFORE DELETE ON sa.clients FOR EACH ROW
EXECUTE PROCEDURE func_delete_orders_on_delete_client();