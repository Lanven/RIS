

SELECT t2.name, t2.country_name, t1.summa
FROM (SELECT id, summa 
	FROM sa.companies_monthly 
	WHERE month = 1 
	) as t1
JOIN (SELECT sa.companies_main.id as id, sa.companies_main.name as name, sa.countries.name as country_name
	FROM sa.companies_main
	JOIN sa.countries ON sa.countries.id = sa.companies_main.country_id) as t2
ON t2.id = t1.id
ORDER BY t1.summa DESC, t2.name ASC;

SELECT sa.companies_main.name, sa.countries.name, summa
FROM sa.companies_monthly
JOIN sa.companies_main ON sa.companies_main.id = sa.companies_monthly.id
JOIN sa.countries ON sa.countries.id = sa.companies_main.country_id
WHERE month = 1
ORDER BY summa DESC, sa.companies_main.name ASC;