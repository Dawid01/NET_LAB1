using Lab;

namespace FreeGamesWindow;

public partial class Form1 : Form
{
    private ClientAPI _client;
    private GamesDb _gamesDb;
    private int _selectedCount = 0;
    private GameAdapter _gameAdapter;

    /*private List<string> _gameCategories = new List<string>
    {
        "mmorpg", "shooter", "strategy", "moba", "racing", "sports", "social", "sandbox",
        "open-world", "survival", "pvp", "pve", "pixel", "voxel", "zombie", "turn-based",
        "first-person", "third-Person", "top-down", "tank", "space", "sailing",
        "side-scroller", "superhero", "permadeath", "card", "battle-royale", "mmo",
        "mmofps", "mmotps", "3d", "2d", "anime", "fantasy", "sci-fi", "fighting",
        "action-rpg", "action", "military", "martial-arts", "flight", "low-spec",
        "tower-defense", "horror", "mmorts"
    };*/
    private List<string> _gameCategories = new List<string>
    {
        "mmorpg", "shooter", "mmo", "social", "card",
        "moba", "strategy", "fighting", "racing", "sports",
        "fantasy", "battle royale", "action rpg", "action"
    };
    private List<string> _platforms = new List<string> { "PC", "BROWSER" };

    private List<CheckBox> _categoryCheckBoxes = new List<CheckBox>();
    private List<CheckBox> _platformCheckBoxes = new List<CheckBox>();

    public Form1()
    {
        _client = ClientAPI.Instance;
        _gamesDb = new GamesDb();
        InitializeComponent();
        _gameAdapter = new GameAdapter(panelResults, labelPageInfo);
        InitializeGameCategories();
        InitializePlatforms();
        this.Size = new System.Drawing.Size(1175, 800);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        labelSelectedCount.Text = $"Selected: {_selectedCount}" + " / " + _gameCategories.Count;
        var cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = cancellationTokenSource.Token;
        try
        {
            UpdateDatabase(cancellationToken);
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("Search was canceled.");
        }
        
        try
        {
            IQueryable<string> distinctGenres = _gamesDb.Games
                .Select(g => g.Genre.ToLower())
                .Distinct();

            foreach (var genre in distinctGenres)
            {
                Console.WriteLine(genre);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
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
        int yPos = 575;

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
            Controls.Add(cb); 
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
                await UpdateDatabase(cancellationToken);
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

        private void Search()
        {
            try
            {
                List<string> selectedCategories = _categoryCheckBoxes
                    .Where(cb => cb.Checked && _gameCategories.Contains(cb.Text.ToLower()))
                    .Select(cb => cb.Text.ToLower())
                    .ToList();

                List<string> selectedPlatforms = _platformCheckBoxes
                    .Where(cb => cb.Checked && _platforms.Contains(cb.Text.ToUpper()))
                    .Select(cb => cb.Text.ToUpper())
                    .ToList();

                for (int i = 0; i < _platforms.Count; i++)
                {
                    if (_platformCheckBoxes[i].Checked)
                    {
                        if (i == 0)
                        {
                            selectedPlatforms.Add("PC (Windows)".ToLower());
                        }
                        else
                        {
                            selectedPlatforms.Add("Web Browser".ToLower());
                        }
                    }
                }

                IQueryable<Game> query = _gamesDb.Games.AsQueryable();

                if (selectedCategories.Any())
                {
                    query = query.Where(g => selectedCategories.Contains(g.Genre.ToLower()));
                }

                if (selectedPlatforms.Any())
                {
                    query = query.Where(g => selectedPlatforms.Contains(g.Platform.ToLower()));
                }

                List<Game> games = query.ToList();

                _gameAdapter.LoadGames(games);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            
        }

        private async Task UpdateDatabase(CancellationToken cancellationToken)
        {
            string query = "/games";
            try
            {
                await _client.Call<List<Game>>(
                    query,
                    OnSuccessful: async (body, response) =>
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            foreach (var game in body)
                            {
                                var existingGame = _gamesDb.Games.FirstOrDefault(g => g.Id == game.Id);
                                if (existingGame == null)
                                {
                                    _gamesDb.Games.Add(game);
                                }
                            }

                            _gamesDb.SaveChanges();
                            Search();
                        }
                        else
                        {
                            Console.WriteLine("RESPONSE CODE: " + response.StatusCode);
                        }
                    },
                    OnFailure: () => { Console.WriteLine("Connection failure"); },
                    cancellationToken: cancellationToken);
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Update was canceled.");
            }
          
        }
}