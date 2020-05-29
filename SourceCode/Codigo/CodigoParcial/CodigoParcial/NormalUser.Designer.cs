using System.ComponentModel;

namespace CodigoParcial
{
    partial class NormalUser
    {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources =
            new System.ComponentModel.ComponentResourceManager(typeof(Administrator));
        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        this.label1 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
        this.SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
        this.tableLayoutPanel1.ColumnCount = 4;
        this.tableLayoutPanel1.ColumnStyles.Add(
            new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
        this.tableLayoutPanel1.ColumnStyles.Add(
            new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
        this.tableLayoutPanel1.ColumnStyles.Add(
            new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
        this.tableLayoutPanel1.ColumnStyles.Add(
            new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
        this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
        this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
        this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.RowCount = 4;
        this.tableLayoutPanel1.RowStyles.Add(
            new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        this.tableLayoutPanel1.RowStyles.Add(
            new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        this.tableLayoutPanel1.RowStyles.Add(
            new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        this.tableLayoutPanel1.RowStyles.Add(
            new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
        this.tableLayoutPanel1.TabIndex = 0;
        // 
        // label1
        // 
        this.label1.BackColor = System.Drawing.Color.White;
        this.tableLayoutPanel1.SetColumnSpan(this.label1, 4);
        this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.label1.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular,
            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
        this.label1.ForeColor =
            System.Drawing.Color.FromArgb(((int) (((byte) (53)))), ((int) (((byte) (27)))), ((int) (((byte) (89)))));
        this.label1.Location = new System.Drawing.Point(3, 60);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(194, 40);
        this.label1.TabIndex = 5;
        this.label1.Text = "Agregar nuevo usuario";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label3
        // 
        this.tableLayoutPanel1.SetColumnSpan(this.label3, 4);
        this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.label3.Font = new System.Drawing.Font("Candara", 24F, System.Drawing.FontStyle.Bold,
            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
        this.label3.ForeColor =
            System.Drawing.Color.FromArgb(((int) (((byte) (53)))), ((int) (((byte) (27)))), ((int) (((byte) (89)))));
        this.label3.Location = new System.Drawing.Point(3, 20);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(194, 20);
        this.label3.TabIndex = 3;
        this.label3.Text = "Lista de usuarios";
        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pictureBox1
        // 
        this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pictureBox1.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox1.Image")));
        this.pictureBox1.Location = new System.Drawing.Point(3, 3);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(194, 68);
        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
        this.pictureBox1.TabIndex = 0;
        this.pictureBox1.TabStop = false;
        // 
        // Administrator
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Name = "Administrator";
        this.Size = new System.Drawing.Size(528, 680);
        this.tableLayoutPanel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}