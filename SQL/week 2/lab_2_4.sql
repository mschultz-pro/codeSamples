SELECT LAST_NAME, JOB_ID, HIRE_DATE
FROM employees
WHERE LAST_NAME IN ('Matos', 'Taylor')
Order by HIRE_DATE asc;