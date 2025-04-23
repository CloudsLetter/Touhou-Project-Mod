using ModernWpf.Controls.Primitives;
using ModernWpf.Controls;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Touhou_Project_Mod_UI.Views;
using Frame = ModernWpf.Controls.Frame;
using System.Diagnostics;
using System.Windows.Threading;
using Touhou_Project_Mod_UI.Utils;
namespace Touhou_Project_Mod_UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{


    private bool _ignoreSelectionChange;
    private readonly ControlPagesData _controlPages = new ControlPagesData();
    private readonly ControlPagesData _controlPagesData = new ControlPagesData();
    private static readonly ThreadLocal<Frame> _rootFrame = new ThreadLocal<Frame>();
    private Type _startPage;


    public MainWindow()
    {
        InitializeComponent();
        //RootFrame.Navigate(typeof(Home));

        ////SetStartPage();
        //if (_startPage != null)
        //{
        //    PagesList.SelectedItem = PagesList.Items.OfType<ControlInfoDataItem>().FirstOrDefault(x => x.PageType == _startPage);
        //}
        RootFrame = rootFrame;
        NavigateToSelectedPage();
        RootFrame.Navigate(typeof(Home));
        PagesList.SelectedItem = PagesList.Items
            .OfType<ControlInfoDataItem>()
            .FirstOrDefault(x => x.PageType == typeof(Home));


    }
    partial void SetStartPage();


    private void Window_Main_Loaded(object sender, RoutedEventArgs e)
    {
        new Thread(Utils.Utils.CheckTouhouRun)
        {
            Name = "CheckTouhouRun",
            IsBackground = true
        }.Start();
    }
    private void RootFrame_Navigating(object sender, NavigatingCancelEventArgs e)
    {
        if (e.NavigationMode == NavigationMode.Back)
        {
            RootFrame.RemoveBackEntry();
        }
    }

    private void RootFrame_Navigated(object sender, NavigationEventArgs e)
    {
        Debug.Assert(!RootFrame.CanGoForward);

        _ignoreSelectionChange = true;
        PagesList.SelectedValue = RootFrame.CurrentSourcePageType;
        _ignoreSelectionChange = false;
    }
    private void NavigateToSelectedPage()
    {
        if (PagesList.SelectedValue is Type type)
        {
            RootFrame?.Navigate(type);
        }
    }
    private void PagesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {


        if (!_ignoreSelectionChange)
        {
                            NavigateToSelectedPage();
            
        }
    }

    public static Frame RootFrame
    {
        get => _rootFrame.Value;
        private set => _rootFrame.Value = value;
    }

    private void OnControlsSearchBoxQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
    {
        if (args.ChosenSuggestion != null && args.ChosenSuggestion is ControlInfoDataItem)
        {
            var pageType = (args.ChosenSuggestion as ControlInfoDataItem).PageType;
            RootFrame.Navigate(pageType);
        }
        else if (!string.IsNullOrEmpty(args.QueryText))
        {
            var item = _controlPagesData.FirstOrDefault(i => i.Title.Equals(args.QueryText, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                RootFrame.Navigate(item.PageType);
            }
        }
    }

    private void OnControlsSearchBoxTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        var suggestions = new List<ControlInfoDataItem>();

        if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
        {
            var querySplit = sender.Text.Split(' ');
            var matchingItems = _controlPagesData.Where(
                item =>
                {
                    bool flag = true;
                    foreach (string queryToken in querySplit)
                    {
                        if (item.Title.IndexOf(queryToken, StringComparison.CurrentCultureIgnoreCase) < 0)
                        {
                            flag = false;
                        }
                    }
                    return flag;
                });
            foreach (var item in matchingItems)
            {
                suggestions.Add(item);
            }
            if (suggestions.Count > 0)
            {
                controlsSearchBox.ItemsSource = suggestions.OrderByDescending(i => i.Title.StartsWith(sender.Text, StringComparison.CurrentCultureIgnoreCase)).ThenBy(i => i.Title);
            }
            else
            {
                controlsSearchBox.ItemsSource = new string[] { Properties.Resources.NoResultsFound };
            }
        }
    }
}

public class ControlInfoDataItem
{

    public ControlInfoDataItem(Type pageType, string title = null)
    {
        PageType = pageType;
        Title = title ?? pageType.Name.Replace("Page", null);
    }

    public string Title { get; }

    public Type PageType { get; }

    public override string ToString()
    {
        return Title;
    }
}

public class ControlPagesData : List<ControlInfoDataItem>
{
    public ControlPagesData()
    {
        AddPage(typeof(Home), Properties.Resources.Home);
        AddPage(typeof(Koumakyou), Properties.Resources.Koumakyou);
        AddPage(typeof(Youyoumu), Properties.Resources.Youyoumu);
        AddPage(typeof(Eiyashou), Properties.Resources.Eiyashou);
        AddPage(typeof(Kaeizuka), Properties.Resources.Kaeizuka);
        AddPage(typeof(Fuujinroku), Properties.Resources.Fuujinroku);
        AddPage(typeof(Chireiden), Properties.Resources.Chireiden);
        AddPage(typeof(Seirensen), Properties.Resources.Seirensen);
        AddPage(typeof(Shinreibyou), Properties.Resources.Shinreibyou);
        AddPage(typeof(Kishinjou), Properties.Resources.Kishinjou);
        AddPage(typeof(Kanjuden), Properties.Resources.Kanjuden);
        AddPage(typeof(Tenkuushou), Properties.Resources.Tenkuushou);
        AddPage(typeof(Kikeijuu), Properties.Resources.Kikeijuu);
        AddPage(typeof(Kouryuudou), Properties.Resources.Kouryuudou);
        AddPage(typeof(Juuouen), Properties.Resources.Juuouen);
        AddPage(typeof(Kinjoukyou), Properties.Resources.Kinjoukyou);
    }

    private void AddPage(Type pageType, string displayName = null)
    {
        Add(new ControlInfoDataItem(pageType, displayName));
    }
}


public class SampleFrame : Frame
{
    private object _oldContent;

    public SampleFrame()
    {
        Navigating += OnNavigating;
        Navigated += OnNavigated;
    }

    protected override void OnContentChanged(object oldContent, object newContent)
    {
        base.OnContentChanged(oldContent, newContent);
        _oldContent = oldContent;
    }

    private void OnNavigating(object sender, NavigatingCancelEventArgs e)
    {
    }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        bool firstNavigation = _oldContent == null;
        _oldContent = null;

        if (!firstNavigation && e.Content is UIElement element)
        {
            Dispatcher.BeginInvoke(() =>
            {
                element.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
            }, DispatcherPriority.Loaded);
        }
    }
}