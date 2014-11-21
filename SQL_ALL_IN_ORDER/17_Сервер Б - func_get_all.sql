CREATE OR REPLACE FUNCTION get_all_categories()
  RETURNS TABLE (    
   id integer,
   title text
   ) AS
$$
BEGIN
RETURN QUERY
	SELECT c.id, c.title from sb.categories c;
END
$$  LANGUAGE plpgsql SECURITY DEFINER;

CREATE OR REPLACE FUNCTION get_all_countries()
  RETURNS TABLE (    
   id integer,
   name text
   ) AS
$$
BEGIN
RETURN QUERY
	SELECT a.id, a.name 
	FROM (SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', 
                                   'SELECT sa.countries.id, sa.countries.name FROM sa.countries' ) as countries (id integer, name text) 
              UNION 
              SELECT sb.countries.id, sb.countries.name 
              FROM sb.countries) a
        ORDER BY 2;
END
$$  LANGUAGE plpgsql SECURITY DEFINER;

CREATE OR REPLACE FUNCTION get_all_clients()
  RETURNS TABLE (    
   id integer,
   surname text,
   name text,
   patronymic text,
   birthdate date,
   phone text,
   email text,
   address text,
   passport_series text,
   passport_number text,
   issue_date date,
   issue_department text
   ) AS
$$
BEGIN
RETURN QUERY
	SELECT a.id, b.surname, b.name, b.patronymic, b.birthdate,
        a.phone, a.email, a.address, 
	b.passport_series, b.passport_number, b.issue_date, b.issue_department
        FROM (SELECT cli.id, cli.phone, cli.email, cli.address
              FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6',
                                  'SELECT sa.clients.id, sa.clients.phone, sa.clients.email, sa.clients.address 
                                    FROM sa.clients' ) as cli (id integer, phone text, email text, address text) 
                                  ) a 
        JOIN sb.clients b on a.id = b.id;
END
$$  LANGUAGE plpgsql SECURITY DEFINER;

CREATE OR REPLACE FUNCTION get_all_companies()
  RETURNS TABLE(id integer, name text, country_id integer, country text, head_full_name text, phone text, address text, bank_details text) AS
$$
BEGIN
RETURN QUERY
	SELECT * FROM (
		SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', 
	'SELECT a.id, a.name, a.country_id, c.name, a.head_full_name, a.phone, a.address, a.bank_details
	FROM sa.companies a
	JOIN sa.countries c ON c.id = a.country_id' ) as companies (id integer, name text, country_id integer, country text, head_full_name text, phone text, address text, bank_details text)

	UNION

	SELECT b.id, b.name, b.country_id, c.name, b.head_full_name, b.phone, b.address, b.bank_details
	FROM sb.companies b
	JOIN sb.countries c ON c.id = b.country_id) w
	ORDER BY 2;
END
$$
  LANGUAGE plpgsql SECURITY DEFINER;

CREATE OR REPLACE FUNCTION get_companies_by_server(serv_id integer)
  RETURNS TABLE (    
   id integer,
  name text,
  country_id integer,
  country text,
  head_full_name text,
  phone text,
  address text,
  bank_details text
   ) AS
$$
BEGIN
if serv_id = 0 then
RETURN QUERY
	SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', 
	'SELECT a.id, a.name, a.country_id, c.name, a.head_full_name, a.phone, a.address, a.bank_details
	FROM sa.companies a
	JOIN sa.countries c ON c.id = a.country_id' ) as companies (id integer, name text, country_id integer, country text, head_full_name text, phone text, address text, bank_details text);
else
RETURN QUERY
	SELECT b.id, b.name, b.country_id, c.name, b.head_full_name, b.phone, b.address, b.bank_details
	FROM sb.companies b
	JOIN sb.countries c ON c.id = b.country_id;
end if;
END
$$  LANGUAGE plpgsql SECURITY DEFINER;

CREATE OR REPLACE FUNCTION get_list_countries_by_server(serv_id integer)
  RETURNS TABLE (    
   id integer,
   name text
   ) AS
$$
BEGIN
if serv_id = 0 then
RETURN QUERY
	SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', 
                                   'SELECT sa.countries.id, sa.countries.name FROM sa.countries' ) as countries (id integer, name text);
else
RETURN QUERY
      SELECT sb.countries.id, sb.countries.name 
      FROM sb.countries;
end if;
END
$$  LANGUAGE plpgsql SECURITY DEFINER;


CREATE OR REPLACE FUNCTION get_list_companies_by_server(serv_id integer)
  RETURNS TABLE (    
   id integer,
   name text
   ) AS
$$
BEGIN
if serv_id = 0 then
RETURN QUERY
	SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', 
	'SELECT a.id, a.name
	FROM sa.companies a' ) as companies (id integer, name text);
else
RETURN QUERY
	SELECT b.id, b.name
	FROM sb.companies b;
end if;
END
$$  LANGUAGE plpgsql SECURITY DEFINER;

