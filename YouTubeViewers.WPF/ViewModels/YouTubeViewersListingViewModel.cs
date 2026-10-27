using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.WPF.Models;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
    public class YouTubeViewersListingViewModel : ViewModelBase
    {
        public SelectedYouTubeViewerStore _selectedYouTubeViewerStore { get; set; }
        // ObservableCollection<T> 和普通 List<T> 的区别：往集合里加/删元素时，它会主动通知界面刷新，List<T> 不会。
        private readonly ObservableCollection<YouTubeViewersListingItemViewModel> _youTubeViewersListingItemViewModels;
        public IEnumerable<YouTubeViewersListingItemViewModel> YouTubeViewersListingItemViewModel => _youTubeViewersListingItemViewModels;

        private YouTubeViewersListingItemViewModel _selectedYouTubeViewerListingItemViewModel;
        public YouTubeViewersListingItemViewModel SelectedYouTubeViewerListingItemViewModel
        {
            get { return _selectedYouTubeViewerListingItemViewModel; }
            set
            { 
                _selectedYouTubeViewerListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedYouTubeViewerListingItemViewModel));

                _selectedYouTubeViewerStore.SelectedYouTubeViewer = _selectedYouTubeViewerListingItemViewModel?.YouTubeViewer;
            }
        }


        public YouTubeViewersListingViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore)
        {
            _selectedYouTubeViewerStore = selectedYouTubeViewerStore;

            _youTubeViewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>
            {
                new (new YouTubeViewer("Mary", true, false)),
                new (new YouTubeViewer("Sean", false, true)),
                new (new YouTubeViewer("Alan", true, false)),
            };
        }
    }
}
