namespace WindowsFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearchTitle;
        private System.Windows.Forms.Button btnSearchAuthor;
        private System.Windows.Forms.Button btnShowAllBooks;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExportToDocx;
        private System.Windows.Forms.Button btnExportToPdf;
        private System.Windows.Forms.Button btnImportFromPdf;
        private System.Windows.Forms.Button btnImportFromDocx;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnOpenBook;
        private System.Windows.Forms.Button btnGenerateQRCode;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.ListBox lstBooks;
        private System.Windows.Forms.PictureBox pictureBoxQRCode;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.GroupBox groupBoxBookDetails;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.GroupBox groupBoxImportExport;
        private System.Windows.Forms.GroupBox groupBoxQRCode;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearchTitle = new System.Windows.Forms.Button();
            this.btnSearchAuthor = new System.Windows.Forms.Button();
            this.btnShowAllBooks = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExportToDocx = new System.Windows.Forms.Button();
            this.btnExportToPdf = new System.Windows.Forms.Button();
            this.btnImportFromPdf = new System.Windows.Forms.Button();
            this.btnImportFromDocx = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnOpenBook = new System.Windows.Forms.Button();
            this.btnGenerateQRCode = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lstBooks = new System.Windows.Forms.ListBox();
            this.pictureBoxQRCode = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.groupBoxBookDetails = new System.Windows.Forms.GroupBox();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.groupBoxImportExport = new System.Windows.Forms.GroupBox();
            this.groupBoxQRCode = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRCode)).BeginInit();
            this.groupBoxBookDetails.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            this.groupBoxImportExport.SuspendLayout();
            this.groupBoxQRCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(103, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearchTitle
            // 
            this.btnSearchTitle.Location = new System.Drawing.Point(198, 19);
            this.btnSearchTitle.Name = "btnSearchTitle";
            this.btnSearchTitle.Size = new System.Drawing.Size(143, 23);
            this.btnSearchTitle.TabIndex = 2;
            this.btnSearchTitle.Text = "Поиск по названию";
            this.btnSearchTitle.UseVisualStyleBackColor = true;
            this.btnSearchTitle.Click += new System.EventHandler(this.btnSearchTitle_Click);
            // 
            // btnSearchAuthor
            // 
            this.btnSearchAuthor.Location = new System.Drawing.Point(347, 20);
            this.btnSearchAuthor.Name = "btnSearchAuthor";
            this.btnSearchAuthor.Size = new System.Drawing.Size(156, 23);
            this.btnSearchAuthor.TabIndex = 3;
            this.btnSearchAuthor.Text = "Поиск по автору";
            this.btnSearchAuthor.UseVisualStyleBackColor = true;
            this.btnSearchAuthor.Click += new System.EventHandler(this.btnSearchAuthor_Click);
            // 
            // btnShowAllBooks
            // 
            this.btnShowAllBooks.Location = new System.Drawing.Point(509, 20);
            this.btnShowAllBooks.Name = "btnShowAllBooks";
            this.btnShowAllBooks.Size = new System.Drawing.Size(152, 23);
            this.btnShowAllBooks.TabIndex = 4;
            this.btnShowAllBooks.Text = "Показать все книги";
            this.btnShowAllBooks.UseVisualStyleBackColor = true;
            this.btnShowAllBooks.Click += new System.EventHandler(this.btnShowAllBooks_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(12, 19);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(132, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Экспорт в JSON";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(150, 19);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(123, 23);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "Импорт из JSON";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExportToDocx
            // 
            this.btnExportToDocx.Location = new System.Drawing.Point(12, 48);
            this.btnExportToDocx.Name = "btnExportToDocx";
            this.btnExportToDocx.Size = new System.Drawing.Size(132, 23);
            this.btnExportToDocx.TabIndex = 7;
            this.btnExportToDocx.Text = "Экспорт в DOCX";
            this.btnExportToDocx.UseVisualStyleBackColor = true;
            this.btnExportToDocx.Click += new System.EventHandler(this.btnExportToDocx_Click);
            // 
            // btnExportToPdf
            // 
            this.btnExportToPdf.Location = new System.Drawing.Point(12, 75);
            this.btnExportToPdf.Name = "btnExportToPdf";
            this.btnExportToPdf.Size = new System.Drawing.Size(132, 23);
            this.btnExportToPdf.TabIndex = 8;
            this.btnExportToPdf.Text = "Экспорт в PDF";
            this.btnExportToPdf.UseVisualStyleBackColor = true;
            this.btnExportToPdf.Click += new System.EventHandler(this.btnExportToPdf_Click);
            // 
            // btnImportFromPdf
            // 
            this.btnImportFromPdf.Location = new System.Drawing.Point(150, 48);
            this.btnImportFromPdf.Name = "btnImportFromPdf";
            this.btnImportFromPdf.Size = new System.Drawing.Size(123, 23);
            this.btnImportFromPdf.TabIndex = 9;
            this.btnImportFromPdf.Text = "Импорт из PDF";
            this.btnImportFromPdf.UseVisualStyleBackColor = true;
            this.btnImportFromPdf.Click += new System.EventHandler(this.btnImportFromPdf_Click);
            // 
            // btnImportFromDocx
            // 
            this.btnImportFromDocx.Location = new System.Drawing.Point(150, 75);
            this.btnImportFromDocx.Name = "btnImportFromDocx";
            this.btnImportFromDocx.Size = new System.Drawing.Size(123, 23);
            this.btnImportFromDocx.TabIndex = 10;
            this.btnImportFromDocx.Text = "Импорт из DOCX";
            this.btnImportFromDocx.UseVisualStyleBackColor = true;
            this.btnImportFromDocx.Click += new System.EventHandler(this.btnImportFromDocx_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(279, 19);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(115, 74);
            this.btnConvert.TabIndex = 11;
            this.btnConvert.Text = "Конвертировать";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnOpenBook
            // 
            this.btnOpenBook.Location = new System.Drawing.Point(400, 19);
            this.btnOpenBook.Name = "btnOpenBook";
            this.btnOpenBook.Size = new System.Drawing.Size(103, 74);
            this.btnOpenBook.TabIndex = 12;
            this.btnOpenBook.Text = "Открыть книгу";
            this.btnOpenBook.UseVisualStyleBackColor = true;
            this.btnOpenBook.Click += new System.EventHandler(this.btnOpenBook_Click);
            // 
            // btnGenerateQRCode
            // 
            this.btnGenerateQRCode.Location = new System.Drawing.Point(12, 19);
            this.btnGenerateQRCode.Name = "btnGenerateQRCode";
            this.btnGenerateQRCode.Size = new System.Drawing.Size(122, 23);
            this.btnGenerateQRCode.TabIndex = 13;
            this.btnGenerateQRCode.Text = "Сгенерировать QR";
            this.btnGenerateQRCode.UseVisualStyleBackColor = true;
            this.btnGenerateQRCode.Click += new System.EventHandler(this.btnGenerateQRCode_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(10, 76);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 20);
            this.txtTitle.TabIndex = 14;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(10, 115);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(200, 20);
            this.txtAuthor.TabIndex = 15;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(10, 154);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(200, 20);
            this.txtYear.TabIndex = 16;
            // 
            // lstBooks
            // 
            this.lstBooks.FormattingEnabled = true;
            this.lstBooks.Location = new System.Drawing.Point(24, 289);
            this.lstBooks.Name = "lstBooks";
            this.lstBooks.Size = new System.Drawing.Size(658, 199);
            this.lstBooks.TabIndex = 17;
            // 
            // pictureBoxQRCode
            // 
            this.pictureBoxQRCode.Location = new System.Drawing.Point(6, 48);
            this.pictureBoxQRCode.Name = "pictureBoxQRCode";
            this.pictureBoxQRCode.Size = new System.Drawing.Size(285, 275);
            this.pictureBoxQRCode.TabIndex = 18;
            this.pictureBoxQRCode.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(7, 58);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(57, 13);
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "Название";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(9, 99);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(37, 13);
            this.lblAuthor.TabIndex = 20;
            this.lblAuthor.Text = "Автор";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(9, 138);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(25, 13);
            this.lblYear.TabIndex = 21;
            this.lblYear.Text = "Год";
            // 
            // groupBoxBookDetails
            // 
            this.groupBoxBookDetails.Controls.Add(this.lblYear);
            this.groupBoxBookDetails.Controls.Add(this.lblAuthor);
            this.groupBoxBookDetails.Controls.Add(this.lblTitle);
            this.groupBoxBookDetails.Controls.Add(this.txtYear);
            this.groupBoxBookDetails.Controls.Add(this.txtAuthor);
            this.groupBoxBookDetails.Controls.Add(this.txtTitle);
            this.groupBoxBookDetails.Location = new System.Drawing.Point(14, 12);
            this.groupBoxBookDetails.Name = "groupBoxBookDetails";
            this.groupBoxBookDetails.Size = new System.Drawing.Size(220, 180);
            this.groupBoxBookDetails.TabIndex = 22;
            this.groupBoxBookDetails.TabStop = false;
            this.groupBoxBookDetails.Text = "Детали книги";
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Controls.Add(this.btnShowAllBooks);
            this.groupBoxActions.Controls.Add(this.btnSearchAuthor);
            this.groupBoxActions.Controls.Add(this.btnSearchTitle);
            this.groupBoxActions.Controls.Add(this.btnDelete);
            this.groupBoxActions.Controls.Add(this.btnAdd);
            this.groupBoxActions.Location = new System.Drawing.Point(240, 12);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(667, 52);
            this.groupBoxActions.TabIndex = 23;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Действия";
            this.groupBoxActions.Enter += new System.EventHandler(this.groupBoxActions_Enter);
            // 
            // groupBoxImportExport
            // 
            this.groupBoxImportExport.Controls.Add(this.btnOpenBook);
            this.groupBoxImportExport.Controls.Add(this.btnConvert);
            this.groupBoxImportExport.Controls.Add(this.btnImportFromDocx);
            this.groupBoxImportExport.Controls.Add(this.btnImportFromPdf);
            this.groupBoxImportExport.Controls.Add(this.btnExportToPdf);
            this.groupBoxImportExport.Controls.Add(this.btnExportToDocx);
            this.groupBoxImportExport.Controls.Add(this.btnImport);
            this.groupBoxImportExport.Controls.Add(this.btnExport);
            this.groupBoxImportExport.Location = new System.Drawing.Point(240, 70);
            this.groupBoxImportExport.Name = "groupBoxImportExport";
            this.groupBoxImportExport.Size = new System.Drawing.Size(667, 116);
            this.groupBoxImportExport.TabIndex = 24;
            this.groupBoxImportExport.TabStop = false;
            this.groupBoxImportExport.Text = "Импорт/Экспорт";
            // 
            // groupBoxQRCode
            // 
            this.groupBoxQRCode.Controls.Add(this.pictureBoxQRCode);
            this.groupBoxQRCode.Controls.Add(this.btnGenerateQRCode);
            this.groupBoxQRCode.Location = new System.Drawing.Point(688, 224);
            this.groupBoxQRCode.Name = "groupBoxQRCode";
            this.groupBoxQRCode.Size = new System.Drawing.Size(297, 329);
            this.groupBoxQRCode.TabIndex = 25;
            this.groupBoxQRCode.TabStop = false;
            this.groupBoxQRCode.Text = "QR-код";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1116, 565);
            this.Controls.Add(this.groupBoxQRCode);
            this.Controls.Add(this.groupBoxImportExport);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxBookDetails);
            this.Controls.Add(this.lstBooks);
            this.Name = "Form1";
            this.Text = "Управление книгами";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRCode)).EndInit();
            this.groupBoxBookDetails.ResumeLayout(false);
            this.groupBoxBookDetails.PerformLayout();
            this.groupBoxActions.ResumeLayout(false);
            this.groupBoxImportExport.ResumeLayout(false);
            this.groupBoxQRCode.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
