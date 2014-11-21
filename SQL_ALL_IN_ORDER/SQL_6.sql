CREATE OR REPLACE FUNCTION query06(p_month int)
  RETURNS TABLE (
   sale_date date,
   titl text,
   compid integer,
   modell text,
   summa numeric(12,2)
  ) AS
$$
BEGIN

RETURN QUERY
	SELECT on_sale_date, title, comp_id.id, model, sale_amount
	FROM (SELECT id FROM sb.companies) comp_id
	JOIN sb.goods_main ON sb.goods_main.company_id = comp_id.id
	JOIN sb.orders_main ON sb.orders_main.goods_id = sb.goods_main.id
	JOIN sb.categories ON sb.categories.id = sb.goods_main.category_id
	WHERE month = p_month
	ORDER BY 1,2,3,4,5;
END
$$  LANGUAGE plpgsql SECURITY DEFINER;