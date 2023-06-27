using DXMauiApp1.Pages;

namespace DXMauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ContactCreatePage), typeof(ContactCreatePage));
            Routing.RegisterRoute(nameof(ContactPage), typeof(ContactPage));
            Routing.RegisterRoute(nameof(ContactUpdatePage), typeof(ContactUpdatePage));
            Routing.RegisterRoute(nameof(EmptyPage), typeof(EmptyPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        }
    }
}