SELECT * FROM (
SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru 
port=5432 user=risbd6 password=ris14bd6', 
'SELECT sa.companies_main.id, sa.companies_main.name, sa.companies_main.country_id
FROM sa.companies_main') as company (id integer, name text, country_id integer)

UNION

SELECT sb.companies.id, sb.companies.name, sb.companies.country_id
FROM sb.companies
) a
ORDER BY 1