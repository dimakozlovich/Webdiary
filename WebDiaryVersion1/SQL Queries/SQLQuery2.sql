Update AppUser
set Grade_id = (select Grade_id from Grades where identificationNumber = 'A205F9B7-6F07-4211-A211-351FFA0B084D')
where UserId = 3