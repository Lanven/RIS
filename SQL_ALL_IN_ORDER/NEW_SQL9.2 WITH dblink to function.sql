CREATE OR REPLACE FUNCTION query92(p_id int, p_from date, p_to date)
  RETURNS TABLE (
   surname text,
   name text,
   patronymic text,
   birthdate date,
   passport_series text,
   passport_number text,
   summa numeric(12,2)
  ) AS
$$
BEGIN

RETURN QUERY
SELECT sb.clients.surname, sb.clients.name, sb.clients.patronymic, sb.clients.birthdate,
	sb.clients.passport_series, sb.clients.passport_number, sum(sale_amount) as summa
FROM (SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru 
	port=5432 user=risbd6 password=ris14bd6', 
'SELECT * FROM (SELECT id FROM sa.goods_main WHERE sa.goods_main.company_id = '||p_id||') as good
JOIN (SELECT goods_id, client_id, sale_amount FROM sa.orders_main 
	WHERE on_sale_date BETWEEN '''||p_from||''' and '''||p_to||''') as ordr
	ON ordr.goods_id = good.id') as t1 (id integer, goods_id integer, client_id integer, sale_amount numeric(12,2))) as a
JOIN sb.clients ON sb.clients.id = a.client_id
GROUP BY sb.clients.surname, sb.clients.name, sb.clients.patronymic, sb.clients.birthdate,
	sb.clients.passport_series, sb.clients.passport_number
ORDER BY 7 DESC, (1,2,3) ASC, 4 ASC;

END
$$  LANGUAGE plpgsql;