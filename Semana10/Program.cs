using System;

public class Program
{
    public static void Main(string[] args)
    {
        CampanaVacunacion campana = new CampanaVacunacion();
        campana.InicializarConjuntos();

        // Obtener la ruta del escritorio
        string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string rutaArchivo = System.IO.Path.Combine(rutaEscritorio, "reporte_campana_vacunacion.pdf");

        // Generar reporte en PDF en el escritorio
        campana.GenerarReportePDF(rutaArchivo);

        Console.WriteLine($"El reporte se ha generado en: {rutaArchivo}");
    }
}