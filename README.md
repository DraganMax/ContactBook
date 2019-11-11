# ContactBook - in progress. #

Project consists of WEB API(ASP.NET), covered by business logic, saving data is being carried out in Microsoft SQL Server database, using Entity Framework(code first approach) and frontend part(UI) with two different frameworks. The main target of this project is to build Web application which would allow user to:
- Add contacts;
- Edit contacts;
- Delete contacts;
- Search contacts by:
   - Name;
   - Surname;
   - Company;
   - Phone number;
   - Email;

## Each contact consists of the following fields:
- First name and last name(required fields);
- one or multiple phone numbers and their types (home, work etc.), must be validated;
- one or multiple e-mail addresses and their types (home, work etc.),  must be validated;
- company, optional;
- notes, optional;
- one or multiple adresses and their types (home, work etc.), validated and normalized through the Geocoding API or similar service;
- birthday, optional.

## Bonus points:

- show map with a contact address on it;
- authorization;
- per user contact book.
