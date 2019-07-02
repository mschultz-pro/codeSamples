SELECT job_id "Job",
SUM(DECODE(department_id , 20, salary)) "Department 20",
SUM(DECODE(department_id , 50, salary)) "Department 50",
SUM(DECODE(department_id , 80, salary)) "Department 80",
SUM(DECODE(department_id , 90, salary)) "Department 90",
SUM(salary) "Total"
FROM employees
GROUP BY job_id;