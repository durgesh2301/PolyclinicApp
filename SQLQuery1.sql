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




create procedure usp_GetDoctorAppointment
(
	@DoctorID int,
	@PatientID int,
	@AppointmentDate datetime,
	@AppointmentID int out
)
as	
begin
	set @AppointmentID = 0
	Begin try
	  if not exists(select * from Patients where PatientID = @PatientID)
		return -1
	  if not exists(select * from Doctors where DoctorID = @DoctorID)
		return -2
	  if @AppointmentDate < getdate()
		return -3
	  if exists(select * from Appointments where DoctorID = @DoctorID and PatientID = @PatientID and AppointmentDate = @AppointmentDate)
		return 2
	  insert into Appointments values(@DoctorID, @PatientID, @AppointmentDate)
	  set @AppointmentID = (select AppointmentID from Appointments where DoctorID = @DoctorID and PatientID = @PatientID and AppointmentDate = @AppointmentDate)
		return 1
	end try
	begin catch
	  set @AppointmentID = 0
	  return -99
	end catch
end


create function ufn_CalculateDoctorFees
(
	@DoctorID int,
	@AppointmentDate datetime
)
returns money
as
begin
	declare @Fees money
	select @Fees = ((select Fees from Doctors where DoctorID = @DoctorID)*0.6)
	return @Fees
end



create function ufn_FetchAllAppointments
(
	@DoctorID int,
	@AppointmentDate datetime
)
returns table
as
return
(
	select d.DoctorName, d.Specialization,p.PatientID, p.PatientName, a.AppointmentID
	from Doctors d, Patients p, Appointments a
	where d.DoctorID = a.DoctorID and p.PatientID = a.PatientID and d.DoctorID = @DoctorID and (CAST(a.AppointmentDate AS DATE)) = CAST(@AppointmentDate AS DATE)
)

