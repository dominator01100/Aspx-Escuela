using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppEscuela.Vistas
{
    public partial class estudiante_i : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarFacultades();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarEstudiante();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alta", "alert('¡Estudiante agregado exitosamente!');", true);
        }

        public void AgregarEstudiante()
        {
            Operaciones_BD alta = new Operaciones_BD();
            string nombre = txtNombre.Text;
            DateTime fecha = Convert.ToDateTime(txtFecha.Text);
            int semestre = Convert.ToInt32(txtSemestre.Text);
            int facultad = Convert.ToInt32(ddlFacultad.SelectedValue);
            alta.AgregarEstudiante(nombre, fecha, semestre, facultad);
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
    }
}