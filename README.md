# Labb3-AvanceradDotNet
Hämta alla personer i systemet
Get
respons: 
[
  {
    "personId": 1,
    "firstName": "Daniel",
    "lastName": "Johansson",
    "phone": "0703157383",
    "personalInterest": null
  },
  {
    "personId": 2,
    "firstName": "Sara",
    "lastName": "Larsson",
    "phone": "0702456700",
    "personalInterest": null
  },
  {
    "personId": 3,
    "firstName": "Victor",
    "lastName": "Svensson",
    "phone": "0765438976",
    "personalInterest": null
  }
]
------------------------------------------------------------------------------
Hämta alla intressen som är kopplade till en specifik person
Get Person/withInterests
response:
{
  "personId": 1,
  "firstName": "Daniel",
  "lastName": "Johansson",
  "phone": "0703157383",
  "personalInterest": [
    {
      "personalInterestId": 1,
      "personId": 1,
      "person": null,
      "interestId": 1,
      "interest": {
        "interestId": 1,
        "title": "Skiing",
        "description": "Skiing is a popular winter sport that involves sliding down snow-covered slopes on long, narrow boards called skis attached to boots. It's not just about gliding down the mountain; it's a dynamic blend of athleticism, technique, and connection with nature. Skiers use a combination of gravity, momentum, and their own muscle power to navigate various terrains, from gentle slopes to steep mountainsides",
        "personalInterest": [
          null
        ]
      },
      "link": null
    },
    {
      "personalInterestId": 2,
      "personId": 1,
      "person": null,
      "interestId": 2,
      "interest": {
        "interestId": 2,
        "title": "Chess",
        "description": "Chess is played by two opponents on a square board divided into 64 smaller squares of alternating colors, typically black and white. Each player starts with an identical set of 16 pieces: one king, one queen, two rooks, two knights, two bishops, and eight pawns. The objective of chess is to checkmate your opponent's king.",
        "personalInterest": [
          null
        ]
      },
      "link": null
    }
  ]
}
--------------------------------------------------------------------------------
Hämta alla länkar för en person
Get Person/withLinks
response:
{
  "personId": 1,
  "firstName": "Daniel",
  "lastName": "Johansson",
  "phone": "0703157383",
  "personalInterest": [
    {
      "personalInterestId": 1,
      "personId": 1,
      "person": null,
      "interestId": 1,
      "interest": null,
      "link": [
        {
          "linkId": 1,
          "url": "skidresor.se",
          "personalInterestId": 1,
          "personalInterest": null
        },
        {
          "linkId": 2,
          "url": "skistar.com",
          "personalInterestId": 1,
          "personalInterest": null
        }
      ]
    },
    {
      "personalInterestId": 2,
      "personId": 1,
      "person": null,
      "interestId": 2,
      "interest": null,
      "link": [
        {
          "linkId": 3,
          "url": "chess.com",
          "personalInterestId": 2,
          "personalInterest": null
        }
      ]
    }
  ]
}
----------------------------------------------------------------------------------
Koppla en person till ett nytt intresse.
PersonalInterest Post
{
  "personId": 2,  
  "interestId": 7  
}
Respons: 
{
  "personalInterestId": 7,
  "personId": 2,
  "person": null,
  "interestId": 7,
  "interest": null,
  "link": null
}
----------------------------------------------------------------
Lägga in ny länk för en specifik person och intresse.
Link Post
{

  "url": "https://en.wikipedia.org/wiki/Fencing",
  "personalInterestId": 7
}
Respons: 
{
  "linkId": 11,
  "url": "https://en.wikipedia.org/wiki/Fencing",
  "personalInterestId": 7,
  "personalInterest": null
}
