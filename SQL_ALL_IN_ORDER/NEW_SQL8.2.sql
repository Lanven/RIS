CREATE OR REPLACE FUNCTION query82(p_id int)
  RETURNS TABLE (
   company_name text,
   country_name text,
   head_full_nam text,
   phon text,
   addres text,
   bank_detail text
  ) AS
$$
BEGIN

   RETURN QUERY
	SELECT sb.companies.name as company_name, sb.countries.name as country_name,
	head_full_name, phone, address, bank_details
	FROM sb.companies
	JOIN sb.countries ON sb.countries.id = sb.companies.country_id
	WHERE sb.companies.id = p_id;
END
$$  LANGUAGE plpgsql;


CREATE OR REPLACE FUNCTION query82dblink(p_id int)
  RETURNS TABLE (
   company_name text,
   country_name text,
   head_full_nam text,
   phon text,
   addres text,
   bank_detail text
  ) AS
$$
BEGIN

   RETURN QUERY
   SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6', 
'SELECT sa.companies.name, sa.countries.name, head_full_name, phone, address, bank_details
FROM sa.companies
JOIN sa.countries ON sa.countries.id = sa.companies.country_id
WHERE sa.companies.id = '||p_id||'') as company (company_name text, country_name text, head_full_name text, phone text, address text, bank_details text);

END
$$  LANGUAGE plpgsql;