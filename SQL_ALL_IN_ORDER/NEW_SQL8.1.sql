CREATE OR REPLACE FUNCTION query81()
  RETURNS TABLE (
   id integer,
   name text
  ) AS
$$
BEGIN

RETURN QUERY
	SELECT * FROM (
		SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', 
	'SELECT sa.companies.id, sa.companies.name
	FROM sa.companies' ) as companies (id integer, name text)

	UNION

	SELECT sb.companies.id, sb.companies.name
	FROM sb.companies) a
	ORDER BY 2;
END
$$  LANGUAGE plpgsql SECURITY DEFINER;	

