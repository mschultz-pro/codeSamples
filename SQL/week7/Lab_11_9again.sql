DROP SEQUENCE InventoryID;
CREATE SEQUENCE InventoryID
START WITH 1001
INCREMENT BY 1
MAXVALUE 9999;

CREATE INDEX Inv_name_index ON KITCHENINVENTORY (Inv_name);

DROP SEQUENCE RecipeID;
CREATE SEQUENCE RecipeID
START WITH 1001
INCREMENT BY 1
MAXVALUE 9999;

CREATE INDEX Rec_name_index ON COOKINGRECIPES (Rec_name);

INSERT INTO KITCHENINVENTORY (InventoryID, Inv_name, Inv_type, Inv_quantity) 
                             VALUES (InventoryID.nextval, 'Chease', 'dairy', 10);
INSERT INTO KITCHENINVENTORY VALUES (InventoryID.nextval, 'Bread', 'starch', 20);
INSERT INTO KITCHENINVENTORY VALUES (InventoryID.nextval, 'Butter', 'dairy', 14);
INSERT INTO KITCHENINVENTORY VALUES (InventoryID.nextval, 'Milk', 'dairy', 0);
INSERT INTO KITCHENINVENTORY VALUES (InventoryID.nextval, 'Tomato Soup Can', 'dairy', 1);
INSERT INTO KITCHENINVENTORY VALUES (InventoryID.nextval, 'Can of Tuna', 'meat', 15);
INSERT INTO KITCHENINVENTORY VALUES (InventoryID.nextval, 'Mayo', 'dairy', 7);
INSERT INTO KITCHENINVENTORY VALUES (InventoryID.nextval, 'Ramen Noodle Pack', 'processed', 9999);
INSERT INTO KITCHENINVENTORY VALUES (InventoryID.nextval, 'Noodles', 'processed', 9);

INSERT INTO COOKINGRECIPES(RecipeID, Rec_name, Rec_steps) 
                           VALUES (RecipeID.nextval, 'Grilled Chease', 'Butter bread on one side. Grill bread butter side down. Add chease to bread. Serve.');
INSERT INTO COOKINGRECIPES VALUES (RecipeID.nextval, 'Tomato Soup', 'Mix equal parts water and milk with one can of soup. Heat for 10 minutes. Serve');
INSERT INTO COOKINGRECIPES VALUES (RecipeID.nextval, 'Tuna Sandwitch', 'Mix tuna and mayo. Spread on bread. Sever');
INSERT INTO COOKINGRECIPES VALUES (RecipeID.nextval, 'Ramen Noodles', 'Put noodles in pan with 2 cups water. Heat till boil for 5 minutes. server with included seasoning');
INSERT INTO COOKINGRECIPES VALUES (RecipeID.nextval, 'Mac n Chease', 'Mix chease, milk and water. Heat till desired consitancy, add noodles. Sever');

INSERT INTO INGREDIENTS(RecipeID_fk, InventoryID_fk, Ing_quantity) 
                        VALUES(1001, 1001, 1);
INSERT INTO INGREDIENTS VALUES(1001, 1002, 2);
INSERT INTO INGREDIENTS VALUES(1001, 1003, 2);
INSERT INTO INGREDIENTS VALUES(1002, 1004, 1);
INSERT INTO INGREDIENTS VALUES(1002, 1002, 2);
INSERT INTO INGREDIENTS VALUES(1002, 1003, 2);
INSERT INTO INGREDIENTS VALUES(1003, 1002, 2);
INSERT INTO INGREDIENTS VALUES(1003, 1006, 2);
INSERT INTO INGREDIENTS VALUES(1003, 1007, 1);
INSERT INTO INGREDIENTS VALUES(1004, 1008, 1);
INSERT INTO INGREDIENTS VALUES(1005, 1001, 2);
INSERT INTO INGREDIENTS VALUES(1005, 1004, 1);
INSERT INTO INGREDIENTS VALUES(1005, 1009, 2);



SELECT count(i.INVENTORYID_FK) "number of times used", i.ING_QUANTITY, 
count(i.INVENTORYID_FK)  * i.ING_QUANTITY "total needed", k.INV_NAME , k.INV_QUANTITY
FROM KITCHENINVENTORY k
JOIN INGREDIENTS i on k.INVENTORYID = i.INVENTORYID_FK
GROUP BY k.INV_NAME, i.ING_QUANTITY, k.INV_QUANTITY;

SELECT count(i.RECIPEID_FK) "nuber of ingredients", c.REC_NAME
FROM COOKINGRECIPES c
join INGREDIENTS i on c.RECIPEID = i.RECIPEID_FK
GROUP BY c.RECIPEID, c.REC_NAME;

