SELECT initial.countries.name,sum(sale_amount)
from initial.orders
right join initial.goods on initial.orders.goods_id=goods.id
right join initial.companies on initial.goods.company_id = initial.companies.id
right join initial.countries on initial.companies.country_id = initial.countries.id
WHERE initial.countries.name <> 'Российская Федерация'
GROUP BY initial.countries.name
ORDER BY sum(sale_amount) DESC NULLS LAST, initial.countries.name ASC 