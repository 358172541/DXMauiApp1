﻿using CommunityToolkit.Maui;
using DevExpress.Maui;

namespace DXMauiApp1
{
    public static class Program
    {
        public static MauiApp CreateMauiApp()
        {
            var budr = MauiApp.CreateBuilder();

            budr.UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseDevExpress();

            DevExpress.Maui.Charts.Initializer.Init();
            DevExpress.Maui.CollectionView.Initializer.Init();
            DevExpress.Maui.Controls.Initializer.Init();
            DevExpress.Maui.DataGrid.Initializer.Init();
            DevExpress.Maui.Editors.Initializer.Init();
            DevExpress.Maui.Scheduler.Initializer.Init();

            return budr.Build();
        }
    }
}