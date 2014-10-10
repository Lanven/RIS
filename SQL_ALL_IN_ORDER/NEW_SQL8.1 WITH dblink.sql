SELECT * FROM (
	SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', 

	
'SELECT sa.companies_main.id, sa.companies_main.name
FROM sa.companies_main' ) as companies (id integer, name text)

UNION

SELECT sb.companies.id, sb.companies.name
FROM sb.companies) a
ORDER BY 2