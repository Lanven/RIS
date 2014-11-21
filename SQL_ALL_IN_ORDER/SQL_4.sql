CREATE OR REPLACE FUNCTION query04()
  RETURNS TABLE (
   nam text,
   summ numeric(12,2)

  ) AS
$$
BEGIN
   RETURN QUERY
	SELECT name, summa 
	FROM sa.countries
	ORDER BY summa DESC NULLS LAST, name ASC;
END
$$  LANGUAGE plpgsql SECURITY DEFINER;