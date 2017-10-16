using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaggerApi;

namespace testPlugin
{
    public class MyPlugin : TaggerApi.IPlugin, TaggerApi.IEventListener, TaggerApi.IMainMenuExtender, TaggerApi.IInitializable
    {
        myWindow mWindow;

        public string Name => "My test plugin";

        public string PluginVersion => "1.0";



        public string Author => "Author name";

        public void Initialize()
        {
            mWindow = new myWindow();
        }

        public IEnumerable<MenuItem> menuItems()
        {
            var mi = new MenuItem
            {
                Name = "Open plugin UI",
                Tooltip = "opens the UI of this plugin",
                onItemClicked = () =>
                {
                    mWindow.Show();
                }
            };

            return new[] { mi };

        }

        public void onFilesTagged(IEnumerable<file> files, IEnumerable<tag> tags)
        {
            var strTags = tags.Select(t => t.name).Aggregate((t1, t2) => t1 + ", " + t2);
            var strFiles = files.Select(f => f.path).Aggregate((f1, f2) => f1 + Environment.NewLine + f2);
            mWindow.txtLog.AppendText("files tagged with these tags: " + strTags + Environment.NewLine +  strFiles);
            mWindow.txtLog.AppendText(Environment.NewLine);
            mWindow.txtLog.AppendText(Environment.NewLine);
        }

        public void onFilesUntagged(IEnumerable<file> files, IEnumerable<tag> tags)
        {
            var strTags = tags.Select(t => t.name).Aggregate((t1, t2) => t1 + ", " + t2);
            var strFiles = files.Select(f => f.path).Aggregate((f1, f2) => f1 + Environment.NewLine + f2);
            mWindow.txtLog.AppendText("files untagged from these tags: " + strTags + Environment.NewLine + strFiles);
            mWindow.txtLog.AppendText(Environment.NewLine);
            mWindow.txtLog.AppendText(Environment.NewLine);
        }

        public void onTagCreated(tag tag)
        {
            mWindow.txtLog.AppendText("tag created: " + tag.name);
            mWindow.txtLog.AppendText(Environment.NewLine);
            mWindow.txtLog.AppendText(Environment.NewLine);
        }

        public void onTagsDeleted(IEnumerable<tag> tags)
        {
            var strTags = tags.Select(t => t.name).Aggregate((t1, t2) => t1 + ", " + t2);
            mWindow.txtLog.AppendText("tags deleted: " + strTags);
            mWindow.txtLog.AppendText(Environment.NewLine);
            mWindow.txtLog.AppendText(Environment.NewLine);

        }
    }
}
