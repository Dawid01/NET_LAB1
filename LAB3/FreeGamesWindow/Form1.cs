using Lab;

namespace FreeGamesWindow;

public partial class Form1 : Form
{
    private ClientAPI _clientApi;
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

    private List<CheckBox> _checkBoxes = new List<CheckBox>();
    private List<CheckBox> _platformCheckBoxes = new List<CheckBox>();

    public Form1()
    {
        _clientApi = ClientAPI.Instance;
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
            _checkBoxes.Add(cb);
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
    
    private void btnSearch_Click(object sender, EventArgs e)
    {
      
    }
    
    private void btnClear_Click(object sender, EventArgs e)
    {
        foreach (var cb in _checkBoxes)
        {
            cb.Checked = false;
        }
    }
}