SELECT sa.countries.name,sum(sale_amount)
from sa.orders_main
right join sa.goods_main on sa.orders_main.goods_id=goods_main.id
right join sa.companies_main on sa.goods_main.company_id = sa.companies_main.id
right join sa.countries on sa.companies_main.country_id = sa.countries.id
WHERE sa.countries.name <> 'Российская Федерация'
GROUP BY sa.countries.name
ORDER BY sum(sale_amount) DESC NULLS LAST, sa.countries.name ASC 