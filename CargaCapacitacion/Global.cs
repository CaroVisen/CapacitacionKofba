using CargaCapacitacion.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargaCapacitacion
{
    public class Global
    {
        public static string GetUserSesion()
        {
            var user = Environment.UserName;
            
            if (user != null)
            {
                //user = "SA\\AR01013838";
                var userName = user.Split('\\');
                if (userName.Length > 1)
                {
                    
                    return userName[1];
                }

                return userName[0];
            }
            return "";
        }

    }

}
