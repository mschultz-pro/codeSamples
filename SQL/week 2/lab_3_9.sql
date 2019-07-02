Select LAST_NAME,(trunc(sysdate,'d')-trunc(HIRE_DATE,'d'))/7 "TENURE"
from EMPLOYEES
where DEPARTMENT_ID = 90
order by TENURE DESC;