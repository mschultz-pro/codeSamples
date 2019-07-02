SELECT INITCAP(LAST_NAME)"Name", LENGTH(LAST_NAME)"# of leters in name"
from EMPLOYEES
where upper (LAST_NAME) like upper ('&Letter%')
order by LAST_NAME;