using Lab;

namespace FreeGamesWindow;

public partial class Form1 : Form
{
    private ClientAPI _clientApi;
    
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

    public Form1()
    {
        _clientApi = ClientAPI.Instance;
        InitializeComponent();
        InitializeGameCategories();
        this.Size = new System.Drawing.Size(1000, 800);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;

    }

    private void InitializeGameCategories()
    {
        int xPos = 10;
        int yPos = 10;

        foreach (var category in _gameCategories)
        {
            CheckBox cb = new CheckBox();
            cb.Text = category;
            cb.AutoSize = true;
            cb.ForeColor = System.Drawing.Color.White;
            cb.FlatStyle = FlatStyle.Flat;
            cb.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            cb.Location = new System.Drawing.Point(xPos, yPos);
            yPos += 30;

            this.panelCategories.Controls.Add(cb);
        }

        this.panelCategories.AutoScroll = true;
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      
        MessageBox.Show("Szukam gier...");
    }
}