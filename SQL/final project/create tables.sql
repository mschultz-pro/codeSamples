DROP TABLE SUPPLIES;
DROP TABLE Visits;
DROP TABLE PATIENTS;
DROP TABLE Staff;
DROP TABLE Departments;
DROP TABLE HOSPITALS;

CREATE TABLE Hospitals 
(HospitalID INT CONSTRAINT HospitalID_PK PRIMARY KEY,
Hospital_Name VARCHAR(45) NOT NULL,
Hospital_Country VARCHAR(45) NOT NULL,
Hospital_Address VARCHAR(45),
Hospital_City VARCHAR(45),
Hospital_Zip INT,
Hospital_Primary_Language VARCHAR(45));

CREATE TABLE Departments
(DepartmentID INT UNIQUE NOT NULL,
FK_HospitalID INT NOT NULL,
Department_Name VARCHAR(45) NOT NULL,
CONSTRAINT Composit_PK PRIMARY KEY (DepartmentID,FK_HospitalID),
CONSTRAINT fk_Departments_Hospitals1 FOREIGN KEY 
  (FK_HospitalID) REFERENCES Hospitals (HospitalID));

CREATE TABLE Staff
(StaffID INT CONSTRAINT StaffID_PK PRIMARY KEY,
Staff_First_Name VARCHAR(45) NOT NULL,
Staff_Last_Name VARCHAR(45) NOT NULL,
Staff_Phone INT,
Staff_Email VARCHAR(45),
Staff_Addess VARCHAR(45),
Staff_City VARCHAR(45),
Staff_Zip VARCHAR(45),
FK_DepartmentID INT NOT NULL,
Staff_Office_location VARCHAR(45),
CONSTRAINT fk_Staff_Departments FOREIGN KEY 
  (FK_DepartmentID) REFERENCES Departments (DepartmentID));

CREATE TABLE Patients
(PatientID INT CONSTRAINT PatientID_PK PRIMARY KEY,
Patient_First_Name VARCHAR(45) NOT NULL,
Patient_Last_Name VARCHAR(45) NOT NULL,
Patient_DOB TIMESTAMP ,
Patient_Gender VARCHAR(45) NOT NULL,
Patient_Phone INT,
Patient_Email VARCHAR(45),
Patient_Address VARCHAR(45),
Patient_City VARCHAR(45),
Patient_Zip INT);

CREATE TABLE Visits
(VisitID INT CONSTRAINT VisitID_PK PRIMARY KEY,
Visit_Date TIMESTAMP NOT NULL,
Visit_Discharge_Date TIMESTAMP,
Visit_Cost VARCHAR(45),
FK_PatientID INT NOT NULL,
FK_DepartmentID INT NOT NULL,
CONSTRAINT fk_Visits_Patients1 FOREIGN KEY 
  (FK_PatientID) REFERENCES Patients (PatientID),
CONSTRAINT fk_Visits_Departments1 FOREIGN KEY
  (FK_DepartmentID) REFERENCES Departments (DepartmentID));

CREATE TABLE Supplies
(SupplyID INT CONSTRAINT SupplyID_PK PRIMARY KEY,
Supply_Name VARCHAR(45) NOT NULL,
Supply_Cost VARCHAR(45),
Supply_Quantiy_Used INT,
Supply_Type VARCHAR(45),
FK_VisitID INT NOT NULL,
CONSTRAINT fk_Supplies_Visits FOREIGN KEY
  (FK_VisitID) REFERENCES Visits (VisitID));
  
INSERT INTO Hospitals (HospitalID, Hospital_Name, Hospital_Country, Hospital_Address, Hospital_City, Hospital_Zip, Hospital_Primary_Language) 
               VALUES (1000,       'Magic Medicine','USA',          '123 Awesome St', 'Accident',    21520,        'English');

INSERT INTO Hospitals (HospitalID, Hospital_Name, Hospital_Country, Hospital_Address, Hospital_City, Hospital_Zip, Hospital_Primary_Language) 
               VALUES (1001,       'Happy Healthy','USA',          '42 Second St',    'Dogtown',     35068,        'English');
            
INSERT INTO Hospitals (HospitalID, Hospital_Name, Hospital_Country, Hospital_Address, Hospital_City, Hospital_Zip, Hospital_Primary_Language) 
               VALUES (1002,       'Brave',       'USA',            '564 Hospital St','Fearnot',     17968,        'English');
               
