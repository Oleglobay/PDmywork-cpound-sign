#include <iostream>
#include <vector>
#include <iomanip>
#include <limits>

using namespace std;

int main()
{
    int groups;

    cout << "Вvedit kilkist grup (3-5): ";
    cin >> groups;

    if (cin.fail() || groups < 3 || groups > 5)
    {
        cout << "Pomylka! Kilkist grup maye buty vid 3 do 5.";
        return 1;
    }

    vector<vector<int>> jaggedArray(groups);


    for (int i = 0; i < groups; i++)
    {
        int students;

        cout << "\nKilkist studentiv u grupe " << i + 1 << " (10-30): ";
        cin >> students;

        if (cin.fail() || students < 10 || students > 30)
        {
            cout << "Pomylka! Kilkist studentiv maye buty vid 10 do 30.";
            return 1;
        }

        jaggedArray[i].resize(students);

        for (int j = 0; j < students; j++)
        {
            cout << "Otsinka studenta " << j + 1 << ": ";
            cin >> jaggedArray[i][j];

            if (cin.fail())
            {
                cout << "Pomylka vvedennya otsinky!";
                return 1;
            }
        }
    }

    long long totalSum = 0;
    int totalCount = 0;

    int totalMin = numeric_limits<int>::max();
    int totalMax = numeric_limits<int>::min();

    for (int i = 0; i < groups; i++)
    {
        long long sum = 0;

        int min = jaggedArray[i][0];
        int max = jaggedArray[i][0];

        for (int j = 0; j < jaggedArray[i].size(); j++)
        {
            int grade = jaggedArray[i][j];

            sum += grade;

            if (grade < min)
                min = grade;

            if (grade > max)
                max = grade;
        }


        cout << "\nGruppa " << i + 1 << ":\n";

        cout << "Seredniy bal: "
            << fixed << setprecision(2)
            << (double)sum / jaggedArray[i].size() << endl;

        cout << "Minimalna otsinka: " << min << endl;
        cout << "Maksymalna otsinka: " << max << endl;


        totalSum += sum;
        totalCount += jaggedArray[i].size();

        if (min < totalMin)
            totalMin = min;

        if (max > totalMax)
            totalMax = max;
    }


    cout << "\n===== VES POTIK =====\n";

    cout << "Seredniy bal potoku: "
        << fixed << setprecision(2)
        << (double)totalSum / totalCount << endl;

    cout << "Minimalna otsinka potoku: " << totalMin << endl;
    cout << "Maksymalna otsinka potoku: " << totalMax << endl;

    return 0;
}