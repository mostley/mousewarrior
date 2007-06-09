namespace MiceMultiplexer
{
  partial class MouseDummy
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.m_CursorList = new System.Windows.Forms.ImageList(this.components);
      this.m_pbMouse = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.m_pbMouse)).BeginInit();
      this.SuspendLayout();
      // 
      // m_CursorList
      // 
      this.m_CursorList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
      this.m_CursorList.ImageSize = new System.Drawing.Size(16, 16);
      this.m_CursorList.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // m_pbMouse
      // 
      this.m_pbMouse.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_pbMouse.Location = new System.Drawing.Point(0, 0);
      this.m_pbMouse.Name = "m_pbMouse";
      this.m_pbMouse.Size = new System.Drawing.Size(40, 40);
      this.m_pbMouse.TabIndex = 0;
      this.m_pbMouse.TabStop = false;
      // 
      // MouseDummy
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Magenta;
      this.ClientSize = new System.Drawing.Size(40, 40);
      this.Controls.Add(this.m_pbMouse);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "MouseDummy";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.TopMost = true;
      this.TransparencyKey = System.Drawing.Color.Magenta;
      ((System.ComponentModel.ISupportInitialize)(this.m_pbMouse)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ImageList m_CursorList;
    private System.Windows.Forms.PictureBox m_pbMouse;
  }
}