INSERT INTO Hospitals (HospitalID, Hospital_Name, Hospital_Country, Hospital_Address, Hospital_City, Hospital_Zip, Hospital_Primary_Language) 
               VALUES (1003,       '1st OutReachMD','Mongolia',     '1 First st',     'Moron',        '',          'Mongolian');
               
INSERT INTO Hospitals (HospitalID, Hospital_Name, Hospital_Country, Hospital_Address, Hospital_City, Hospital_Zip, Hospital_Primary_Language) 
               VALUES (1004,       'Serious Care','Belgium',        '66 Stern Dr',    'Silly',       7830,         'Dutch');
               
INSERT INTO Hospitals (HospitalID, Hospital_Name, Hospital_Country, Hospital_Address, Hospital_City, Hospital_Zip, Hospital_Primary_Language) 
               VALUES (1005,       'Supper Meidical','Turkey',      '5649 Hero St',   'Batman',      72000,        'Turkish');
               
INSERT INTO Hospitals (HospitalID, Hospital_Name, Hospital_Country, Hospital_Address, Hospital_City, Hospital_Zip, Hospital_Primary_Language) 
               VALUES (1006,       'Mediocer Medicine','USA',       '123 LetDown St', 'Accident',    21520,        'English');

INSERT INTO Hospitals (HospitalID, Hospital_Name, Hospital_Country, Hospital_Address, Hospital_City, Hospital_Zip, Hospital_Primary_Language) 
               VALUES (1007,       'Crucial Compashion','Uganda',   '646 third St',   'Kampala',     '',           'English');
            
INSERT INTO Hospitals (HospitalID, Hospital_Name, Hospital_Country, Hospital_Address, Hospital_City, Hospital_Zip, Hospital_Primary_Language) 
               VALUES (1008,'Wyoming County Community Health System','USA','400 N Main St','Warsaw', 14569,        'English');
               
INSERT INTO Hospitals (HospitalID, Hospital_Name, Hospital_Country, Hospital_Address, Hospital_City, Hospital_Zip, Hospital_Primary_Language) 
               VALUES (1009,       '9th OutReachMD','Nepal',        '1 First st',     'Kathmandu',   '',           'Nepali');
               
INSERT INTO Hospitals (HospitalID, Hospital_Name, Hospital_Country, Hospital_Address, Hospital_City, Hospital_Zip, Hospital_Primary_Language) 
               VALUES (1010,       'No1 Hospital','kazakhstan ',    '66 apple Dr',    'almaty',      '',           'kazakh');




INSERT INTO Departments (DepartmentID, FK_HospitalID, Department_Name) 
               VALUES (1000, 1002, 'Professional training center');
               
INSERT INTO Departments (DepartmentID, FK_HospitalID, Department_Name) 
               VALUES (1001, 1002, 'Marketing ');
               
INSERT INTO Departments (DepartmentID, FK_HospitalID, Department_Name) 
               VALUES (1002, 1002, 'Pediatric center');
               
INSERT INTO Departments (DepartmentID, FK_HospitalID, Department_Name) 
               VALUES (1003, 1002, 'Professional training center');
               
INSERT INTO Departments (DepartmentID, FK_HospitalID, Department_Name) 
               VALUES (1004, 1003, 'Executive administration');
               
INSERT INTO Departments (DepartmentID, FK_HospitalID, Department_Name) 
               VALUES (1005, 1003, 'Accounting');
               
INSERT INTO Departments (DepartmentID, FK_HospitalID, Department_Name) 
               VALUES (1006, 1003, 'Critical care');
               
INSERT INTO Departments (DepartmentID, FK_HospitalID, Department_Name) 
               VALUES (1007, 1004, 'Information systems');
               
INSERT INTO Departments (DepartmentID, FK_HospitalID, Department_Name) 
               VALUES (1008, 1004, 'Critical care');
               
INSERT INTO Departments (DepartmentID, FK_HospitalID, Department_Name) 
               VALUES (1009, 1004, 'Pediatric center');
               
INSERT INTO Departments (DepartmentID, FK_HospitalID, Department_Name) 
               VALUES (1010, 1004, 'Professional training center');





INSERT INTO Staff (StaffID, Staff_First_Name, Staff_Last_Name, Staff_Phone, Staff_Email, Staff_Addess, Staff_City, Staff_Zip, FK_DepartmentID, Staff_Office_location) 
           VALUES (1000,    'Mayte',          'Treasure',      1234567890,  'Terson59@rhyta.com','8782 N. Wintergreen Circle','Vicksburg',39180,1000,'East Wing');

