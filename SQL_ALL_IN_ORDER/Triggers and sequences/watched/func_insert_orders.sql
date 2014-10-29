CREATE OR REPLACE FUNCTION func_distribution_orders_on_insert(p_goods_id integer, p_client_id integer, 
							      p_on_sale_date date, p_sale_amount numeric (12,2), 
							      p_payment_method_id integer, p_sale_type_id integer, 
							      p_details text) RETURNS void AS $$
  
DECLARE
p_id integer;
month integer;

BEGIN
p_id = nextval('sb.orders_id_seq');
month = EXTRACT (MONTH FROM p_on_sale_date);

if (SELECT count(*) from sb.goods_main WHERE sb.goods_main.id = p_goods_id)=0
    
then 
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
			
perform dblink_exec ('INSERT INTO sa.orders_main VALUES ('||p_id||',
			'||p_goods_id||', '||p_client_id||',
			'''||p_on_sale_date||''', '''||p_sale_amount||''',
			'||p_payment_method_id||', '||p_sale_type_id||', '||month||');');
			
perform dblink_exec ('INSERT INTO sa.orders_info VALUES ('||p_id||',
			'''||p_details||''');');

perform dblink_disconnect();

else 
INSERT INTO sb.orders_main VALUES (p_id, p_goods_id, p_client_id, p_on_sale_date, p_sale_amount, p_payment_method_id, month);
INSERT INTO sb.orders_info VALUES (p_id, p_sale_type_id, p_details);

end if;

END
$$ LANGUAGE plpgsql;
