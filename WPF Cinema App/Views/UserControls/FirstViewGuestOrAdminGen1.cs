using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPF_Cinema_App.Static_Classes;
using WPF_Cinema_App.Static_File_Helper_Classes;


namespace WPF_Cinema_App.Views.UserControls
{
    public partial class FirstViewGuestOrAdmin : UserControl
    {
        public static bool IsAliGuidedGuest;
        private readonly SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine(new CultureInfo("en-US"));
        private readonly SpeechSynthesizer _Ali = new SpeechSynthesizer();

        private void ChangeResourcesWhenModeChanges(SolidColorBrush windowBackColor, SolidColorBrush nameForeColor, SolidColorBrush buttonBackColor)
        {
            Application.Current.Resources["GuestOrAdminWindowBackgroundColor"] = windowBackColor;
            Application.Current.Resources["TheaterNameForegroundColor"] = nameForeColor;
            Application.Current.Resources["GuestOrAdminButtonBackgroundColor"] = buttonBackColor;
            Application.Current.Resources["GuestOrAdminButtonForegroundColor"] = windowBackColor;
        }

        private void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            if (speech == Modes.NightMode)
            {
                ChangeResourcesWhenModeChanges(new SolidColorBrush(Colors.Black), new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.White));
            }
            else if (speech == Modes.DayMode)
            {
                ChangeResourcesWhenModeChanges(
                     new SolidColorBrush(Colors.White), new SolidColorBrush(Colors.Red), (SolidColorBrush)(new BrushConverter().ConvertFrom("#272727")));
            }
        }

        private void SetRecognizerDatas()
        {
            ObservableCollection<string> grammers = JsonFileHelper.JsonDeserialization<string>("Speech Commands/commands");
            _recognizer.SetInputToDefaultAudioDevice();


            GrammarBuilder grammerBuilder = new GrammarBuilder();
            grammerBuilder.Append(new Choices(grammers.ToArray()), 1, 11);

            _recognizer.LoadGrammarAsync(new Grammar(grammerBuilder));
            _recognizer.SpeechRecognized += Default_SpeechRecognized;
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void SetAliDatasAndSpeak()
        {
            if (IsAliGuidedGuest == false)
            {
                _Ali.SetOutputToDefaultAudioDevice();
                _Ali.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult);
                _Ali.Rate = -1;
                _Ali.Volume = 100;

                _Ali.SpeakAsync($"Hello, My name is Ali, if you want night mode, just say night mode, or if you want day mode, just say day mode.");

                IsAliGuidedGuest = true;
            }
        }

    }

}
