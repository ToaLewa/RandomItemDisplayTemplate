using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RandomItemDisplayTemplate
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListPage : Page
    {

        List<string> itemsList;


        public ListPage()
        {
          
          
            this.InitializeComponent();


            FillItemList();

            int numberOfItems = itemsList.Count();
            
            //populates the listbox
            for (int i = 0; i <= numberOfItems - 1; i++)
            {

                itemListTextBlock.Text = itemListTextBlock.Text + Convert.ToString(i + 1) +  ".  " + itemsList[i] + "\n\n";
                

            }

            

        }



        public void FillItemList()
        {

            itemsList = new List<string>();

            XmlReader reader = XmlReader.Create(@"Common/ItemList.xml");


            while (reader.Read())
            {

                if (reader.NodeType == XmlNodeType.Element)
                {

                    if (reader.Name == "item")
                    {

                        reader.Read();

                        string item = reader.Value;
                        itemsList.Add(item);
                    }

                }

            }

        }



        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {

            this.Frame.GoBack();
            
        }
            
        
    }

}
