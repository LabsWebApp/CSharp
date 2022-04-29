using System;
using System.Windows;
using System.Windows.Controls;

namespace Delegate.Events.Wpf.MVP;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DoItButton.Click += DoItButton_Click;
        var _ = new Presenter(this);
    }

    public event EventHandler? DoItButtonClickEvent;

    private void DoItButton_Click(object sender, RoutedEventArgs e)
    {
        if(sender is not Button {Name: nameof(DoItButton) } button) return;

        DoItButtonClickEvent?.Invoke(button, e); 
    }
}