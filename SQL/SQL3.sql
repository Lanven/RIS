SELECT surname,name,patronymic,birthdate,phone,email,address
    FROM initial.clients
    ORDER BY birthdate DESC, surname,name,patronymic ASC
