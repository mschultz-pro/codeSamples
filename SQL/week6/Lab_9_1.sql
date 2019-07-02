drop table my_employee;
CREATE TABLE my_employee
(id NUMBER(4) CONSTRAINT my_employee_id_nn NOT NULL,
last_name VARCHAR2(25),
first_name VARCHAR2(25),
userid VARCHAR2(8),
salary NUMBER(9,2));

INSERT INTO my_employee (id,  last_name, first_name, userid, salary)
VALUES (1, 'Patel', 'Ralph', 'rpatel', 1000);

INSERT INTO my_employee (id,  last_name, first_name, userid, salary)
VALUES (3, 'Drexler', 'Ben', 'bbiri', 1100);

INSERT INTO my_employee (id,  last_name, first_name, userid, salary)
VALUES (4, 'Newman', 'Chad', 'cnewman', 1000);

INSERT INTO my_employee (id,  last_name, first_name, userid, salary)
VALUES (5, 'Ropeburn', 'Audrey', 'aropebur', 1550);

SELECT * FROM my_employee;

SAVEPOINT SAVE_1;

DELETE FROM MY_EMPLOYEE;

SELECT * FROM MY_EMPLOYEE;

ROLLBACK TO SAVEPOINT SAVE_1;