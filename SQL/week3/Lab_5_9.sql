SELECT manager_id, MIN(salary) 
from EMPLOYEES
where MANAGER_ID is not null 
GROUP BY MANAGER_ID
HAVING MIN(salary) > 6000
ORDER BY min(SALARY) DESC;
