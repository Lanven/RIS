SELECT on_sale_date,initial.categories.title,companies.name,model,countries.name,payment_methods.title,sale_types.title,sale_amount
from initial.orders
join initial.goods on initial.orders.goods_id=goods.id
join initial.payment_methods on initial.orders.payment_method_id = initial.payment_methods.id
join initial.sale_types on initial.orders.sale_type_id = initial.sale_types.id
join initial.companies on initial.goods.company_id = initial.companies.id
join initial.countries on initial.companies.country_id = initial.countries.id
join initial.categories on initial.goods.category_id = initial.categories.id
where initial.countries.name <> 'Российская Федерация' and EXTRACT(MONTH FROM on_sale_date)=1 and sale_amount <= 1000
order by initial.countries.name, on_sale_date, categories.title,companies.name,model,sale_types.title,payment_methods.title,sale_amount