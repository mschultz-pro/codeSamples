DROP TABLE EMPLOYEES2;
CREATE TABLE EMPLOYEES2 AS
SELECT employee_id id, first_name, last_name, salary,
department_id dept_id
FROM employees;
DESCRIBE EMPLOYEES2;