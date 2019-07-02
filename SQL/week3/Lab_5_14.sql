SELECT e.FIRST_NAME, e.LAST_NAME, j.JOB_TITLE, j.MIN_SALARY, j.MAX_SALARY
FROM EMPLOYEES e join JOBs j on e.JOB_ID = j.JOB_ID
order by e.LAST_NAME;

Min(DECODE(JOB_ID , to_char(JOB_ID), salary )) "MIN_SALARY",
Max(DECODE(JOB_ID , to_char(JOB_ID), salary )) "MAX_SALARY"