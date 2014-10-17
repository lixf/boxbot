using QonqrDotUniversal.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace BoxBotAlpha
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private NavigationHelper navigationHelper;

        private SolidColorBrush foregroundColor = new SolidColorBrush();
        private SolidColorBrush backgroundColor = new SolidColorBrush();
        private SolidColorBrush transparentColor = new SolidColorBrush();

        private TranslateTransform TabMove = new TranslateTransform();
        private TransformGroup TabTransforms = new TransformGroup();
        private TranslateTransform ButtonMove = new TranslateTransform();
        private TransformGroup ButtonTransforms = new TransformGroup();
        private bool moreDisplayed = false;
        private int animationCounter = 0;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            TabTransforms.Children.Add(TabMove);
            NavigationTabs.RenderTransform = TabTransforms;
            ButtonTransforms.Children.Add(ButtonMove);
            NavigationMore.RenderTransform = ButtonTransforms;
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            // hide the status bar
            StatusBar statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
            await statusBar.HideAsync();

            // set color brushes
            foregroundColor.Color = Color.FromArgb(0, 33, 33, 33);
            backgroundColor.Color = Color.FromArgb(0, 174, 174, 174);
            transparentColor.Color = Color.FromArgb(0, 0, 0, 0);

            homeBotBounceStoryboard.Begin();

            Rectangle rect = new Rectangle();
            rect.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
            rect.Width = 50;
            rect.Height = 50;
            Canvas.SetLeft(rect, 100);
            Canvas.SetTop(rect, 150);

            InventoryBotView.Children.Add(rect);
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {

        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        /*###########################################################################################*
         #                                TabBar Navigation Functions                                #
         *###########################################################################################*/

        /// <summary>
        /// Provide highlight animation when a tab is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeButton_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            HomeButtonOverlay.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
        private void HomeButton_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            HomeButtonOverlay.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
        private void MapButton_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            MapButtonOverlay.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
        private void MapButton_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            MapButtonOverlay.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
        private void InventoryButton_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            InventoryButtonOverlay.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
        private void InventoryButton_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            InventoryButtonOverlay.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
        private void FriendsButton_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            FriendsButtonOverlay.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
        private void FriendsButton_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            FriendsButtonOverlay.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
        private void MoreButton_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            MoreButtonOverlay.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
        private void MoreButton_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            MoreButtonOverlay.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
        private void SettingsButton_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            SettingsButtonOverlay.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
        private void SettingsButton_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            SettingsButtonOverlay.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void HomeButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            HomeView.Visibility = Windows.UI.Xaml.Visibility.Visible;
            InventoryView.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            FriendsView.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            inventoryBotBounceStoryboard.Stop();
            homeBotBounceStoryboard.Stop();

            homeBotBounceStoryboard.Begin();
        }

        private void MapButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            HomeView.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            InventoryView.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            FriendsView.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            inventoryBotBounceStoryboard.Stop();
            homeBotBounceStoryboard.Stop();
        }

        private void InventoryButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            HomeView.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            InventoryView.Visibility = Windows.UI.Xaml.Visibility.Visible;
            FriendsView.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            homeBotBounceStoryboard.Stop();
            inventoryBotBounceStoryboard.Stop();

            inventoryBotBounceStoryboard.Begin();
        }

        private void FriendsButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            HomeView.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            InventoryView.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            FriendsView.Visibility = Windows.UI.Xaml.Visibility.Visible;

            inventoryBotBounceStoryboard.Stop();
            homeBotBounceStoryboard.Stop();
        }

        /// <summary>
        /// Hide or Display extra settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoreButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // animate up
            if (!moreDisplayed) showMenu();
            // animate down
            else hideMenu();
        }

        private void SettingsButton_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        /*###########################################################################################*
         #                                     Helper Functions                                      #
         *###########################################################################################*/

        private void showMenu()
        {
            moreDisplayed = true;

            animationCounter = 0;
            ButtonMove.Y -= 4;
            TabMove.Y -= 1;
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1); // 500 Milliseconds
            dt.Tick +=
                delegate
                {
                    if (animationCounter >= 180) dt.Stop();
                    ButtonMove.Y -= 30;
                    TabMove.Y -= 30;
                    animationCounter += 30;
                };
            dt.Start();
        }
        private void hideMenu()
        {
            moreDisplayed = false;

            animationCounter = 0;
            ButtonMove.Y += 4;
            TabMove.Y += 1;
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1); // 500 Milliseconds
            dt.Tick +=
                delegate
                {
                    if (animationCounter >= 180) dt.Stop();
                    ButtonMove.Y += 30;
                    TabMove.Y += 30;
                    animationCounter += 30;
                };
            dt.Start();
        }

        
    }
}
