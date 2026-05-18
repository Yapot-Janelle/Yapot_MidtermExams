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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Initialize the list
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

                if (IdTextBox.Text != "" && NameTextBox.Text != "" && DescriptionTextBox.Text != "" && PriceTextBox.Text != "")
                {
                    AvailableItems.Add(new AvailableItem
                    {
                        ID = int.Parse(IdTextBox.Text),
                        Name = NameTextBox.Text,
                        Description = DescriptionTextBox.Text,
                        Price = int.Parse(PriceTextBox.Text)

                        
                    });
                    MessageBox.Show("Item/s succesfully added");
                }
                else
                {
                    MessageBox.Show("Please fill in all fields correctly.");
                }
                
                AvailableItemGrid.Items.Refresh();

                IdTextBox.Text = "";
                NameTextBox.Text = "";
                DescriptionTextBox.Text = "";
                PriceTextBox.Text = "";

            }
            catch
            {
                MessageBox.Show("Please fill in all fields correctly.");
            }
        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            AvailableItem selectedItems = AvailableItemGrid.SelectedItem as AvailableItem;
            if (selectedItems != null)
            {
                AvailableItems.Remove(selectedItems);
                AvailableItemGrid.Items.Refresh();
                MessageBox.Show("Item/s succesfully removed.");
            }
            else
            {
                MessageBox.Show("Please select an item/s to remove.");
            }

        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{

            //    if (IdTextBox.Text != "" && NameTextBox.Text != "" && DescriptionTextBox.Text != "" && PriceTextBox.Text != "")
            //    {
            //        ShoppingCart.Add(new ShoppingCarts
            //        {
            //            ID = int.Parse(IdTextBox.Text),
            //            Name = NameTextBox.Text,
            //            Description = DescriptionTextBox.Text,
            //            Price = int.Parse(PriceTextBox.Text)


            //        });
            //        MessageBox.Show("Item/s succesfully added");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please fill in all fields correctly.");
            //    }

            //    ShoppingCartGrid.Items.Refresh();

            //    IdTextBox.Text = "";
            //    NameTextBox.Text = "";
            //    DescriptionTextBox.Text = "";
            //    PriceTextBox.Text = "";

            //}
            //catch
            //{
            //    MessageBox.Show("Please fill in all fields correctly.");
            //}

            //AvailableItem selectedItems = ShoppingCartGrid.SelectedItem as AvailableItem;
            //if (selectedItems != null)
            //{
            //    ShoppingCart.Add(selectedItems);
            //    ShoppingCartGrid.Items.Refresh();
            //    MessageBox.Show("Item/s succesfully added to the cart!");
            //}
            //else
            //{
            //    MessageBox.Show("Please select an item/s to add.");
            //}

            //if (ShoppingCartGrid.SelectedItem is AvailableItem selectedItems)
            //{
            //    try
            //    {

            //        selectedItems.ID = int.Parse(IdTextBox.Text);
            //        selectedItems.Name = NameTextBox.Text;
            //        selectedItems.Description = DescriptionTextBox.Text;
            //        selectedItems.Price = int.Parse(PriceTextBox.Text);

            //        ShoppingCartGrid.Items.Refresh();
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Please fill in all fields correctly!");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please select an employee to update!");
            //}

        }
    }
}