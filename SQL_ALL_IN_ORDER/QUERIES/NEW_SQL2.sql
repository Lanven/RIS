SELECT on_sale_date,sa.categories.title,companies_main.name,model,countries.name,payment_methods.title,sale_types.title,sale_amount
from sa.orders_main
join sa.goods_main on sa.orders_main.goods_id = goods_main.id
join sa.payment_methods on sa.orders_main.payment_method_id = sa.payment_methods.id
join sa.sale_types on sa.orders_main.sale_type_id = sa.sale_types.id
join sa.companies_main on sa.goods_main.company_id = sa.companies_main.id
join sa.countries on sa.companies_main.country_id = sa.countries.id
join sa.categories on sa.goods_main.category_id = sa.categories.id
where EXTRACT(MONTH FROM on_sale_date)=1 and sale_amount <= 1000
order by sa.countries.name, on_sale_date, categories.title,companies_main.name,model,sale_types.title,payment_methods.title,sale_amount