using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MiceMultiplexer
{
  public partial class MouseDummy : Form
  {
    Image m_CursorLeft;
    Image m_CursorRight;

    public Image CursorLeft
    {
      set
      {
        m_CursorLeft = value;
      }
    }
    public Image CursorRight
    {
      set
      {
        m_CursorRight = value;
      }
    }

    public MouseDummy()
    {
      InitializeComponent();
    }

    public void ShowCursor(bool isLeft)
    {
      this.Visible = true;
      if (isLeft)
      {
        m_pbMouse.Image = m_CursorLeft;
      }
      else
      {
        m_pbMouse.Image = m_CursorRight;
      }
    }
  }
}