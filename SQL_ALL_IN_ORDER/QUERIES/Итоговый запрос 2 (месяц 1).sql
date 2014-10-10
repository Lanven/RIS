SELECT ords.on_sale_date, sa.categories.title, companies_main.name, model,
	countries.name, payment_methods.title, sale_types.title, ords.sale_amount
from (SELECT on_sale_date,sale_amount,goods_id,payment_method_id,sale_type_id
	FROM sa.orders_main 
	WHERE  month = 1 and sale_amount <= 1000) ords
join sa.goods_main on ords.goods_id = goods_main.id
join sa.payment_methods on ords.payment_method_id = sa.payment_methods.id
join sa.sale_types on ords.sale_type_id = sa.sale_types.id
join sa.companies_main on sa.goods_main.company_id = sa.companies_main.id
join sa.countries on sa.companies_main.country_id = sa.countries.id
join sa.categories on sa.goods_main.category_id = sa.categories.id
order by 5, 1, 2, 3, 4, 7, 6, 8