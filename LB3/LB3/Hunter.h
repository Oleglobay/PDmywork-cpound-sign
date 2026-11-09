#pragma once
#include <iostream>
#include <string>
using namespace std;

class Hunter
{
private:
    string name;
    int health;
    int gold;
    int arrows;
    int loot;

public:
    Hunter(string n, int h, int g, int a);

    void hunt();
    void buyArrows();
    void showInfo();

    int getLoot();
    string getName();
};

