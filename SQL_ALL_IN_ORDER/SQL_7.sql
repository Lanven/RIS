CREATE OR REPLACE FUNCTION query07()
  RETURNS TABLE (
   surnam text,
   nam text,
   patronymi text,
   birthdat date,
   passport_serie text,
   passport_numbe text,
   issue_dat date,
   issue_departmen text
  ) AS
$$
BEGIN

RETURN QUERY
	SELECT surname, name, patronymic, birthdate,
	   passport_series, passport_number, issue_date, issue_department
	FROM sb.clients
	ORDER BY passport_series,passport_number;
END
$$  LANGUAGE plpgsql;