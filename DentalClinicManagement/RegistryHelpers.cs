using DentalClinicManagement.Account;
using DentalClinicManagement.Dentist;
using DentalClinicManagement.Dentist.Class;
using DentalClinicManagement.Employee.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinicManagement.Account.Class;

namespace DentalClinicManagement
{
    public class RegistryHelpers
    {
        public bool RegisterCustomer(CustomerClass customer)
        {
            try
            {
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Thực hiện thêm dữ liệu vào database
                    string query = "INSERT INTO Customer (Name, DateOfBirth, Address, PhoneNo) " +
                                   "VALUES (@Name, @DateOfBirth, @Address, @PhoneNo)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", customer.Name);
                        command.Parameters.AddWithValue("@DateOfBirth", customer.DayOfBirth);
                        command.Parameters.AddWithValue("@Address", customer.Address);
                        command.Parameters.AddWithValue("@PhoneNo", customer.PhoneNo);

                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public bool RegisterAppointmentRequest(AppointmentRequest appointment)
        {
            try
            {
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Thực hiện thêm dữ liệu vào database
                    string query = "INSERT INTO [Appointment Request] (PatientID, DentistID, ScheduleID, TimeOfRequest, Note, Status) " +
                                   "VALUES (@PatientID, @DentistID, @ScheduleID, @TimeOfRequest, @Note, @Status)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PatientID", appointment.PatientID);
                        command.Parameters.AddWithValue("@DentistID", appointment.DentistID);
                        command.Parameters.AddWithValue("@ScheduleID", appointment.ScheduleID);
                        command.Parameters.AddWithValue("@TimeOfRequest", appointment.TimeOfRequest);
                        command.Parameters.AddWithValue("@Note", appointment.Note);
                        command.Parameters.AddWithValue("@Status", appointment.Status);

                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public bool RegisterMedication(MedicationList medication)
        {
            try
            {
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Thực hiện thêm dữ liệu vào database
                    string query = "INSERT INTO [Medication List] (Name) " +
                                   "VALUES (@Name)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", medication.Name);

                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public bool RegisterRestrictedMedication(RestrictedMedication medication)
        {
            try
            {
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Thực hiện thêm dữ liệu vào database
                    string query = "INSERT INTO [Restricted Medication] (MedicationID, PatientRecordID) " +
                                   "VALUES (@MedicationID, @PatientRecordID)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MedicationID", medication.MedicationID);
                        command.Parameters.AddWithValue("@PatientRecordID", medication.PatientRecordID);

                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public bool RegisterPatient(Patient patient)
        {
            try
            {
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Thực hiện thêm dữ liệu vào database
                    string query = "INSERT INTO [Patient] (Name, PhoneNo) " +
                                   "VALUES (@Name, @PhoneNo)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", patient.Name);
                        command.Parameters.AddWithValue("@PhoneNo", patient.PhoneNo);

                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public bool RegisterPatientRecord(PatientRecord patientRecord)
        {
            try
            {
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Thực hiện thêm dữ liệu vào database
                    string query = "INSERT INTO [Patient Record] (Name, Age, Sex, TotalTreatmentFee, TotalPaid, GeneralInformation, AllergyStatus) " +
                                   "VALUES (@Name, @Age, @Sex, @TotalTreatmentFee, @TotalPaid, @GeneralInformation, @AllergyStatus)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", patientRecord.Name);
                        command.Parameters.AddWithValue("@Age", patientRecord.Age);
                        command.Parameters.AddWithValue("@Sex", patientRecord.Age);
                        command.Parameters.AddWithValue("@TotalTreatmentFee", patientRecord.TotalTreatmentFee);
                        command.Parameters.AddWithValue("@TotalPaid", patientRecord.TotalPaid);
                        command.Parameters.AddWithValue("@GeneralInformation", patientRecord.GeneralInformation);
                        command.Parameters.AddWithValue("@AllergyStatus", patientRecord.AllergyStatus);

                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public bool RegisterDetailTreatmentPlan(DetailedTreatmentPlan plan)
        {
            try
            {
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Thực hiện thêm dữ liệu vào database
                    string query = "INSERT INTO [Detailed Treatment Plan] (ConductedTreatmentID, PatientID, TreatmentID, Date, DentistID, Assistant, ToothSurfaceID) " +
                                   "VALUES (@ConductedTreatmentID, @PatientID, @TreatmentID, @Date, @DentistID, @Assistant, @ToothSurfaceID)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ConductedTreatmentID", plan.ConductedTreatmentID);
                        command.Parameters.AddWithValue("@PatientID", plan.PatientID);
                        command.Parameters.AddWithValue("@TreatmentID", plan.TreatmentID);
                        command.Parameters.AddWithValue("@Date", plan.Date);
                        command.Parameters.AddWithValue("@DentistID", plan.DentistID);
                        command.Parameters.AddWithValue("@Assistant", plan.Assistant);
                        command.Parameters.AddWithValue("@ToothSurfaceID", plan.ToothSurfaceID);

                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}
