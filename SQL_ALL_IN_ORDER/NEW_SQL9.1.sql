CREATE OR REPLACE FUNCTION query91()
  RETURNS TABLE (
   id integer,
   name text,
   country_id integer
  ) AS
$$
BEGIN

RETURN QUERY

SELECT * FROM (
	SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru 
	port=5432 user=risbd6 password=ris14bd6', 
	'SELECT sa.companies.id, sa.companies.name, sa.companies.country_id
	FROM sa.companies') as company (id integer, name text, country_id integer)

	UNION

	SELECT sb.companies.id, sb.companies.name, sb.companies.country_id
	FROM sb.companies
) a
ORDER BY 1;

END
$$  LANGUAGE plpgsql SECURITY DEFINER;