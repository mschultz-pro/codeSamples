SELECT EMPLOYEE_ID, LAST_NAME, SALARY, 
round (salary*1.155)"New Salary", 
round (salary*1.155) - SALARY "Increase "
from EMPLOYEES;