using System;
using System.Collections.Generic;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public class CampanaVacunacion
{
    // Conjuntos que almacenan los diferentes grupos de ciudadanos.
    private HashSet<Ciudadano> conjuntoTotal;
    private HashSet<Ciudadano> conjuntoPfizer;
    private HashSet<Ciudadano> conjuntoAstraZeneca;

    public CampanaVacunacion()
    {
        // Inicialización de los conjuntos.
        conjuntoTotal = new HashSet<Ciudadano>();
        conjuntoPfizer = new HashSet<Ciudadano>();
        conjuntoAstraZeneca = new HashSet<Ciudadano>();
    }

    // Método para inicializar los conjuntos con datos de prueba.
    public void InicializarConjuntos()
    {
        // Añadir 500 ciudadanos al conjunto total.
        for (int i = 1; i <= 500; i++)
        {
            conjuntoTotal.Add(new Ciudadano(i));
        }

        // Añadir 75 ciudadanos al conjunto de Pfizer y AstraZeneca.
        for (int i = 1; i <= 75; i++)
        {
            conjuntoPfizer.Add(new Ciudadano(i));             // Pfizer
            conjuntoAstraZeneca.Add(new Ciudadano(i + 75));   // AstraZeneca
        }
    }

    // Método para obtener los ciudadanos que no han recibido ninguna vacuna.
    public IEnumerable<Ciudadano> ObtenerCiudadanosNoVacunados()
    {
        return conjuntoTotal.Except(conjuntoPfizer.Union(conjuntoAstraZeneca));
    }

    // Método para obtener los ciudadanos que han recibido ambas vacunas.
    public IEnumerable<Ciudadano> ObtenerCiudadanosConAmbasVacunas()
    {
        return conjuntoPfizer.Intersect(conjuntoAstraZeneca);
    }

    // Método para obtener los ciudadanos que solo han recibido la vacuna Pfizer.
    public IEnumerable<Ciudadano> ObtenerCiudadanosSoloPfizer()
    {
        return conjuntoPfizer.Except(conjuntoAstraZeneca);
    }

    // Método para obtener los ciudadanos que solo han recibido la vacuna AstraZeneca.
    public IEnumerable<Ciudadano> ObtenerCiudadanosSoloAstraZeneca()
    {
        return conjuntoAstraZeneca.Except(conjuntoPfizer);
    }

    // Método para generar el reporte en PDF con los datos de la campaña.
    public void GenerarReportePDF(string rutaArchivo)
    {
        Document documento = new Document();

        try
        {
            // Intentar crear el archivo PDF.
            PdfWriter.GetInstance(documento, new FileStream(rutaArchivo, FileMode.Create));
            documento.Open();

            // Añadir título y espacio en blanco.
            documento.Add(new Paragraph("Reporte de Campaña de Vacunación COVID-19"));
            documento.Add(new Paragraph(" ")); // Espacio en blanco

            // Añadir sección de ciudadanos no vacunados.
            documento.Add(new Paragraph("Ciudadanos no vacunados:"));
            documento.Add(new Paragraph(string.Join(", ", ObtenerCiudadanosNoVacunados().Select(c => c.Id))));
            documento.Add(new Paragraph(" ")); // Espacio en blanco

            // Añadir sección de ciudadanos con ambas vacunas.
            documento.Add(new Paragraph("Ciudadanos con ambas vacunas:"));
            documento.Add(new Paragraph(string.Join(", ", ObtenerCiudadanosConAmbasVacunas().Select(c => c.Id))));
            documento.Add(new Paragraph(" ")); // Espacio en blanco

            // Añadir sección de ciudadanos con solo Pfizer.
            documento.Add(new Paragraph("Ciudadanos solo con Pfizer:"));
            documento.Add(new Paragraph(string.Join(", ", ObtenerCiudadanosSoloPfizer().Select(c => c.Id))));
            documento.Add(new Paragraph(" ")); // Espacio en blanco

            // Añadir sección de ciudadanos con solo AstraZeneca.
            documento.Add(new Paragraph("Ciudadanos solo con AstraZeneca:"));
            documento.Add(new Paragraph(string.Join(", ", ObtenerCiudadanosSoloAstraZeneca().Select(c => c.Id))));

            // Cerrar el documento.
            documento.Close();
        }
}

public class Ciudadano
{
    public int Id { get; set; }

    // Constructor para inicializar el ID del ciudadano.
    public Ciudadano(int id)
    {
        Id = id;
    }
}
