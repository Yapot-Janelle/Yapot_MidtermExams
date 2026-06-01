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

namespace Yapot_MidtermExam
{
    public partial class MainWindow : Window
    {
        public List<AvailableItem> AvailableItems { get; set; }

        public class AvailableItem
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
        }

        public List<ShoppingCarts> ShoppingCart { get; set; }

        public class ShoppingCarts
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();

            AvailableItems = new List<AvailableItem>();
            ShoppingCart = new List<ShoppingCarts>();

            AvailableItemGrid.ItemsSource = AvailableItems;
            ShoppingCartGrid.ItemsSource = ShoppingCart;

            DataContext = this;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            IdTextBox.Clear();
            NameTextBox.Clear();
            DescriptionTextBox.Clear();
            PriceTextBox.Clear();
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IdTextBox.Text != "" &&
                    NameTextBox.Text != "" &&
                    DescriptionTextBox.Text != "" &&
                    PriceTextBox.Text != "")
                {
                    AvailableItems.Add(new AvailableItem
                    {
                        ID = int.Parse(IdTextBox.Text),
                        Name = NameTextBox.Text,
                        Description = DescriptionTextBox.Text,
                        Price = int.Parse(PriceTextBox.Text)
                    });

                    AvailableItemGrid.Items.Refresh();

                    MessageBox.Show("Item successfully added!");

                    IdTextBox.Clear();
                    NameTextBox.Clear();
                    DescriptionTextBox.Clear();
                    PriceTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Please fill in all fields correctly.");
                }
            }
            catch
            {
                MessageBox.Show("Invalid input!");
            }
        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if (ShoppingCartGrid.SelectedItem is ShoppingCarts selectedCart)
            {
                ShoppingCart.Remove(selectedCart);

                ShoppingCartGrid.Items.Refresh();

                ShoppingCartGrid.SelectedItem = null;

                MessageBox.Show("Item succesfully removed from cart!");
            }

            else if (AvailableItemGrid.SelectedItem is AvailableItem selectedItems)
            {
                AvailableItems.Remove(selectedItems);

                AvailableItemGrid.Items.Refresh();

                AvailableItemGrid.SelectedItem = null;

                MessageBox.Show("Item succesfully removed!");
            }

            else
            {
                MessageBox.Show("Please select an item to remove.");
            }
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (AvailableItemGrid.SelectedItem is AvailableItem selectedItem)
            {
                ShoppingCarts newItem = new ShoppingCarts
                {
                    ID = selectedItem.ID,
                    Name = selectedItem.Name,
                    Description = selectedItem.Description,
                    Price = selectedItem.Price
                };

                ShoppingCart.Add(newItem);

                ShoppingCartGrid.Items.Refresh();

                MessageBox.Show("Item successfully added to cart!");
            }
            else
            {
                MessageBox.Show("Please select an item first!");
            }
        }
    }
}