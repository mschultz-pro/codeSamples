SELECT e.LAST_NAME Employee, e.EMPLOYEE_ID Emp#, m.LAST_NAME Manager, m.EMPLOYEE_ID Mgr#
from EMPLOYEES e left join EMPLOYEES m on e.MANAGER_ID = m.EMPLOYEE_ID
order by e.EMPLOYEE_ID;