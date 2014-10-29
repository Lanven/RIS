--DROP TRIGGER tr_copy_category_to_A_on_insert ON sb.categories;
--DROP FUNCTION func_copy_category_to_A_on_insert();

CREATE OR REPLACE FUNCTION func_copy_category_to_A_on_insert() RETURNS trigger AS $$
BEGIN
NEW.id = nextval('sb.categories_id_seq');
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('INSERT INTO sa.categories VALUES ('||NEW.id||','''||NEW.title||''');');

perform dblink_disconnect();
return NEW;
END
$$ LANGUAGE plpgsql;

CREATE TRIGGER tr_copy_category_to_A_on_insert
BEFORE INSERT ON sb.categories FOR EACH ROW
EXECUTE PROCEDURE func_copy_category_to_A_on_insert();