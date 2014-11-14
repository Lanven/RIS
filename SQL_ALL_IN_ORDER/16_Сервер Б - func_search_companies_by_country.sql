CREATE OR REPLACE FUNCTION func_search_companies_by_country(p_id integer)
  RETURNS integer AS
$$
BEGIN
RETURN (SELECT count(*) 
	FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6', 
		'SELECT sa.companies.id
		FROM sa.companies
		WHERE sa.companies.country_id = '||p_id||'') as company (company_id integer));
END
$$  LANGUAGE plpgsql;

select func_search_companies_by_country(1);