using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeViewers.WPF.ViewModels
{
    public class YouTubeViewersListingViewModel
    {
        // ObservableCollection<T> 和普通 List<T> 的区别：往集合里加/删元素时，它会主动通知界面刷新，List<T> 不会。
        private readonly ObservableCollection<YouTubeViewersListingItemViewModel> _youTubeViewersListingItemViewModels;
        public IEnumerable<YouTubeViewersListingItemViewModel> YouTubeViewersListingItemViewModel => _youTubeViewersListingItemViewModels;

        public YouTubeViewersListingViewModel()
        {
            _youTubeViewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>
            {
                new("Mary"),
                new("Sean"),
                new("Alan")
            };
        }
    }
}
