using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Chess_Kokorin.Classes
{
    public class Horse
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Select = false;
        public bool Black = false;
        public Grid Figure { get; set; }
        public Horse(int X, int Y, bool Black)
        {
            this.X = X;
            this.Y = Y;
            this.Black = Black;
        }
        public void SelectFigure(object sender, MouseButtonEventArgs e)
        {
            bool atack = false;
            Horse SelectHorse = MainWindow.mainWindow.Horses.Find(x => x.Select == true);
            if (SelectHorse != null)
            {
                if (SelectHorse.HorseMove(this.X, this.Y))
                {
                    MainWindow.mainWindow.gameBoard.Children.Remove(this.Figure);
                    Grid.SetColumn(SelectHorse.Figure, this.X);
                    Grid.SetRow(SelectHorse.Figure, this.Y);
                    SelectHorse.X = this.X;
                    SelectHorse.Y = this.Y;
                    SelectHorse.SelectFigure(null, null);
                    atack = true;
                }
            }

            if (!atack)
            {
                MainWindow.mainWindow.OnSelect(this);
                if (this.Select)
                {
                    if (this.Black)
                        this.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Horse (black).png")));
                    else
                        this.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Horse.png")));
                    this.Select = false;
                }
                else
                {
                    this.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Horse (select).png")));
                    this.Select = true;
                }
            }
        }
        public void Transform(int X, int Y)
        {
            if (HorseMove(X, Y))
            {
                Grid.SetColumn(this.Figure, X);
                Grid.SetRow(this.Figure, Y);
                this.X = X;
                this.Y = Y;
            }
            SelectFigure(null, null);
        }
        private bool HorseMove(int newX, int newY)
        {
            int deltaX = Math.Abs(newX - this.X);
            int deltaY = Math.Abs(newY - this.Y);
            return (deltaX == 2 && deltaY == 1) || (deltaX == 1 && deltaY == 2);
        }
    }
}
