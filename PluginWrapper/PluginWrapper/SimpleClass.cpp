#include "SimpleClass.h"
using namespace std;
int SimpleClass::SimpleFunction()
{
	return 1;
}

void SimpleClass::SavePosition(float x, float y, float z) {
	string XString = "X" + to_string(x);
	string YString = "Y" + to_string(y);
	string ZString = "Z" + to_string(z);


	string FinalString = XString + YString + ZString;
	ofstream unityFile;

	unityFile.open("UnityLoad.txt");
	unityFile.clear();
	if (unityFile.is_open()) {
		unityFile << FinalString;
	}
	unityFile.close();
	
}


void SimpleClass::LoadPosition() {
	ifstream unityFile("UnityLoad.txt", ifstream::in);
	string test;
	
	if (unityFile.good()) {
		getline(unityFile, test);
		string x;
		string y;
		string z;
		string* strptr = nullptr;
		for (int i = 0; i < test.length(); i++) {
			if (test[i] == 'X') {
				strptr = &x;
				continue;
			}
			else if (test[i] == 'Y') {
				strptr = &y;
				continue;
			}
			else if (test[i] == 'Z') {
				strptr = &z;
				continue;
			}
			if (strptr != nullptr) {
				*strptr +=  test[i];
			}
		}
		this->X = stof(x);
		this->Y = stof(y);
		this->Z = stof(z);
	}

}

float SimpleClass::getX()
{
	return this->X;
}

float SimpleClass::getY()
{
	return this->Y;
}

float SimpleClass::getZ()
{
	return this->Z;
}


