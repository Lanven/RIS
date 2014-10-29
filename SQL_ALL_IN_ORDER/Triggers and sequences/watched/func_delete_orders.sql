CREATE OR REPLACE FUNCTION func_distribution_orders_on_delete(p_id integer) RETURNS void AS $$

BEGIN

if (SELECT count(*) from sb.orders_main WHERE id = p_id)=0
    
then 
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');


perform dblink_exec ('DELETE FROM sa.orders_info WHERE id = '||p_id||';');


perform dblink_exec ('DELETE FROM sa.orders_main WHERE id = '||p_id||';');

perform dblink_disconnect();

else 

DELETE FROM sb.orders_info WHERE id = p_id;
DELETE FROM sb.orders_main WHERE id = p_id;

end if;

END
$$ LANGUAGE plpgsql;

