SELECT last_name,department_id,TO_CHAR(null) "DEPARTMENT_NAME"
FROM employees
UNION
SELECT TO_CHAR(null),department_id,DEPARTMENT_NAME
FROM departments;