DROP TABLE employees_micah;
CREATE TABLE employees_micah
(id NUMBER(4) CONSTRAINT employees_micah_id_nn NOT NULL,
last_name VARCHAR2(25),
first_name VARCHAR2(25),
userid VARCHAR2(8),
salary NUMBER(9,2));

INSERT INTO employees_micah
SELECT * FROM MY_EMPLOYEE ;

INSERT INTO EMPLOYEES_MICAH (id,  last_name, first_name, userid, salary)
VALUES (6, 'Shmoe', 'Joe', 'jshmoe', 5);
INSERT INTO EMPLOYEES_MICAH (id,  last_name, first_name, userid, salary)
VALUES (7, 'Sam', 'Sammy', 'ssam', 9999);
INSERT INTO EMPLOYEES_MICAH (id,  last_name, first_name, userid, salary)
VALUES (8, 'Mad', 'Vlad', 'vmad', 1234);
INSERT INTO EMPLOYEES_MICAH (id,  last_name, first_name, userid, salary)
VALUES (9, 'Shelps', 'Micah', 'mshelps', 2551);
INSERT INTO EMPLOYEES_MICAH (id,  last_name, first_name, userid, salary)
VALUES (10, 'Redman', 'Rob', 'rredman', 3);

SELECT * FROM EMPLOYEES_MICAH
WHERE ID > 5;