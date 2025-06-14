using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PoluclinicDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoluclinicDALLayer
{
    public class PolyclinicRepository
    {
        private PolyclinicDbContext dbContext;

        public PolyclinicRepository(PolyclinicDbContext context)
        {
            dbContext = context;
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            try
            {
                doctors = dbContext.Doctors.OrderBy(d => d.DoctorId).ToList();
            }
            catch (Exception ex)
            {
                doctors = null;
            }
            return doctors;
        }

        public List<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();
            try
            {
                patients = dbContext.Patients.OrderBy(p => p.PatientId).ToList();
            }
            catch (Exception ex)
            {
                patients = null;
            }
            return patients;
        }

        public List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            try
            {
                appointments = dbContext.Appointments.OrderBy(a => a.AppointmentId).ToList();
            }
            catch (Exception ex)
            {
                appointments = null;
            }
            return appointments;
        }

        public Doctor GetDoctorById(int doctorId)
        {
            Doctor doctor = null;
            try
            {
                doctor = dbContext.Doctors.FirstOrDefault(d => d.DoctorId == doctorId);
            }
            catch (Exception ex)
            {
                doctor = null;
            }
            return doctor;
        }

        public Patient GetPatientById(int patientId)
        {
            Patient patient = null;
            try
            {
                patient = dbContext.Patients.FirstOrDefault(p => p.PatientId == patientId);
            }
            catch (Exception ex)
            {
                patient = null;
            }
            return patient;
        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            Appointment appointment = null;
            try
            {
                appointment = dbContext.Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
            }
            catch (Exception ex)
            {
                appointment = null;
            }
            return appointment;
        }

        public bool AddDoctor(Doctor doctor)
        {
            try
            {
                dbContext.Doctors.Add(doctor);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddPatient(Patient patient)
        {
            try
            {
                dbContext.Patients.Add(patient);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddAppointment(Appointment appointment)
        {
            try
            {
                dbContext.Appointments.Add(appointment);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int GetDoctorAppointment(int doctorId, int patientId, DateTime appointmentDate, out int appointmentId)
        {
            appointmentId = 0;
            int returnResult = 0;
            int noOfRowsAffected = 0;
            try { 
                SqlParameter doctorIdParam = new SqlParameter("@DoctorId", doctorId);
                SqlParameter patientIdParam = new SqlParameter("@PatientId", patientId);
                SqlParameter appointmentDateParam = new SqlParameter("@AppointmentDate", appointmentDate);
                SqlParameter appointmentIdParam = new SqlParameter("@AppointmentId", System.Data.SqlDbType.Int);
                appointmentIdParam.Direction = System.Data.ParameterDirection.Output;
                SqlParameter returnValueParam = new SqlParameter("@ReturnValue", System.Data.SqlDbType.Int);
                returnValueParam.Direction = System.Data.ParameterDirection.Output;

                noOfRowsAffected = dbContext.Database.ExecuteSqlRaw("EXEC @ReturnValue = usp_GetDoctorAppointment @DoctorId, @PatientId, @AppointmentDate, @AppointmentID out", 
                    returnValueParam, doctorIdParam, patientIdParam, appointmentDateParam, appointmentIdParam);
                if (noOfRowsAffected > 0)
                {
                    returnResult = Convert.ToInt32(returnValueParam.Value);
                    appointmentId = Convert.ToInt32(appointmentIdParam.Value);
                }
            }
            catch (Exception ex)
            {
                returnResult = -99;
                appointmentId = 0;
            }
            
            return appointmentId;
        }

        public bool UpdateDoctorFees(int doctorId, decimal fees)
        {
            bool isUpdated = false;
            try
            {
                Doctor doctor = dbContext.Doctors.FirstOrDefault(d => d.DoctorId == doctorId);
                if (doctor != null)
                {
                    doctor.Fees = fees;
                    dbContext.SaveChanges();
                    isUpdated = true;
                }
                else
                {
                    isUpdated = false;
                }
            }
            catch (Exception ex)
            {
                isUpdated = false;
            }
            return isUpdated;
        }

        public bool UpdateAppointmentDate(int appointmentId, DateTime appointmentDate)
        {
            bool isUpdated = false;
            try
            {
                Appointment appointment = dbContext.Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
                if (appointment != null)
                {
                    appointment.AppointmentDate = appointmentDate;
                    dbContext.SaveChanges();
                    isUpdated = true;
                }
                else
                {
                    isUpdated = false;
                }
            }
            catch (Exception ex)
            {
                isUpdated = false;
            }
            return isUpdated;
        }

        public bool UpdatePatientAge(int patientId, int newAge)
        {
            bool isUpdated = false;
            try
            {
                Patient patient = dbContext.Patients.FirstOrDefault(p => p.PatientId == patientId);
                if (patient != null)
                {
                    patient.Age = newAge;
                    dbContext.SaveChanges();
                    isUpdated = true;
                }
                else
                {
                    isUpdated = false;
                }
            }
            catch (Exception ex)
            {
                isUpdated = false;
            }
            return isUpdated;
        }

        public bool DeleteDoctor(int doctorId)
        {
            bool isDeleted = false;
            try
            {
                Doctor doctor = dbContext.Doctors.FirstOrDefault(d => d.DoctorId == doctorId);
                if (doctor != null)
                {
                    dbContext.Doctors.Remove(doctor);
                    dbContext.SaveChanges();
                    isDeleted = true;
                }
                else
                {
                    isDeleted = false;
                }
            }
            catch (Exception ex)
            {
                isDeleted = false;
            }
            return isDeleted;
        }

        public bool DeletePatient(int patientId)
        {
            bool isDeleted = false;
            try
            {
                Patient patient = dbContext.Patients.FirstOrDefault(p => p.PatientId == patientId);
                if (patient != null)
                {
                    dbContext.Patients.Remove(patient);
                    dbContext.SaveChanges();
                    isDeleted = true;
                }
                else
                {
                    isDeleted = false;
                }
            }
            catch (Exception ex)
            {
                isDeleted = false;
            }
            return isDeleted;
        }

        public bool DeleteAppointment(int appointmentId)
        {
            bool isDeleted = false;
            try
            {
                Appointment appointment = dbContext.Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
                if (appointment != null)
                {
                    dbContext.Appointments.Remove(appointment);
                    dbContext.SaveChanges();
                    isDeleted = true;
                }
                else
                {
                    isDeleted = false;
                }
            }
            catch (Exception ex)
            {
                isDeleted = false;
            }
            return isDeleted;
        }

        public decimal CalculateDoctorFees(int doctorId, DateTime appointmentDate)
        {
            decimal fees = 0;
            try
            {
                fees = (from d in dbContext.Doctors
                        select PolyclinicDbContext.ufn_CalculateDoctorFees(doctorId, appointmentDate)).FirstOrDefault();
            }
            catch(Exception ex)
            {
                fees = 0;
            }
            return fees;
        }

        public List<DoctorAppointments> FetchDoctorAppointments(int doctorId, DateTime appointmentDate)
        {
            List<DoctorAppointments> doctorAppointments = new List<DoctorAppointments>();
            try
            {
                SqlParameter doctorIdParam = new SqlParameter("@DoctorId", doctorId);
                SqlParameter appointmentDateParam = new SqlParameter("@AppointmentDate", appointmentDate);
                doctorAppointments = dbContext.DoctorAppointments.FromSqlRaw("SELECT * FROM ufn_FetchAllAppointments(@DoctorId,@AppointmentDate)", doctorIdParam,appointmentDateParam).ToList();
            }
            catch (Exception ex)
            {
                doctorAppointments = null;
            }
            return doctorAppointments;
        }
    }
}
