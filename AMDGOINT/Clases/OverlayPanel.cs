using DevExpress.Utils.Drawing;
using DevExpress.XtraSplashScreen;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AMDGOINT.Clases
{
    public class OverlayPanel
    {
        private IOverlaySplashScreenHandle handleOvrly = null;
        private CustomOverlayPainter customOverlayPainter = new CustomOverlayPainter();

        
        private IOverlaySplashScreenHandle ShowProgressPanel(Control ownr, OverlayWindowOptions op)
        {
            return SplashScreenManager.ShowOverlayForm(owner: ownr, customPainter: new CustomOverlayPainter());
        }

        private void CloseProgressPanel(IOverlaySplashScreenHandle handle)
        {
            if (handle != null) { SplashScreenManager.CloseOverlayForm(handle); }                
        }

        public void Mostrar(Control owner)
        {
            try
            {
                OverlayWindowOptions options = new OverlayWindowOptions(
                                               startupDelay: 100,
                                               backColor: Color.FromArgb(64, 64, 64),
                                               opacity: 0.6,
                                               fadeIn: false,
                                               fadeOut: false);

                handleOvrly = ShowProgressPanel(owner, options);
            }
            catch (Exception)
            {

            }
        }

        public void Ocultar()
        {
            CloseProgressPanel(handleOvrly);
        }
    }
}

public class CustomOverlayPainter : OverlayWindowPainterBase
{
    // Defines the string’s font.
    static readonly Font drawFont;
    static CustomOverlayPainter()
    {
        drawFont = new Font("Tw Cen MT", 12);
    }

    protected override void Draw(OverlayWindowCustomDrawContext context)
    {
        //The Handled event parameter should be set to true. 
        //to disable the default drawing algorithm. 
        context.Handled = true;
        //Provides access to the drawing surface. 
        GraphicsCache cache = context.DrawArgs.Cache;
        //Adjust the TextRenderingHint option
        //to improve the image quality.
        cache.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        //Overlapped control bounds. 
        Rectangle bounds = context.DrawArgs.Bounds;
        //Draws the default background. 
        context.DrawImage();
        context.DrawBackground();
        //Specify the string that will be drawn on the Overlay Form instead of the wait indicator.
        String drawString = "Aguarde";
        //Get the system's black brush.
        Brush drawBrush = Brushes.SteelBlue;        
        //Calculate the size of the message string.
        SizeF textSize = cache.CalcTextSize(drawString, drawFont);
        //A point that specifies the upper-left corner of the rectangle where the string will be drawn.
        PointF drawPoint = new PointF(
            bounds.Left + bounds.Width / 2 - textSize.Width / 2,
            bounds.Top + bounds.Height /2 - textSize.Height / 2
            );
        //Draw the string on the screen.
        cache.DrawString(drawString, drawFont, drawBrush, drawPoint);
    }
}