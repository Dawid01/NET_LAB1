using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Lab;

namespace FreeGamesWindow
{
    public class GameAdapter
    {
        private Panel _panel;
        private List<Game> _games;
        private int _itemHeight = 206;
        private int _visibleItems = 0;
        private int _startIndex = 0;
        private int _loadIncrement = 20; 

        public GameAdapter(Panel panel)
        {
            _panel = panel;
            _panel.AutoScroll = true;
            _panel.Scroll += Panel_Scroll;
            _panel.MouseWheel += Panel_MouseWheel;
        }

        public void LoadGames(List<Game> games)
        {
            _games = games;
            UpdateScrollBar();
            LoadVisibleGames();
        }

        private void LoadVisibleGames()
        {
            _panel.Controls.Clear();

            int yPos = 10;
            for (int i = _startIndex; i < _startIndex + _visibleItems && i < _games.Count; i++)
            {
                var gamePanel = CreateGamePanel(_games[i]);
                gamePanel.Location = new Point(10, yPos);
                _panel.Controls.Add(gamePanel);

                yPos += _itemHeight + 10;
            }
        }

        private Panel CreateGamePanel(Game game)
        {
            Panel gamePanel = new Panel();
            gamePanel.BackColor = Color.FromArgb(25, 25, 25);
            gamePanel.Size = new Size(858, _itemHeight);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Load(game.Thumbnail);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(365, 206);
            pictureBox.Location = new Point(0, 0);
            gamePanel.Controls.Add(pictureBox);

            Label lblTitle = CreateLabel(game.Title, new Point(370, 5), Color.White, true, new Size(470, 50), ContentAlignment.TopLeft);
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gamePanel.Controls.Add(lblTitle);

            Label lblDescription = CreateLabel(game.ShortDescription, new Point(370, 60), Color.Gray, false, new Size(470, 50), ContentAlignment.TopLeft);
            gamePanel.Controls.Add(lblDescription);

            Label lblGenre = CreateLabel("Genre: " + game.Genre, new Point(370, 150), Color.White, true, new Size(470, 20), ContentAlignment.TopLeft);
            gamePanel.Controls.Add(lblGenre);

            Label lblPlatform = CreateLabel("Platform: " + game.Platform, new Point(370, 180), Color.White, true, new Size(470, 20), ContentAlignment.TopLeft);
            gamePanel.Controls.Add(lblPlatform);

            Label lblPublisher = CreateLabel("Publisher: " + game.Publisher, new Point(370, 130), Color.White, true, new Size(470, 20), ContentAlignment.TopLeft);
            gamePanel.Controls.Add(lblPublisher);

            Label lblDeveloper = CreateLabel(game.Developer, new Point(370, 35), Color.White, true, new Size(470, 20), ContentAlignment.TopLeft);
            gamePanel.Controls.Add(lblDeveloper);

            Label lblReleaseDate = CreateLabel(game.ReleaseDate, new Point(858 - 88, 5), Color.White, true, new Size(88, 20), ContentAlignment.MiddleRight);
            gamePanel.Controls.Add(lblReleaseDate);

            Button btnPlay = new Button();
            btnPlay.Text = "PLAY";
            btnPlay.BackColor = Color.FromArgb(45, 45, 48);
            btnPlay.ForeColor = Color.White;
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.Location = new Point(858 - 88, 170);
            btnPlay.Size = new Size(80, 30);
            btnPlay.Click += (sender, e) =>
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = game.GameUrl,
                    UseShellExecute = true
                });
            };
            gamePanel.Controls.Add(btnPlay);

            return gamePanel;
        }

        private Label CreateLabel(string text, Point location, Color color, bool autoSize, Size size, ContentAlignment alignment)
        {
            Label label = new Label();
            label.Text = text;
            label.ForeColor = color;
            label.Location = location;
            label.AutoSize = autoSize;
            label.Size = size;
            label.TextAlign = alignment;

            return label;
        }

        private void Panel_Scroll(object sender, ScrollEventArgs e)
        {
            int currentScrollPosition = _panel.VerticalScroll.Value;
            int maximumScrollValue = _panel.VerticalScroll.Maximum - _panel.Height;

            if (currentScrollPosition >= maximumScrollValue)
            {
                _startIndex += _loadIncrement;
                LoadVisibleGames();
            }
            else if (currentScrollPosition == _panel.VerticalScroll.Minimum)
            {
                _startIndex -= _loadIncrement;
                if (_startIndex < 0) _startIndex = 0;
                LoadVisibleGames();
            }
        }

        private void Panel_MouseWheel(object sender, MouseEventArgs e)
        {
            int scrollLines = SystemInformation.MouseWheelScrollLines;

            if (e.Delta > 0 && _panel.VerticalScroll.Value - _panel.VerticalScroll.SmallChange >= _panel.VerticalScroll.Minimum)
            {
                _panel.VerticalScroll.Value -= _panel.VerticalScroll.SmallChange * scrollLines;
            }
            else if (e.Delta < 0 && _panel.VerticalScroll.Value + _panel.VerticalScroll.SmallChange <= _panel.VerticalScroll.Maximum)
            {
                _panel.VerticalScroll.Value += _panel.VerticalScroll.SmallChange * scrollLines;
            }

            int currentScrollPosition = _panel.VerticalScroll.Value;
            int maximumScrollValue = _panel.VerticalScroll.Maximum - _panel.Height;

            if (currentScrollPosition >= maximumScrollValue)
            {
                if (_startIndex + _loadIncrement < _games.Count)
                {
                    _startIndex += _loadIncrement;
                    LoadVisibleGames();
                }
                else
                {
                    _startIndex = _games.Count - _visibleItems;
                    LoadVisibleGames();
                }
            }
            else if (currentScrollPosition == _panel.VerticalScroll.Minimum)
            {
                _startIndex -= _loadIncrement;
                if (_startIndex < 0) _startIndex = 0;
                LoadVisibleGames();
                _panel.VerticalScroll.Value = _panel.VerticalScroll.Maximum - _panel.Height; 
            }
        }



        private void UpdateScrollBar()
        {
            int totalHeight = _games.Count * (_itemHeight + 10);
            _visibleItems = _panel.Height / (_itemHeight + 10) + _loadIncrement;
            _panel.VerticalScroll.Maximum = totalHeight;
        }
    }
}
