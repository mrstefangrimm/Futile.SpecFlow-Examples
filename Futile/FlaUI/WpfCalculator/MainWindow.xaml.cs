﻿using System.Windows;

namespace FlaUI.WpfCalculator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(string commandLineArgs)
    {
        InitializeComponent();

        if (!string.IsNullOrEmpty(commandLineArgs))
        {
        Welcome.Content = commandLineArgs;
        }
    }

    private void OnAddClick(object sender, RoutedEventArgs e)
    {
        Result.Text = $"{(double.Parse(First.Text) + double.Parse(Second.Text)):0.00}";
    }

    private void OnSubtractClick(object sender, RoutedEventArgs e)
    {
        Result.Text = $"{(double.Parse(First.Text) - double.Parse(Second.Text)):0.00}";
    }

    private void OnMultiplyClick(object sender, RoutedEventArgs e)
    {
        Result.Text = $"{(double.Parse(First.Text) * double.Parse(Second.Text)):0.00}";
    }

    private void OnDivideClick(object sender, RoutedEventArgs e)
    {
        Result.Text = $"{(double.Parse(First.Text) / double.Parse(Second.Text)):0.00}";
    }
}