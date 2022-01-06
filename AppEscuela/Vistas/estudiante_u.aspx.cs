using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppEscuela.Vistas
{
    public partial class estudiante_u : System.Web.UI.Page
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

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            ModificarEstudiante();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Cambios", "alert('¡Estudiante mofificado exitosamente!');", true);
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
            ddlFacultad.Items.Insert(0, new ListItem("--Seleccione una Facultad--", ""));
            ddlFacultad.Items[0].Attributes["selected"] = "selected";
            ddlFacultad.Items[0].Attributes["disabled"] = "disabled";
        }

        public void CargarEstudiante(int matricula)
        {
            Operaciones_BD carga = new Operaciones_BD();
            DataTable dtEstudiante = new DataTable();
            dtEstudiante = carga.CargarEstudiante(matricula);
            lblMatricula.Text = dtEstudiante.Rows[0]["Matricula"].ToString();
            txtNombre.Text = dtEstudiante.Rows[0]["Nombre"].ToString();
            txtFecha.Text = dtEstudiante.Rows[0]["FechaNacimiento"].ToString().Substring(1, 10);
            txtSemestre.Text = dtEstudiante.Rows[0]["Semestre"].ToString();
            ddlFacultad.SelectedValue = dtEstudiante.Rows[0]["Facultad"].ToString();
        }

        public void ModificarEstudiante()
        {
            Operaciones_BD cambios = new Operaciones_BD();
            int matricula = int.Parse(lblMatricula.Text);
            string nombre = txtNombre.Text;
            DateTime fecha = Convert.ToDateTime(txtFecha.Text);
            int semestre = Convert.ToInt32(txtSemestre.Text);
            int facultad = Convert.ToInt32(ddlFacultad.SelectedValue);
            cambios.ModificarEstudiante(matricula, nombre, fecha, semestre, facultad);
        }
    }
}