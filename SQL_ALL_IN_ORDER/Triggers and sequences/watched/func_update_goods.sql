--DROP FUNCTION func_distribution_goods_on_update();


CREATE OR REPLACE FUNCTION func_distribution_goods_on_update(p_id integer, p_category_id integer,
							     p_company_id integer, p_model text,
							     p_price numeric(12, 2), p_description text) RETURNS void AS $$

BEGIN

if (SELECT count(*) from sb.goods_main WHERE id=p_id)=0
    
then 
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
			
perform dblink_exec ('UPDATE sa.goods_main SET category_id = '||p_category_id||', 
			company_id = '||p_company_id||',
			model = '''||p_model||''' 
			WHERE id = '||p_id||'; ');
			
perform dblink_exec ('UPDATE sa.goods_info SET price = '||p_price||', 
			description = '''||p_description||'''
			WHERE id = '||p_id||'; ');

perform dblink_disconnect();

else 
UPDATE sa.goods_main SET category_id = p_category_id, 
			 company_id = p_company_id, model = p_model 
			 WHERE id = p_id;
UPDATE sa.goods_info SET price = p_price, 
			 description = p_description
			 WHERE id = p_id;

end if;

END
$$ LANGUAGE plpgsql;

--select func_distribution_goods_on_update (10168, 332, 598, 'bbb', 1000, 'bbbbbbb');