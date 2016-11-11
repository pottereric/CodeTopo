using CodeTopo.Analyzer;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace CodeTopo.Drawing
{
    public class Painter
    {
        public Canvas Paint(List<FunctionInfo> list)
        {
            var canvas = new Canvas();
            int verticalPosition = 5;

            foreach (var item in list)
            {
                System.Windows.Shapes.Rectangle rect;
                rect = new System.Windows.Shapes.Rectangle();
                rect.Stroke = new SolidColorBrush(Colors.White);
                rect.Fill = new SolidColorBrush(
                    GetColorForModifier(item.Modifier));
                rect.Width = item.NestingLevel * 5;
                rect.Height = item.Lines * 2;

                Canvas.SetLeft(rect, 10);
                Canvas.SetTop(rect, verticalPosition);

                verticalPosition += (int)rect.Height + 10;

                rect.ToolTip = item.Name;
                canvas.Children.Add(rect);
            }

            return canvas;
        }

        public Color GetColorForModifier(AccessModifier modifier)
        {
            Color color = Colors.Red;
            switch (modifier)
            {
                case AccessModifier.AccessPublic:
                    color = Colors.Green;
                    break;

                case AccessModifier.AccessProtected:
                    color = Colors.Blue;
                    break;
            }

            return color;
        }
    }
}