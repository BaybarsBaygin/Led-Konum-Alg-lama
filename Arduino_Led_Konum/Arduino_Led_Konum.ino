int gelen;
int Led1=10;
int Led2=9;
int Led3=8;
int Led4=7;
int Led5=6;
int Led6=5;
int Led7=4;
int Led8=3;
int Led9=2;
void setup() {

Serial.begin(9600);
pinMode(Led1,OUTPUT);
pinMode(Led2,OUTPUT);
pinMode(Led3,OUTPUT);
pinMode(Led4,OUTPUT);
pinMode(Led5,OUTPUT);
pinMode(Led6,OUTPUT);
pinMode(Led7,OUTPUT);
pinMode(Led8,OUTPUT);
pinMode(Led9,OUTPUT);
}
void loop() 
{
  if(Serial.available() >0)
    { 
      gelen = Serial.read();
      if(gelen == '1')
      {
        digitalWrite(Led1,HIGH);
      }
      if(gelen == 'a')
      {
        digitalWrite(Led1,LOW);
      }
      if(gelen == '2')
      {
        digitalWrite(Led2,HIGH);
      }
      if(gelen == 'b')
      {
        digitalWrite(Led2,LOW);
      }
      if(gelen == '3')
      {
        digitalWrite(Led3,HIGH);
      }
      if(gelen == 'c')
      {
        digitalWrite(Led3,LOW);
      }
      if(gelen == '4')
      {
        digitalWrite(Led4,HIGH);
      }
      if(gelen == 'd')
      {
        digitalWrite(Led4,LOW);
      }
          if(gelen == '5')
      {
        digitalWrite(Led5,HIGH);
      }
      if(gelen == 'e')
      {
        digitalWrite(Led5,LOW);
      }
      if(gelen == '6')
      {
        digitalWrite(Led6,HIGH);
      }
      if(gelen == 'f')
      {
        digitalWrite(Led6,LOW);
      }
      if(gelen == '7')
      {
        digitalWrite(Led7,HIGH);
      }
       if(gelen == 'g')
      {
        digitalWrite(Led7,LOW);
      }
      if(gelen == '8')
      {
        digitalWrite(Led8,HIGH);
      }
      if(gelen == 'h')
      {
        digitalWrite(Led8,LOW);
      }
      if(gelen == '9')
      {
        digitalWrite(Led9,HIGH);
      }
      if(gelen == 'j')
      {
        digitalWrite(Led9,LOW);
      }
    }
}


  
