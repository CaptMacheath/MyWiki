using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace MyWiki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Articles.ItemsSource = GetAllArticles().Select(a => a.Title);
        }

        private List<Article> GetAllArticles()
        {
            List<Article> articles = new List<Article>();
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=WikiDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "SELECT * FROM [dbo].[Articles];"
                };

                using SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Article article = new Article
                    {
                        Title = dataReader["title"].ToString(),
                        Text = dataReader["text"].ToString()
                    };

                    articles.Add(article);
                }
            }

            return articles;
        }

        private void Articles_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // ...
        }
    }
}
