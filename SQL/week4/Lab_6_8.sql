SELECT e.LAST_NAME, e.HIRE_DATE
FROM EMPLOYEES e join EMPLOYEES d on d.LAST_NAME = 'Davies'
WHERE e.HIRE_DATE > d.HIRE_DATE;