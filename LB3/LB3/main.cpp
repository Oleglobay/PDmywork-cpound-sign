
#include <iostream>
#include <cstdlib>
#include <ctime>
#include "Hunter.h"
#include "Menu.h"

using namespace std;

int main()
{
    setlocale(LC_ALL, "uk_UA");
    srand(time(0));

    Hunter hunter1("Îëåã", 100, 50, 5);
    Hunter hunter2("Àíäğ³é", 100, 50, 5);

    Menu menu;

    cout << "===== ÇÌÀÃÀÍÍß ÌÈÑËÈÂÖ²Â =====" << endl;

    hunter1.showInfo();
    hunter2.showInfo();

    menu.start(hunter1, hunter2);
    menu.results(hunter1, hunter2);

    return 0;
}
