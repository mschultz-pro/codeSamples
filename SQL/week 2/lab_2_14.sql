select last_name, job_id, salary
From EMPLOYEES
where JOB_ID in ('SA_REP', 'ST_CLERK')
and SALARY not in (2500,3500,7000);