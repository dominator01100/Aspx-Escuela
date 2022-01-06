using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppEscuela.Vistas
{
    public partial class estudiante_d : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int matricula = int.Parse(Request.QueryString["matricula"]);
                CargarFacultades();
                CargarEstudiante(matricula);
            }
        }
        public void CargarFacultades()
        {
            Operaciones_BD carga = new Operaciones_BD();
            DataSet dsFacultades = new DataSet();
            dsFacultades = carga.CargarFacultades();
            ddlFacultad.DataSource = dsFacultades;
            ddlFacultad.DataValueField = "ID";
            ddlFacultad.DataTextField = "Nombre";
            ddlFacultad.DataBind();
        }

        public void CargarEstudiante(int matricula)
        {
            Operaciones_BD carga = new Operaciones_BD();
            DataTable dtEstudiante = new DataTable();
            dtEstudiante = carga.CargarEstudiante(matricula);
            lblMatricula.Text = dtEstudiante.Rows[0]["Matricula"].ToString();
            lblNombre.Text = dtEstudiante.Rows[0]["Nombre"].ToString();
            lblFecha.Text = dtEstudiante.Rows[0]["FechaNacimiento"].ToString();
            lblSemestre.Text = dtEstudiante.Rows[0]["Semestre"].ToString();
            ddlFacultad.SelectedValue = dtEstudiante.Rows[0]["Facultad"].ToString();
        }

        public void EliminarEstudiante()
        {
            Operaciones_BD eliminar = new Operaciones_BD();
            int matricula = int.Parse(lblMatricula.Text);
            eliminar.EliminarEstudiante(matricula);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarEstudiante();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Eliminar", "alert('¡Estudiante eliminado exitosamente!');", true);
            Response.Redirect("~/Vistas/estudiante_s.aspx");
        }
    }
}