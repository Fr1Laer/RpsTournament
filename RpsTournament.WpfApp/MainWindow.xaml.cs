using RpsTournament.Core;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RpsTournament.WpfApp
{
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<GameRound> _rounds = new();
        private const int MaxRounds = 5;

        public MainWindow()
        {
            InitializeComponent();

            RoundsDataGrid.ItemsSource = _rounds;
            PlayerMoveComboBox.ItemsSource = Enum.GetValues<Move>();
            PlayerMoveComboBox.SelectedIndex = -1;
        }

        private void PlayRoundButton_Click(object sender, RoutedEventArgs e)
        {
            StatusTextBlock.Text = string.Empty;

            string name = PlayerNameTextBox.Text.Trim();
            if (name.Length < 2 || name.Length > 30)
            {
                StatusTextBlock.Text = Properties.Resources.ErrInvalidName;
                return;
            }

            if (PlayerMoveComboBox.SelectedItem == null)
            {
                StatusTextBlock.Text = Properties.Resources.ErrSelectMove;
                return;
            }
            PlayerNameTextBox.IsEnabled = false;

            Move playerMove = (Move)PlayerMoveComboBox.SelectedItem;
            Move computerMove = GameLogic.GetComputerMove();
            RoundResult result = GameLogic.GetResult(playerMove, computerMove);

            GameRound round = new GameRound
            {
                Number = _rounds.Count + 1,
                PlayerMove = playerMove,
                ComputerMove = computerMove,
                Result = result
            };

            _rounds.Add(round);
            UpdateScore();

            if (_rounds.Count >= MaxRounds)
            {
                PlayRoundButton.IsEnabled = false;

                int playerWins = _rounds.Count(r => r.Result == RoundResult.Win);
                int computerWins = _rounds.Count(r => r.Result == RoundResult.Loss);

                if (playerWins > computerWins)
                {
                    StatusTextBlock.Foreground = System.Windows.Media.Brushes.Green;

                    StatusTextBlock.Text = string.Format(Properties.Resources.MsgTournamentPlayerWon, name);
                }
                else if (computerWins > playerWins)
                {
                    StatusTextBlock.Foreground = System.Windows.Media.Brushes.Red;
                    StatusTextBlock.Text = Properties.Resources.MsgTournamentComputerWon;
                }
                else
                {
                    StatusTextBlock.Foreground = System.Windows.Media.Brushes.Orange;
                    StatusTextBlock.Text = Properties.Resources.MsgTournamentDraw;
                }
            }
        }

        private void NewTournamentButton_Click(object sender, RoutedEventArgs e)
        {
            if (_rounds.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show(
                    Properties.Resources.ConfirmNewTournament,
                    "Uus turniir",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result != MessageBoxResult.Yes)
                {
                    return;
                }
            }

            ResetTournament();
        }

        private void ResetTournament()
        {
            _rounds.Clear();
            UpdateScore();

            PlayerNameTextBox.IsEnabled = true;

            PlayRoundButton.IsEnabled = true;
            StatusTextBlock.Foreground = System.Windows.Media.Brushes.Red;
            StatusTextBlock.Text = string.Empty;
            PlayerNameTextBox.Clear();
            PlayerMoveComboBox.SelectedIndex = -1;
        }

        private void UpdateScore()
        {
            int wins = _rounds.Count(r => r.Result == RoundResult.Win);
            int losses = _rounds.Count(r => r.Result == RoundResult.Loss);
            int draws = _rounds.Count(r => r.Result == RoundResult.Draw);

            ScoreTextBlock.Text = $"Võite: {wins} | Kaotusi: {losses} | Viike: {draws}";
        }
    }
}