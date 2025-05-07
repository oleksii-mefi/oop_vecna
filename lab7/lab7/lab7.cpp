#include <iostream>
#include <string>
#include <list>
#include <Windows.h>

using namespace std;

struct Product {
    int id;
    string name;
    int quantity;
};

// Пошук товару за ID
Product* findById(list<Product>& products, int id) {
    for (auto& item : products)
        if (item.id == id) return &item;
    return nullptr;
}

// Вивід списку
void display(const list<Product>& products, const string& title) {
    cout << "\n " << title << " \n";
    if (products.empty()) {
        cout << "Список порожній.\n";
        return;
    }
    for (const auto& p : products)
        cout << "ID: " << p.id << ", Назва: " << p.name << ", Кількість: " << p.quantity << '\n';
}

int main() {
    setlocale(LC_ALL, ""); SetConsoleCP(1251); SetConsoleOutputCP(1251);

    list<Product> assortment = {
        {101, "Телефон", 50},
        {102, "Планшет", 30},
        {103, "Ноутбук", 20}
    };

    list<Product> orders = {
        {101, "Телефон", 10},
        {104, "Монітор", 5},
        {102, "Планшет", 15}
    };

    display(assortment, "Асортимент на складі");
    display(orders, "Список замовлень");

    // Надходження нового виробу
    cout << "\nНадходження нового виробу\n";
    int newId, newQty;
    string newName;
    cout << "ID виробу: "; cin >> newId;
    cout << "Назва: "; cin >> newName;
    cout << "Кількість: "; cin >> newQty;

    Product* found = findById(assortment, newId);
    if (found)
        found->quantity += newQty;
    else
        assortment.push_back({ newId, newName, newQty });

    display(assortment, "Асортимент після надходження");

    // Обробка замовлень
    cout << "\nОбробка замовлень\n";
    list<Product> updatedOrders;

    for (const auto& order : orders) {
        Product* stockItem = findById(assortment, order.id);
        if (stockItem && stockItem->quantity >= order.quantity) {
            stockItem->quantity -= order.quantity;
            cout << "Замовлення ID " << order.id << " виконано.\n";
        }
        else {
            updatedOrders.push_back(order);
            cout << "Замовлення ID " << order.id << " НЕ виконано. Недостатньо товару.\n";
        }
    }

    display(assortment, "Оновлений асортимент");
    display(updatedOrders, "Актуальний список замовлень");

    return 0;
}
