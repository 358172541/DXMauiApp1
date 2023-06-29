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

            Routing.RegisterRoute(nameof(Packag1120UpdatePage), typeof(Packag1120UpdatePage));
            Routing.RegisterRoute(nameof(ReceiptMakeupPage), typeof(ReceiptMakeupPage));
            Routing.RegisterRoute(nameof(VoyagePage), typeof(VoyagePage));
            Routing.RegisterRoute(nameof(VoyagePackagPage), typeof(VoyagePackagPage));
            Routing.RegisterRoute(nameof(VoyagePackagDetectPage), typeof(VoyagePackagDetectPage));
        }
    }
}