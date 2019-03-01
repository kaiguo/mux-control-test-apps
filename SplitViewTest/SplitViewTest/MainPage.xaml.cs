using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SplitViewTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.SizeChanged += MainPage_SizeChanged;
            TestSplitView.PaneOpening += TestSplitView_PaneOpening;
            TestSplitView.PaneClosing += TestSplitView_PaneClosing;
        }

        private void TestSplitView_PaneClosing(SplitView sender, SplitViewPaneClosingEventArgs args)
        {
            OpenStateText.Text = "Closing";
        }

        private void TestSplitView_PaneOpening(SplitView sender, object args)
        {
            OpenStateText.Text = "Opening";
        }

        private void MainPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var width = e.NewSize.Width;
            if (width < 1000) TestSplitView.DisplayMode = SplitViewDisplayMode.CompactOverlay;
            else
            {
                TestSplitView.DisplayMode = SplitViewDisplayMode.CompactInline;
                TestSplitView.IsPaneOpen = true;
            }
            WidthText.Text = width.ToString();
            if(TestSplitView.DisplayMode == SplitViewDisplayMode.CompactOverlay)
            {
                if (TestSplitView.IsPaneOpen) TestSplitView.IsPaneOpen = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TestSplitView.IsPaneOpen = !TestSplitView.IsPaneOpen;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(TestSplitView.DisplayMode == SplitViewDisplayMode.CompactInline)
            {
                TestSplitView.DisplayMode = SplitViewDisplayMode.CompactOverlay;
            }
            else
            {
                TestSplitView.DisplayMode = SplitViewDisplayMode.CompactInline;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenStateText.Text = TestSplitView.IsPaneOpen.ToString();
        }
    }
}
