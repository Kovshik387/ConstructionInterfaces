using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.Media.Protection.PlayReady;

namespace ClientAccounting.MAUI.ViewModel.ReviewVm
{
    public class ReviewView : INotifyPropertyChanged
    {
        private readonly IReviewService _reviewService;

        public event PropertyChangedEventHandler PropertyChanged;

        public Review Review { get; set; } = new() {Message = "" };

        public ReviewView(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public void ResetView() => this.Review = new Review();

        public async Task<Review> GetReview(int id) => await _reviewService.GetReview(id, int.Parse(await SecureStorage.Default.GetAsync("id_user")));

        public void AddReview() => _reviewService.AddReview(this.Review);

        public int Rating 
        { 
            get => Review.Rating; set
            {
                if (Review.Rating != value && value > 0 && value < 6)
                {
                    Review.Rating = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Message 
        { get => Review.Message; set 
            {
                if (Review.Message != value && value is not null)
                {
                    Review.Message = value;
                    OnPropertyChanged();
                }
            } 
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
