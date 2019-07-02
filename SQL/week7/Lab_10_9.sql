DROP TABLE INGREDIENTS;
DROP TABLE KITCHENINVENTORY;
DROP TABLE COOKINGRECIPES;

CREATE TABLE KITCHENINVENTORY
(InventoryID INT CONSTRAINT Inventory_fk PRIMARY KEY,
Inv_name VARCHAR2(45),
Inv_type VARCHAR2(45),
Inv_quantity FLOAT);
DESCRIBE KITCHENINVENTORY;

CREATE TABLE COOKINGRECIPES
(RecipeID INT CONSTRAINT Recipe_fk PRIMARY KEY,
Rec_name VARCHAR2(45),
Rec_steps VARCHAR2(500));
DESCRIBE COOKINGRECIPES;

CREATE TABLE INGREDIENTS
(RecipeID_fk INT,
InventoryID_fk INT,
Ing_quantity FLOAT,
FOREIGN KEY (RecipeID_fk) REFERENCES COOKINGRECIPES(RecipeID),
FOREIGN KEY (InventoryID_fk) REFERENCES KITCHENINVENTORY(InventoryID));
DESCRIBE INGREDIENTS;