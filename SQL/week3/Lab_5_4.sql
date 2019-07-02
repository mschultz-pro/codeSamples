SELECT ROUND(MAX(salary),0) "Maximum", ROUND(MIN(salary),0) "Minimum",
ROUND(SUM(salary),0) "Sum", ROUND(AVG(SALARY),0) "Average"
FROM EMPLOYEES;