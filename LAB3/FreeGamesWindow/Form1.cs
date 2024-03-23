using Lab;

namespace FreeGamesWindow;

public partial class Form1 : Form
{
    private ClientAPI _client;
    private int _selectedCount = 0;
    
    private List<string> _gameCategories = new List<string>
    {
        "mmorpg", "shooter", "strategy", "moba", "racing", "sports", "social", "sandbox",
        "open-world", "survival", "pvp", "pve", "pixel", "voxel", "zombie", "turn-based",
        "first-person", "third-Person", "top-down", "tank", "space", "sailing",
        "side-scroller", "superhero", "permadeath", "card", "battle-royale", "mmo",
        "mmofps", "mmotps", "3d", "2d", "anime", "fantasy", "sci-fi", "fighting",
        "action-rpg", "action", "military", "martial-arts", "flight", "low-spec",
        "tower-defense", "horror", "mmorts"
    };
    private List<string> _platforms = new List<string> { "PC", "BROWSER" };

    private List<CheckBox> _categoryCheckBoxes = new List<CheckBox>();
    private List<CheckBox> _platformCheckBoxes = new List<CheckBox>();

    public Form1()
    {
        _client = ClientAPI.Instance;
        InitializeComponent();
        InitializeGameCategories();
        InitializePlatforms();
        this.Size = new System.Drawing.Size(1000, 800);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        labelSelectedCount.Text = $"Selected: {_selectedCount}" + " / " + _gameCategories.Count;

    }

    private void InitializeGameCategories()
    {
        int xPos = 0;
        int yPos = 10;

        foreach (var category in _gameCategories)
        {
            CheckBox cb = new CheckBox();
            cb.TextAlign = ContentAlignment.MiddleLeft;
            cb.Text = category.ToUpper();
            cb.AutoSize = true;
            cb.ForeColor = System.Drawing.Color.White;
            cb.FlatStyle = FlatStyle.Flat;
            cb.AutoSize = false;
            cb.Size = new System.Drawing.Size(211, 25);
            cb.Padding = new Padding(10, 0, 0, 0);
            cb.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            cb.Location = new System.Drawing.Point(xPos, yPos);
            yPos += 30;
            
            cb.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            _categoryCheckBoxes.Add(cb);
            this.panelCategories.Controls.Add(cb);
        }

        this.panelCategories.AutoScroll = true;
    }
    
    private void InitializePlatforms()
    {
        int xPos = 2;
        int yPos = 570;

        foreach (var platform in _platforms)
        {
            CheckBox cb = new CheckBox();
            cb.Text = platform;
            cb.AutoSize = true;
            cb.ForeColor = System.Drawing.Color.White;
            cb.FlatStyle = FlatStyle.Flat;
            cb.AutoSize = false;
            cb.Padding = new Padding(15, 0, 0, 0);
            cb.Size = new System.Drawing.Size(252, 25);
            cb.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            //cb.BackColor = System.Drawing.Color.Transparent;
            cb.Location = new System.Drawing.Point(xPos, yPos);
            yPos += 30;

            cb.CheckedChanged += new System.EventHandler(this.platformCb_CheckedChanged);
            _platformCheckBoxes.Add(cb);
            this.Controls.Add(cb); 
        }
    }

    
    private void cb_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cb = sender as CheckBox;

        if (cb.Checked)
        {
            cb.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
            _selectedCount++;
        }
        else
        {
            cb.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            _selectedCount--;
        }

