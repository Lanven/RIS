SELECT surname,name,patronymic,birthdate,passport_series,passport_number,issue_date,issue_department
    FROM initial.clientsb
    ORDER BY passport_series,passport_number
