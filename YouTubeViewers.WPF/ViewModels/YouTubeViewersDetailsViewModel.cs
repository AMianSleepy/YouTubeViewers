using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.WPF.Models;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
    public class YouTubeViewersDetailsViewModel : ViewModelBase
    {
        private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;
        private YouTubeViewer SelectedYouTubeViewers => _selectedYouTubeViewerStore.SelectedYouTubeViewer;

        /// <summary>
        /// 页面是否被选中
        /// </summary>
        public bool HasSelectedYouTubeViewers => SelectedYouTubeViewers != null;
        public string Username => SelectedYouTubeViewers?.Username ?? "Unknown";
        public string IsSubscribedDisplay => (SelectedYouTubeViewers?.IsSubscribed ?? false) ? "Yes" : "No";
        public string IsMemberDisplay => (SelectedYouTubeViewers?.IsMember ?? false) ? "Yes" : "No";

        public YouTubeViewersDetailsViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore)
        {
            _selectedYouTubeViewerStore = selectedYouTubeViewerStore;

            _selectedYouTubeViewerStore.SelectedYouTubeViewerChanged += SelectedYouTubeViewerStore_SelectedYouTubeViewerChanged;
        }

        protected override void Dispose()
        {
            _selectedYouTubeViewerStore.SelectedYouTubeViewerChanged -= SelectedYouTubeViewerStore_SelectedYouTubeViewerChanged;

            base.Dispose();
        }

        private void SelectedYouTubeViewerStore_SelectedYouTubeViewerChanged()
        {
            OnPropertyChanged(nameof(HasSelectedYouTubeViewers));
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(IsSubscribedDisplay));
            OnPropertyChanged(nameof(IsMemberDisplay));
        }
    }
}
