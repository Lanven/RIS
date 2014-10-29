CREATE OR REPLACE FUNCTION func_distribution_company_on_update( id integer, 
								name text, 
								country_id integer, 
								head_full_name text, 
								phone text, 
								address text, 
								bank_details text) RETURNS void AS $$
BEGIN

if (select count(*) from sb.companies a where a.id=id)=0
then 
raise notice '111';
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('UPDATE sa.companies SET 
			name='''||name||''', country_id='||country_id||',
			head_full_name='''||head_full_name||''', phone='''||phone||''',
			address='''||address||''', bank_details='''||bank_details||''' 
			WHERE id='||id||';');

perform dblink_disconnect();
end if;

raise notice '222';

END
$$ LANGUAGE plpgsql;

