// Jacobi.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <math.h>
#include <algorithm>

using namespace std;

#define DELETE(a) if((a)!=nullptr){delete (a);(a)=nullptr;}
#define DELETE_ARRAY(a) if((a)!=nullptr){delete[](a);(a)=nullptr;}
#define DELETE_ARRAY_2D(a,n) if((a)!=nullptr){for(int i = 0; i < n; i++)delete[]a[i];delete[] a; (a) = nullptr;}

bool uslovieShodimosti(double** A);
bool uslovieTochnosti(double* x, double* xs, double epsilon);
void fillExpression(double** A, double* B);
void doSimpleIterationsJacobi(double** A, double* B, double* initXs, double epsilon);
const int matrix_size = 3;
const double epsilon = DBL_EPSILON;

int main()
{
	// init
	auto B = new double[matrix_size];
	double** A = new double*[matrix_size];
	for (int i = 0; i < matrix_size; i++)
		A[i] = new double[matrix_size];

	// fill
	fillExpression(A, B);

	auto result = uslovieShodimosti(A);
	if (result)
	{
		cout << "uslovie shodimosti ne sobljudaetsa" << endl;
	}
	else
	{
		cout << "uslovie shodimosti sobljudaetsa" << endl;


		auto initXs = new double[matrix_size];

		cout << "Enter init Xs:" << endl;

		for (int i = 0; i < matrix_size; i++)
			cin >> initXs[i];


		// calculate
		doSimpleIterationsJacobi(A, B, initXs, epsilon);

		// output
		for (int i = 0; i < matrix_size; i++)
		{
			cout << "X" << i + 1 << " = " << initXs[i] << endl;
		}
	}




	// clean
	DELETE_ARRAY(B);
	DELETE_ARRAY_2D(A, matrix_size);

	system("pause");
	return 0;
}

void fillExpression(double** A, double* B) {

	A[1][0] = 1;
	A[1][1] = 3;
	A[1][2] = -2;

	B[1] = 7;

	A[0][0] = 2;
	A[0][1] = -1;
	A[0][2] = 1;

	B[0] = 5;

	A[2][0] = 1;
	A[2][1] = 2;
	A[2][2] = 3;

	B[2] = 10;

}

void doSimpleIterationsJacobi(double** A, double* B, double* originXs, double epsilon) {

	auto Xs = new double[matrix_size];
	double prec = 0;

	auto iterationCounter = 0;
	do {

		for (int i = 0; i < matrix_size; i++)
		{
			auto b = B[i];
			for (int j = 0; j < matrix_size; j++) {
				if (i != j)
					b -= A[i][j] * originXs[j];
			}
			Xs[i] = b / A[i][i];

			if (i == 0)
				prec = fabs(originXs[i] - Xs[i]);

			if (fabs(originXs[i] - Xs[i]) > prec)
				prec = fabs(originXs[i] - Xs[i]);

			originXs[i] = Xs[i];
		}
		cout << "Iteration: " << ++iterationCounter << endl;

	} while (prec > epsilon);

	DELETE_ARRAY(Xs);
}


bool uslovieShodimosti(double** A) {
	if (fabs(A[0][0]) > (fabs(A[0][1]) + fabs(A[0][2])) &&
		fabs(A[1][1]) > (fabs(A[1][0]) + fabs(A[1][2])) &&
		fabs(A[2][2]) > (fabs(A[2][0]) + fabs(A[2][1])))
		return true;
	return false;
}

bool uslovieTochnosti(double* x, double* xs, double epsilon) {
	auto maxD = max(fabs(xs[0] - x[0]), max(fabs(xs[1] - x[1]), fabs(xs[2] - x[2])));

	if (epsilon > maxD)
		return true;
	return false;
}
