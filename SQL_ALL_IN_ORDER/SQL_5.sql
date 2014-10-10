SELECT sa.companies_main.name, sa.countries.name, summa
FROM sa.companies_monthly
JOIN sa.companies_main ON sa.companies_main.id = sa.companies_monthly.id
JOIN sa.countries ON sa.countries.id = sa.companies_main.country_id
WHERE month = 1
ORDER BY summa DESC, sa.companies_main.name ASC;