explain analyze SELECT sa.companies_monthly.name, sa.countries.name, mon1 as summa 
FROM sa.companies_monthly
JOIN sa.countries on sa.countries.id  = sa.companies_monthly.country_id
ORDER BY summa DESC, sa.companies_monthly.name ASC;