using NPOI.HSSF.UserModel;  // Para XLS
using NPOI.SS.UserModel;    // Interfaz común a XLS y XLSX
using NPOI.XSSF.UserModel;  // Para XLSX
using NPOI.XWPF.Extractor;  // Para extraer texto de DOCX
using NPOI.XWPF.UserModel;  // Para DOCX
using System.Text;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace Devsmartsoft.ServicioTecnicoApi.Shared.Helpers
{
    public class ConvertFileToText
    {
        public static async Task<string> GetTextFromFileAsync(Stream fileStream, string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLowerInvariant();

            switch (extension)
            {
                case ".txt":
                    // Leer directamente el texto desde el stream
                    using (var reader = new StreamReader(fileStream))
                    {
                        return await reader.ReadToEndAsync();
                    }

                case ".pdf":
                    // Extraer texto usando UglyToad.PdfPig desde un stream
                    return ExtractPdfText(fileStream);

                case ".xls":
                case ".xlsx":
                    // Extraer texto usando NPOI desde un stream
                    return ExtractExcelText(fileStream);

                case ".doc":
                case ".docx":
                    // Extraer texto usando NPOI (HWPF para .doc y XWPF para .docx)
                    return ExtractWordText(fileStream, extension);

                default:
                    return "[Extensión de archivo no soportada para extracción de texto]";
            }
        }

        #region PDF con UglyToad.PdfPig

        private static string ExtractPdfText(Stream pdfStream)
        {
            var sb = new StringBuilder();
            using (var document = PdfDocument.Open(pdfStream))
            {
                foreach (Page page in document.GetPages())
                {
                    sb.AppendLine(page.Text);
                }
            }
            return sb.ToString();
        }

        private static string ExtractPdfText(string pdfPath)
        {
            var sb = new StringBuilder();

            // UglyToad.PdfPig: leer el PDF y extraer texto de cada página
            using (PdfDocument document = PdfDocument.Open(pdfPath))
            {
                foreach (Page page in document.GetPages())
                {
                    sb.AppendLine(page.Text);
                }
            }

            return sb.ToString();
        }
        #endregion

        #region Excel con NPOI (XLS o XLSX)
        private static string ExtractExcelText(Stream excelStream)
        {
            var sb = new StringBuilder();

            // Dependiendo de si es .xls o .xlsx
            // Ej: si es .xlsx => new XSSFWorkbook(excelStream)
            // si es .xls => new HSSFWorkbook(excelStream)
            // Aquí te muestro uno genérico:
            IWorkbook workbook;
            // Para simplificar, asume XLSX:
            workbook = new XSSFWorkbook(excelStream);

            for (int i = 0; i < workbook.NumberOfSheets; i++)
            {
                ISheet sheet = workbook.GetSheetAt(i);
                sb.AppendLine($"---- Hoja: {sheet.SheetName} ----");
                for (int rowIndex = 0; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    IRow row = sheet.GetRow(rowIndex);
                    if (row == null) continue;
                    var rowText = new List<string>();
                    for (int colIndex = 0; colIndex < row.LastCellNum; colIndex++)
                    {
                        NPOI.SS.UserModel.ICell cell = row.GetCell(colIndex);
                        rowText.Add(cell?.ToString() ?? "");
                    }
                    sb.AppendLine(string.Join("\t", rowText));
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
        private static string ExtractExcelText(string excelPath)
        {
            var sb = new StringBuilder();

            // Abrimos el archivo y determinamos si es XLS o XLSX
            using var fs = new FileStream(excelPath, FileMode.Open, FileAccess.Read);

            IWorkbook workbook;

            if (excelPath.EndsWith(".xls"))
            {
                // Formato Excel 97-2003
                workbook = new HSSFWorkbook(fs);
            }
            else
            {
                // Formato Excel 2007+
                workbook = new XSSFWorkbook(fs);
            }

            // Recorremos todas las hojas y filas
            for (int sheetIndex = 0; sheetIndex < workbook.NumberOfSheets; sheetIndex++)
            {
                ISheet sheet = workbook.GetSheetAt(sheetIndex);
                sb.AppendLine($"---- Hoja: {sheet.SheetName} ----");

                for (int rowIndex = 0; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    IRow row = sheet.GetRow(rowIndex);
                    if (row == null) continue;

                    var rowText = new List<string>();
                    for (int colIndex = 0; colIndex < row.LastCellNum; colIndex++)
                    {
                        NPOI.SS.UserModel.ICell cell = row.GetCell(colIndex);
                        if (cell == null)
                        {
                            rowText.Add("");
                            continue;
                        }

                        // Convertimos el valor a string
                        rowText.Add(cell.ToString() ?? "");
                    }

                    // Unimos las celdas con un separador
                    sb.AppendLine(string.Join("\t", rowText));
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
        #endregion

        #region Word con NPOI (DOCX)
        private static string ExtractWordText(Stream wordStream, string extension)
        {
            if (extension == ".doc")
            {
                // Word 97-2003
                XWPFDocument doc = new XWPFDocument(wordStream);
                XWPFWordExtractor extractor = new XWPFWordExtractor(doc);
                return extractor.Text;
            }
            else
            {
                // Word .docx
                XWPFDocument docx = new XWPFDocument(wordStream);
                XWPFWordExtractor extractor = new XWPFWordExtractor(docx);
                return extractor.Text;
            }
        }
        private static string ExtractWordText(string wordPath)
        {
            // Tomamos la extensión en minúscula
            string extension = Path.GetExtension(wordPath).ToLowerInvariant();
            // Abrimos el archivo en modo lectura
            using var fs = new FileStream(wordPath, FileMode.Open, FileAccess.Read);

            // Archivos Word 2007+ (formato .docx)
            // 1. Cargamos el documento con XWPFDocument
            XWPFDocument docx = new XWPFDocument(fs);
            // 2. Usamos XWPFWordExtractor para extraer el texto
            XWPFWordExtractor extractor = new XWPFWordExtractor(docx);
            return extractor.Text;
        }
        #endregion
    }
}
