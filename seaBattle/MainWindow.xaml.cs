using seaBattle.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace seaBattle
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool[,] matrix;

        private ShipRectangle[,] rectangleMatrix;

        public MainWindow()
        {
            InitializeComponent();
        }

        private Rectangle ShipRectangle()
        {
            Rectangle rec = new Rectangle();
            rec.Width = 50;
            rec.Height = 50;
            rec.Fill = Brushes.Gray;

            return rec;
        }

        private Rectangle SeaRectangle()
        {
            Rectangle rec = new Rectangle();
            rec.Width = 50;
            rec.Height = 50;
            rec.Fill = Brushes.Blue;

            return rec;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AutoGenerationFild autoGenerationFild = new AutoGenerationFild();

            matrix = autoGenerationFild.GetFilledIn();

            rectangleMatrix = new ShipRectangle[10, 10];
            
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    Rectangle rec;
                    if (matrix[i, j] == true)
                        rec = ShipRectangle();
                    else
                        rec = SeaRectangle();

                    rec.SetValue(Grid.RowProperty, i);
                    rec.SetValue(Grid.ColumnProperty, j);
                    CompField.Children.Add(rec);
                    rectangleMatrix[i, j] = new ShipRectangle();
                    rectangleMatrix[i, j].rectangle = rec;
                }
        }

        private void CompField_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var x = e.GetPosition(null).X - 25;
            var y = e.GetPosition(null).Y - 50;

            int numbereOfColumn = (int)Math.Floor(x / 50);
            int numbereOfRow = (int)Math.Floor(y / 50);

            rectangleMatrix[numbereOfRow, numbereOfColumn].rectangle.Fill = Brushes.Black;

        }
    }
}