INSERT INTO Staff (StaffID, Staff_First_Name, Staff_Last_Name, Staff_Phone, Staff_Email, Staff_Addess, Staff_City, Staff_Zip, FK_DepartmentID, Staff_Office_location) 
           VALUES (1001,    'Kleio',          'Ishani',        1234567890,  'Eforst56@superrito.com','8 East Cactus Drive','Reynoldsburg',32137,1001,'Basement');

INSERT INTO Staff (StaffID, Staff_First_Name, Staff_Last_Name, Staff_Phone, Staff_Email, Staff_Addess, Staff_City, Staff_Zip, FK_DepartmentID, Staff_Office_location) 
           VALUES (1002,    'Divya',          'Tiwlip',        1234567890,  'Ablemplaid48@cuvox.de','115 E. Rock Creek Circle','Palm Coast',32137,1002,'Top Floor');

INSERT INTO Staff (StaffID, Staff_First_Name, Staff_Last_Name, Staff_Phone, Staff_Email, Staff_Addess, Staff_City, Staff_Zip, FK_DepartmentID, Staff_Office_location) 
           VALUES (1003,    'Roland',         'Sebastian',     1234567890,  'Abse1957@einrot.com','679 Pacific Dr.','Reading',01867,1003,'');

INSERT INTO Staff (StaffID, Staff_First_Name, Staff_Last_Name, Staff_Phone, Staff_Email, Staff_Addess, Staff_City, Staff_Zip, FK_DepartmentID, Staff_Office_location) 
           VALUES (1004,    'Indira',         'Rajeev',        1234567890,  'Thut1953@superrito.com','43 West Shady Court','Snohomish',98290,1004,'Main Building');

INSERT INTO Staff (StaffID, Staff_First_Name, Staff_Last_Name, Staff_Phone, Staff_Email, Staff_Addess, Staff_City, Staff_Zip, FK_DepartmentID, Staff_Office_location) 
           VALUES (1005,    'Ionas',          'Filipina',      1234567890,  'Derry1942@rhyta.com','721 Oak Lane','Poughkeepsie',12601,1005,'Main Building');

INSERT INTO Staff (StaffID, Staff_First_Name, Staff_Last_Name, Staff_Phone, Staff_Email, Staff_Addess, Staff_City, Staff_Zip, FK_DepartmentID, Staff_Office_location) 
           VALUES (1006,    'Nirmal',         'Doncho',        1234567890,  'Gorry1980@fleckens.hu','24 Paris Hill Road','South Portland',04106,1006,'Basement');

INSERT INTO Staff (StaffID, Staff_First_Name, Staff_Last_Name, Staff_Phone, Staff_Email, Staff_Addess, Staff_City, Staff_Zip, FK_DepartmentID, Staff_Office_location) 
           VALUES (1007,    'Uranus',         'Eusebius',      1234567890,  'Capt1929@rhyta.com','533 Bank Lane','Williamsburg',23185,1007,'East Wing');

INSERT INTO Staff (StaffID, Staff_First_Name, Staff_Last_Name, Staff_Phone, Staff_Email, Staff_Addess, Staff_City, Staff_Zip, FK_DepartmentID, Staff_Office_location) 
           VALUES (1008,    'Zulfaqar',       'Uduak',         1234567890,  'Olde1931@einrot.com','9192 Sussex Dr.','Camas',98607,1008,'Secound Building');

INSERT INTO Staff (StaffID, Staff_First_Name, Staff_Last_Name, Staff_Phone, Staff_Email, Staff_Addess, Staff_City, Staff_Zip, FK_DepartmentID, Staff_Office_location) 
           VALUES (1009,    'Patroclus',      'Hakan',         1234567890,  'Amen1978@superrito.com','718 Littleton Road','Fort Washington',20744,1009,'Main Building');




INSERT INTO Patients (PatientID, Patient_First_Name, Patient_Last_Name, Patient_DOB, Patient_Gender, Patient_Phone, Patient_Email, Patient_Address, Patient_City, Patient_Zip) 
              VALUES (1000,      'Vidya',            'Aleksey','27-Oct-2037 06:28:20','Female',1234567890,'Spond1983@cuvox.de',' 386 West Drive','Kernersville',27284);

INSERT INTO Patients (PatientID, Patient_First_Name, Patient_Last_Name, Patient_DOB, Patient_Gender, Patient_Phone, Patient_Email, Patient_Address, Patient_City, Patient_Zip) 
              VALUES (1001,      'Widald',            'Louise','19-Feb-1972 07:25:24','Female',1234567890,'Havis1969@dayrep.com','36 North Smoky Hollow Ave.','Olympia',98512);

