// MusicalComposition.cs
using System;

// Атрибут Serializable необхідний для запису/зчитування об'єкта у файл (серіалізації)
[Serializable]
public class MusicalComposition : IComparable<MusicalComposition>
{
    // Приватні поля для зберігання даних
    private string _title;
    private string _artist;
    private string _album;
    private string _genre;
    private TimeSpan _duration;

    #region Конструктори

    /// <summary>
    /// Конструктор за замовчуванням.
    /// Ініціалізує об'єкт з порожніми, але валідними значеннями.
    /// </summary>
    public MusicalComposition()
    {
        _title = "Unknown Title";
        _artist = "Unknown Artist";
        _album = "Unknown Album";
        _genre = "Unknown Genre";
        _duration = TimeSpan.Zero;
    }

    /// <summary>
    /// Параметризований конструктор з обробкою виключень.
    /// </summary>
    public MusicalComposition(string title, string artist, string album, string genre, TimeSpan duration)
    {
        // Використовуємо властивості для присвоєння значень,
        // щоб спрацювала логіка валідації.
        Title = title;
        Artist = artist;
        Album = album;
        Genre = genre;
        Duration = duration;
    }

    #endregion

    #region Властивості з обробкою виключень

    public string Title
    {
        get => _title;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Назва композиції не може бути порожньою.");
            }
            _title = value;
        }
    }

    public string Artist
    {
        get => _artist;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Ім'я виконавця не може бути порожнім.");
            }
            _artist = value;
        }
    }

    public string Album
    {
        get => _album;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                // Для альбому допустимо порожнє значення (напр. сингл), але не null
                _album = value ?? "Single";
            }
            else
            {
                _album = value;
            }
        }
    }

    public string Genre
    {
        get => _genre;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Жанр не може бути порожнім.");
            }
            _genre = value;
        }
    }

    public TimeSpan Duration
    {
        get => _duration;
        set
        {
            if (value < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(Duration), "Тривалість не може бути від'ємною.");
            }
            _duration = value;
        }
    }

    #endregion

    #region Реалізація стандартних інтерфейсів та методів

    /// <summary>
    /// Реалізація методу CompareTo інтерфейсу IComparable для сортування.
    /// Сортування відбувається спочатку за жанром (в алфавітному порядку),
    /// а потім за тривалістю (від меншої до більшої).
    /// </summary>
    public int CompareTo(MusicalComposition other)
    {
        if (other == null) return 1;

        // 1. Порівнюємо за жанром
        int genreComparison = string.Compare(this.Genre, other.Genre, StringComparison.OrdinalIgnoreCase);

        if (genreComparison != 0)
        {
            return genreComparison;
        }

        // 2. Якщо жанри однакові, порівнюємо за тривалістю
        return this.Duration.CompareTo(other.Duration);
    }

    /// <summary>
    /// Перевизначений метод для гарного відображення об'єкта у списках.
    /// </summary>
    public override string ToString()
    {
        // Форматуємо тривалість у вигляді мм:сс
        return $"{Artist} - {Title} ({Genre}) [{Duration:mm\\:ss}]";
    }

    #endregion
}