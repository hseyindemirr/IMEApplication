using LoginForm.DataSet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.Services
{
    class AuthorizationService
    {
        
        public List<AuthorizationValue> GetAvailAuthorization(Worker Worker)
        {

            IMEEntities IMEDB = new IMEEntities();
            return IMEDB.AuthorizationValues.AsNoTracking().Where(a => !a.Workers.Any(w => w.WorkerID == Worker.WorkerID)).ToList();

        }
        public List<AuthorizationValue> GetUserAuthorization(Worker Worker)
        {
            IMEEntities IMEDB = new IMEEntities();
            return IMEDB.AuthorizationValues.AsNoTracking().Where(a => a.Workers.Any(w => w.WorkerID == Worker.WorkerID)).ToList();

        }
        public List<AuthorizationValue> Authorizations()
        {
            IMEEntities IMEDB = new IMEEntities();
            return IMEDB.AuthorizationValues.AsNoTracking().ToList();

        }
        public void AddNewAuthorization(AuthorizationValue NewAuthorization,Worker Worker)
        {
            IMEEntities IMEDB = new IMEEntities();
            
         
            IMEDB.AuthorizationValues.Add(NewAuthorization);
            
            IMEDB.SaveChanges();
           
        }
        public void Add(int AutID,int WorkerID)
        {
            using (SqlConnection connection = new SqlConnection("data source=.;initial catalog=IME;integrated security=True;multipleactiveresultsets=True"))
            {
                String query = "INSERT INTO dbo.UserAuthorization (WorkerID,AuthorizationID) VALUES (@WorkerID,@AutID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AutID",AutID);
                    command.Parameters.AddWithValue("@WorkerID",WorkerID);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    
                }
            }
        }
    }
}
