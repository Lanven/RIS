CREATE OR REPLACE FUNCTION func_countries_on_insert(p_name text) RETURNS void AS $$
DECLARE
 p_id integer;
BEGIN
p_id = nextval('sb.countries_id_seq');

perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('INSERT INTO sa.countries VALUES ('||p_id||','''||p_name||''');');
perform dblink_disconnect();
return;
EXCEPTION WHEN unique_violation THEN
raise exception 'Country already exists';
END
$$ LANGUAGE plpgsql;


CREATE OR REPLACE FUNCTION func_countries_on_update(p_id integer, p_name text) RETURNS void AS $$
BEGIN

perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('UPDATE sa.countries SET name='''||p_name||''' WHERE id='||p_id||';');

perform dblink_disconnect();
return;
EXCEPTION WHEN unique_violation THEN
raise exception 'Country already exists';
END
$$ LANGUAGE plpgsql;


CREATE OR REPLACE FUNCTION func_countries_on_delete(p_id integer) RETURNS void AS $$
BEGIN

perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('DELETE FROM sa.countries WHERE id='||p_id||';');

perform dblink_disconnect();
return;
EXCEPTION WHEN foreign_key_violation THEN
raise exception 'Referenced data exist';
END
$$ LANGUAGE plpgsql;
