SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6', 
'SELECT sa.companies.name, sa.countries.id, sa.countries.name, head_full_name, phone, address, bank_details
FROM sa.companies
JOIN sa.countries ON sa.countries.id = sa.companies.country_id
WHERE sa.companies.id = 1') as company (company_name text, id integer, country_name text, head_full_name text, phone text, address text, bank_details text)