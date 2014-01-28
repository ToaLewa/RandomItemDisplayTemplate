using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;
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
    public sealed partial class MainPage : Page
    {

        //A list which holds the items within the XML document
        List<string> items;

        
        public MainPage()
        {
            this.InitializeComponent();

            if (Settings.run == true)
            {

                SettingsPane.GetForCurrentView().CommandsRequested += OnSettingsPaneCommandRequested;
                Settings.run = false;
            }

            //Displays a random item from the XML file into the itemDisplay textbox
            DisplayRandomItem(itemDisplay);

            
            //fills the item list once the list is empty
            if (Settings.runFillList == true)
            {

                ItemListFiller creator = new ItemListFiller();
                items = creator.ListFiller();

                Settings.runFillList = false;
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



        public void DisplayRandomItem(TextBlock itemDisplay)
        {


            try
            {

                int numOfItems = items.Count();


                Random rand = new Random();


                //randThing is used to randomly pick an index number in the item list
                //The upper limit of randThing is determined by numOfItems. 

                int randThing = rand.Next(0, numOfItems);


                //Displays the randomly picked item
                itemDisplay.Text = items[randThing];

                //The displayed item is removed from the list so it won't display again
                items.RemoveAt(randThing);

            }

            //If the item list runs out.  The list is repopulated and the method is run again.
            catch
            {
                ItemListFiller creator = new ItemListFiller();
                items = creator.ListFiller();

                DisplayRandomItem(itemDisplay);

            }
            
        }

        



        private void OnClick(object sender, RoutedEventArgs e)
        {
            DisplayRandomItem(itemDisplay);
        }
        

        private void LinkToPage(object sender, RoutedEventArgs e)
        {
            //links to ListPage.

            this.Frame.Navigate(typeof(ListPage));

        }
        //Provides a link for a generic privacy policy in the settings tab of the charms bar

        private void OnSettingsPaneCommandRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {

            args.Request.ApplicationCommands.Add(new SettingsCommand("commandID", "Privacy Statement", DoOperation));

        }


        //Opens generic privacy policy in a new window

        private async void DoOperation(IUICommand command)
        {
            Uri uri = new Uri("http://genericprivacystatement.tumblr.com/post/48082551268/privacy-policy");
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }

    }

}
