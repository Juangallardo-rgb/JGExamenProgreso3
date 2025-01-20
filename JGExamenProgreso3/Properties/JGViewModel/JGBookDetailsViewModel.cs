using JGExamenProgreso3.Properties.Model;

namespace JGExamenProgreso3.Properties.JGViewModel
{
    public class JGBookDetailsViewModel
    {
        public JGBookModel Book { get; }

        public JGBookDetailsViewModel(JGBookModel book)
        {
            Book = book;
        }
    }
}

