CREATE OR REPLACE FUNCTION func_categories_on_insert(p_title text) RETURNS void AS $$
DECLARE
 p_id integer;
BEGIN
p_id = nextval('sb.categories_id_seq');
INSERT INTO sb.categories VALUES(p_id, p_title);
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('INSERT INTO sa.categories VALUES ('||p_id||','''||p_title||''');');
perform dblink_disconnect();
RETURN;
EXCEPTION WHEN unique_violation THEN
raise exception 'Category already exists';
END
$$ LANGUAGE plpgsql SECURITY DEFINER;


CREATE OR REPLACE FUNCTION func_categories_on_update(p_id integer, p_title text) RETURNS void AS $$
BEGIN
UPDATE sb.categories SET title = p_title WHERE id = p_id;

perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('UPDATE sa.categories SET title='''||p_title||''' WHERE id='||p_id||';');

perform dblink_disconnect();
RETURN;
EXCEPTION WHEN unique_violation THEN
raise exception 'Category already exists';
END
$$ LANGUAGE plpgsql SECURITY DEFINER;


CREATE OR REPLACE FUNCTION func_categories_on_delete(p_id integer) RETURNS void AS $$
BEGIN
DELETE FROM sb.categories WHERE id = p_id;
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('DELETE FROM sa.categories  WHERE id='||p_id||';');

perform dblink_disconnect();
RETURN;
END
$$ LANGUAGE plpgsql SECURITY DEFINER;
