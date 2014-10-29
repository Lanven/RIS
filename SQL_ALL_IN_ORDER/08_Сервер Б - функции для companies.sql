CREATE OR REPLACE FUNCTION func_companies_on_insert(p_name text,
													p_country_id integer, p_head_full_name text,
													p_phone text, p_address text, 
													p_bank_details text) RETURNS void AS $$
DECLARE
p_id integer;
													
BEGIN

p_id = nextval('sb.companies_id_seq');

if (select count(*) from sb.countries a where a.id = p_country_id) = 0
then 
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('INSERT INTO sa.companies VALUES ('||p_id||',
			'''||p_name||''','||p_country_id||',
			'''||p_head_full_name||''','''||p_phone||''',
			'''||p_address||''','''||p_bank_details||''');');

perform dblink_disconnect();
else
INSERT INTO sb.companies VALUES (p_id,
			p_name,p_country_id,
			p_head_full_name,p_phone,
			p_address,p_bank_details);

end if;
return;
END
$$ LANGUAGE plpgsql;


CREATE OR REPLACE FUNCTION func_companies_on_update(p_id integer, p_name text,
													p_country_id integer, p_head_full_name text,
													p_phone text, p_address text, 
													p_bank_details text) RETURNS void AS $$
BEGIN
if (select count(*) from sb.companies a where a.id = p_id) = 0
then 
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('UPDATE sa.companies SET 
			name='''||p_name||''', country_id='||p_country_id||',
			head_full_name='''||p_head_full_name||''', phone='''||p_phone||''',
			address='''||p_address||''', bank_details='''||p_bank_details||''' 
			WHERE id='||p_id||';');

perform dblink_disconnect();
else
UPDATE sb.companies SET 
			name=p_name, country_id=p_country_id,
			head_full_name=p_head_full_name, phone=p_phone,
			address=p_address, bank_details=p_bank_details
			WHERE id=p_id;
end if;			
return;
END
$$ LANGUAGE plpgsql;



--DROP FUNCTION func_distribution_company_on_delete(integer);

CREATE OR REPLACE FUNCTION func_companies_on_delete(p_id integer) RETURNS void AS $$
BEGIN

if (select count(*) from sb.companies a where a.id = p_id)=0
then 
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('DELETE FROM sa.companies WHERE id='||p_id||';');

perform dblink_disconnect();

else 
DELETE FROM sb.companies WHERE id = p_id;
end if;

return;
END
$$ LANGUAGE plpgsql;

--select func_distribution_company_on_delete(606);
