using AMDGOINT.Clases;
using AMDGOINT.Formularios.Configuracion.GruposUsuarios;
using DevExpress.Utils;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace AMDGOINT.Formularios.Configuracion.Usuarios
{
    public partial class Frm_UsuariosMain : Form
    {
        private Funciones func = new Funciones();
        
        private int idgrupousuario = 0;
        private int idusuario = 0;

        public Frm_UsuariosMain()
        {
            InitializeComponent();
        }

        #region METODOS MANUALES

        //PARAMETROS INICIO
        private void ParametrosInicio()
        {
            cmbGrupo.Properties.Buttons[1].Shortcut = new KeyShortcut(Keys.F1);

            CargaCombos();
        }

        //CARGAR COMBOS
        private void CargaCombos()
        {
            try
            {
                Datos.Tables["UsuGrupos"].Clear();

                string consulta = "SELECT ID_Registro, Descripcion FROM USUGRUPOS";

                foreach (DataRow fila in func.getColecciondatos(consulta).Rows)
                {
                    Datos.Tables["UsuGrupos"].ImportRow(fila);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un error al cargar los grupos.\n" +
                    e.Message, "Amdgo Mutual", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                
            }
        }

        //REFRESCO LOS DATOS ASOCIADOS AL COMBO DE PROVINCIA
        private void Selecciongrupo(int idregistro)
        {
            //REFRESCO EL COMBO DE PROVINCIAS
            CargaCombos();

            cmbGrupo.EditValue = idregistro;            
        }

        //CARGO LA LISTA DE USUARIOS ASOCIADOS A ESE GRUPO
        private void Cargarusuarios()
        {
            try
            {
                Datos.Tables["Usuarios"].Clear();

                if (idgrupousuario <= 0) { return; }

                string consulta = "SELECT ID_Registro, ID_Grupo, Administrador, Supervisor," +
                    " Usuario AS Nombre, Nick, Contrasena AS Password, Estadoreg AS Estado" +
                    " FROM USUARIOS" +
                    " WHERE ID_Grupo = " + idgrupousuario;

                foreach (DataRow fila in func.getColecciondatos(consulta).Rows)
                {
                    Datos.Tables["Usuarios"].ImportRow(fila);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un error al cargar los usuarios.\n" +
                    e.Message, "Amdgo Mutual", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        //CARGO LOS PERMISOS ASOCIADOS AL GRUPO
        private void Cargapermisos()
        {
            try
            {
                Datos.Tables["Permisos"].Clear();

                if (idgrupousuario <= 0) { return; }

                string consulta = "SELECT RO.ID_Registro, RO.ID_Grupo, PER.Clave, PER.Descripcion," +
                    " PER.Formulario, RO.Acceso" +
                    " FROM ROLESGRUPO RO" +
                    " LEFT OUTER JOIN PERMISOS PER ON(PER.ID_Registro = RO.ID_Permiso)" +
                    " WHERE RO.ID_Grupo = " + idgrupousuario;

                foreach (DataRow fila in func.getColecciondatos(consulta).Rows)
                {
                    Datos.Tables["Permisos"].ImportRow(fila);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Ocurrió un error al cargar los permisos.\n" +
                    e.Message, "Amdgo Mutual", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //AGREGA LA TABLA DE ROLES - PERMISOS CON NUEVOS REGISTROS
        private void AgregaRolespermisos()
        {
            try
            {
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("ID_Grupo");
                campos.Add("ID_Permiso");
                
                string consulta = "SELECT ID_Registro, Clave" +
                    " FROM PERMISOS";

                DataTable dtpermisos =  func.getColecciondatos(consulta);

                //RECORRO LOS GRUPOS
                foreach (DataRow fila in Datos.Tables["UsuGrupos"].Rows)
                {
                    //RECORRO LOS PERMISOS
                    foreach (DataRow permiso in dtpermisos.Rows)
                    {

                        //SI NO CONTIENE EL PERMISO, LO DOY DE ALTA
                        consulta = "SELECT * FROM ROLESGRUPO WHERE (ID_Grupo = " + fila["ID_Registro"] + ")"
                            +" AND (ID_Permiso = " + permiso["ID_Registro"] + ")";

                        if (func.getColecciondatos(consulta).Rows.Count <= 0)
                        {
                            parametros.Clear();
                            parametros.Add(Convert.ToInt32(fila["ID_Registro"]));
                            parametros.Add(Convert.ToInt32(permiso["ID_Registro"]));

                            func.AccionBD(campos, parametros, "I", "ROLESGRUPO", 0, "ID_Registro");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un error al agregar los permisos.\n" +
                    e.Message, "Amdgo Mutual", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //ACTUALIZO EL ESTADO DEL ROL PERMISO
        private void ActualizaPermisos()
        {
            try
            {
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("Acceso");                

                foreach (DataRow fila in Datos.Tables["Permisos"].Rows)
                {
                    if (fila.RowState == DataRowState.Modified)
                    {
                        parametros.Clear();
                        parametros.Add(Convert.ToBoolean(fila["Acceso"]));
                        func.AccionBD(campos, parametros, "U", "ROLESGRUPO", Convert.ToInt64(fila["ID_Registro"]), "ID_Registro");
                        fila.AcceptChanges();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un error al actualizar los permisos.\n" +
                    e.Message, "Amdgo Mutual", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            
            }
        }

        //PROCESO LA ACCION AL ABRIR EL FORMULARIO DE USUARIOS
        private void Formulariousuarios(string accion)
        {
            if (idgrupousuario <= 0)
            {
                MessageBox.Show("Debe Ingresar un grupo para continuar.", "Amdgo Mutual", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Frm_Usuarios formu = new Frm_Usuarios();
            formu.Es_Popup = true;
            formu.Idgrupo = idgrupousuario;

            if (accion == "N") { formu.IDregistro = 0; }
            else { formu.IDregistro = idusuario; }

            if (formu.ShowDialog() == DialogResult.OK)
            { Cargarusuarios(); }
        }

        //BAJA DE USUARIO
        private void Estadousuarios(byte estado)
        {
            try
            {
                if (idusuario <= 0) { return; }

                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("Estadoreg");
                parametros.Add(estado);

                //LLAMO AL METODO QUE SE ENCARGA DE GUARDAR / MODIFICAR LOS DATOS
                func.AccionBD(campos, parametros, "U", "USUARIOS", idusuario, "ID_Registro");

                Cargarusuarios();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un error al dar de baja el usuario.\n" +
                    e.Message, "Amdgo Mutual", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }

        #endregion

        private void Frm_UsuariosMain_Load(object sender, EventArgs e)
        {
            ParametrosInicio();

            TabControl.SelectedTabPageIndex = 0;
        }

        private void cmbGrupo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //SI PRESIONO EL BOTON DE LA IZQUIERDA
            if (e.Button.Kind.ToString() != "Combo")
            {
                Frm_Grupos formulario = new Frm_Grupos();
                formulario.Es_Popup = true;

                int idreg = 0;
                if (cmbGrupo.EditValue != null && cmbGrupo.EditValue.ToString() != "")
                { idreg = Convert.ToInt32(cmbGrupo.EditValue); }

                //ASIGNO EL ID DE LA PROVINCIA EN CASO DE EDITAR EXISTENTE
                formulario.IDregistro = idreg;

                //MUESTRO EL FORMULARIO 
                if (formulario.ShowDialog() == DialogResult.OK) { Selecciongrupo(idreg); }
            }
        }

        private void cmbGrupo_TextChanged(object sender, EventArgs e)
        {
            idgrupousuario = Convert.ToInt32(cmbGrupo.EditValue);

            Cargarusuarios();
            Cargapermisos();
        }

        private void cmbGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete) { cmbGrupo.EditValue = 0; }
        }

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            //if (gridView.RowCount <= 0) { return; }

            e.Allow = false;
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        private void gridView_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (popupMenu.Visible) { popupMenu.HidePopup(); }
            idusuario = 0;

            var registro = gridView.GetRowCellValue(gridView.FocusedRowHandle, gridView.Columns.ColumnByFieldName("ID_Registro"));

            if (registro != null && registro.ToString() != "")
            {
                idusuario = Convert.ToInt32(registro);
            }
        }
        
        private void btnNuevousu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //AGREGO NUEVO REGISTRO
            Formulariousuarios("N");
        }

        private void btnEditarusu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //AGREGO NUEVO REGISTRO
            Formulariousuarios("M");
        }

        private void btnEliminarusu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (idusuario <= 0) { return; }

            if (MessageBox.Show("¿Está seguro de Desactivar éste usuario?", "Amdgo Mutual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Estadousuarios(0);
            }
        }

        private void btnActivarusu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (idusuario <= 0) { return; }

            if (MessageBox.Show("¿Está seguro de Activar éste usuario?", "Amdgo Mutual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Estadousuarios(1);
            }
        }

        private void popupMenu_BeforePopup(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var estado = gridView.GetFocusedRowCellValue(gridView.Columns.ColumnByFieldName("Estado"));

            if (estado != null && estado.ToString() != "" && !Convert.ToBoolean(estado))
            {
                btnEditarusu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnEliminarusu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnActivarusu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnEditarusu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnEliminarusu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnActivarusu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private void btnActualizapermiso_Click(object sender, EventArgs e)
        {
            AgregaRolespermisos();
        }

        private void gridViewpermisos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridViewpermisos.FocusedColumn == colAcceso)
            {
                gridViewpermisos.SetFocusedRowCellValue(colAcceso, 
                    !Convert.ToBoolean(gridViewpermisos.GetFocusedRowCellValue(colAcceso)));

                gridViewpermisos.UpdateCurrentRow();
                ActualizaPermisos();
            }
        }
    }
}
