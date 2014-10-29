CREATE OR REPLACE FUNCTION func_client_on_update(p_id integer, p_surname text,
						p_name text, p_patronymic text,
						p_birthdate date, p_phone text,
						p_email text, p_address text,
						p_passport_series text, p_passport_number text,
						p_issue_date date, p_issue_department text) RETURNS void AS $$
BEGIN

UPDATE sb.clients SET surname=p_surname, name=p_name,
			patronymic=p_patronymic, birthdate=p_birthdate,
			passport_series=p_passport_series, passport_number=p_passport_number,
			issue_date=p_issue_date, issue_department=p_issue_department
			WHERE id=p_id;

perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('UPDATE sa.clients SET 
			surname='''||p_surname||''', name='''||p_name||''',
			patronymic='''||p_patronymic||''', birthdate='''||p_birthdate||''',
			phone='''||p_phone||''', email='''||p_email||''', address='''||p_address||''' 
			WHERE id='||p_id||';');

perform dblink_disconnect();



return;
END
$$ LANGUAGE plpgsql;
