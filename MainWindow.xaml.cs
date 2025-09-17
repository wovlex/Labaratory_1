using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laba_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        Triangle tr;
        Fourangle pr;
        Kvadrat kv;
        Random rnd = new Random();
        public MainWindow()
        {

            InitializeComponent();
            //Создание треугольника со случайными координатами
            Point2D p1 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0,(int)Scene.Height));
            Point2D p2 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0,(int)Scene.Height));
            Point2D p3 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0,(int)Scene.Height));
            tr = new Triangle(p1, p2, p3);

        }

        public void Risovanie()
        {
            Point2D p1 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            Point2D p2 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            Point2D p3 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            tr = new Triangle(p1, p2, p3);
        }
        public void RisovanieKva()
        {

            int width = rnd.Next(50, 150);
            int height = rnd.Next(50, 150);

            // Выбираем начальную точку так, чтобы весь прямоугольник помещался на сцене
            int startX = rnd.Next(0, (int)Scene.Width - width);
            int startY = rnd.Next(0, (int)Scene.Height - height);
            Point2D p1 = new Point2D(startX, startY);

            // Создаем остальные точки, чтобы образовать прямоугольник с углом 90 градусов
            Point2D p2 = new Point2D(p1.getX() + width, p1.getY());
            Point2D p3 = new Point2D(p2.getX(), p2.getY() + height);
            Point2D p4 = new Point2D(p1.getX(), p1.getY() + height);

            pr = new Fourangle(p1, p2, p3, p4);
        }
        public void RisovanieKvadrat()
        {
            int sideLength = rnd.Next(50, 150);
            Point2D startPoint = new Point2D(rnd.Next(0, (int)Scene.Width - sideLength), rnd.Next(0, (int)Scene.Height - sideLength));

            Point2D p1 = startPoint;
            Point2D p2 = new Point2D(p1.getX() + sideLength, p1.getY());
            Point2D p3 = new Point2D(p2.getX(), p2.getY() + sideLength);
            Point2D p4 = new Point2D(p1.getX(), p1.getY() + sideLength);

            kv = new Kvadrat(p1, p2, p3, p4);
        }
        public void DrawTriangle(Triangle tr)
        {
            //Отрисовка треугольника с помощью функции отрисовки линии
            DrawLine(tr.getP1(), tr.getP2());
            DrawLine(tr.getP2(), tr.getP3());
            DrawLine(tr.getP3(), tr.getP1());
        }
        public void ClearScene()
        {
            //Очистка Canvas от всех объектов
            Scene.Children.Clear();
        }
        public void DrawFourangle(Fourangle pr)
        {
            //Отрисовка треугольника с помощью функции отрисовки линии
            DrawLine(pr.getP1(), pr.getP2());
            DrawLine(pr.getP2(), pr.getP3());
            DrawLine(pr.getP3(), pr.getP4());
            DrawLine(pr.getP4(), pr.getP1());
        }

        public void DrawKvadrat(Kvadrat kv)
        {
            //Отрисовка кварата с помощью функции отрисовки линии
            DrawLine(kv.getP1(), kv.getP2());
            DrawLine(kv.getP2(), kv.getP3());
            DrawLine(kv.getP3(), kv.getP4());
            DrawLine(kv.getP4(), kv.getP1());
        }

        //функция в основном теле программы
        public void DrawLine(Point2D p1, Point2D p2)
        {
            //Создание новой линии
            Line line = new Line();
            //Цвет и толщина линии
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 3;
            //Установка координат линии из координат точек Point2D
            line.X1 = p1.getX();
            line.Y1 = p1.getY();
            line.X2 = p2.getX();
            line.Y2 = p2.getY();

            //Добавление линии в Canvas
            Scene.Children.Add(line);
        }

        private void ButtonTre_Click(object sender, RoutedEventArgs e)
        {

            
            Risovanie();
            ClearScene();
            DrawTriangle(tr);


        }

        private void ButtonKva_Click(object sender, RoutedEventArgs e)
        {
            RisovanieKvadrat();
            ClearScene();
            DrawKvadrat(kv);
        }

        private void ButtonPra_Click(object sender, RoutedEventArgs e)
        {
            RisovanieKva();
            ClearScene();
            DrawFourangle(pr);
        }

        private void SliderX(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void SliderY(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }


    public class Point2D
    {
        //Атрибуты класса
        private int X;
        private int Y;
        //Конструктор класса
        public Point2D(int x, int y)
        {
            //this используется для однозначного указания на атрибуты класса так как переменные имеют одинаковые имена
            this.X = x;
            this.Y = y;
        }

        //Методы для получения координат
        public int getX()
        {
            return X;
        }
        public int getY()
        {
            return Y;
        }
        //Методы для изменения координат
        public void addX(int x)
        {
            X += x;
        }
        public void addY(int y)
        {
            Y += y;
        }





    }




}