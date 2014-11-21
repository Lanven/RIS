CREATE OR REPLACE FUNCTION func_goods_on_insert(p_category_id integer, 
												p_company_id integer, 
												p_model text, p_price numeric, 
												p_description text) RETURNS void AS $$
DECLARE
p_id integer;

BEGIN
p_id = nextval('sb.goods_id_seq');

if (SELECT count(*) from sb.countries
    JOIN sb.companies ON sb.companies.country_id = sb.countries.id 
    WHERE sb.companies.id=p_company_id)=0
    
then 
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
			
perform dblink_exec ('INSERT INTO sa.goods_main VALUES ('||p_id||',
			'||p_category_id||', '||p_company_id||',
			'''||p_model||''');');
			
perform dblink_exec ('INSERT INTO sa.goods_info VALUES ('||p_id||',
			'||p_price||','''||p_description||''');');

perform dblink_disconnect();

else 
INSERT INTO sb.goods_main VALUES (p_id, p_category_id, p_company_id, p_model);
INSERT INTO sb.goods_info VALUES (p_id, p_price, p_description);

end if;

END

$$ LANGUAGE plpgsql SECURITY DEFINER;

--DROP FUNCTION func_distribution_goods_on_update();


CREATE OR REPLACE FUNCTION func_goods_on_update(p_id integer, p_category_id integer,
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
UPDATE sb.goods_main SET category_id = p_category_id, 
			 company_id = p_company_id, model = p_model 
			 WHERE id = p_id;
UPDATE sb.goods_info SET price = p_price, 
			 description = p_description
			 WHERE id = p_id;

end if;

END
$$ LANGUAGE plpgsql SECURITY DEFINER;

--select func_distribution_goods_on_update (10168, 332, 598, 'bbb', 1000, 'bbbbbbb');

--DROP FUNCTION func_distribution_goods_on_delete();


CREATE OR REPLACE FUNCTION func_goods_on_delete(p_id integer) RETURNS void AS $$

BEGIN

if (SELECT count(*) from sb.goods_main WHERE id=p_id)=0
    
then 
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
			
perform dblink_exec ('DELETE FROM sa.goods_info WHERE id = '||p_id||'; ');
			
perform dblink_exec ('DELETE FROM sa.goods_main WHERE id = '||p_id||'; ');

perform dblink_disconnect();

else 
DELETE FROM sb.goods_info WHERE id = p_id;
DELETE FROM sb.goods_main WHERE id = p_id;

end if;

END
$$ LANGUAGE plpgsql SECURITY DEFINER;