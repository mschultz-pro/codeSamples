select concat (rpad(SUBSTR(LAST_NAME , 1 , 8),8,' ') ,
rpad(' ',round (salary/1000), '*')) "EMPLOYEES_AND_THEIR_SALARIES"
from EMPLOYEES
order by SALARY DESC;
