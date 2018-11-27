using DA.Policlinico;
using Entity.Policlinico;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Drawing;

namespace BL.Policlinico
{
    public class UtilImpresionBL
    {
        LaboratorioDA g = new LaboratorioDA();

        public void To_pdfA4(string numGuia)
        {
            Document doc = new Document(PageSize.A4, 30, 30, 30, 30);

            if (File.Exists("Reporte.pdf"))
            {
                File.Delete("Reporte.pdf");
            }

            FileStream file = new FileStream("Reporte.pdf",
            FileMode.OpenOrCreate,
            FileAccess.ReadWrite,
            FileShare.ReadWrite);
            PdfWriter.GetInstance(doc, file);
            doc.Open();

            /*iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance("logo.png");

            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_LEFT;
            float percentage = 0.0f;
            percentage = 200 / imagen.Width;
            imagen.ScalePercent(percentage * 100);

            // Insertamos la imagen en el documento
            doc.Add(imagen);*/

            iTextSharp.text.Image imagenBarra = iTextSharp.text.Image.GetInstance("barraGenerada.png");
            imagenBarra.BorderWidth = 0;
            imagenBarra.Alignment = Element.ALIGN_RIGHT;
            float percentageBarra = 0.0f;
            percentageBarra = 100 / imagenBarra.Width;
            imagenBarra.ScalePercent(percentageBarra * 100);

            // Insertamos la imagen en el documento
            doc.Add(imagenBarra);
            doc.Add(new Paragraph("                       "));

            Chunk chunk = new Chunk("Reporte de General Usuarios", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD));
            GenerarCab(doc, numGuia);

            doc.Add(new Paragraph("                       "));
            GenerarDocumento(doc, numGuia);
            doc.Add(new Paragraph("                       "));
            doc.AddCreationDate();

            doc.Close();
            Process.Start("Reporte.pdf");//Esta parte se puede omitir, si solo se desea guardar el archivo, y que este no se ejecute al instante
            //  }
        }
        public void To_pdfA5(string numGuia)
        {
            Document doc = new Document(PageSize.A5.Rotate(), 30, 30, 30, 30);

            if (File.Exists("Reporte.pdf"))
            {
                File.Delete("Reporte.pdf");
            }

            FileStream file = new FileStream("Reporte.pdf",
            FileMode.OpenOrCreate,
            FileAccess.ReadWrite,
            FileShare.ReadWrite);
            PdfWriter.GetInstance(doc, file);
            doc.Open();
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance("logo.png");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_RIGHT;
            float percentage = 0.0f;
            percentage = 150 / imagen.Width;
            imagen.ScalePercent(percentage * 100);

            // Insertamos la imagen en el documento
            doc.Add(imagen);
            Chunk chunk = new Chunk("Reporte de General Usuarios", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD));
            GenerarCab(doc, numGuia);

            doc.Add(new Paragraph("                       "));
            GenerarDocumento(doc, numGuia);
            doc.Add(new Paragraph("                       "));
            doc.AddCreationDate();

            doc.Close();
            Process.Start("Reporte.pdf");//Esta parte se puede omitir, si solo se desea guardar el archivo, y que este no se ejecute al instante
            //  }
        }

        public void GenerarDocumento(Document document, String numGuia)
        {
            List<LabAnalisisBE> analisis = g.getReporte(numGuia);
            int i, j;
            PdfPTable datatable = new PdfPTable(4);
            datatable.DefaultCell.Padding = 3;
            float[] headerwidths = new float[] { 300, 300, 150, 300 };
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 100;
            datatable.DefaultCell.BorderWidth = 1;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatable.DefaultCell.BackgroundColor = BaseColor.LIGHT_GRAY;

            datatable.AddCell(new Paragraph("Analisis", FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.BOLD)));
            datatable.AddCell(new Paragraph("Resultado", FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.BOLD)));
            datatable.AddCell(new Paragraph("Unidad", FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.BOLD)));
            datatable.AddCell(new Paragraph("Valor Referencial", FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.BOLD)));
            datatable.HeaderRows = 1;
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.BackgroundColor = BaseColor.WHITE;
            datatable.AddCell(new Paragraph(analisis[0].analisis, FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
            datatable.AddCell(new Paragraph(analisis[0].resultado, FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
            datatable.AddCell(new Paragraph(analisis[0].unidad, FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
            datatable.AddCell(new Paragraph(analisis[0].valreferencial, FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
            for (i = 1; i < analisis.Count; i++)
            {
                if (analisis[i - 1].analisis.Equals((analisis[i].analisis)))
                {
                    datatable.AddCell(new Paragraph(""));
                    datatable.AddCell(new Paragraph(""));
                    datatable.AddCell(new Paragraph(""));
                    datatable.AddCell(new Paragraph(analisis[i].valreferencial, FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
                }
                else
                {
                    datatable.AddCell(new Paragraph(analisis[i].analisis, FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
                    datatable.AddCell(new Paragraph(analisis[i].resultado, FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
                    datatable.AddCell(new Paragraph(analisis[i].unidad, FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
                    datatable.AddCell(new Paragraph(analisis[i].valreferencial, FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
                }

            }
            datatable.CompleteRow();
            document.Add(datatable);
        }
        public void GenerarCab(Document document, String numguia)
        {
            PacienteBE paciente = g.getGuiaLab(numguia);
            int i, j;
            PdfPTable datatable = new PdfPTable(5);
            datatable.DefaultCell.Padding = 3;
            float[] headerwidths = new float[] { 100, 500, 100, 100, 150 };
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 100;
            datatable.DefaultCell.BorderWidth = 1;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.DefaultCell.BackgroundColor = BaseColor.LIGHT_GRAY;

            datatable.AddCell(new Paragraph("Historia", FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.BOLD)));
            datatable.AddCell(new Paragraph("Paciente", FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.BOLD)));
            datatable.AddCell(new Paragraph("Edad", FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.BOLD)));
            datatable.AddCell(new Paragraph("Sexo", FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.BOLD)));
            datatable.AddCell(new Paragraph("Fecha de Guía", FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.BOLD)));
            datatable.HeaderRows = 1;

            datatable.DefaultCell.BackgroundColor = BaseColor.WHITE;
            datatable.AddCell(new Paragraph(paciente.numHistoria, FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
            datatable.AddCell(new Paragraph(paciente.paterno, FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
            datatable.AddCell(new Paragraph(paciente.edad.ToString(), FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
            datatable.AddCell(new Paragraph(paciente.sexo, FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));
            datatable.AddCell(new Paragraph(paciente.fechaGuia, FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));

            datatable.CompleteRow();
            document.Add(datatable);
        }

    }

}
