SELECT EMPLOYEE_ID, LAST_NAME, SALARY
FROM EMPLOYEES
where DEPARTMENT_ID in 
(SELECT DEPARTMENT_ID from EMPLOYEES WHERE LAST_NAME like '%u%')
AND SALARY > (SELECT AVG(SALARY) from EMPLOYEES);