INSERT INTO Patients (PatientID, Patient_First_Name, Patient_Last_Name, Patient_DOB, Patient_Gender, Patient_Phone, Patient_Email, Patient_Address, Patient_City, Patient_Zip) 
              VALUES (1002,      'Khasan',            'Taliesin','31-Dec-2010 02:51:26','Female',1234567890,'Eass1945@superrito.com','45 Marsh Rd.','Merrimack',03054);
              
INSERT INTO Patients (PatientID, Patient_First_Name, Patient_Last_Name, Patient_DOB, Patient_Gender, Patient_Phone, Patient_Email, Patient_Address, Patient_City, Patient_Zip) 
              VALUES (1003,      'Prateek',            'Hyacinth','17-Nov-2002 11:12:27','Female',1234567890,'Shmidecir@armyspy.com','427 University Ave.','Cincinnati',45211);

INSERT INTO Patients (PatientID, Patient_First_Name, Patient_Last_Name, Patient_DOB, Patient_Gender, Patient_Phone, Patient_Email, Patient_Address, Patient_City, Patient_Zip) 
              VALUES (1004,      'Aoife',            'Iliyana','26-Nov-2037 07:12:22','Female',1234567890,'Thars1990@rhyta.com','8246 Beaver Ridge Ave.','Hamilton',45011);

INSERT INTO Patients (PatientID, Patient_First_Name, Patient_Last_Name, Patient_DOB, Patient_Gender, Patient_Phone, Patient_Email, Patient_Address, Patient_City, Patient_Zip) 
              VALUES (1005,      'Dominik',            'Jeronim','23-Jan-1972 10:16:59','Female',1234567890,'Buddard1929@gustr.com','8782 N. Wintergreen Circle','Vicksburg',39180);

INSERT INTO Patients (PatientID, Patient_First_Name, Patient_Last_Name, Patient_DOB, Patient_Gender, Patient_Phone, Patient_Email, Patient_Address, Patient_City, Patient_Zip) 
              VALUES (1006,      'Mordad',            'Dip','09-Jun-1984 10:51:59','Female',1234567890,'Comee1977@cuvox.de','45 Briarwood Ave.','Providence',02904);

INSERT INTO Patients (PatientID, Patient_First_Name, Patient_Last_Name, Patient_DOB, Patient_Gender, Patient_Phone, Patient_Email, Patient_Address, Patient_City, Patient_Zip) 
              VALUES (1007,      'Fleur',            ' Ireneus','23-Dec-2028 01:10:25','Female',1234567890,'Witiet41@teleworm.us','19 Jones Drive','Rosemount',55068);

INSERT INTO Patients (PatientID, Patient_First_Name, Patient_Last_Name, Patient_DOB, Patient_Gender, Patient_Phone, Patient_Email, Patient_Address, Patient_City, Patient_Zip) 
              VALUES (1008,      'Duha',            'Keitha','24-Jun-1994 02:58:56','Female',1234567890,'Harl1984@jourrapide.com','823 Union St.','Woburn',01801);

INSERT INTO Patients (PatientID, Patient_First_Name, Patient_Last_Name, Patient_DOB, Patient_Gender, Patient_Phone, Patient_Email, Patient_Address, Patient_City, Patient_Zip) 
              VALUES (1009,      'Ana',            'Alard','08-Dec-1975 12:52:54','Female',1234567890,'Fals1934@dayrep.com','6 Market Lane','Irvington',07111);





INSERT INTO Visits (VisitID, Visit_Date, Visit_Discharge_Date, Visit_Cost, FK_PatientID, FK_DepartmentID) 
            VALUES (1000,    '18-Jul-1988 10:47:07','04-Dec-2006 07:37:18',4643,1000,    1008  );
            
INSERT INTO Visits (VisitID, Visit_Date, Visit_Discharge_Date, Visit_Cost, FK_PatientID, FK_DepartmentID) 
            VALUES (1001,    '14-Jan-1987 06:31:43', '30-Jun-1998 05:41:45',1012,1001,   1008  );
            
INSERT INTO Visits (VisitID, Visit_Date, Visit_Discharge_Date, Visit_Cost, FK_PatientID, FK_DepartmentID) 
            VALUES (1002,    '14-Jan-2001 01:02:11','',        '',         1002,         1008 );
            
