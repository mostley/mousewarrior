using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

using RawInputSharp;
using System.Windows.Forms;
using System.IO;

namespace MiceMultiplexer
{
  public class MouseControler
  {
    private RawMouseInput m_rmInput = null;

    private Point m_SecondMousePos;
    private Point m_FirstMousePos;
    private bool m_bIsFirstMouse = true;

    private List<string> m_sOutputData;

    private MouseDummy m_fDummy;
    private Cursor m_cLeftCursor;
    private const string m_sLeftCursorFile = "arrow.cur";

    public MouseControler(RawMouseInput rminput)
    {
      m_rmInput = rminput;

      m_FirstMousePos = new Point(-1, -1);
      m_SecondMousePos = new Point(-1, -1);

      m_fDummy = new MouseDummy();
      m_fDummy.Visible = false;

      if (File.Exists(m_sLeftCursorFile))
      {
        m_cLeftCursor = new Cursor(m_sLeftCursorFile);
      }
      else
      {
        m_cLeftCursor = Cursors.Arrow;
      }

      Image cursorImage = new Bitmap(40, 40);
      Graphics g = Graphics.FromImage(cursorImage);
      m_cLeftCursor.Draw(g, new Rectangle(Point.Empty, cursorImage.Size));
      m_fDummy.CursorLeft = cursorImage;

      g.Clear(Color.Transparent);
      Cursors.Arrow.Draw(g, new Rectangle(Point.Empty, cursorImage.Size));
      m_fDummy.CursorRight = cursorImage;

      MouseAction();
    }

    public void MouseAction()
    {
      if (m_rmInput.Mice.Count > 1)
      {
        RawMouse mouse1 = (RawMouse)m_rmInput.Mice[0];
        RawMouse mouse2 = (RawMouse)m_rmInput.Mice[1];

        int dx1 = mouse1.XDelta;
        int dy1 = mouse1.YDelta;
        int dx2 = mouse2.XDelta;
        int dy2 = mouse2.YDelta;

        //Print(mouse1, mouse2, dx1, dy1, dx2, dy2);

        if (m_FirstMousePos.X != -1 || m_FirstMousePos.Y != -1)
        {
          UpdateFirstMouse(dx1, dy1);
        }
        else
        {
          m_FirstMousePos = Cursor.Position;
        }

        if (m_SecondMousePos.X != -1 || m_SecondMousePos.Y != -1)
        {
          UpdateSecondMouse(dx2, dy2);
        }
        else
        {
          m_SecondMousePos = Cursor.Position;
        }

        if (m_bIsFirstMouse)
        {
          Cursor.Current = Cursors.Arrow;
        }
        else
        {
          Cursor.Current = m_cLeftCursor;
        }
      }
    }

    private void UpdateFirstMouse(int dx, int dy)
    {
      if (HasMovement(dx, dy))
      {
        m_bIsFirstMouse = true;

        ShowDummy(m_SecondMousePos, true);

        Cursor.Position = m_FirstMousePos;
        m_FirstMousePos.Offset(dx, dy);
      }
    }

    private void UpdateSecondMouse(int dx, int dy)
    {
      if (HasMovement(dx, dy))
      {
        m_bIsFirstMouse = false;

        ShowDummy(m_FirstMousePos, false);

        Cursor.Position = m_SecondMousePos;
        m_SecondMousePos.Offset(dx, dy);

      }
    }

    private bool HasMovement(int dx, int dy)
    {
      return Math.Abs(dx) >= 1 || Math.Abs(dy) >= 1;
    }

    private void HideDummy()
    {
      m_fDummy.Visible = false;
    }

    private void ShowDummy(Point pos, bool isleft)
    {
      m_fDummy.ShowCursor(isleft);
      m_fDummy.Location = pos;
    }

    private void Print(RawMouse m1, RawMouse m2, int dx1, int dy1, int dx2, int dy2)
    {
      if (m_sOutputData == null) { m_sOutputData = new List<string>(); }

      if (m_sOutputData.Count > 10)
      {
        m_sOutputData.RemoveAt(0);
      }

      m_sOutputData.Add(
        string.Format(@"\b DX1: \b0 {0,6} \b DY1: \b0 {1,6} \b DX2: \b0 {2,6} \b DX3: \b0 {3,6} \b CurPos: \b0 {4,6} \b First: \b0 {5,6} \b Second: \b0 {6:000}\par",
        dx1,
        dy1,
        dx2,
        dy2,
        Cursor.Position.ToString(),
        m_FirstMousePos.ToString(),
        m_SecondMousePos.ToString()));

      //m_rtbOutput.Rtf = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1031{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}\viewkind4\uc1\pard\f0\fs17\par" + string.Concat(m_sOutputData.ToArray()) + "}";
      //m_rtbOutput.Select(m_rtbOutput.TextLength - 1, 1);
      //m_rtbOutput.ScrollToCaret();
    }
  }
}