CREATE OR REPLACE FUNCTION get_goods_by_server(serv_id integer)
  RETURNS TABLE (    
   id integer, 
   category_id integer, 
   category text, 
   company_id integer, 
   company text, 
   model text, 
   price numeric(12,2)
   ) AS
$$
BEGIN
if serv_id = 0 then
RETURN QUERY
	SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', 
                 'SELECT am.id, am.category_id, cat.title, am.company_id, comp.name, am.model, ai.price
                  FROM sa.goods_main am
                  JOIN sa.goods_info ai ON am.id = ai.id
		  JOIN sa.categories cat ON cat.id = am.category_id
		  JOIN sa.companies comp ON comp.id = am.company_id') 
                as goods (id integer, category_id integer, category text, company_id integer, company text, model text, price numeric(12,2));
else
RETURN QUERY
	SELECT bm.id, bm.category_id, cat.title, bm.company_id, comp.name, bm.model, bi.price
	FROM sb.goods_main bm
	JOIN sb.goods_info bi ON bm.id = bi.id
	JOIN sb.categories cat ON cat.id = bm.category_id
	JOIN sb.companies comp ON comp.id = bm.company_id;
end if;
END
$$  LANGUAGE plpgsql SECURITY DEFINER;


CREATE OR REPLACE FUNCTION get_orders_by_server(serv_id integer)
  RETURNS TABLE (    
   id integer, 
   goods_id integer,
   goods text,
   client_id integer, 
   client text,
   on_sale_date date,
   sale_amount numeric(12,2), 
   payment_method_id integer, 
   payment_method text, 
   sale_type_id integer, 
   sale_type text
   ) AS
$$
BEGIN
if serv_id = 0 then
RETURN QUERY
	SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6',
                  'SELECT om.id, om.goods_id, gm.model, om.client_id, (c.surname ||'' ''|| c.name||'' ''||c.patronymic)as fio,
			 om.on_sale_date, om.sale_amount, 
			 om.payment_method_id, pm.title, om.sale_type_id, st.title
			FROM sa.orders_main om
			JOIN sa.goods_main gm ON gm.id = om.goods_id
			JOIN sa.clients c ON c.id = om.client_id
			JOIN sa.sale_types st ON st.id = om.sale_type_id
			JOIN sa.payment_methods pm ON pm.id = om.payment_method_id')
                 as orders (id integer, goods_id integer, goods text, client_id integer, client text, on_sale_date date, sale_amount numeric(12,2), payment_method_id integer, payment_method text, sale_type_id integer, sale_type text);
else
RETURN QUERY
	SELECT om.id, om.goods_id, gm.model, om.client_id, (c.surname ||' '|| c.name||' '||c.patronymic)as fio,
	 om.on_sale_date, om.sale_amount, 
	 om.payment_method_id, pm.title, oi.sale_type_id, st.title
        FROM sb.orders_main om
        JOIN sb.orders_info oi ON om.id = oi.id
	JOIN sb.goods_main gm ON gm.id = om.goods_id
	JOIN sb.clients c ON c.id = om.client_id
	JOIN sb.sale_types st ON st.id = oi.sale_type_id
	JOIN sb.payment_methods pm ON pm.id = om.payment_method_id;
end if;
END
$$  LANGUAGE plpgsql SECURITY DEFINER;



CREATE OR REPLACE FUNCTION get_all_sale_types()
  RETURNS TABLE (    
   id integer,
   title text
   ) AS
$$
BEGIN
RETURN QUERY
	SELECT c.id, c.title from sb.sale_types c;
END
$$  LANGUAGE plpgsql SECURITY DEFINER;

CREATE OR REPLACE FUNCTION get_all_payment_methods()
  RETURNS TABLE (    
   id integer,
   title text
   ) AS
$$
BEGIN
RETURN QUERY
	SELECT c.id, c.title from sb.payment_methods c;
END
$$  LANGUAGE plpgsql SECURITY DEFINER;



CREATE OR REPLACE FUNCTION get_list_clients()
  RETURNS TABLE (    
   id integer,
   fullname text
   ) AS
$$
BEGIN
RETURN QUERY
	SELECT sb.clients.id, (surname ||' '|| name||' '||patronymic)as fio FROM sb.clients;
END
$$  LANGUAGE plpgsql SECURITY DEFINER;


CREATE OR REPLACE FUNCTION get_list_goods_by_server(serv_id integer)
  RETURNS TABLE (    
   id integer,
   model text
   ) AS
$$
BEGIN
if serv_id = 0 then
RETURN QUERY
	SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6',
                            'SELECT sa.goods_main.id, sa.goods_main.model FROM sa.goods_main' )
                            as goods (id integer, model text);
else
RETURN QUERY
	SELECT sb.goods_main.id, sb.goods_main.model FROM sb.goods_main;
end if;
END
$$  LANGUAGE plpgsql SECURITY DEFINER;