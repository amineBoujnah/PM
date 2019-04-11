
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Report
{
    public class DeclarationReport
    {
        #region Declaration
        int _totalColumn = 4;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(4);
        PdfPCell _pdfPCell;
        MemoryStream _memoryStream = new MemoryStream();
        //List<DeclarationVM> _declarations = new List<DeclarationVM>();
        #endregion

        //public byte[] PrepareReport(List<DeclarationVM> declarations)
        //{
        //    _declarations = declarations;
        //    #region
        //    _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
        //    _document.SetPageSize(PageSize.A4);
        //    _document.SetMargins(10f, 10f, 10f, 10f);
        //    _pdfTable.WidthPercentage = 100;
        //    _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
        //    _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
        //    PdfWriter.GetInstance(_document, _memoryStream);
        //    _document.Open();
        //    _pdfTable.SetWidths(new float[] { 30f, 50f, 20f,20f});
        //    #endregion

        //    this.ReportHeader();
        //    this.ReportBody();
        //    _pdfTable.HeaderRows = 4;
        //    _document.Add(_pdfTable);
        //    _document.Close();
        //    return _memoryStream.ToArray();
        //}

        //private void ReportHeader()
        //{
        //    _fontStyle = FontFactory.GetFont("Arial", 15f, 1);
        //    _pdfPCell = new PdfPCell(new Phrase("Liste des déclarations", _fontStyle));
        //    _pdfPCell.Colspan = _totalColumn;
        //    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    _pdfPCell.Border = 0;
        //    _pdfPCell.BackgroundColor = BaseColor.WHITE;
        //    _pdfPCell.ExtraParagraphSpace = 0;
        //    _pdfTable.AddCell(_pdfPCell);
        //    _pdfTable.CompleteRow();

        //}



        private void ReportBody()
        {
            #region Table header
            _pdfPCell = new PdfPCell(new Phrase("Auteur", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);


          


           
            _pdfPCell = new PdfPCell(new Phrase("Fichier", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

           
            _pdfPCell = new PdfPCell(new Phrase("Titre", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);


            
            _pdfPCell = new PdfPCell(new Phrase("Preuve", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();
            #endregion


            //#region Table Body
            //_fontStyle = FontFactory.GetFont("Tahoma", 11f, 0);
            //foreach(DeclarationVM decla in _declarations)
            //{
            //    _pdfPCell = new PdfPCell(new Phrase(decla.auteur, _fontStyle));
            //    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //    _pdfPCell.BackgroundColor = BaseColor.WHITE;
            //    _pdfPCell.ExtraParagraphSpace = 0;
                _pdfTable.AddCell(_pdfPCell);

               

        //        _pdfPCell = new PdfPCell(new Phrase(decla.fichier, _fontStyle));
        //        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
        //        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //        _pdfPCell.BackgroundColor = BaseColor.WHITE;
        //        _pdfPCell.ExtraParagraphSpace = 0;
        //        Image jpg = Image.GetInstance("http://localhost/" + decla.fichier);
        //        _pdfTable.AddCell(jpg);
        //       // _pdfTable.AddCell(_pdfPCell);

        //        _pdfPCell = new PdfPCell(new Phrase(decla.titre, _fontStyle));
        //        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
        //        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //        _pdfPCell.BackgroundColor = BaseColor.WHITE;
        //        _pdfPCell.ExtraParagraphSpace = 0;
        //        _pdfTable.AddCell(_pdfPCell);

        //        _pdfPCell = new PdfPCell(new Phrase(decla.preuve, _fontStyle));
        //        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
        //        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //        _pdfPCell.BackgroundColor = BaseColor.WHITE;
        //        _pdfPCell.ExtraParagraphSpace = 0;
        //        Anchor anchor = new Anchor("cliquez sur la preuve");
        //        anchor.Reference = "http://localhost/"+decla.preuve;
        //        _pdfTable.AddCell(anchor);
               
        //        _pdfTable.CompleteRow();
        //    }
        //    #endregion
        }
    }
}