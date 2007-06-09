using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using RawInputSharp;
using JCMLib;

namespace MiceMultiplexer
{
  public partial class ControlForm : Form
  {
    private RawMouseInput m_rmInput = null;
    protected const int WM_INPUT = 0x00FF;
    private NotifyIconEx m_niTaskIcon;

    private MouseControler m_MouseControler;

    public ControlForm()
    {
      InitializeComponent();

      this.m_niTaskIcon = new NotifyIconEx();
      // 
      // m_niTaskIcon
      // 
      this.m_niTaskIcon.Icon = this.Icon;
      this.m_niTaskIcon.Text = "MiceMultiplexer";
      this.m_niTaskIcon.Visible = true;
      this.m_niTaskIcon.InputHandlerEvent += new InputHandler(m_niTaskIcon_InputHandlerEvent);

      //create and init
      m_rmInput = new RawMouseInput();
      m_rmInput.RegisterForWM_INPUT(this.Handle);
      //m_rmInput.RegisterForWM_INPUT(this.m_niTaskIcon.Handle);

      m_MouseControler = new MouseControler(m_rmInput);
    }

    void m_niTaskIcon_InputHandlerEvent(Message msg)
    {
      m_rmInput.UpdateRawMouse(msg.LParam);
      m_MouseControler.MouseAction();
    }

    protected override void WndProc(ref Message m)
    {
      switch (m.Msg)
      {
        case WM_INPUT:
          //read in new mouse values.
          m_rmInput.UpdateRawMouse(m.LParam);

          m_MouseControler.MouseAction();
          break;
      }
      base.WndProc(ref m);
    }
  }
}