#include <iostream>
#include <cmath>

using namespace std;

double makeDegree(double value, double degree)
{
	double temp = 1;

	for (int i = 0; i < degree; i++)
	{
		temp = temp * value;
	}

	return temp;
}

int det(double** array, int ColCount)
{
	int i; double** p = new double* [ColCount];
	int j = 0; int result = 0;
	int k = 1; int n = ColCount - 1;

	for (i = 0; i < ColCount; i++)
	{
		p[i] = new double[ColCount];
	}

	//1*1 matrix
	if (ColCount == 1)
	{
		result = array[0][0];
		return(result);
	}

	//2*2 matrix
	if (ColCount == 2)
	{
		result = array[0][0] * array[1][1] - (array[1][0] * array[0][1]);
		return(result);
	}

	//> 2*2 matrix
	if (ColCount > 2) {

		for (i = 0; i < ColCount; i++) {
			int d1 = 0;

			for (int k1 = 0; k1 < ColCount - 1; k1++) {

				if (k1 == i) {

					d1 = 1;
				}

				int d2 = 0;

				for (int k2 = 0; k2 < ColCount - 1; k2++) {

					if (k2 == 0) {
						d2 = 1;
					}

					p[k1][k2] = array[k1 + d1][k2 + d2];
				}
			}

			result = result + k * array[i][0] * det(p, n);
			k = -k;
		}
	}

	return(result);
}

void printMatrix(double** array, int n)
{
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			cout << array[i][j];
		}
		cout << endl;
	}
}

void forCramer(double** temp, int n, double* x, int* fun, int d, int index)
{
	for (int j = 0; j < n; j++) {
		temp[j][index] = fun[j];
	}

	x[index] = det(temp, n) / d;
}

void defTemp(double** temp, double** arr, int n)
{
	for (int i = 0; i < n; i++) {

		for (int j = 0; j < n; j++) {
			temp[i][j] = arr[i][j];
		}
	}
}

double P(double* tempArrOfA, int n, double x)
{
	double result = 0;
	for (int i = 0; i < n; i++) {

		result = result + tempArrOfA[n - 1 - i] * makeDegree(x, i);
	}

	return result;
}

int main()
{
	int n; cin >> n;

	double** arrayForSLAY = new double* [n];
	for (int i = 0; i < n; i++) {

		arrayForSLAY[i] = new double[n];
	}

	//x0 x1 x2
	for (int i = 0; i < n; i++) {
		int x; cin >> x;

		for (int j = 0; j < n; j++) {

			arrayForSLAY[i][j] = makeDegree(x, n - j - 1);
		}
	}

	int* fun = new int[n];

	//f0 f1 f2
	for (int i = 0; i < n; i++) {

		cin >> fun[i];
	}

	int d = det(arrayForSLAY, n);
	double* x = new double[n];

	double** temp = new double* [n];
	for (int i = 0; i < n; i++)
	{
		temp[i] = new double[n];
	}

	for (int i = 0; i < n; i++) {

		defTemp(temp, arrayForSLAY, n);
		forCramer(temp, n, x, fun, d, i);
	}

	double value; cin >> value;
	cout << P(x, n, value);

	return 0;
}