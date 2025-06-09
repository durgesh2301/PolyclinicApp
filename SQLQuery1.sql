create database PolyclinicDB

use PolyclinicDB

create table Doctors
(
	DoctorID int primary key identity(1000,1),
	DoctorName nvarchar(50) not null,
	Specialization nvarchar(50) not null,
	Fees money not null
);

create table Patients
(
	PatientID int primary key identity(1000,1),
	PatientName nvarchar(50) not null,
	Age int not null,
	Gender char(1) not null check(Gender in ('M', 'F')),
	PhoneNumber nvarchar(15) not null
);

create table Appointments
(
	AppointmentID int primary key identity(1000,1),
	DoctorID int not null,
	PatientID int not null,
	AppointmentDate datetime not null,
	Foreign key (DoctorID) references Doctors(DoctorID),
	Foreign key (PatientID) references Patients(PatientID)
);

