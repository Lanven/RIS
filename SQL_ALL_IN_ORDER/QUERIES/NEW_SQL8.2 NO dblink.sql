SELECT sb.companies.name, sb.countries.name, head_full_name, phone, address, bank_details
FROM sb.companies
JOIN sb.countries ON sb.countries.id = sb.companies.country_id
WHERE sb.companies.id = 220