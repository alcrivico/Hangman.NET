using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Hangman.UI.VisualComponents
{
    /// <summary>
    /// Interaction logic for TableControl.xaml
    /// </summary>
    public partial class TableControl : UserControl
    {

        public TableControl()
        {
            InitializeComponent();
        }

        public void DefineColumns(Dictionary<string, string>[] columns)
        {
            DataGridStructure.Columns.Clear();

            for (int i = 0; i < columns.Length; i++)
            {
                double ColumnWidth = -1;


                if (columns[i]["Width"] != "*")
                {
                    ColumnWidth = Convert.ToDouble(columns[i]["Width"]);
                }
                
                DataGridTextColumn dataGridTextColumn = new DataGridTextColumn();
                dataGridTextColumn.Header = columns[i]["Name"];
                dataGridTextColumn.Binding = new Binding(columns[i]["BindingName"]);
                dataGridTextColumn.IsReadOnly = true;

                
                if (i != 0)
                {

                    dataGridTextColumn.HeaderStyle = FindResource("GeneralColumnHeader") as Style;
                    dataGridTextColumn.CellStyle = FindResource("GeneralCell") as Style;
                
                }

                if (ColumnWidth != -1)
                {
                    dataGridTextColumn.Width = new DataGridLength(ColumnWidth, DataGridLengthUnitType.Pixel);
                } 
                else
                {
                    dataGridTextColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                }

                DataGridStructure.Columns.Add(dataGridTextColumn);

            }

        }

        public void SetItemsSource(ObservableCollection<GameDTO> itemsSource)
        {

            DataGridStructure.ItemsSource = null;
            DataGridStructure.ItemsSource = itemsSource;

        }

    }

    //Este DTO es temporal y deberá ser reemplazado por el DTO correspondiente en Resourses
    public class GameDTO
    {
        public required string ID { get; set; }
        public required string CreatedBy { get; set; }
        public int WaitingTime { get; set; }

    }
}
