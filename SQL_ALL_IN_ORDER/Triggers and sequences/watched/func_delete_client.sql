--DROP FUNCTION func_delete_client(integer);

CREATE OR REPLACE FUNCTION func_delete_client(p_id integer) RETURNS void AS $$
BEGIN

DELETE FROM sb.clients WHERE id=p_id;

perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('DELETE FROM sa.clients WHERE id='||p_id||';');

perform dblink_disconnect();

return;
END
$$ LANGUAGE plpgsql;

--select func_delete_client(50002);
