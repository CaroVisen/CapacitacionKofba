using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargaCapacitacion.Controllers
{
    public class clsDAO
    {
        SqlConnection cnn;
        private string conexion = "Server=KOFARALCBD03;Database=CAPACITACION;uid=PlanCurricular;pwd=Pl4nCXrr1cXl4r35;Trusted_Connection=True;Integrated Security=False";
        public void SqlExec(String strValue)
        {
            try
            {
                cnn = new SqlConnection(conexion);
                SqlCommand sqlComm = new SqlCommand(strValue);
                sqlComm.Connection = cnn;
                sqlComm.CommandTimeout = 30000;
                cnn.Open();
                sqlComm.ExecuteScalar();
                sqlComm = null;
                cnn.Close();
            }
            catch (Exception ex)
            {
                cnn.Close();
                throw ex;
            }
        }
    }
}
