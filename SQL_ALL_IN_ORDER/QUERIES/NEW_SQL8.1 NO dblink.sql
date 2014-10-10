SELECT * FROM (
SELECT sa.companies_main.id, sa.companies_main.name
FROM sa.companies_main

UNION

SELECT sb.companies.id, sb.companies.name
FROM sb.companies) a
ORDER BY 2