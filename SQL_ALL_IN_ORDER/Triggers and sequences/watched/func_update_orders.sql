﻿CREATE OR REPLACE FUNCTION func_distribution_orders_on_update(p_id integer, p_goods_id integer, p_client_id integer, 
							      p_on_sale_date date, p_sale_amount numeric (12,2), 
							      p_payment_method_id integer, p_sale_type_id integer, 
							      p_details text, p_month integer) RETURNS void AS $$

BEGIN

if (SELECT count(*) from sb.orders_main WHERE id = p_id)=0
    
then 
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
			
perform dblink_exec ('UPDATE sa.orders_main SET 
			goods_id = '||p_goods_id||', client_id = '||p_client_id||',
			on_sale_date = '''||p_on_sale_date||''', sale_amount = '''||p_sale_amount||''',
			payment_method_id = '||p_payment_method_id||', sale_type_id = '||p_sale_type_id||', month = '||p_month||' 
			WHERE id = '||p_id||';');
			
perform dblink_exec ('UPDATE sa.orders_info SET 
			details = '''||p_details||'''
			WHERE id = '||p_id||';');

perform dblink_disconnect();

else 
UPDATE sb.orders_main SET 
   goods_id = p_goods_id, client_id = p_client_id, 
   on_sale_date = p_on_sale_date, sale_amount = p_sale_amount, 
   payment_method_id = p_payment_method_id, month = p_month
   WHERE id = p_id;
   
UPDATE sb.orders_info SET 
   sale_type_id = p_sale_type_id, details = p_details
   WHERE id = p_id;

end if;

END
$$ LANGUAGE plpgsql;

