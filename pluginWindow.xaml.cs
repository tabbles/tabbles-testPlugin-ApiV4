using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace testPlugin
{
    /// <summary>
    /// Interaction logic for window.xaml
    /// </summary>
    public partial class myWindow : Window
    {
        public myWindow()
        {
            InitializeComponent();
        }

        private async void btnTag_Click(object sender, RoutedEventArgs e)
        {
            var tagName = txtTagName.Text.Trim();

            // first you need to create the tag, otherwise the tagFiles call will do nothing
            var createTagRes = await Api.createTagWithDefaultColor(tagName);


            var filesToTag = new[] { txtFilePath.Text.Trim() };
            var tags = new[] { tagName };

            var tagRes = await Api.tagFiles(tags: tags, files: filesToTag);


        }

        private async void btnUntag_Click(object sender, RoutedEventArgs e)
        {
            var tagName = txtTagName.Text.Trim();

            // here you don't need to create the tag. if the tag does not exist, the untag operation does not need to do anything.
            

            var filesToTag = new[] { txtFilePath.Text.Trim() };
            var tags = new[] { tagName };

            var tagRes = await Api.untagFiles(tags: tags, files: filesToTag);
             
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var y = 4;
        }
    }
}
