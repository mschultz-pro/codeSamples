SELECT last_name "Employee", salary "Monthly Salary"
FROM employees
WHERE salary < 12000 and salary > 5000
and department_id in (20,50);