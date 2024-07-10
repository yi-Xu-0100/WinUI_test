using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using WinUI_test.Core.Models;

namespace WinUI_test.Views;

public sealed partial class P2DetailControl : UserControl
{
    public SampleOrder? ListDetailsMenuItem
    {
        get => GetValue(ListDetailsMenuItemProperty) as SampleOrder;
        set => SetValue(ListDetailsMenuItemProperty, value);
    }

    public static readonly DependencyProperty ListDetailsMenuItemProperty = DependencyProperty.Register("ListDetailsMenuItem", typeof(SampleOrder), typeof(P2DetailControl), new PropertyMetadata(null, OnListDetailsMenuItemPropertyChanged));

    public P2DetailControl()
    {
        InitializeComponent();
    }

    private static void OnListDetailsMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is P2DetailControl control)
        {
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
