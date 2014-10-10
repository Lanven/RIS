SELECT sa.companies_main.name, sa.countries.name, summa
FROM sa.companies_main
JOIN (SELECT id,mon4 as summa FROM sa.companies_monthly) as getsum
	on getsum.id = sa.companies_main.id
JOIN sa.countries on sa.countries.id = sa.companies_main.country_id
ORDER BY summa DESC, sa.companies_main.name ASC