--DROP TRIGGER tr_copy_category_to_A_on_insert ON sb.categories;
--DROP FUNCTION func_copy_category_to_A_on_insert();

CREATE OR REPLACE FUNCTION func_category_replication_on_insert() RETURNS trigger AS $$
BEGIN
NEW.id = nextval('sb.categories_id_seq');
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('INSERT INTO sa.categories VALUES ('||NEW.id||','''||NEW.title||''');');

perform dblink_disconnect();
return NEW;
END
$$ LANGUAGE plpgsql;

CREATE TRIGGER tr_category_replication_on_insert
AFTER INSERT ON sb.categories FOR EACH ROW
EXECUTE PROCEDURE func_category_replication_on_insert();

--DROP TRIGGER tr_update_category_to_A_on_update ON sb.categories;
--DROP FUNCTION func_update_category_to_A_on_update();


CREATE OR REPLACE FUNCTION func_category_replication_on_update() RETURNS trigger AS $$
BEGIN
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('UPDATE sa.categories SET title='''||NEW.title||''' WHERE id='||OLD.id||';');

perform dblink_disconnect();
return NEW;
END
$$ LANGUAGE plpgsql;

CREATE TRIGGER tr_category_replication_on_update
AFTER UPDATE ON sb.categories FOR EACH ROW
EXECUTE PROCEDURE func_category_replication_on_update();



--DROP TRIGGER tr_delete_category_to_A_on_delete ON sb.categories;
--DROP FUNCTION func_delete_category_to_A_on_delete();

CREATE OR REPLACE FUNCTION func_category_replication_on_delete() RETURNS trigger AS $$
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


CREATE TRIGGER tr_category_replication_on_delete
AFTER DELETE ON sb.categories FOR EACH ROW
EXECUTE PROCEDURE func_category_replication_on_delete();