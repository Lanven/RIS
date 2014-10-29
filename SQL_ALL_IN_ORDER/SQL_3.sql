SELECT surname,name,patronymic,birthdate,phone,email,address
    FROM sa.clients
    ORDER BY birthdate DESC, surname, name, patronymic;