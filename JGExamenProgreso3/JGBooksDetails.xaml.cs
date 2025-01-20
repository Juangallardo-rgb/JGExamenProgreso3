using JGExamenProgreso3.Properties.Model;
using JGExamenProgreso3.Properties.JGViewModel;

namespace JGExamenProgreso3;
public partial class JGBooksDetails : ContentPage
{
    public JGBooksDetails(JGBookModel book)
    {
        InitializeComponent();
        BindingContext = new JGBookDetailsViewModel(book);
    }
}