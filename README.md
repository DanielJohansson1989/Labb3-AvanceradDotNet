# Labb3-AvanceradDotNet

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
