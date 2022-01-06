using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppEscuela.Vistas
{
    public partial class estudiante_s : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridEstudiantes.DataSource = CargarEstudiantes();
                GridEstudiantes.DataBind();
            }
        }

        public DataTable CargarEstudiantes()
        {
            Operaciones_BD operaciones = new Operaciones_BD();
            return operaciones.CargarEstudiantes();
        }

        protected void GridEstudiantes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/Vistas/estudiante_u.aspx?matricula=" + e.CommandArgument);
            }
            else
            {
                Response.Redirect("~/Vistas/estudiante_d.aspx?matricula=" + e.CommandArgument);
            }
        }
    }
}