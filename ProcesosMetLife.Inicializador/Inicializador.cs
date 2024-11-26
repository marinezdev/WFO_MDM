namespace ProcesosMetLife.Negocio.Inicializador
{
    public class Inicializador
    {
        /// <summary>
        /// Instancia de procesos de negocio de MDM
        /// </summary>
        public Procesos.MDM.MDM mdm;
        /// <summary>
        /// Instancia de Procesos de Negocio de Administración del Sistema
        /// </summary>
        public Sistema.Sistema administracion;

        //Catalogos
        /// <summary>
        /// Catalogos Genericos
        /// </summary>
        public Catalogos.Catalogo cats;

        public ProcesosMetLifel.Negocio.Catalogos.CatalogosMDM catalogosmdm;

        public Inicializador()
        {
            //Catalogos
            cats = new Catalogos.Catalogo();
            catalogosmdm = new ProcesosMetLifel.Negocio.Catalogos.CatalogosMDM();

            mdm = new Procesos.MDM.MDM();

            administracion = new Sistema.Sistema();
        }


    }
}
