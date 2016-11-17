using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using CsvHelper;
using DemoCSVHelper.Entity;
using DemoCSVHelper.MapCSV;

namespace DemoCSVHelper
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
          

            if (FUSeleccionarArchivoCSV.HasFile)
            {
                //Primero guardamos el archivo CSV en nuestro proyecto
                string filename = Path.GetFileName(FUSeleccionarArchivoCSV.FileName);
                string fullPath = Server.MapPath("~/CSVFiles/" + FUSeleccionarArchivoCSV.FileName);
                IEnumerable<EmpleadoBE> listaEmpleados;

                FUSeleccionarArchivoCSV.SaveAs(fullPath);

                if (rdOpcionCarga.SelectedValue.Equals("Simple"))
                {
                    listaEmpleados = CargaManual(fullPath);
                }
                else
                {
                    listaEmpleados = CargaConCSVMAP(fullPath);
                }
           
                gvListaEmpleados.DataSource = listaEmpleados;
                gvListaEmpleados.DataBind();
             
            }
        }

        #region Methods

        private IEnumerable<EmpleadoBE> CargaManual(string fullPath)
        {
            using (TextReader reader = File.OpenText(fullPath))
            {
                var csv = new CsvReader(reader);

                IList<EmpleadoBE> empleados = new List<EmpleadoBE>();

                while (csv.Read())
                {

                    EmpleadoBE empleado = new EmpleadoBE();
                    empleado.EmpleadoID = csv.GetField<int>(nameof(empleado.EmpleadoID));
                    empleado.Nombre = csv.GetField<string>(nameof(empleado.Nombre));
                    empleado.ApellidoPaterno = csv.GetField<string>(nameof(empleado.ApellidoPaterno));
                    empleado.ApellidoMaterno = csv.GetField<string>(nameof(empleado.ApellidoMaterno));
                    empleado.DNI = csv.GetField<string>(nameof(empleado.DNI));
                    empleado.Cargo = csv.GetField<string>(nameof(empleado.Cargo));
                    empleado.NombreCompleto = string.Concat(empleado.Nombre, 
                                                    " ", empleado.ApellidoPaterno,
                                                    " ", empleado.ApellidoMaterno
                                                    );

                    empleados.Add(empleado);
                }

                return empleados;
            }
        }

        private IEnumerable<EmpleadoBE> CargaConCSVMAP(string fullPath)
        {
            using (TextReader reader = File.OpenText(fullPath))
            {
                var csv = new CsvReader(reader);
                csv.Configuration.RegisterClassMap<EmpleadoMap>();
                csv.Configuration.IsHeaderCaseSensitive = false;
                csv.Configuration.Delimiter = ",";
                csv.Configuration.HasHeaderRecord = true;

                IEnumerable<EmpleadoBE> records = csv.GetRecords<EmpleadoBE>().ToList();
                return records;
            }
        }

        #endregion

    }
}