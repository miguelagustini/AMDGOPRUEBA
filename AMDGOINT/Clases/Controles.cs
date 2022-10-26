using DevExpress.Export;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.Utils.Filtering.Internal;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AMDGOINT.Clases
{
    class Controles
    {
        //AJUSTO EL TAMAÑO DEL SPLITTER, COLOR, ICONO
        public void setSplitter(SplitContainerControl splitter)
        {
            try
            {
                SkinElement element = SkinManager.GetSkinElement(SkinProductId.Common, splitter.LookAndFeel, "SplitterHorz");

                Size size = new Size(0, 15);
                element.Size.MinSize = size;

                Size imgsize = new Size();
                imgsize = new Size(50, 20);
                element.Glyph.Image = new Bitmap(Properties.Resources.Stop_128x128, imgsize);

                element.Color.BackColor2 = Color.FromArgb(16, 110, 190);
                element.Color.BackColor = Color.FromArgb(16, 110, 190);

                splitter.LookAndFeel.UpdateStyleSettings();

            }
            catch (Exception)
            {
                return;
            }
        }

        public FormBorderStyle EstiloBordesform(bool EsPopup)
        {
            if (EsPopup) { return FormBorderStyle.Sizable; }
            else { return FormBorderStyle.None; }
        }

        //BORDES DE COLOR
        public Color Setcolorborde(bool EsPopup)
        {
            if (EsPopup) { return Color.DeepSkyBlue; }
            else { return Color.White; }
        }

        //AGREGO FORMULARIO A TABPAGE
        public void AgregaFormulario(Form formulario, XtraTabControl tabcontrol, bool mlt = false)
        {
            try
            {
                //VARIABLES NECESARIAS PARA VALIDACIONES
                Form formufound = null; //ALMACENO SI EL FORMULARIO FUE ENCONTRADO
                bool existe = false; //DETERMINA SI HAY COINCIDENCIA ENTRE EL FORMULARIO ENCONTRADO Y EL MANEJADO
                int pageindex = 0; //ALMACENA EN QUE PESTAÑA SE POSICIONA EL FORMULARIO                

                //RECORRO TODAS LAS PESTAÑAS EN BUSCA DEL FORMULARIO
                foreach (XtraTabPage hoja in tabcontrol.TabPages)
                {
                    //GUARDO LO ENCONTRADO
                    formufound = hoja.Controls.OfType<Form>().FirstOrDefault();

                    //COMPRUEBO QUE NO SEA NULLO Y SI COINCIDE CON EL QUE TRATO DE ABRIR
                    if ((formufound != null) && (formufound.Name.ToString() == formulario.Name.ToString()))
                    {
                        //SI AMBOS SON CORRECTOS, HALLÉ EL FORMULARIO
                        existe = true;
                        break;
                    }

                    //POR CADA NUEVO RECORRIDO, AUMENTO EN 1 EL INDEX DE LA PESTAÑA EN LA QUE ESTY POSICIONADO
                    pageindex = pageindex + 1;

                }

                //ENTONCES, SI NO EXISTE EL FORMULARIO O ES FORMULARIO MULTIPLE
                if (!existe || mlt)
                {
                    //CREO UNA NUEVA PESTÑA PARA EL FORMULARIO
                    XtraTabPage myTabPage = new XtraTabPage();
                    myTabPage.Padding = new Padding(0, 0, 0, 0);
                    myTabPage.Margin = new Padding(0, 0, 0, 0);
                    //TITULO DE LA PESTAÑA
                    myTabPage.Text = formulario.Text.ToString();
                    //AGREGO LA PESTAÑA AL CONTROL PRINCIPAL
                    tabcontrol.TabPages.Add(myTabPage);

                    //INDICO QUE EL FORMULARIO SERÁ HIJO
                    formulario.TopLevel = false;
                    //AGREGO EL FORMULARIO A LA PESTAÑA
                    myTabPage.Controls.Add(formulario);
                    //HAGO QUE USE TODA LA PESTAÑA
                    formulario.Dock = DockStyle.Fill;
                    //MUESTRO EL FORMULARIO
                    formulario.Show();

                    pageindex++;
                }

                //HAGO FOCO EN LA PESTAÑA QUE LO CONTINE
                tabcontrol.SelectedTabPageIndex = pageindex;

            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un error al agregar el nuevo formulario a la interfaz. \n" +
                    e.Message, "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //MENSAJE DE ERROR
        public void MensajeInfo(string caption, short icon)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.Caption = "Amdgo";
            args.Text = caption;
            args.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            args.Buttons = new DialogResult[] { DialogResult.OK };
            if (icon == 0) { args.Icon = StockIconHelper.GetWindows8AssociatedIcon(SystemIcons.Warning); }
            if (icon == 1) { args.Icon = StockIconHelper.GetWindows8AssociatedIcon(SystemIcons.Information); }
            args.Showing += Args_Showing;
            XtraMessageBox.Show(args);

        }

        public DialogResult MensajePregunta(string caption)
        {

            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.Caption = "Amdgo";
            args.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            args.Text = caption;
            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
            args.Icon = StockIconHelper.GetWindows8AssociatedIcon(SystemIcons.Question);
            args.Showing += Args_Showing;
            return XtraMessageBox.Show(args);
        }

        private void Args_Showing(object sender, XtraMessageShowingArgs e)
        {
            SkinStyle skin = SkinStyle.Bezier;
            FontFamily fam = new FontFamily("Trebuchet MS");

            //APARIENCIA DE TEXTOS GENERAL            
            e.Form.Font = new Font(fam, 11, FontStyle.Regular, GraphicsUnit.Point, 204);
            e.Form.LookAndFeel.UseDefaultLookAndFeel = false;
            e.Form.LookAndFeel.Style = LookAndFeelStyle.Skin;
            e.Form.LookAndFeel.SetSkinStyle(skin);

            e.Form.Appearance.BackColor = Color.White;

            foreach (var control in e.Form.Controls)
            {
                SimpleButton button = control as SimpleButton;
                if (button != null)
                {
                    button.ImageOptions.SvgImageSize = new Size(16, 16);
                    button.Appearance.Font = new Font(fam, 10, FontStyle.Regular, GraphicsUnit.Point, 204);
                    button.Height += 10;

                    switch (button.DialogResult.ToString())
                    {
                        case ("Yes"):
                            button.ImageOptions.Image = Properties.Resources.Apply_16x16;
                            break;
                        case ("No"):
                            button.ImageOptions.Image = Properties.Resources.Cancel_16x16;
                            break;
                        case ("Ok"):
                            button.ImageOptions.Image = Properties.Resources.Apply_16x16;
                            break;

                    }
                }
            }
        }

        //LIMPIO LOS CONTROLES
        public void Limpiacontroles(Control controles)
        {
            foreach (Control ctrl in controles.Controls)
            {
                if (ctrl is TextEdit)
                {
                    TextEdit txt = ctrl as TextEdit;
                    txt.Text = "";
                }
                else if (ctrl is GridLookUpEdit)
                {
                    GridLookUpEdit cmb = ctrl as GridLookUpEdit;
                    cmb.EditValue = 0;
                }
                else if (ctrl is SpinEdit)
                {
                    SpinEdit sp = ctrl as SpinEdit;
                    sp.EditValue = 0;
                }
                else if (ctrl is MemoEdit)
                {
                    MemoEdit me = ctrl as MemoEdit;
                    me.Text = "";
                }

                if (ctrl.Controls.Count > 0) { Limpiacontroles(ctrl); }
            }
        }

        //GUARDO O RECUPERO LA PERSONALIZACION DE LA GRID
        public void PreferencesGrid(Form formulario = null, object grilla = null, string accion = "", UserControl userControl = null)
        {
            try
            {
                string path = "";

                if (userControl != null)
                { path = Application.StartupPath + @"\" + userControl.Name; }
                else if (formulario != null) { path = Application.StartupPath + @"\" + formulario.Name; }
                else { return; }

                if (grilla != null && grilla is GridView)
                {
                    GridView g = grilla as GridView;

                    path += g.Name + ".xml";

                    //GUARDO O RESTAURO
                    if (accion == "S") { g.SaveLayoutToXml(path); }
                    else
                    {
                        if (File.Exists(path))
                        {
                            g.RestoreLayoutFromXml(path);
                        }
                    }
                }
                else if (grilla != null && grilla is AdvBandedGridView)
                {
                    GridView g = grilla as AdvBandedGridView;
                    path += g.Name + ".xml";

                    //GUARDO O RESTAURO
                    if (accion == "S") { g.SaveLayoutToXml(path); }
                    else
                    {
                        if (File.Exists(path))
                        {
                            g.RestoreLayoutFromXml(path);
                        }
                    }
                }
                else if (grilla != null && grilla is BandedGridView)
                {
                    GridView g = grilla as BandedGridView;
                    path += g.Name + ".xml";

                    //GUARDO O RESTAURO
                    if (accion == "S") { g.SaveLayoutToXml(path); }
                    else
                    {
                        if (File.Exists(path))
                        {
                            g.RestoreLayoutFromXml(path);
                        }
                    }
                }
                else if (grilla != null && grilla is DockManager)
                {
                    DockManager g = grilla as DockManager;
                    path += g.ToString() + ".xml";

                    //GUARDO O RESTAURO
                    if (accion == "S") { g.SaveLayoutToXml(path); }
                    else
                    {
                        if (File.Exists(path))
                        {
                            g.RestoreLayoutFromXml(path);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MensajeInfo("Sin permisos de administrador para escribir en el disco.", 1);
                return;
            }
        }

        //GUARDO O RECUPERO LA PERSONALIZACION DEL PIVOTGRID
        public void PreferencesPivot(Form formulario, PivotGridControl grilla = null, string accion = "")
        {
            try
            {
                string path = "";
                if (grilla != null)
                {
                    path = Application.StartupPath + @"\" + formulario.Name +
                    grilla.Name + ".xml";
                }

                //GUARDO LA CONFIGURACION DE LA GRILLA
                if (accion == "S")
                {
                    if (grilla != null) grilla.SaveLayoutToXml(path);
                }
                //RESTAURO LA CONFIGURACION DE LA GRILLA
                else
                {
                    if (File.Exists(path))
                    {
                        if (grilla != null) grilla.RestoreLayoutFromXml(path);
                    }

                }
            }
            catch (Exception)
            {
                MensajeInfo("Sin permisos de administrador para escribir en el disco.", 1);
                return;
            }

        }

        //EXPORTAR A EXCEL GRID CONTROL
        public void ExportaraExcelgrd(GridControl gridControl, ExportType exptype = ExportType.WYSIWYG)
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.ValidateNames = true;
                    //saveDialog.CheckFileExists = true;
                    saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";

                    XlsExportOptionsEx gridxlsExport = new XlsExportOptionsEx();
                    gridxlsExport.ExportType = exptype;
                    XlsxExportOptionsEx gridxlsxExport = new XlsxExportOptionsEx();
                    gridxlsxExport.ExportType = exptype;
                    


                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        string exportFilePath = saveDialog.FileName;
                        string fileExtenstion = new FileInfo(exportFilePath).Extension;

                        switch (fileExtenstion)
                        {
                            case ".xls":
                                gridControl.ExportToXls(exportFilePath, gridxlsExport);
                                //gridControl.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl.ExportToXlsx(exportFilePath, gridxlsxExport);
                                //gridControl.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl.ExportToMht(exportFilePath);
                                break;
                            default:
                                break;
                        }

                        if (File.Exists(exportFilePath))
                        {
                            try
                            {
                                //Try to open the file and let windows decide how to open it.
                                System.Diagnostics.Process.Start(exportFilePath);
                            }
                            catch
                            {
                                String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                                MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception e)
            {

                MensajeInfo("Ocurrio un error al intentar exportar.\n" + e.Message, 0);
                return;
            }
        }

        //EXPORTAR A EXCEL GRID CONTROL
        public void ExportaraExceltree(TreeList gridControl)
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.ValidateNames = true;
                    //saveDialog.CheckFileExists = true;
                    saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";

                    XlsExportOptionsEx gridxlsExport = new XlsExportOptionsEx();
                    gridxlsExport.ExportType = ExportType.WYSIWYG;
                    XlsxExportOptionsEx gridxlsxExport = new XlsxExportOptionsEx();
                    gridxlsxExport.ExportType = ExportType.WYSIWYG;


                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        string exportFilePath = saveDialog.FileName;
                        string fileExtenstion = new FileInfo(exportFilePath).Extension;

                        switch (fileExtenstion)
                        {
                            case ".xls":
                                gridControl.ExportToXls(exportFilePath, gridxlsExport);
                                //gridControl.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl.ExportToXlsx(exportFilePath, gridxlsxExport);
                                //gridControl.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl.ExportToHtml(exportFilePath);
                                break;                            
                            default:
                                break;
                        }

                        if (File.Exists(exportFilePath))
                        {
                            try
                            {
                                //Try to open the file and let windows decide how to open it.
                                System.Diagnostics.Process.Start(exportFilePath);
                            }
                            catch
                            {
                                String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                                MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception e)
            {

                MensajeInfo("Ocurrio un error al intentar exportar.\n" + e.Message, 0);
                return;
            }
        }

        //EXPORTAR A EXCEL PIVOT CONTROL
        public void ExportaraExcelpvgr(PivotGridControl gridControl)
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.ValidateNames = true;
                    //saveDialog.CheckFileExists = true;
                    saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                    var pivotExportOptionsxlsx = new PivotXlsxExportOptions();
                    var pivotExportOptionsxls = new PivotXlsExportOptions();
                    pivotExportOptionsxlsx.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                    pivotExportOptionsxlsx.AllowConditionalFormatting = DevExpress.Utils.DefaultBoolean.True;
                    pivotExportOptionsxls.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                    pivotExportOptionsxls.AllowConditionalFormatting = DevExpress.Utils.DefaultBoolean.True;
                    


                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        string exportFilePath = saveDialog.FileName;
                        string fileExtenstion = new FileInfo(exportFilePath).Extension;

                        switch (fileExtenstion)
                        {
                            case ".xls":
                                gridControl.ExportToXls(exportFilePath, pivotExportOptionsxls);                                
                                break;
                            case ".xlsx":
                                gridControl.ExportToXlsx(exportFilePath, pivotExportOptionsxlsx);                                
                                break;
                            case ".rtf":
                                gridControl.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl.ExportToMht(exportFilePath);
                                break;
                            default:
                                break;
                        }

                        if (File.Exists(exportFilePath))
                        {
                            try
                            {
                                //Try to open the file and let windows decide how to open it.
                                System.Diagnostics.Process.Start(exportFilePath);
                            }
                            catch
                            {
                                String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                                MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception e)
            {

                MensajeInfo("Ocurrio un error al intentar exportar.\n" + e.Message, 0);
                return;
            }
        }

        public void Args_Showingglob(object sender, XtraMessageShowingArgs e)
        {
            
            e.Form.Icon = Icon.FromHandle(Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084.GetHicon());
        }

        //PARA LOS CONTROLES QUE NO REFLEJAN EL CAMBIO DE LA FUENTE DE DATOS
        public void RefrescarValorcontrols(List<Binding> controlesb)
        {
            foreach (Binding b in controlesb)
            {
                if (b != null) { b.ReadValue(); }
            }
        }
    }

    public class EspañolLocalizerFiltros : FilterUIElementResXLocalizer
    {
        public override string Language { get { return "Spanish"; } }

        public override string GetLocalizedString(FilterUIElementLocalizerStringId id)
        {
            string ret = "";
            switch (id)
            {
                
                case FilterUIElementLocalizerStringId.CustomUIFiltersNumericName: return "Filtros Numéricos";
                case FilterUIElementLocalizerStringId.CustomUIFiltersNumericDescription: return "Descripción de filtros Numéricos";
                case FilterUIElementLocalizerStringId.CustomUIFiltersDateTimeName: return "Filtros de Fecha";
                case FilterUIElementLocalizerStringId.CustomUIFiltersDateTimeDescription: return "Descripción de Filtros de Fecha";
                case FilterUIElementLocalizerStringId.CustomUIFiltersTextName: return "Filtros de Texto";
                case FilterUIElementLocalizerStringId.CustomUIFiltersTextDescription: return "Descripción de Filtros de Texto";
                case FilterUIElementLocalizerStringId.CustomUIFiltersBooleanName: return "Filtros";
                case FilterUIElementLocalizerStringId.CustomUIFiltersBooleanDescription: return "Descripción de Filtros";
                case FilterUIElementLocalizerStringId.CustomUIFilterEqualsName: return "Igual";
                case FilterUIElementLocalizerStringId.CustomUIFilterEqualsDescription: return "Es igual a un Valor";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotEqualName: return "No es Igual";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotEqualDescription: return "No es igual a un Valor";
                case FilterUIElementLocalizerStringId.CustomUIFilterBetweenName: return "Entre";
                case FilterUIElementLocalizerStringId.CustomUIFilterBetweenDescription: return "Valores dentro de un Rango";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsNullName: return "Nulos";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsNullDescription: return "Vacíos";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsNotNullName: return "No es Nulo";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsNotNullDescription: return "No es vacío";
                case FilterUIElementLocalizerStringId.CustomUIFilterGreaterThanName: return "Mayor que";
                case FilterUIElementLocalizerStringId.CustomUIFilterGreaterThanDescription: return "Más grande que un valor";
                case FilterUIElementLocalizerStringId.CustomUIFilterGreaterThanOrEqualToName: return "Mayor o Igual a";
                case FilterUIElementLocalizerStringId.CustomUIFilterGreaterThanOrEqualToDescription: return "Mayor o igual al valor";
                case FilterUIElementLocalizerStringId.CustomUIFilterLessThanName: return "Menor que";
                case FilterUIElementLocalizerStringId.CustomUIFilterLessThanDescription: return "Menor que un valor";
                case FilterUIElementLocalizerStringId.CustomUIFilterLessThanOrEqualToName: return "Menor o igual a";
                case FilterUIElementLocalizerStringId.CustomUIFilterLessThanOrEqualToDescription: return "menor o igual al valor";
                case FilterUIElementLocalizerStringId.CustomUIFilterTopNName: return "Valores Altos";
                case FilterUIElementLocalizerStringId.CustomUIFilterTopNDescription: return "Valores más altos";
                case FilterUIElementLocalizerStringId.CustomUIFilterBottomNName: return "Valores Bajos";
                case FilterUIElementLocalizerStringId.CustomUIFilterBottomNDescription: return "Valores más bajos";
                case FilterUIElementLocalizerStringId.CustomUIFilterSequenceQualifierItemsName: return "Elementos";
                case FilterUIElementLocalizerStringId.CustomUIFilterSequenceQualifierItemsDescription: return "Descripción de Elementos";
                case FilterUIElementLocalizerStringId.CustomUIFilterSequenceQualifierPercentsName: return "Porcentajes";
                case FilterUIElementLocalizerStringId.CustomUIFilterSequenceQualifierPercentsDescription: return "Descripción de Porcentaje";
                case FilterUIElementLocalizerStringId.CustomUIFilterAboveAverageName: return "Por encima del Promedio";
                case FilterUIElementLocalizerStringId.CustomUIFilterAboveAverageDescription: return "Valores por encima del Promedio";
                case FilterUIElementLocalizerStringId.CustomUIFilterBelowAverageName: return "Por debajo del promedio";
                case FilterUIElementLocalizerStringId.CustomUIFilterBelowAverageDescription: return "Valores por debajo del Promedio";
                case FilterUIElementLocalizerStringId.CustomUIFilterBeginsWithName: return "Comienza con";
                case FilterUIElementLocalizerStringId.CustomUIFilterBeginsWithDescription: return "Comienza con un texto específico";
                case FilterUIElementLocalizerStringId.CustomUIFilterEndsWithName: return "Termina con";
                case FilterUIElementLocalizerStringId.CustomUIFilterEndsWithDescription: return "Termina con un texto específico";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotBeginWithName: return "No comienza con";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotBeginWithDescription: return "No comienza con un texto específico";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotEndWithName: return "No termina con";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotEndWithDescription: return "No termina con un texto específico";
                case FilterUIElementLocalizerStringId.CustomUIFilterContainsName: return "Contiene";
                case FilterUIElementLocalizerStringId.CustomUIFilterContainsDescription: return "Contiene un texto específico";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotContainName: return "No Contiene";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotContainDescription: return "No contiene un texto específico";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsBlankName: return "Está en blanco";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsBlankDescription: return "Vacío o no Especificado";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsNotBlankName: return "No está en blanco";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsNotBlankDescription: return "No es vacío";
                //DIAS
                case FilterUIElementLocalizerStringId.CustomUIFilterIsSameDayName: return "Es el Mismo Día";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsSameDayDescription: return "Es la misma Fecha";
                case FilterUIElementLocalizerStringId.CustomUIFilterAfterName: return "Después";
                case FilterUIElementLocalizerStringId.CustomUIFilterAfterDescription: return "Despues de la fecha";
                case FilterUIElementLocalizerStringId.CustomUIFilterTomorrowName: return "Mañana";
                case FilterUIElementLocalizerStringId.CustomUIFilterTomorrowDescription: return "Mañana";
                case FilterUIElementLocalizerStringId.CustomUIFilterTodayName: return "Hoy";
                case FilterUIElementLocalizerStringId.CustomUIFilterTodayDescription: return "Hoy";
                case FilterUIElementLocalizerStringId.CustomUIFilterYesterdayName: return "Ayer";
                case FilterUIElementLocalizerStringId.CustomUIFilterYesterdayDescription: return "Ayer";
                //SEMANA
                case FilterUIElementLocalizerStringId.CustomUIFilterNextWeekName: return "Próxima Semana";
                case FilterUIElementLocalizerStringId.CustomUIFilterNextWeekDescription: return "Próxima Semana";
                case FilterUIElementLocalizerStringId.CustomUIFilterThisWeekName: return "Ésta Semana";
                case FilterUIElementLocalizerStringId.CustomUIFilterThisWeekDescription: return "Ésta Semana";
                case FilterUIElementLocalizerStringId.CustomUIFilterLastWeekName: return "Semana Pasada";
                case FilterUIElementLocalizerStringId.CustomUIFilterLastWeekDescription: return "Semana Pasada";
                //MES
                case FilterUIElementLocalizerStringId.CustomUIFilterNextMonthName: return "Próximo Mes";
                case FilterUIElementLocalizerStringId.CustomUIFilterNextMonthDescription: return "Próximo Mes";
                case FilterUIElementLocalizerStringId.CustomUIFilterThisMonthName: return "Éste Mes";
                case FilterUIElementLocalizerStringId.CustomUIFilterThisMonthDescription: return "Éste mes";
                case FilterUIElementLocalizerStringId.CustomUIFilterLastMonthName: return "Mes Pasado";
                case FilterUIElementLocalizerStringId.CustomUIFilterLastMonthDescription: return "Mes Pasado";
                //QUERTER?
                //AÑOS
                case FilterUIElementLocalizerStringId.CustomUIFilterNextYearName: return "Próximo Año";
                case FilterUIElementLocalizerStringId.CustomUIFilterNextYearDescription: return "Próximo Año";
                case FilterUIElementLocalizerStringId.CustomUIFilterThisYearName: return "Éste Año";
                case FilterUIElementLocalizerStringId.CustomUIFilterThisYearDescription: return "Éste Año";
                case FilterUIElementLocalizerStringId.CustomUIFilterLastYearName: return "Año Pasado";
                case FilterUIElementLocalizerStringId.CustomUIFilterLastYearDescription: return "Año Pasado";
                case FilterUIElementLocalizerStringId.CustomUIFilterYearToDateName: return "Año a Fecha";
                case FilterUIElementLocalizerStringId.CustomUIFilterYearToDateDescription: return "Desde Principio del Año hasta la Fecha";
                //RANGOS DE FECHA
                case FilterUIElementLocalizerStringId.CustomUIFilterDatePeriodsName: return "Período de Fecha";
                case FilterUIElementLocalizerStringId.CustomUIFilterDatePeriodsDescription: return "Período específico";
                case FilterUIElementLocalizerStringId.CustomUIFilterAllDatesInThePeriodName: return "Todas las fechas del Período";
                case FilterUIElementLocalizerStringId.CustomUIFilterAllDatesInThePeriodDescription: return "Fechas dentro del Rango";
                //NOMBRE DE MESES
                case FilterUIElementLocalizerStringId.CustomUIFilterJanuaryName: return "Enero";
                case FilterUIElementLocalizerStringId.CustomUIFilterJanuaryDescription: return "Enero";
                case FilterUIElementLocalizerStringId.CustomUIFilterFebruaryName: return "Febrero";
                case FilterUIElementLocalizerStringId.CustomUIFilterFebruaryDescription: return "Febrero";
                case FilterUIElementLocalizerStringId.CustomUIFilterMarchName: return "Marzo";
                case FilterUIElementLocalizerStringId.CustomUIFilterMarchDescription: return "Marzo";
                case FilterUIElementLocalizerStringId.CustomUIFilterAprilName: return "Abril";
                case FilterUIElementLocalizerStringId.CustomUIFilterAprilDescription: return "Abril";
                case FilterUIElementLocalizerStringId.CustomUIFilterMayName: return "Mayo";
                case FilterUIElementLocalizerStringId.CustomUIFilterMayDescription: return "Mayo";
                case FilterUIElementLocalizerStringId.CustomUIFilterJuneName: return "Junio";
                case FilterUIElementLocalizerStringId.CustomUIFilterJuneDescription: return "Junio";
                case FilterUIElementLocalizerStringId.CustomUIFilterJulyName: return "Julio";
                case FilterUIElementLocalizerStringId.CustomUIFilterJulyDescription: return "Julio";
                case FilterUIElementLocalizerStringId.CustomUIFilterAugustName: return "Agosto";
                case FilterUIElementLocalizerStringId.CustomUIFilterAugustDescription: return "Agosto";
                case FilterUIElementLocalizerStringId.CustomUIFilterSeptemberName: return "Septiembre";
                case FilterUIElementLocalizerStringId.CustomUIFilterSeptemberDescription: return "Septiembre";
                case FilterUIElementLocalizerStringId.CustomUIFilterOctoberName: return "Octubre";
                case FilterUIElementLocalizerStringId.CustomUIFilterOctoberDescription: return "Octubre";
                case FilterUIElementLocalizerStringId.CustomUIFilterNovemberName: return "Noviembre";
                case FilterUIElementLocalizerStringId.CustomUIFilterNovemberDescription: return "Noviembre";
                case FilterUIElementLocalizerStringId.CustomUIFilterDecemberName: return "Diciembre";
                case FilterUIElementLocalizerStringId.CustomUIFilterDecemberDescription: return "Diciembre";
                //
                case FilterUIElementLocalizerStringId.CustomUIFilterCustomName: return "Filtro Personalizado";
                case FilterUIElementLocalizerStringId.CustomUIFilterCustomDescription: return "Condiciones Combinadas con operadores And y OR (Y-O)";
                case FilterUIElementLocalizerStringId.CustomUIFilterUserName: return "Filtros Predefinidos";
                case FilterUIElementLocalizerStringId.CustomUIFilterUserDescription: return "Filtros Predefinidos";
                case FilterUIElementLocalizerStringId.CustomUINullValuePromptChooseOne: return "Elige uno...";
                case FilterUIElementLocalizerStringId.CustomUINullValuePromptEnterADate: return "Ingrese una fecha...";
                case FilterUIElementLocalizerStringId.CustomUINullValuePromptSelectAValue: return "Selecciona un valor...";
                case FilterUIElementLocalizerStringId.CustomUINullValuePromptEnterAValue: return "Ingresa un valor...";
                case FilterUIElementLocalizerStringId.CustomUINullValuePromptSelectADate: return "Selecciona una fecha...";
                    
                //PANEL DE BUSQUEDA
                case FilterUIElementLocalizerStringId.CustomUINullValuePromptSearchControl: return "Texto a Buscar...";
                case FilterUIElementLocalizerStringId.CustomUIFirstLabel: return "Primero";
                case FilterUIElementLocalizerStringId.CustomUISecondLabel: return "Segundo";
                case FilterUIElementLocalizerStringId.FilteringUITabValues: return "Valores";
                case FilterUIElementLocalizerStringId.FilteringUIClearFilter: return "Limpiar ";
                case FilterUIElementLocalizerStringId.FilteringUIClose: return "Cerrar";
                    


                default:
                    ret = base.GetLocalizedString(id);
                    break;
            }
            return ret;
        }
    }

    public class EspañolLocalizerGrid : GridLocalizer
    {
        public override string Language { get { return "Spanish"; } }

        public override string GetLocalizedString(GridStringId id)
        {
            string ret = "";
            switch (id)
            {
                // ... 
                case GridStringId.GridGroupPanelText: return "Arrastre aqui una o mas columnas para agrupar...";
                case GridStringId.MenuColumnClearSorting: return "Limpiar Ordenamiento";
                case GridStringId.MenuGroupPanelHide: return "Ocultar panel de Grupo";
                case GridStringId.MenuGroupPanelShow: return "Mostrar panel de grupo";
                case GridStringId.MenuColumnRemoveColumn: return "Quitar Columna";
                case GridStringId.MenuColumnFilterEditor: return "Flitros y Editores";
                case GridStringId.MenuColumnFindFilterShow: return "Mostrar Panel de Búsqueda";
                case GridStringId.MenuColumnFindFilterHide: return "Ocultar Panel de Búsqueda";
                case GridStringId.MenuColumnAutoFilterRowShow: return "Mostrar Fila de filtros";
                case GridStringId.MenuColumnAutoFilterRowHide: return "Ocultar Fila de filtros";
                case GridStringId.MenuColumnSortAscending: return "Órden Ascendente";
                case GridStringId.MenuColumnSortDescending: return "Órden Descendente";
                case GridStringId.MenuColumnGroup: return "Agrupar por ésta columna";
                case GridStringId.MenuColumnUnGroup: return "Desagrupar ésta columna";
                case GridStringId.MenuColumnColumnCustomization: return "Selector de columnas";
                case GridStringId.MenuColumnBestFit: return "Ajuste óptimo para ésta columna";
                case GridStringId.MenuColumnFilter: return "Kann gruppieren";
                case GridStringId.MenuColumnClearFilter: return "Limpiar éste Filtro";
                case GridStringId.MenuColumnBestFitAllColumns: return "Ajuste óptimo, todas las columnas";
                case GridStringId.MenuColumnShowColumn: return "Mostrar Columna";
                case GridStringId.CustomFilterDialogClearFilter: return "Limpiar todos los Filtros";
                case GridStringId.EditFormCancelButton: return "Cancelar";
                case GridStringId.EditFormUpdateButton: return "Aplicar";
                case GridStringId.EditFormCancelMessage: return "Cancelar";
                case GridStringId.EditFormSaveMessage: return "Aplicar";
                case GridStringId.FindControlClearButton: return "Limpiar";
                case GridStringId.FindControlFindButton: return "Buscar";
                case GridStringId.MenuColumnClearAllSorting: return "Quitar Ordenamientos";

                case GridStringId.MenuGroupPanelFullExpand: return "Expandir Todos";
                case GridStringId.MenuGroupPanelFullCollapse: return "Contraer Todos";
                case GridStringId.MenuGroupPanelClearGrouping: return "Quitar Agrupamiento";
                case GridStringId.MenuGroupRowCollapse: return "Contraer";
                case GridStringId.MenuGroupRowExpand: return "Expandir";

                case GridStringId.PopupFilterAll: return "Todos";


                case GridStringId.MenuColumnConditionalFormatting: return "Formato Condicional";
                case GridStringId.MenuColumnBandCustomization: return "Selector de Bandas y Columnas";
                case GridStringId.CustomFilterDialogRadioAnd: return "Y";
                case GridStringId.CustomFilterDialogRadioOr: return "O";
                case GridStringId.CustomizationBands: return "Bandas";
                case GridStringId.CustomizationFormBandHint: return "Arrastre bandas desde o hacia aqui para personalizar la grilla";
                case GridStringId.CustomizationColumns: return "Columnas";
                case GridStringId.CustomizationFormColumnHint: return "Arrastre columnas desde o hacia aqui para personalizar la grilla";
                case GridStringId.CustomizationCaption: return "Personalización";

                case GridStringId.FindNullPrompt: return "Ingrese el texto a buscar";
                case GridStringId.FilterBuilderApplyButton: return "Aplicar";
                case GridStringId.FilterBuilderCancelButton: return "Cancelar";
                case GridStringId.FilterBuilderOkButton: return "Ok";
                case GridStringId.FilterBuilderCaption: return "Filtros y Editores";
                case GridStringId.FilterPanelCustomizeButton: return "Editar Filtros";

                case GridStringId.MenuColumnAverageSummaryTypeDescription: return "Promedio";

                case GridStringId.MenuFooterAverage: return "Promedio";
                case GridStringId.MenuFooterCount: return "Contar";
                case GridStringId.MenuFooterMax: return "Máximo";
                case GridStringId.MenuFooterMin: return "Mínimo";
                case GridStringId.MenuFooterSum: return "Suma";
                case GridStringId.MenuFooterAddSummaryItem: return "Agregar Operación";
                case GridStringId.MenuFooterNone: return "Ninguno";
                case GridStringId.MenuFooterClearSummaryItems: return "Quitar Operaciónes";

                // ... 
                default:
                    ret = base.GetLocalizedString(id);
                    break;
            }
            return ret;
        }
    }

    public class EspañolLocalizer : Localizer
    {
        public override string Language { get { return "Spanish"; } }
        public override string GetLocalizedString(StringId id)
        {
            string net = "";
            switch (id)
            {   
                case StringId.FormatRuleMenuItemDataUpdateRules: return "Reglas de Actualización de Datos";
                case StringId.FormatRuleMenuItemDataBars: return "Barras de Datos";
                case StringId.ColorScaleBlueWhiteRed: return "Azul - Blanco - Rojo";
                case StringId.ColorScaleEmeraldAzureBlue: return "Esmeralda - Cián - Azul";
                case StringId.ColorScaleGreenWhiteRed: return "Verde - Blanco - Rojo";
                case StringId.ColorScaleGreenYellowRed: return "Verde - Amarillo - Rojo";
                case StringId.ColorScalePurpleWhiteAzure: return "Púrpura - Blanco - Cián";
                case StringId.ColorScaleWhiteAzure: return "Blanco - Cián";
                case StringId.ColorScaleWhiteRed: return "Blanco - Rojo";
                case StringId.ColorScaleYellowGreen: return "Amarillo - Verde";
                case StringId.ColorScaleYellowOrangeCoral: return "Amarillo - Naranja - Coral";
                case StringId.DataBarBlue: return "Barra Azul";
                case StringId.DataBarBlueGradient: return "Barra azul degradado";
                case StringId.DataBarCoral: return "Barra Coral";
                case StringId.DataBarCoralGradient: return "Barra Coral Degradado";
                case StringId.DataBarGreen: return "Barra Verde";
                case StringId.DataBarGreenGradient: return "Barra Verde Degradado";
                case StringId.DataBarLightBlue: return "Barra Celeste";
                case StringId.DataBarLightBlueGradient: return "Barra Celeste Degradado";
                case StringId.DataBarMint: return "Barra Menta";
                case StringId.DataBarMintGradient: return "Barra Menta Degradado";
                case StringId.DataBarOrange: return "Barra Naranja";
                case StringId.DataBarOrangeGradient: return "Barra Naranja Degradado";
                case StringId.DataBarRaspberry: return "Barra Frambuesa";
                case StringId.DataBarRaspberryGradient: return "Barra Frambuesa Degradado";
                case StringId.DataBarViolet: return "Barra Violeta";
                case StringId.DataBarVioletGradient: return "Barra Violeta Degradado";
                case StringId.DataBarYellow: return "Barra Amarilla";
                case StringId.DataBarYellowGradient: return "Barra Amarilla Degradado";
                case StringId.ManageRuleDataBar: return "Barra de Datos";
                case StringId.ColorScaleWhiteGreen: return "Blanco - Verde";                
                
                case StringId.FormatRuleMenuItemHighlightCellRules: return "Reglas de celda";
                case StringId.FormatPredefinedAppearanceRedBoldText: return "Negrita Rojo";
                case StringId.FormatPredefinedAppearanceBoldText: return "Negrita";
                case StringId.FormatPredefinedAppearanceGreenBoldText: return "Negrita Verde";
                case StringId.FormatPredefinedAppearanceGreenFill: return "Relleno Verde";
                case StringId.FormatPredefinedAppearanceGreenFillGreenText: return "Relleno y Letras Verdes";
                case StringId.FormatPredefinedAppearanceGreenText: return "Letras Verdes";
                case StringId.FormatPredefinedAppearanceItalicText: return "Cursiva";                
                case StringId.FormatPredefinedAppearanceRedFill: return "Relleno Rojo";
                case StringId.FormatPredefinedAppearanceRedFillRedText: return "Relleno Rojo y Texto Rojo";
                case StringId.FormatPredefinedAppearanceRedText: return "Texto Rojo";
                case StringId.FormatPredefinedAppearanceStrikeoutText: return "Texto Tachado";
                case StringId.FormatPredefinedAppearanceYellowFillYellowText: return "Relleno y Texto amarillo";
                case StringId.FormatRuleAboveAverageText: return "Aplicar formato a encima del promedio";
                case StringId.FormatRuleApplyFormatProperty: return "Aplicar el formato a la fila completa";
                case StringId.FormatRuleBelowAverageText: return "Aplicar formato a celdas por debajo del promedio";
                case StringId.FormatRuleBetweenText: return "Formatear celdas que están entre";
                case StringId.FormatRuleBottomText: return "Formatear celdas en los últimos puestos";
                case StringId.FormatRuleCustomConditionText: return "Formatear celdas que coinciden con la condicion...";
                case StringId.FormatRuleDateOccurring: return "Formatear celdas que contengan una fecha que coincida con estas condiciones";
                case StringId.FormatRuleDuplicateText: return "Formatear celdas con valores duplicados";
                case StringId.FormatRuleEqualToText: return "Formatear celdas que son iguales a";
                case StringId.FormatRuleExpressionEmptyEnter: return "Ingresar una expresión";
                case StringId.FormatRuleForThisColumnWith: return "Para ésta columna con..";
                case StringId.FormatRuleGreaterThanText: return "Formatear celdas que son mayores que";
                case StringId.FormatRuleLessThanText: return "Formatear celdas que son menores que";                
                case StringId.FormatRuleMenuItemDuplicate: return "Duplicados";
                case StringId.FormatRuleMenuItemEqualTo: return "Iguales A";
                case StringId.FormatRuleMenuItemGradientFill: return "Relleno Degradado";
                case StringId.FormatRuleMenuItemGreaterThan: return "Mayor que";
                case StringId.FormatRuleMenuItemLessThan: return "Menor que";
                case StringId.FormatRuleMenuItemManageRules: return "Administrador de Reglas";
                case StringId.FormatRuleMenuItemSolidFill: return "Relleno Solido";
                case StringId.FormatRuleMenuItemTextThatContains: return "Texto que contiene...";
                case StringId.FormatRuleMenuItemTop10Items: return "Top 10 item";
                case StringId.FormatRuleMenuItemTop10Percent: return "Top 10 %";
                case StringId.FormatRuleMenuItemTopBottomRules: return "Regla de Mayores y Menores";
                case StringId.FormatRuleMenuItemUnique: return "Valores únicos";
                case StringId.FormatRuleMenuItemUniqueDuplicateRules: return "Reglas de único/Duplicado";
                case StringId.FormatRuleTopText: return "Formato de celdas de primeros puestos";
                case StringId.FormatRuleUniqueText: return "Formato de celdas con valores unicos";
                case StringId.FormatRuleWith: return "Con..";
                case StringId.FormatRuleMenuItemAboveAverage: return "Sobre el promedio";
                case StringId.FormatRuleMenuItemBelowAverage: return "Debajo del promedio";
                case StringId.FormatRuleMenuItemBetween: return "Entre..";
                case StringId.FormatRuleMenuItemBottom10Items: return "10 Elementos inferiores";
                case StringId.FormatRuleMenuItemBottom10Percent: return "Inferior al 10%";
                case StringId.FormatRuleMenuItemClearAllRules: return "Limpiar todas las reglas";
                case StringId.FormatRuleMenuItemClearColumnRules: return "Limpiar las reglas de ésta columna";
                case StringId.FormatRuleMenuItemClearRules: return "Limpiar Regla";
                case StringId.FormatRuleMenuItemColorScaleDescription: return "Aplica un degradado de color a un rango de\r\n" +
                        "celdas en esta columna el color indica\r\n" +
                        "dónde se encuentra cada celda dentro de ese rango";
                case StringId.FormatRuleMenuItemColorScales: return "Escala de colores";
                case StringId.FormatRuleMenuItemCustomCondition: return "Condiciones personalizadas";
                case StringId.FormatRuleMenuItemDataBarDescription: return "Agregue barras de datos de colores para representar\r\n" +
                        "el valor en una celda. cuanto mayor sea el valor,\r\nmás larga será la barra";
                case StringId.FormatRuleMenuItemIconSetDescription: return
                        "Use este conjunto de iconos para clasificar los valores de la columna en los siguientes rangos";
                
                case StringId.Hours: return "Horas";
                case StringId.Mins: return "Minutos";
                case StringId.Secs: return "Segundos";
                case StringId.Millisecs: return "Milisegundos";
                
                case StringId.Apply: return "Aplicar";
                case StringId.Cancel: return "Cancelar";
                case StringId.DateEditClear: return "Limpiar";
                case StringId.DateEditToday: return "Hoy";
                case StringId.Days: return "Dias";

                case StringId.FormatRuleMenuItemIconSets: return "Conjutos de Íconos";
                case StringId.IconSetCategoryDirectional: return "Direccional";
                case StringId.IconSetCategoryIndicators: return "Indicadores";
                case StringId.IconSetCategoryPositiveNegative: return "Positivos / Negativos";
                case StringId.IconSetCategoryRatings: return "Rating";
                case StringId.IconSetCategoryShapes: return "Formas";
                case StringId.IconSetCategorySymbols: return "Simbolos";
                case StringId.IconSetTitleArrows3Colored: return "3 felchas color";
                case StringId.IconSetTitleArrows3Gray: return "3 flechas escala grises";
                case StringId.IconSetTitleArrows4Colored: return "4 felchas color";
                case StringId.IconSetTitleArrows4Gray: return "4 felchas escala grises";
                case StringId.IconSetTitleArrows5Colored: return "5 felchas color";
                case StringId.IconSetTitleArrows5Gray: return "5 felchas escala grises";
                case StringId.IconSetTitleBoxes5: return "5 Cajas";
                case StringId.IconSetTitleFlags3: return "3 Banderas";
                case StringId.IconSetTitlePositiveNegativeArrows: return "Felchas a Color";
                case StringId.IconSetTitlePositiveNegativeArrowsGray: return "Flechas en escala de grises";
                case StringId.IconSetTitlePositiveNegativeTriangles: return "Triangulos";
                case StringId.IconSetTitleQuarters5: return "5 Cuartos";
                case StringId.IconSetTitleRatings4: return "4 estrellas";
                case StringId.IconSetTitleRatings5: return "5 estrellas";
                case StringId.IconSetTitleRedToBlack: return "Rojo a Negro";
                case StringId.IconSetTitleSigns3: return "Tres Signos";
                case StringId.IconSetTitleStars3: return "Tres Estrellas";
                case StringId.IconSetTitleSymbols3Circled: return "Tres Circulos";
                case StringId.IconSetTitleSymbols3Uncircled: return "Tres No circulos";
                case StringId.IconSetTitleTrafficLights3Rimmed: return "Semáforo bordeado";
                case StringId.IconSetTitleTrafficLights3Unrimmed: return "Semáforo";
                case StringId.IconSetTitleTrafficLights4: return "Semáforo 4 luces";
                case StringId.IconSetTitleTriangles3: return "Tres Triángulos";
                case StringId.FilterMenuConditionAdd: return "Agregar Condición";

                case StringId.FilterAggregateAvg: return "Promedio";
                case StringId.FilterAggregateCount: return "Contador";
                case StringId.FilterAggregateExists: return "Existe";
                case StringId.FilterAggregateMax: return "Máximo";
                case StringId.FilterAggregateMin: return "Mínimo";
                case StringId.FilterAggregateSum: return "Suma";
                case StringId.FilterClauseAnyOf: return "Es cualquiera de";
                case StringId.FilterClauseBeginsWith: return "Comienza con";
                case StringId.FilterClauseBetween: return "Está entre";
                case StringId.FilterClauseBetweenAnd: return "Y";
                case StringId.FilterCriteriaToStringGroupOperatorOr: return "O";
                case StringId.FilterCriteriaToStringGroupOperatorAnd: return "Y";
                case StringId.FilterGroupOr: return "O";
                case StringId.FilterGroupAnd: return "Y";
                
                case StringId.FilterClauseContains: return "Contiene";
                case StringId.FilterClauseDoesNotContain: return "No Contiene";
                case StringId.FilterClauseDoesNotEqual: return "No es igual";
                case StringId.FilterClauseEndsWith: return "Termina con";
                case StringId.FilterClauseEquals: return "Es igual";
                case StringId.FilterClauseGreater: return "Mayor que";
                case StringId.FilterClauseGreaterOrEqual: return "Mayor o igual que";
                case StringId.FilterClauseIsNotNull: return "No es Nulo";
                case StringId.FilterClauseIsNotNullOrEmpty: return "No es nulo o vacío";
                case StringId.FilterClauseIsNull: return "Es nulo";
                case StringId.FilterClauseIsNullOrEmpty: return "Es nulo o vacío";
                case StringId.FilterClauseLess: return "Menor que";
                case StringId.FilterClauseLessOrEqual: return "Menor o igual que";
                case StringId.FilterClauseLike: return "Es cómo";
                case StringId.FilterClauseNoneOf: return "Es ninguno de";
                case StringId.FilterClauseNotBetween: return "No está entre";
                case StringId.FilterClauseNotLike: return "No es cómo";
                case StringId.FilterEmptyEnter: return "Ingrese un Valor";
                case StringId.FilterCriteriaToStringFunctionToday: return "Hoy";
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeYesterday: return "Ayer";
                //case StringId.FilterCriteriaInvalidExpression: return "";
                //case StringId.FilterCriteriaInvalidExpressionEx: return "";

                case StringId.ManageRuleAboveAverage: return "Encima del promedio";
                case StringId.ManageRuleAllColumns: return "Todas las columnas";
                case StringId.ManageRuleAverageAbove: return "Por encima";
                case StringId.ManageRuleAverageBelow: return "Por Debajo";
                case StringId.ManageRuleAverageEqualOrAbove: return "Igual o Mayor";
                case StringId.ManageRuleAverageEqualOrBelow: return "Igual o Menor";
                case StringId.ManageRuleAverageFormatValuesThatAre: return "Formatear valores que son:";
                case StringId.ManageRuleAverageTheAverageForTheSelectedRange: return "Promedio de los valores de la columna";
                case StringId.ManageRuleBelowAverage: return "Debajo del porcentaje";
                case StringId.ManageRuleCaption: return "Administrador de reglas de formato condicional";
                case StringId.ManageRuleCellValueBetween: return "Entre";
                case StringId.ManageRuleCellValueEqualTo: return "Igual a";
                case StringId.ManageRuleCellValueGreaterThan: return "Mayor que";
                case StringId.ManageRuleCellValueGreaterThanOrEqualTo: return "Mayor o Igual que";
                case StringId.ManageRuleCellValueLessThan: return "Menor que";
                case StringId.ManageRuleCellValueLessThanOrEqualTo: return "Menor o igual que";
                case StringId.ManageRuleCellValueNotBetween: return "No está entre";
                case StringId.ManageRuleCellValueNotEqualTo: return "No son iguales a";
                case StringId.ManageRuleColorScale: return "Escalas de color graduales";
                case StringId.ManageRuleColorScale2: return "Escalas de dos colores";
                case StringId.ManageRuleColorScale3: return "Escalas de tres colores";
                case StringId.ManageRuleColorScaleMidpoint: return "Punto Medio";
                case StringId.ManageRuleCommonAutomatic: return "Automático";
                case StringId.ManageRuleCommonColor: return "Color:";
                case StringId.ManageRuleCommonMaximum: return "Maximo";
                case StringId.ManageRuleCommonMinimum: return "Mínimo";
                case StringId.ManageRuleCommonNumber: return "Número";
                case StringId.ManageRuleCommonPercent: return "Porcentaje";
                case StringId.ManageRuleCommonPreview: return "Previsualización";
                case StringId.ManageRuleCommonType: return "Tipo:";
                case StringId.ManageRuleCommonValue: return "Valor";
                case StringId.ManageRuleComplexRuleBaseFormatStyle: return "Estilo de formato";
                case StringId.ManageRuleDataBarAxisColor: return "Color de Axis:";
                case StringId.ManageRuleDataBarBarAppearance: return "Apariencia de la barra:";
                case StringId.ManageRuleDataBarBarDirection: return "Dirección de la barra:";
                case StringId.ManageRuleDataBarBorder: return "Bordes:";
                case StringId.ManageRuleDataBarContext: return "Contexto:";
                case StringId.ManageRuleDataBarDrawAxis: return "Dibujar Axis";
                case StringId.ManageRuleDataBarFill: return "Rellenar:";
                case StringId.ManageRuleDataBarGradientFill: return "Relleno Degradado";
                case StringId.ManageRuleDataBarLTR: return "Izquierda a Derecha";
                case StringId.ManageRuleDataBarNoBorder: return "Sin Bordes";
                case StringId.ManageRuleDataBarRTL: return "Derecha a Izquierda";
                case StringId.ManageRuleDataBarSolidBorder: return "Borde Sólido";
                case StringId.ManageRuleDataBarSolidFill: return "Relleno Sólido";
                case StringId.ManageRuleDataBarUseNegativeBar: return "Uso de barra negativa";
                case StringId.ManageRuleDataUpdate: return "Reglas de actualización de datos";
                case StringId.ManageRuleDatesOccurringBeyond: return "Siguientes dos meses";
                case StringId.ManageRuleDatesOccurringBeyondThisYear: return "Siguiente Año";
                case StringId.ManageRuleDatesOccurringEarlier: return "Seis meses atrás";
                case StringId.ManageRuleDatesOccurringEarlierThisMonth: return "Éste mes, previo a la semana anterior";
                case StringId.ManageRuleDatesOccurringEarlierThisWeek: return "Ésta semana, previo a ayer";
                case StringId.ManageRuleDatesOccurringEarlierThisYear: return "Éste año, previo a éste mes";
                case StringId.ManageRuleDatesOccurringLastWeek: return "Semana pasada";
                case StringId.ManageRuleDatesOccurringLaterThisMonth: return "Éste mes, despúes de ésta semana";
                case StringId.ManageRuleDatesOccurringLaterThisWeek: return "Ésta semana, despúes de mañana";
                case StringId.ManageRuleDatesOccurringLaterThisYear: return "Éste año, después de éste mes";
                case StringId.ManageRuleDatesOccurringMonthAfter1: return "Próximo mes";
                case StringId.ManageRuleDatesOccurringMonthAfter2: return "éste y los Siguientes dos meses";
                case StringId.ManageRuleDatesOccurringMonthAgo1: return "Mes pasado";
                case StringId.ManageRuleDatesOccurringMonthAgo2: return "Últimos dos meses";
                case StringId.ManageRuleDatesOccurringMonthAgo3: return "Últimos tres meses";
                case StringId.ManageRuleDatesOccurringMonthAgo4: return "Últimos cuatro meses";
                case StringId.ManageRuleDatesOccurringMonthAgo5: return "Últimos cinco meses";
                case StringId.ManageRuleDatesOccurringMonthAgo6: return "Últimos seis meses";
                case StringId.ManageRuleDatesOccurringNextWeek: return "Próxima semana";
                case StringId.ManageRuleDatesOccurringPriorThisYear: return "Anterior a éste año";
                case StringId.ManageRuleDatesOccurringThisMonth: return "Éste mes";
                case StringId.ManageRuleDatesOccurringThisWeek: return "Ésta semana";
                case StringId.ManageRuleDatesOccurringToday: return "Hoy";
                case StringId.ManageRuleDatesOccurringTomorrow: return "Mañana";
                case StringId.ManageRuleDatesOccurringYesterday: return "Ayer";



                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalPriorThisYear: return "Anterior a éste año";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalBeyondThisYear: return "Siguiente Año";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalEarlierThisYear: return "Éste año, previo a éste mes";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalLaterThisYear: return "Éste año, después de éste mes";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalEarlierThisMonth: return "Éste mes, previo a la semana anterior";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalLaterThisMonth: return "Éste mes, despúes de ésta semana";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalEarlierThisWeek: return "Ésta semana, previo a ayer";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalLastWeek: return "Semana pasada";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalLaterThisWeek: return "Ésta semana, despúes de mañana";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalNextWeek: return "Próxima semana";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalToday: return "Hoy";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalTomorrow: return "Mañana";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalYesterday: return "Ayer";

                case StringId.FilterCriteriaToStringFunctionIsJanuary: return "Es Enero";
                case StringId.FilterCriteriaToStringFunctionIsFebruary: return "Es Febrero";
                case StringId.FilterCriteriaToStringFunctionIsMarch: return "Es Marzo";
                case StringId.FilterCriteriaToStringFunctionIsApril: return "Es Abril";
                case StringId.FilterCriteriaToStringFunctionIsMay: return "Es Mayo";
                case StringId.FilterCriteriaToStringFunctionIsJune: return "Es Junio";
                case StringId.FilterCriteriaToStringFunctionIsJuly: return "Es Julio";
                case StringId.FilterCriteriaToStringFunctionIsAugust: return "ES Agosto";
                case StringId.FilterCriteriaToStringFunctionIsSeptember: return "Es Septiembre";
                case StringId.FilterCriteriaToStringFunctionIsOctober: return "Es Octubre";
                case StringId.FilterCriteriaToStringFunctionIsNovember: return "Es Noviembre";
                case StringId.FilterCriteriaToStringFunctionIsDecember: return "Es Diciembre";

                case StringId.FilterCriteriaToStringFunctionIsSameDay: return "Es el mismo día";
                case StringId.FilterCriteriaToStringFunctionIsNextMonth: return "Es el mes que viene";
                case StringId.FilterCriteriaToStringFunctionIsNextYear: return "Es el año que viene";
                case StringId.FilterCriteriaToStringFunctionIsLastMonth: return "Es el mes pasado";
                case StringId.FilterCriteriaToStringFunctionIsLastYear: return "Es el año pasado";
                case StringId.FilterCriteriaToStringFunctionIsYearToDate: return "Es el período del año hasta la fecha";
                case StringId.FilterCriteriaToStringFunctionStartsWith: return "Stars With";
                
                case StringId.ManageRuleDeleteRule: return "Quitar regla";
                case StringId.ManageRuleDown: return "Bajar";
                case StringId.ManageRuleEditRule: return "Editar Regla";
                case StringId.ManageRuleEqualOrAboveAverage: return "Igual o Encima del promedio";
                case StringId.ManageRuleEqualOrBelowAverage: return "Igual o Debajo del Promedio";
                case StringId.ManageRuleFormatCellsBackgroundColor: return "Color de fondo:";
                case StringId.ManageRuleFormatCellsBold: return "Negrita";
                case StringId.ManageRuleFormatCellsCaption: return "Formato de celdas";
                case StringId.ManageRuleFormatCellsClear: return "Limpiar";
                case StringId.ManageRuleFormatCellsEffects: return "Efectos:";
                case StringId.ManageRuleFormatCellsFill: return "Relleno";
                case StringId.ManageRuleFormatCellsFont: return "Fuente";
                case StringId.ManageRuleFormatCellsFontColor: return "Color de Fuente";
                case StringId.ManageRuleFormatCellsFontStyle: return "Estilo de fuente";
                case StringId.ManageRuleFormatCellsItalic: return "Cursiva";
                case StringId.ManageRuleFormatCellsNone: return "Ninguna";
                case StringId.ManageRuleFormatCellsPredefinedAppearance: return "Apariencia predefinida";
                case StringId.ManageRuleFormatCellsRegular: return "Regular";
                case StringId.ManageRuleFormatCellsStrikethrough: return "Tachado";
                case StringId.ManageRuleFormatCellsUnderline: return "Subrayado";
                case StringId.ManageRuleFormula: return "Fórmula";
                case StringId.ManageRuleFormulaFormatValuesWhereThisFormulaIsTrue: return "Formatear valores donde ésta formula es verdadera";
                case StringId.ManageRuleGridCaptionApplyToTheRow: return "Aplicar a la fila";
                case StringId.ManageRuleGridCaptionColumn: return "Columna";
                case StringId.ManageRuleGridCaptionColumnApplyTo: return "Aplicar a la columna";
                case StringId.NoneItemText: return "(Ninguna)";
                case StringId.ManageRuleGridCaptionFormat: return "Formato";
                case StringId.ManageRuleGridCaptionRule: return "Regla";
                case StringId.ManageRuleGridCaptionStopIfTrue: return "Detener si es verdadero";
                case StringId.ManageRuleIconSet: return "Conjunto de íconos";
                case StringId.ManageRuleIconSets: return "Conjuntos de íconos";
                case StringId.ManageRuleIconSetsDisplayEachIconAccordingToTheseRules: return "Mostrar cada ícono acorde a éstas reglas";
                case StringId.ManageRuleIconSetsReverseIconOrder: return "Íconos en órden inverso";
                case StringId.ManageRuleIconSetsValueIs: return "El valor es";
                case StringId.ManageRuleIconSetsWhen: return "Cuando";
                case StringId.ManageRuleNewRule: return "Nueva regla...";
                case StringId.ManageRuleNoFormatSet: return "Sin Formato Establecido";
                case StringId.ManageRuleRankedValuesBottom: return "Último";
                case StringId.ManageRuleRankedValuesFormatValuesThatRankInThe: return "Formatear los valores que clasifican en";
                case StringId.ManageRuleRankedValuesOfTheColumnsCellValues: return "% de valores de columna";
                case StringId.ManageRuleRankedValuesTop: return "Primero";
                case StringId.ManageRuleShowFormattingRules: return "Mostrar las reglas de formato para:";
                case StringId.ManageRuleSimpleRuleBaseFormat: return "Formato...";
                case StringId.ManageRuleSpecificTextBeginningWith: return "Comienza con";
                case StringId.ManageRuleSpecificTextContaining: return "Contiene";
                case StringId.ManageRuleSpecificTextEndingWith: return "Termina con";
                case StringId.ManageRuleSpecificTextNotContaining: return "No contiene";
                case StringId.ManageRuleThatContainBlanks: return "Espacios en blanco";
                case StringId.ManageRuleThatContainCellValue: return "Valor de celda";
                case StringId.ManageRuleThatContainDatesOccurring: return "Fechas en transcurso";
                case StringId.ManageRuleThatContainErrors: return "Errores";
                case StringId.ManageRuleThatContainFormatOnlyCellsWith: return "Formatear celdas solo con:";
                case StringId.ManageRuleThatContainNoBlanks: return "Sin espacios en blanco";
                case StringId.ManageRuleThatContainNoErrors: return "Sin errores";
                case StringId.ManageRuleThatContainSpecificText: return "Texto específico";
                case StringId.ManageRuleUniqueOrDuplicateDuplicate: return "Duplicados";
                case StringId.ManageRuleUniqueOrDuplicateFormatAll: return "Formatear todos:";
                case StringId.ManageRuleUniqueOrDuplicateUnique: return "Unicos";
                case StringId.ManageRuleUniqueOrDuplicateValuesInTheSelectedRange: return "Valores de columna";
                case StringId.ManageRuleUp: return "Arriba";
                case StringId.MaskBoxValidateError: return "Especifica el mensaje de excepción que se genera cuando el valor ingresado por el editor" +
                        " especificado por la máscara está incompleto. Valor Devuelto:" +
                        " El valor ingresado está incompleto. ¿Quiere corregirlo?\r\n\r\n" +
                        " SI - Regresa al editor y corríge el valor.\r\n" +
                        " No - Deja el valor como ésta.\r\n" +
                        " Cancelar - Reestablece al valor anterior.\r\n";
                case StringId.NewEditFormattingRuleEditTheRuleDescription: return "Edite la descripción de la regla:";
                case StringId.NewEditFormattingRuleFormatAllCellsBasedOnTheirValues: return "Formatear todas las celdas basadas en sus valores";
                case StringId.NewEditFormattingRuleFormatOnlyCellsThatContain: return "Formatear solo las celdas que contienen";
                case StringId.NewEditFormattingRuleFormatOnlyChangingValues: return "Formatear solo los cambios de valores";
                case StringId.NewEditFormattingRuleFormatOnlyTopOrBottomRankedValues: return "Formatear solo los valores superiores e inferiores de la clasificación";
                case StringId.NewEditFormattingRuleFormatOnlyUniqueOrDuplicateValues: return "Formatear solo valores unicos o duplicados";
                case StringId.NewEditFormattingRuleFormatOnlyValuesThatAreAboveOrBelowAverage: return "Formatear valores que están por encima o debajo del promedio";
                case StringId.NewEditFormattingRuleSelectARuleType: return "Seleccionar un tipo de relga";
                case StringId.NewEditFormattingRuleUseAFormulaToDetermineWhichCellsToFormat: return "Utilizar una formula para determinar que regla formatear";
                case StringId.NewFormattingRule: return "Nuevo formato de regla";

                case StringId.ColorPickPopupAutomaticItemCaption: return "Automático";
                case StringId.ColorPickPopupMoreColorsItemCaption: return "Más colores...";
                case StringId.ColorPickPopupRecentColorsGroupCaption: return "Colores recientes";
                case StringId.ColorPickPopupStandardColorsGroupCaption: return "Colores Standar";
                case StringId.ColorPickPopupThemeColorsGroupCaption: return "Tema de colores";
                case StringId.ColorTabCustom: return "Personalizado";
                case StringId.ColorTabSystem: return "Predeterminados";
                case StringId.ColorTabWeb: return "Web";
                

                // ...
                default:
                    net = base.GetLocalizedString(id);
                    break;
            }
            return net;
        }
    }

}
