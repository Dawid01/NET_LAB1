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
            PictureBox pictureBox = new PictureBox();
            pictureBox.Load(game.Thumbnail);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(365, 206);
            pictureBox.Location = new Point(xPos, yPos);
            panelResults.Controls.Add(pictureBox);

            Label lblTitle = new Label();
            lblTitle.Text = game.Title;
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(xPos + 110, yPos);
            panelResults.Controls.Add(lblTitle);

            Label lblDescription = new Label();
            lblDescription.Text = game.ShortDescription;
            lblDescription.ForeColor = Color.Gray;
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(xPos + 110, yPos + 30);
            panelResults.Controls.Add(lblDescription);

            Label lblGenre = new Label();
            lblGenre.Text = "Genre: " + game.Genre;
            lblGenre.ForeColor = Color.White;
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(xPos + 110, yPos + 60);
            panelResults.Controls.Add(lblGenre);

            Label lblPlatform = new Label();
            lblPlatform.Text = "Platform: " + game.Platform;
            lblPlatform.ForeColor = Color.White;
            lblPlatform.AutoSize = true;
            lblPlatform.Location = new Point(xPos + 110, yPos + 90);
            panelResults.Controls.Add(lblPlatform);

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
}