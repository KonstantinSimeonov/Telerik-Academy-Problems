#include <iostream>
#include <string>
#include <Windows.h>
using namespace std;

#define DEBUG_MODE

class Field
{
private:
	int numAliveNeighboursForSurvival;
	int numAliveNeighboursForBirth;
	bool living;
	bool dead;

	unsigned int generations;

	int rows, cols;
	bool ** fieldBuffers[2];
	int frontBufferIndex;

	void InitializeFieldBuffers()
	{
		this->fieldBuffers[0] = new bool* [rows];
		for (int i=0; i<rows; i++)
		{
			this->fieldBuffers[0][i] = new bool [cols];
		}
		this->fieldBuffers[1] = new bool* [rows];
		for (int i=0; i<rows; i++)
		{
			this->fieldBuffers[1][i] = new bool [cols];
		}
	}

	bool IsInField (int cellRow, int cellCol)
	{
		if (cellRow < 0 || cellCol < 0)
		{
			return false;
		}
		if (cellRow >= this->rows || cellCol >= this->cols)
		{
			return false;
		}
		return true;
	}

	void Initialize ()
	{
		this->generations = 0;
		this->numAliveNeighboursForSurvival = 2;
		this->numAliveNeighboursForBirth = 3;
		this->living = true;
		this->dead = false;

		this->frontBufferIndex=0;
		this->rows = 0;
		this->cols = 0;
		this->fieldBuffers[0] = NULL;
		this->fieldBuffers[0] = NULL;
	}

#ifdef DEBUG_MODE
public:
#endif
	int GetNumAliveNeighbours(int cellRow, int cellCol, int bufferIndex)
	{
		int alive = 0;
		int currCellRow, currCellCol;

		//in previous row 
		currCellRow = cellRow - 1; currCellCol = cellCol - 1;
		if (this->IsInField(currCellRow, currCellCol) && this->fieldBuffers[bufferIndex][currCellRow][currCellCol]) alive++;

		currCellRow = cellRow - 1; currCellCol = cellCol;
		if (this->IsInField(currCellRow, currCellCol) && this->fieldBuffers[bufferIndex][currCellRow][currCellCol]) alive++;

		currCellRow = cellRow - 1; currCellCol = cellCol + 1;
		if (this->IsInField(currCellRow, currCellCol) && this->fieldBuffers[bufferIndex][currCellRow][currCellCol]) alive++;

		//in current row
		currCellRow = cellRow; currCellCol = cellCol - 1;
		if (this->IsInField(currCellRow, currCellCol) && this->fieldBuffers[bufferIndex][currCellRow][currCellCol]) alive++;

		currCellRow = cellRow; currCellCol = cellCol + 1;
		if (this->IsInField(currCellRow, currCellCol) && this->fieldBuffers[bufferIndex][currCellRow][currCellCol]) alive++;

		//in next row
		currCellRow = cellRow + 1; currCellCol = cellCol - 1;
		if (this->IsInField(currCellRow, currCellCol) && this->fieldBuffers[bufferIndex][currCellRow][currCellCol]) alive++;

		currCellRow = cellRow + 1; currCellCol = cellCol;
		if (this->IsInField(currCellRow, currCellCol) && this->fieldBuffers[bufferIndex][currCellRow][currCellCol]) alive++;

		currCellRow = cellRow + 1; currCellCol = cellCol + 1;
		if (this->IsInField(currCellRow, currCellCol) && this->fieldBuffers[bufferIndex][currCellRow][currCellCol]) alive++;

		return alive;
	}

public:
	Field ()
	{
		this->Initialize();
	}

	Field (int rows, int cols)
	{
		this->Initialize();
		this->frontBufferIndex=0;
		this->rows = rows;
		this->cols = cols;
		this->InitializeFieldBuffers();
	}

