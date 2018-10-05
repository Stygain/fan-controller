#include <Wire.h>
#include <Adafruit_RGBLCDShield.h>
#include <utility/Adafruit_MCP23017.h>

#include <dht.h>
#include <IRremote.h>

#define DHT_P 4
#define IR_P 2
#define THERM_P 0
 
#define transistorPin 6

#define NUM_MODES 2
#define UPPER_FAN_LIMIT 9
#define FAN_BAR_INDEX 11

dht DHT;
Adafruit_RGBLCDShield lcd = Adafruit_RGBLCDShield();
IRrecv irrecv(IR_P);
decode_results results;

// Custom characters for the LCD display.
const uint8_t cFanCharacterMask[] PROGMEM = {
  0b01100,
  0b01100,
  0b00101,
  0b11011,
  0b11011,
  0b10100,
  0b00110,
  0b00110,
};
const char cFanCharacter = '\x05';
const uint8_t cTemp1CharacterMask[] PROGMEM = {
  0b01000,
  0b10100,
  0b10100,
  0b10100,
  0b10100,
  0b11101,
  0b11101,
  0b01000
};
const char cTemp1Character = '\x06';
const uint8_t cTemp2CharacterMask[] PROGMEM = {
  0b01000,
  0b10101,
  0b10101,
  0b10100,
  0b10100,
  0b11101,
  0b11101,
  0b01000
};
const char cTemp2Character = '\x07';

int mode = 0;
int fanSpeed = 4;
char tempUnit = 'F';

long start_DHT = -1;
long start_DisplayChange = -1;
long start_IR = -1;

int Vo;
float R1 = 10000;
float logR2, R2, T;
float CT1, FT1, CT2, FT2;
float c1 = 1.009249522e-03, c2 = 2.378405444e-04, c3 = 2.019202697e-07;

int celTemp = 0;
float multiplier = (9.0 / 5.0);
int fahTemp = 0;

String lastCommand;

void setup() {
  Serial.begin(9600);
  // Prevents whining of fans
  setPwmFrequency(transistorPin, 8);
  lcd.begin(16, 2);
  irrecv.enableIRIn();
  irrecv.blink13(true);

  // Add custom characters for the fan as bar display.
  uint8_t bars[] = {B10000, B11000, B11100, B11110, B11111};
  uint8_t character[8];
  for (uint8_t i = 0; i < 5; ++i) {
    for (uint8_t j = 0; j < 8; ++j) character[j] = bars[i];
    lcd.createChar(i, character);
  }
  // Add custom characters from the masks.
  memcpy_P(character, cFanCharacterMask, 8);
  lcd.createChar(cFanCharacter, character);
  memcpy_P(character, cTemp1CharacterMask, 8);
  lcd.createChar(cTemp1Character, character);
  memcpy_P(character, cTemp2CharacterMask, 8);
  lcd.createChar(cTemp2Character, character);

  pinMode(transistorPin, OUTPUT);
  
  sampleData(celTemp, fahTemp);
  updateDisplay();
  updateFanDisplay(fanSpeed);
}

void lcdPrintPaddedDecimal(uint8_t value) {
  if (value < 10) {
    lcd.print('0');
  }
  lcd.print(value, DEC);
}

void displayMode (int mode) {
  lcd.clear();
  lcd.setCursor(0,0);
  if (mode == 1) {
    lcd.print("Manual");
  } else {
    lcd.print("Auto");
  }
  start_DisplayChange = millis();
}

void updateFanDisplay (int rate) {
  lcd.setCursor(FAN_BAR_INDEX,0);
  if (rate > 4) {
//    Serial.println("fan speed greater than 4");
    lcd.print(static_cast<char>(4));
    int tempFanSpeed = rate - 4;
    lcd.print(static_cast<char>(tempFanSpeed-1));
  } else {
//    Serial.println("fan speed not greater than 4");
    lcd.print(static_cast<char>(rate));
    lcd.print(' ');
  }
}

void changeMode (String irVal, int & mode, int & fanSpeed) {
  int modeBefore = mode;
  int speedBefore = fanSpeed;
  if (irVal == "ff5aa5") {
    mode++;
  } else if (irVal == "ff10ef") {
    mode--;
  }
  mode = (mode + NUM_MODES) % NUM_MODES;
  if (mode != modeBefore) {
    displayMode(mode);
  }
  
  if (irVal == "ff18e7") {
    if (fanSpeed != UPPER_FAN_LIMIT) {
      fanSpeed++;
    }
  } else if (irVal == "ff4ab5") {
    if (fanSpeed != 0) {
      fanSpeed--;
    }
  }
  if (fanSpeed != speedBefore) {
    updateFanDisplay(fanSpeed);
  }

  if (irVal == "ffa25d") {
    tempUnit = 'F';
    updateDisplay();
  }
  if (irVal == "ff629d") {
    tempUnit = 'C';
    updateDisplay();
  }
  start_IR = millis();
}

void updateDisplay () {
//  Serial.print("Final: ");
//  Serial.println(fahTemp);
  lcd.clear();
  lcd.setCursor(0,0);
  lcd.print(cTemp1Character);
  if (tempUnit == 'F') {
    lcd.print(fahTemp, DEC);
    lcd.print('\xdf');
    lcd.print("F ");
  } else {
    lcd.print(celTemp, DEC);
    lcd.print('\xdf');
    lcd.print("C ");
  }
  lcd.print(static_cast<uint8_t>(DHT.humidity), DEC);
  lcd.print('%');
  lcd.print(" ");
  lcd.print(cFanCharacter);
  updateFanDisplay(fanSpeed);
  lcd.setCursor(0,1);
  if (mode == 1) {
    lcd.print("M");
  } else {
    lcd.print("A");
  }
  lcd.print(" RPM");
}

