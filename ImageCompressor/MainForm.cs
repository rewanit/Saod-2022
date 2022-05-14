using ImageCompressor.TestModules;
using ImageCompressor.TestModules.Libs;

namespace ImageCompressor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        enum Libs
        {
            System,
            ImageSharp
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            FileTest();

        }

        private void FileTest()
        {
            var filepath = openFileDialog1.FileName;
            ITestBase testBase = (Libs)comboBox1.SelectedValue switch
            {
                Libs.System => new SystemDrawingTest(),
                Libs.ImageSharp => new ImageSharpTest(),
                _ => throw new Exception("тебе как это удалось?"),
            };
            var rez = testBase.Test(filepath);
            dataGridView1.DataSource = rez;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DataSource = Enum.GetValues(typeof(Libs));
            comboBox1.SelectedIndex = 0;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged; ;
        }

        private void ComboBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(openFileDialog1.FileName)) return;
            FileTest();
        }
    }
}