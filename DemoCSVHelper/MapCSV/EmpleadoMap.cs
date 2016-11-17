
using CsvHelper.Configuration;
using DemoCSVHelper.Entity;

namespace DemoCSVHelper.MapCSV
{
    public sealed class EmpleadoMap : CsvClassMap<EmpleadoBE>
    {

        public EmpleadoMap()
        {
            Map(m => m.EmpleadoID);
            Map(m => m.Nombre);
            Map(m => m.ApellidoPaterno);
            Map(m => m.ApellidoMaterno);
            Map(m => m.DNI);
            Map(m => m.Cargo);
            Map(m => m.NombreCompleto).ConvertUsing(row => 
                            row.GetField<string>(nameof(EmpleadoBE.Nombre)) + " " + 
                            row.GetField<string>(nameof(EmpleadoBE.ApellidoPaterno)) + " " +
                            row.GetField<string>(nameof(EmpleadoBE.ApellidoMaterno))
                            );
        }

    }
}