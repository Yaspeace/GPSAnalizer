using System;
using System.Windows.Forms;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;

namespace InterfacesDidorenko
{
    public partial class Form1 : Form
    {
        ProtocolHandler ph = new ProtocolHandler();

        public Form1()
        {
            InitializeComponent();
        }
        private async void btnChooseFile_Click(object sender, EventArgs e)
        {
            ph = new ProtocolHandler();
            ph.DataReaded += FillMessages;
            lbMessages.Items.Clear();
            fileChooser.ShowDialog();
            tbChosenFile.Text = fileChooser.FileName;
            lbl_Process.Visible = true;
            lbl_Process.Text = "Импорт файла...";
            await Task.Run(() => ph._ReadFromFile(fileChooser.FileName));
            pb_import.Visible = true;
            foreach (string msg in ph.Messages)
            {
                lbl_Process.Text = "Добавление строк... " + lbMessages.Items.Count.ToString();
                lbl_Process.Refresh();
                lbMessages.Items.Add(msg);
                pb_import.Maximum = ph.Messages.Count;
                pb_import.Value = lbMessages.Items.Count;
                pb_import.Refresh();
            }
            lbl_Process.Text = "Файл импортирован!";
            pb_import.Visible = false;
            lbl_Process.Visible = false;
        }

        private void FillMessages(object sender, EventArgs e)
        {
            foreach (string msg in ph.Messages)
                lbMessages.Items.Add(msg);
            lbl_Process.Text = "Данные файла успешно импортированы!";
        }

        private string ChosenProtocol()
        {
            if (rb_gga.Checked)
                return "GGA";
            if (rb_report.Checked)
                return "REPORT";
            if (rb_rmc.Checked)
                return "RMC";
            if (rb_vtg.Checked)
                return "VTG";
            if (rb_stats.Checked)
                return "Stats";
            if (rb_ETK.Checked)
                return "ETK";
            return "REPORT";
        }
        
        private void brn_More_Click(object sender, EventArgs e)
        {
            var phType = ph.GetType();
            var protocolListType = phType.GetProperty("Messages" + ChosenProtocol());
            dynamic protocolList = protocolListType.GetValue(ph);
            if (protocolList.Count > 0)
            {
                string prot = ChosenProtocol();
                FucnForm ff = new FucnForm(ph, prot);
                ff.Show();
            }
            else
                MessageBox.Show("Нет считанных данных выбранного формата!");
        }

        private void btn_SkyPlot_Click(object sender, EventArgs e)
        {
            if (ph.HasData && ph.MessagesGSV.Count > 0)
            {
                SkyplotForm sf = new SkyplotForm(ph);
                sf.Show();
            }
            else if(ph.MessagesGSV.Count == 0)
                MessageBox.Show("Выберите файл, содержащий данные\nв формате GPGSV для получения статистики!");
            else
                MessageBox.Show("Нет считанных данных!");
        }

        private void btn_stats_Click(object sender, EventArgs e)
        {
            if (ph.HasData && ph.MessagesGGA.Count > 0)
            {
                StatsForm sf = new StatsForm(ph);
                sf.Show();
            }
            else if (ph.MessagesGGA.Count == 0)
                MessageBox.Show("Выберите файл, содержащий данные\nв формате GPGGA для получения статистики!");
            else
                MessageBox.Show("Нет считанных данных!");
        }
    }
}
