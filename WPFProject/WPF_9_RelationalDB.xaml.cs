using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFProject
{
    /// <summary>
    /// Interaction logic for WPF_9_RelationalDB.xaml
    /// </summary>
    public partial class WPF_9_RelationalDB : Window
    {
        public WPF_9_RelationalDB()
        {
            InitializeComponent();

            HospitalManagementDBEntities db = new HospitalManagementDBEntities();

            var result = from a in db.Appointments
                         select new
                         {
                             a.DoctorID,
                             DoctorName = a.Doctor.Name,
                             a.Doctor.Specialization,
                             a.PatientID,
                             Patient = a.Patient.Name,
                             a.Patient.ContactNo,
                             a.AppointmentDate
                         };

            var resultOuterDoctor = from d in db.Doctors
                                    from a in d.Appointments.DefaultIfEmpty()
                                    select new
                                    {
                                        d.Name,
                                        ApptID = a.Id.ToString(),
                                        a.AppointmentDate,
                                        Patient=a.Patient.Name
                                    };

            this.gridAppointments.ItemsSource = result.ToList();
        }
    }
}