        labelSelectedCount.Text = $"Selected: {_selectedCount}" + " / " + _gameCategories.Count;
    }
    
    private void platformCb_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cb = sender as CheckBox;

        if (cb.Checked)
        {
            cb.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
        }
        else
        {   
            cb.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
        }

        labelSelectedCount.Text = $"Selected: {_selectedCount}" + " / " + _gameCategories.Count;
    }
    
    private async void btnSearch_Click(object sender, EventArgs e)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = cancellationTokenSource.Token;

        try
        {
            await Search(cancellationToken);
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("Search was canceled.");
        }
    }
    
    private void btnClear_Click(object sender, EventArgs e)
    {
        foreach (var cb in _categoryCheckBoxes)
        {
            cb.Checked = false;
        }
        
        foreach (var cb in _platformCheckBoxes)
        {
            cb.Checked = false;
        }
    }

    private async Task Search(CancellationToken cancellationToken)
    {
        string query = "/games";

        if (_selectedCount > 0)
        {
            List<string> selectedCategories = new List<string>();
            for (int i = 0; i < _categoryCheckBoxes.Count; i++)
            {
                if (_categoryCheckBoxes[i].Checked)
                {
                    selectedCategories.Add(_gameCategories[i]);
                }
            }

            if (selectedCategories.Count > 0)
            {
                query += "?category=" + string.Join(",", selectedCategories);
            }
        }

        try
        {
            await _client.Call<List<Game>>(
                query,
                OnSuccessful: async (body, response) =>
                {
                    if (response.IsSuccessStatusCode)
                    {
                        LoadGames(body);
                    }
                    else
                    {
                        Console.WriteLine("RESPONSE CODE: " + response.StatusCode);
                    }
                },
                OnFailure: () =>
                {
                    Console.WriteLine("Connection failure");
                },
                cancellationToken: cancellationToken);
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("Search was canceled.");
        }
    }


    void LoadGames(List<Game> games)
    {
        panelResults.Controls.Clear();

        int xPos = 10;
        int yPos = 10;
        int contentHeight = 0; 

        foreach (var game in games)
        {
            Panel gamePanel = new Panel();
            gamePanel.BackColor = Color.FromArgb(25, 25, 25);  
            gamePanel.Size = new Size(760, 206);
            gamePanel.Location = new Point(xPos, yPos);
            panelResults.Controls.Add(gamePanel);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Load(game.Thumbnail);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(365, 206);
            pictureBox.Location = new Point(0, 0);  
            gamePanel.Controls.Add(pictureBox);

            Label lblTitle = new Label();
            lblTitle.Text = game.Title;
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(370, 10); 
            gamePanel.Controls.Add(lblTitle);

            Label lblDescription = new Label();
            lblDescription.Text = game.ShortDescription;
            lblDescription.ForeColor = Color.Gray;
            lblDescription.AutoSize = false;
            lblDescription.Size = new Size(365, 150);
            lblDescription.MaximumSize = new Size(340, 100);
            lblDescription.BorderStyle = BorderStyle.FixedSingle;
            lblDescription.Location = new Point(370, 40);
            gamePanel.Controls.Add(lblDescription);

            Label lblGenre = new Label();
            lblGenre.Text = "Genre: " + game.Genre;
            lblGenre.ForeColor = Color.White;
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(370, 70);  
            gamePanel.Controls.Add(lblGenre);

            Label lblPlatform = new Label();
            lblPlatform.Text = "Platform: " + game.Platform;
            lblPlatform.ForeColor = Color.White;
            lblPlatform.AutoSize = true;
            lblPlatform.Location = new Point(370, 180); 
            gamePanel.Controls.Add(lblPlatform);

            yPos += 206 + 10;
            contentHeight = yPos;
        }
        VScrollBar vScrollBar = new VScrollBar();
        vScrollBar.Dock = DockStyle.Right;
        vScrollBar.Scroll += (sender, e) => { panelResults.VerticalScroll.Value = vScrollBar.Value; };
        vScrollBar.Maximum = contentHeight - panelResults.ClientSize.Height;
        panelResults.Controls.Add(vScrollBar);
        panelResults.AutoScroll = false;
        panelResults.VerticalScroll.Visible = false;
    }


    public class GameAdapter
    {
        private Panel _panel;

        public GameAdapter(Panel panel)
        {
            _panel = panel;
        }

        public void LoadGames(List<Game> games)
        {
            _panel.Controls.Clear();

            int yPos = 10;
            foreach (var game in games)
            {
                var gamePanel = CreateGamePanel(game);
                gamePanel.Location = new Point(10, yPos);
                _panel.Controls.Add(gamePanel);

                yPos += gamePanel.Height + 10;
            }
        }

        private Panel CreateGamePanel(Game game)
        {
            Panel panel = new Panel();
            panel.Size = new Size(750, 206);
            panel.BackColor = Color.FromArgb(64, 64, 64);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Load(game.Thumbnail);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(365, 206);
            pictureBox.Location = new Point(0, 0);
            panel.Controls.Add(pictureBox);

            Label lblTitle = CreateLabel(game.Title, new Point(370, 0), Color.White, true);
            panel.Controls.Add(lblTitle);

            Label lblDescription = CreateLabel(game.ShortDescription, new Point(370, 40), Color.Gray, false);
            lblDescription.Size = new Size(365, 150);
            lblDescription.MaximumSize = new Size(365, 0);
            lblDescription.BorderStyle = BorderStyle.FixedSingle;
            panel.Controls.Add(lblDescription);

            Label lblGenre = CreateLabel("Genre: " + game.Genre, new Point(370, 190), Color.White, true);
            panel.Controls.Add(lblGenre);

            Label lblPlatform = CreateLabel("Platform: " + game.Platform, new Point(370, 215), Color.White, true);
            panel.Controls.Add(lblPlatform);

            return panel;
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
    }
}