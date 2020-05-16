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
    /// Interaction logic for WPF_8_EF_HMS.xaml
    /// </summary>
    public partial class WPF_8_EF_HMS : Window
    {
        public WPF_8_EF_HMS()
        {
            InitializeComponent();

            HospitalManagementDBEntities db = new HospitalManagementDBEntities();
            var docs = from d in db.Doctors
                       select new
                       {
                           DoctorName = d.Name,
                           Speciality = d.Specialization
                       };

            foreach (var item in docs)
            {
                Console.WriteLine(item.DoctorName);
                Console.WriteLine(item.Speciality);
            }

            this.gridDoctors.ItemsSource = docs.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            HospitalManagementDBEntities db = new HospitalManagementDBEntities();

            Doctor doctorObject = new Doctor()
            {
                Name = txtName.Text,
                Qualification = txtQualification.Text,
                Specialization = txtSpecialization.Text
            };

            db.Doctors.Add(doctorObject);
            db.SaveChanges();
        }

        private void BtnLoadDoctors_Click(object sender, RoutedEventArgs e)
        {
            HospitalManagementDBEntities db = new HospitalManagementDBEntities();

            this.gridDoctors.ItemsSource = db.Doctors.ToList();
        }

        private int updatingDoctorID = 0;
        private void GridDoctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.gridDoctors.SelectedIndex >= 0)
            {
                if (this.gridDoctors.SelectedItems.Count >= 0)
                {
                    if (this.gridDoctors.SelectedItems[0].GetType() == typeof(Doctor))
                    {
                        Doctor d = (Doctor)this.gridDoctors.SelectedItems[0];
                        this.txtName2.Text = d.Name;
                        this.txtSpecialization2.Text = d.Specialization;
                        this.txtQualification2.Text = d.Qualification;
                        this.txtAge.Text = d.Age.ToString();

                        this.updatingDoctorID = d.Id;
                    }
                }
            }
        }

        private void BtnUpdateDoctor_Click(object sender, RoutedEventArgs e)
        {
            HospitalManagementDBEntities db = new HospitalManagementDBEntities();

            var r = from d in db.Doctors
                    where d.Id == this.updatingDoctorID
                    select d;

            Doctor obj = r.SingleOrDefault();

            if(obj != null)
            {
                obj.Name = this.txtName2.Text;
                obj.Specialization = this.txtSpecialization2.Text;
                obj.Qualification = this.txtQualification2.Text;
                obj.Age = int.Parse(this.txtAge.Text);

                db.SaveChanges();
            }

            
        }

        private void BtnDeleteDoctor_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msgBoxResult = MessageBox.Show("Are you sure you want to Delete?",
                "Delete Doctor",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning,
                MessageBoxResult.No
                );

            if (msgBoxResult == MessageBoxResult.Yes)
            {

                HospitalManagementDBEntities db = new HospitalManagementDBEntities();

                var r = from d in db.Doctors
                        where d.Id == this.updatingDoctorID
                        select d;

                Doctor obj = r.SingleOrDefault();

                if (obj != null)
                {
                    db.Doctors.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
    }
}
