using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace RFID
{
    public partial class Form1 : Form
    {


        public SqlConnection conn;
        public string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asssss\Desktop\RFID\RFID\database.mdf;Integrated Security=True;";
        SqlConnectionStringBuilder bldr;
        BindingSource bns;
        BindingSource bns2;
        BindingSource bns3;
        public string param2;
        public Form1()
        {
            InitializeComponent();
            // сдвиг окна с любой ее области
            this.MouseDown += delegate
            {
                this.Capture = false;
                var msg = Message.Create(this.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
                this.WndProc(ref msg);
            };
            //трей
            notifyIcon1.Visible = false;
            this.notifyIcon1.MouseDoubleClick += new MouseEventHandler(notifyIcon1_MouseDoubleClick);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            tabPage3.Parent = null;
            tabPage4.Parent = null;
            tabPage5.Parent = null;
            if (Properties.Settings.Default.PortName == "")
            {
                string[] ports = SerialPort.GetPortNames();

                Properties.Settings.Default.PortName = ports[0];
                Properties.Settings.Default.Save();
            }
            loadDatabaseToGrid();
        }



        private void loadDatabaseToGrid()
        {
            try
            {
                bns = new BindingSource();
                bns2 = new BindingSource();
                bns3 = new BindingSource();
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                string SQLstr = "SELECT * FROM VU";
                SqlDataAdapter da = new SqlDataAdapter(SQLstr, conn);
                DataTable t = new DataTable("VU");
                da.Fill(t);
                dataGridView2.DataSource = t;
                bns.DataSource = dataGridView2.DataSource as DataTable;
            //    textBox12.DataBindings.Clear();
               // textBox12.DataBindings.Add(new Binding("Text", bns, "UDID"));
                textBox11.DataBindings.Clear();
                textBox11.DataBindings.Add(new Binding("Text", bns, "familia"));
                textBox10.DataBindings.Clear();
                textBox10.DataBindings.Add(new Binding("Text", bns, "name"));
                textBox9.DataBindings.Clear();
                textBox9.DataBindings.Add(new Binding("Text", bns, "otchestvo"));
                textBox8.DataBindings.Clear();
                textBox8.DataBindings.Add(new Binding("Text", bns, "datar"));
                textBox7.DataBindings.Clear();
                textBox7.DataBindings.Add(new Binding("Text", bns, "mestor"));
                textBox6.DataBindings.Clear();
                textBox6.DataBindings.Add(new Binding("Text", bns, "datav"));
                textBox5.DataBindings.Clear();
                textBox5.DataBindings.Add(new Binding("Text", bns, "datao"));
                textBox4.DataBindings.Clear();
                textBox4.DataBindings.Add(new Binding("Text", bns, "serianomer"));
                textBox2.DataBindings.Clear();
                textBox2.DataBindings.Add(new Binding("Text", bns, "gruppakrovi"));
               


                string SQLstr11 = "SELECT * FROM transport";
                SqlDataAdapter da11 = new SqlDataAdapter(SQLstr11, conn);
                DataTable t11 = new DataTable("transport");
                da11.Fill(t11);
                dataGridView4.DataSource = t11;
                bns2.DataSource = dataGridView4.DataSource as DataTable;
                textBox52.DataBindings.Clear();
                textBox52.DataBindings.Add(new Binding("Text", bns2, "transportnomer"));
                textBox51.DataBindings.Clear();
                textBox51.DataBindings.Add(new Binding("Text", bns2, "godvipuska"));
                textBox50.DataBindings.Clear();
                textBox50.DataBindings.Add(new Binding("Text", bns2, "datavidac4i"));
                textBox49.DataBindings.Clear();
                textBox49.DataBindings.Add(new Binding("Text", bns2, "familiaa"));
                textBox48.DataBindings.Clear();
                textBox48.DataBindings.Add(new Binding("Text", bns2, "imia"));
                textBox47.DataBindings.Clear();
                textBox47.DataBindings.Add(new Binding("Text", bns2, "ot4estvoo"));
                textBox46.DataBindings.Clear();
                textBox46.DataBindings.Add(new Binding("Text", bns2, "adrespropiska"));
                textBox45.DataBindings.Clear();
                textBox45.DataBindings.Add(new Binding("Text", bns2, "deistvitelyno"));
                textBox44.DataBindings.Clear();
                textBox44.DataBindings.Add(new Binding("Text", bns2, "identifinomer"));
                textBox43.DataBindings.Clear();
                textBox43.DataBindings.Add(new Binding("Text", bns2, "marka"));
                textBox42.DataBindings.Clear();
                textBox42.DataBindings.Add(new Binding("Text", bns2, "modely"));
                textBox41.DataBindings.Clear();
                textBox41.DataBindings.Add(new Binding("Text", bns2, "tip"));
                textBox40.DataBindings.Clear();
                textBox40.DataBindings.Add(new Binding("Text", bns2, "massa"));
                textBox39.DataBindings.Clear();
                textBox39.DataBindings.Add(new Binding("Text", bns2, "kategorii"));
                textBox38.DataBindings.Clear();
                textBox38.DataBindings.Add(new Binding("Text", bns2, "obyemdvigatelya"));
                textBox37.DataBindings.Clear();
                textBox37.DataBindings.Add(new Binding("Text", bns2, "tiptopliva"));
                textBox36.DataBindings.Clear();
                textBox36.DataBindings.Add(new Binding("Text", bns2, "nomerdvigatelya"));
                textBox35.DataBindings.Clear();
                textBox35.DataBindings.Add(new Binding("Text", bns2, "cvet"));
                textBox34.DataBindings.Clear();
                textBox34.DataBindings.Add(new Binding("Text", bns2, "osobieotmetki"));
             //   textBox33.DataBindings.Clear();
               //textBox33.DataBindings.Add(new Binding("Text", bns2, "udidtransport"));
               


                string SQLstr32 = "SELECT * FROM protocol";
                SqlDataAdapter da32 = new SqlDataAdapter(SQLstr32, conn);
                DataTable t32 = new DataTable("protocol");
                da32.Fill(t32);
                dataGridView5.DataSource = t32;
                bns3.DataSource = dataGridView5.DataSource as DataTable;

                textBox54.DataBindings.Clear();
                textBox54.DataBindings.Add(new Binding("Text", bns3, "nomerprotocola"));
                textBox55.DataBindings.Clear();
                textBox55.DataBindings.Add(new Binding("Text", bns3, "nomervod"));
                textBox56.DataBindings.Clear();
                textBox56.DataBindings.Add(new Binding("Text", bns3, "registranomer"));
                textBox59.DataBindings.Clear();
                textBox59.DataBindings.Add(new Binding("Text", bns3, "narfio"));
                maskedTextBox1.DataBindings.Clear();
                maskedTextBox1.DataBindings.Add(new Binding("Text", bns3, "datanarush"));
                textBox57.DataBindings.Clear();
                textBox57.DataBindings.Add(new Binding("Text", bns3, "famsotr"));
                textBox58.DataBindings.Clear();
                textBox58.DataBindings.Add(new Binding("Text", bns3, "nomerwetonasotr"));
                textBox60.DataBindings.Clear();
                textBox60.DataBindings.Add(new Binding("Text", bns3, "statia"));
                comboBox1.DataBindings.Clear();
                comboBox1.DataBindings.Add(new Binding("Text", bns3, "status"));
                textBox62.DataBindings.Clear();
                textBox62.DataBindings.Add(new Binding("Text", bns3, "nomerprotocola"));

                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false; //первый столбец убирает
            dataGridView3.RowHeadersVisible = false; //первый столбец убирает
            rfid();
        }
        SerialPort port;

        public void rfid()
        {


            Task task = Task.Run(() =>
                  {
                      port = new SerialPort();
                      try
                      {
                          port.PortName = Properties.Settings.Default.PortName;
                          if (Properties.Settings.Default.NoRFID == false)
                          {
                              if (!port.IsOpen)
                              {
                                  port.Open();
                               //   label13.Text = "Подключено";
                              }
                             
                          }
                          while (true)
                          {
                              if (port.IsOpen && Properties.Settings.Default.NoRFID == false)
                              {
                                  string entrada = port.ReadLine();
                                  entrada = entrada.Split('\r')[0];
                                  string zzz;

                                  zzz = entrada;

                                  if (UDIDBox.InvokeRequired)
                                  {
                                      Invoke(new Action(() => UDIDBox.Text = zzz));
                                  }
                                  else UDIDBox.Text = zzz;

                                  if (textBox32.InvokeRequired)
                                  {
                                      Invoke(new Action(() => textBox32.Text = zzz));
                                  }
                                  else textBox32.Text = zzz;


                                  if (textBox12.InvokeRequired)
                                  {
                                      Invoke(new Action(() => textBox12.Text = zzz));
                                  }
                                  else textBox12.Text = zzz;




                                  


                                  if (textBox33.InvokeRequired)
                                  {
                                      Invoke(new Action(() => textBox33.Text = zzz));
                                  }
                                  else textBox33.Text = zzz;

                                  if (UDIDBox.InvokeRequired)
                                  {
                                      Invoke(new Action(() => button2_Click(null, null)));
                                  }
                                  else button2_Click(null, null);

                                  if (UDIDBox.InvokeRequired)
                                  {
                                      Invoke(new Action(() => button6_Click(null, null)));
                                  }
                                  else button6_Click(null, null);

                                  if (UDIDBox.InvokeRequired)
                                  {
                                      Invoke(new Action(() => button5_Click(null, null)));
                                  }
                                  else button5_Click(null, null);

                              }
                              //port.Close();
                          }
                      }
                      catch (Exception)
                      {
                          if (Properties.Settings.Default.NoRFID == true)
                          {
                              return;
                          }
                          if (port.IsOpen)
                              port.Close();
                          Settings set = new Settings(this);
                          set.ShowDialog();
                         // label13.Text = "Отключено";

                      }
                  });
        }


        //  port.Close();
        /*   if (UDIDBox.InvokeRequired)
           {
               Invoke(new Action(() => UDIDBox.Text = ("") + entrada));

               if (FamiliaBox.InvokeRequired)
               {
                   Invoke(new Action(() => FamiliaBox.Text = ("Талпа")));

               }
           }
           else


       }
       catch (Exception)
       {
           Invoke(new Action(() =>
         {
             Settings set = new Settings();
             set.ShowDialog();
             //port.Close();
         }));
       }
   }
}
});

}*/

        public void resetPort()
        {
            port.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void runSettings()
        {
            Settings set = new Settings(this);
            set.ShowDialog();
        }
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runSettings();
        }
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Нажав на синий фон и удерживая кнопку мыши, можно передвигать окно.\n\n\n", "Справка.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void разработчикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Работу выполнил:\n\"Студент группы ИТ13ДР62ИС1.\"\n\"Талпа Роман Витальевич\"\n ", "Разработчик :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void свернутьОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = new System.Windows.Forms.DialogResult();
            result = MessageBox.Show("Вы уверены что хотите выйти?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void reloadTable(object sender, EventArgs e)
        {
            // MessageBox.Show(Properties.Settings.Default.PortName);
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd;
            cmd = new SqlCommand("select * from VU", conn);
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataTable qw = new DataTable();
            DA.Fill(qw);
            dataGridView2.DataSource = qw;
            SqlCommand cmd4;
            cmd4 = new SqlCommand("select * from transport", conn);
            SqlDataAdapter DA4 = new SqlDataAdapter(cmd4);
            DataTable qw4 = new DataTable();
            DA4.Fill(qw4);
            dataGridView4.DataSource = qw4;

            SqlCommand cmd44;
            cmd44 = new SqlCommand("select * from protocol", conn);
            SqlDataAdapter DA44 = new SqlDataAdapter(cmd44);
            DataTable qw44 = new DataTable();
            DA44.Fill(qw44);
            dataGridView5.DataSource = qw44;
            conn.Close();
            conn.Dispose();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            //трей
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //трей
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }
        private void администраторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "0000")
            {
                tabPage3.Parent = tabControl1;
                UDIDBox.ReadOnly = false;
                ImyaBox.ReadOnly = false;
                Ot4estvoBox.ReadOnly = false;
                DMGBox.ReadOnly = false;
                RodilsyaBox.ReadOnly = false;
                DataVida4iBox.ReadOnly = false;
                DataOkon4aniyaBox.ReadOnly = false;
                VidalBox.ReadOnly = false;
                button1.Enabled = true;
                textBox32.ReadOnly = false;
                tabPage4.Parent = tabControl1;
                tabPage5.Parent = tabControl1;
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();


                SqlCommand cmd;
                cmd = new SqlCommand("select * from VU", conn);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataTable qw = new DataTable();
                DA.Fill(qw);
                dataGridView2.DataSource = qw;


                dataGridView4.RowHeadersVisible = false; //первый столбец убирает
                dataGridView5.RowHeadersVisible = false; //первый столбец убирает
                dataGridView2.RowHeadersVisible = false; //первый столбец убирает


                dataGridView2.Columns[0].HeaderText = "UDID";
                dataGridView2.Columns[1].HeaderText = "Фамилия";
                dataGridView2.Columns[2].HeaderText = "Имя";
                dataGridView2.Columns[3].HeaderText = "Отчество";
                dataGridView2.Columns[4].HeaderText = "Дата рождения";
                dataGridView2.Columns[5].HeaderText = "Место рождения";
                dataGridView2.Columns[6].HeaderText = "Дата выдачи";
                dataGridView2.Columns[7].HeaderText = "Дата окончания";
                dataGridView2.Columns[8].HeaderText = "Номер документа";
                dataGridView2.Columns[9].HeaderText = "Группа крови";


                SqlCommand cmd4;
                cmd4 = new SqlCommand("select * from transport", conn);
                SqlDataAdapter DA4 = new SqlDataAdapter(cmd4);
                DataTable qw4 = new DataTable();
                DA4.Fill(qw4);
                dataGridView4.DataSource = qw4;

                dataGridView4.Columns[0].HeaderText = "Регистрационный номер";
                dataGridView4.Columns[1].HeaderText = "Год выпуска";
                dataGridView4.Columns[2].HeaderText = "Дата выдачи";
                dataGridView4.Columns[3].HeaderText = "Фамилия";
                dataGridView4.Columns[4].HeaderText = "Имя";
                dataGridView4.Columns[5].HeaderText = "Отчество";
                dataGridView4.Columns[6].HeaderText = "Прописка";
                dataGridView4.Columns[7].HeaderText = "Действителено с";
                dataGridView4.Columns[8].HeaderText = "Идентификационный номер";
                dataGridView4.Columns[9].HeaderText = "Марка";
                dataGridView4.Columns[10].HeaderText = "Модель";
                dataGridView4.Columns[11].HeaderText = "Тип";
                dataGridView4.Columns[12].HeaderText = "Масса";
                dataGridView4.Columns[13].HeaderText = "Категории";
                dataGridView4.Columns[14].HeaderText = "Объем двигателя";
                dataGridView4.Columns[15].HeaderText = "Тип топлива";
                dataGridView4.Columns[16].HeaderText = "Номер двигателя";
                dataGridView4.Columns[17].HeaderText = "Цвет";
                dataGridView4.Columns[18].HeaderText = "Особые отметки";
                dataGridView4.Columns[19].HeaderText = "UDID транспорта";



                SqlCommand cmd44;
                cmd44 = new SqlCommand("select * from protocol", conn);
                SqlDataAdapter DA44 = new SqlDataAdapter(cmd44);
                DataTable qw44 = new DataTable();
                DA44.Fill(qw44);
                dataGridView5.DataSource = qw44;

                dataGridView5.Columns[0].HeaderText = "Номер протокола";
                dataGridView5.Columns[1].HeaderText = "Номер водительского";
                dataGridView5.Columns[2].HeaderText = "Регистрационный номер";
                dataGridView5.Columns[3].HeaderText = "Дата нарушения";
                dataGridView5.Columns[4].HeaderText = "Фамилия сотрудника";
                dataGridView5.Columns[5].HeaderText = "Номер жетона сотрудника";
                dataGridView5.Columns[6].HeaderText = "Нарушил ФИО";
                dataGridView5.Columns[7].HeaderText = "Статья";
                dataGridView5.Columns[8].HeaderText = "Статус";
                conn.Close();

                conn.Dispose();
            }
            else
            {
                MessageBox.Show("Введите пароль администратора", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void обновитьБазуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Clear();
            tabPage3.Parent = null;
            UDIDBox.ReadOnly = true;
            ImyaBox.ReadOnly = true;
            Ot4estvoBox.ReadOnly = true;
            DMGBox.ReadOnly = true;
            RodilsyaBox.ReadOnly = true;
            DataVida4iBox.ReadOnly = true;
            DataOkon4aniyaBox.ReadOnly = true;
            VidalBox.ReadOnly = true;
            button1.Enabled = false;

            tabPage4.Parent = null;
            tabPage5.Parent = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                //SqlCommand cmd = new SqlCommand("Insert into VU" +
                //    "(UDID документа, Фамилия, Имя, Отчество, Дата рождения, Место рождения, Дата выдачи, Дата окончания, Серия и номер, Группа крови) "+
                //    "Values (@param0, @param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9)", conn);

                SqlCommand cmd = new SqlCommand("Insert into VU ([UDID], [familia], [name], [otchestvo], [datar], [mestor], [datav], [datao], [serianomer], [gruppakrovi]) Values (@param0,@param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9)", conn);



                SqlParameter param;
                param = new SqlParameter();
                param.ParameterName = "@param0";
                param.Value = textBox12.Text;
                param.SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@param1";
                param.Value = textBox11.Text;
                param.SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@param2";
                param.Value = textBox10.Text;
                param.SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@param3";
                param.Value = textBox9.Text;
                param.SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@param4";
                param.Value = textBox8.Text;
                param.SqlDbType = SqlDbType.DateTime;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@param5";
                param.Value = textBox7.Text;
                param.SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@param6";
                param.Value = textBox6.Text;
                param.SqlDbType = SqlDbType.DateTime;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@param7";
                param.Value = textBox5.Text;
                param.SqlDbType = SqlDbType.DateTime;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@param8";
                param.Value = textBox4.Text;
                param.SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@param9";
                param.Value = textBox2.Text;
                param.SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters.Add(param);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {

                    MessageBox.Show("Не все поля заполнены", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }



                cmd = new SqlCommand("select * from VU", conn);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataTable qw = new DataTable();
                DA.Fill(qw);
                dataGridView2.DataSource = qw;



                conn.Close();
                conn.Dispose();

            }
            catch
            {
            }
            loadDatabaseToGrid();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            /*  SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("select * from VU", conn);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataTable qw = new DataTable();
                DA.Fill(qw);
                dataGridView2.DataSource = qw;*/
            /* dataGridView2.DataSource = qw.DefaultView;
             dataGridView2.Columns[0].HeaderText = "UDID";
             dataGridView2.Columns[1].HeaderText = "Фамилия";
             dataGridView2.Columns[2].HeaderText = "Имя";
             dataGridView2.Columns[3].HeaderText = "Отчество";
             dataGridView2.Columns[4].HeaderText = "Дата";
             dataGridView2.Columns[5].HeaderText = "Место рождения";
             dataGridView2.Columns[6].HeaderText = "Дата выдачи";
             dataGridView2.Columns[7].HeaderText = "Дата окончания";
             dataGridView2.Columns[8].HeaderText = "Номер документа";
             dataGridView2.Columns[9].HeaderText = "Группа крови";*/
            /* SqlCommand cmd4;
              cmd4 = new SqlCommand("select * from transport", conn);
              SqlDataAdapter DA4 = new SqlDataAdapter(cmd4);
              DataTable qw4 = new DataTable();
              DA4.Fill(qw4);
              dataGridView4.DataSource = qw4;

              SqlCommand cmd44;
              cmd44 = new SqlCommand("select * from protocol", conn);
              SqlDataAdapter DA44 = new SqlDataAdapter(cmd44);
              DataTable qw44 = new DataTable();
              DA44.Fill(qw44);
              dataGridView5.DataSource = qw44;
              conn.Close();
              conn.Dispose();*/

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox12.Text != "")
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd22 = new SqlCommand("DELETE FROM VU WHERE UDID= '" + textBox12.Text + "'", conn);


                //SqlCommand cmd222 = new SqlCommand("select * from vu", conn);

                SqlDataAdapter DA = new SqlDataAdapter(cmd22);
                DataTable qw = new DataTable();
                DA.Fill(qw);

                dataGridView2.DataSource = qw;


                try
                {
                    cmd22.ExecuteNonQuery();
                }
                catch
                {

                    MessageBox.Show("Введите значение", "Удаление");
                    return;
                }

                SqlCommand cmd222 = new SqlCommand("select * from vu", conn);

                SqlDataAdapter DA444 = new SqlDataAdapter(cmd222);
                DataTable qw444 = new DataTable();
                DA444.Fill(qw444);

                dataGridView2.DataSource = qw444;
                conn.Close();
                conn.Dispose();
            }
            else
            {
                MessageBox.Show("Введите UDID документа", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            loadDatabaseToGrid();
        }


        private void button5_Click(object sender, EventArgs e)
        {

            if (textBox12.Text != "")
            {
                SqlConnection conn21 = new SqlConnection(connStr);
                conn21.Open();
                SqlCommand cmd21 = new SqlCommand("SELECT * FROM VU WHERE UDID ='" + textBox12.Text + "'", conn21);

                // cmd = new SqlCommand("SELECT * FROM VU WHERE UDID ='" + textBox1.Text + "'", conn);
                SqlDataAdapter DA21 = new SqlDataAdapter(cmd21);
                DataTable qw21 = new DataTable();
                DA21.Fill(qw21);
                dataGridView2.DataSource = qw21;
                if (qw21.Rows.Count != 0)
                {
                  //  textBox12.Text = qw21.Rows[0]["UDID"].ToString();
                    textBox11.Text = qw21.Rows[0]["familia"].ToString();
                    textBox10.Text = qw21.Rows[0]["name"].ToString();
                    textBox9.Text = qw21.Rows[0]["otchestvo"].ToString();
                    textBox8.Text = qw21.Rows[0]["datar"].ToString();
                    textBox7.Text = qw21.Rows[0]["mestor"].ToString();
                    textBox6.Text = qw21.Rows[0]["datav"].ToString();
                    textBox5.Text = qw21.Rows[0]["datao"].ToString();
                    textBox4.Text = qw21.Rows[0]["serianomer"].ToString();
                    textBox2.Text = qw21.Rows[0]["gruppakrovi"].ToString();
                    textBox2.Text = qw21.Rows[0]["gruppakrovi"].ToString();

                }
                else {
                   // textBox12.Text = "";
                    textBox11.Text = ""; 
                    textBox10.Text = "";
                    textBox9.Text = "";
                    textBox8.Text = "";
                    textBox7.Text = "";
                    textBox6.Text = "";
                    textBox5.Text = "";
                    textBox4.Text = "";
                    textBox2.Text = "";
                    textBox2.Text = ""; 
                }
                try
                {
                    cmd21.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Введите значение", "Поиск");
                    return;
                }

                conn21.Close();
                conn21.Dispose();

            }
            else
            {
                //MessageBox.Show("Введите UDID документа", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reloadTable(null, null);

            }
            //loadDatabaseToGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                //SqlCommand cmd = new SqlCommand("Insert into VU" +
                //    "(UDID документа, Фамилия, Имя, Отчество, Дата рождения, Место рождения, Дата выдачи, Дата окончания, Серия и номер, Группа крови) "+
                //    "Values (@param0, @param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9)", conn);

                // SqlCommand cmdupd = new SqlCommand("UPDATE VU FROM (UDID, familia, name, otchestvo, datar, mestor, datav, datao, serianomer, gruppakrovi) Values (@param0, @param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9)", conn);

                SqlCommand cmdupd = new SqlCommand("UPDATE [VU] " + " SET [familia]=@s2, [name]=@s3, [otchestvo]=@s4, [datar]=@s5, [mestor]=@s6, [datav]=@s7, [datao]=@s8, [serianomer]=@s9, [gruppakrovi]=@s10 " + " WHERE [UDID]=@s1", conn);
                // SqlCommand cmdupd = new SqlCommand(strSQl);
                cmdupd.Parameters.AddWithValue("@s1", textBox12.Text);
                cmdupd.Parameters.AddWithValue("@s2", textBox11.Text);
                cmdupd.Parameters.AddWithValue("@s3", textBox10.Text);
                cmdupd.Parameters.AddWithValue("@s4", textBox9.Text);
                cmdupd.Parameters.AddWithValue("@s5", textBox8.Text);
                cmdupd.Parameters.AddWithValue("@s6", textBox7.Text);
                cmdupd.Parameters.AddWithValue("@s7", textBox6.Text);
                cmdupd.Parameters.AddWithValue("@s8", textBox5.Text);
                cmdupd.Parameters.AddWithValue("@s9", textBox4.Text);
                cmdupd.Parameters.AddWithValue("@s10", textBox2.Text);

                try
                {
                    cmdupd.ExecuteNonQuery();
                }
                catch
                {

                    MessageBox.Show("Проверьте все поля", "Изменение");
                    return;
                }



                cmdupd = new SqlCommand("SELECT * from VU", conn);
                SqlDataAdapter DA = new SqlDataAdapter(cmdupd);
                DataTable qw = new DataTable();
                DA.Fill(qw);
                dataGridView2.DataSource = qw;



                conn.Close();
                conn.Dispose();

            }
            catch
            {
            }
            loadDatabaseToGrid();
        }


        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd5 = new SqlCommand("Insert into transport" + "(transportnomer, godvipuska, datavidac4i, familiaa, imia, ot4estvoo, adrespropiska, deistvitelyno, identifinomer, marka, modely, tip, massa, kategorii, obyemdvigatelya, tiptopliva, nomerdvigatelya, cvet, osobieotmetki, udidtransport) " + "Values (@param0, @param1, @param2, @param3, @param4, @param5, @param6, @param7, @param8, @param9, @param10, @param11, @param12, @param13, @param14, @param15, @param16, @param17, @param18, @param19)", conn);

                SqlParameter param5;
                param5 = new SqlParameter();
                param5.ParameterName = "@param0";
                param5.Value = textBox52.Text;
                param5.SqlDbType = SqlDbType.NVarChar;
                cmd5.Parameters.Add(param5);

                param5 = new SqlParameter();
                param5.ParameterName = "@param1";
                param5.Value = textBox51.Text;
                param5.SqlDbType = SqlDbType.DateTime;
                cmd5.Parameters.Add(param5);

                param5 = new SqlParameter();
                param5.ParameterName = "@param2";
                param5.Value = textBox50.Text;
                param5.SqlDbType = SqlDbType.DateTime;
                cmd5.Parameters.Add(param5);

                param5 = new SqlParameter();
                param5.ParameterName = "@param3";
                param5.Value = textBox49.Text;
                param5.SqlDbType = SqlDbType.NVarChar;
                cmd5.Parameters.Add(param5);

                param5 = new SqlParameter();
                param5.ParameterName = "@param4";
                param5.Value = textBox48.Text;
                param5.SqlDbType = SqlDbType.NVarChar;
                cmd5.Parameters.Add(param5);

                param5 = new SqlParameter();
                param5.ParameterName = "@param5";
                param5.Value = textBox47.Text;
                param5.SqlDbType = SqlDbType.NVarChar;
                cmd5.Parameters.Add(param5);

                param5 = new SqlParameter();
                param5.ParameterName = "@param6";
                param5.Value = textBox46.Text;
                param5.SqlDbType = SqlDbType.NVarChar;
                cmd5.Parameters.Add(param5);

                param5 = new SqlParameter();
                param5.ParameterName = "@param7";
                param5.Value = textBox45.Text;
                param5.SqlDbType = SqlDbType.DateTime;
                cmd5.Parameters.Add(param5);

                param5 = new SqlParameter();
                param5.ParameterName = "@param8";
                param5.Value = textBox44.Text;
                param5.SqlDbType = SqlDbType.NVarChar;
                cmd5.Parameters.Add(param5);

                param5 = new SqlParameter();
                param5.ParameterName = "@param9";
                param5.Value = textBox43.Text;
                param5.SqlDbType = SqlDbType.NVarChar;
                cmd5.Parameters.Add(param5);

                param5 = new SqlParameter();
                param5.ParameterName = "@param10";
                param5.Value = textBox42.Text;
                param5.SqlDbType = SqlDbType.NVarChar;
                cmd5.Parameters.Add(param5);

                param5 = new SqlParameter();
                param5.ParameterName = "@param11";
                param5.Value = textBox41.Text;
                param5.SqlDbType = SqlDbType.NVarChar;
                cmd5.Parameters.Add(param5);

                param5 = new SqlParameter();
                param5.ParameterName = "@param12";
                param5.Value = textBox40.Text;
                param5.SqlDbType = SqlDbType.NVarChar;
                cmd5.Parameters.Add(param5);

                param5 = new SqlParameter();
                param5.ParameterName = "@param13";
                param5.Value = textBox39.Text;
                param5.SqlDbType = SqlDbType.NVarChar;
                cmd5.Parameters.Add(param5);

                param5 = new SqlParameter();
                param5.ParameterName = "@param14";
                param5.Value = textBox38.Text;
                param5.SqlDbType = SqlDbType.NVarChar;
                cmd5.Parameters.Add(param5);

                param5 = new SqlParameter();
                param5.ParameterName = "@param15";
                param5.Value = textBox37.Text;
                param5.SqlDbType = SqlDbType.NVarChar;
                cmd5.Parameters.Add(param5);

                param5 = new SqlParameter();
                param5.ParameterName = "@param16";
                param5.Value = textBox36.Text;
                param5.SqlDbType = SqlDbType.NVarChar;
                cmd5.Parameters.Add(param5);

                param5 = new SqlParameter();
                param5.ParameterName = "@param17";
                param5.Value = textBox35.Text;
                param5.SqlDbType = SqlDbType.NVarChar;
                cmd5.Parameters.Add(param5);

                param5 = new SqlParameter();
                param5.ParameterName = "@param18";
                param5.Value = textBox34.Text;
                param5.SqlDbType = SqlDbType.NVarChar;
                cmd5.Parameters.Add(param5);

                param5 = new SqlParameter();
                param5.ParameterName = "@param19";
                param5.Value = textBox33.Text;
                param5.SqlDbType = SqlDbType.NVarChar;
                cmd5.Parameters.Add(param5);
                try
                {
                    cmd5.ExecuteNonQuery();
                }
                catch
                {

                    MessageBox.Show("Не все поля заполнены", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }



                cmd5 = new SqlCommand("select * from transport", conn);
                SqlDataAdapter DA5 = new SqlDataAdapter(cmd5);
                DataTable qw5 = new DataTable();
                DA5.Fill(qw5);
                dataGridView4.DataSource = qw5;



                conn.Close();
                conn.Dispose();

            }
            catch
            {
            }
            loadDatabaseToGrid();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox33.Text != "")
            {
                SqlConnection conn111 = new SqlConnection(connStr);
                conn111.Open();
                SqlCommand cmd6 = new SqlCommand("SELECT * FROM transport WHERE udidtransport ='" + textBox33.Text + "'", conn111);

                // cmd6 = new SqlCommand("SELECT * FROM transport WHERE transportnomer ='" + textBox53.Text + "'", conn);
                SqlDataAdapter DA6 = new SqlDataAdapter(cmd6);
                DataTable qw6 = new DataTable();
                DA6.Fill(qw6);
                dataGridView4.DataSource = qw6;

                if (qw6.Rows.Count != 0)
                {
                    textBox52.Text = qw6.Rows[0]["transportnomer"].ToString();
                    textBox51.Text = qw6.Rows[0]["godvipuska"].ToString();
                    textBox50.Text = qw6.Rows[0]["datavidac4i"].ToString();
                    textBox49.Text = qw6.Rows[0]["familiaa"].ToString();
                    textBox48.Text = qw6.Rows[0]["imia"].ToString();
                    textBox47.Text = qw6.Rows[0]["ot4estvoo"].ToString();
                    textBox46.Text = qw6.Rows[0]["adrespropiska"].ToString();
                    textBox45.Text = qw6.Rows[0]["deistvitelyno"].ToString();
                    textBox44.Text = qw6.Rows[0]["identifinomer"].ToString();
                    textBox43.Text = qw6.Rows[0]["marka"].ToString();
                    textBox42.Text = qw6.Rows[0]["modely"].ToString();
                    textBox41.Text = qw6.Rows[0]["tip"].ToString();
                    textBox40.Text = qw6.Rows[0]["massa"].ToString();
                    textBox39.Text = qw6.Rows[0]["kategorii"].ToString();
                    textBox38.Text = qw6.Rows[0]["obyemdvigatelya"].ToString();
                    textBox37.Text = qw6.Rows[0]["tiptopliva"].ToString();
                    textBox36.Text = qw6.Rows[0]["nomerdvigatelya"].ToString();
                    textBox35.Text = qw6.Rows[0]["cvet"].ToString();
                    textBox34.Text = qw6.Rows[0]["osobieotmetki"].ToString();
               //     textBox32.Text = qw6.Rows[0]["udidtransport"].ToString();

                }
                else
                {
                     textBox52.Text = "";
                     textBox51.Text = "";
                     textBox50.Text = "";
                     textBox49.Text = "";
                     textBox48.Text = "";
                     textBox47.Text = "";
                     textBox46.Text = "";
                     textBox45.Text = "";
                     textBox44.Text = "";
                     textBox43.Text = "";
                     textBox42.Text = "";
                     textBox41.Text = "";
                     textBox40.Text = "";
                     textBox39.Text = "";
                     textBox38.Text = "";
                     textBox37.Text = "";
                     textBox36.Text = "";
                     textBox35.Text = "";
                     textBox34.Text = "";
                    //       textBox32.Text = "";
                }


                try
                {
                    cmd6.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Введите UDID документа", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                conn111.Close();
                conn111.Dispose();
            }
            else
            { //MessageBox.Show("Введите UDID документа", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                reloadTable(null,null);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox33.Text != "")
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd7 = new SqlCommand("DELETE FROM transport WHERE udidtransport= '" + textBox33.Text + "'", conn);


                // cmd7 = new SqlCommand("DELETE FROM transport WHERE udidtransport= (" + Convert.ToInt32(textBox53.Text) + ")", conn);
                SqlDataAdapter DA7 = new SqlDataAdapter(cmd7);
                DataTable qw7 = new DataTable();
                DA7.Fill(qw7);
                dataGridView4.DataSource = qw7;
                try
                {
                    cmd7.ExecuteNonQuery();
                }
                catch
                {

                    MessageBox.Show("Введите значение", "Удаление");
                    return;
                }
                SqlCommand cmd777 = new SqlCommand("select * from transport", conn);
                SqlDataAdapter DA777 = new SqlDataAdapter(cmd777);
                DataTable qw777 = new DataTable();
                DA777.Fill(qw777);
                dataGridView4.DataSource = qw777;
                conn.Close();
                conn.Dispose();
            }
            else
            {
                MessageBox.Show("Введите UDID документа", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            loadDatabaseToGrid();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmdupd11 = new SqlCommand("UPDATE [transport] " + " SET [godvipuska]=@s2, [datavidac4i]=@s3, [familiaa]=@s4, [imia]=@s5, [ot4estvoo]=@s6, [adrespropiska]=@s7, [deistvitelyno]=@s8, [identifinomer]=@s9, [marka]=@s10, [modely]=@s11, [tip]=@s12, [massa]=@s13, [kategorii]=@s14, [obyemdvigatelya]=@s15, [tiptopliva]=@s16, [nomerdvigatelya]=@s17, [cvet]=@s18, [osobieotmetki]=@s19, [transportnomer]=@s1 " + " WHERE [udidtransport]=@s20", conn);

                cmdupd11.Parameters.AddWithValue("@s1", textBox52.Text);
                cmdupd11.Parameters.AddWithValue("@s2", textBox51.Text);
                cmdupd11.Parameters.AddWithValue("@s3", textBox50.Text);
                cmdupd11.Parameters.AddWithValue("@s4", textBox49.Text);
                cmdupd11.Parameters.AddWithValue("@s5", textBox48.Text);
                cmdupd11.Parameters.AddWithValue("@s6", textBox47.Text);
                cmdupd11.Parameters.AddWithValue("@s7", textBox46.Text);
                cmdupd11.Parameters.AddWithValue("@s8", textBox45.Text);
                cmdupd11.Parameters.AddWithValue("@s9", textBox44.Text);
                cmdupd11.Parameters.AddWithValue("@s10", textBox43.Text);
                cmdupd11.Parameters.AddWithValue("@s11", textBox42.Text);
                cmdupd11.Parameters.AddWithValue("@s12", textBox41.Text);
                cmdupd11.Parameters.AddWithValue("@s13", textBox40.Text);
                cmdupd11.Parameters.AddWithValue("@s14", textBox39.Text);
                cmdupd11.Parameters.AddWithValue("@s15", textBox38.Text);
                cmdupd11.Parameters.AddWithValue("@s16", textBox37.Text);
                cmdupd11.Parameters.AddWithValue("@s17", textBox36.Text);
                cmdupd11.Parameters.AddWithValue("@s18", textBox35.Text);
                cmdupd11.Parameters.AddWithValue("@s19", textBox34.Text);
                cmdupd11.Parameters.AddWithValue("@s20", textBox33.Text);



                try
                {
                    cmdupd11.ExecuteNonQuery();
                }
                catch
                {

                    MessageBox.Show("Проверьте все поля", "Изменение");
                    return;
                }



                cmdupd11 = new SqlCommand("SELECT * from transport", conn);
                SqlDataAdapter DA11 = new SqlDataAdapter(cmdupd11);
                DataTable qw11 = new DataTable();
                DA11.Fill(qw11);
                dataGridView4.DataSource = qw11;



                conn.Close();
                conn.Dispose();

            }
            catch
            {
            }
            loadDatabaseToGrid();
        }

        private void textBox53_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (UDIDBox.Text != "")
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM VU WHERE UDID ='" + UDIDBox.Text + "'", conn);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataTable qw = new DataTable();
                DA.Fill(qw);
                if (qw.Rows.Count != 0)
                {
                    FamiliaBox.Text = qw.Rows[0]["familia"].ToString();
                    ImyaBox.Text = qw.Rows[0]["name"].ToString();
                    Ot4estvoBox.Text = qw.Rows[0]["otchestvo"].ToString();
                    DMGBox.Text = qw.Rows[0]["datar"].ToString();
                    RodilsyaBox.Text = qw.Rows[0]["mestor"].ToString();
                    DataVida4iBox.Text = qw.Rows[0]["datav"].ToString();
                    DataOkon4aniyaBox.Text = qw.Rows[0]["datao"].ToString();
                    NomerDokumentaBox.Text = qw.Rows[0]["serianomer"].ToString();
                    VidalBox.Text = qw.Rows[0]["gruppakrovi"].ToString();

                }
                else
                {
                    FamiliaBox.Text = "";
                    ImyaBox.Text = "";
                    Ot4estvoBox.Text = "";
                    DMGBox.Text = "";
                    RodilsyaBox.Text = "";
                    DataVida4iBox.Text = "";
                    DataOkon4aniyaBox.Text = "";
                    NomerDokumentaBox.Text = "";
                    VidalBox.Text = "";
                }

                SqlCommand cmd29 = new SqlCommand("SELECT vu.udid, vu.familia, protocol.nomerprotocola, protocol.registranomer,protocol.famsotr,protocol.nomerwetonasotr,protocol.statia, protocol.status FROM VU inner join protocol on vu.serianomer = protocol.nomervod WHERE udid LIKE '" + UDIDBox.Text + "'", conn);
                SqlDataAdapter DA29 = new SqlDataAdapter(cmd29);
                DataTable qw29 = new DataTable();
                DA29.Fill(qw29);
                dataGridView1.DataSource = qw29;
                dataGridView1.Columns[0].HeaderText = "UDID";
                dataGridView1.Columns[1].HeaderText = "Фамилия";
                dataGridView1.Columns[2].HeaderText = "Номер протокола";
                dataGridView1.Columns[3].HeaderText = "Регистрационный номер";
                dataGridView1.Columns[4].HeaderText = "Фамилия сотрудника";
                dataGridView1.Columns[5].HeaderText = "Номер жетона";
                dataGridView1.Columns[6].HeaderText = "Статья";
                dataGridView1.Columns[7].HeaderText = "Статус";

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Не удалось добавить ВУ в базу", "Добавление ВУ");
                    return;
                }



                conn.Close();
                conn.Dispose();
            }
          //  else { MessageBox.Show("Введите UDID документа", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                SqlCommand cmd33 = new SqlCommand("Insert into protocol" +
    "(nomerprotocola, nomervod, registranomer, datanarush, famsotr, nomerwetonasotr, narfio, statia, status) " +
    "Values (@param0, @param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8)", conn);



                SqlParameter param33;
                param33 = new SqlParameter();

                param33.ParameterName = "@param0";
                param33.Value = textBox54.Text;
                param33.SqlDbType = SqlDbType.NVarChar;
                cmd33.Parameters.Add(param33);

                param33 = new SqlParameter();
                param33.ParameterName = "@param1";
                param33.Value = textBox55.Text;
                param33.SqlDbType = SqlDbType.NVarChar;
                cmd33.Parameters.Add(param33);

                param33 = new SqlParameter();
                param33.ParameterName = "@param2";
                param33.Value = textBox56.Text;
                param33.SqlDbType = SqlDbType.NVarChar;
                cmd33.Parameters.Add(param33);

                param33 = new SqlParameter();
                param33.ParameterName = "@param3";
                param33.Value = maskedTextBox1.Text;
                param33.SqlDbType = SqlDbType.DateTime;
                cmd33.Parameters.Add(param33);

                param33 = new SqlParameter();
                param33.ParameterName = "@param4";
                param33.Value = textBox57.Text;
                param33.SqlDbType = SqlDbType.NVarChar;
                cmd33.Parameters.Add(param33);

                param33 = new SqlParameter();
                param33.ParameterName = "@param5";
                param33.Value = textBox58.Text;
                param33.SqlDbType = SqlDbType.NVarChar;
                cmd33.Parameters.Add(param33);

                param33 = new SqlParameter();
                param33.ParameterName = "@param6";
                param33.Value = textBox59.Text;
                param33.SqlDbType = SqlDbType.NVarChar;
                cmd33.Parameters.Add(param33);

                param33 = new SqlParameter();
                param33.ParameterName = "@param7";
                param33.Value = textBox60.Text;
                param33.SqlDbType = SqlDbType.NVarChar;
                cmd33.Parameters.Add(param33);

                param33 = new SqlParameter();
                param33.ParameterName = "@param8";
                param33.Value = comboBox1.Text;
                param33.SqlDbType = SqlDbType.NVarChar;
                cmd33.Parameters.Add(param33);



                try
                {
                    cmd33.ExecuteNonQuery();
                }
                catch
                {

                    MessageBox.Show("Не все поля заполнены", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }



                cmd33 = new SqlCommand("select * from protocol", conn);
                SqlDataAdapter DA33 = new SqlDataAdapter(cmd33);
                DataTable qw33 = new DataTable();
                DA33.Fill(qw33);
                dataGridView5.DataSource = qw33;



                conn.Close();
                conn.Dispose();

            }
            catch
            {
            }
            loadDatabaseToGrid();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox62.Text != "")
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd34 = new SqlCommand("DELETE FROM protocol WHERE nomerprotocola= '" + textBox62.Text + "'", conn);

                try
                {
                    cmd34.ExecuteNonQuery();
                }
                catch
                {

                    MessageBox.Show("Введите значение", "Удаление");
                    return;
                }
                cmd34 = new SqlCommand("select * from protocol", conn);
                SqlDataAdapter DA34 = new SqlDataAdapter(cmd34);
                DataTable qw34 = new DataTable();
                DA34.Fill(qw34);
                dataGridView5.DataSource = qw34;
                conn.Close();
                conn.Dispose();
            }
            else { MessageBox.Show("Введите номер протокола", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            loadDatabaseToGrid();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox62.Text != "")
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd61 = new SqlCommand("SELECT * FROM protocol WHERE nomerprotocola ='" + textBox62.Text + "'", conn);

                cmd61 = new SqlCommand("SELECT * FROM protocol WHERE nomerprotocola ='" + textBox62.Text + "'", conn);
                SqlDataAdapter DA61 = new SqlDataAdapter(cmd61);
                DataTable qw61 = new DataTable();
                DA61.Fill(qw61);
                dataGridView5.DataSource = qw61;
                if (qw61.Rows.Count != 0)
                {
                    textBox54.Text = qw61.Rows[0]["nomerprotocola"].ToString();
                    textBox55.Text = qw61.Rows[0]["nomervod"].ToString();
                    textBox56.Text = qw61.Rows[0]["registranomer"].ToString();
                    textBox59.Text = qw61.Rows[0]["narfio"].ToString();
                    maskedTextBox1.Text = qw61.Rows[0]["datanarush"].ToString();
                    textBox57.Text = qw61.Rows[0]["famsotr"].ToString();
                    textBox58.Text = qw61.Rows[0]["nomerwetonasotr"].ToString();
                    textBox60.Text = qw61.Rows[0]["statia"].ToString();
                    comboBox1.Text = qw61.Rows[0]["status"].ToString();


                }
                try
                {
                    cmd61.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Введите значение", "Поиск");
                    return;
                }
                conn.Close();
                conn.Dispose();
            }
            else
            { MessageBox.Show("Введите номер протокола", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmdupd25 = new SqlCommand("UPDATE [protocol] " + " SET [nomervod]=@s2, [registranomer]=@s3, [narfio]=@s4, [datanarush]=@s5, [famsotr]=@s6, [nomerwetonasotr]=@s7, [statia]=@s8, [status]=@s9 " + " WHERE [nomerprotocola]=@s1", conn);

                cmdupd25.Parameters.AddWithValue("@s1", textBox54.Text);
                cmdupd25.Parameters.AddWithValue("@s2", textBox55.Text);
                cmdupd25.Parameters.AddWithValue("@s3", textBox56.Text);
                cmdupd25.Parameters.AddWithValue("@s4", textBox59.Text);
                cmdupd25.Parameters.AddWithValue("@s5", maskedTextBox1.Text);
                cmdupd25.Parameters.AddWithValue("@s6", textBox57.Text);
                cmdupd25.Parameters.AddWithValue("@s7", textBox58.Text);
                cmdupd25.Parameters.AddWithValue("@s8", textBox60.Text);
                cmdupd25.Parameters.AddWithValue("@s9", comboBox1.Text);

                try
                {
                    cmdupd25.ExecuteNonQuery();
                }
                catch
                {

                    MessageBox.Show("Проверьте все поля", "Изменение");
                    return;
                }



                cmdupd25 = new SqlCommand("SELECT * from protocol", conn);
                SqlDataAdapter DA25 = new SqlDataAdapter(cmdupd25);
                DataTable qw25 = new DataTable();
                DA25.Fill(qw25);
                dataGridView5.DataSource = qw25;



                conn.Close();
                conn.Dispose();

            }
            catch
            {
            }
            loadDatabaseToGrid();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox32.Text != "")
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd43 = new SqlCommand("SELECT * FROM transport WHERE udidtransport ='" + textBox32.Text + "'", conn);
                SqlDataAdapter DA43 = new SqlDataAdapter(cmd43);
                DataTable qw43 = new DataTable();
                DA43.Fill(qw43);
                if (qw43.Rows.Count != 0)
                {
                    textBox13.Text = qw43.Rows[0]["transportnomer"].ToString();
                    textBox14.Text = qw43.Rows[0]["godvipuska"].ToString();
                    textBox15.Text = qw43.Rows[0]["datavidac4i"].ToString();
                    textBox16.Text = qw43.Rows[0]["familiaa"].ToString();
                    textBox17.Text = qw43.Rows[0]["imia"].ToString();
                    textBox18.Text = qw43.Rows[0]["ot4estvoo"].ToString();
                    textBox19.Text = qw43.Rows[0]["adrespropiska"].ToString();
                    textBox20.Text = qw43.Rows[0]["deistvitelyno"].ToString();
                    textBox21.Text = qw43.Rows[0]["identifinomer"].ToString();
                    textBox22.Text = qw43.Rows[0]["marka"].ToString();
                    textBox23.Text = qw43.Rows[0]["modely"].ToString();
                    textBox24.Text = qw43.Rows[0]["tip"].ToString();
                    textBox25.Text = qw43.Rows[0]["massa"].ToString();
                    textBox26.Text = qw43.Rows[0]["kategorii"].ToString();
                    textBox27.Text = qw43.Rows[0]["obyemdvigatelya"].ToString();
                    textBox28.Text = qw43.Rows[0]["tiptopliva"].ToString();
                    textBox29.Text = qw43.Rows[0]["nomerdvigatelya"].ToString();
                    textBox30.Text = qw43.Rows[0]["cvet"].ToString();
                    textBox31.Text = qw43.Rows[0]["osobieotmetki"].ToString();
                    //  textBox32.Text = qw43.Rows[0]["udidtransport"].ToString();

                }
                else {
                    textBox13.Text = "";
                    textBox14.Text = "";
                    textBox15.Text = "";
                    textBox16.Text = "";
                    textBox17.Text = "";
                    textBox18.Text = "";
                    textBox19.Text = "";
                    textBox20.Text = "";
                    textBox21.Text = "";
                    textBox22.Text = "";
                    textBox23.Text = "";
                    textBox24.Text = "";
                    textBox25.Text = "";
                    textBox26.Text = "";
                    textBox27.Text = "";
                    textBox28.Text = "";
                    textBox29.Text = "";
                    textBox30.Text = "";
                    textBox31.Text = "";
                }
                SqlCommand cmd54 = new SqlCommand("SELECT transport.udidtransport, transport.transportnomer,transport.familiaa, protocol.nomerprotocola,protocol.famsotr,protocol.nomerwetonasotr,protocol.statia, protocol.status FROM transport inner join protocol on transport.transportnomer = protocol.registranomer WHERE udidtransport LIKE '" + textBox32.Text + "'", conn);
                SqlDataAdapter DA54 = new SqlDataAdapter(cmd54);
                DataTable qw54 = new DataTable();
                DA54.Fill(qw54);
                dataGridView3.DataSource = qw54;
                dataGridView3.Columns[0].HeaderText = "UDID";
                dataGridView3.Columns[1].HeaderText = "Регистрационный номер";
                dataGridView3.Columns[2].HeaderText = "Фамилия";
                dataGridView3.Columns[3].HeaderText = "Номер протокола";
                dataGridView3.Columns[4].HeaderText = "Фамилия сотрудника";
                dataGridView3.Columns[5].HeaderText = "Номер жетона";
                dataGridView3.Columns[6].HeaderText = "Статья";
                dataGridView3.Columns[7].HeaderText = "Статус";

                try
                {
                    cmd43.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Не удалось добавить ВУ в базу", "Добавление ВУ");
                    return;
                }



                conn.Close();
                conn.Dispose();
            }
            else { MessageBox.Show("Введите UDID документа", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            this.textBox12.TextChanged -= new System.EventHandler(this.button5_Click);

            try
            {
                bns.Position = dataGridView2.CurrentRow.Index;
            }
            catch
            { }

            this.textBox12.TextChanged += new System.EventHandler(this.button5_Click);

        }

        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            this.textBox33.TextChanged -= new System.EventHandler(this.button10_Click);
            try
            {
                bns2.Position = dataGridView4.CurrentRow.Index;
            }
            catch
            { }
            this.textBox33.TextChanged += new System.EventHandler(this.button10_Click);
        }


        private void dataGridView5_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                bns3.Position = dataGridView5.CurrentRow.Index;
            }
            catch
            { }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox49_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox48_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox47_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox46_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox41_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox35_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox34_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox59_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox57_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[0-9\b]");
        }

        private void textBox54_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[0-9\b]");
        }

        private void textBox55_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[0-9\b]");
        }

        private void textBox58_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[0-9\b]");
        }

        private void textBox60_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[0-9\b]");
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                администраторToolStripMenuItem_Click(null,null);
            }
        }

        private void UDIDBox_MouseUp(object sender, MouseEventArgs e)
        {
            UDIDBox.Text = "";
            FamiliaBox.Text = "";
            ImyaBox.Text = "";
            Ot4estvoBox.Text = "";
            DMGBox.Text = "";
            RodilsyaBox.Text = "";
            DataVida4iBox.Text = "";
            DataOkon4aniyaBox.Text = "";
            NomerDokumentaBox.Text = "";
            VidalBox.Text = "";
        }
    }
}
