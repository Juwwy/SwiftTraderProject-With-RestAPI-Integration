using SwiftTradersProject.Models;
using SwiftTraderPRoject.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SwiftTraderPRoject.ViewModels
{
    public class OnBoardingViewModel : BaseViewModel
    {
        private ObservableCollection<OnBoardingModel> presentations;
        public ObservableCollection<OnBoardingModel> Presentations
        {
            get { return presentations; }
            set { presentations = value; OnPropertyChanged(); }
        }

        public OnBoardingViewModel()
        {
            Presentations = new ObservableCollection<OnBoardingModel>()
            {
                new OnBoardingModel()
                {
                    ImgUrl = "img1.jpg",
                    Title = "Purchase now Available on net",
                    Content = "Get all product ultimaltely completed online, no stress shopping around to get your needs. Everything done at a wink"
                },
                new OnBoardingModel()
                {
                    ImgUrl = "img3.jpg",
                    Title = "Together we can make life easy",
                    Content = "It is no more news on how slow you get recent orders. Glad to have you here, have a new experience"
                },
                new OnBoardingModel()
                {
                    ImgUrl = "img4.jpg",
                    Title = "Fast delivery accuracy on Goal",
                    Content = "Able and efficient dispatchers bring your product at a glimpse. That what swifters do, always to get your smile"
                },
            };
        }
    }
}
