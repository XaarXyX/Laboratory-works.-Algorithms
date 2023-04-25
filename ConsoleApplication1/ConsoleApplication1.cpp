#include <iostream>
#include <vector>
#include <thread>
#include <chrono>

using namespace std;

const int n_threads = 1;
const int H = 10;
const int W = 10;
const int K = 5;
const int P = (K - 1) / 2;
const int piH = H + 2 * P;
const int piW = W + 2 * P;

int input[H][W];
int kernel[K][K];
int padded_input[piH][piW];
int output[H][W];

void fill_and_print_input();  // Заполнение и вывод input единицами
void fill_and_print_kernel();  // Заполнение и вывод kernel единицами
void fill_and_print_padded_input();  // Заполнение и вывод padded_input
void fill_and_print_output();  // Заполнение и вывод output
void t_fill_output(int i_from, int i_to);  // Заполнение части output в отдельном потоке

int main()
{
    fill_and_print_input();
    fill_and_print_kernel();
    fill_and_print_padded_input();

    srand(time(NULL));
    auto start = chrono::high_resolution_clock::now();
    fill_and_print_output();
    auto end = chrono::high_resolution_clock::now();
    auto duration = chrono::duration_cast<std::chrono::microseconds>(end - start);
    cout << endl << duration.count() << " mks";
}

// Заполнение и вывод input единицами
void fill_and_print_input()
{
    cout << "input" << endl;
    for (int h = 0; h < H; h++)
    {
        for (int w = 0; w < W; w++)
        {
            input[h][w] = 1;
            cout << input[h][w] << ' ';
        }
        cout << endl;
    }
}

// Заполнение и вывод kernel единицами
void fill_and_print_kernel()
{
    cout << endl << "kernel" << endl;
    for (int h = 0; h < K; h++)
    {
        for (int w = 0; w < K; w++)
        {
            kernel[h][w] = 1;
            cout << kernel[h][w] << ' ';
        }
        cout << endl;
    }
}

// Заполнение и вывод padded_input
void fill_and_print_padded_input()
{
    for (int h = 0; h < piH; h++)
    {
        for (int w = 0; w < piW; w++)
        {
            padded_input[h][w] = 0;
        }
    }

    for (int h = (piH - H) / 2; h < (piH - H) / 2 + H; h++)
    {
        for (int w = (piW - W) / 2; w < (piW - W) / 2 + W; w++)
        {
            padded_input[h][w] = 1;
        }
    }

    cout << endl << "padded_input" << endl;
    for (int h = 0; h < piH; h++)
    {
        for (int w = 0; w < piW; w++)
        {
            cout << padded_input[h][w] << ' ';
        }
        cout << endl;
    }
}

// Заполнение и вывод output
void fill_and_print_output()
{
    vector<thread> threads;

    for (int t = 0; t < n_threads; t++)
    {
        int i_from = t * (H / n_threads);
        int i_to = i_from + (H / n_threads);
        t_fill_output(i_from, i_to);
    }

    for (thread& t : threads)
    {
        t.join();
    }

    cout << endl << "output" << endl;
    for (int h = 0; h < H; h++)
    {
        for (int w = 0; w < W; w++)
        {
            cout << output[h][w] << ' ';
        }
        cout << endl;
    }
}

// Заполнение части output в отдельном потоке
void t_fill_output(int i_from, int i_to)
{
    for (int i = i_from; i < i_to; i++)
    {
        for (int j = 0; j < W; j++)
        {
            for (int i1 = 0; i1 < K; i1++)
            {
                for (int j1 = 0; j1 < K; j1++)
                {
                    output[i][j] += kernel[i1][j1] * padded_input[i + i1][j + j1];
                }
            }
        }
    }
}