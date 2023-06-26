using System;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;

namespace SimpleOutlook_VSTO_AddIns
{
    public partial class ThisAddIn
    {
        private SidePanelControl sidePanelControl;
        //private Office.CustomTaskPane taskPane;
        private Microsoft.Office.Tools.CustomTaskPane taskPane;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            // Create and display the side panel
            sidePanelControl = new SidePanelControl();
            taskPane = this.CustomTaskPanes.Add(sidePanelControl, "Sample VSTO Side Panel");
            taskPane.Visible = true;
            
            // Hook into the Outlook Application events
            ((Outlook.ApplicationEvents_11_Event)this.Application).Quit += ThisAddIn_Quit;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }
        private void ThisAddIn_Quit()
        {
            // Clean up resources when Outlook is closed
            //taskPane.Dispose();
            sidePanelControl.Dispose();
        }
        // Other event handlers and methods can be added as needed

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
