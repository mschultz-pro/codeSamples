UNDEFINE name
SELECT last_name, hire_date
FROM employees
WHERE department_id = (SELECT department_id
  FROM employees
  WHERE last_name = '&&name')
AND last_name != '&name';
