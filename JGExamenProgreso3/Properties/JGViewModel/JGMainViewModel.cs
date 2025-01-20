using JGExamenProgreso3.Properties.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace JGExamenProgreso3.Properties.JGViewModel
{
    public class JGMainViewModel : INotifyPropertyChanged
    {
        private readonly JGBookService _booksService;

        private string _searchQuery;
        private bool _isBusy;
        private ObservableCollection<JGBookModel> _books;

        public JGMainViewModel()
        {
            _booksService = new JGBookService();
            Books = new ObservableCollection<JGBookModel>();
            SearchCommand = new Command(async () => await SearchBooksAsync());
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set => SetProperty(ref _searchQuery, value);
        }

        public ObservableCollection<JGBookModel> Books
        {
            get => _books;
            set => SetProperty(ref _books, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public ICommand SearchCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value)) return false;

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private async Task SearchBooksAsync()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery)) return;

            IsBusy = true;
            Books.Clear();

            var books = await _booksService.SearchBooksAsync(SearchQuery);
            foreach (var book in books)
            {
                Books.Add(book);
            }

            IsBusy = false;
        }
    }
}
