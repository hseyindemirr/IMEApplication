using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.WorkerManager
{

    public partial class AuthorizationManagement : Form
    {
        AuthorizationService AuthorizationManager = new AuthorizationService();
        WorkerService WorkerService = new WorkerService();
        Worker AutWorker;
        AuthorizationValue AutValue;
        public AuthorizationManagement()
        {
            InitializeComponent();
        }

        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutWorker = cbUser.SelectedItem as Worker;
           lstAddAuthorization.DataSource = AuthorizationManager.GetAvailAuthorization(AutWorker);
            lstAddAuthorization.DisplayMember = "AuthorizationValue1";
            lstAddAuthorization.ValueMember = "AuthorizationID";
            dgAuthorizations.DataSource = AuthorizationManager.GetUserAuthorization(AutWorker);


        }

        private void AuthorizationManagement_Load(object sender, EventArgs e)
        {
            cbUser.DataSource = WorkerService.GetWorkers();
            cbUser.DisplayMember = "FirstName";
            cbUser.ValueMember = "WorkerID";
            //lstAddAuthorization.DataSource = AuthorizationManager.Authorizations();




        }

        private void cbUser_Click(object sender, EventArgs e)
        {

        }

        private void btnAddAuthorization_Click(object sender, EventArgs e)
        {
        

            AutWorker = cbUser.SelectedItem as Worker;
            AutValue = lstAddAuthorization.SelectedItem as AuthorizationValue;
            
            AutValue.Workers.Add(AutWorker);
            int ID1 = AutWorker.WorkerID;
            int ID2 = AutValue.AuthorizationID;
            AuthorizationManager.Add(ID2,ID1);
           

           lstAddAuthorization.DataSource = AuthorizationManager.GetAvailAuthorization(AutWorker);

           dgAuthorizations.DataSource = AuthorizationManager.GetUserAuthorization(AutWorker);

        }


    }
}
