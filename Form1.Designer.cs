namespace CarDetect

{
    partial class FormForDetectingCars
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForDetectingCars));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemForChooseFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemForOpenDirections = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonForActivateDetecting = new System.Windows.Forms.ToolStripButton();
            this.pictureBoxForImageOrVideo = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBoxForResult = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForImageOrVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForResult)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemForChooseFile});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // ToolStripMenuItemForChooseFile
            // 
            this.ToolStripMenuItemForChooseFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemForOpenDirections});
            this.ToolStripMenuItemForChooseFile.Name = "ToolStripMenuItemForChooseFile";
            resources.ApplyResources(this.ToolStripMenuItemForChooseFile, "ToolStripMenuItemForChooseFile");
            this.ToolStripMenuItemForChooseFile.Click += new System.EventHandler(this.ToolStripMenuItemForChooseFile_Click);
            // 
            // ToolStripMenuItemForOpenDirections
            // 
            this.ToolStripMenuItemForOpenDirections.Name = "ToolStripMenuItemForOpenDirections";
            resources.ApplyResources(this.ToolStripMenuItemForOpenDirections, "ToolStripMenuItemForOpenDirections");
            this.ToolStripMenuItemForOpenDirections.Click += new System.EventHandler(this.открытьToolStripMenuMenuItem_click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonForActivateDetecting});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripButtonForActivateDetecting
            // 
            this.toolStripButtonForActivateDetecting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButtonForActivateDetecting, "toolStripButtonForActivateDetecting");
            this.toolStripButtonForActivateDetecting.Name = "toolStripButtonForActivateDetecting";
            this.toolStripButtonForActivateDetecting.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // pictureBoxForImageOrVideo
            // 
            resources.ApplyResources(this.pictureBoxForImageOrVideo, "pictureBoxForImageOrVideo");
            this.pictureBoxForImageOrVideo.Name = "pictureBoxForImageOrVideo";
            this.pictureBoxForImageOrVideo.TabStop = false;
            this.pictureBoxForImageOrVideo.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // richTextBox
            // 
            resources.ApplyResources(this.richTextBox, "richTextBox");
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog2, "openFileDialog2");
            // 
            // pictureBoxForResult
            // 
            resources.ApplyResources(this.pictureBoxForResult, "pictureBoxForResult");
            this.pictureBoxForResult.Name = "pictureBoxForResult";
            this.pictureBoxForResult.TabStop = false;
            // 
            // FormForDetectingCars
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxForResult);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.pictureBoxForImageOrVideo);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormForDetectingCars";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForImageOrVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemForChooseFile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemForOpenDirections;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonForActivateDetecting;
        private System.Windows.Forms.PictureBox pictureBoxForImageOrVideo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.PictureBox pictureBoxForResult;
    }
}

