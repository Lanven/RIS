--DROP TRIGGER tr_distribution_company_on_update ON sb.companies;
--DROP FUNCTION func_distribution_company_on_update();



CREATE OR REPLACE FUNCTION func_distribution_company_on_update(p_id integer, p_name text,
															   p_country_id integer, p_head_full_name text,
															   p_phone text, p_address text, 
															   p_bank_details text) RETURNS void AS $$
BEGIN
if (select count(*) from sb.companies a where a.id=p_id)=0
then 
raise notice '111';
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('UPDATE sa.companies SET 
			name='''||p_name||''', country_id='||p_country_id||',
			head_full_name='''||p_head_full_name||''', phone='''||p_phone||''',
			address='''||p_address||''', bank_details='''||p_bank_details||''' 
			WHERE id='||p_id||';');

perform dblink_disconnect();

end if;

UPDATE sb.companies SET 
			name=p_name, country_id=p_country_id,
			head_full_name=p_head_full_name, phone=p_phone,
			address=p_address, bank_details=p_bank_details
			WHERE id=p_id;
			
return;
END
$$ LANGUAGE plpgsql;
