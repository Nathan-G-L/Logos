using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using nameSpaceWF;

namespace Logos_Rotulagem
{
    public partial class Form1 : Form
    {
        CLS_BDCONECTA Conn = new CLS_BDCONECTA();
        DataTable Data = new DataTable();
        public Form1()
        {
            InitializeComponent();
            cbATU();

            CriaGrid();
            AtualizaGrid();
        }

        #region GRID
        public void CriaGrid()
        {
            Data.Columns.Add("ID", typeof(string));
            Data.Columns.Add("CODIGO", typeof(string));
            Data.Columns.Add("DESCRIÇÃO", typeof(string));
            Data.Columns.Add("LOGO", typeof(string));
            Data.Columns.Add("DESCRIÇÃO CLIENTE", typeof(string));
        }
        public void AtualizaGrid()
        {
            Data.Rows.Clear();
            string[,] select=Conn.FastSelect("select logo_rotulagem.ID,COD_PROD,descr_prd_pr5030 DESCR,ROTULO LOGO,DESCR_ESPECIAL " +
                "from logo_rotulagem " +
                "left join pr5030 on COD_PROD = cod_prd_pr5030 " +
                "left join logo_design on logo_design.ID = LOGO" +
                " order by 1");

            if (select[0, 0] != "" && select[0, 0] != null)
            {
                for (int i = 0; i < select.GetLength(0); i++)
                {
                    Data.Rows.Add(select[i,0], select[i, 1], select[i, 2], select[i, 3],select[i,4]);
                    //Cria_Logo(select[i, 1]);
                }            //    
            }
            dataGridView1.DataSource = Data;
            //OFOPE.DefaultView.RowFilter= "Operador = '"+cbOPE1.Text+"'";
            //dgwTEC.Sort(dgwTEC.Columns[0],0);
        }

        #endregion

        #region BOTAO
        private void btCAD_Click(object sender, EventArgs e)
        {
            string[,] existe = Conn.FastSelect("select COD_PROD from logo_rotulagem where COD_PROD='"+txCOD.Text+"'");
            if (existe[0, 0] != null) { btCAD.Text = "ATUALIZAR"; }

            if (btCAD.Text == "CADASTRAR")
            {
                string[,] teste = Conn.FastSelect("select cod_prd_pr5030 from pr5030 where cod_prd_pr5030 ='" + txCOD.Text + "'");
                
                if (teste[0, 0] != null)
                {
                    string LOGO = "NULL";
                    string DESCR = txDESCR.Text.Replace("'","");
                    if (cbLOGO.SelectedIndex != -1)
                    {
                        LOGO = cbLOGO.Text.Split('-')[0].Trim();
                    }
                    string insert = "insert into logo_rotulagem values ('" + txCOD.Text + "'," + LOGO + ",'"+DESCR+"')";

                    DialogResult YN = MessageBox.Show("Deseja inserir peça?", "Tem certeza?", MessageBoxButtons.YesNo);

                    if (YN == DialogResult.Yes)
                    {
                        Conn.Play("", insert, "");
                        MessageBox.Show("PEÇA INSERIDA!");
                        Cria_Logo(txCOD.Text);
                    }
                    
                }
                else { MessageBox.Show("Favor inserir peça valida!"); }
            }
            else
            {
                string LOGO = "NULL";
                if (cbLOGO.SelectedIndex != -1)
                {
                    LOGO = cbLOGO.Text.Split('-')[0].Trim();
                }
                string upd = "update logo_rotulagem set LOGO=" + LOGO + ",DESCR_ESPECIAL='"+txDESCR.Text+"' where COD_PROD='" + txCOD.Text + "'";

                DialogResult YN = MessageBox.Show("Deseja atualizar a peça?", "Tem certeza?", MessageBoxButtons.YesNo);

                if (YN == DialogResult.Yes)
                {
                    Conn.Play(upd, "", "");
                    MessageBox.Show("PEÇA ATUALIZADA!");
                    Cria_Logo(txCOD.Text);
                }

                txCOD.Text = "";
                lbDESCR.Text = "";
                cbLOGO.SelectedIndex = -1;
                txDESCR.Text = "";
                btCAD.Text = "CADASTRAR";
            }
            AtualizaGrid();
        }
        #endregion

