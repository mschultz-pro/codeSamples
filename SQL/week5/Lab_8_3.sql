SELECT * FROM
(SELECT job_id, department_id
FROM employees
minus
SELECT job_id, department_id
FROM employees
WHERE department_id not in (20,50,10) or department_id is null)
ORDER BY
case department_id
when 10 then 1
when 50 then 2
when 20 then 3
else 4 end;
