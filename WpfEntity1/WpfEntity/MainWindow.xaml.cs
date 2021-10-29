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

namespace WpfEntity
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        moviesEntities entities = new moviesEntities();
        public MainWindow()
        {
            
            InitializeComponent();
            
            foreach (var movie in entities.Movies)
            {
                moviesListBox.Items.Add(movie);
            }
            foreach (var genre in entities.Genres)
            {
                genresComboBox.Items.Add(genre);
            }
        }

        private void moviesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedMovie = moviesListBox.SelectedItem as Movies;
            if (selectedMovie != null)
            {
                movieTitleTextBox.Text = selectedMovie.Название;
                yearTextBox.Text = selectedMovie.Год.ToString();
                genresComboBox.SelectedItem = (from genre in entities.Genres where genre.id == selectedMovie.Жанр select genre).Single<Genres>();
            }
            else
            {
                movieTitleTextBox.Text = "";
                yearTextBox.Text = "";
                genresComboBox.SelectedIndex = -1;
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedMovie = moviesListBox.SelectedItem as Movies;
            if (selectedMovie != null)
            {
                MessageBoxResult res = MessageBox.Show("Вы уверены что хотите удалить объект?", "Подтвердите удаление", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (res == MessageBoxResult.OK)
                {
                    entities.Movies.Remove(selectedMovie);
                    entities.SaveChanges();
                    movieTitleTextBox.Clear();
                    yearTextBox.Clear();
                    moviesListBox.Items.Remove(selectedMovie);
                    genresComboBox.SelectedIndex = -1;
                }
                else
                {
                    return;
                }
            }
            else { MessageBox.Show("Нет удаляемых объектов.", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            var movie = moviesListBox.SelectedItem as Movies;
            if (movieTitleTextBox.Text == "" || genresComboBox.SelectedIndex == -1 || yearTextBox.Text == "")
            {
                MessageBox.Show("Заполните все поля.", "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (movie == null)
                {
                    movie = new Movies();
                    entities.Movies.Add(movie);
                    moviesListBox.Items.Add(movie);
                }
                movie.Название = movieTitleTextBox.Text;
                movie.Год = int.Parse(yearTextBox.Text);
                movie.Жанр = (genresComboBox.SelectedItem as Genres).id;
                entities.SaveChanges();
                moviesListBox.Items.Refresh();
            }
        }
        private void addMovieButton_Click(object sender, RoutedEventArgs e)
        {
            movieTitleTextBox.Text = "";
            yearTextBox.Text = "";
            genresComboBox.SelectedIndex = -1;
            moviesListBox.SelectedIndex = -1;
            movieTitleTextBox.Focus();
        }
    }
}
