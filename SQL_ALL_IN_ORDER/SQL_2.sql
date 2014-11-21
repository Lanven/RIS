CREATE OR REPLACE FUNCTION query02(p_month int)
  RETURNS TABLE (    
   sale_date date,
   category text,
   company text,
   modell text,
   country text,
   payment_method text,
   sale_type text,
   summa numeric(12,2)
   ) AS
$$
BEGIN

RETURN QUERY
	SELECT ords.on_sale_date as sale_date, sa.categories.title as category, companies.name as company,
	model as modell, countries.name as country, payment_methods.title as payment_method,
	sale_types.title as sale_type, ords.sale_amount as summa
	from (SELECT on_sale_date,sale_amount,goods_id,payment_method_id,sale_type_id
		FROM sa.orders_main 
		WHERE month = p_month and sale_amount <= 1000) ords
	join sa.goods_main on ords.goods_id = goods_main.id
	join sa.payment_methods on ords.payment_method_id = sa.payment_methods.id
	join sa.sale_types on ords.sale_type_id = sa.sale_types.id
	join sa.companies on sa.goods_main.company_id = sa.companies.id
	join sa.countries on sa.companies.country_id = sa.countries.id
	join sa.categories on sa.goods_main.category_id = sa.categories.id
	order by 5, 1, 2, 3, 4, 7, 6, 8;

END
$$  LANGUAGE plpgsql SECURITY DEFINER;