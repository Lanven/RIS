SELECT sa.companies_main.name,sa.countries.name,sum(sale_amount)
from sa.companies_main
left join sa.countries on sa.companies_main.country_id = sa.countries.id
left join sa.goods_main on sa.goods_main.company_id = sa.companies_main.id
left join sa.orders_main on sa.orders_main.goods_id = sa.goods_main.id
WHERE sa.countries.name <> 'Российская Федерация' and (EXTRACT(MONTH FROM on_sale_date)=1 or sale_amount is null)
GROUP BY sa.companies_main.name,sa.countries.name
ORDER BY sum(sale_amount) DESC NULLS FIRST, sa.companies_main.name ASC 