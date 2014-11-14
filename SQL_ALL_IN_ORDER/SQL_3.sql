CREATE OR REPLACE FUNCTION query03()
  RETURNS TABLE (
   surnam text,
   nam text,
   patronymi text,
   birthdat date,
   phon text,
   emai text,
   addres text
  ) AS
$$
BEGIN
   RETURN QUERY
SELECT surname, name, patronymic, birthdate, phone, email, address
    FROM sa.clients
    ORDER BY birthdate DESC, surname, name, patronymic;

END
$$  LANGUAGE plpgsql;