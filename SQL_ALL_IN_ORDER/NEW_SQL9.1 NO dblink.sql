SELECT * FROM (
SELECT sa.companies_main.id, sa.companies_main.name, sa.companies_main.country_id
FROM sa.companies_main

UNION

SELECT sb.companies.id, sb.companies.name, sb.companies.country_id
FROM sb.companies
) a
ORDER BY 1