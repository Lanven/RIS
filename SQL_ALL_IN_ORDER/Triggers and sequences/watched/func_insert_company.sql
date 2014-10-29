CREATE OR REPLACE FUNCTION func_distribution_company_on_insert() RETURNS trigger AS $$

BEGIN

NEW.id = nextval('sb.companies_id_seq');

if (select count(*) from sb.countries a where a.id=NEW.country_id)=0
then 
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('INSERT INTO sa.companies VALUES ('||NEW.id||',
			'''||NEW.name||''','||NEW.country_id||',
			'''||NEW.head_full_name||''','''||NEW.phone||''',
			'''||NEW.address||''','''||NEW.bank_details||''');');

perform dblink_disconnect();

return null;
end if;


return NEW;

END

$$ LANGUAGE plpgsql