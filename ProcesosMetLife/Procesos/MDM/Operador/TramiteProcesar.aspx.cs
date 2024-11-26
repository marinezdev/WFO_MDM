using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

namespace ProcesosMetLife.Procesos.MDM.Operador
{
    public partial class TramiteProcesar : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int IdFlujo = 0;
            int IdMesa = 0;

            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            mensajes.TituloAplicacionEnUso(this, "MDM");

            if (!IsPostBack)
            {
                IdFlujo = int.Parse(Request["IdFlujo"]);
                IdMesa = int.Parse(Request["IdMesa"]);
                PintaMesa(IdFlujo, IdMesa);
            }
        }
        
        protected void listOcupacionProfesion_Init(object sender, EventArgs e)
        {
            //i.catalogosmdm.Pais(ref DDLLugarNacimientoPais);
            List<ProcesosMetLife.Propiedades.Listas> listaElementos = i.catalogosmdm.getOcupacionProfesion();
            ASPxListBox listaOcupacionProfesion = (ASPxListBox)sender;

            foreach (ProcesosMetLife.Propiedades.Listas item in listaElementos)
            {
                listaOcupacionProfesion.Items.Add(item.Nombre, item.Id);
            }
        }

        protected void listEstadoProvincia_Init(object sender, EventArgs e)
        {
            //i.catalogosmdm.Pais(ref DDLLugarNacimientoPais);
            List<ProcesosMetLife.Propiedades.Listas> listaElementos = i.catalogosmdm.getProvincia();
            ASPxListBox listaEstadoProvincia = (ASPxListBox)sender;

            foreach (ProcesosMetLife.Propiedades.Listas item in listaElementos)
            {
                listaEstadoProvincia.Items.Add(item.Nombre, item.Id);
            }
        }

        protected void listPais_Init(object sender, EventArgs e)
        {
            //i.catalogosmdm.Pais(ref DDLLugarNacimientoPais);
            List<ProcesosMetLife.Propiedades.Listas> lsPais = i.catalogosmdm.getPais();
            ASPxListBox ListaPaises = (ASPxListBox)sender;

            foreach (ProcesosMetLife.Propiedades.Listas item in lsPais)
            {
                ListaPaises.Items.Add(item.Nombre, item.Id);
            }
        }

        private void PintaMesa(int IdFlujo, int IdMesa)
        {
            //Pais(ref DDLLugarNacimientoPais);
            //OcupacionProfesion(ref DDLOcupacionProfesion);
            //Preguntas(ref DDL1);
            //Preguntas(ref DDL2);
            //Preguntas(ref DDL3);
            //TipoDocumento(ref DDLTipoDocumento);
            //SubTipoDocumento(ref DDLSubTipoDocumento);
            //EntidadGubernamentalEmisora(ref DDLEntidadGubernamentalEmisora);
            //Pais(ref DDLPaisEmisor);
            //Preguntas(ref DDLEliminar);
            Botones();

            dtFechaInicial.Value = DateTime.Now;
            dtFechaFinal.Value = DateTime.Now;

            i.catalogosmdm.Preguntas(ref DDL1);
            i.catalogosmdm.Preguntas(ref DDL2);
            i.catalogosmdm.Preguntas(ref DDL3);
            i.catalogosmdm.Preguntas(ref DDLEliminar);
            i.catalogosmdm.EstadoFinal(ref DDLEstadoFinal);
            i.catalogosmdm.Comentarios(ref DDLComentarios, 0);
            i.catalogosmdm.Preguntas(ref ddlPagoExtrangero);
            i.catalogosmdm.Preguntas(ref ddlNacionalidadExtrangera);

            i.catalogosmdm.Pais(ref cboLugarNaciomientoPais);
            i.catalogosmdm.OcupacionProfesion(ref cboOcupacionProfesion);
            i.catalogosmdm.TipoDocumento(ref cboTipoDocumento);
            i.catalogosmdm.SubTipoDocumento(ref cboSubTipoDocumento);
            i.catalogosmdm.EntidadGubernamentalEmisora(ref cboEntidadGubernamentalEmisora);
            i.catalogosmdm.Pais(ref cboPaisEmisor);
            i.catalogosmdm.Provincia(ref cboLugarNacimientoProvincia);
            i.catalogosmdm.Pais(ref cboNacionalidad);
            i.catalogosmdm.OcupacionProfesionClave(ref cboOcupacionProfesionClave);
            i.catalogosmdm.Pais(ref cboPaisEmisor);
            

            // Datos Default
            DDLEliminar.SelectedIndex = 2;

            //Obtener los datos del tramite 
            LlenarCamposCaptura(IdFlujo, IdMesa, 0);

            if (IdFlujo == 4)
            {
                switch (IdMesa)
                {
                    case 103:
                        lblTitulo.Text = "CAPTURA";
                        break;

                    case 104:
                        lblTitulo.Text = "CALIDAD";
                        break;

                    case 105:
                        lblTitulo.Text = "VALIDACIÓN";
                        break;
                }
            }
        }

        #region Listados desplegables

        private void OcupacionProfesion(ref DropDownList dropdownlist)
        {
            dropdownlist.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
            dropdownlist.Items.Insert(1, new ListItem("EMPLEADO ACTIVO", "1"));
            dropdownlist.Items.Insert(2, new ListItem("PROFESIONAL INDEPENDIENTE", "2"));
            dropdownlist.Items.Insert(3, new ListItem("COMERCIANTE", "3"));
            dropdownlist.Items.Insert(4, new ListItem("JUBILADO", "4"));
            dropdownlist.Items.Insert(5, new ListItem("AMA DE CASA", "5"));
            dropdownlist.Items.Insert(6, new ListItem("ESTUDIANTE", "6"));
            dropdownlist.Items.Insert(7, new ListItem("OTRO", "7"));
        }

        private void Preguntas(ref DropDownList dropdownlist)
        {
            dropdownlist.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
            dropdownlist.Items.Insert(1, new ListItem("SI", "1"));
            dropdownlist.Items.Insert(2, new ListItem("NO", "2"));
        }

        private void TipoDocumento(ref DropDownList dropdownlist)
        {
            dropdownlist.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
            dropdownlist.Items.Insert(1, new ListItem("IDENTIFICACION OFICIAL PERSONAS FISICAS", "1"));
            dropdownlist.Items.Insert(2, new ListItem("IDENTIFICACION OFICIAL PERSONAS MORALES", "2"));
            dropdownlist.Items.Insert(3, new ListItem("COMPROBANTE DE DOMICILIO", "3"));
            dropdownlist.Items.Insert(4, new ListItem("CURP", "4"));
            dropdownlist.Items.Insert(5, new ListItem("RFC", "5"));
            dropdownlist.Items.Insert(6, new ListItem("NUMERO DE SEGURIDAD SOCIAL", "6"));
            dropdownlist.Items.Insert(7, new ListItem("GUID", "7"));
        }

        private void SubTipoDocumento(ref DropDownList dropdownlist)
        {
            dropdownlist.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
            dropdownlist.Items.Insert(1, new ListItem("CREDENCIAL PARA VOTAR", "1"));
            dropdownlist.Items.Insert(2, new ListItem("PASAPORTE MEXICANO", "2"));
            dropdownlist.Items.Insert(3, new ListItem("CEDULA PROFESIONAL", "3"));
            dropdownlist.Items.Insert(4, new ListItem("CARTILLA DEL SERVICIO MILITAR NACIONAL", "4"));
            dropdownlist.Items.Insert(5, new ListItem("LICENCIA PARA CONDUCIR", "5"));
            dropdownlist.Items.Insert(6, new ListItem("TARJETA DE AFILIACION AL INSTITUTO NACIONAL DE LAS PERSONAS ADULTAS MAYORES", "6"));
            dropdownlist.Items.Insert(7, new ListItem("TARJETA UNICA DE IDENTIDAD MILITAR", "7"));
            dropdownlist.Items.Insert(8, new ListItem("CERTIFICADO DE MATRICULA CONSULAR", "8"));
            dropdownlist.Items.Insert(9, new ListItem("CREDENCIALES DE AFILIACION AL INSTITUTO MEXICANO DEL SEGURO SOCIAL", "9"));
            dropdownlist.Items.Insert(10, new ListItem("FM2(INMIGRANTE - INMIGRADO)", "10"));
            dropdownlist.Items.Insert(11, new ListItem("FM3(NO INMIGRANTES)", "11"));
            dropdownlist.Items.Insert(12, new ListItem("PASAPORTE EXTRANJERO", "12"));
            dropdownlist.Items.Insert(13, new ListItem("IMPUESTO PREDIAL", "13"));
            dropdownlist.Items.Insert(14, new ListItem("RECIBO DE LUZ", "14"));
            dropdownlist.Items.Insert(15, new ListItem("RECIBO DE AGUA", "15"));
            dropdownlist.Items.Insert(16, new ListItem("RECIBO TELEFONICO", "16"));
            dropdownlist.Items.Insert(17, new ListItem("RECIBO TELEVISION DE PAGA", "17"));
            dropdownlist.Items.Insert(18, new ListItem("RECIBO DE GAS", "18"));
            dropdownlist.Items.Insert(19, new ListItem("ESTADO DE CUENTA BANCARIO", "19"));
            dropdownlist.Items.Insert(20, new ListItem("ESTADO DE CUENTA TIENDAS DEPARTAMENTALES", "20"));
            dropdownlist.Items.Insert(21, new ListItem("COPIA CERTIFICADA DE ESCRITURAS DE PROPIEDAD INMOBILIARIA", "21"));
            dropdownlist.Items.Insert(22, new ListItem("CONTRATO DE ARRENDAMIENTO", "22"));
            dropdownlist.Items.Insert(23, new ListItem("COPIA CERTIFICADA DEL TESTIMONIO O DE LA ESCRITURA CONSTITUTIVA(ACTA CONSTITUTIVA)", "23"));
            dropdownlist.Items.Insert(24, new ListItem("CARTA PODER", "24"));
            dropdownlist.Items.Insert(25, new ListItem("DOCUMENTO DE ACREDITACION DE APODERADO(S)", "25"));
            dropdownlist.Items.Insert(26, new ListItem("DOCUMENTO DE ACREDITACION DE LEGAL ESTANCIA DE PM", "26"));
            dropdownlist.Items.Insert(27, new ListItem("ACTA DE ASAMBLEA ELEGIDA POR DIRECTIVA", "27"));
            dropdownlist.Items.Insert(28, new ListItem("TOMA DE NOTA PARA REPRESENTAR SINDICATO", "28"));
            dropdownlist.Items.Insert(29, new ListItem("INSCRIPCION A LA CNBV(CONSTITUCION ANTE CONDUSEF)", "29"));
            dropdownlist.Items.Insert(30, new ListItem("CEDULA DE IDENTIFICACION FISCAL", "30"));
        }

        public void EntidadGubernamentalEmisora(ref DropDownList dropdownlist)
        {
            dropdownlist.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
            dropdownlist.Items.Insert(1, new ListItem("INSTITUTO FEDERAL ELECTORAL", "1"));
            dropdownlist.Items.Insert(2, new ListItem("INSTITUTO NACIONAL ELECTORAL", "2"));
            dropdownlist.Items.Insert(3, new ListItem("SECRETARIA DE RELACIONES EXTERIORES", "3"));
            dropdownlist.Items.Insert(4, new ListItem("SECRETARIA DE EDUCACION PUBLICA", "4"));
            dropdownlist.Items.Insert(5, new ListItem("SECRETARIA DE LA DEFENSA NACIONAL", "5"));
            dropdownlist.Items.Insert(6, new ListItem("GOBIERNO DEL ESTADO", "6"));
            dropdownlist.Items.Insert(7, new ListItem("INSTITUTO NACIONAL DE LAS PERSONAS ADULTAS MAYORES / SECRETARIA DE DESARROLLO SOCIAL", "7"));
            dropdownlist.Items.Insert(8, new ListItem("INSTITUTO MEXICANO DEL SEGURO SOCIAL", "8"));
            dropdownlist.Items.Insert(9, new ListItem("INSTITUTO NACIONAL DE INMIGRACION", "9"));
        }

        public void Pais(ref DropDownList dropdownlist)
        {
            dropdownlist.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
            dropdownlist.Items.Insert(1, new ListItem("AFGANISTAN", "1"));
            dropdownlist.Items.Insert(2, new ListItem("ALBANIA", "2"));
            dropdownlist.Items.Insert(3, new ListItem("ALEMANIA", "3"));
            dropdownlist.Items.Insert(4, new ListItem("ANDORRA", "4"));
            dropdownlist.Items.Insert(5, new ListItem("ANGOLA", "5"));
            dropdownlist.Items.Insert(6, new ListItem("ANGUILA", "6"));
            dropdownlist.Items.Insert(7, new ListItem("ANTARTIDA", "7"));
            dropdownlist.Items.Insert(8, new ListItem("ANTIGUA Y BARBUDA", "8"));
            dropdownlist.Items.Insert(9, new ListItem("ANTILLAS NEERLANDESAS", "9"));
            dropdownlist.Items.Insert(10, new ListItem("ARABIA SAUDITA", "10"));
            dropdownlist.Items.Insert(11, new ListItem("ARGEL", "11"));
            dropdownlist.Items.Insert(12, new ListItem("ARGENTINA", "12"));
            dropdownlist.Items.Insert(13, new ListItem("ARMENIA", "13"));
            dropdownlist.Items.Insert(14, new ListItem("ARUBA", "14"));
            dropdownlist.Items.Insert(15, new ListItem("AUSTRALIA", "15"));
            dropdownlist.Items.Insert(16, new ListItem("AUSTRIA", "16"));
            dropdownlist.Items.Insert(17, new ListItem("AZERBAIYAN", "17"));
            dropdownlist.Items.Insert(18, new ListItem("BAHAMAS", "18"));
            dropdownlist.Items.Insert(19, new ListItem("BAHREIN", "19"));
            dropdownlist.Items.Insert(20, new ListItem("BANGLADESH", "20"));
            dropdownlist.Items.Insert(21, new ListItem("BARBADOS", "21"));
            dropdownlist.Items.Insert(22, new ListItem("BELARUS", "22"));
            dropdownlist.Items.Insert(23, new ListItem("BELGICA", "23"));
            dropdownlist.Items.Insert(24, new ListItem("BELICE", "24"));
            dropdownlist.Items.Insert(25, new ListItem("BENIN", "25"));
            dropdownlist.Items.Insert(26, new ListItem("BERMUDAS", "26"));
            dropdownlist.Items.Insert(27, new ListItem("BHUTAN", "27"));
            dropdownlist.Items.Insert(28, new ListItem("BOLIVIA", "28"));
            dropdownlist.Items.Insert(29, new ListItem("BOSNIA Y HERZEGOVINA", "29"));
            dropdownlist.Items.Insert(30, new ListItem("BOTSUANA", "30"));
            dropdownlist.Items.Insert(31, new ListItem("BRASIL", "31"));
            dropdownlist.Items.Insert(32, new ListItem("BRUNEI", "32"));
            dropdownlist.Items.Insert(33, new ListItem("BULGARIA", "33"));
            dropdownlist.Items.Insert(34, new ListItem("BURKINA FASO", "34"));
            dropdownlist.Items.Insert(35, new ListItem("BURUNDI", "35"));
            dropdownlist.Items.Insert(36, new ListItem("CABO VERDE", "36"));
            dropdownlist.Items.Insert(37, new ListItem("CAMBOYA", "37"));
            dropdownlist.Items.Insert(38, new ListItem("CAMERUN", "38"));
            dropdownlist.Items.Insert(39, new ListItem("CANADA", "39"));
            dropdownlist.Items.Insert(40, new ListItem("CHAD", "40"));
            dropdownlist.Items.Insert(41, new ListItem("CHILE", "41"));
            dropdownlist.Items.Insert(42, new ListItem("CHINA", "42"));
            dropdownlist.Items.Insert(43, new ListItem("CHIPRE", "43"));
            dropdownlist.Items.Insert(44, new ListItem("CIUDAD DEL VATICANO", "44"));
            dropdownlist.Items.Insert(45, new ListItem("COLOMBIA", "45"));
            dropdownlist.Items.Insert(46, new ListItem("COMOROS", "46"));
            dropdownlist.Items.Insert(47, new ListItem("CONGO", "47"));
            dropdownlist.Items.Insert(48, new ListItem("COREA DEL NORTE", "48"));
            dropdownlist.Items.Insert(49, new ListItem("COREA DEL SUR", "49"));
            dropdownlist.Items.Insert(50, new ListItem("COSTA DE MARFIL", "50"));
            dropdownlist.Items.Insert(51, new ListItem("COSTA RICA", "51"));
            dropdownlist.Items.Insert(52, new ListItem("CROACIA", "52"));
            dropdownlist.Items.Insert(53, new ListItem("CUBA", "53"));
            dropdownlist.Items.Insert(54, new ListItem("DINAMARCA", "54"));
            dropdownlist.Items.Insert(55, new ListItem("DOMINICA", "55"));
            dropdownlist.Items.Insert(56, new ListItem("ECUADOR", "56"));
            dropdownlist.Items.Insert(57, new ListItem("EGIPTO", "57"));
            dropdownlist.Items.Insert(58, new ListItem("EL SALVADOR", "58"));
            dropdownlist.Items.Insert(59, new ListItem("EMIRATOS ARABES UNIDOS", "59"));
            dropdownlist.Items.Insert(60, new ListItem("ERITREA", "60"));
            dropdownlist.Items.Insert(61, new ListItem("ESLOVAQUIA", "61"));
            dropdownlist.Items.Insert(62, new ListItem("ESLOVENIA", "62"));
            dropdownlist.Items.Insert(63, new ListItem("ESPAÑA", "63"));
            dropdownlist.Items.Insert(64, new ListItem("ESTADOS UNIDOS DE AMERICA", "64"));
            dropdownlist.Items.Insert(65, new ListItem("ESTONIA", "65"));
            dropdownlist.Items.Insert(66, new ListItem("ETIOPIA", "66"));
            dropdownlist.Items.Insert(67, new ListItem("FIJI", "67"));
            dropdownlist.Items.Insert(68, new ListItem("FILIPINAS", "68"));
            dropdownlist.Items.Insert(69, new ListItem("FINLANDIA", "69"));
            dropdownlist.Items.Insert(70, new ListItem("FRANCIA", "70"));
            dropdownlist.Items.Insert(71, new ListItem("GABON", "71"));
            dropdownlist.Items.Insert(72, new ListItem("GAMBIA", "72"));
            dropdownlist.Items.Insert(73, new ListItem("GEORGIA", "73"));
            dropdownlist.Items.Insert(74, new ListItem("GEORGIA DEL SUR E ISLAS SANDWICH DEL SUR", "74"));
            dropdownlist.Items.Insert(75, new ListItem("GHANA", "75"));
            dropdownlist.Items.Insert(76, new ListItem("GIBRALTAR", "76"));
            dropdownlist.Items.Insert(77, new ListItem("GRANADA", "77"));
            dropdownlist.Items.Insert(78, new ListItem("GRECIA", "78"));
            dropdownlist.Items.Insert(79, new ListItem("GROENLANDIA", "79"));
            dropdownlist.Items.Insert(80, new ListItem("GUADALUPE", "80"));
            dropdownlist.Items.Insert(81, new ListItem("GUAM", "81"));
            dropdownlist.Items.Insert(82, new ListItem("GUATEMALA", "82"));
            dropdownlist.Items.Insert(83, new ListItem("GUAYANA", "83"));
            dropdownlist.Items.Insert(84, new ListItem("GUAYANA FRANCESA", "84"));
            dropdownlist.Items.Insert(85, new ListItem("GUERNSEY", "85"));
            dropdownlist.Items.Insert(86, new ListItem("GUINEA", "86"));
            dropdownlist.Items.Insert(87, new ListItem("GUINEA ECUATORIAL", "87"));
            dropdownlist.Items.Insert(88, new ListItem("GUINEA-BISSAU", "88"));
            dropdownlist.Items.Insert(89, new ListItem("HAITI", "89"));
            dropdownlist.Items.Insert(90, new ListItem("HONDURAS", "90"));
            dropdownlist.Items.Insert(91, new ListItem("HONG KONG", "91"));
            dropdownlist.Items.Insert(92, new ListItem("HUNGRIA", "92"));
            dropdownlist.Items.Insert(93, new ListItem("INDIA", "93"));
            dropdownlist.Items.Insert(94, new ListItem("INDONESIA", "94"));
            dropdownlist.Items.Insert(95, new ListItem("IRAK", "95"));
            dropdownlist.Items.Insert(96, new ListItem("IRAN", "96"));
            dropdownlist.Items.Insert(97, new ListItem("IRLANDA", "97"));
            dropdownlist.Items.Insert(98, new ListItem("ISLA BOUVET", "98"));
            dropdownlist.Items.Insert(99, new ListItem("ISLA DE MAN", "99"));
            dropdownlist.Items.Insert(100, new ListItem("ISLANDIA", "100"));
            dropdownlist.Items.Insert(101, new ListItem("ISLAS ALAND", "101"));
            dropdownlist.Items.Insert(102, new ListItem("ISLAS CAIMAN", "102"));
            dropdownlist.Items.Insert(103, new ListItem("ISLAS CHRISTMAS", "103"));
            dropdownlist.Items.Insert(104, new ListItem("ISLAS COCOS", "104"));
            dropdownlist.Items.Insert(105, new ListItem("ISLAS COOK", "105"));
            dropdownlist.Items.Insert(106, new ListItem("ISLAS FAROE", "106"));
            dropdownlist.Items.Insert(107, new ListItem("ISLAS HEARD Y MCDONALD", "107"));
            dropdownlist.Items.Insert(108, new ListItem("ISLAS MALVINAS", "108"));
            dropdownlist.Items.Insert(109, new ListItem("ISLAS MARSHALL", "109"));
            dropdownlist.Items.Insert(110, new ListItem("ISLAS NORKFOLK", "110"));
            dropdownlist.Items.Insert(111, new ListItem("ISLAS PALAOS", "111"));
            dropdownlist.Items.Insert(112, new ListItem("ISLAS PITCAIRN", "112"));
            dropdownlist.Items.Insert(113, new ListItem("ISLAS SOLOMON", "113"));
            dropdownlist.Items.Insert(114, new ListItem("ISLAS SVALBARD Y JAN MAYEN", "114"));
            dropdownlist.Items.Insert(115, new ListItem("ISLAS TURCAS Y CAICOS", "115"));
            dropdownlist.Items.Insert(116, new ListItem("ISLAS VIRGENES BRITANICAS", "116"));
            dropdownlist.Items.Insert(117, new ListItem("ISLAS VIRGENES DE LOS ESTADOS UNIDOS DE AMERICA", "117"));
            dropdownlist.Items.Insert(118, new ListItem("ISRAEL", "118"));
            dropdownlist.Items.Insert(119, new ListItem("ITALIA", "119"));
            dropdownlist.Items.Insert(120, new ListItem("JAMAICA", "120"));
            dropdownlist.Items.Insert(121, new ListItem("JAPON", "121"));
            dropdownlist.Items.Insert(122, new ListItem("JERSEY", "122"));
            dropdownlist.Items.Insert(123, new ListItem("JORDANIA", "123"));
            dropdownlist.Items.Insert(124, new ListItem("KAZAJSTAN", "124"));
            dropdownlist.Items.Insert(125, new ListItem("KENIA", "125"));
            dropdownlist.Items.Insert(126, new ListItem("KIRGUISTAN", "126"));
            dropdownlist.Items.Insert(127, new ListItem("KIRIBATI", "127"));
            dropdownlist.Items.Insert(128, new ListItem("KUWAIT", "128"));
            dropdownlist.Items.Insert(129, new ListItem("LAOS", "129"));
            dropdownlist.Items.Insert(130, new ListItem("LESOTHO", "130"));
            dropdownlist.Items.Insert(131, new ListItem("LETONIA", "131"));
            dropdownlist.Items.Insert(132, new ListItem("LIBANO", "132"));
            dropdownlist.Items.Insert(133, new ListItem("LIBERIA", "133"));
            dropdownlist.Items.Insert(134, new ListItem("LIBIA", "134"));
            dropdownlist.Items.Insert(135, new ListItem("LIECHTENSTEIN", "135"));
            dropdownlist.Items.Insert(136, new ListItem("LITUANIA", "136"));
            dropdownlist.Items.Insert(137, new ListItem("LUXEMBURGO", "137"));
            dropdownlist.Items.Insert(138, new ListItem("MACAO", "138"));
            dropdownlist.Items.Insert(139, new ListItem("MACEDONIA", "139"));
            dropdownlist.Items.Insert(140, new ListItem("MADAGASCAR", "140"));
            dropdownlist.Items.Insert(141, new ListItem("MALASIA", "141"));
            dropdownlist.Items.Insert(142, new ListItem("MALAWI", "142"));
            dropdownlist.Items.Insert(143, new ListItem("MALDIVAS", "143"));
            dropdownlist.Items.Insert(144, new ListItem("MALI", "144"));
            dropdownlist.Items.Insert(145, new ListItem("MALTA", "145"));
            dropdownlist.Items.Insert(146, new ListItem("MARRUECOS", "146"));
            dropdownlist.Items.Insert(147, new ListItem("MARTINICA", "147"));
            dropdownlist.Items.Insert(148, new ListItem("MAURICIO", "148"));
            dropdownlist.Items.Insert(149, new ListItem("MAURITANIA", "149"));
            dropdownlist.Items.Insert(150, new ListItem("MAYOTTE", "150"));
            dropdownlist.Items.Insert(151, new ListItem("MEXICO", "151"));
            dropdownlist.Items.Insert(152, new ListItem("MICRONESIA", "152"));
            dropdownlist.Items.Insert(153, new ListItem("MOLDOVA", "153"));
            dropdownlist.Items.Insert(154, new ListItem("MONACO", "154"));
            dropdownlist.Items.Insert(155, new ListItem("MONGOLIA", "155"));
            dropdownlist.Items.Insert(156, new ListItem("MONTENEGRO", "156"));
            dropdownlist.Items.Insert(157, new ListItem("MONTSERRAT", "157"));
            dropdownlist.Items.Insert(158, new ListItem("MOZAMBIQUE", "158"));
            dropdownlist.Items.Insert(159, new ListItem("MYANMAR", "159"));
            dropdownlist.Items.Insert(160, new ListItem("NAMIBIA", "160"));
            dropdownlist.Items.Insert(161, new ListItem("NAURU", "161"));
            dropdownlist.Items.Insert(162, new ListItem("NEPAL", "162"));
            dropdownlist.Items.Insert(163, new ListItem("NICARAGUA", "163"));
            dropdownlist.Items.Insert(164, new ListItem("NIGER", "164"));
            dropdownlist.Items.Insert(165, new ListItem("NIGERIA", "165"));
            dropdownlist.Items.Insert(166, new ListItem("NIUE", "166"));
            dropdownlist.Items.Insert(167, new ListItem("NORUEGA", "167"));
            dropdownlist.Items.Insert(168, new ListItem("NUEVA CALEDONIA", "168"));
            dropdownlist.Items.Insert(169, new ListItem("NUEVA ZELANDA", "169"));
            dropdownlist.Items.Insert(170, new ListItem("OMAN", "170"));
            dropdownlist.Items.Insert(171, new ListItem("PAISES BAJOS", "171"));
            dropdownlist.Items.Insert(172, new ListItem("PAKISTAN", "172"));
            dropdownlist.Items.Insert(173, new ListItem("PALESTINA", "173"));
            dropdownlist.Items.Insert(174, new ListItem("PANAMA", "174"));
            dropdownlist.Items.Insert(175, new ListItem("PAPUA NUEVA GUINEA", "175"));
            dropdownlist.Items.Insert(176, new ListItem("PARAGUAY", "176"));
            dropdownlist.Items.Insert(177, new ListItem("PERU", "177"));
            dropdownlist.Items.Insert(178, new ListItem("POLINESIA FRANCESA", "178"));
            dropdownlist.Items.Insert(179, new ListItem("POLONIA", "179"));
            dropdownlist.Items.Insert(180, new ListItem("PORTUGAL", "180"));
            dropdownlist.Items.Insert(181, new ListItem("PUERTO RICO", "181"));
            dropdownlist.Items.Insert(182, new ListItem("QATAR", "182"));
            dropdownlist.Items.Insert(183, new ListItem("REINO UNIDO", "183"));
            dropdownlist.Items.Insert(184, new ListItem("REPUBLICA CENTRO-AFRICANA", "184"));
            dropdownlist.Items.Insert(185, new ListItem("REPUBLICA CHECA", "185"));
            dropdownlist.Items.Insert(186, new ListItem("REPUBLICA DOMINICANA", "186"));
            dropdownlist.Items.Insert(187, new ListItem("REUNION", "187"));
            dropdownlist.Items.Insert(188, new ListItem("RUANDA", "188"));
            dropdownlist.Items.Insert(189, new ListItem("RUMANIA", "189"));
            dropdownlist.Items.Insert(190, new ListItem("RUSIA", "190"));
            dropdownlist.Items.Insert(191, new ListItem("SAHARA OCCIDENTAL", "191"));
            dropdownlist.Items.Insert(192, new ListItem("SAMOA", "192"));
            dropdownlist.Items.Insert(193, new ListItem("SAMOA AMERICANA", "193"));
            dropdownlist.Items.Insert(194, new ListItem("SAN BARTOLOME", "194"));
            dropdownlist.Items.Insert(195, new ListItem("SAN CRISTOBAL Y NIEVES", "195"));
            dropdownlist.Items.Insert(196, new ListItem("SAN MARINO", "196"));
            dropdownlist.Items.Insert(197, new ListItem("SAN PEDRO Y MIQUELON", "197"));
            dropdownlist.Items.Insert(198, new ListItem("SAN VICENTE Y LAS GRANADINAS", "198"));
            dropdownlist.Items.Insert(199, new ListItem("SANTA ELENA", "199"));
            dropdownlist.Items.Insert(200, new ListItem("SANTA LUCIA", "200"));
            dropdownlist.Items.Insert(201, new ListItem("SANTO TOME Y PRINCIPE", "201"));
            dropdownlist.Items.Insert(202, new ListItem("SENEGAL", "202"));
            dropdownlist.Items.Insert(203, new ListItem("SERBIA Y MONTENEGRO", "203"));
            dropdownlist.Items.Insert(204, new ListItem("SEYCHELLES", "204"));
            dropdownlist.Items.Insert(205, new ListItem("SIERRA LEONA", "205"));
            dropdownlist.Items.Insert(206, new ListItem("SINGAPUR", "206"));
            dropdownlist.Items.Insert(207, new ListItem("SIRIA", "207"));
            dropdownlist.Items.Insert(208, new ListItem("SOMALIA", "208"));
            dropdownlist.Items.Insert(209, new ListItem("SRI LANKA", "209"));
            dropdownlist.Items.Insert(210, new ListItem("SUAZILANDIA", "210"));
            dropdownlist.Items.Insert(211, new ListItem("SUDAFRICA", "211"));
            dropdownlist.Items.Insert(212, new ListItem("SUDAN", "212"));
            dropdownlist.Items.Insert(213, new ListItem("SUECIA", "213"));
            dropdownlist.Items.Insert(214, new ListItem("SUIZA", "214"));
            dropdownlist.Items.Insert(215, new ListItem("SURINAM", "215"));
            dropdownlist.Items.Insert(216, new ListItem("TAILANDIA", "216"));
            dropdownlist.Items.Insert(217, new ListItem("TAIWAN", "217"));
            dropdownlist.Items.Insert(218, new ListItem("TANZANIA", "218"));
            dropdownlist.Items.Insert(219, new ListItem("TAYIKISTAN", "219"));
            dropdownlist.Items.Insert(220, new ListItem("TERRITORIO BRITANICO DEL OCEANO INDICO", "220"));
            dropdownlist.Items.Insert(221, new ListItem("TERRITORIOS AUSTRALES FRANCESES", "221"));
            dropdownlist.Items.Insert(222, new ListItem("TIMOR-LESTE", "222"));
            dropdownlist.Items.Insert(223, new ListItem("TOGO", "223"));
            dropdownlist.Items.Insert(224, new ListItem("TOKELAU", "224"));
            dropdownlist.Items.Insert(225, new ListItem("TONGA", "225"));
            dropdownlist.Items.Insert(226, new ListItem("TRINIDAD Y TOBAGO", "226"));
            dropdownlist.Items.Insert(227, new ListItem("TUNEZ", "227"));
            dropdownlist.Items.Insert(228, new ListItem("TURKMENISTAN", "228"));
            dropdownlist.Items.Insert(229, new ListItem("TURQUIA", "229"));
            dropdownlist.Items.Insert(230, new ListItem("TUVALU", "230"));
            dropdownlist.Items.Insert(231, new ListItem("UCRANIA", "231"));
            dropdownlist.Items.Insert(232, new ListItem("UGANDA", "232"));
            dropdownlist.Items.Insert(233, new ListItem("URUGUAY", "233"));
            dropdownlist.Items.Insert(234, new ListItem("UZBEKISTAN", "234"));
            dropdownlist.Items.Insert(235, new ListItem("VANUATU", "235"));
            dropdownlist.Items.Insert(236, new ListItem("VENEZUELA", "236"));
            dropdownlist.Items.Insert(237, new ListItem("VIETNAM", "237"));
            dropdownlist.Items.Insert(238, new ListItem("WALLIS Y FUTUNA", "238"));
            dropdownlist.Items.Insert(239, new ListItem("YEMEN", "239"));
            dropdownlist.Items.Insert(240, new ListItem("YIBUTI", "240"));
            dropdownlist.Items.Insert(241, new ListItem("BONAIRE SAN EUSTAQUIO Y SABA", "241"));
            dropdownlist.Items.Insert(242, new ListItem("CONGO LA REPUBLICA DEMOCRATICA", "242"));
            dropdownlist.Items.Insert(243, new ListItem("CURAZAO", "243"));
            dropdownlist.Items.Insert(244, new ListItem("SAN MARTIN (FRANCIA)", "244"));
            dropdownlist.Items.Insert(245, new ListItem("ISLAS MARIANAS DEL NORTE", "245"));
            dropdownlist.Items.Insert(246, new ListItem("SUDAN DEL SUR", "246"));
            dropdownlist.Items.Insert(247, new ListItem("SAN MARTIN (HOLANDA)", "247"));
            dropdownlist.Items.Insert(248, new ListItem("ISLAS ULTRAMARINAS MENORES DE ESTADOS UNIDOS", "248"));
            dropdownlist.Items.Insert(249, new ListItem("ZAMBIA", "249"));
            dropdownlist.Items.Insert(250, new ListItem("ZIMBABUE", "250"));
        }
        #endregion

        /// <summary>
        /// Visibilidad de botones en el proceso
        /// </summary>
        protected void Botones()
        {
            btnAceptarObs.Visible = false;
            //btnAceptar.Visible = true;
            btnSelccionCompleta.Visible = false;
            btnPCI.Visible = false;
            btnHold.Visible = false;
            btnSuspender.Visible = false;
            btnRechazar.Visible = false;
            btnDetener.Visible = false;
        }

        /// <summary>
        /// Procesamiento que llevará a cabo el botón presionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BotonPresionado_Click(object sender, EventArgs e)
        {
            Button valor = (Button)sender;

            switch (valor.ID)
            {
                case "btnAceptarObs":
                    mensajes.MostrarMensaje(this, "Se ha presionado el botón de Aceptar");
                    break;
                case "btnAceptar":
                    string MensajeError = "";
                    int IdStatusMesa = 17;
                    bool Validacion = true;
                    DateTime FechaInicial = DateTime.Now;
                    DateTime FechaFinal = DateTime.Now;

                    // Validación de la Fecha de Emisión
                    try
                    {
                        FechaInicial = Convert.ToDateTime(dtFechaInicial.Value.ToString()) ;
                        FechaFinal   = Convert.ToDateTime(dtFechaFinal.Value.ToString());

                        if (FechaFinal <= FechaInicial.AddDays(1))
                        {
                            if (FechaInicial.ToShortDateString() == "01/01/3000" && FechaFinal.ToShortDateString() == "01/01/3000")
                            {
                                // Validación de Fecha Correcto
                                dtFechaInicial.BackColor = Color.White;
                                dtFechaFinal.BackColor = Color.White;
                            }
                            else 
                            {
                                Validacion = false;
                                dtFechaInicial.BackColor = Color.Red;
                                dtFechaFinal.BackColor = Color.Red;
                                //MensajeError = "La fecha de vigencia de la identificación es incorrecta. ";
                            }
                        }
                        else
                        {
                            dtFechaInicial.BackColor = Color.White;
                            dtFechaFinal.BackColor = Color.White;
                        }
                    }
                    catch (Exception ex)
                    {
                        Validacion = false;
                        //MensajeError += "Formato de Fecha Inválidos. ";
                    }

                    if (cboLugarNaciomientoPais.SelectedIndex == -1) { Validacion = false; cboLugarNaciomientoPais.BackColor = Color.Red; } else { cboLugarNaciomientoPais.BackColor = Color.White; }
                    if (cboLugarNacimientoProvincia.SelectedIndex == -1) { Validacion = false; cboLugarNacimientoProvincia.BackColor = Color.Red; } else { cboLugarNacimientoProvincia.BackColor = Color.White; }
                    if (cboNacionalidad.SelectedIndex == -1) { Validacion = false; cboNacionalidad.BackColor = Color.Red; } else { cboNacionalidad.BackColor = Color.White; }
                    if (cboOcupacionProfesion.SelectedIndex == -1) { Validacion = false; cboOcupacionProfesion.BackColor = Color.Red; } else { cboOcupacionProfesion.BackColor = Color.White; }
                    if (cboOcupacionProfesionClave.SelectedIndex == -1) { Validacion = false; cboOcupacionProfesionClave.BackColor = Color.Red; } else { cboOcupacionProfesionClave.BackColor = Color.White; }
                    if (cboTipoDocumento.SelectedIndex == -1) { Validacion = false; cboTipoDocumento.BackColor = Color.Red; } else { cboTipoDocumento.BackColor = Color.White; }
                    if (cboSubTipoDocumento.SelectedIndex == -1) { Validacion = false; cboSubTipoDocumento.BackColor = Color.Red; } else { cboSubTipoDocumento.BackColor = Color.White; }
                    if (cboEntidadGubernamentalEmisora.SelectedIndex == -1) { Validacion = false; cboEntidadGubernamentalEmisora.BackColor = Color.Red; } else { cboEntidadGubernamentalEmisora.BackColor = Color.White; }
                    if (cboPaisEmisor.SelectedIndex == -1) { Validacion = false; cboPaisEmisor.BackColor = Color.Red; } else { cboPaisEmisor.BackColor = Color.White; }
                    if (DDL1.SelectedIndex == 0 || DDL1.SelectedIndex == -1) { Validacion = false; DDL1.BackColor = Color.Red; } else { DDL1.BackColor = Color.White; }
                    if (ddlPagoExtrangero.SelectedIndex == 0 || ddlPagoExtrangero.SelectedIndex == -1) { Validacion = false; ddlPagoExtrangero.BackColor = Color.Red; } else { ddlPagoExtrangero.BackColor = Color.White; }
                    if (DDL2.SelectedIndex == 0 || DDL2.SelectedIndex == -1) { Validacion = false; DDL2.BackColor = Color.Red; } else { DDL2.BackColor = Color.White; }
                    if (ddlNacionalidadExtrangera.SelectedIndex == 0 || ddlNacionalidadExtrangera.SelectedIndex == -1) { Validacion = false; ddlNacionalidadExtrangera.BackColor = Color.Red; } else { ddlNacionalidadExtrangera.BackColor = Color.White; }
                    if (DDL3.SelectedIndex == 0 || DDL3.SelectedIndex == -1) { Validacion = false; DDL3.BackColor = Color.Red; } else { DDL3.BackColor = Color.White; }
                    if (DDLEliminar.SelectedIndex == 0 || DDLEliminar.SelectedIndex == -1) { Validacion = false; DDLEliminar.BackColor = Color.Red; } else { DDLEliminar.BackColor = Color.White; }
                    if (DDLEstadoFinal.SelectedIndex == 0 || DDLEstadoFinal.SelectedIndex == -1) { Validacion = false; DDLEstadoFinal.BackColor = Color.Red; } else { DDLEstadoFinal.BackColor = Color.White; }
                    if ((DDLComentarios.SelectedIndex == 0 || DDLComentarios.SelectedIndex == -1) || (DDLComentarios.Items.Count > 2 && DDLComentarios.SelectedIndex == 0)) { Validacion = false; DDLComentarios.BackColor = Color.Red; } else { DDLComentarios.BackColor = Color.White; }
                    if (TextBox5.Text.Trim() == "" || TextBox5.Text.Trim().Length < 3 || TextBox5.Text.Trim() == "SIN INFORMACION" ) { Validacion = false; TextBox5.BackColor = Color.Red; } else { TextBox5.BackColor = Color.White; }
                    if (TextBox8.Text.Trim() == "" || TextBox8.Text.Trim().Length < 3 || TextBox8.Text.Trim() == "SIN INFORMACION") { Validacion = false; TextBox8.BackColor = Color.Red; } else { TextBox8.BackColor = Color.White; }
                    if (TextBox9.Text.Trim() == "" || TextBox9.Text.Trim().Length < 3 || TextBox9.Text.Trim() == "SIN INFORMACION") { Validacion = false; TextBox9.BackColor = Color.Red; } else { TextBox9.BackColor = Color.White; }
                    if (TextBox10.Text.Trim() == "" || TextBox10.Text.Trim().Length < 1 || TextBox10.Text.Trim() == "SIN INFORMACION") { Validacion = false; TextBox10.BackColor = Color.Red; } else { TextBox10.BackColor = Color.White; }
                    if (TextBox11.Text.Trim() == "" || TextBox11.Text.Trim().Length < 1 || TextBox11.Text.Trim() == "SIN INFORMACION") { Validacion = false; TextBox11.BackColor = Color.Red; } else { TextBox11.BackColor = Color.White; }
                    if (TextBox12.Text.Trim() == "" || TextBox12.Text.Trim().Length < 1 || TextBox12.Text.Trim() == "SIN INFORMACION") { Validacion = false; TextBox12.BackColor = Color.Red; } else { TextBox12.BackColor = Color.White; }
                    if (TextBox13.Text.Trim() == "" || TextBox13.Text.Trim().Length < 1 || TextBox13.Text.Trim() == "SIN INFORMACION") { Validacion = false; TextBox13.BackColor = Color.Red; } else { TextBox13.BackColor = Color.White; }
                    if (TextBox15.Text.Trim() == "" || TextBox15.Text.Trim().Length < 3 || TextBox15.Text.Trim() == "SIN INFORMACION") { Validacion = false; TextBox15.BackColor = Color.Red; } else { TextBox15.BackColor = Color.White; }
                    if (TextBox17.Text.Trim() == "" || TextBox17.Text.Trim().Length < 3 || TextBox17.Text.Trim() == "SIN INFORMACION") { Validacion = false; TextBox17.BackColor = Color.Red; } else { TextBox17.BackColor = Color.White; }
                    if (TextBox18.Text.Trim() == "" || (TextBox18.Text.Trim().Length < 3 && TextBox18.Text.Trim() != "1") || TextBox18.Text.Trim() == "SIN INFORMACION") { Validacion = false; TextBox18.BackColor = Color.Red; } else { TextBox18.BackColor = Color.White; }

                    //if (DDLEstadoFinal.SelectedValue.ToString() == "8")
                    //{
                    //    Validacion = true;
                    //}

                    if (!Validacion)
                    {
                        mensajes.MostrarMensaje(this, "Debe capturar toda la información marcada en rojo. " + MensajeError.ToUpper());
                    }
                    else
                    {
                        string mensajeValidacion = "";
                        Validacion = true;

                        //validación sin información del tipo de documento
                        if (cboTipoDocumento.Text.Trim() == "( SIN INFORMACIÓN )")
                        {
                            if (
                                (cboSubTipoDocumento.Text.Trim() != "( SIN INFORMACIÓN )") 
                                || (TextBox18.Text.Trim() != "S/N") 
                                || (FechaInicial.ToString("dd/MM/yyyy") != "01/01/3000")
                                || (FechaFinal.ToString("dd/MM/yyyy") != "01/01/3000")
                                || (cboEntidadGubernamentalEmisora.Text.Trim() != "( SIN INFORMACIÓN )")
                                || (cboPaisEmisor.Text.Trim() != "( SIN INFORMACIÓN )")
                            )
                            {
                                mensajeValidacion = "Validación 1. Tipo de Documento SIN INFORMACIÓN y existen datos Adicionales...";
                                Validacion = false;
                            }
                        }

                        // validamos el tipo de documento
                        if (cboTipoDocumento.Text.Trim() == "IDENTIFICACION OFICIAL PERSONAS FISICAS")
                        {
                            // validación de crédencial para votar
                            if (cboSubTipoDocumento.Text.Trim() == "CREDENCIAL PARA VOTAR")
                            {
                                if (TextBox18.Text.Trim() != "1" && TextBox18.Text.Trim().Length != 13)
                                {
                                    mensajeValidacion = "Validación 2. Referencia de la Identificación es incorrecta.";
                                    Validacion = false;
                                }
                            }
                        }

                        // Validación entidad emisora
                        if (cboEntidadGubernamentalEmisora.Text.Trim() == "( SIN INFORMACIÓN )")
                        {
                            if (cboPaisEmisor.Text.Trim() != "( SIN INFORMACIÓN )")
                            {
                                mensajeValidacion = "Validación 3. Entidad Gubernamental / País Emisor incorrecto.";
                                Validacion = false;
                            }
                        }

                        if (!Validacion)
                        {
                            mensajes.MostrarMensaje(this, mensajeValidacion);
                        }
                        else
                        {
                            // Guardar la captura
                            Propiedades.Extraccion_MDM items = new Propiedades.Extraccion_MDM();
                            items.Numero = TextBox1.Text.Trim();
                            items.Poliza = TextBox2.Text.Trim();
                            items.GUID_ = TextBox3.Text.Trim();
                            items.PaisNacimiento = cboLugarNaciomientoPais.Text.Trim();
                            items.EstadoNacimiento = cboLugarNacimientoProvincia.Text.Trim();
                            items.Ciudad = TextBox5.Text.Trim();
                            items.Nacionalidad = cboNacionalidad.Text.Trim();
                            items.Ocupacion = cboOcupacionProfesion.Text.Trim();
                            items.ClaveOcupacion = cboOcupacionProfesionClave.Text.Trim();
                            items.DetalleOcupacion = TextBox8.Text.Trim();
                            items.IngresoMensual = TextBox9.Text.Trim();
                            items.TransaccionesAnualesAportaciones = TextBox10.Text.Trim();
                            items.TransaccionesAnualesRetiros = TextBox11.Text.Trim();
                            items.TransaccionesAportaciones = TextBox12.Text.Trim();
                            items.TransaccionesRetiros = TextBox13.Text.Trim();
                            items.PagoImpuestosExtranjero = DDL1.SelectedValue;
                            items.PagoImpuestosExtranjeroPais = ddlPagoExtrangero.SelectedValue;
                            items.NSS = TextBox15.Text.Trim();
                            items.DesempeñoDestacado = DDL2.SelectedValue;
                            items.RazonesContratacion = ddlNacionalidadExtrangera.SelectedValue;
                            items.NivelRiesgo = TextBox17.Text.Trim();
                            items.LimitarDivulgacion = DDL3.SelectedValue;
                            items.Tipodocumento = cboTipoDocumento.Text.Trim();
                            items.SubtipoDocumento = cboSubTipoDocumento.Text.Trim();
                            items.Referencia = TextBox18.Text.Trim();
                            items.FechaEmision = FechaInicial.ToString("dd/MM/yyyy");
                            items.FechaVigencia = FechaFinal.ToString("dd/MM/yyyy");
                            items.EntidadGubernamentalEmisora = cboEntidadGubernamentalEmisora.Text.Trim();
                            items.PaisEmisor = cboPaisEmisor.Text.Trim();
                            items.Contador = TextBox21.Text.Trim();
                            items.Eliminar = DDLEliminar.SelectedValue;
                            items.Id = Funciones.Nums.TextoAEntero(hfIdTramite.Value.ToString());
                            items.EstadoFinal = DDLEstadoFinal.SelectedValue;
                            items.Comentarios = DDLComentarios.SelectedValue;
                            items.idtramite = hfIdTramite.Value;
                            items.idmesa = hfIdMesa.Value.ToString();
                            items.idusuario = manejo_sesion.Usuarios.IdUsuario.ToString();
                            items.idstatusmesa = IdStatusMesa.ToString();
                            items.obspub = "";
                            items.obspri = txtObservacionesPrivadas.Text.Trim();
                            items.motivosrechazo = "";

                            string TablaCaptura = "";
                            switch (hfIdMesa.Value)
                            {
                                case "103":
                                    TablaCaptura = "Captura1";
                                    break;

                                case "104":
                                    TablaCaptura = "Captura2";
                                    break;

                                case "105":
                                    TablaCaptura = "Captura3";
                                    break;
                            }

                            //if (i.mdm.extraccion.GuardarCaptura(items))
                            if (i.mdm.captura2.Agregar(items, TablaCaptura))
                            {
                                //mensajes.MostrarMensaje(this, "Se guardaron los datos capturados exitosamente", "MapaGeneral.aspx");
                                mensajes.MostrarMensaje(this, "Se guardaron los datos capturados exitosamente", "TramiteProcesar.aspx?IdFlujo=" + hfIdFlujo.Value.ToString() + "&IdMesa=" + hfIdMesa.Value.ToString() + "");
                            }
                            else
                            {
                                lblMensajes.Text = "Existió un problema al tratar de guardar la captura, verifique datos.";
                            }

                        }
                    }
                    break;

                case "btnSelccionCompleta":
                    mensajes.MostrarMensaje(this, "Se ha presionado el botón de Sel completa");
                    break;
                case "btnPCI":
                    mensajes.MostrarMensaje(this, "Se ha presionado el botón de P C I");
                    break;
                case "btnHold":
                    mensajes.MostrarMensaje(this, "Se ha presionado el botón de Hold");
                    break;
                case "btnSuspender":
                    mensajes.MostrarMensaje(this, "Se ha presionado el botón de Rechazar");
                    break;
                case "btnRechazar":
                    mensajes.MostrarMensaje(this, "Se ha presionado el botón de Rechazar");
                    break;
                case "btnPausa":
                    mensajes.MostrarMensaje(this, "Se ha presionado el botón de Pausa de Trámite");
                    break;
                case "btnDetener":
                    mensajes.MostrarMensaje(this, "Se ha presionado el botón de Pausa de Usuario");
                    break;
            }
        }
        
        protected void CargaComentarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(DDLEstadoFinal.SelectedValue.ToString());
            i.catalogosmdm.Comentarios(ref DDLComentarios, Id);

            if (Id == 1)
            {
                DDLComentarios.SelectedValue = "-1";
            }
        }

        protected void LlenarCamposCaptura(int IdFlujo, int IdMesa, int IdTramite)
        {
            string obtenido = i.mdm.tramitemesa.AsignarTramite(IdMesa, manejo_sesion.Usuarios.IdUsuario, ref IdTramite);
            string[] obtenidos = obtenido.Split(':');
            if (obtenidos[0] == "KO")
                lblMensajes.Text = obtenidos[1].ToString();
            else
            {
                if (IdTramite == 0)
                {
                    mensajes.MostrarMensaje(this, "No existen trámites a procesar en la mesa...", "MapaGeneral.aspx");
                }
                else
                {
                    hfIdTramite.Value = IdTramite.ToString();
                    hfIdMesa.Value = IdMesa.ToString();
                    hfIdFlujo.Value = IdFlujo.ToString();

                    // Verificmaos si el Flujo es MDM y la Mesa es la de validación
                    if (IdFlujo == 4 && (IdMesa == 105 || IdMesa == 104) )
                    {
                        // Cargamos los datos de la Captura.
                        DataSet dsCaptura = null;
                        DataRow drCaptura = null;
                        DataRow drValidacion = null;
                        dsCaptura = i.mdm.extraccion.getCapturaValidacion(IdTramite);

                        if (IdMesa == 104)
                        {
                            drCaptura = dsCaptura.Tables[0].Rows[0];

                            TextBox1.Text = drCaptura["Numero"].ToString(); 
                            TextBox2.Text = drCaptura["Poliza"].ToString(); 
                            TextBox3.Text = drCaptura["GUID_"].ToString();

                            //cboLugarNaciomientoPais.SelectedIndex = int.Parse(drCaptura["PaisNacimiento"].ToString()); if (drValidacion["ValidacionCaptura"].ToString().Contains("[PaisNacimiento]")) { cboLugarNaciomientoPais.BackColor = Color.Red; cboLugarNaciomientoPais.ForeColor = Color.Black; } else { cboLugarNaciomientoPais.BackColor = Color.White; cboLugarNaciomientoPais.ForeColor = Color.Black; }
                            //cboLugarNaciomientoPais.Value = drCaptura["PaisNacimiento"].ToString();
                            cboLugarNaciomientoPais.Value = drCaptura["IdPais"].ToString();
                            cboLugarNacimientoProvincia.Value = drCaptura["IdEstadoNacimiento"].ToString(); 
                            TextBox5.Text = drCaptura["Ciudad"].ToString();
                            cboNacionalidad.Value = drCaptura["IdNacionalidad"].ToString(); 
                            cboOcupacionProfesion.Value = drCaptura["IdOcupacion"].ToString(); 
                            cboOcupacionProfesionClave.Value = drCaptura["IdClaveOcupacion"].ToString(); 
                            TextBox8.Text = drCaptura["DetalleOcupacion"].ToString(); 
                            TextBox9.Text = drCaptura["IngresoMensual"].ToString();
                            TextBox10.Text = drCaptura["TransaccionesAnualesAportaciones"].ToString();
                            TextBox11.Text = drCaptura["TransaccionesAnualesRetiros"].ToString(); 
                            TextBox12.Text = drCaptura["TransaccionesAportaciones"].ToString();
                            TextBox13.Text = drCaptura["TransaccionesRetiros"].ToString();
                            DDL1.SelectedValue = drCaptura["PagoImpuestosExtranjero"].ToString();
                            ddlPagoExtrangero.SelectedValue = drCaptura["PagoImpuestosExtranjeroPais"].ToString(); 
                            TextBox15.Text = drCaptura["NSS"].ToString();
                            DDL2.SelectedValue = drCaptura["DesempeñoDestacado"].ToString();
                            ddlNacionalidadExtrangera.SelectedValue = drCaptura["RazonesContratacion"].ToString();
                            TextBox17.Text = drCaptura["NivelRiesgo"].ToString();
                            DDL3.SelectedValue = drCaptura["LimitarDivulgacion"].ToString();
                            cboTipoDocumento.Value = drCaptura["IdTipodocumento"].ToString(); 
                            cboSubTipoDocumento.Value = drCaptura["IdSubtipoDocumento"].ToString();
                            TextBox18.Text = drCaptura["Referencia"].ToString();
                            dtFechaInicial.Text = drCaptura["FechaEmision"].ToString();
                            dtFechaFinal.Text = drCaptura["FechaVigencia"].ToString(); 
                            cboEntidadGubernamentalEmisora.Value = drCaptura["IdEntidadGubernamentalEmisora"].ToString();
                            cboPaisEmisor.Value = drCaptura["IdPaisEmisor"].ToString();
                            TextBox21.Text = drCaptura["Contador"].ToString();
                            DDLEliminar.SelectedValue = drCaptura["Eliminar"].ToString(); 
                            DDLEstadoFinal.SelectedValue = drCaptura["EstadoFinal"].ToString(); 
                            
                            if (drCaptura["EstadoFinal"].ToString() == "9")
                            {
                                DDLEstadoFinal.SelectedValue = "9";
                                i.catalogosmdm.Comentarios(ref DDLComentarios, 9);
                                DDLComentarios.SelectedValue = drCaptura["Comentarios"].ToString();
                            }
                        }
                        else
                        {
                            drValidacion = dsCaptura.Tables[2].Rows[0];
                            if (dsCaptura.Tables[1].Rows[0]["EstadoFinal"].ToString() == "8")
                            {
                                drCaptura = dsCaptura.Tables[0].Rows[0];
                            }
                            else
                            {
                                drCaptura = dsCaptura.Tables[1].Rows[0];
                            }

                            TextBox1.Text = drCaptura["Numero"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[Numero]")) { TextBox1.BackColor = Color.Red; TextBox1.ForeColor = Color.Black; } else { TextBox1.BackColor = Color.White; TextBox1.ForeColor = Color.Black; }
                            TextBox2.Text = drCaptura["Poliza"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[Poliza]")) { TextBox2.BackColor = Color.Red; TextBox2.ForeColor = Color.Black; } else { TextBox2.BackColor = Color.White; TextBox2.ForeColor = Color.Black; }
                            TextBox3.Text = drCaptura["GUID_"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[GUID_]")) { TextBox3.BackColor = Color.Red; TextBox3.ForeColor = Color.Black; } else { TextBox3.BackColor = Color.White; TextBox3.ForeColor = Color.Black; }

                            //cboLugarNaciomientoPais.SelectedIndex = int.Parse(drCaptura["PaisNacimiento"].ToString()); if (drValidacion["ValidacionCaptura"].ToString().Contains("[PaisNacimiento]")) { cboLugarNaciomientoPais.BackColor = Color.Red; cboLugarNaciomientoPais.ForeColor = Color.Black; } else { cboLugarNaciomientoPais.BackColor = Color.White; cboLugarNaciomientoPais.ForeColor = Color.Black; }
                            cboLugarNaciomientoPais.Value = drCaptura["IdPais"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[PaisNacimiento]")) { cboLugarNaciomientoPais.BackColor = Color.Red; cboLugarNaciomientoPais.ForeColor = Color.Black; } else { cboLugarNaciomientoPais.BackColor = Color.White; cboLugarNaciomientoPais.ForeColor = Color.Black; }
                            cboLugarNacimientoProvincia.Value = drCaptura["IdEstadoNacimiento"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[EstadoNacimiento]")) { cboLugarNacimientoProvincia.BackColor = Color.Red; cboLugarNacimientoProvincia.ForeColor = Color.Black; } else { cboLugarNacimientoProvincia.BackColor = Color.White; cboLugarNacimientoProvincia.ForeColor = Color.Black; }
                            TextBox5.Text = drCaptura["Ciudad"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[Ciudad]")) { TextBox5.BackColor = Color.Red; TextBox5.ForeColor = Color.Black; } else { TextBox5.BackColor = Color.White; TextBox5.ForeColor = Color.Black; }
                            cboNacionalidad.Value = drCaptura["IdNacionalidad"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[Nacionalidad]")) { cboNacionalidad.BackColor = Color.Red; cboNacionalidad.ForeColor = Color.Black; } else { cboNacionalidad.BackColor = Color.White; cboNacionalidad.ForeColor = Color.Black; }
                            cboOcupacionProfesion.Value = drCaptura["IdOcupacion"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[Ocupacion]")) { cboOcupacionProfesion.BackColor = Color.Red; cboOcupacionProfesion.ForeColor = Color.Black; } else { cboOcupacionProfesion.BackColor = Color.White; cboOcupacionProfesion.ForeColor = Color.Black; }
                            cboOcupacionProfesionClave.Value = drCaptura["IdClaveOcupacion"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[ClaveOcupacion]")) { cboOcupacionProfesionClave.BackColor = Color.Red; cboOcupacionProfesionClave.ForeColor = Color.Black; } else { cboOcupacionProfesionClave.BackColor = Color.White; cboOcupacionProfesionClave.ForeColor = Color.Black; }
                            TextBox8.Text = drCaptura["DetalleOcupacion"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[DetalleOcupacion]")) { TextBox8.BackColor = Color.Red; TextBox8.ForeColor = Color.Black; } else { TextBox8.BackColor = Color.White; TextBox8.ForeColor = Color.Black; }
                            TextBox9.Text = drCaptura["IngresoMensual"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[IngresoMensual]")) { TextBox9.BackColor = Color.Red; TextBox9.ForeColor = Color.Black; } else { TextBox9.BackColor = Color.White; TextBox9.ForeColor = Color.Black; }
                            TextBox10.Text = drCaptura["TransaccionesAnualesAportaciones"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[TransaccionesAnualesAportaciones]")) { TextBox10.BackColor = Color.Red; TextBox10.ForeColor = Color.Black; } else { TextBox10.BackColor = Color.White; TextBox10.ForeColor = Color.Black; }
                            TextBox11.Text = drCaptura["TransaccionesAnualesRetiros"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[TransaccionesAnualesRetiros]")) { TextBox11.BackColor = Color.Red; TextBox11.ForeColor = Color.Black; } else { TextBox11.BackColor = Color.White; TextBox11.ForeColor = Color.Black; }
                            TextBox12.Text = drCaptura["TransaccionesAportaciones"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[TransaccionesAportaciones]")) { TextBox12.BackColor = Color.Red; TextBox12.ForeColor = Color.Black; } else { TextBox12.BackColor = Color.White; TextBox12.ForeColor = Color.Black; }
                            TextBox13.Text = drCaptura["TransaccionesRetiros"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[TransaccionesRetiros]")) { TextBox13.BackColor = Color.Red; TextBox13.ForeColor = Color.Black; } else { TextBox13.BackColor = Color.White; TextBox13.ForeColor = Color.Black; }
                            DDL1.SelectedValue = drCaptura["PagoImpuestosExtranjero"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[PagoImpuestosExtranjero]")) { DDL1.BackColor = Color.Red; DDL1.ForeColor = Color.Black; } else { DDL1.BackColor = Color.White; DDL1.ForeColor = Color.Black; }
                            ddlPagoExtrangero.SelectedValue = drCaptura["PagoImpuestosExtranjeroPais"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[PagoImpuestosExtranjeroPais]")) { ddlPagoExtrangero.BackColor = Color.Red; ddlPagoExtrangero.ForeColor = Color.Black; } else { ddlPagoExtrangero.BackColor = Color.White; ddlPagoExtrangero.ForeColor = Color.Black; }
                            TextBox15.Text = drCaptura["NSS"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[NSS]")) { TextBox15.BackColor = Color.Red; TextBox15.ForeColor = Color.Black; } else { TextBox15.BackColor = Color.White; TextBox15.ForeColor = Color.Black; }
                            DDL2.SelectedValue = drCaptura["DesempeñoDestacado"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[DesempeñoDestacado]")) { DDL2.BackColor = Color.Red; DDL2.ForeColor = Color.Black; } else { DDL2.BackColor = Color.White; DDL2.ForeColor = Color.Black; }
                            ddlNacionalidadExtrangera.SelectedValue = drCaptura["RazonesContratacion"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[RazonesContratacion]")) { ddlNacionalidadExtrangera.BackColor = Color.Red; ddlNacionalidadExtrangera.ForeColor = Color.Black; } else { ddlNacionalidadExtrangera.BackColor = Color.White; ddlNacionalidadExtrangera.ForeColor = Color.Black; }
                            TextBox17.Text = drCaptura["NivelRiesgo"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[NivelRiesgo]")) { TextBox17.BackColor = Color.Red; TextBox17.ForeColor = Color.Black; } else { TextBox17.BackColor = Color.White; TextBox17.ForeColor = Color.Black; }
                            DDL3.SelectedValue = drCaptura["LimitarDivulgacion"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[LimitarDivulgacion]")) { DDL3.BackColor = Color.Red; DDL3.ForeColor = Color.Black; } else { DDL3.BackColor = Color.White; DDL3.ForeColor = Color.Black; }
                            cboTipoDocumento.Value = drCaptura["IdTipodocumento"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[Tipodocumento]")) { cboTipoDocumento.BackColor = Color.Red; cboTipoDocumento.ForeColor = Color.Black; } else { cboTipoDocumento.BackColor = Color.White; cboTipoDocumento.ForeColor = Color.Black; }
                            cboSubTipoDocumento.Value = drCaptura["IdSubtipoDocumento"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[SubtipoDocumento]")) { cboSubTipoDocumento.BackColor = Color.Red; cboSubTipoDocumento.ForeColor = Color.Black; } else { cboSubTipoDocumento.BackColor = Color.White; cboSubTipoDocumento.ForeColor = Color.Black; }
                            TextBox18.Text = drCaptura["Referencia"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[Referencia]")) { TextBox18.BackColor = Color.Red; TextBox18.ForeColor = Color.Black; } else { TextBox18.BackColor = Color.White; TextBox18.ForeColor = Color.Black; }
                            dtFechaInicial.Text = drCaptura["FechaEmision"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[FechaEmision]")) { dtFechaInicial.BackColor = Color.Red; dtFechaInicial.ForeColor = Color.Black; } else { dtFechaInicial.BackColor = Color.White; dtFechaInicial.ForeColor = Color.Black; }
                            dtFechaFinal.Text = drCaptura["FechaVigencia"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[FechaVigencia]")) { dtFechaFinal.BackColor = Color.Red; dtFechaFinal.ForeColor = Color.Black; } else { dtFechaFinal.BackColor = Color.White; dtFechaFinal.ForeColor = Color.Black; }
                            cboEntidadGubernamentalEmisora.Value = drCaptura["IdEntidadGubernamentalEmisora"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[EntidadGubernamentalEmisora]")) { cboEntidadGubernamentalEmisora.BackColor = Color.Red; cboEntidadGubernamentalEmisora.ForeColor = Color.Black; } else { cboEntidadGubernamentalEmisora.BackColor = Color.White; cboEntidadGubernamentalEmisora.ForeColor = Color.Black; }
                            cboPaisEmisor.Value = drCaptura["IdPaisEmisor"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[PaisEmisor]")) { cboPaisEmisor.BackColor = Color.Red; cboPaisEmisor.ForeColor = Color.Black; } else { cboPaisEmisor.BackColor = Color.White; cboPaisEmisor.ForeColor = Color.Black; }
                            TextBox21.Text = drCaptura["Contador"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[Contador]")) { TextBox21.BackColor = Color.Red; TextBox21.ForeColor = Color.Black; } else { TextBox21.BackColor = Color.White; TextBox21.ForeColor = Color.Black; }
                            DDLEliminar.SelectedValue = drCaptura["Eliminar"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[Eliminar]")) { DDLEliminar.BackColor = Color.Red; DDLEliminar.ForeColor = Color.Black; } else { DDLEliminar.BackColor = Color.White; DDLEliminar.ForeColor = Color.Black; }
                            DDLEstadoFinal.SelectedValue = drCaptura["EstadoFinal"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[EstadoFinal]")) { DDLEstadoFinal.BackColor = Color.Red; DDLEstadoFinal.ForeColor = Color.Black; } else { DDLEstadoFinal.BackColor = Color.White; DDLEstadoFinal.ForeColor = Color.Black; }

                            if (drCaptura["EstadoFinal"].ToString() == "9")
                            {
                                DDLEstadoFinal.SelectedValue = "9";
                                i.catalogosmdm.Comentarios(ref DDLComentarios, 9);
                            }

                            DDLComentarios.SelectedValue = drCaptura["Comentarios"].ToString(); if (drValidacion["ValidacionCaptura"].ToString().Contains("[Comentarios]")) { DDLComentarios.BackColor = Color.Red; DDLComentarios.ForeColor = Color.Black; } else { DDLComentarios.BackColor = Color.White; DDLComentarios.ForeColor = Color.Black; }
                        }


                        dsCaptura = null;
                        drCaptura = null;
                        drValidacion = null;
                    }
                    else
                    {
                        i.mdm.trmaitedetmdm.SeleccionarPorId(IdTramite, ref TextBox1, ref TextBox2, ref TextBox3);

                        // Llenamos Valores Default.
                        cboLugarNaciomientoPais.Value = "152";
                        cboNacionalidad.Value = "152";
                        DDL1.SelectedValue = "2";
                        ddlPagoExtrangero.SelectedValue = "2";
                        DDL2.SelectedValue = "2";
                        ddlNacionalidadExtrangera.SelectedValue = "-1";
                        DDL3.SelectedValue = "2";
                        cboTipoDocumento.Value = "2";
                        cboPaisEmisor.Value = "152";
                    }
                }
            }
        }
    }
}