// CompositionCollection.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class CompositionCollection
{
    private List<MusicalComposition> _compositions;

    public CompositionCollection()
    {
        // Формування колекції
        _compositions = new List<MusicalComposition>();
    }

    /// <summary>
    /// Додає нову композицію до колекції.
    /// </summary>
    public void Add(MusicalComposition composition)
    {
        _compositions.Add(composition);
    }

    /// <summary>
    /// Повертає всю колекцію для відображення.
    /// </summary>
    public List<MusicalComposition> GetAllCompositions()
    {
        return _compositions;
    }

    /// <summary>
    /// Сортує колекцію, використовуючи реалізацію IComparable в MusicalComposition.
    /// </summary>
    public void Sort()
    {
        _compositions.Sort();
    }

    /// <summary>
    /// Здійснює вибірку композицій за іменем виконавця.
    /// </summary>
    public List<MusicalComposition> FilterByArtist(string artist)
    {
        // Використовуємо LINQ для зручної фільтрації
        return _compositions
            .Where(c => c.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    /// <summary>
    /// Запис колекції у файл за допомогою бінарної серіалізації.
    /// </summary>
    public void SaveToFile(string filePath)
    {
        // Використовуємо using для гарантованого закриття потоку
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            // Серіалізуємо сам список, а не обгортку
            formatter.Serialize(fs, _compositions);
        }
    }

    /// <summary>
    /// Зчитування колекції з файлу.
    /// </summary>
    public void LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Файл не знайдено.", filePath);
        }

        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                // Десеріалізуємо об'єкт і приводимо його до типу List<MusicalComposition>
                _compositions = (List<MusicalComposition>)formatter.Deserialize(fs);
            }
            catch (SerializationException ex)
            {
                throw new SerializationException("Не вдалося десеріалізувати файл. Можливо, його формат пошкоджено.", ex);
            }
        }
    }
}
