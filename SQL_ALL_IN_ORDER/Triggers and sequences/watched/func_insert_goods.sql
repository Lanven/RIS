CREATE OR REPLACE FUNCTION func_distribution_goods_on_insert(p_category_id integer, 
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

$$ LANGUAGE plpgsql;