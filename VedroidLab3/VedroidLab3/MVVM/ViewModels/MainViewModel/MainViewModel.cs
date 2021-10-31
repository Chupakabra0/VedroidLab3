using System.Windows.Input;
using VedroidLab3.Core.Commands.RelayCommand;

namespace VedroidLab3.MVVM.ViewModels.MainViewModel {
    public class MainViewModel : BaseViewModel.BaseViewModel {
        private static readonly string ResumeText = "Продолжить анимацию";
        private static readonly string PauseText  = "Остановить анимацию";

        public float SpeedAnimation { get; set; } = 1.0f;

        public string ButtonText   { get; set; }  = MainViewModel.PauseText;
        public bool   IsAnimating  { get; set; }  = true;

        public ICommand StartOrStopAnimationCommand =>
            new RelayCommand(() => {
                this.ButtonText     = this.IsAnimating ? MainViewModel.ResumeText : MainViewModel.PauseText;
                
                if (this.IsAnimating) {
                    this.rememberedSpeed = this.SpeedAnimation;
                    this.SpeedAnimation  = 0.0f;
                }
                else {
                    this.SpeedAnimation = this.rememberedSpeed;
                }

                this.IsAnimating    = !this.IsAnimating;
            }
        );

        private float rememberedSpeed;
    }
}
