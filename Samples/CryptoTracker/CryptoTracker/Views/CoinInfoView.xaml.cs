﻿using CryptoTracker.Data;
using CryptoTracker.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.Linq;
using Telerik.XamarinForms.Chart;
using Telerik.XamarinForms.Common;

namespace CryptoTracker.Views
{
    public partial class CoinInfoView : ContentView
    {
        public CoinInfoView()
        {
            this.InitializeComponent();
        }

        public void InitializeCoinData(CoinData coinInfo)
        {
            var viewModel = (CoinInfoViewModel)this.BindingContext;
            viewModel.InitializeCoinData(coinInfo);

        }

        private void RadCartesianChart_HandlerChanged(object sender, System.EventArgs e)
        {
#if WINDOWS
            var handler = ((RadCartesianChart)sender).Handler;
            if (handler != null)
            {
                var nativeRenderer = handler.NativeView as Telerik.XamarinForms.ChartRenderer.UWP.CartesianChartRenderer;
                if (nativeRenderer != null)
                {
                    var nativeChart = nativeRenderer.Control;
                    var trackBallBehavior = nativeChart.Behaviors.FirstOrDefault(a => a.GetType() == typeof(Telerik.UI.Xaml.Controls.Chart.ChartTrackBallBehavior)) as Telerik.UI.Xaml.Controls.Chart.ChartTrackBallBehavior;
                    if (trackBallBehavior != null)
                    {
                        var nativeApp = MauiWinUIApplication.Current;
                        var trackBallCustomTemplate = nativeApp.Resources["CustomTrackBallTemplate"] as Microsoft.UI.Xaml.DataTemplate;
                        Telerik.UI.Xaml.Controls.Chart.ChartTrackBallBehavior.SetTrackInfoTemplate(nativeChart.Series[0], trackBallCustomTemplate);
                    }
                }
            }
#endif
        }
    }

}