	void EvolveNextGeneration()
	{
		this->generations++;
		int backBufferIndex = this->frontBufferIndex;
		this->frontBufferIndex ^= 1;
		for (int row = 0; row < this->rows; row++)
		{
			for (int col = 0; col < this->cols; col++)
			{
				int numAliveNeighbours = this->GetNumAliveNeighbours(row, col, backBufferIndex);
				bool lastState = this->fieldBuffers[backBufferIndex][row][col];
				if (lastState == this->living)
				{
					if (numAliveNeighbours == this->numAliveNeighboursForSurvival || numAliveNeighbours == this->numAliveNeighboursForBirth)
					{
						this->fieldBuffers[frontBufferIndex][row][col] = this->living;
					}
					else
					{
						this->fieldBuffers[frontBufferIndex][row][col] = this->dead;
					}
				}
				else
				{
					if (numAliveNeighbours == this->numAliveNeighboursForBirth)
					{
						this->fieldBuffers[frontBufferIndex][row][col] = this->living;
					}
					else
					{
						this->fieldBuffers[frontBufferIndex][row][col] = this->dead;
					}
				}
			}
		}
	}

	void CopyFieldDataFrom (bool ** fieldMatrix, int matrixRows, int matrixCols)
	{
		this->rows = matrixRows;
		this->cols = matrixCols;
		this->InitializeFieldBuffers();
		for(int row = 0; row < matrixRows; row++)
		{
			for(int col = 0; col < matrixCols; col++)
			{
				this->fieldBuffers[this->frontBufferIndex][row][col] = fieldMatrix[row][col];
			}
		}
	}

	void ReadFromStandardInput()
	{
		scanf ("%d%d", &this->rows, &this->cols);
		this->InitializeFieldBuffers();
		for (int row = 0; row<this->rows; row++)
		{
			for (int col = 0; col < this->cols; col++)
			{
				int input;
				scanf("%d", &input);
				this->fieldBuffers [this->frontBufferIndex][row][col] = input;
			}
		}
	}

	int GetNumAliveInCurrentGeneration ()
	{
		int numAlive = 0;
		for (int row = 0; row < this->rows; row++)
		{
			for (int col = 0; col < this->cols; col++)
			{
				if (this->fieldBuffers[this->frontBufferIndex][row][col] == this->living)
				{
					numAlive++;
				}
			}
		}
		return numAlive;
	}
	
	void Print()
	{
		for (int row = 0; row < this->rows; row++)
		{
			for (int col = 0; col < this->cols; col++)
			{
				if (this->fieldBuffers[this->frontBufferIndex][row][col])
				{
					printf ("#");
				}
				else
				{
					printf (" ");
				}
			}
			printf ("\n");
		}
		printf ("%d\n", this->generations);
	}
};

#ifdef DEBUG_MODE
void TestLifeFieldGetLiveNeighboursCount()
{
	Field lifeField = Field();
	lifeField.ReadFromStandardInput();
	lifeField.Print();
	int cellRow, cellCol;
	cin>>cellRow>>cellCol;
	cout << lifeField.GetNumAliveNeighbours(cellRow, cellCol, 0);
}

void TestLifeFieldReadAndPrint()
{
	Field lifeField = Field();
	lifeField.ReadFromStandardInput();
	lifeField.Print();
}

void TestLifeFieldEvolveNextGeneration()
{
	Field lifeField = Field();
	lifeField.ReadFromStandardInput();
	lifeField.Print();
	while(true)
	{
		
		lifeField.EvolveNextGeneration();
		system("pause");
		lifeField.Print();
	}
}
#endif



int main()
{
	//TestLifeFieldEvolveNextGeneration();

	int lastGenerationToEvolve = 0;
	cout << "last generation to evolve:"<<endl;
	cin >> lastGenerationToEvolve;

	Field lifeField = Field();
	lifeField.ReadFromStandardInput();
	int currentGeneration = 1;
	while(currentGeneration <= lastGenerationToEvolve )
	{
		lifeField.EvolveNextGeneration();
		currentGeneration++;

		system("cls");
		lifeField.Print();
		Sleep(75);
	}
	cout << lifeField.GetNumAliveInCurrentGeneration() << endl;

	return 0;
}