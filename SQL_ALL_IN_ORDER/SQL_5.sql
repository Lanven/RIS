SELECT sa.companies.name, sa.countries.name, s.summa
FROM (select id, summa FROM sa.companies_monthly WHERE month = 11) s
JOIN sa.companies ON sa.companies.id = s.id
JOIN sa.countries ON sa.countries.id = sa.companies.country_id
ORDER BY summa DESC, sa.companies.name ASC;

SELECT sa.companies.name, sa.countries.name, sa.companies_monthly.summa
FROM sa.companies_monthly
JOIN sa.companies ON sa.companies.id = sa.companies_monthly.id
JOIN sa.countries ON sa.countries.id = sa.companies.country_id
WHERE month = 11
ORDER BY sa.companies_monthly.summa DESC, sa.companies.name ASC;