        #region AÇAO
        public void cbATU()
        {
            string[,] logos = Conn.FastSelect("select ID,ROTULO from logo_design where ATIVO=1");
            for (int i = 0; i < logos.GetLength(0); i++)
            {
                cbLOGO.Items.Add(logos[i, 0] + " - " + logos[i, 1]);
            }
        }

        static void Cria_Logo(string produto)
        {
            CLS_BDCONECTA Conn = new CLS_BDCONECTA();
            string[,] infos = Conn.FastSelect("select logo_rotulagem.ID,COD_PROD,descr_prd_pr5030 DESCR,ROTULO LOGO,DESCR_ESPECIAL 'DESCRIÇÃO ESPECIAL',CAMINHO " +
                "from logo_rotulagem " +
                "left join pr5030 on COD_PROD = cod_prd_pr5030 " +
                "left join logo_design on logo_design.ID = LOGO " +
                "where COD_PROD = '" + produto + "'");
            string Descr = "";
            string logo = "";

            if (infos[0, 4] == null || infos[0, 4] == "") { Descr = infos[0, 2].ToUpper(); } else { Descr = infos[0, 4].ToUpper(); }
            if (infos[0, 3] != "" || infos[0, 3] != null) { logo = infos[0, 5]; }

            string altura = "15";
            if (Descr.Contains("  ") || Descr.Contains("\t"))
            {
                altura = "30";
            }

            string xmlContent = $@"<?xml version=""1.0""?>
<XMLTemplateObject xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <PathCSV />
  <ConnectionType />
  <FileName />
  <TemplateHeight>48</TemplateHeight>
  <SheetIndex>0</SheetIndex>
  <TemplateWidth>756</TemplateWidth>
  <ShapeObject>
    <XMLShapeObject>
      <IsInvalidBarcode>false</IsInvalidBarcode>
      <Mask>{Descr}</Mask>
      <TBarcodeObject>
        <ModuleWidth>0</ModuleWidth>
        <TBarcodeType>0</TBarcodeType>
        <BearerBarWidth>0</BearerBarWidth>
        <BearerBarType>0</BearerBarType>
        <IsOptimization>false</IsOptimization>
        <IsFit>false</IsFit>
        <IsTextVisible>false</IsTextVisible>
        <IsTextAbove>false</IsTextAbove>
        <SynchronizationBarsHeight>0</SynchronizationBarsHeight>
        <TextAlignment>0</TextAlignment>
        <TextMargin>0</TextMargin>
        <QuietZonesUnit>0</QuietZonesUnit>
        <QuietZoneLeftSize>0</QuietZoneLeftSize>
        <QuietZoneRightSize>0</QuietZoneRightSize>
        <QuietZoneTopSize>0</QuietZoneTopSize>
        <QuietZoneBottomSize>0</QuietZoneBottomSize>
        <InkCompensation>0</InkCompensation>
        <CODABLOCKF_FORMAT>0</CODABLOCKF_FORMAT>
        <CODABLOCKF_NumberOfColumns>0</CODABLOCKF_NumberOfColumns>
        <CODABLOCKF_NumberOfRows>0</CODABLOCKF_NumberOfRows>
        <CODABLOCKF_RowHeight>0</CODABLOCKF_RowHeight>
        <CODABLOCKF_RowSeparatorHeight>0</CODABLOCKF_RowSeparatorHeight>
        <Aztec_ErrCorrection>0</Aztec_ErrCorrection>
        <Aztec_FORMAT>0</Aztec_FORMAT>
        <Aztec_SymbolSize>0</Aztec_SymbolSize>
        <Aztec_IsBinaryEncoding>false</Aztec_IsBinaryEncoding>
        <Aztec_IsRuneMode>false</Aztec_IsRuneMode>
        <Aztec_IsStructuredAppendActive>false</Aztec_IsStructuredAppendActive>
        <Aztec_StructuredAppendIndex>0</Aztec_StructuredAppendIndex>
        <Aztec_StructuredAppendTotal>0</Aztec_StructuredAppendTotal>
        <DataMatrix_Format>0</DataMatrix_Format>
        <DataMatrix_SIZE>0</DataMatrix_SIZE>
        <DataMatrix_IsBinaryEncoding>false</DataMatrix_IsBinaryEncoding>
        <DataMatrix_IsRectangular>false</DataMatrix_IsRectangular>
        <DataMatrix_StructuredAppendIndex>0</DataMatrix_StructuredAppendIndex>
        <DataMatrix_StructuredAppendSUM>0</DataMatrix_StructuredAppendSUM>
        <DataMatrix_StructuredAppendFileID>0</DataMatrix_StructuredAppendFileID>
        <DOTCODE_FORMAT>0</DOTCODE_FORMAT>
        <DOTCODE_IsStructuredAppendActive>false</DOTCODE_IsStructuredAppendActive>
        <DOTCODE_MASK>0</DOTCODE_MASK>
        <DOTCODE_DIRECTION>0</DOTCODE_DIRECTION>
        <DOTCODE_IsBinaryEncoding>false</DOTCODE_IsBinaryEncoding>
        <DOTCODE_SIZEMODE>0</DOTCODE_SIZEMODE>
        <DOTCODE_StructuredAppendIndex>0</DOTCODE_StructuredAppendIndex>
        <DOTCODE_StructuredAppendTotal>0</DOTCODE_StructuredAppendTotal>
        <HANXIN_ECL>0</HANXIN_ECL>
        <HANXIN_MASK>0</HANXIN_MASK>
        <HANXIN_IsBinaryEncoding>false</HANXIN_IsBinaryEncoding>
        <HANXIN_VERSION>0</HANXIN_VERSION>
        <MAXICODE_MODE>0</MAXICODE_MODE>
        <MAXICODE_IsUsePreamble>false</MAXICODE_IsUsePreamble>
        <MAXICODE_StructuredAppendIndex>0</MAXICODE_StructuredAppendIndex>
        <MAXICODE_StructureAppendSUM>0</MAXICODE_StructureAppendSUM>
        <MAXICODE_UnderCut>0</MAXICODE_UnderCut>
        <PDF_ENCODINGMODE>0</PDF_ENCODINGMODE>
        <PDF_ECL>0</PDF_ECL>
        <PDF_NumberOfColumns>0</PDF_NumberOfColumns>
        <PDF_NumberOfRows>0</PDF_NumberOfRows>
        <PDF_RowHeight>0</PDF_RowHeight>
        <PDF_CheckSumCCITT16>0</PDF_CheckSumCCITT16>
        <PDF_FileSize>0</PDF_FileSize>
        <PDF_IsLastSegment>false</PDF_IsLastSegment>
        <PDF_SegmentCount>0</PDF_SegmentCount>
        <PDF_SegmentIndex>0</PDF_SegmentIndex>
        <PDF_TimeStamp>0</PDF_TimeStamp>
        <MPDF_ENCODINGMODE>0</MPDF_ENCODINGMODE>
        <MPDF_Version>0</MPDF_Version>
        <QRCode_ECL>0</QRCode_ECL>
        <QRCode_FORMAT>0</QRCode_FORMAT>
        <QRCode_COMPACTION>0</QRCode_COMPACTION>
        <QRCode_MASK>0</QRCode_MASK>
        <QRCode_VERSION>0</QRCode_VERSION>
        <QRCode_StructuredAppendIndex>0</QRCode_StructuredAppendIndex>
        <QRCode_StructuredAppendSUM>0</QRCode_StructuredAppendSUM>
        <QRCode_StructuredAppendParity>0</QRCode_StructuredAppendParity>
        <MQRCode_MASK>0</MQRCode_MASK>
        <MQRCode_VERSION>0</MQRCode_VERSION>
        <CompositeComponentType>0</CompositeComponentType>
        <RSS_NumberOfSegmentPerRow>0</RSS_NumberOfSegmentPerRow>
      </TBarcodeObject>
      <TypeShape>StringShape</TypeShape>
      <Angle>0</Angle>
      <LocationX>303</LocationX>
      <LocationY>17</LocationY>
      <MinimumWidth>300</MinimumWidth>
      <MinimumHeight>{altura}</MinimumHeight>
      <BoundWidth>300</BoundWidth>
      <BoundHeight>{altura}</BoundHeight>
      <Lock>false</Lock>
      <IsBarcode>false</IsBarcode>
      <GS1>false</GS1>
      <IsSameSize>false</IsSameSize>
      <LineType>0</LineType>
      <StartRow>0</StartRow>
      <EndRow>0</EndRow>
      <Loop>false</Loop>
      <TextData>{Descr}</TextData>
      <FontFamilyName>Arial</FontFamilyName>
      <FontSize>9</FontSize>
      <FontStyle>Regular</FontStyle>
      <VertAlignment>Near</VertAlignment>
      <HoriAlignment>Near</HoriAlignment>
      <NumberTypeSerial>false</NumberTypeSerial>
      <AddZero>false</AddZero>
      <LeadingAdd>false</LeadingAdd>
      <SpaceMinimumLength>0</SpaceMinimumLength>
      <Start>0</Start>
      <End>0</End>
      <Step>0</Step>
      <Repeat>0</Repeat>
      <BarcodeName>0</BarcodeName>
      <ShortTallBar>0</ShortTallBar>
      <MarginBottom>0</MarginBottom>
      <MarginTop>0</MarginTop>
      <MarginRight>0</MarginRight>
      <MarginLeft>0</MarginLeft>
      <VerBearBar>0</VerBearBar>
      <HorBearBar>0</HorBearBar>
      <BarRatio>0</BarRatio>
      <BarHeight>0</BarHeight>
      <BarWidth>0</BarWidth>
      <MarginText>0</MarginText>
      <Resolution>0</Resolution>
      <CalculateCheckSum>false</CalculateCheckSum>
      <DisplayCheckSum>false</DisplayCheckSum>
      <PDFTruncate>false</PDFTruncate>
      <DisplayBarcodeData>false</DisplayBarcodeData>
      <DisplayAsterisk>false</DisplayAsterisk>
      <PDFColumnCount>0</PDFColumnCount>
      <PDFRowCount>0</PDFRowCount>
      <FontSizeBarcode>0</FontSizeBarcode>
      <LineBold>0</LineBold>
      <BrushType>0</BrushType>
      <Threshold>0</Threshold>
      <ListPODData />
    </XMLShapeObject>
    <XMLShapeObject>
      <IsInvalidBarcode>false</IsInvalidBarcode>
      <TBarcodeObject>
        <ModuleWidth>0</ModuleWidth>
        <TBarcodeType>0</TBarcodeType>
        <BearerBarWidth>0</BearerBarWidth>
        <BearerBarType>0</BearerBarType>
        <IsOptimization>false</IsOptimization>
        <IsFit>false</IsFit>
        <IsTextVisible>false</IsTextVisible>
        <IsTextAbove>false</IsTextAbove>
        <SynchronizationBarsHeight>0</SynchronizationBarsHeight>
        <TextAlignment>0</TextAlignment>
        <TextMargin>0</TextMargin>
        <QuietZonesUnit>0</QuietZonesUnit>
        <QuietZoneLeftSize>0</QuietZoneLeftSize>
        <QuietZoneRightSize>0</QuietZoneRightSize>
        <QuietZoneTopSize>0</QuietZoneTopSize>
        <QuietZoneBottomSize>0</QuietZoneBottomSize>
        <InkCompensation>0</InkCompensation>
        <CODABLOCKF_FORMAT>0</CODABLOCKF_FORMAT>
        <CODABLOCKF_NumberOfColumns>0</CODABLOCKF_NumberOfColumns>
        <CODABLOCKF_NumberOfRows>0</CODABLOCKF_NumberOfRows>
        <CODABLOCKF_RowHeight>0</CODABLOCKF_RowHeight>
        <CODABLOCKF_RowSeparatorHeight>0</CODABLOCKF_RowSeparatorHeight>
        <Aztec_ErrCorrection>0</Aztec_ErrCorrection>
        <Aztec_FORMAT>0</Aztec_FORMAT>
        <Aztec_SymbolSize>0</Aztec_SymbolSize>
        <Aztec_IsBinaryEncoding>false</Aztec_IsBinaryEncoding>
        <Aztec_IsRuneMode>false</Aztec_IsRuneMode>
        <Aztec_IsStructuredAppendActive>false</Aztec_IsStructuredAppendActive>
        <Aztec_StructuredAppendIndex>0</Aztec_StructuredAppendIndex>
        <Aztec_StructuredAppendTotal>0</Aztec_StructuredAppendTotal>
        <DataMatrix_Format>0</DataMatrix_Format>
        <DataMatrix_SIZE>0</DataMatrix_SIZE>
        <DataMatrix_IsBinaryEncoding>false</DataMatrix_IsBinaryEncoding>
        <DataMatrix_IsRectangular>false</DataMatrix_IsRectangular>
        <DataMatrix_StructuredAppendIndex>0</DataMatrix_StructuredAppendIndex>
        <DataMatrix_StructuredAppendSUM>0</DataMatrix_StructuredAppendSUM>
        <DataMatrix_StructuredAppendFileID>0</DataMatrix_StructuredAppendFileID>
        <DOTCODE_FORMAT>0</DOTCODE_FORMAT>
        <DOTCODE_IsStructuredAppendActive>false</DOTCODE_IsStructuredAppendActive>
        <DOTCODE_MASK>0</DOTCODE_MASK>
        <DOTCODE_DIRECTION>0</DOTCODE_DIRECTION>
        <DOTCODE_IsBinaryEncoding>false</DOTCODE_IsBinaryEncoding>
        <DOTCODE_SIZEMODE>0</DOTCODE_SIZEMODE>
        <DOTCODE_StructuredAppendIndex>0</DOTCODE_StructuredAppendIndex>
        <DOTCODE_StructuredAppendTotal>0</DOTCODE_StructuredAppendTotal>
        <HANXIN_ECL>0</HANXIN_ECL>
        <HANXIN_MASK>0</HANXIN_MASK>
        <HANXIN_IsBinaryEncoding>false</HANXIN_IsBinaryEncoding>
        <HANXIN_VERSION>0</HANXIN_VERSION>
        <MAXICODE_MODE>0</MAXICODE_MODE>
        <MAXICODE_IsUsePreamble>false</MAXICODE_IsUsePreamble>
        <MAXICODE_StructuredAppendIndex>0</MAXICODE_StructuredAppendIndex>
        <MAXICODE_StructureAppendSUM>0</MAXICODE_StructureAppendSUM>
        <MAXICODE_UnderCut>0</MAXICODE_UnderCut>
        <PDF_ENCODINGMODE>0</PDF_ENCODINGMODE>
        <PDF_ECL>0</PDF_ECL>
        <PDF_NumberOfColumns>0</PDF_NumberOfColumns>
        <PDF_NumberOfRows>0</PDF_NumberOfRows>
        <PDF_RowHeight>0</PDF_RowHeight>
        <PDF_CheckSumCCITT16>0</PDF_CheckSumCCITT16>
        <PDF_FileSize>0</PDF_FileSize>
        <PDF_IsLastSegment>false</PDF_IsLastSegment>
        <PDF_SegmentCount>0</PDF_SegmentCount>
        <PDF_SegmentIndex>0</PDF_SegmentIndex>
        <PDF_TimeStamp>0</PDF_TimeStamp>
        <MPDF_ENCODINGMODE>0</MPDF_ENCODINGMODE>
        <MPDF_Version>0</MPDF_Version>
        <QRCode_ECL>0</QRCode_ECL>
        <QRCode_FORMAT>0</QRCode_FORMAT>
        <QRCode_COMPACTION>0</QRCode_COMPACTION>
        <QRCode_MASK>0</QRCode_MASK>
        <QRCode_VERSION>0</QRCode_VERSION>
        <QRCode_StructuredAppendIndex>0</QRCode_StructuredAppendIndex>
        <QRCode_StructuredAppendSUM>0</QRCode_StructuredAppendSUM>
        <QRCode_StructuredAppendParity>0</QRCode_StructuredAppendParity>
        <MQRCode_MASK>0</MQRCode_MASK>
        <MQRCode_VERSION>0</MQRCode_VERSION>
        <CompositeComponentType>0</CompositeComponentType>
        <RSS_NumberOfSegmentPerRow>0</RSS_NumberOfSegmentPerRow>
      </TBarcodeObject>
      <TypeShape>ImageShape</TypeShape>
      <Angle>0</Angle>
      <LocationX>104</LocationX>
      <LocationY>-75</LocationY>
      <MinimumWidth>10</MinimumWidth>
      <MinimumHeight>10</MinimumHeight>
      <BoundWidth>188</BoundWidth>
      <BoundHeight>188</BoundHeight>
      <Lock>false</Lock>
      <IsBarcode>false</IsBarcode>
      <GS1>false</GS1>
      <IsSameSize>false</IsSameSize>
      <LineType>0</LineType>
      <FilePath>{logo}</FilePath>
      <StartRow>0</StartRow>
      <EndRow>0</EndRow>
      <Loop>false</Loop>
      <FontSize>0</FontSize>
      <NumberTypeSerial>false</NumberTypeSerial>
      <AddZero>false</AddZero>
      <LeadingAdd>false</LeadingAdd>
      <SpaceMinimumLength>0</SpaceMinimumLength>
      <Start>0</Start>
      <End>0</End>
      <Step>0</Step>
      <Repeat>0</Repeat>
      <BarcodeName>0</BarcodeName>
      <ShortTallBar>0</ShortTallBar>
      <MarginBottom>0</MarginBottom>
      <MarginTop>0</MarginTop>
      <MarginRight>0</MarginRight>
      <MarginLeft>0</MarginLeft>
      <VerBearBar>0</VerBearBar>
      <HorBearBar>0</HorBearBar>
      <BarRatio>0</BarRatio>
      <BarHeight>0</BarHeight>
      <BarWidth>0</BarWidth>
      <MarginText>0</MarginText>
      <Resolution>0</Resolution>
      <CalculateCheckSum>false</CalculateCheckSum>
      <DisplayCheckSum>false</DisplayCheckSum>
      <PDFTruncate>false</PDFTruncate>
      <DisplayBarcodeData>false</DisplayBarcodeData>
      <DisplayAsterisk>false</DisplayAsterisk>
      <PDFColumnCount>0</PDFColumnCount>
      <PDFRowCount>0</PDFRowCount>
      <FontSizeBarcode>0</FontSizeBarcode>
      <LineBold>0</LineBold>
      <BrushType>0</BrushType>
      <Threshold>500</Threshold>
      <ListPODData />
    </XMLShapeObject>
  </ShapeObject>
</XMLTemplateObject>";//COM LOGO
            if (logo == "")
            { 
                xmlContent = $@"<?xml version=""1.0""?>
<XMLTemplateObject xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <PathCSV />
  <ConnectionType />
  <FileName />
  <TemplateHeight>48</TemplateHeight>
  <SheetIndex>0</SheetIndex>
  <TemplateWidth>756</TemplateWidth>
  <ShapeObject>
    <XMLShapeObject>
      <IsInvalidBarcode>false</IsInvalidBarcode>
      <Mask>{Descr}</Mask>
      <TBarcodeObject>
        <ModuleWidth>0</ModuleWidth>
        <TBarcodeType>0</TBarcodeType>
        <BearerBarWidth>0</BearerBarWidth>
        <BearerBarType>0</BearerBarType>
        <IsOptimization>false</IsOptimization>
        <IsFit>false</IsFit>
        <IsTextVisible>false</IsTextVisible>
        <IsTextAbove>false</IsTextAbove>
        <SynchronizationBarsHeight>0</SynchronizationBarsHeight>
        <TextAlignment>0</TextAlignment>
        <TextMargin>0</TextMargin>
        <QuietZonesUnit>0</QuietZonesUnit>
        <QuietZoneLeftSize>0</QuietZoneLeftSize>
        <QuietZoneRightSize>0</QuietZoneRightSize>
        <QuietZoneTopSize>0</QuietZoneTopSize>
        <QuietZoneBottomSize>0</QuietZoneBottomSize>
        <InkCompensation>0</InkCompensation>
        <CODABLOCKF_FORMAT>0</CODABLOCKF_FORMAT>
        <CODABLOCKF_NumberOfColumns>0</CODABLOCKF_NumberOfColumns>
        <CODABLOCKF_NumberOfRows>0</CODABLOCKF_NumberOfRows>
        <CODABLOCKF_RowHeight>0</CODABLOCKF_RowHeight>
        <CODABLOCKF_RowSeparatorHeight>0</CODABLOCKF_RowSeparatorHeight>
        <Aztec_ErrCorrection>0</Aztec_ErrCorrection>
        <Aztec_FORMAT>0</Aztec_FORMAT>
        <Aztec_SymbolSize>0</Aztec_SymbolSize>
        <Aztec_IsBinaryEncoding>false</Aztec_IsBinaryEncoding>
        <Aztec_IsRuneMode>false</Aztec_IsRuneMode>
        <Aztec_IsStructuredAppendActive>false</Aztec_IsStructuredAppendActive>
        <Aztec_StructuredAppendIndex>0</Aztec_StructuredAppendIndex>
        <Aztec_StructuredAppendTotal>0</Aztec_StructuredAppendTotal>
        <DataMatrix_Format>0</DataMatrix_Format>
        <DataMatrix_SIZE>0</DataMatrix_SIZE>
        <DataMatrix_IsBinaryEncoding>false</DataMatrix_IsBinaryEncoding>
        <DataMatrix_IsRectangular>false</DataMatrix_IsRectangular>
        <DataMatrix_StructuredAppendIndex>0</DataMatrix_StructuredAppendIndex>
        <DataMatrix_StructuredAppendSUM>0</DataMatrix_StructuredAppendSUM>
        <DataMatrix_StructuredAppendFileID>0</DataMatrix_StructuredAppendFileID>
        <DOTCODE_FORMAT>0</DOTCODE_FORMAT>
        <DOTCODE_IsStructuredAppendActive>false</DOTCODE_IsStructuredAppendActive>
        <DOTCODE_MASK>0</DOTCODE_MASK>
        <DOTCODE_DIRECTION>0</DOTCODE_DIRECTION>
        <DOTCODE_IsBinaryEncoding>false</DOTCODE_IsBinaryEncoding>
        <DOTCODE_SIZEMODE>0</DOTCODE_SIZEMODE>
        <DOTCODE_StructuredAppendIndex>0</DOTCODE_StructuredAppendIndex>
        <DOTCODE_StructuredAppendTotal>0</DOTCODE_StructuredAppendTotal>
        <HANXIN_ECL>0</HANXIN_ECL>
        <HANXIN_MASK>0</HANXIN_MASK>
        <HANXIN_IsBinaryEncoding>false</HANXIN_IsBinaryEncoding>
        <HANXIN_VERSION>0</HANXIN_VERSION>
        <MAXICODE_MODE>0</MAXICODE_MODE>
        <MAXICODE_IsUsePreamble>false</MAXICODE_IsUsePreamble>
        <MAXICODE_StructuredAppendIndex>0</MAXICODE_StructuredAppendIndex>
        <MAXICODE_StructureAppendSUM>0</MAXICODE_StructureAppendSUM>
        <MAXICODE_UnderCut>0</MAXICODE_UnderCut>
        <PDF_ENCODINGMODE>0</PDF_ENCODINGMODE>
        <PDF_ECL>0</PDF_ECL>
        <PDF_NumberOfColumns>0</PDF_NumberOfColumns>
        <PDF_NumberOfRows>0</PDF_NumberOfRows>
        <PDF_RowHeight>0</PDF_RowHeight>
        <PDF_CheckSumCCITT16>0</PDF_CheckSumCCITT16>
        <PDF_FileSize>0</PDF_FileSize>
        <PDF_IsLastSegment>false</PDF_IsLastSegment>
        <PDF_SegmentCount>0</PDF_SegmentCount>
        <PDF_SegmentIndex>0</PDF_SegmentIndex>
        <PDF_TimeStamp>0</PDF_TimeStamp>
        <MPDF_ENCODINGMODE>0</MPDF_ENCODINGMODE>
        <MPDF_Version>0</MPDF_Version>
        <QRCode_ECL>0</QRCode_ECL>
        <QRCode_FORMAT>0</QRCode_FORMAT>
        <QRCode_COMPACTION>0</QRCode_COMPACTION>
        <QRCode_MASK>0</QRCode_MASK>
        <QRCode_VERSION>0</QRCode_VERSION>
        <QRCode_StructuredAppendIndex>0</QRCode_StructuredAppendIndex>
        <QRCode_StructuredAppendSUM>0</QRCode_StructuredAppendSUM>
        <QRCode_StructuredAppendParity>0</QRCode_StructuredAppendParity>
        <MQRCode_MASK>0</MQRCode_MASK>
        <MQRCode_VERSION>0</MQRCode_VERSION>
        <CompositeComponentType>0</CompositeComponentType>
        <RSS_NumberOfSegmentPerRow>0</RSS_NumberOfSegmentPerRow>
      </TBarcodeObject>
      <TypeShape>StringShape</TypeShape>
      <Angle>0</Angle>
      <LocationX>162</LocationX>
      <LocationY>11</LocationY>
      <MinimumWidth>300</MinimumWidth>
      <MinimumHeight>{altura}</MinimumHeight>
      <BoundWidth>300</BoundWidth>
      <BoundHeight>{altura}</BoundHeight>
      <Lock>false</Lock>
      <IsBarcode>false</IsBarcode>
      <GS1>false</GS1>
      <IsSameSize>false</IsSameSize>
      <LineType>0</LineType>
      <StartRow>0</StartRow>
      <EndRow>0</EndRow>
      <Loop>false</Loop>
      <TextData>{Descr}</TextData>
      <FontFamilyName>Arial</FontFamilyName>
      <FontSize>9</FontSize>
      <FontStyle>Regular</FontStyle>
      <VertAlignment>Near</VertAlignment>
      <HoriAlignment>Near</HoriAlignment>
      <NumberTypeSerial>false</NumberTypeSerial>
      <AddZero>false</AddZero>
      <LeadingAdd>false</LeadingAdd>
      <SpaceMinimumLength>0</SpaceMinimumLength>
      <Start>0</Start>
      <End>0</End>
      <Step>0</Step>
      <Repeat>0</Repeat>
      <BarcodeName>0</BarcodeName>
      <ShortTallBar>0</ShortTallBar>
      <MarginBottom>0</MarginBottom>
      <MarginTop>0</MarginTop>
      <MarginRight>0</MarginRight>
      <MarginLeft>0</MarginLeft>
      <VerBearBar>0</VerBearBar>
      <HorBearBar>0</HorBearBar>
      <BarRatio>0</BarRatio>
      <BarHeight>0</BarHeight>
      <BarWidth>0</BarWidth>
      <MarginText>0</MarginText>
      <Resolution>0</Resolution>
      <CalculateCheckSum>false</CalculateCheckSum>
      <DisplayCheckSum>false</DisplayCheckSum>
      <PDFTruncate>false</PDFTruncate>
      <DisplayBarcodeData>false</DisplayBarcodeData>
      <DisplayAsterisk>false</DisplayAsterisk>
      <PDFColumnCount>0</PDFColumnCount>
      <PDFRowCount>0</PDFRowCount>
      <FontSizeBarcode>0</FontSizeBarcode>
      <LineBold>0</LineBold>
      <BrushType>0</BrushType>
      <Threshold>0</Threshold>
      <ListPODData />
    </XMLShapeObject>
  </ShapeObject>
</XMLTemplateObject>";//SEM LOGO
            }//SEM LOGO
            string caminhoArquivo = "M:\\EXPEDIÇÃO\\ROTULAGEM\\LIMAS\\" + infos[0, 0] + ".mlg";

            // Gravando o valor no arquivo .mlg
            File.WriteAllText(caminhoArquivo, xmlContent);

            xmlContent = "<?xml version=\"1.0\"?><Configs>"
            + "<SWOdd>True</SWOdd><SWEven>False</SWEven><AutoSW>False</AutoSW>"
            + "<TimesAutoSW>1</TimesAutoSW><SWIMP>False</SWIMP><TimeIMP>15</TimeIMP>"
            + "<MeasureUnit>1</MeasureUnit><Direction>1</Direction><Inverts>False</Inverts>"
            + "<Density>3</Density><Resolution>5</Resolution><PrintMode>Sensor</PrintMode>"
            + "<FixLength>10</FixLength><SensorMode>Internal</SensorMode><DisToPH>0</DisToPH>"
            + "<MBefore>30</MBefore><MAfter>10</MAfter><Repeat>0</Repeat><LRepeat>10</LRepeat>"
            + "<Encoder>False</Encoder><Speed>10</Speed><UnRepeatAll>False</UnRepeatAll></Configs>";

            caminhoArquivo = $"M:\\EXPEDIÇÃO\\ROTULAGEM\\LIMAS\\{infos[0, 0]}.mlg.xml";

            File.WriteAllText(caminhoArquivo, xmlContent);

            MessageBox.Show("Logo " + infos[0, 0] + " criado!");
        }

        #endregion

        #region MAGIA
        private void txCOD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//ENTER
            {
                string[,] descr = Conn.FastSelect("select descr_prd_pr5030 from pr5030 where cod_prd_pr5030='" + txCOD.Text + "'");
                lbDESCR.Text = descr[0, 0];
            }
        }
        private void cbLOGO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)//BACK
            {

                cbLOGO.SelectedIndex = -1;
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = dataGridView1.SelectedCells[0].RowIndex;
            txCOD.Text = dataGridView1.Rows[a].Cells[1].Value.ToString();

            int index = cbLOGO.FindStringExact(cbLOGO.Items.Cast<string>().FirstOrDefault(item =>
    item.Split('-').Length > 1 && item.Split('-')[1].Trim() == dataGridView1.Rows[a].Cells[3].Value.ToString()));

            cbLOGO.SelectedIndex= index;
            txDESCR.Text = dataGridView1.Rows[a].Cells[4].Value.ToString();

            KeyPressEventArgs press = new KeyPressEventArgs((char)Keys.Enter);
            txCOD_KeyPress(this, press);

            btCAD.Text = "ATUALIZAR";
        }
        #endregion
    }
}
