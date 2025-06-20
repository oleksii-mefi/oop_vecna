// FormPresenter.cs
using System;
using System.Windows.Forms;
using lab14;

public class FormPresenter
{
    // Посилання на нашу форму (View) і модель даних
    private readonly Form1 _view;
    private readonly CompositionCollection _model;

    // Конструктор, який отримує форму і модель для роботи
    public FormPresenter(Form1 view, CompositionCollection model)
    {
        _view = view;
        _model = model;
        // Підписуємо методи цього класу на події форми
        SubscribeToEvents();
        // Початкове завантаження даних
        AddSampleData();
        UpdateCompositionList();
    }

    // Метод для підписки на події
    private void SubscribeToEvents()
    {
        _view.BtnAdd.Click += OnAddClick;
        _view.BtnSort.Click += OnSortClick;
        _view.BtnSave.Click += OnSaveClick;
        _view.BtnLoad.Click += OnLoadClick;
        _view.BtnFilter.Click += OnFilterClick;
        _view.BtnClearFilter.Click += OnClearFilterClick;
    }

    // Оновлення списку на формі
    private void UpdateCompositionList()
    {
        _view.LstCompositions.Items.Clear();
        foreach (var comp in _model.GetAllCompositions())
        {
            _view.LstCompositions.Items.Add(comp);
        }
    }

    private void AddSampleData()
    {
        try
        {
            _model.Add(new MusicalComposition("Stairway to Heaven", "Led Zeppelin", "Led Zeppelin IV", "Rock", new TimeSpan(0, 8, 2)));
            _model.Add(new MusicalComposition("Bohemian Rhapsody", "Queen", "A Night at the Opera", "Rock", new TimeSpan(0, 5, 55)));
            _model.Add(new MusicalComposition("So What", "Miles Davis", "Kind of Blue", "Jazz", new TimeSpan(0, 9, 22)));
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Помилка при додаванні тестових даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Вся логіка тепер тут
    private void OnAddClick(object sender, EventArgs e)
    {
        try
        {
            if (!TimeSpan.TryParseExact(_view.MskDuration.Text, "mm\\:ss", null, out TimeSpan duration))
            {
                throw new FormatException("Некоректний формат тривалості. Введіть у форматі 'хх:сс'.");
            }
            var newComposition = new MusicalComposition(
                _view.TxtTitle.Text, _view.TxtArtist.Text, _view.TxtAlbum.Text,
                _view.TxtGenre.Text, duration);
            _model.Add(newComposition);
            UpdateCompositionList();
            _view.ClearInputFields();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Помилка: {ex.Message}", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void OnSortClick(object sender, EventArgs e)
    {
        _model.Sort();
        UpdateCompositionList();
        MessageBox.Show("Композиції відсортовано.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void OnFilterClick(object sender, EventArgs e)
    {
        var artist = _view.TxtFilterArtist.Text;
        if (string.IsNullOrWhiteSpace(artist))
        {
            MessageBox.Show("Введіть ім'я виконавця.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        var filteredList = _model.FilterByArtist(artist);
        _view.LstCompositions.Items.Clear();
        foreach (var comp in filteredList)
        {
            _view.LstCompositions.Items.Add(comp);
        }
    }

    private void OnClearFilterClick(object sender, EventArgs e)
    {
        UpdateCompositionList();
        _view.TxtFilterArtist.Clear();
    }

    private void OnSaveClick(object sender, EventArgs e)
    {
        SaveFileDialog sfd = new SaveFileDialog { Filter = "Файли колекції (*.dat)|*.dat" };
        if (sfd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                _model.SaveToFile(sfd.FileName);
                MessageBox.Show("Колекцію збережено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show($"Помилка збереження: {ex.Message}"); }
        }
    }

    private void OnLoadClick(object sender, EventArgs e)
    {
        OpenFileDialog ofd = new OpenFileDialog { Filter = "Файли колекції (*.dat)|*.dat" };
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                _model.LoadFromFile(ofd.FileName);
                UpdateCompositionList();
                MessageBox.Show("Колекцію завантажено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show($"Помилка завантаження: {ex.Message}"); }
        }
    }
}