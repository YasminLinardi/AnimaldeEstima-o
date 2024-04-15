using Microsoft.Maui.Controls;
using System;

namespace Gatin
{
    public partial class MainPage : ContentPage
    {
        int brincarBtnCount = 10; 
        int comerBtnCount = 10;
        int beberBtnCount = 10; 
        readonly int initialProgress = 10; 
        readonly int progressDecreaseInterval = 2000; 
        private bool isTimerRunning = false;

        [Obsolete]
        public MainPage()
        {
            InitializeComponent();

            
            InitializeProgressBars();

           
            StartProgressDecreaseTimer();
        }

        private void InitializeProgressBars()
        {
            BrincarProgressBar.Progress = (double)initialProgress / 10;
            ComerProgressBar.Progress = (double)initialProgress / 10;
            BeberProgressBar.Progress = (double)initialProgress / 10;
        }

        [Obsolete]
        private void StartProgressDecreaseTimer()
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(progressDecreaseInterval), () =>
            {
               
                if (brincarBtnCount > 0)
                {
                    brincarBtnCount--;
                    UpdateProgressBar(BrincarProgressBar, brincarBtnCount);
                }

                if (comerBtnCount > 0)
                {
                    comerBtnCount--;
                    UpdateProgressBar(ComerProgressBar, comerBtnCount);
                }

                if (beberBtnCount > 0)
                {
                    beberBtnCount--;
                    UpdateProgressBar(BeberProgressBar, beberBtnCount);
                }

               
                if (brincarBtnCount == 0 && comerBtnCount == 0 && beberBtnCount == 0)
                {
                  
                    Navigation.PushAsync(new MortePage(this));
                    
                    return false;
                }

                return true;
            });

            isTimerRunning = true;
        }

        private void UpdateProgressBar(ProgressBar progressBar, int count)
        {
            double progress = (double)count / 10;
            progressBar.Progress = progress;
        }

        private void OnBrincarClicked(object sender, EventArgs e)
        {
            brincarBtnCount = Math.Min(brincarBtnCount + 1, initialProgress); 
            UpdateProgressBar(BrincarProgressBar, brincarBtnCount);
        }

        private void OnComerClicked(object sender, EventArgs e)
        {
            comerBtnCount = Math.Min(comerBtnCount + 1, initialProgress); 
            UpdateProgressBar(ComerProgressBar, comerBtnCount);
        }

        private void OnBeberClicked(object sender, EventArgs e)
        {
            beberBtnCount = Math.Min(beberBtnCount + 1, initialProgress); 
            UpdateProgressBar(BeberProgressBar, beberBtnCount);
        }

        
        [Obsolete]
        public void Restart()
        {
            
            brincarBtnCount = initialProgress;
            comerBtnCount = initialProgress;
            beberBtnCount = initialProgress;

           
            InitializeProgressBars();

            
            StartProgressDecreaseTimer();
        }




    }


}
