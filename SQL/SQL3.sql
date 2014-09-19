SELECT surname,name,patronymic,birthdate,phone,email,address
    FROM initial.clientsa
    ORDER BY birthdate DESC, (surname,name,patronymic) ASC;
