using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ProcesosMetLifel.Negocio.Catalogos
{
    public class CatalogosMDM : BD
    {

        public void OcupacionProfesionClave(ref DevExpress.Web.ASPxComboBox combobox)
        {
            ProcesosMetLife.Funciones.LlenarControles.LlenarComboBox(ref combobox, catalogosmdm.OcupacionProfesionClave(), "Nombre", "Id");
        }

        public void OcupacionProfesionClave(ref DropDownList dropdownlist)
        {
            ProcesosMetLife.Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, catalogosmdm.OcupacionProfesionClave(), "Nombre", "Id");
        }

        public List<ProcesosMetLife.Propiedades.Listas> getOcupacionProfesion()
        {
            return catalogosmdm.OcupacionProfesion();
        }

        public void OcupacionProfesion(ref DevExpress.Web.ASPxComboBox combobox)
        {
            ProcesosMetLife.Funciones.LlenarControles.LlenarComboBox(ref combobox, catalogosmdm.OcupacionProfesion(), "Nombre", "Id");
        }


        public void OcupacionProfesion(ref DropDownList dropdownlist)
        {
            ProcesosMetLife.Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, catalogosmdm.OcupacionProfesion(), "Nombre", "Id");
        }

        public void Provincia(ref DevExpress.Web.ASPxComboBox combobox)
        {
            ProcesosMetLife.Funciones.LlenarControles.LlenarComboBox(ref combobox, catalogosmdm.Provincia(), "Nombre", "Id");
        }

        public void Provincia(ref DropDownList dropdownlist)
        {
            ProcesosMetLife.Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, catalogosmdm.Provincia(), "Nombre", "Id");
        }

        public List<ProcesosMetLife.Propiedades.Listas> getProvincia()
        {
            return catalogosmdm.Provincia();
        }

        public void Preguntas(ref DropDownList dropdownlist)
        {
            ProcesosMetLife.Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, catalogosmdm.Preguntas(), "Nombre", "Id");
        }

        public void TipoDocumento(ref DevExpress.Web.ASPxComboBox combobox)
        {
            ProcesosMetLife.Funciones.LlenarControles.LlenarComboBox(ref combobox, catalogosmdm.TipoDocumento(), "Nombre", "Id");
        }

        public void TipoDocumento(ref DropDownList dropdownlist)
        {
            ProcesosMetLife.Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, catalogosmdm.TipoDocumento(), "Nombre", "Id");
        }

        public void SubTipoDocumento(ref DevExpress.Web.ASPxComboBox combobox)
        {
            ProcesosMetLife.Funciones.LlenarControles.LlenarComboBox(ref combobox, catalogosmdm.SubTipoDocumento(), "Nombre", "Id");
        }

        public void SubTipoDocumento(ref DropDownList dropdownlist)
        {
            ProcesosMetLife.Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, catalogosmdm.SubTipoDocumento(), "Nombre", "Id");
        }

        public void EntidadGubernamentalEmisora(ref DevExpress.Web.ASPxComboBox combobox)
        {
            ProcesosMetLife.Funciones.LlenarControles.LlenarComboBox(ref combobox, catalogosmdm.EntidadGubernamentalEmisora(), "Nombre", "Id");
        }

        public void EntidadGubernamentalEmisora(ref DropDownList dropdownlist)
        {
            ProcesosMetLife.Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, catalogosmdm.EntidadGubernamentalEmisora(), "Nombre", "Id");
        }

        public List<ProcesosMetLife.Propiedades.Listas> getPais()
        {
            return catalogosmdm.Pais();
        }

        public void Pais(ref DevExpress.Web.ASPxComboBox combobox)
        {
            ProcesosMetLife.Funciones.LlenarControles.LlenarComboBox(ref combobox, catalogosmdm.Pais(), "Nombre", "Id");
        }

        public void Pais(ref DropDownList dropdownlist)
        {
            ProcesosMetLife.Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, catalogosmdm.Pais(), "Nombre", "Id");
        }

        public void EstadoFinal(ref DropDownList dropdownlist)
        {
            ProcesosMetLife.Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, catalogosmdm.EstadoFinal(), "Nombre", "Id");
        }

        public void Comentarios(ref DropDownList dropdownlist, int MotivoComentario)
        {
            ProcesosMetLife.Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, catalogosmdm.Comentarios(MotivoComentario), "Nombre", "Id");
        }
        
    }
}
