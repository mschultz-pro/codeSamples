SELECT DEPARTMENT_NAME "Departments not in the US"
FROM DEPARTMENTS
WHERE LOCATION_ID = any 
(SELECT LOCATION_ID FROM LOCATIONS 
WHERE COUNTRY_ID = any 
(SELECT COUNTRY_ID FROM COUNTRIES 
WHERE country_name != 'United States of America'));

Select COUNT(LOCATION_ID) "locations not in us"
FROM locations
WHERE COUNTRY_ID = any (SELECT COUNTRY_ID from countries 
WHERE COUNTRY_NAME != 'United States of America');





Select * 
FROM DEPARTMENTS d join LOCATIONS l on d.LOCATION_ID = l.LOCATION_ID;

Select * 
FROM COUNTRIES;