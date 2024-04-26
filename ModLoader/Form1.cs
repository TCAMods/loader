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
    }
}
