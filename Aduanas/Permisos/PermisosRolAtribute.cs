using Aduanas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Aduanas.Permisos
{
    public class PermisosRolAtribute : ActionFilterAttribute
    {

        private Rol idrol;


        public PermisosRolAtribute(Rol _idrol)
        {
            idrol = _idrol;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Usuario") != null)
            {
                Usuarios usuario = JsonConvert.DeserializeObject<Usuarios>(context.HttpContext.Session.GetString("Usuario"));

                if (usuario.idRol != this.idrol) {

                    context.Result = new RedirectResult("~/Home/PermisoDenegado");
                
                }
            }

            base.OnActionExecuting(context);
        }

    }
}
