namespace ServicioRecordatorio
{
    partial class recuerdo
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tiempo = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.tiempo)).BeginInit();
            // 
            // tiempo
            // 
            this.tiempo.Enabled = true;
            this.tiempo.Interval = 60000D;
            this.tiempo.Elapsed += new System.Timers.ElapsedEventHandler(this.tiempo_Elapsed);
            // 
            // recuerdo
            // 
            this.ServiceName = "Service1";
            ((System.ComponentModel.ISupportInitialize)(this.tiempo)).EndInit();

        }

        #endregion
        private System.Timers.Timer tiempo;
    }
}