void sampleData (int & celTemp, int & fahTemp) {
  int chk = DHT.read11(DHT_P);
  if (chk == 0) {
    CT1 = DHT.temperature;
    float celMult = CT1 * multiplier;
    FT1 = celMult + 32;
//    Serial.print("T1 ");
//    Serial.println(FT1);
  }
  
  Vo = analogRead(THERM_P);
  R2 = R1 * (1023.0 / (float)Vo - 1.0);
  logR2 = log(R2);
  T = (1.0 / (c1 + c2*logR2 + c3*logR2*logR2*logR2));
  CT2 = T - 273.15;
  FT2 = (CT2 * 9.0)/ 5.0 + 32.0;
//  Serial.print("T2 ");
//  Serial.println(FT2);

  int celTempCache = celTemp;
  int fahTempCache = fahTemp;

  if (chk == 0) {
    celTemp = (int)((CT1 + CT2) / 2);
    fahTemp = (int)((FT1 + FT2) / 2);
  } else {
    celTemp = (int)CT2;
    fahTemp = (int)FT2;
  }

  if (celTempCache != celTemp || fahTempCache != fahTemp) {
//    Serial.println("Actually updating 1");
    updateDisplay();
  }
  
  start_DHT = millis();
}

/**
 * Divides a given PWM pin frequency by a divisor.
 * 
 * The resulting frequency is equal to the base frequency divided by
 * the given divisor:
 *   - Base frequencies:
 *      o The base frequency for pins 3, 9, 10, and 11 is 31250 Hz.
 *      o The base frequency for pins 5 and 6 is 62500 Hz.
 *   - Divisors:
 *      o The divisors available on pins 5, 6, 9 and 10 are: 1, 8, 64,
 *        256, and 1024.
 *      o The divisors available on pins 3 and 11 are: 1, 8, 32, 64,
 *        128, 256, and 1024.
 * 
 * PWM frequencies are tied together in pairs of pins. If one in a
 * pair is changed, the other is also changed to match:
 *   - Pins 5 and 6 are paired on timer0
 *   - Pins 9 and 10 are paired on timer1
 *   - Pins 3 and 11 are paired on timer2
 * 
 * Note that this function will have side effects on anything else
 * that uses timers:
 *   - Changes on pins 3, 5, 6, or 11 may cause the delay() and
 *     millis() functions to stop working. Other timing-related
 *     functions may also be affected.
 *   - Changes on pins 9 or 10 will cause the Servo library to function
 *     incorrectly.
 * 
 * Thanks to macegr of the Arduino forums for his documentation of the
 * PWM frequency divisors. His post can be viewed at:
 *   http://forum.arduino.cc/index.php?topic=16612#msg121031
 */
void setPwmFrequency(int pin, int divisor) {
  byte mode;
  if(pin == 5 || pin == 6 || pin == 9 || pin == 10) {
    switch(divisor) {
      case 1: mode = 0x01; break;
      case 8: mode = 0x02; break;
      case 64: mode = 0x03; break;
      case 256: mode = 0x04; break;
      case 1024: mode = 0x05; break;
      default: return;
    }
    if(pin == 5 || pin == 6) {
      TCCR0B = TCCR0B & 0b11111000 | mode;
    } else {
      TCCR1B = TCCR1B & 0b11111000 | mode;
    }
  } else if(pin == 3 || pin == 11) {
    switch(divisor) {
      case 1: mode = 0x01; break;
      case 8: mode = 0x02; break;
      case 32: mode = 0x03; break;
      case 64: mode = 0x04; break;
      case 128: mode = 0x05; break;
      case 256: mode = 0x06; break;
      case 1024: mode = 0x07; break;
      default: return;
    }
    TCCR2B = TCCR2B & 0b11111000 | mode;
  }
}
//end arduino code

String serial_read = "";

void loop() {

  if (Serial.available() > 0) {
    int incomingByte = Serial.read();
//    Serial.print("I received: ");
//    Serial.println(incomingByte, DEC);
    char char_rec = (char)incomingByte;
    serial_read = serial_read + char_rec;
  }
  if (serial_read.length() == 5) {
    lcd.setCursor(5,1);
    lcd.print(serial_read);
    serial_read = "";
  }
  
  if (irrecv.decode(&results) && (millis() > (50+start_IR) || start_IR == -1)) {
    String value;
//    Serial.print("What we got: ");
//    Serial.print(results.value, HEX);
//    Serial.print(" ");
//    Serial.println(lastCommand);
    if (results.value == 0xFFFFFFFF) {
//      Serial.println("We got a repeat");
      value = lastCommand;
    } else {
      lastCommand = String(results.value, HEX);
      value = String(results.value, HEX);
    }
//    Serial.println(results.value, HEX);
//    Serial.println(value);
    changeMode(value, mode, fanSpeed);
    irrecv.resume();
  }

  unsigned long currTime = millis();
  if (start_DHT != -1 && currTime >= (start_DHT + 2000)) {
//    Serial.println("It is time to sample");
    sampleData(celTemp, fahTemp);
//    Serial.println("Update display 1");
//    updateDisplay();
  }
  if (start_DisplayChange != -1 && currTime >= (start_DisplayChange + 1000)) {
//    Serial.println("It is time to update the display after waiting");
//    Serial.println("Update display 2");
//    updateDisplay();
    start_DisplayChange = -1;
  }

  int temp_fanSpeed = 10 - fanSpeed;
  int outputValue = map(temp_fanSpeed, 1, 10, 0, 255);
  analogWrite(transistorPin, outputValue);
}
