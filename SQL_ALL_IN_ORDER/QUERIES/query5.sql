SELECT sa.companies_main.name, sa.countries.name, subquery.summa
FROM sa.companies_main
JOIN (SELECT company_id, sum(sale_amount)as summa 
	FROM sa.orders_main_1
	RIGHT JOIN sa.goods_main on sa.goods_main.id = sa.orders_main_1.goods_id
	GROUP BY company_id) 
	as subquery on subquery.company_id = sa.companies_main.id
JOIN sa.countries on sa.countries.id = sa.companies_main.country_id