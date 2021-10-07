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
using Vector = Snake.Model.Vector;

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int GameWidth = 25;
        private const int GameHeight = 25;
        private const int ValueFoodCount = 10;


        private Vector _snake = new Vector(GameWidth/2,GameHeight/2);
        private Vector _direction = new Vector();
        private readonly List<Vector> _foodPosition = new List<Vector>();
        private readonly Random _random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            InitGame();
        }


        private void InitGame()
        {
            _snake = new Vector(GameWidth / 2, GameHeight / 2);
            for (int i = 0; i < ValueFoodCount; i++)
            {
                _foodPosition.Add(GenerateRandomFreePosition());
            }
            RenderState();
        }

        private void RenderState()
        {
            gameCanvas.Children.Clear();
            RenderSnake();
            RenderPortion();
            RenderFood();
        }

        private void RenderFood()
        {
         foreach(var food in _foodPosition)
            {
                DrawPoint(food, Brushes.Red);
            } 
        }

        private void RenderPortion()
        {
   
        }

        private Vector GenerateRandomFreePosition()
        {
            Vector generatedPosition;
            do
            {
                generatedPosition = new Vector(_random.Next(GameWidth), _random.Next(GameHeight));
            }
            while (_snake == generatedPosition||_foodPosition.Any(food=>food==generatedPosition));
            return generatedPosition;
        }

        private void RenderSnake()
        {
            DrawPoint(_snake, Brushes.Coral);
        }


        private void DrawPoint(Vector position,Brush brush)
        {
            var shape = new Rectangle();
            shape.Fill=brush;
            var unitX = gameCanvas.Width / GameWidth;
            var unitY = gameCanvas.Height / GameHeight;
            shape.Width = unitX;
            shape.Height = unitY;
            Canvas.SetLeft(shape, position.X * unitX);
            Canvas.SetTop(shape, position.Y * unitY);
            gameCanvas.Children.Add(shape);
        }


        private void ApplyInputKey(Key pressedKey)
        {
            if (pressedKey == Key.Up)
            {
                _direction = Vector.Up;
            }
            else if (pressedKey == Key.Down)
            {
                _direction = Vector.Down;
            }
            else if (pressedKey == Key.Left)
            {
                _direction = Vector.Left;
            }
            else if (pressedKey == Key.Right)
            {
                _direction = Vector.Right;
            }
        }


        private bool CalculateState()
        {
            _snake += _direction;
            if (_snake.X < 0 || _snake.X >= GameWidth || _snake.Y < 0 || _snake.Y >= GameHeight)
            {
                return false;
            }
            return true;
        }

        private void gameCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            ApplyInputKey(e.Key);
            if (CalculateState())
            {
                RenderState();
            }
            else
            {
                GameOver();
            }
            
        }

        private void GameOver()
        {
            InitGame();
        }
    }
}
