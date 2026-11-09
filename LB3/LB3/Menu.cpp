
#include "Menu.h"

void Menu::start(Hunter& h1, Hunter& h2)
{
    int choice, hunterChoice;

    do
    {
        cout << "\n===== МЕНЮ =====" << endl;
        cout << "1. Полювати" << endl;
        cout << "2. Купити стріли" << endl;
        cout << "3. Інформація про мисливця" << endl;
        cout << "4. Завершити змагання" << endl;
        cout << "Ваш вибір: ";
        cin >> choice;

        if (choice >= 1 && choice <= 3)
        {
            cout << "\n1. " << h1.getName() << endl;
            cout << "2. " << h2.getName() << endl;
            cout << "Оберіть мисливця: ";
            cin >> hunterChoice;

            Hunter* hunter = nullptr;

            if (hunterChoice == 1)
                hunter = &h1;
            else if (hunterChoice == 2)
                hunter = &h2;
            else
            {
                cout << "Неправильний вибір!" << endl;
                continue;
            }

            switch (choice)
            {
            case 1:
                hunter->hunt();
                break;

            case 2:
                hunter->buyArrows();
                break;

            case 3:
                hunter->showInfo();
                break;
            }
        }
        else if (choice != 4)
        {
            cout << "Неправильний пункт меню!" << endl;
        }

    } while (choice != 4);
}

void Menu::results(Hunter& h1, Hunter& h2)
{
    cout << "\n===== РЕЗУЛЬТАТИ =====" << endl;

    h1.showInfo();
    h2.showInfo();

    cout << "\n===== ПЕРЕМОЖЕЦЬ =====" << endl;

    if (h1.getLoot() > h2.getLoot())
        cout << "Переможець: " << h1.getName() << endl;
    else if (h2.getLoot() > h1.getLoot())
        cout << "Переможець: " << h2.getName() << endl;
    else
        cout << "Нічия!" << endl;
}
