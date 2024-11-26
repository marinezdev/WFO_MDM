using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProcesosMetLife.Procesos.MDM
{
    public partial class Captura : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            mensajes.TituloAplicacionEnUso(this, "MDM");

            if (!IsPostBack)
            {
                //Obtener los datos del tramite 
                LlenarCamposCaptura(Request["Id1"]);

                Pais(ref DDLLugarNacimientoPais);
                OcupacionProfesion(ref DDLOcupacionProfesion);
                Preguntas(ref DDL1);
                Preguntas(ref DDL2);
                Preguntas(ref DDL3);
                TipoDocumento(ref DDLTipoDocumento);
                SubTipoDocumento(ref DDLSubTipoDocumento);
                EntidadGubernamentalEmisora(ref DDLEntidadGubernamentalEmisora);
                Pais(ref DDLPaisEmisor);
                Preguntas(ref DDLEliminar);
                Botones();
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
            btnAceptar.Visible = true;
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
                    //Validar la captura
                    if (DDLLugarNacimientoPais.SelectedIndex == 0 ||
                        TextBox4.Text == "" ||
                        TextBox5.Text == "" ||
                        TextBox6.Text == "" ||
                        DDLOcupacionProfesion.SelectedIndex == 0 ||
                        TextBox7.Text == "" ||
                        TextBox8.Text == "" ||
                        TextBox9.Text == "" ||
                        TextBox10.Text == "" ||
                        TextBox11.Text == "" ||
                        TextBox12.Text == "" ||
                        TextBox13.Text == "" ||
                        DDL1.SelectedIndex == 0 ||
                        TextBox14.Text == "" ||
                        TextBox15.Text == "" ||
                        DDL2.SelectedIndex == 0 ||
                        TextBox16.Text == "" ||
                        TextBox17.Text == "" ||
                        DDL3.SelectedIndex == 0 ||
                        DDLTipoDocumento.SelectedIndex == 0 ||
                        DDLSubTipoDocumento.SelectedIndex == 0 ||
                        TextBox18.Text == "" ||
                        TextBox19.Text == "" ||
                        TextBox20.Text == "" ||
                        DDLEntidadGubernamentalEmisora.SelectedIndex == 0 ||
                        DDLPaisEmisor.SelectedIndex == 0 ||
                        TextBox21.Text == "" ||
                        DDLEliminar.SelectedIndex == 0)
                    {
                        mensajes.MostrarMensaje(this, "Debe capturar toda la información.");
                    }

                    //guardar la captura
                    Propiedades.Extraccion_MDM items = new Propiedades.Extraccion_MDM();
                    items.PaisNacimiento = DDLLugarNacimientoPais.SelectedValue;
                    items.EstadoNacimiento = TextBox4.Text;
                    items.Ciudad = TextBox5.Text;
                    items.Nacionalidad= TextBox6.Text;
                    items.Ocupacion = DDLOcupacionProfesion.SelectedValue;
                    items.ClaveOcupacion= TextBox7.Text;
                    items.DetalleOcupacion= TextBox8.Text;
                    items.IngresoMensual= TextBox9.Text;
                    items.TransaccionesAnualesAportaciones= TextBox10.Text;
                    items.TransaccionesAnualesRetiros= TextBox11.Text;
                    items.TransaccionesAportaciones= TextBox12.Text;
                    items.TransaccionesRetiros= TextBox13.Text;
                    items.PagoImpuestosExtranjero= DDL1.SelectedValue;
                    items.PagoImpuestosExtranjeroPais = TextBox14.Text;
                    items.NSS= TextBox15.Text;
                    items.DesempeñoDestacado = DDL2.SelectedValue;
                    items.RazonesContratacion= TextBox16.Text;
                    items.NivelRiesgo= TextBox17.Text;
                    items.LimitarDivulgacion = DDL3.SelectedValue;
                    items.Tipodocumento = DDLTipoDocumento.SelectedValue;
                    items.SubtipoDocumento = DDLSubTipoDocumento.SelectedValue;
                    items.Referencia= TextBox18.Text;
                    items.FechaEmision= TextBox19.Text;
                    items.FechaVigencia= TextBox20.Text;
                    items.EntidadGubernamentalEmisora = DDLEntidadGubernamentalEmisora.SelectedValue;
                    items.PaisEmisor = DDLPaisEmisor.SelectedValue;
                    items.Contador= TextBox21.Text;
                    items.Eliminar = DDLEliminar.SelectedValue;
                    items.Id = Funciones.Nums.TextoAEntero(Request["Id1"].ToString());

                    items.idtramite = hfIdTramite.Value;
                    items.idmesa = Request["Id3"].ToString();
                    items.idusuario = manejo_sesion.Usuarios.IdUsuario.ToString();
                    items.idstatusmesa = Request["Id4"].ToString();
                    items.obspub = "";
                    items.obspri = txtObservacionesPrivadas.Text;
                    items.motivosrechazo = "";
                    if (i.mdm.extraccion.GuardarCaptura(items))
                        mensajes.MostrarMensaje(this, "Se guardaron los datos capturados exitosamente", "BuscarTramite.aspx");
                    else
                    {
                        lblMensajes.Text = "Ha habido un error al tratar de guardar la captura, verifique datos.";
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

        protected void LlenarCamposCaptura(string idtramite)
        {
            //string obtenido = i.mdm.tramitemesa.AsignarTramite(Request["id3"], manejo_sesion.Usuarios.IdUsuario.ToString(), idtramite);
            //string[] obtenidos = obtenido.Split(':');
            //if (obtenidos[0] == "KO")
            //    lblMensajes.Text = obtenidos[1].ToString();
            //else
            //{
            //    hfIdTramite.Value = Request["id2"];
            //    i.mdm.trmaitedetmdm.SeleccionarPorId(idtramite, ref TextBox1, ref TextBox2, ref TextBox3);
            //}
        }

    }

}