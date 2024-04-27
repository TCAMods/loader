using System.Text.Json;
using System.Text.Json.Nodes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Newtonsoft.Json.Linq;
using System.Windows.Forms.VisualStyles;

namespace ModLoader
{
    public partial class Form1 : Form
    {
        JArray loadoutsUnloaded = new JArray();
        JObject currentLoadedLoadout = new JObject();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void selectFolderButton_Click(object sender, EventArgs e)
        {
            if (tcaFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                tcaGameFolderTextBox.Text = tcaFolderBrowser.SelectedPath;
            }
        }

        private async void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tcaGameFolderTextBox.Text.Length == 0)
            {
                tabControl1.SelectTab(Setup);
                return;
            }

            loadoutAuthorLabel.Visible = false;
            loadoutVersionNumber.Visible = false;
            loadoutInstallButton.Visible = false;

            String[] ignores = ["README.md", "LICENSE"];
            if (e.TabPage == Loadouts && loadoutsUnloaded.Count == 0)
            {
                // Make an HTTP request to https://api.github.com/repos/TCAMods/loadouts/git/trees/main?recursive=1
                // then parse the json response
                HttpClient client = new HttpClient();
                // fix github not accepting request:
                client.DefaultRequestHeaders.Add("User-Agent", "ModLoader");
                HttpResponseMessage response = (await client.GetAsync("https://api.github.com/repos/TCAMods/loadouts/git/trees/main?recursive=1"));

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    JObject json = JObject.Parse(responseBody);
                    JArray tree = (JArray)json["tree"];

                    // TODO: This is redundant, no?
                    TreeNode AV8B = new TreeNode("AV8B");
                    TreeNode F4E = new TreeNode("F4E");
                    TreeNode F5E = new TreeNode("F5E");
                    TreeNode F16 = new TreeNode("F16");
                    TreeNode Mig21bis = new TreeNode("Mig21bis");
                    TreeNode Mig23MLA = new TreeNode("Mig23MLA");
                    TreeNode Others = new TreeNode("Others");

                    foreach (var item in tree)
                    {
                        if (ignores.Contains(item["path"].ToString())) continue;

                        if (item["type"].ToString() == "blob")
                        {
                            loadoutsUnloaded.Add(item);
                            String folder = item["path"].ToString().Split("/")[0];

                            if (folder == "AV8B")
                            {
                                AV8B.Nodes.Add(item["path"].ToString());
                            }
                            else if (folder == "F4E")
                            {
                                F4E.Nodes.Add(item["path"].ToString());
                            }
                            else if (folder == "F5E")
                            {
                                F5E.Nodes.Add(item["path"].ToString());
                            }
                            else if (folder == "F16")
                            {
                                F16.Nodes.Add(item["path"].ToString());
                            }
                            else if (folder == "Mig21bis")
                            {
                                Mig21bis.Nodes.Add(item["path"].ToString());
                            }
                            else if (folder == "Mig23MLA")
                            {
                                Mig23MLA.Nodes.Add(item["path"].ToString());
                            }
                            else if (folder == "Others")
                            {
                                Others.Nodes.Add(item["path"].ToString());
                            }
                        }
                    }

                    loadoutsTreeView.BeginUpdate();
                    loadoutsTreeView.Nodes.AddRange([
                        AV8B,
                        F4E,
                        F5E,
                        F16,
                        Mig21bis,
                        Mig23MLA,
                        Others
                    ]);
                    loadoutsTreeView.EndUpdate();
                }
            }
        }

        private async void loadoutsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            loadoutDescription.Text = "Loading...";
            loadoutAuthorLabel.Text = "Loading...";
            loadoutVersionNumber.Text = "Loading...";
            loadoutTitle.Text = "Loading...";
            String filename = e.Node.Text.ToString();
            foreach (var node in loadoutsUnloaded)
            {
                if (node["path"].ToString() == filename)
                {
                    HttpClient client = new HttpClient();
                    // fix github not accepting request:
                    client.DefaultRequestHeaders.Add("User-Agent", "ModLoader");
                    HttpResponseMessage response = await client.GetAsync(node["url"].ToString());
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        JObject json = JObject.Parse(responseBody);
                        String content = json["content"].ToString();
                        content = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(content));

                        JObject json2;
                        try
                        {
                            json2 = JObject.Parse(content);
                        } catch
                        {
                            return;
                        }
                        
                        loadoutTitle.Text = json2["Name"].ToString();
                        loadoutDescription.Text = json2["Description"].ToString();
                        loadoutAuthorLabel.Text = json2["Author"].ToString();
                        loadoutVersionNumber.Text = json2["Version"].ToString();

                        // Check if the loadout is already installed
                        String foldername = filename.Split('/')[0];
                        if (foldername == "Others")
                        {
                            foldername = json2["Aircraft"].ToString();
                        }

                        String loadoutPath = tcaGameFolderTextBox.Text + "\\Arena_Data\\StreamingAssets\\Data\\Loadouts\\" + foldername + ".json";
                        if (File.Exists(loadoutPath))
                        {
                            // Open the loadout file and check if the loadout is already installed
                            FileStream file = File.Open(loadoutPath, FileMode.Open);
                            StreamReader reader = new StreamReader(file);
                            JObject myAircraft = JObject.Parse(reader.ReadToEnd());
                            reader.Close();
                            file.Close();

                            foreach (JObject myLoadout in myAircraft["Loadouts"])
                            {
                                if (myLoadout["Name"].ToString() == json2["Name"].ToString())
                                {
                                    loadoutInstallButton.Text = "Installed";
                                    loadoutInstallButton.BackColor = Color.Green;
                                    loadoutInstallButton.ForeColor = Color.White;
                                    break;
                                }
                            }

                            if (loadoutInstallButton.BackColor != Color.Green)
                            {
                                loadoutInstallButton.Text = "Install";
                                loadoutInstallButton.BackColor = Color.Transparent;
                                loadoutInstallButton.ForeColor = SystemColors.ControlText;
                            }
                        }
                        else
                        {
                            loadoutInstallButton.Visible = true;
                        }

                        loadoutAuthorLabel.Visible = true;
                        loadoutVersionNumber.Visible = true;
                        loadoutInstallButton.Visible = true;

                        currentLoadedLoadout = json2;
                    }
                }
            }
        }

        private void loadoutInstallButton_Click(object sender, EventArgs e)
        {
            TreeNode node = loadoutsTreeView.SelectedNode;
            String filename = node.Text.ToString();
            String foldername = filename.Split('/')[0];
            if (foldername == "Others")
            {
                foldername = currentLoadedLoadout["Aircraft"].ToString();
            }

            String loadoutPath = tcaGameFolderTextBox.Text + "\\Arena_Data\\StreamingAssets\\Data\\Loadouts\\" + foldername + ".json";

            if (File.Exists(loadoutPath))
            {
                FileStream file = File.Open(loadoutPath, FileMode.Open);
                StreamReader reader = new StreamReader(file);
                JObject myAircraft = JObject.Parse(reader.ReadToEnd());
                reader.Close();
                file.Close();
            }
            else
            {
                return;
            }

            if (loadoutInstallButton.Text == "Uninstall")
            {
                FileStream file = File.Open(loadoutPath, FileMode.Open);
                StreamReader reader = new StreamReader(file);
                JObject myAircraft = JObject.Parse(reader.ReadToEnd());
                reader.Close();
                file.Close();

                foreach (JObject myLoadout in myAircraft["Loadouts"])
                {
                    if (myLoadout["Name"].ToString() == currentLoadedLoadout["Name"].ToString())
                    {
                        ((JArray)myAircraft["Loadouts"]).Remove(myLoadout);
                        break;
                    }
                }
                File.WriteAllText(loadoutPath, myAircraft.ToString());
            }
            else if (loadoutInstallButton.Text == "Install")
            {
                // Open the loadout file and check if the loadout is already installed
                FileStream file = File.Open(loadoutPath, FileMode.Open);
                StreamReader reader = new StreamReader(file);
                JObject myAircraft = JObject.Parse(reader.ReadToEnd());
                reader.Close();
                file.Close();

                ((JArray)myAircraft["Loadouts"]).Add(currentLoadedLoadout);
                File.WriteAllText(loadoutPath, myAircraft.ToString());
            }

            TreeViewEventArgs e1 = new TreeViewEventArgs(node);
            loadoutsTreeView_AfterSelect(null, e1);
        }

        private void loadoutInstallButton_MouseEnter(object sender, EventArgs e)
        {
            if (loadoutInstallButton.Text == "Installed")
            {
                loadoutInstallButton.Text = "Uninstall";
                loadoutInstallButton.BackColor = Color.Red;
                loadoutInstallButton.ForeColor = Color.White;
            }
        }

        private void loadoutInstallButton_MouseLeave(object sender, EventArgs e)
        {
            if (loadoutInstallButton.Text == "Uninstall")
            {
                loadoutInstallButton.Text = "Installed";
                loadoutInstallButton.BackColor = Color.Green;
                loadoutInstallButton.ForeColor = Color.White;
            }
        }

        private void searchLoadoutbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                op_searchloadout();
            }
        }
        private void loadoutSearchButton_Click(object sender, EventArgs e)
        {
            op_searchloadout();
        }

        private void op_searchloadout()
        {
            String query = searchLoadoutbox.Text;
            if (query != null)
            {
                JArray matches = new JArray();
                foreach (var node in loadoutsUnloaded)
                {
                    if (node["path"].ToString().ToLower().Contains(query.ToLower()))
                    {
                        matches.Add(node);
                    }
                }

                loadoutsTreeView.Nodes.Clear();
                foreach (var item in matches)
                {
                    if (item["type"].ToString() == "blob")
                    {
                        loadoutsTreeView.Nodes.Add(item["path"].ToString());
                    }
                }
            }
        }
    }
}
