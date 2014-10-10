SELECT orders_month.on_sale_date,sa.categories.title,companies_main.name,model,countries.name,payment_methods.title,sale_types.title,orders_month.sale_amount
from (SELECT goods_id,payment_method_id,sale_type_id,sale_amount,on_sale_date from sa.orders_main_less WHERE month = 1) as orders_month
join sa.goods_main on orders_month.goods_id = goods_main.id
join sa.payment_methods on orders_month.payment_method_id = sa.payment_methods.id
join sa.sale_types on orders_month.sale_type_id = sa.sale_types.id
join sa.companies_main on sa.goods_main.company_id = sa.companies_main.id
join sa.countries on sa.companies_main.country_id = sa.countries.id
join sa.categories on sa.goods_main.category_id = sa.categories.id
order by sa.countries.name, orders_month.on_sale_date, categories.title,companies_main.name,model,sale_types.title,payment_methods.title,orders_month.sale_amount