--DROP TRIGGER tr_update_category_to_A_on_update ON sb.categories;
--DROP FUNCTION func_update_category_to_A_on_update();


CREATE OR REPLACE FUNCTION func_update_category_to_A_on_update() RETURNS trigger AS $$
BEGIN
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('UPDATE sa.categories SET title='''||NEW.title||''' WHERE id='||OLD.id||';');

perform dblink_disconnect();
return NEW;
END
$$ LANGUAGE plpgsql;

CREATE TRIGGER tr_update_category_to_A_on_update
BEFORE UPDATE ON sb.categories FOR EACH ROW
EXECUTE PROCEDURE func_update_category_to_A_on_update();