--DROP TRIGGER tr_delete_category_to_A_on_delete ON sb.categories;
--DROP FUNCTION func_delete_category_to_A_on_delete();

CREATE OR REPLACE FUNCTION func_delete_category_to_A_on_delete() RETURNS trigger AS $$
BEGIN
DELETE FROM sb.goods_info WHERE id IN (SELECT id FROM sb.goods_main WHERE category_id = OLD.id);
DELETE FROM sb.goods_main WHERE category_id = OLD.id;
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('DELETE FROM sa.categories  WHERE id='||OLD.id||';');

perform dblink_disconnect();
return OLD;
END
$$ LANGUAGE plpgsql;


CREATE TRIGGER tr_delete_category_to_A_on_delete
BEFORE DELETE ON sb.categories FOR EACH ROW
EXECUTE PROCEDURE func_delete_category_to_A_on_delete();