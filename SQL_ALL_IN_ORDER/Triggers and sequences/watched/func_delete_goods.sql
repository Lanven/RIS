--DROP FUNCTION func_distribution_goods_on_delete();


CREATE OR REPLACE FUNCTION func_distribution_goods_on_delete(p_id integer) RETURNS void AS $$

BEGIN

if (SELECT count(*) from sb.goods_main WHERE id=p_id)=0
    
then 
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
			
perform dblink_exec ('DELETE FROM sa.goods_info WHERE id = '||p_id||'; ');
			
perform dblink_exec ('DELETE FROM sa.goods_main WHERE id = '||p_id||'; ');

perform dblink_disconnect();

else 
DELETE FROM sa.goods_info WHERE id = p_id;
DELETE FROM sa.goods_main WHERE id = p_id;

end if;

END
$$ LANGUAGE plpgsql;