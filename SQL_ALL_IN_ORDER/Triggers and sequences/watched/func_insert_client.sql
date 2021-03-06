﻿--DROP TRIGGER tr_distribution_company_on_insert ON sb.companies;
--DROP FUNCTION func_distribution_company_on_insert();

CREATE OR REPLACE FUNCTION func_distribution_clients_on_insert (p_surname text,
								p_name text, p_patronymic text,
								p_birthdate date, p_phone text,
								p_email text, p_address text,
								p_passport_series text, p_passport_number text,
								p_issue_date date, p_issue_department text) RETURNS void AS $$
DECLARE
 p_id integer;

BEGIN
p_id = nextval('sb.clients_id_seq');

INSERT INTO sb.clients VALUES (p_id,
			p_surname,p_name,
			p_patronymic,p_birthdate,
			p_passport_series,p_passport_number,
			p_issue_date,p_issue_department);
			
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('INSERT INTO sa.clients VALUES ('||p_id||',
			'''||p_surname||''','''||p_name||''',
			'''||p_patronymic||''','''||p_birthdate||''',
			'''||p_phone||''','''||p_email||''','''||p_address||''');');

perform dblink_disconnect();


return;
END
$$ LANGUAGE plpgsql;


