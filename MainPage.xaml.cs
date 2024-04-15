using Microsoft.Maui.Controls;
using System;

namespace Gatin
{
    public partial class MainPage : ContentPage
    {
        int brincarBtnCount = 10; // Inicializando com o valor inicial
        int comerBtnCount = 10; // Inicializando com o valor inicial
        int beberBtnCount = 10; // Inicializando com o valor inicial
        readonly int initialProgress = 10; // Valor inicial da barra de progresso
        readonly int progressDecreaseInterval = 2000; // Intervalo de diminuição da barra de progresso em milissegundos
        private bool isTimerRunning = false;

        [Obsolete]
        public MainPage()
        {
            InitializeComponent();

            // Configurar os valores iniciais das barras de progresso
            InitializeProgressBars();

            // Iniciar o temporizador de diminuição das barras de progresso
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
                // Decrementar os contadores e atualizar as barras de progresso
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

                // Verificar se todos os contadores chegaram a 0
                if (brincarBtnCount == 0 && comerBtnCount == 0 && beberBtnCount == 0)
                {
                    // Redirecionar para a página de morte
                    Navigation.PushAsync(new MortePage(this)); // Passar uma referência desta página para a MortePage
                    // Parar o temporizador
                    return false;
                }

                return true; // Continuar o temporizador
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
            brincarBtnCount = Math.Min(brincarBtnCount + 1, initialProgress); // Incrementar o contador, limitando a 10
            UpdateProgressBar(BrincarProgressBar, brincarBtnCount);
        }

        private void OnComerClicked(object sender, EventArgs e)
        {
            comerBtnCount = Math.Min(comerBtnCount + 1, initialProgress); // Incrementar o contador, limitando a 10
            UpdateProgressBar(ComerProgressBar, comerBtnCount);
        }

        private void OnBeberClicked(object sender, EventArgs e)
        {
            beberBtnCount = Math.Min(beberBtnCount + 1, initialProgress); // Incrementar o contador, limitando a 10
            UpdateProgressBar(BeberProgressBar, beberBtnCount);
        }

        // Método para reiniciar a página principal
        [Obsolete]
        public void Restart()
        {
            // Reinicializar os contadores
            brincarBtnCount = initialProgress;
            comerBtnCount = initialProgress;
            beberBtnCount = initialProgress;

            // Reinicializar as barras de progresso
            InitializeProgressBars();

            // Reiniciar o temporizador
            StartProgressDecreaseTimer();
        }




    }


}
