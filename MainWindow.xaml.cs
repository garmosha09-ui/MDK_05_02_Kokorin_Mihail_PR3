using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using Chess_Kokorin.Classes;

namespace Chess_Kokorin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;
        public List<Classes.Pawn> Pawns = new List<Classes.Pawn>();
        public List<Classes.Horse> Horses = new List<Classes.Horse>();
        public MainWindow()
        {
            InitializeComponent();
            MainWindow.mainWindow = this;
            Pawns.Add(new Classes.Pawn(0, 1, false));
            Pawns.Add(new Classes.Pawn(1, 1, false));
            Pawns.Add(new Classes.Pawn(2, 1, false));
            Pawns.Add(new Classes.Pawn(3, 1, false));
            Pawns.Add(new Classes.Pawn(4, 1, false));
            Pawns.Add(new Classes.Pawn(5, 1, false));
            Pawns.Add(new Classes.Pawn(6, 1, false));
            Pawns.Add(new Classes.Pawn(7, 1, false));

            Horses.Add(new Classes.Horse(1, 0, false));
            Horses.Add(new Classes.Horse(6, 0, false));

            Pawns.Add(new Classes.Pawn(0, 6, true));
            Pawns.Add(new Classes.Pawn(1, 6, true));
            Pawns.Add(new Classes.Pawn(2, 6, true));
            Pawns.Add(new Classes.Pawn(3, 6, true));
            Pawns.Add(new Classes.Pawn(4, 6, true));
            Pawns.Add(new Classes.Pawn(5, 6, true));
            Pawns.Add(new Classes.Pawn(6, 6, true));
            Pawns.Add(new Classes.Pawn(7, 6, true));

            Horses.Add(new Classes.Horse(1, 7, true));
            Horses.Add(new Classes.Horse(6, 7, true));

            CreateFigure();
        }
        public void CreateFigure()
        {
            foreach (Classes.Pawn Pawn in Pawns)
            {
                Pawn.Figure = new Grid()
                {
                    Width = 50,
                    Height = 50
                };
                if(Pawn.Black)
                    Pawn.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Pawn (black).png")));
                else
                    Pawn.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Pawn.png")));
                Grid.SetColumn(Pawn.Figure, Pawn.X);
                Grid.SetRow(Pawn.Figure, Pawn.Y);
                Pawn.Figure.MouseDown += Pawn.SelectFigure;
                gameBoard.Children.Add(Pawn.Figure);
            }

            foreach (Classes.Horse Horse in Horses)
            {
                Horse.Figure = new Grid()
                {
                    Width = 50,
                    Height = 50
                };
                if (Horse.Black)
                    Horse.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Horse (black).png")));
                else
                    Horse.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Horse.png")));
                Grid.SetColumn(Horse.Figure, Horse.X);
                Grid.SetRow(Horse.Figure, Horse.Y);
                Horse.Figure.MouseDown += Horse.SelectFigure;
                gameBoard.Children.Add(Horse.Figure);
            }
        }

        public void OnSelect(Classes.Pawn SelectPawn)
        {
            foreach (Classes.Pawn Pawn in Pawns)
                if (Pawn != SelectPawn)
                    if (Pawn.Select)
                        Pawn.SelectFigure(null, null);
        }
        public void OnSelect(Classes.Horse SelectHorse)
        {
            foreach (Classes.Horse Horse in Horses)
                if (Horse != SelectHorse)
                    if (Horse.Select)
                        Horse.SelectFigure(null, null);
        }
        private void SelectTile(object sender, MouseButtonEventArgs e)
        {
            Grid Tile = sender as Grid;
            int X = Grid.GetColumn(Tile);
            int Y = Grid.GetRow(Tile);
            Classes.Pawn SelectPawn = Pawns.Find(x => x.Select == true);
            if (SelectPawn != null)
            {
                SelectPawn.Transform(X, Y);
            }
            Classes.Horse SelectHorse = Horses.Find(x => x.Select == true);
            if (SelectHorse != null)
            {
                
            }
            if (SelectHorse != null)
            {
                SelectHorse.Transform(X, Y);
            }
        }
    }
}
