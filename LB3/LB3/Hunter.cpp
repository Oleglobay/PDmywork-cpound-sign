
#include "Hunter.h"
#include <cstdlib>

Hunter::Hunter(string n, int h, int g, int a)
{
    name = n;
    health = h;
    gold = g;
    arrows = a;
    loot = 0;
}

void Hunter::hunt()
{
    if (health <= 0)
    {
        cout << name << " не має здоров'я!" << endl;
        return;
    }

    if (arrows <= 0)
    {
        cout << name << " не має стріл!" << endl;
        return;
    }

    arrows--;

    if (rand() % 2 == 1)
    {
        loot++;
        gold += 20;
        cout << name << " отримав здобич і 20 золота!" << endl;
    }
    else
    {
        health -= 20;

        if (health < 0)
            health = 0;

        cout << name << " втратив 20 здоров'я!" << endl;
    }
}

void Hunter::buyArrows()
{
    if (gold >= 10)
    {
        gold -= 10;
        arrows += 5;

        cout << name << " купив 5 стріл!" << endl;
    }
    else
    {
        cout << "Недостатньо золота!" << endl;
    }
}

void Hunter::showInfo()
{
    cout << "\n--- " << name << " ---" << endl;
    cout << "Здоров'я: " << health << endl;
    cout << "Золото: " << gold << endl;
    cout << "Стріли: " << arrows << endl;
    cout << "Здобич: " << loot << endl;
}

int Hunter::getLoot()
{
    return loot;
}

string Hunter::getName()
{
    return name;
}
