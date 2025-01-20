
using JGExamenProgreso3.Properties.Model;

namespace JGExamenProgreso3

{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnBookSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is JGBookModel selectedBook)
            {
                await Navigation.PushAsync(new JGBooksDetails(selectedBook));
            }
        }
    }
}
