namespace EmployeeManager
{
    partial class EmployeeManager
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHire = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHire
            // 
            this.btnHire.Location = new System.Drawing.Point(100, 524);
            this.btnHire.Name = "btnHire";
            this.btnHire.Size = new System.Drawing.Size(101, 39);
            this.btnHire.TabIndex = 0;
            this.btnHire.Text = "Hire Employee";
            this.btnHire.UseVisualStyleBackColor = true;
            // 
            // EmployeeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1077, 575);
            this.Controls.Add(this.btnHire);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "EmployeeManager";
            this.Text = "E-Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHire;
    }
}

