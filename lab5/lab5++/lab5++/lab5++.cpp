#include <iostream>
#include <string>
#include <Windows.h>
using namespace std;

// Абстрактний клас ССАВЦІ
class Mammals {
public:
    virtual string describe() const = 0; // Чисто віртуальна функція
    virtual ~Mammals() = default; // Віртуальний деструктор
};

// Похідний клас ТВАРИНИ
class Animals : public Mammals {
public:
    virtual string describe() const override = 0; // Чисто віртуальна функція
};

// Похідний клас ЛЮДИ
class Humans : public Mammals {
public:
    string describe() const override {
        return "Людина: Розумна істота, здатна до мислення і творчості.";
    }
};

// Похідний клас КОНЕЙ
class Horses : public Animals {
public:
    string describe() const override {
        return "Кінь: Великий ссавець, використовується для їзди верхи та перевезення вантажів.";
    }
};

// Похідний клас КОРІВ
class Cows : public Animals {
public:
    string describe() const override {
        return "Корова: Великий ссавець, використовується для виробництва молока та м'яса.";
    }
};

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    setlocale(LC_ALL, "");
    Humans human;
    Horses horse;
    Cows cow;

    cout << human.describe() << endl;
    cout << horse.describe() << endl;
    cout << cow.describe() << endl;

    return 0;
}