INSERT INTO Visits (VisitID, Visit_Date, Visit_Discharge_Date, Visit_Cost, FK_PatientID, FK_DepartmentID) 
            VALUES (1003,    '18-Jun-1998 03:56:38','',        '',         1003,           1009  );
            
INSERT INTO Visits (VisitID, Visit_Date, Visit_Discharge_Date, Visit_Cost, FK_PatientID, FK_DepartmentID) 
            VALUES (1004,    '25-Jan-1985 10:04:19','02-Dec-1998 12:06:44',619881,1004,  1009  );
            
INSERT INTO Visits (VisitID, Visit_Date, Visit_Discharge_Date, Visit_Cost, FK_PatientID, FK_DepartmentID)
            VALUES (1005,    '25-Dec-2002 11:34:33','',        '',         1005,         1006  );
            
INSERT INTO Visits (VisitID, Visit_Date, Visit_Discharge_Date, Visit_Cost, FK_PatientID, FK_DepartmentID) 
            VALUES (1006,    '17-Oct-1996 12:51:26','18-Oct-1996 12:51:26',10000,1006,   1006  );
            
INSERT INTO Visits (VisitID, Visit_Date, Visit_Discharge_Date, Visit_Cost, FK_PatientID, FK_DepartmentID) 
            VALUES (1007,    '30-May-2013 06:16:54','30-Jun-2013 11:16:54',61891,1007,   1006  );
          
INSERT INTO Visits (VisitID, Visit_Date, Visit_Discharge_Date, Visit_Cost, FK_PatientID, FK_DepartmentID) 
            VALUES (1008,    '07-Dec-1999 10:30:27','14-Dec-1999 08:30:27',99,1008,      1002  );
            
INSERT INTO Visits (VisitID, Visit_Date, Visit_Discharge_Date, Visit_Cost, FK_PatientID, FK_DepartmentID) 
            VALUES (1009,    '17-Jun-2003 11:45:06','17-Jun-2003 11:45:06','',1009,      1002  );
            
            
            
INSERT INTO Supplies (SupplyID, Supply_Name, Supply_Cost, Supply_Quantiy_Used, Supply_Type, FK_VisitID) 
              VALUES (1000,     'Bandages',  2,           14,                  'Wound Care',1000);

INSERT INTO Supplies (SupplyID, Supply_Name, Supply_Cost, Supply_Quantiy_Used, Supply_Type, FK_VisitID) 
              VALUES (1001,     'Gauze',     13,          100,                 'Wound Care',1001);

INSERT INTO Supplies (SupplyID, Supply_Name, Supply_Cost, Supply_Quantiy_Used, Supply_Type, FK_VisitID)  
              VALUES (1002,     'Ointments', 7,           3,                   'Wound Care',1002);

INSERT INTO Supplies (SupplyID, Supply_Name, Supply_Cost, Supply_Quantiy_Used, Supply_Type, FK_VisitID)  
              VALUES (1003,     'Oxygen Masks',120,       1,                   'Respiratory',1003);

INSERT INTO Supplies (SupplyID, Supply_Name, Supply_Cost, Supply_Quantiy_Used, Supply_Type, FK_VisitID) 
              VALUES (1004,     'Oxygen Tank',185,        3,                   'Respiratory',1004);

INSERT INTO Supplies (SupplyID, Supply_Name, Supply_Cost, Supply_Quantiy_Used, Supply_Type, FK_VisitID) 
              VALUES (1005,     'Scalpel',   27,          5,                   'Surgical',  1005);

INSERT INTO Supplies (SupplyID, Supply_Name, Supply_Cost, Supply_Quantiy_Used, Supply_Type, FK_VisitID) 
              VALUES (1006,     'Mask',      1,           50,                  'Surgical',  1006);

INSERT INTO Supplies (SupplyID, Supply_Name, Supply_Cost, Supply_Quantiy_Used, Supply_Type, FK_VisitID) 
              VALUES (1007,     'Morphine',  1000,        2,                   'Emergency and Trauma',1007);

INSERT INTO Supplies (SupplyID, Supply_Name, Supply_Cost, Supply_Quantiy_Used, Supply_Type, FK_VisitID) 
              VALUES (1008,     'Splint',    57,          1,                   'Emergency and Trauma',1008);

INSERT INTO Supplies (SupplyID, Supply_Name, Supply_Cost, Supply_Quantiy_Used, Supply_Type, FK_VisitID) 
              VALUES (1009,     'Cast',      300,         2,                   'Emergency and Trauma',1009);