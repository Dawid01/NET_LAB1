using System.Diagnostics;
using Lab;

namespace FreeGamesWindow;

public class GameAdapter
{
    private Panel _panel;
    private VScrollBar _scrollBar;
    private List<Game> _games;
    private int _visibleItems = 0;
    private int _startIndex = 0;
    private int _itemHeight = 206;

    public GameAdapter(Panel panel, VScrollBar scrollBar)
    {
        _panel = panel;
        _scrollBar = scrollBar;
        _scrollBar.Scroll += ScrollBar_Scroll;
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

        Label lblTitle = new Label();
        lblTitle.Text = game.Title;
        lblTitle.ForeColor = Color.White;
        lblTitle.BackColor = Color.Transparent;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        lblTitle.AutoSize = true;
        lblTitle.Location = new Point(370, 5); 
        gamePanel.Controls.Add(lblTitle);

        Label lblDescription = new Label();
        lblDescription.Text = game.ShortDescription;
        lblDescription.ForeColor = Color.Gray;
        lblDescription.AutoSize = false;
        lblDescription.Size = new Size(470, 50);
        lblDescription.MaximumSize = new Size(470, 50);
        //lblDescription.BorderStyle = BorderStyle.FixedSingle;
        lblDescription.Location = new Point(370, 60);
        gamePanel.Controls.Add(lblDescription);

        Label lblGenre = new Label();
        lblGenre.Text = "Genre: " + game.Genre;
        lblGenre.ForeColor = Color.White;
        lblGenre.AutoSize = true;
        lblGenre.Location = new Point(370, 150);  
        gamePanel.Controls.Add(lblGenre);

        Label lblPlatform = new Label();
        lblPlatform.Text = "Platform: " + game.Platform;
        lblPlatform.ForeColor = Color.White;
        lblPlatform.AutoSize = true;
        lblPlatform.Location = new Point(370, 180); 
        gamePanel.Controls.Add(lblPlatform);

        Label lblPublisher = new Label();
        lblPublisher.Text = "Publisher: " + game.Publisher;
        lblPublisher.ForeColor = Color.White;
        lblPublisher.AutoSize = true;
        lblPublisher.Location = new Point(370, 130); 
        gamePanel.Controls.Add(lblPublisher);

        Label lblDeveloper = new Label();
        lblDeveloper.Text = game.Developer;
        lblDeveloper.ForeColor = Color.White;
        lblDeveloper.AutoSize = true;
        lblDeveloper.Location = new Point(370, 35); 
        gamePanel.Controls.Add(lblDeveloper);

        Label lblReleaseDate = new Label();
        lblReleaseDate.Text = game.ReleaseDate;
        lblReleaseDate.ForeColor = Color.White;
        lblReleaseDate.TextAlign = ContentAlignment.MiddleRight;
        lblReleaseDate.AutoSize = true;
        lblReleaseDate.Location = new Point(858 - 88, 5); 
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
            System.Diagnostics.Process.Start(new ProcessStartInfo()
            {
                FileName = game.GameUrl,
                UseShellExecute = true
            });
        };
        gamePanel.Controls.Add(btnPlay);

        return gamePanel;
    }

    private Label CreateLabel(string text, Point location, Color color, bool autoSize)
    {
        Label label = new Label();
        label.Text = text;
        label.ForeColor = color;
        label.Location = location;
        label.AutoSize = autoSize;

        return label;
    }

    private void ScrollBar_Scroll(object sender, ScrollEventArgs e)
    {
        _startIndex = e.NewValue / (_itemHeight + 10);
        LoadVisibleGames();
    }

    private void UpdateScrollBar()
    {
        int totalHeight = _games.Count * (_itemHeight + 10);
        _visibleItems = _panel.Height / (_itemHeight + 10) + 1;
        _scrollBar.Minimum = 0;
        _scrollBar.Maximum = totalHeight - _panel.Height + (_itemHeight + 10);
        _scrollBar.LargeChange = _visibleItems * (_itemHeight + 10);
        _scrollBar.SmallChange = _itemHeight + 10;
        _scrollBar.Value = _startIndex * (_itemHeight + 10);
    }            
}