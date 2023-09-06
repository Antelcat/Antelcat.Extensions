using System.Drawing;

namespace Antelcat.Extensions;

public static class GeometryExtension
{
    public static Size FixedScaleInto(this Size size, int width, int height)
    {
        var ret = size;
        if (size.Height <= height && size.Width <= width)
        {
            return ret;
        }
        var desireTan = (double)height / width;
        var sourceTan = (double)size.Height / size.Width;
        if (sourceTan > desireTan)//正切值更大
        {
            ret.Height = height;
            ret.Width = ret.Width * height / size.Height;
        }
        else
        {
            ret.Width = width;
            ret.Height = ret.Height * width / size.Width;
        }

        return ret;
    }

    
    public static Size Scale(this Size size, double scale) => new( (int)(scale * size.Width), (int)(scale * size.Height));

    public static Rectangle Scale(this Rectangle rectangle, double scale)
    {
        var lu = rectangle.Location;
        var l = rectangle.Width / 2;
        var h = rectangle.Height / 2;
        var center = new Point(lu.X + l, lu.Y + h);
        var nl = l * scale;
        var nh = h * scale;
        return new Rectangle((int)(center.X - nl), (int)(center.Y - nh), (int)nl * 2, (int)nh * 2);
    }
    
    public static Rectangle ScaleHeight(this Rectangle rectangle, double scale)
    {
        var lu = rectangle.Location;
        var h = rectangle.Height / 2;
        var center = new Point(lu.X +  rectangle.Width / 2, lu.Y + h);
        var nh = h * scale;
        return new Rectangle(rectangle.Left, (int)(center.Y - nh),rectangle.Width, (int)nh * 2);
    }
    public static Rectangle ScaleWidth(this Rectangle rectangle, double scale)
    {
        var lu = rectangle.Location;
        var l = rectangle.Width / 2;
        var center = new Point(lu.X + l, lu.Y + rectangle.Height / 2);
        var nl = l * scale;
        return new Rectangle((int)(center.X - nl), rectangle.Top, (int)nl * 2, rectangle.Height);
    }
}