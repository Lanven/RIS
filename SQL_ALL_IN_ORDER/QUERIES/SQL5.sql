SELECT initial.companies.name,initial.countries.name,sum(sale_amount)
from initial.companies
left join initial.countries on initial.companies.country_id = initial.countries.id
left join initial.goods on initial.goods.company_id = initial.companies.id
left join initial.orders on initial.orders.goods_id = initial.goods.id
WHERE initial.countries.name <> 'Российская Федерация' and (EXTRACT(MONTH FROM on_sale_date)=12 or sale_amount is null)
GROUP BY initial.companies.name,initial.countries.name
ORDER BY sum(sale_amount) DESC NULLS FIRST, initial.companies.name ASC 