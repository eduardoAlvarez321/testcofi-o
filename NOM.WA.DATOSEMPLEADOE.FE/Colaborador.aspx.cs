using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace NOM.WA.DATOSEMPLEADOE.FE
{
    public partial class Colaborador : System.Web.UI.Page
    {
        private static readonly string apiUrl = "http://localhost:5000/api/colaborador/getall";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvColaboradores.DataSource = new List<object>();
                gvColaboradores.DataBind();
            }
        }

        protected async void btnCargarDatos_Click(object sender, EventArgs e)
        {
            var colaboradores = await ObtenerColaboradoresDesdeAPI();
            gvColaboradores.DataSource = colaboradores;
            gvColaboradores.DataBind();
        }

        private async Task<List<Colaborador>> ObtenerColaboradoresDesdeAPI()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync(); // Obtener JSON como string
                    return JsonConvert.DeserializeObject<List<Colaborador>>(json);
                }
                return new List<Colaborador>(); // Devuelve una lista vacía si hay error
            }
        }
    }

    public class Colaboradores
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Puesto { get; set; }
        public string Departamento { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}