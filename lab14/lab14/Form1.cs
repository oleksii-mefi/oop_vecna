// Form1.cs
using System;
using System.Windows.Forms;

namespace lab14
{
    public partial class Form1 : Form
    {
        // Форма тепер не знає про логіку, вона лише має посилання на презентер
        private readonly FormPresenter _presenter;

        public Form1()
        {
            InitializeComponent();

            // Створюємо модель і презентер, передаючи йому цю форму
            var musicCollection = new CompositionCollection();
            _presenter = new FormPresenter(this, musicCollection);
        }

        // Публічні властивості, щоб презентер мав доступ до контролів
        public ListBox LstCompositions => lstCompositions;
        public TextBox TxtTitle => txtTitle;
        public TextBox TxtArtist => txtArtist;
        public TextBox TxtAlbum => txtAlbum;
        public TextBox TxtGenre => txtGenre;
        public MaskedTextBox MskDuration => mskDuration;
        public TextBox TxtFilterArtist => txtFilterArtist;

        // Публічні властивості для кнопок, щоб презентер міг підписатися на їхні події
        public Button BtnAdd => btnAdd;
        public Button BtnSort => btnSort;
        public Button BtnSave => btnSave;
        public Button BtnLoad => btnLoad;
        public Button BtnFilter => btnFilter;
        public Button BtnClearFilter => btnClearFilter;

        // Метод для очищення полів, який викликає презентер
        public void ClearInputFields()
        {
            txtTitle.Clear();
            txtArtist.Clear();
            txtAlbum.Clear();
            txtGenre.Clear();
            mskDuration.Clear();
        }

        // Обробники подій тепер ПУСТІ, бо вся логіка в презентері.
        // Ми їх залишаємо, бо дизайнер їх створив, але можна і видалити.
        // Краще видалити їх звідси і з Designer.cs, але для простоти можна залишити.
        private void btnAdd_Click(object sender, EventArgs e) { }
        private void btnSort_Click(object sender, EventArgs e) { }
        private void btnSave_Click(object sender, EventArgs e) { }
        private void btnLoad_Click(object sender, EventArgs e) { }
        private void btnFilter_Click(object sender, EventArgs e) { }
        private void btnClearFilter_Click(object sender, EventArgs e) { }
    }
}