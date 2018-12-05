using System;
using System.Diagnostics;
using Xamarin.Forms;
using XamarinFormsApp.Models;

namespace XamarinFormsApp.Views
{
    public class UserListPageCS : ContentPage
    {
        ListView listView;

        public UserListPageCS()
        {
            Title = "User";

            var toolbarItem = new ToolbarItem
            {
                Text = "+",
                Icon = Device.RuntimePlatform == Device.iOS ? null : "plus.png"
            };
            toolbarItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new UserItemPageCS
                {
                    BindingContext = new UserItem()
                });
            };
            ToolbarItems.Add(toolbarItem);

            listView = new ListView
            {
                Margin = new Thickness(20),
                ItemTemplate = new DataTemplate(() =>
                {
                    var label = new Label
                    {
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.StartAndExpand
                    };
                    label.SetBinding(Label.TextProperty, "Name");
                    var Notelabel = new Label
                    {
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.StartAndExpand
                    };
                    Notelabel.SetBinding(Label.TextProperty, "Notes");

                  
                    var stackLayout = new StackLayout
                    {
                        Margin = new Thickness(20, 0, 0, 0),
                        Orientation = StackOrientation.Vertical,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { label, Notelabel }
                    };

                    return new ViewCell { View = stackLayout };
                })
            };
            listView.ItemSelected += async (sender, e) =>
            {
              

                if (e.SelectedItem != null)
                {
                    await Navigation.PushAsync(new UserItemPageCS
                    {
                        BindingContext = e.SelectedItem as UserItem
                    });
                }
            };

            Content = listView;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }
    }
}
