using Xamarin.Forms;
using XamarinFormsApp.Models;

namespace XamarinFormsApp.Views
{
    public class UserItemPageCS : ContentPage
    {
        public UserItemPageCS()
        {
            Title = "User Item";

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            var notesEntry = new Entry();
            notesEntry.SetBinding(Entry.TextProperty, "Notes");

            var passwordEntry = new Entry();
            passwordEntry.SetBinding(Entry.TextProperty, "Password");


            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var userItem = (UserItem)BindingContext;
                await App.Database.SaveItemAsync(userItem);
                await Navigation.PopAsync();
            };

            //var deleteButton = new Button { Text = "Delete" };
            //deleteButton.Clicked += async (sender, e) =>
            //{
            //    var userItem = (UserItem)BindingContext;
            //    await App.Database.DeleteItemAsync(userItem);
            //    await Navigation.PopAsync();
            //};

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Name" },
                    nameEntry,
                    new Label { Text = "Notes" },
                    notesEntry,
                    new Label { Text = "Enter Password" },
                    passwordEntry,
                  //  new Label { Text = "Done" },
                  //  doneSwitch,
                    saveButton,
                  // deleteButton,
                    cancelButton
                }
            };
        }
    }
}
