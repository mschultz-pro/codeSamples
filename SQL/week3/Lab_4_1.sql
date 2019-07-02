SELECT last_name || ' earns ' || TO_Char( salary, 'fm$99,999.00') 
|| ' monthly but wants ' || TO_CHAR(salary * 3, 'fm$99,999.00') || '.' "Dream Salaries"
FROM EMPLOYEES;