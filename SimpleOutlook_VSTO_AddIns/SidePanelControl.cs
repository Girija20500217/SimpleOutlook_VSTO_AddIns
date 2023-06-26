using System;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Outlook;
using System.Drawing;
using System.Xml.Linq;
using Microsoft.Office.Interop.Word;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.DirectoryServices;

namespace SimpleOutlook_VSTO_AddIns
{
    public partial class SidePanelControl : UserControl
    {
        private Outlook.Application outlookApplication;
        private Outlook.NameSpace outlookNamespace;
        private Outlook.MAPIFolder inboxFolder;
        public SidePanelControl()
        {
            InitializeComponent();
        }
        private void SidePanelControl_Load(object sender, EventArgs e)
        {
        }
        private void SearchMail_TextChanged(object sender, EventArgs e)
        {
            SearchOutlookMail();
        }
        private void SearchOutlookMail()
        {
            string searchTerm = SearchMail.Text;

            if (string.IsNullOrEmpty(searchTerm))
            {
                outlookApplication.ActiveExplorer().ClearSelection();
                return;
            }

            // Get the Outlook application
            outlookApplication = new Outlook.Application();

            // Get the MAPI namespace
            outlookNamespace = outlookApplication.GetNamespace("MAPI");

            // Get the Inbox folder
            inboxFolder = outlookNamespace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);

            // Search for emails in the Inbox folder according to following searchTerm. It can be modified as required.
            string filter = $"@SQL=\"urn:schemas:httpmail:subject\" LIKE '%{searchTerm}%' " +
                $"OR \"urn:schemas:httpmail:textdescription\" LIKE '%{searchTerm}%' " +
                $"OR \"urn:schemas:httpmail:fromname\" LIKE '%{searchTerm}%' " +
                $"OR \"urn:schemas:httpmail:fromaddress\" LIKE '%{searchTerm}%' " +
                $"OR \"urn:schemas:httpmail:displayto\" LIKE '%{searchTerm}%' " +
                $"OR \"urn:schemas:httpmail:displaycc\" LIKE '%{searchTerm}%'";
            //string filter = $"@SQL=\"http://schemas.microsoft.com/mapi/proptag/0x0E04001E\" LIKE '%{searchTerm}%' " +
            //    $"OR \"http://schemas.microsoft.com/mapi/proptag/0x0037001E\" LIKE '%{searchTerm}%' " +
            //    $"OR \"http://schemas.microsoft.com/mapi/proptag/0x0C1A001E\" LIKE '%{searchTerm}%' " +
            //    $"OR \"http://schemas.microsoft.com/mapi/proptag/0x0C1F001E\" LIKE '%{searchTerm}%'";

            // filter emails accroding to above search term rule.
            Outlook.Items searchResults = inboxFolder.Items.Restrict(filter);

            if (searchResults == null || searchResults.Count < 1)
            {
                outlookApplication.ActiveExplorer().ClearSelection();
                return;
            }
            // Get the first matching email
            MailItem selectedEmail = searchResults.GetFirst() as Outlook.MailItem;


            if (selectedEmail != null)
            {
                // Open the selected email in new popup window. can be customized as required.
                //selectedEmail.Display();

                // Get the EntryID of the selected email
                string entryId = selectedEmail.EntryID;

                // Get the active explorer window
                Outlook.Explorer activeExplorer = outlookApplication.ActiveExplorer();

                // Retrieve the email item using EntryID
                Outlook.MailItem openedEmail = (Outlook.MailItem)outlookNamespace.GetItemFromID(entryId);
                if (openedEmail != null)
                {
                    // Select and display the email in the active explorer window
                    activeExplorer.ClearSelection();
                    activeExplorer.AddToSelection(openedEmail);
                    activeExplorer.Display();

                    var mailItem = outlookApplication.ActiveExplorer().Selection[1];
                    if (mailItem == null) { return; }
                    var inspector = mailItem.GetInspector;
                    if (inspector == null) { return; }

                    if (inspector.IsWordMail())
                    {
                        var outlookWordDocument = inspector.WordEditor as Document;
                        string emailBody = mailItem.HTMLBody;
                        mailItem.HTMLBody = emailBody;
                        if (outlookWordDocument == null || outlookWordDocument.Application.Selection == null)
                        {
                            return;
                        }
                        var wordRange = outlookWordDocument.Application.Selection.Range;
                        var wordFind = wordRange.Find;
                        wordFind.Format = false;
                        wordFind.MatchCase = false;
                        wordFind.MatchWholeWord = false;
                        wordFind.HitHighlight(searchTerm, WdColor.wdColorYellow);

                    }
                }
                else
                {
                    //Either clear the selection in active window and display message in popover as described below.

                    // you can clear the selection in the active explorer window:
                    outlookApplication.ActiveExplorer().ClearSelection();

                    // Alternatively, display a message if required. this opens popover with msg.
                    //MessageBox.Show("No matching email found.");

                }
            }

        }
    }
}
