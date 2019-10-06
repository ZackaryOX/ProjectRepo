#include "SimpleClass.h"
using namespace std;
int SimpleClass::SimpleFunction()
{
	return 1;
}


void SimpleClass::ClearFile()
{
	ofstream unityFile;
	unityFile.open("UnityLoad.txt");
	unityFile.clear();
	unityFile.close();
	this->currentLine = 1;
}
void SimpleClass::SavePosition(int ID,float x, float y, float z, float x2, float y2, float z2) {
	string XString = "X" + to_string(x);
	string YString = "Y" + to_string(y);
	string ZString = "Z" + to_string(z);

	string XString2 = "X" + to_string(x2);
	string YString2 = "Y" + to_string(y2);
	string ZString2 = "Z" + to_string(z2);

	string FinalString = to_string(ID) + XString + YString + ZString + XString2 + YString2 + ZString2;
	ofstream unityFile;

	unityFile.open("UnityLoad.txt", ios::out | ios::app);
	if (unityFile.is_open()) {
		unityFile << FinalString << endl;
	}
	unityFile.close();
	
}

int SimpleClass::CountLines() {
	ifstream unityFile("UnityLoad.txt", ifstream::in);
	int counter = 0;
	if (unityFile.good()) {
		
		while (!unityFile.eof()) {
			string plchldr;
			getline(unityFile, plchldr);
			counter++;
		}

	}
	unityFile.close();
	return counter;
}
void SimpleClass::LoadPosition() {
	ifstream unityFile("UnityLoad.txt", ifstream::in);
	string test;
	
	if (unityFile.good()) {


		for (int i = 0; i < this->currentLine; i++) {
			if(!unityFile.eof())
			getline(unityFile, test);
		}
		string ID;
		string x = "";
		string y = "";
		string z = "";
		string x2;
		string y2;
		string z2;
		string* strptr = nullptr;
		for (int i = 0; i < test.length(); i++) {
			if (test[i] == 'X') {
				if(x == "")
					strptr = &x;
				else 
					strptr = &x2;

				continue;
			}
			else if (test[i] == 'Y') {
				if (y == "")
					strptr = &y;
				else
					strptr = &y2;

				continue;
			}
			else if (test[i] == 'Z') {
				if (z == "")
					strptr = &z;
				else
					strptr = &z2;

				continue;
			}
			else if(strptr == nullptr) {
				ID += test[i];
			}


			if (strptr != nullptr) {
				*strptr += test[i];
			}

		}
			
		this->X = stof(x);
		this->Y = stof(y);
		this->Z = stof(z);
		this->X2 = stof(x2);
		this->Y2 = stof(y2);
		this->Z2 = stof(z2);
		this->ID = stoi(ID);
		this->currentLine++;

	}
	unityFile.close();

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

float SimpleClass::getX2()
{
	return this->X2;
}

float SimpleClass::getY2()
{
	return this->Y2;
}

float SimpleClass::getZ2()
{
	return this->Z2;
}

void SimpleClass::setCurrentLine(int x)
{
	this->currentLine = x;
}

int SimpleClass::getID()
{
	return this->ID;
}


