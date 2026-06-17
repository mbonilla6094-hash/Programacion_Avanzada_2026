using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProyectoTesis.Entidades;
using ProyectoTesis.Logica.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace ProyectoTesis.Logica.Servicios
{
    public class PdfServicio : IPdfServicio
    {
        public PdfServicio()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public byte[] GenerarInformeMensual(InformeCabecera informe, List<InformeDetalle> actividades, string rutaLogo)
        {
            using (var ms = new MemoryStream())
            {
                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(30);
                        page.DefaultTextStyle(x => x.FontSize(10));

                        page.Header().Element(c => CabeceraInforme(c, informe, rutaLogo));
                        page.Content().Element(c => CuerpoInforme(c, informe, actividades));
                        page.Footer().AlignCenter().Text($"Generado el {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(8).FontColor(Colors.Grey.Medium);
                    });
                }).GeneratePdf(ms);

                return ms.ToArray();
            }
        }

        public byte[] GenerarInformeFinal(Estudiante estudiante, List<HistorialProgresion> listaHistorial, string rutaLogo)
        {
            using (var ms = new MemoryStream())
            {
                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(30);
                        page.DefaultTextStyle(x => x.FontSize(10));

                        page.Header().Element(c => CabeceraFinal(c, estudiante, rutaLogo));
                        page.Content().Element(c => CuerpoFinal(c, estudiante, listaHistorial));
                        page.Footer().AlignCenter().Text($"Generado el {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(8).FontColor(Colors.Grey.Medium);
                    });
                }).GeneratePdf(ms);

                return ms.ToArray();
            }
        }

        private void CabeceraInforme(IContainer container, InformeCabecera informe, string rutaLogo)
        {
            container.Column(col =>
            {
                if (File.Exists(rutaLogo))
                    col.Item().Width(100).Image(rutaLogo);

                col.Item().AlignCenter().Text("UNIVERSIDAD").SemiBold().FontSize(16);
                col.Item().AlignCenter().Text("SISTEMA DE SEGUIMIENTO DE TESIS").FontSize(12);
                col.Item().AlignCenter().Text($"INFORME DE AVANCE {informe.NumeroInforme}").SemiBold().FontSize(14);
                col.Item().PaddingVertical(5);
            });
        }

        private void CuerpoInforme(IContainer container, InformeCabecera informe, List<InformeDetalle> actividades)
        {
            container.Column(col =>
            {
                col.Item().Row(row =>
                {
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text($"Estudiante: {informe.Estudiante?.Nombres} {informe.Estudiante?.Apellidos}").SemiBold();
                        c.Item().Text($"Carrera: {informe.Estudiante?.Carrera}");
                        c.Item().Text($"Titulo: {informe.Estudiante?.TituloTesis}");
                        c.Item().Text($"Resolucion: {informe.Estudiante?.NumeroResolucion}");
                    });
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text($"Fecha: {informe.FechaEmision:dd/MM/yyyy}");
                        c.Item().Text($"Estado: {informe.Estado}");
                        c.Item().Text($"% Acumulado: {informe.PorcentajeAcumulado}%");
                        c.Item().Text($"Profesor: {informe.Profesor?.Nombres} {informe.Profesor?.Apellidos}");
                    });
                });

                col.Item().PaddingVertical(10);
                col.Item().Text("ACTIVIDADES REALIZADAS").SemiBold().FontSize(12);
                col.Item().PaddingVertical(5);

                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(c =>
                    {
                        c.ConstantColumn(40);
                        c.RelativeColumn();
                        c.ConstantColumn(60);
                        c.ConstantColumn(100);
                    });

                    table.Header(header =>
                    {
                        header.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("#").SemiBold();
                        header.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("Actividad").SemiBold();
                        header.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("%").SemiBold();
                        header.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("Observacion").SemiBold();
                    });

                    foreach (var act in actividades)
                    {
                        table.Cell().Border(1).AlignCenter().Text(act.NumeroActividad.ToString());
                        table.Cell().Border(1).Text(act.DescripcionActividad);
                        table.Cell().Border(1).AlignCenter().Text($"{act.PorcentajeActividad}%");
                        table.Cell().Border(1).Text(act.Observacion ?? "");
                    }
                });

                col.Item().PaddingVertical(10);
                col.Item().AlignRight().Text($"Total: {informe.PorcentajeAcumulado}%").SemiBold().FontSize(12);

                if (informe.EsFinal == true)
                {
                    col.Item().PaddingVertical(10);
                    col.Item().Background(Colors.Green.Lighten4).Padding(10).AlignCenter().Text(
                        "TESIS APROBADA - 100% COMPLETADO").SemiBold().FontSize(14).FontColor(Colors.Green.Darken3);
                }
            });
        }

        private void CabeceraFinal(IContainer container, Estudiante estudiante, string rutaLogo)
        {
            container.Column(col =>
            {
                if (File.Exists(rutaLogo))
                    col.Item().Width(100).Image(rutaLogo);

                col.Item().AlignCenter().Text("UNIVERSIDAD").SemiBold().FontSize(16);
                col.Item().AlignCenter().Text("SISTEMA DE SEGUIMIENTO DE TESIS").FontSize(12);
                col.Item().AlignCenter().Text("INFORME FINAL DE TESIS").SemiBold().FontSize(14);
                col.Item().PaddingVertical(5);
            });
        }

        private void CuerpoFinal(IContainer container, Estudiante estudiante, List<HistorialProgresion> historial)
        {
            container.Column(col =>
            {
                col.Item().Row(row =>
                {
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text($"Estudiante: {estudiante.Nombres} {estudiante.Apellidos}").SemiBold();
                        c.Item().Text($"Cedula: {estudiante.Cedula}");
                        c.Item().Text($"Carrera: {estudiante.Carrera}");
                        c.Item().Text($"Titulo: {estudiante.TituloTesis}");
                        c.Item().Text($"Resolucion: {estudiante.NumeroResolucion} - {estudiante.FechaResolucion:dd/MM/yyyy}");
                    });
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text($"Estado Final: {estudiante.Estado}");
                        c.Item().Text($"% Final: {estudiante.PorcentajeAvance}%");
                        c.Item().Text($"Registro: {estudiante.FechaRegistro:dd/MM/yyyy}");
                    });
                });

                col.Item().PaddingVertical(15);
                col.Item().Text("HISTORIAL DE PROGRESION").SemiBold().FontSize(12);
                col.Item().PaddingVertical(5);

                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(c =>
                    {
                        c.ConstantColumn(30);
                        c.RelativeColumn();
                        c.ConstantColumn(50);
                        c.ConstantColumn(70);
                        c.ConstantColumn(80);
                    });

                    table.Header(header =>
                    {
                        header.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("#").SemiBold();
                        header.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("Actividades").SemiBold();
                        header.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("%").SemiBold();
                        header.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("Estado").SemiBold();
                        header.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("Fecha").SemiBold();
                    });

                    int i = 1;
                    foreach (var h in historial)
                    {
                        table.Cell().Border(1).AlignCenter().Text(i.ToString());
                        table.Cell().Border(1).Text(h.ResumenActividades ?? "");
                        table.Cell().Border(1).AlignCenter().Text($"{h.PorcentajeEnInforme}%");
                        table.Cell().Border(1).AlignCenter().Text(h.EstadoEnInforme);
                        table.Cell().Border(1).AlignCenter().Text($"{h.FechaInforme:dd/MM/yyyy}");
                        i++;
                    }
                });

                col.Item().PaddingVertical(15);
                col.Item().Background(Colors.Green.Lighten4).Padding(10).AlignCenter().Text(
                    "TESIS APROBADA AL 100%").SemiBold().FontSize(16).FontColor(Colors.Green.Darken3);

                col.Item().PaddingVertical(20);
                col.Item().Row(row =>
                {
                    row.RelativeItem().AlignCenter().Column(c =>
                    {
                        c.Item().PaddingTop(30).Width(200).LineHorizontal(1);
                        c.Item().AlignCenter().Text($"{estudiante.Profesor?.Nombres} {estudiante.Profesor?.Apellidos}");
                        c.Item().AlignCenter().Text("Profesor Asesor");
                    });
                });
            });
        }
    }
}
