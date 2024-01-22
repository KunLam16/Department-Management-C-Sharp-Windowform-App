drop database store
Use Master
go
Create database [store]
go
use [store]
go
--DepartmentID, DepartmentName, AccountName, EmailAddress, Password, Tel, Location
Create table Department
(
DepartmentID int identity(1,1) NOT NULL constraint PK_Department primary key, --Tự tăng

DepartmentName Nvarchar(100), --Unicode, cỡ 50
AccountName Nvarchar(100),
EmailAddress nvarchar(100),
[Password] nvarchar(50),
Tel nvarchar(50),
[Location] nvarchar(500)
)
-- Insert 20 records into the Department table
INSERT INTO Department (DepartmentName, AccountName, EmailAddress, [Password], Tel, [Location]) VALUES
('HR Department', 'hr_account', 'hr@email.com', 'hr_password', '123456789', 'Office
Building A, Floor 1'),
('IT Department', 'it_account', 'it@email.com', 'it_password', '987654321', 'Tech
Center, Floor 3'),
('Finance Department', 'finance_account', 'finance@email.com', 'finance_password',
'555555555', 'Financial Tower, Floor 5'),
('Marketing Department', 'marketing_account', 'marketing@email.com',
'marketing_password', '111111111', 'Marketing Plaza, Floor 2'),
('Production Department', 'production_account', 'production@email.com',
'production_password', '999999999', 'Factory Complex, Floor 1'),
('Sales Department', 'sales_account', 'sales@email.com', 'sales_password',
'777777777', 'Sales Center, Floor 4'),
('Research and Development Department', 'r&d_account', 'rnd@email.com',
'rnd_password', '888888888', 'Innovation Lab, Floor 2'),
('Customer Support Department', 'support_account', 'support@email.com',
'support_password', '444444444', 'Support Center, Floor 1'),
('Legal Department', 'legal_account', 'legal@email.com', 'legal_password',
'666666666', 'Legal Office, Floor 3'),
('Supply Chain Department', 'supply_chain_account', 'supplychain@email.com',
'supplychain_password', '222222222', 'Logistics Center, Floor 1'),
-- Add 10 more records
('Quality Assurance Department', 'qa_account', 'qa@email.com', 'qa_password',
'333333333', 'Testing Lab, Floor 2'),
('Facilities Management Department', 'facilities_account', 'facilities@email.com',
'facilities_password', '777777777', 'Facilities Center, Floor 1'),
('Customer Relations Department', 'customer_relations_account',
'customerrelations@email.com', 'customerrelations_password', '555555555', 'Customer
Relations Center, Floor 2'),
('Health and Safety Department', 'health_safety_account', 'healthsafety@email.com',
'healthsafety_password', '999999999', 'Safety Office, Floor 1'),
('Event Planning Department', 'event_planning_account', 'eventplanning@email.com',
'eventplanning_password', '111111111', 'Event Planning Center, Floor 3'),
('Training and Development Department', 'training_account', 'training@email.com',
'training_password', '888888888', 'Training Center, Floor 2'),
('Public Relations Department', 'pr_account', 'pr@email.com', 'pr_password',
'444444444', 'PR Office, Floor 1'),
('Internal Audit Department', 'audit_account', 'audit@email.com', 'audit_password',
'666666666', 'Audit Center, Floor 3'),
('Information Security Department', 'infosec_account', 'infosec@email.com',
'infosec_password', '222222222', 'Security Office, Floor 2'),
('Logistics Department', 'logistics_account', 'logistics@email.com',
'logistics_password', '123456789', 'Logistics Center, Floor 1');

select * from Department