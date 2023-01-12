using ClinicServiceClientNamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicDektop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonLoadClients_Click(object sender, EventArgs e)
        {
            ClinicServiceClient clinicServiceClient = new ClinicServiceClient("http://localhost:5043/", new HttpClient());
            var clients = clinicServiceClient.GetAllAsync().Result;

            List<ListViewItem> clientItems = new List<ListViewItem>();
            foreach (Client client in clients)
            {
                ListViewItem item = new ListViewItem()
                {
                    Text = client.ClientId.ToString(),
                    SubItems =
                    {
                        client.SurName,
                        client.FirstName,
                        client.Patronymic
                    }
                };
                clientItems.Add(item);
            }

            listViewClients.Items.Clear();
            listViewClients.Items.AddRange(clientItems.ToArray());
        }
    }
}
