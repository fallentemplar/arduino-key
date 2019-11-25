#define LEDPin 13
String SerialInput;

int nodoInicio = 0;
int nodoFin = 37;

int nodo[38][6] = {
    {0, 1, 2},    // 1
    {1, 0, 3},    // 2
    {2, 3, 4, 5}, // 3
    {3, 7, 9},    // 4
    {4, 2, 5},
    {5, 6, 7},
    {6, 5, 22},
    {7, 8, 13, 16},
    {8, 3, 9, 16},
    {9, 10},
    {10, 11, 18},
    {11, 10, 12, 18},
    {12, 11, 17},
    {13, 14, 17},
    {14, 15, 20},
    {15, 7},
    {16, 12, 13},
    {17, 17, 19, 20},
    {18, 12, 19},
    {19, 20, 27},
    {20, 14, 21, 26},
    {21, 22},
    {22, 14, 21, 23, 24, 25},
    {23, 25},
    {24, 32},
    {25, 29, 30, 31},
    {26, 25},
    {27, 18, 28},
    {28, 28, 30, 35},
    {29, 32},
    {30, 26, 28, 34},
    {31, 33, 34},
    {32, 33},
    {33, 37},
    {34, 33, 37},
    {35, 36},
    {36, 37},
    {37, 34, 37}};
char peso[38][5] = {
    {'A', 'D'},
    {'8', 'P'},
    {'F', 'E', '9'},
    {'C', 'W'},
    {'D', 'Z'},
    {'5', 'C'},
    {'9', 'Q'},
    {'6', '0', 'M'},
    {'C', '2', '5'},
    {'B'},
    {'5', 'V'},
    {'B', 'D', '7'},
    {'4', '9'},
    {'3', 'T'},
    {'B', 'I'},
    {'F'},
    {'4', 'N'},
    {'E', 'D', '8'},
    {'C', '2'},
    {'4', 'A'},
    {'R', 'B', '7'},
    {'0'},
    {'H', 'C', '2', '8', '1'},
    {'3'},
    {'U'},
    {'7', 'E', 'A'},
    {'2'},
    {'4', '0'},
    {'3', 'C', '4'},
    {'A'},
    {'3', '7', 'V'},
    {'K', 'Ñ'},
    {'6'},
    {'C'},
    {'5', 'P'},
    {'1'},
    {'4'},
    {'Q', '4'}};

void setup()
{
  pinMode(LEDPin, OUTPUT);
  // serial communication
  Serial.begin(9600);
}

void loop()
{
  while (Serial.available())
  {
    SerialInput = Serial.readString();
    if (Recorrido(SerialInput))
    {
      digitalWrite(LEDPin, HIGH);
      delay(500);
      digitalWrite(LEDPin, LOW);
      delay(500);
      digitalWrite(LEDPin, HIGH);
      delay(500);
      digitalWrite(LEDPin, LOW);
      delay(500);
      Serial.println("Y");
    }
    else
    {
      digitalWrite(LEDPin, HIGH);
      Serial.println("N");
    }
  }
}

bool Recorrido(String llave)
{
  int i = 0, pos_recorrido = 0;
  int con = nodoInicio; // actual
  
  while (i < llave.length())
  {
    pos_recorrido = i;
    //for (int j = 1; j < nodo[con].length(); j++)
    int a = sizeof(nodo[con]);
    for (int j = 1; j < a / 2; j++)
    {
      if (llave.charAt(i) == peso[con][j - 1])
      {
        con = nodo[con][j];
        i++;
        break;
      }
    }
    if (pos_recorrido == i)
    {
      return false;
    }
  }
  return con == nodoFin;
}
