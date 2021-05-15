using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.Xml.XPath;

namespace CodeBrowser
{
    public partial class Form1 : Form
    {
        private bool bBoxInit = false;
        private XmlDocument doc = null;
        const String appName = "Code Browser";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resetControls();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                initDialog(openFileDialog1.FileName);
            }
        }

        public string getAccessSymbol(String mode)
        {
            mode = mode.ToLower();
            if (mode == "private") { return "-"; }
            if (mode == "public") { return "+"; }
            if (mode == "protected") { return "#"; }

            return "";
        }

        XPathNodeIterator getXPathNodeIterator(string XPathExpr)
        {
            if (doc == null) return null;
            XPathNavigator nav = doc.CreateNavigator();
            nav.MoveToRoot();
            nav.MoveToFirstChild();
            XPathNodeIterator it = nav.Select(XPathExpr);
            if (it.Count == 0) { return null; }

            return it;
        }

        public void fillClassList()
        {
            classList.Items.Add("GlobalData");
            
            XPathNodeIterator it = getXPathNodeIterator("//class");
            if (it == null) { return; }
            while (it.MoveNext())
            {
                XPathNavigator n = it.Current;
                String s = n.GetAttribute("name", n.NamespaceURI);
                classList.Items.Add(s);
            }
        }

        public void fillFunctionVariableList(String className)
        {
            functionList.Items.Clear();
            
            if (className.Equals("GlobalData"))
            {
                XPathNodeIterator it1 = getXPathNodeIterator("//global");
                if (it1 == null) { return; }
                while (it1.MoveNext())
                {
                    XPathNavigator n = it1.Current;
                    String line = n.GetAttribute("line", it1.Current.NamespaceURI);
                    functionList.Items.Add(line);
                }

                return;
            }
            
            XPathNodeIterator it = getXPathNodeIterator("//class[@name='" + className + "']");
            if (it == null) { return; }
            it.MoveNext();
            XPathNavigator tmp = it.Current;
            String classDesc = tmp.GetAttribute("description", it.Current.NamespaceURI);
            if (classDesc.Length == 0)
            {
                classDescription.Text = "Class Description Here ...";
            }
            else
            {
                classDescription.Text = classDesc;
            }

            it = getXPathNodeIterator("//class[@name='" + className + "']/variable");
            if (it == null) { return; }
            while (it.MoveNext())
            {
                XPathNavigator n = it.Current;
                String variableName = n.GetAttribute("name", n.NamespaceURI);
                String variableAccess = n.GetAttribute("access", n.NamespaceURI);
                String variableType = n.GetAttribute("type", n.NamespaceURI);
                String variableDefvalue = n.GetAttribute("defvalue", n.NamespaceURI);
                functionList.Items.Add(getAccessSymbol(variableAccess) + " " + variableType + " " + variableName);
            }
          
            it = getXPathNodeIterator("//class[@name='" + className + "']/function");
            if (it == null) { return; }
            while (it.MoveNext())
            {
                XPathNavigator n = it.Current;
                String functionName = n.GetAttribute("name", n.NamespaceURI);
                String functionAccess = n.GetAttribute("access", n.NamespaceURI);
                String functionRettype = n.GetAttribute("rettype", n.NamespaceURI);
                String functionParams = n.GetAttribute("params", n.NamespaceURI);
                functionList.Items.Add(getAccessSymbol(functionAccess) + " " + functionRettype + " " + functionName + "(" + functionParams  + ")");
            }
        }

        public void initDialog(String filename)
        {
            classList.Enabled = true;
            functionList.Enabled = true;
            reloadButton.Enabled = true;
            label1.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = true;

            fileLabel.Text = filename;
            int index = filename.LastIndexOf(@"\") + 1;
            fileSystemWatcher1.Path = filename.Substring(0, index - 1);
            fileSystemWatcher1.Filter = "*.xml";
            

            doc = new XmlDocument();
            doc.Load(filename);

            XPathNavigator n = doc.CreateNavigator();
            n.MoveToRoot();
            n.MoveToFirstChild();
            String fileDesc = n.GetAttribute("description", n.NamespaceURI);
            String fileDate = n.GetAttribute("date", n.NamespaceURI);
            fileDescription.Text = fileDesc + " " + fileDate;

            bBoxInit = true;
            fillClassList();
            bBoxInit = false;
            classList.SelectedIndex = 0;

            fillTreeView(filename);
        }
        public void fillTreeView(String filename)
        {
            // create root tree node
            TreeNode node = new TreeNode(filename);
            treeView1.Nodes.Add(node);

            // assume classlist has been filled in
            List<TreeNode> list = new List<TreeNode>();
            foreach (Object obj in classList.Items)
            {
                XPathNodeIterator it = getXPathNodeIterator("//class[@name='" + (String)obj + "']/variable");
                if (it != null)
                {
                    while (it.MoveNext())
                    {
                        XPathNavigator n = it.Current;
                        String name = n.GetAttribute("name", n.NamespaceURI);
                        list.Add(new TreeNode(name+" (V)"));
                    }
                }
                it = getXPathNodeIterator("//class[@name='" + (String)obj + "']/function");
                if (it != null)
                {
                    while (it.MoveNext())
                    {
                        XPathNavigator n = it.Current;
                        String name = n.GetAttribute("name", n.NamespaceURI);
                        list.Add(new TreeNode(name+" (F)"));
                    }
                }

                TreeNode node1;

                //TreeNode[] array = new TreeNode[list.Count];
                //for (int i = 0; i < list.Count; i++) {array[i] = list[i];}

                TreeNode[] array = list.ToArray();
                if (list.Count == 0) { node1 = new TreeNode((String)obj); } else { node1 = new TreeNode((String)obj,array); }
                treeView1.Nodes[0].Nodes.Add(node1);
            }

        }
    public void resetControls()
        {
            fileLabel.Text = "No File Selected";
            classDescription.Text = "";
            funcvarDescription.Text = "";
            fileDescription.Text = "";

            classList.Items.Clear();
            functionList.Items.Clear();

            treeView1.Nodes.Clear();

            classList.Enabled = false;
            functionList.Enabled = false;
            reloadButton.Enabled = false;
            label1.Enabled = false;
            label5.Enabled = false;
            label6.Enabled = false;

            doc = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                initDialog(openFileDialog1.FileName);
            }
        }

        private void classList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bBoxInit) { return; }

            classDescription.Text = "";
            fillFunctionVariableList((string)classList.SelectedItem);
        }

        private void functionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bBoxInit) { return; }

            funcvarDescription.Text = "";
            string className = (string)classList.SelectedItem;
            if (className.Equals("GlobalData")) { return; }
            String text = (string)functionList.SelectedItem;
            int index = text.IndexOf("(", 0);
            if (index == -1)
            {
                text = text.Substring(2);
                text = text.Substring(text.IndexOf(" ", 0) + 1);
                XPathNodeIterator it = getXPathNodeIterator("//class[@name='" + className + "']/variable[@name='" + text + "']");
                if (it == null) { return; }
                while (it.MoveNext())
                {
                    XPathNavigator n = it.Current;
                    String variableDesc = n.GetAttribute("description", n.NamespaceURI);
                    if (variableDesc.Length == 0)
                    {
                        funcvarDescription.Text = "Variable Description Here ...";
                    }
                    else
                    {
                        funcvarDescription.Text = variableDesc;
                    }
                }
            }
            else
            {
                text = text.Substring(2, index - 2);
                text = text.Substring(text.IndexOf(" ", 0) + 1);
                XPathNodeIterator it = getXPathNodeIterator("//class[@name='" + className + "']/function[@name='" + text + "']");
                if (it == null) { return; }
                while (it.MoveNext())
                {
                    XPathNavigator n = it.Current;
                    String functionDesc = n.GetAttribute("description", n.NamespaceURI);
                    if (functionDesc.Length == 0)
                    {
                        funcvarDescription.Text = "Function Description Here ...";
                    }
                    else
                    {
                        funcvarDescription.Text = functionDesc;
                    }
                }
            }

        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            reloadFile();
        }

        public void reloadFile()
        {
            string filename = fileLabel.Text;
            resetControls();
            initDialog(filename);
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            if (MessageBox.Show("Reload File", appName, System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
            {
                reloadFile();
            }
      
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            String text = node.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string text = (string)classList.SelectedItem;
            System.Windows.Forms.Clipboard.SetText(text);
        }
    }
}
