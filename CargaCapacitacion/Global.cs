using Microsoft.AspNetCore.Http;

namespace CargaCapacitacion
{
    public class Global
    {
        public static string GetUserSesion()
        {
            //if (HttpContext.Current != null)
            //{
                
            //    var request = HttpContext.Current.Request;
            //    var user = request.LogonUserIdentity.Name;
            //    user = "SA\\AR01013838";
            //    var userName = user.Split('\\');
            //    if (userName.Length > 0)
            //    {
            //        if (userName[1] == "Silve")
            //        {
            //            return "TARTGVVTEDES";
            //        }
            //        return userName[1];
            //    }

            //    return userName[0];
            //}
            return "";
        }

    }

}
