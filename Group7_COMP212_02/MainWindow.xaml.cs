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
using System.Collections.ObjectModel; // for ObservableCollection<T>

namespace Group7_COMP212_02
{
    

    public class Vegetable
    {
        public string Name { get; set; }
        public string Price { get; set; }

        private double priceInDouble; //to save price as double type

        public Vegetable(string name, double price)
        {
            Name = name;
            this.priceInDouble = price;
            Price = string.Format("${0:0.00}", price);
        }
        public override string ToString()
        {
            return $"{Name} {Price}";
        }
    }
    public class Fruit
    {
        public string Name { get; set; }
        public string Price { get; set; }

        private double priceInDouble; //to save price as double type

        public Fruit(string name, double price)
        {
            Name = name;
            this.priceInDouble = price;
            Price = string.Format("${0:0.00}", price);
        }
        public override string ToString()
        {
            return $"{Name} {Price}";
        }
    }
    public class Flower
    {
        public string Name { get; set; }
        public string Price { get; set; }

        private double priceInDouble; //to save price as double type

        public Flower(string name, double price)
        {
            Name = name;
            this.priceInDouble = price;
            Price = string.Format("${0:0.00}", price);
        }
        public override string ToString()
        {
            return $"{Name} {Price}";
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<Vegetable> vegetables
                              = new ObservableCollection<Vegetable>();
        ObservableCollection<Flower> flowers
                              = new ObservableCollection<Flower>();
        ObservableCollection<Fruit> fruits
                              = new ObservableCollection<Fruit>();

        public MainWindow()
        {
            InitializeComponent();
            doMyCustomWork();
        }
        public void doMyCustomWork()
        {
            //bind the target dataGrid1 to the source vegetables
            fruitCombo.Items.Add(new Fruit("Plum",15) );
            fruitCombo.Items.Add(new Fruit("Kiwi", 30));
            flowerCombo.Items.Add(new Flower("Lily", 40));
            flowerCombo.Items.Add(new Flower("Rose", 30));
            
            //Add items to datagrid1
            //NOTE: If a ObservableCollection object changes, 
            //it notifies its target (if bound).
            //Thus the data is sent to its target every time 
            //it changes (i.e. in this case every time 
            //a new Vegetable object is added).


        }

        private void call_delete_selected_row(object sender, RoutedEventArgs e)
        {
            Vegetable v = (Vegetable)dataGrid1.SelectedItem;
            vegetables.Remove(v);
        }

        private void call_reset(object sender, RoutedEventArgs e)
        {
            vegetables.Clear();
        }

        private void call_populate(object sender, RoutedEventArgs e)
        {
            vegetables.Add(new Vegetable("Spinach", 6.11));
            vegetables.Add(new Vegetable("Methi", 11.22));
        }
        private void call_ComboBox_Fruit(object sender, SelectionChangedEventArgs e)
        {
            // (expression as Type) is equivalent to:
            // expression is Type ? (Type)expression : null 
            var item = (sender as ComboBox).SelectedItem;

            if (item == null) return;

            Fruit fruit = (Fruit)item;
            this.dataGrid1.ItemsSource = fruits;
            fruits.Add(fruit);

            //greenVeg.Text = v.ToString(); //set the string to a textblock named greenVeg
        }

        private void call_ComboBox_flower(object sender, SelectionChangedEventArgs e)
        {
            // (expression as Type) is equivalent to:
            // expression is Type ? (Type)expression : null 
            var item = (sender as ComboBox).SelectedItem;
            if (item == null) return;

            Flower flower = (Flower)item;
            this.dataGrid1.ItemsSource = flowers;
            flowers.Add(flower);

            // redVeg.Text = v.ToString(); //set the string to a textblock named redVeg
        }

        private void call_reset_comboBoxes(object sender, RoutedEventArgs e)
        {
            //way to display the default text "Pick a green vegetable"
            //in combo box until the user selects an item from combo box.

            //greenVeg.Text = " ";
            //redVeg.Text = " ";
        }
    }
}
